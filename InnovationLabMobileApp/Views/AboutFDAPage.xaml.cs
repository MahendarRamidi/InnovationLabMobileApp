using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace InnovationLabMobileApp.Views
{
    public partial class AboutFDAPage : ContentPage
    {
        public AboutFDAPage()
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

        }
        void Handle_Tapped1(object sender, System.EventArgs e)
        {
            Navigation.PushModalAsync(new MainOurWorkPage());
        }

        void Handle_Tapped2(object sender, System.EventArgs e)
        {
            Navigation.PushModalAsync(new MainActivityPage());
        }

        void Handle_Tapped3(object sender, System.EventArgs e)
        {
            Navigation.PushModalAsync(new MainHoursPage());
        }

        void Handle_Tapped4(object sender, System.EventArgs e)
        {
            Navigation.PushModalAsync(new MainInnovatePage());
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
