using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FourPicsOneWordGame
{
    public partial class InstructionsForm : Form
    {
        public InstructionsForm()
        {
            InitializeComponent();
            LoadInstructions();
        }

        private void LoadInstructions()
        {

            if (this.Controls.ContainsKey("richTextBoxInstructions"))
            {
                RichTextBox rtb = this.Controls["richTextBoxInstructions"] as RichTextBox;
                if (rtb != null)
                {
                    rtb.Clear();
                    rtb.SelectionFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
                    rtb.AppendText("How to Play: WordPic\n\n");

                    rtb.SelectionFont = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
                    rtb.AppendText("Objective:\n");
                    rtb.SelectionFont = new System.Drawing.Font("Segoe UI", 10F);
                    rtb.AppendText("Look at the four pictures and guess the word that is common to all of them.\n\n");

                    rtb.SelectionFont = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
                    rtb.AppendText("Gameplay:\n");
                    rtb.SelectionFont = new System.Drawing.Font("Segoe UI", 10F);
                    rtb.AppendText("1. Examine the four images provided for each level.\n");
                    rtb.AppendText("2. Identify the common theme or word they represent.\n");
                    rtb.AppendText("3. Use the letter bank at the bottom to spell out your answer in the empty slots.\n");
                    rtb.AppendText("4. Click a letter from the bank to place it in the next available answer slot.\n");
                    rtb.AppendText("5. Click a letter in an answer slot to return it to the letter bank.\n\n");

                    rtb.SelectionFont = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
                    rtb.AppendText("Scoring:\n");
                    rtb.SelectionFont = new System.Drawing.Font("Segoe UI", 10F);
                    rtb.AppendText($"- You start each level attempt with a base of 10 points.\n");
                    rtb.AppendText($"- Each wrong guess deducts 2 points.\n");
                    rtb.AppendText($"- Each hint used deducts 2 points.\n");
                    rtb.AppendText($"- Successfully completing a level adds your remaining points for that attempt to your total score.\n\n");


                    rtb.SelectionFont = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
                    rtb.AppendText("Wrong Guesses:\n");
                    rtb.SelectionFont = new System.Drawing.Font("Segoe UI", 10F);
                    rtb.AppendText($"- You are allowed a maximum of {MAX_WRONG_GUESSES_PER_LEVEL} wrong guesses per level attempt.\n"); 
                    rtb.AppendText("- If you exceed this limit, it's game over, and your overall progress will be reset.\n\n");


                    rtb.SelectionFont = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
                    rtb.AppendText("Hints:\n");
                    rtb.SelectionFont = new System.Drawing.Font("Segoe UI", 10F);
                    rtb.AppendText($"- You can use up to {MAX_HINTS_PER_LEVEL} hints per level.\n");
                    rtb.AppendText("  - Hint 1: Reveals one correct letter in its place.\n");
                    rtb.AppendText("  - Hint 2: Removes 3 incorrect letters from the letter bank.\n\n");

                    rtb.SelectionFont = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
                    rtb.AppendText("Good luck and have fun!\n");

                    rtb.Select(0, 0);
                }
            }
            else
            {
                this.Text = "How to Play";
                Label lblInfo = new Label();
                lblInfo.Text = "Detailed game instructions go here...";
                lblInfo.AutoSize = false;
                lblInfo.Dock = DockStyle.Fill;
                lblInfo.Padding = new Padding(10);
                this.Controls.Add(lblInfo);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private const int MAX_WRONG_GUESSES_PER_LEVEL = 2;
        private const int MAX_HINTS_PER_LEVEL = 2;
    }
}
