using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace InnovationLabMobileApp.Views
{
    public partial class LandingPage
    {
        public LandingPage()
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

        void AboutFda_Tapped(object sender, System.EventArgs e)
        {
            Navigation.PushModalAsync(new MainAboutFDAPage());

        }

        void LabReg_Tapped(object sender, System.EventArgs e)
        {
            Navigation.PushModalAsync(new MainLabRegPage());
        }

        void EventReg_Tapped(object sender, System.EventArgs e)
        {
            Navigation.PushModalAsync(new MainEventRegPage());
        }

        void Previousdays_Tapped(object sender, System.EventArgs e)
        {
            Navigation.PushModalAsync(new MainPreviousVisitorsPage());
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
