using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace InnovationLabMobileApp.Views
{
    public partial class LabRegistrationPage : ContentPage
    {
        CloudDataStore cloudStore = new CloudDataStore();
        string selecteddate = null;
        string selectedtime = null;
        public LabRegistrationPage()
        {
            InitializeComponent();

            timepicker.Time = DateTime.Now.TimeOfDay;

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

            string[] pickercollection = { "TechTalkX", "Ask the Expert", "Workshops", "Gold Label Tour", "Brainstorming Session", "LIVE Demo", "Vendor Meeting", "Other", "All of the above" };
            picker.ItemsSource = pickercollection;
            datepicker.DateSelected += (sender, e) =>
            {
                selecteddate = e.NewDate.ToString("MM-dd-yyyy");
            };

            timepicker.PropertyChanged += (sender, e) =>
            {
                selectedtime = timepicker.Time.ToString(@"hh\:mm");
            };
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

        async void Handle_Clicked(object sender, System.EventArgs e)
        {
            try
            {
                if (VisitorNameentry.Text == null && picker.SelectedItem == null)
                {
                    await DisplayAlert("Error", "Please fill all the fields.", "Ok");
                }
                else if (VisitorNameentry.Text == null)
                {
                    await DisplayAlert("Error", "Please fill Visitor Name.", "Ok");
                }
                else if (picker.SelectedItem == null)
                {
                    await DisplayAlert("Error", "Please select Topic of Interest.", "Ok");
                }
                else
                {
                    if (selecteddate == null)
                    {
                        selecteddate = DateTime.Now.ToString("MM-dd-yyyy");
                    }
                    if (selectedtime == null)
                    {
                        selectedtime = timepicker.Time.ToString(@"hh\:mm");
                    }
                    var isSuccess = await cloudStore.AddRegisteredUser(
                        VisitorNameentry.Text, selecteddate, selectedtime, picker.SelectedItem.ToString());
                    if (isSuccess)
                    {
                        await Navigation.PushModalAsync(new MainLabRegistrationCompletePage(VisitorNameentry.Text, "LabRegistrationPage"));
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
    }
}
