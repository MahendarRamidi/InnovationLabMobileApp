using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace InnovationLabMobileApp.Views
{
    public partial class HoursofOperationPage : ContentPage
    {
        public HoursofOperationPage()
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
            lbl.Text = "FDA Innovation Lab \nWhite Oak Campus\nBuilding 2, Room 3130\nEmail: innovation@fda.hhs.gov\nWebsite: http://inside.fda.gov:9003/it/innovation/InnovationLab/default.htm";
            lbl.LineBreakMode = LineBreakMode.WordWrap;
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
