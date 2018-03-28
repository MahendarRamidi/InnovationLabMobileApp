using InnovationLabMobileApp.Views;
using Xamarin.Forms;

namespace InnovationLabMobileApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //  MainPage = new EventRegistrationPage();
            MainPage = new LogInPage();
            // MainPage = new AboutFDAPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
