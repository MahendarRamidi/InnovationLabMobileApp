using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace InnovationLabMobileApp.Views
{
    public partial class OurWorkPage : ContentPage
    {
        public OurWorkPage()
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

        void Prototypes_Tapped(object sender, System.EventArgs e)
        {
            Navigation.PushModalAsync(new MainPrototypePage());
        }

        void WhitePapers_Tapped(object sender, System.EventArgs e)
        {
            Navigation.PushModalAsync(new MainWhitePaperPage());
        }

        void Ideation_Tapped(object sender, System.EventArgs e)
        {
            Navigation.PushModalAsync(new MainIdeationPage());
        }

        void TechSurv_Tapped(object sender, System.EventArgs e)
        {
            Navigation.PushModalAsync(new MainTechSurvPage());
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
