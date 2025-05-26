using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using FourPicsOneWordGame.Models;
using MySql.Data.MySqlClient;

namespace FourPicsOneWordGame
{
    public partial class GamePlayForm : Form
    {
        private GameLevel? _currentLevel;
        private string _baseImagePath;
        private List<Label> _answerSlots = new List<Label>();
        private List<Button> _letterBankButtons = new List<Button>();
        private const int TOTAL_BANK_LETTERS = 14;
        private const int MAX_HINTS_PER_LEVEL = 2;
        private int _hintsUsedThisLevel = 0;
        private int _playerLevelCounter = 1;
        private long _currentTotalScore = 0;
        private int _wrongGuessesThisLevel = 0;
        private int _pointsEarnedThisLevelAttempt = 0;
        public GamePlayForm()
        {
            InitializeComponent();
            _baseImagePath = Path.Combine(Application.StartupPath, "Images");
        }

        private async void GamePlayForm_Load(object sender, EventArgs e)
        {
            _playerLevelCounter = 1;
            await FetchInitialTotalScoreAsync();
            await LoadAndDisplayNextLevelAsync();
        }

        private async Task FetchInitialTotalScoreAsync()
        {
            if (CurrentUser.LoggedInUser == null)
            {
                _currentTotalScore = 0;
                UpdateTotalScoreDisplay();
                return;
            }

            int userId = CurrentUser.LoggedInUser.UserId;
            long scoreFromDb = 0;

            try
            {
                using (var connection = new MySqlConnection(DbHelper.ConnectionString))
                {
                    await connection.OpenAsync();

                    string query = "SELECT SUM(Score) FROM userprogresses WHERE UserId = @UserId AND IsCompleted = 1;";

                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserId", userId);

                        object? result = await command.ExecuteScalarAsync();

                        if (result != null && result != DBNull.Value)

                        {

                            scoreFromDb = Convert.ToInt64(result);

                        }

                    }

                }

                _currentTotalScore = scoreFromDb;

            }

            catch (Exception ex)

            {

                MessageBox.Show($"Error loading total score: {ex.Message}", "Score Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                _currentTotalScore = 0;

            }

            UpdateTotalScoreDisplay();

        }



        private void UpdateTotalScoreDisplay()

        {

            if (this.Controls.ContainsKey("lblGameTotalScore"))

            {

                (this.Controls["lblGameTotalScore"] as Label).Text = $"Total Score: {_currentTotalScore}";

            }

        }



        private async Task LoadAndDisplayNextLevelAsync()

        {

            ClearGameBoard();

            _currentLevel = null;

            _hintsUsedThisLevel = 0; 

            _wrongGuessesThisLevel = 0;

            _pointsEarnedThisLevelAttempt = 10;



            if (CurrentUser.LoggedInUser == null)

            {

                MessageBox.Show("No user is logged in. Cannot load level.", "Authentication Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                this.Close();

                return;

            }

            int currentUserId = CurrentUser.LoggedInUser.UserId;



            try

            {

                using (var connection = new MySqlConnection(DbHelper.ConnectionString))

                {

                    await connection.OpenAsync();

                    string query = @"
                    SELECT 
                        gl.GameLevelId, 
                        gl.CorrectWord, 
                        gl.ImagePath1, 
                        gl.ImagePath2, 
                        gl.ImagePath3, 
                        gl.ImagePath4, 
                        up.HintsUsedInAttempt, 
                        up.WrongGuessesInAttempt, 
                        up.Score AS PersistedAttemptScore, 
                        up.IsCompleted 
                    FROM 
                        gamelevels gl 
                    LEFT JOIN 
                        userprogresses up 
                        ON gl.GameLevelId = up.GameLevelId AND up.UserId = @CurrentUserId 
                    WHERE 
                        gl.GameLevelId NOT IN (
                            SELECT sup.GameLevelId 
                            FROM userprogresses sup 
                            WHERE sup.UserId = @CurrentUserId AND sup.IsCompleted = 1
                        ) 
                    ORDER BY 
                        gl.GameLevelId ASC 
                    LIMIT 1;";


                    using (var command = new MySqlCommand(query, connection))

                    {

                        command.Parameters.AddWithValue("@CurrentUserId", currentUserId);

                        using (var reader = await command.ExecuteReaderAsync())

                        {

                            if (await reader.ReadAsync())

                            {

                                _currentLevel = new GameLevel

                                {

                                    GameLevelId = reader.GetInt32(reader.GetOrdinal("GameLevelId")),

                                    CorrectWord = reader.GetString(reader.GetOrdinal("CorrectWord")).ToUpper(),

                                    ImagePath1 = reader.GetString(reader.GetOrdinal("ImagePath1")),

                                    ImagePath2 = reader.GetString(reader.GetOrdinal("ImagePath2")),

                                    ImagePath3 = reader.GetString(reader.GetOrdinal("ImagePath3")),

                                    ImagePath4 = reader.GetString(reader.GetOrdinal("ImagePath4"))

                                };



                                bool hasPersistedUserProgressRecord = !reader.IsDBNull(reader.GetOrdinal("IsCompleted"));



                                if (hasPersistedUserProgressRecord)

                                {

                                    if (!reader.IsDBNull(reader.GetOrdinal("HintsUsedInAttempt")))

                                    {

                                        _hintsUsedThisLevel = reader.GetInt32(reader.GetOrdinal("HintsUsedInAttempt"));

                                    }


                                    if (!reader.IsDBNull(reader.GetOrdinal("PersistedAttemptScore")))

                                    {

                                        _pointsEarnedThisLevelAttempt = reader.GetInt32(reader.GetOrdinal("PersistedAttemptScore"));

                                    }


                                    if (!reader.IsDBNull(reader.GetOrdinal("WrongGuessesInAttempt")))

                                    {

                                        _wrongGuessesThisLevel = reader.GetInt32(reader.GetOrdinal("WrongGuessesInAttempt"));

                                    }


                                }

                            }

                        }

                    }

                }



                if (_currentLevel != null)

                {

                    DisplayLevelInfo();

                }

                else

                {

                    DisableGameControls();

                    DialogResult gameFinishedChoice = MessageBox.Show(

                      $"Congratulations, {CurrentUser.LoggedInUser?.UserName}!\n" +

                      "You have completed all available levels!\n\n" +

                      $"Your final total score is: {_currentTotalScore}\n\n" +

                      "Would you like to restart the game from Level 1?",

                      "Game Finished!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);



                    if (gameFinishedChoice == DialogResult.Yes)

                    {

                        bool restartSuccess = await DeleteUserProgressAsync(CurrentUser.LoggedInUser.UserId);

                        if (restartSuccess)

                        {

                            MessageBox.Show("Progress reset! Starting from Level 1.", "Progress Reset");

                            _playerLevelCounter = 1;

                            _currentTotalScore = 0;

                            _pointsEarnedThisLevelAttempt = 0;

                            UpdateTotalScoreDisplay();

                            await LoadAndDisplayNextLevelAsync(); 

                        }

                        else { this.Close(); }

                    }

                    else { this.Close(); }

                }

            }

            catch (MySqlException ex) { MessageBox.Show($"DB error loading level: {ex.Message}"); this.Close(); }

            catch (Exception ex) { MessageBox.Show($"Unexpected error loading level: {ex.Message}"); this.Close(); }

        }



        private void DisplayLevelInfo()

        {

            if (_currentLevel == null || string.IsNullOrEmpty(_currentLevel.CorrectWord))

            {

                ClearGameBoard();

                lblGameMessage.Text = "Error: Level data missing.";

                DisableGameControls();

                return;

            }



            if (this.Controls.ContainsKey("lblPlayerLevelDisplay"))

            {

                this.Controls["lblPlayerLevelDisplay"].Text = $"Level: {_playerLevelCounter}";

            }

            else { this.Text = $"Wordpic - Level: {_playerLevelCounter}"; }



            DisplayImage(pbImage1, _currentLevel.ImagePath1);

            DisplayImage(pbImage2, _currentLevel.ImagePath2);

            DisplayImage(pbImage3, _currentLevel.ImagePath3);

            DisplayImage(pbImage4, _currentLevel.ImagePath4);



            SetupAnswerSlots();

            if (flpAnswerSlots.Controls.Count > 0) flpAnswerSlots.Left = (this.ClientSize.Width - flpAnswerSlots.Width) / 2;



            SetupLetterBank();

            if (flpLetterBank.Controls.Count > 0) flpLetterBank.Left = (this.ClientSize.Width - flpLetterBank.Width) / 2;



            lblGameMessage.Text = "";



            EnableGameControls();

        }



        private void DisplayImage(PictureBox targetPictureBox, string relativeImagePath)

        {

            try

            {

                Image oldImage = targetPictureBox.Image;

                targetPictureBox.Image = null;

                oldImage?.Dispose();



                if (string.IsNullOrWhiteSpace(relativeImagePath)) return;

                string fullPath = Path.Combine(_baseImagePath, relativeImagePath);



                if (File.Exists(fullPath))

                {

                    using (FileStream stream = new FileStream(fullPath, FileMode.Open, FileAccess.Read))

                    { targetPictureBox.Image = Image.FromStream(stream); }

                }

                else { lblGameMessage.Text += $"Warn: Img not found '{relativeImagePath}'.\n"; }

            }

            catch { lblGameMessage.Text += $"Err loading img '{relativeImagePath}'.\n"; }

        }



        private void ClearGameBoard()

        {

            pbImage1.Image?.Dispose(); pbImage1.Image = null;

            pbImage2.Image?.Dispose(); pbImage2.Image = null;

            pbImage3.Image?.Dispose(); pbImage3.Image = null;

            pbImage4.Image?.Dispose(); pbImage4.Image = null;



            flpAnswerSlots.Controls.Clear(); _answerSlots.Clear();

            flpLetterBank.Controls.Clear(); _letterBankButtons.Clear();



            lblGameMessage.Text = "";



            if (this.Controls.ContainsKey("btnNextLevel")) this.Controls["btnNextLevel"].Visible = false;

        }



        private void SetupAnswerSlots()

        {

            flpAnswerSlots.Controls.Clear(); _answerSlots.Clear();

            if (_currentLevel == null || string.IsNullOrEmpty(_currentLevel.CorrectWord)) return;



            foreach (char c in _currentLevel.CorrectWord)

            {

                Label slotLabel = new Label

                {

                    Text = "",

                    Font = new Font("Segoe UI", 18F, FontStyle.Bold),

                    Size = new Size(40, 40),

                    BorderStyle = BorderStyle.FixedSingle,

                    TextAlign = ContentAlignment.MiddleCenter,

                    Margin = new Padding(3),

                    Tag = null

                };

                slotLabel.Click += AnswerSlot_Click;

                flpAnswerSlots.Controls.Add(slotLabel);

                _answerSlots.Add(slotLabel);

            }

        }



        private void AnswerSlot_Click(object sender, EventArgs e)

        {

            Label clickedAnswerSlot = sender as Label;

            if (clickedAnswerSlot == null || string.IsNullOrEmpty(clickedAnswerSlot.Text) || clickedAnswerSlot.Text == "_") return;



            if (clickedAnswerSlot.Tag is string tagString && tagString == "HINT_REVEALED")

            {

                lblGameMessage.Text = "Revealed letters cannot be removed.";

                lblGameMessage.ForeColor = Color.Orange;

                return;

            }



            if (clickedAnswerSlot.Tag is Button associatedBankButton)

            {

                associatedBankButton.Enabled = true;

                clickedAnswerSlot.Text = "";

                clickedAnswerSlot.Tag = null;

                lblGameMessage.Text = "";

                if (this.Controls.ContainsKey("btnNextLevel") && this.Controls["btnNextLevel"].Visible)

                { this.Controls["btnNextLevel"].Visible = false; }




                if (btnShowHint != null) btnShowHint.Enabled = (_hintsUsedThisLevel < MAX_HINTS_PER_LEVEL);

            }

        }



        private void SetupLetterBank()

        {

            flpLetterBank.Controls.Clear(); _letterBankButtons.Clear();

            if (_currentLevel == null || string.IsNullOrEmpty(_currentLevel.CorrectWord)) return;



            List<char> letters = new List<char>();

            foreach (char c in _currentLevel.CorrectWord.ToUpper()) { letters.Add(c); }



            Random random = new Random();

            string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            while (letters.Count < TOTAL_BANK_LETTERS)

            {

                letters.Add(alphabet[random.Next(alphabet.Length)]);

            }

            letters = letters.OrderBy(x => random.Next()).ToList();



            foreach (char letter in letters)

            {

                Button letterButton = new Button

                {

                    Text = letter.ToString(),

                    Font = new Font("Segoe UI", 12F, FontStyle.Bold),

                    Size = new Size(40, 40),

                    Margin = new Padding(3),

                    Tag = letter

                };

                letterButton.Click += LetterBankButton_Click;

                flpLetterBank.Controls.Add(letterButton);

                _letterBankButtons.Add(letterButton);

            }

        }



        private void LetterBankButton_Click(object sender, EventArgs e)

        {

            Button clickedBankButton = sender as Button;

            if (clickedBankButton == null || !clickedBankButton.Enabled) return;



            char letter = (char)clickedBankButton.Tag;

            Label emptySlot = _answerSlots.FirstOrDefault(slot => string.IsNullOrEmpty(slot.Text) || slot.Text == "_");



            if (emptySlot != null)

            {

                emptySlot.Text = letter.ToString();

                emptySlot.Tag = clickedBankButton;

                clickedBankButton.Enabled = false;

                if (_answerSlots.All(slot => !string.IsNullOrEmpty(slot.Text) && slot.Text != "_"))

                { CheckAnswer(); }

            }

        }



        private void lblGameMessage_Click(object sender, EventArgs e)

        {


        }



        private async void CheckAnswer()

        {

            if (_currentLevel == null) return;

            string guessedWord = string.Concat(_answerSlots.Select(slot => slot.Text));



            if (guessedWord.Equals(_currentLevel.CorrectWord, StringComparison.OrdinalIgnoreCase))

            {

                lblGameMessage.ForeColor = Color.Green;

                lblGameMessage.Text = "Correct!";

                DisableGameControls();

                await UpdateUserProgressAsync(Math.Max(_pointsEarnedThisLevelAttempt, 1));


                _playerLevelCounter++;

                await FetchInitialTotalScoreAsync(); 



                System.Windows.Forms.Timer nextLevelTimer = new System.Windows.Forms.Timer { Interval = 2000 };

                nextLevelTimer.Tick += async (s, ev) => {

                    nextLevelTimer.Stop(); nextLevelTimer.Dispose();

                    await LoadAndDisplayNextLevelAsync();

                };

                nextLevelTimer.Start();

            }

            else

            {

                _wrongGuessesThisLevel++;

                lblGameMessage.ForeColor = Color.Red;



                int pointsToDeduct = 2;

                _pointsEarnedThisLevelAttempt -= pointsToDeduct;

                if (_pointsEarnedThisLevelAttempt < 0) _pointsEarnedThisLevelAttempt = 0;




                await SaveInProgressLevelStateAsync();



                if (_wrongGuessesThisLevel >= 3)

                {

                    lblGameMessage.Text = $"Game Over! Too many wrong guesses. Progress reset.";

                    MessageBox.Show($"Game Over!\n3 wrong guesses on this level.\nOverall progress will be reset.", "Game Over", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                    DisableGameControls();

                    if (CurrentUser.LoggedInUser != null)

                    {

                        bool resetSuccess = await DeleteUserProgressAsync(CurrentUser.LoggedInUser.UserId);

                        if (resetSuccess)

                        {

                            _currentTotalScore = 0;

                            _pointsEarnedThisLevelAttempt = 0; 

                            UpdateTotalScoreDisplay(); 

                        }

                    }

                    this.Close();

                }

                else

                {

                    lblGameMessage.Text = $"Try Again! (Attempts: {3 - _wrongGuessesThisLevel}). Score for this level: {_pointsEarnedThisLevelAttempt}";

                    System.Windows.Forms.Timer clearAttemptTimer = new System.Windows.Forms.Timer { Interval = 1500 };

                    clearAttemptTimer.Tick += (s, ev) => {

                        clearAttemptTimer.Stop(); clearAttemptTimer.Dispose();

                        foreach (Label slotLabel in _answerSlots)

                        {

                            if (!(slotLabel.Tag is string tagStr && tagStr == "HINT_REVEALED"))

                            {

                                if (slotLabel.Tag is Button assocBankBtn) { assocBankBtn.Enabled = true; }

                                slotLabel.Text = ""; slotLabel.Tag = null;

                            }

                        }

                        lblGameMessage.Text = $"Try Again! (Attempts left: {3 - _wrongGuessesThisLevel}). Score for this level: {_pointsEarnedThisLevelAttempt}";

                    };

                    clearAttemptTimer.Start();

                }

            }

        }



        private void EnableGameControls()

        {

            foreach (Button btn in _letterBankButtons) { btn.Enabled = true; btn.Visible = true; }

            btnShowHint.Enabled = (_hintsUsedThisLevel < MAX_HINTS_PER_LEVEL);

        }



        private void DisableGameControls()

        {

            foreach (Button btn in _letterBankButtons) { btn.Enabled = false; }

            btnShowHint.Enabled = false;

        }



        private async void btnShowHint_Click(object sender, EventArgs e)

        {

            if (_currentLevel == null || string.IsNullOrEmpty(_currentLevel.CorrectWord))

            {

                MessageBox.Show("No level loaded or word defined, cannot provide hint.", "Hint Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;

            }



            if (_hintsUsedThisLevel >= MAX_HINTS_PER_LEVEL)

            {

                MessageBox.Show("No more hints available for this level.", "Hint Limit Reached", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;

            }



            bool hintActionTaken = false;



            if (_hintsUsedThisLevel == 0)

            {

                lblGameMessage.Text = "";

                Label? slotToFill = null;

                char letterToReveal = '\0';

                Button? bankButtonUsedForReveal = null;



                for (int i = 0; i < _currentLevel.CorrectWord.Length; i++)

                {

                    if (i < _answerSlots.Count && (string.IsNullOrEmpty(_answerSlots[i].Text) || _answerSlots[i].Text == "_"))

                    {

                        char correctLetterForSlot = _currentLevel.CorrectWord[i];

                        Button? matchingBankButton = _letterBankButtons.FirstOrDefault(btn =>

                          btn.Enabled && btn.Tag != null && (char)btn.Tag == correctLetterForSlot);



                        if (matchingBankButton != null)

                        {

                            slotToFill = _answerSlots[i];

                            letterToReveal = correctLetterForSlot;

                            bankButtonUsedForReveal = matchingBankButton;

                            hintActionTaken = true;

                            break;

                        }

                    }

                }



                if (hintActionTaken)

                {

                    slotToFill.Text = letterToReveal.ToString();


                    slotToFill.Tag = "HINT_REVEALED";

                    bankButtonUsedForReveal.Enabled = false;

                    lblGameMessage.Text = "Hint: Letter Revealed!";

                    lblGameMessage.ForeColor = Color.Blue;

                }

                else

                {

                    lblGameMessage.Text = "Hint: Could not reveal a letter (all correct letters may be placed or no empty slots).";

                    lblGameMessage.ForeColor = Color.Orange;

                }

            }

            else if (_hintsUsedThisLevel == 1)

            {

                lblGameMessage.Text = "";

                int lettersToRemoveCount = 3;

                int lettersActuallyRemoved = 0;



                List<Button> availableBankButtonsForRemoval = _letterBankButtons.Where(btn => btn.Enabled).ToList();

                Random random = new Random();

                availableBankButtonsForRemoval = availableBankButtonsForRemoval.OrderBy(x => random.Next()).ToList();



                foreach (Button bankButtonToRemove in availableBankButtonsForRemoval)

                {

                    if (lettersActuallyRemoved >= lettersToRemoveCount)

                        break;



                    char letterInBank = (char)bankButtonToRemove.Tag;

                    bool isPartOfRemainingAnswer = false;



                    for (int i = 0; i < _currentLevel.CorrectWord.Length; i++)

                    {

                        if (i < _answerSlots.Count && (string.IsNullOrEmpty(_answerSlots[i].Text) || _answerSlots[i].Text == "_"))

                        {

                            if (_currentLevel.CorrectWord[i] == letterInBank)

                            {

                                int neededCount = 0;

                                for (int j = 0; j < _currentLevel.CorrectWord.Length; ++j)

                                {

                                    if ((string.IsNullOrEmpty(_answerSlots[j].Text) || _answerSlots[j].Text == "_") && _currentLevel.CorrectWord[j] == letterInBank)

                                    {

                                        neededCount++;

                                    }

                                }

                                int availableInBankCount = _letterBankButtons.Count(btn => btn.Enabled && (char)btn.Tag == letterInBank);



                                if (availableInBankCount > neededCount)

                                {

                                    isPartOfRemainingAnswer = true;

                                }

                                else if (availableInBankCount <= neededCount && neededCount > 0)

                                {

                                    isPartOfRemainingAnswer = true;

                                }

                                break;

                            }

                        }

                    }



                    if (!isPartOfRemainingAnswer)

                    {

                        bankButtonToRemove.Enabled = false;

                        lettersActuallyRemoved++;

                        hintActionTaken = true;

                    }

                }



                if (hintActionTaken && lettersActuallyRemoved > 0)

                {

                    lblGameMessage.Text = $"Hint: {lettersActuallyRemoved} incorrect letter(s) removed!";

                    lblGameMessage.ForeColor = Color.Blue;

                }

                else

                {

                    lblGameMessage.Text = "Hint: No incorrect letters could be removed.";

                    lblGameMessage.ForeColor = Color.Orange;

                    hintActionTaken = false;

                }

            }



            if (hintActionTaken)

            {

                _hintsUsedThisLevel++;

                if (_pointsEarnedThisLevelAttempt >= 3)

                    _pointsEarnedThisLevelAttempt -= 2;

                else

                    _pointsEarnedThisLevelAttempt = 1;



                await SaveInProgressLevelStateAsync();



                if (_hintsUsedThisLevel >= MAX_HINTS_PER_LEVEL)

                {

                    btnShowHint.Enabled = false;

                    if (!string.IsNullOrEmpty(lblGameMessage.Text) && lblGameMessage.ForeColor == Color.Blue)

                    {

                        lblGameMessage.Text += " (All hints used)";

                    }

                    else

                    {

                        lblGameMessage.Text = "All hints used for this level.";

                        lblGameMessage.ForeColor = Color.Blue;

                    }

                }



                if (_answerSlots.All(slot => !string.IsNullOrEmpty(slot.Text) && slot.Text != "_"))

                {

                    CheckAnswer();

                }

            }

        }



        private async Task UpdateUserProgressAsync(int scoreAchievedForThisLevel)

        {

            if (_currentLevel == null || CurrentUser.LoggedInUser == null) { return; }

            int userId = CurrentUser.LoggedInUser.UserId;

            int gameLevelId = _currentLevel.GameLevelId;



            try

            {

                using (var connection = new MySqlConnection(DbHelper.ConnectionString))

                {

                    await connection.OpenAsync();

                    string query = "INSERT INTO userprogresses (UserId, GameLevelId, IsCompleted, CompletedDate, Score, HintsUsedInAttempt) VALUES (@UserId, @GameLevelId, 1, NOW(), @Score, 0) ON DUPLICATE KEY UPDATE IsCompleted = 1, CompletedDate = NOW(), Score = @Score, HintsUsedInAttempt = 0;";


                    using (var command = new MySqlCommand(query, connection))

                    {

                        command.Parameters.AddWithValue("@UserId", userId);

                        command.Parameters.AddWithValue("@GameLevelId", gameLevelId);

                        command.Parameters.AddWithValue("@Score", scoreAchievedForThisLevel);

                        int rowsAffected = await command.ExecuteNonQueryAsync();

                        if (rowsAffected > 0)

                        {

                            Console.WriteLine($"Progress saved. UserID: {userId}, LevelID: {gameLevelId}, Score: {scoreAchievedForThisLevel}");

                        }

                    }

                }

            }

            catch (Exception ex) { MessageBox.Show($"DB error saving progress: {ex.Message}"); }

        }



        private async Task<bool> DeleteUserProgressAsync(int userId)

        {

            // ... (Your existing DeleteUserProgressAsync method - looks good) ...

            try

            {

                using (var connection = new MySqlConnection(DbHelper.ConnectionString))

                {

                    await connection.OpenAsync();

                    string query = "DELETE FROM userprogresses WHERE UserId = @UserId;";

                    using (var command = new MySqlCommand(query, connection))

                    {

                        command.Parameters.AddWithValue("@UserId", userId);

                        await command.ExecuteNonQueryAsync();

                        Console.WriteLine($"All progress deleted for UserId: {userId}");

                        return true;

                    }

                }

            }

            catch (MySqlException ex)

            {

                MessageBox.Show($"Database error resetting progress: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;

            }

            catch (Exception ex)

            {

                MessageBox.Show($"An unexpected error occurred resetting progress: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;

            }

        }



        private void button1_Click(object sender, EventArgs e)

        {

            this.Close();

        }



        private async Task SaveInProgressLevelStateAsync()

        {

            if (_currentLevel == null || CurrentUser.LoggedInUser == null)

            {

                Console.WriteLine("SaveInProgressLevelStateAsync: Cannot save state - no current level or logged-in user.");

                return;

            }



            try

            {

                using (var connection = new MySqlConnection(DbHelper.ConnectionString))

                {

                    await connection.OpenAsync();

                    string upsertQuery = "INSERT INTO userprogresses (UserId, GameLevelId, HintsUsedInAttempt, WrongGuessesInAttempt, IsCompleted, Score, CompletedDate) VALUES (@UserId, @GameLevelId, @CurrentHintsUsed, @CurrentWrongGuesses, 0, @CurrentAttemptScore, NULL) ON DUPLICATE KEY UPDATE HintsUsedInAttempt = VALUES(HintsUsedInAttempt), WrongGuessesInAttempt = VALUES(WrongGuessesInAttempt), Score = VALUES(Score), IsCompleted = 0;";


                    using (var command = new MySqlCommand(upsertQuery, connection))

                    {

                        command.Parameters.AddWithValue("@UserId", CurrentUser.LoggedInUser.UserId);

                        command.Parameters.AddWithValue("@GameLevelId", _currentLevel.GameLevelId);

                        command.Parameters.AddWithValue("@CurrentHintsUsed", _hintsUsedThisLevel);

                        command.Parameters.AddWithValue("@CurrentWrongGuesses", _wrongGuessesThisLevel); 

                        command.Parameters.AddWithValue("@CurrentAttemptScore", _pointsEarnedThisLevelAttempt);



                        await command.ExecuteNonQueryAsync();

                        Console.WriteLine($"In-progress state saved for UserID: {CurrentUser.LoggedInUser.UserId}, LevelID: {_currentLevel.GameLevelId}, Hints: {_hintsUsedThisLevel}, WrongGuesses: {_wrongGuessesThisLevel}, Score: {_pointsEarnedThisLevelAttempt}");

                    }

                }

            }

            catch (MySqlException ex)

            {

                MessageBox.Show($"Error saving in-progress game state: {ex.Message}\n\nQuery: {ex.ToString()}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }

            catch (Exception ex)

            {

                MessageBox.Show($"Unexpected error saving in-progress game state: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }

        }

    }

}