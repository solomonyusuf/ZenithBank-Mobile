using ZenithBank.Pages;

namespace ZenithBank
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            // Set AppShell as the main page
            MainPage = new AppShell();

            // Navigate explicitly to WelcomePage
            //Shell.Current.GoToAsync("//WelcomePage");
        }
    }
}
