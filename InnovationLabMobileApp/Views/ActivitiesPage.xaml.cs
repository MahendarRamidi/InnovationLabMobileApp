using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace InnovationLabMobileApp.Views
{
    public partial class ActivitiesPage : ContentPage
    {
        public ActivitiesPage()
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
        }


        void Workshops_Tapped(object sender, System.EventArgs e)
        {
            Navigation.PushModalAsync(new MainWorkshopsPage());
        }

        void TechTalkx_Tapped(object sender, System.EventArgs e)
        {
            Navigation.PushModalAsync(new MainTechTalkxPage());
        }

        void AskExpert_Tapped(object sender, System.EventArgs e)
        {
            Navigation.PushModalAsync(new MainAskExpertPage());
        }

        void InnovateToday_Tapped(object sender, System.EventArgs e)
        {
            Navigation.PushModalAsync(new MainInnovateTodayPage());
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
