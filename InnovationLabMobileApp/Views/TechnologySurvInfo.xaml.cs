using System;
using System.Collections.Generic;
using InnovationLabMobileApp.Models;
using Xamarin.Forms;

namespace InnovationLabMobileApp.Views
{
    public partial class TechnologySurvInfo : ContentPage
    {
        public TechnologySurvInfo(TechSurv TechSurv)
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

            lblname.Text = TechSurv.name;
            lblinformation.Text = TechSurv.information;
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
  
    
