using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace InnovationLabMobileApp.Views
{
    public partial class EventRegistrationPage : ContentPage
    {
        ObservableCollection<string> BusinessCenterCollection = new ObservableCollection<string>();
        CloudDataStore cloudStore = new CloudDataStore();
        public EventRegistrationPage()
        {
            InitializeComponent();

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

            string[] businessCenterData = { "CBER", "CDER", "CDRH", "CFSAN", "CTP", "CVM", "NCTR", "OC", "ORA", "OIMT" };

            BusinessCenterpicker.ItemsSource = businessCenterData;

            string[] eventType = { "TechTalkx", "Ask the Expert", "Workshops", "Collaboration Session" };
            string[] eventName = { "SAP HANA TechTalkx", "Mobile Application Development TechTalkx",
                "The ACID TechTalkX", "AI& Machine Learning"};
            string[] eventDate = { "05-10-2017", "05-11-2017", "12-08-2017", "10-25-2017" };

            EventTypepicker.ItemsSource = eventType;

            EventTypepicker.SelectedIndexChanged += (object sender, EventArgs e) =>
           {
               if (EventTypepicker.SelectedItem == "TechTalkx")
               {
                   string[] EventName = { "SAP HANA TechTalkx", "Mobile Application Development TechTalkx" };
                   if (EventNamepicker.ItemsSource != null)
                   {
                       EventNamepicker.ItemsSource = null;
                   }

                   EventNamepicker.ItemsSource = EventName;
                   string[] EventDate = { "05-10-2017", "05-11-2017" };
                   if (EventDatepicker.ItemsSource != null)
                   {
                       EventDatepicker.ItemsSource = null;
                   }

                   EventDatepicker.ItemsSource = EventDate;

               }
               else if (EventTypepicker.SelectedItem == "Ask the Expert")
               {
                   string[] EventName = { "The ACID TechTalkX", "AI& Machine Learning" };
                   if (EventNamepicker.ItemsSource != null)
                   {
                       EventNamepicker.ItemsSource = null;
                   }

                   EventNamepicker.ItemsSource = EventName;
                   string[] EventDate = { "05-10-2017", "05-11-2017" };
                   if (EventDatepicker.ItemsSource != null)
                   {
                       EventDatepicker.ItemsSource = null;
                   }
                   EventDatepicker.ItemsSource = EventDate;

               }

           };

        }

        async void Handle_Clicked(object sender, System.EventArgs e)
        {
            try
            {
                if (FirstNameEntry.Text == null &&
                    LastNameEntry.Text == null &&
                    BusinessCenterpicker.SelectedItem == null &&
                    EmailEntry.Text == null &&
                    PhoneNumberEntry.Text == null &&
                    EventTypepicker.SelectedItem == null &&
                     EventNamepicker.SelectedItem == null &&
                 EventDatepicker.SelectedItem == null)
                {
                    await DisplayAlert("Error", "Please Fill Missing Fields", "OK");
                }
                else if (FirstNameEntry.Text == null)
                {
                    await DisplayAlert("Error", "Please Fill First Name.", "OK");
                }
                else if (LastNameEntry.Text == null)
                {
                    await DisplayAlert("Error", "Please Fill Last Name.", "OK");
                }
                else if (BusinessCenterpicker.SelectedItem == null)
                {
                    await DisplayAlert("Error", "Please select Business Center.", "OK");
                }
                else if (EmailEntry.Text == null)
                {
                    await DisplayAlert("Error", "Please Fill Email.", "OK");
                }
                else if (!Regex.Match(EmailEntry.Text, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$").Success)
                {
                    await DisplayAlert("Error", "Invalid Email.", "OK");
                }
                else if (PhoneNumberEntry.Text == null)
                {
                    await DisplayAlert("Error", "Please Fill Phone Number.", "OK");
                }
                else if (!Regex.Match(PhoneNumberEntry.Text, @"^\d{10}$").Success)
                {
                    await DisplayAlert("Error", "Invalid Phone Number.", "OK");
                }
                else if (EventTypepicker.SelectedItem == null)
                {
                    await DisplayAlert("Error", "Please Select Event Type.", "OK");
                }
                else if (EventNamepicker.SelectedItem == null)
                {
                    await DisplayAlert("Error", "Please Select Event Name.", "OK");
                }
                else if (EventDatepicker.SelectedItem == null)
                {
                    await DisplayAlert("Error", "Please Select Event Date.", "OK");
                }

                else
                {
                    Dictionary<string, string> dict = new Dictionary<string, string>();
                    dict["FirstName"] = FirstNameEntry.Text;
                    dict["LastName"] = LastNameEntry.Text;
                    dict["BusinessCenter"] = BusinessCenterpicker.SelectedItem.ToString();
                    dict["Email"] = EmailEntry.Text;
                    dict["Phone"] = PhoneNumberEntry.Text;
                    dict["EventType"] = EventTypepicker.SelectedItem.ToString();
                    dict["EventName"] = EventNamepicker.SelectedItem.ToString();
                    dict["EventDate"] = EventDatepicker.SelectedItem.ToString();


                    var isSuccess = await cloudStore.AddRegisteredEvent(dict);
                    if (isSuccess)
                    {
                        await Navigation.PushModalAsync(new MainLabRegistrationCompletePage(FirstNameEntry.Text, "EventRegistrationPage"));
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
