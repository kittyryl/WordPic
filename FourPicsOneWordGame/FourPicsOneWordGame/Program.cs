namespace FourPicsOneWordGame
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            while (true)
            {
                CurrentUser.LoggedInUser = null;

                LoginForm loginForm = new LoginForm();
                DialogResult loginResult = loginForm.ShowDialog();

                if(loginResult == DialogResult.OK && CurrentUser.LoggedInUser != null)
                {
                    MainMenuForm mainMenu = new MainMenuForm();
                    Application.Run(mainMenu);

                    if(CurrentUser.LoggedInUser == null)
                    {
                        continue;
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    break;
                }
            }
        }
    }
}