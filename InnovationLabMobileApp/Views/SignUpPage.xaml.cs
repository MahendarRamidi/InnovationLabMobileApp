using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace InnovationLabMobileApp.Views
{
    public partial class SignUpPage : ContentPage
    {
        CloudDataStore cloudStore = new CloudDataStore();
        public SignUpPage()
        {
            InitializeComponent();
        }

        async void Back_Tapped(object sender, System.EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        async void Signup_Clicked(object sender, System.EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(VisitorfirstNameentry.Text) &&
                string.IsNullOrWhiteSpace(VisitorlastNameentry.Text) &&
                string.IsNullOrWhiteSpace(Visitoremailentry.Text) &&
                string.IsNullOrWhiteSpace(Visitorpasswordentry.Text))
            {
                await DisplayAlert("Error", "Please Fill Missing Fields", "OK");
            }
            else if (string.IsNullOrWhiteSpace(VisitorfirstNameentry.Text))
            {
                await DisplayAlert("Error", "Please Fill First Name", "OK");
            }
            else if (string.IsNullOrWhiteSpace(VisitorlastNameentry.Text))
            {
                await DisplayAlert("Error", "Please Fill Last Name", "OK");
            }
            else if (string.IsNullOrWhiteSpace(Visitoremailentry.Text))
            {
                await DisplayAlert("Error", "Please Fill Email", "OK");
            }

            else if (string.IsNullOrWhiteSpace(Visitorpasswordentry.Text))
            {
                await DisplayAlert("Error", "Please Fill Password", "OK");
            }
            //else if (!Regex.IsMatch(Visitoremailentry.Text, @"^([1-9])([0-9]*)$"))
            //{

            //}
            //else if (!Regex.IsMatch(Visitoremailentry.Text, @"^\w +@[a-zA-Z_]+?\.[a-zA-Z]{2,3}$"))
            //{
            //    await DisplayAlert("Error", "Invalid Email", "OK");
            //}
            else
            {

                Dictionary<string, string> dict = new Dictionary<string, string>();
                dict["FirstName"] = VisitorfirstNameentry.Text;
                dict["LastName"] = VisitorlastNameentry.Text;
                dict["Email"] = Visitoremailentry.Text;
                dict["Password"] = Visitorpasswordentry.Text;

                try
                {
                    var isSuccess = await cloudStore.AddSignupRecord(dict);

                    if (isSuccess)
                    {
                        await Navigation.PopModalAsync();
                    }
                    else
                    {
                        await DisplayAlert("Error", "Wrong Email or Password.", "Ok", "Cancle");
                    }
                }
                catch (Exception ex)
                {

                }
            }
        }
    }
}
