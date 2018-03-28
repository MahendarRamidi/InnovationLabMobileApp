using System;
using System.Collections.Generic;
using InnovationLabMobileApp.Models;
using Xamarin.Forms;

namespace InnovationLabMobileApp.Views
{
    public partial class SurveySubmitPage : ContentPage
    {

        CloudDataStore cloudStore = new CloudDataStore();

        bool Qes1 = false;
        bool Qes2 = false;

        public SurveySubmitPage()
        {
            InitializeComponent();

            // Tap Gesture for Menu
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

            YesSwitch.Toggled += (sender, e) =>
            {
                if (YesSwitch.IsToggled == true)
                {
                    NoSwitch.IsToggled = false;
                    Qes1 = true;
                }
                else
                {
                    NoSwitch.IsToggled = true;
                    Qes1 = false;
                }
            };

            NoSwitch.Toggled += (sender, e) =>
            {
                if (NoSwitch.IsToggled == true)
                {
                    YesSwitch.IsToggled = false;
                    Qes1 = false;
                }
                else
                {
                    YesSwitch.IsToggled = true;
                    Qes1 = true;
                }
            };

            YesSwitch2.Toggled += (sender, e) =>
            {
                if (YesSwitch2.IsToggled == true)
                {
                    NoSwitch2.IsToggled = false;
                    Qes2 = true;
                }
                else
                {
                    NoSwitch2.IsToggled = true;
                    Qes2 = false;
                }
            };

            NoSwitch2.Toggled += (sender, e) =>
            {
                if (NoSwitch2.IsToggled == true)
                {
                    YesSwitch2.IsToggled = false;
                    Qes2 = false;
                }
                else
                {
                    YesSwitch2.IsToggled = true;
                    Qes2 = true;
                }
            };

            var submittapGestureRecognizer = new TapGestureRecognizer();
            submittapGestureRecognizer.Tapped += async (s, e) =>
                {
                    try
                    {
                        List<SurveyResult> request = new List<SurveyResult>();
                        request.Add(new SurveyResult()
                        {
                            question = question1.Text,
                            answer = Qes1.ToString()
                        });

                        request.Add(new SurveyResult()
                        {
                            question = question2.Text,
                            answer = Qes2.ToString()
                        });

                        var isSuccess = await cloudStore.AddSurveyResult(request);
                        if (isSuccess)
                        {
                            await DisplayAlert("Alert", "Survey Submited successfully.", "Ok");
                            await Navigation.PopModalAsync();
                        }
                        else
                        {
                            await DisplayAlert("Error", "", "Ok");
                        }

                    }
                    catch (Exception ex)
                    {

                    }

                };
            FDAStack.GestureRecognizers.Add(submittapGestureRecognizer);
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
