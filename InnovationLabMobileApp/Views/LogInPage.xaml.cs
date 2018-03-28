using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using InnovationLabMobileApp.Views;
using Xamarin.Forms;

namespace InnovationLabMobileApp
{
    public partial class LogInPage : ContentPage
    {
        CloudDataStore cloudStore = new CloudDataStore();
        public LogInPage()
        {
            InitializeComponent();
        }

        async void Login_Clicked(object sender, System.EventArgs e)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            dict["Email"] = emailTextField.Text;
            dict["Password"] = passwordTextField.Text;

            try
            {
                var isSuccess = await cloudStore.CheckLogin(dict);

                if (isSuccess)
                {
                    await Navigation.PushModalAsync(new MainPage());
                }
                else
                {
                    await  DisplayAlert("Error", "Wrong Email or Password.", "Ok", "Cancle");
                }

            }
            catch (Exception ex)
            {

            }
        }

        async void Signup_Tapped(object sender, System.EventArgs e)
        {
            await Navigation.PushModalAsync(new SignUpPage());
        }
    }
}
