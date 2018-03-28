using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace InnovationLabMobileApp.Views
{
    public partial class ScheduleATourPage : ContentPage
    {
        CloudDataStore cloudStore = new CloudDataStore();
        string date = null;
        public ScheduleATourPage()
        {
            InitializeComponent();
            //Tap Gesture for Menu
            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += (s, e) =>
            {
                try
                {
                    MasterDetailPage ParentPage = (MasterDetailPage)this.Parent;
                    ParentPage.IsPresented = (ParentPage.IsPresented == false) ? true : false;
                }
                catch (Exception ex)
                {
                    var msg = ex.Message;
                }
            };
            img.GestureRecognizers.Add(tapGestureRecognizer);
            string[] CenterData = { "CBER", "CDER", "CDRH", "CFSAN", "CTP", "CVM", "NCTR", "OC", "ORA", "OIMT" };
            CenterPicker.ItemsSource = CenterData;

            DateEntry.Focused += async (object sender, FocusEventArgs e) =>
            {
                await Navigation.PushModalAsync(new CalendarPage());
            };

            MessagingCenter.Subscribe<CalendarPage, string>(this, "H", (s, a) =>
            {
                date = a;
                DateEntry.Text = a;
            });

        }

        async void Schedule_Clicked(object sender, System.EventArgs e)
        {
            try
            {
                if (date == null &&
                    YourNameEntry.Text == null &&
                    CenterPicker.SelectedItem == null &&
                     EmailEntry.Text == null &&
                     PhoneNumberEntry.Text == null &&
                    NumberodPeopleEntry.Text == null)
                {
                    await DisplayAlert("Error", "Please Fill Missing Fields.", "OK");
                }
                else if (date == null)
                {
                    await DisplayAlert("Error", "Please Select the Date.", "OK");
                }
                else if (YourNameEntry.Text == null)
                {
                    await DisplayAlert("Error", "Please Fill your Name.", "OK");
                }
                else if (CenterPicker.SelectedItem == null)
                {
                    await DisplayAlert("Error", "Please Select Center.", "OK");
                }
                else if (EmailEntry.Text == null)
                {
                    await DisplayAlert("Error", "Please Fill Email.", "OK");
                }
                else if (PhoneNumberEntry.Text == null)
                {
                    await DisplayAlert("Error", "Please Fill Phone Number.", "OK");
                }
                else if (!Regex.Match(PhoneNumberEntry.Text, @"^\d{10}$").Success)
                {
                    await DisplayAlert("Error", "Invalid Phone Number.", "OK");
                }
                else if (!Regex.Match(EmailEntry.Text, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$").Success)
                {
                    await DisplayAlert("Error", "Invalid Email.", "OK");
                }
                else if (NumberodPeopleEntry.Text == null)
                {
                    await DisplayAlert("Error", "Please Fill Number of People.", "OK");
                }
                else
                {
                    Dictionary<string, string> dict = new Dictionary<string, string>();
                    dict["Date"] = date;
                    dict["TourName"] = YourNameEntry.Text;
                    dict["Center"] = CenterPicker.SelectedItem.ToString();
                    dict["Email"] = EmailEntry.Text;
                    dict["Phone"] = PhoneNumberEntry.Text;
                    dict["NumberPeople"] = NumberodPeopleEntry.Text;

                    var isSuccess = await cloudStore.AddScheduleTour(dict);
                    if (isSuccess)
                    {
                        await DisplayAlert("Alert", "Successfully Scheduled.", "Ok");
                        await Navigation.PushModalAsync(new ScheduleATourPage());
                    }
                    else
                    {
                        await DisplayAlert("Error", "", "Ok");
                    }
                }

            }
            catch (Exception ex)
            {

            }

        }

        void Back_Tapped(object sender, System.EventArgs e)
        {
            Navigation.PopModalAsync();
        }
        void Home_Tapped(object sender, System.EventArgs e)
        {
            App.Current.MainPage = new MainPage();
        }
        void Scan_Tapped(object sender, System.EventArgs e)
        {
            Navigation.PushModalAsync(new MainScanPage());
        }
    }
}
