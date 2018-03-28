using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace InnovationLabMobileApp.Views
{
    public partial class InnovateTodayConferencePage : ContentPage
    {
        public InnovateTodayConferencePage()
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
            lbl.Text = "The FDA Innovation Lab will host Vendors for the annual Innovate Today Conference featuring new and emerging technologies. This will be an opportunity to see, touch, and experience cutting-edge technologies and speak with the master minds behinds the designs.";
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
