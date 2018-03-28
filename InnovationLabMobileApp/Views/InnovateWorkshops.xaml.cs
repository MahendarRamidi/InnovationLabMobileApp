using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace InnovationLabMobileApp.Views
{
    public partial class InnovateWorkshops : ContentPage
    {
        public InnovateWorkshops()
        {
            InitializeComponent();
            //Tap Gestutre for Menu
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
            lbl.Text = "Innovate Workshops occur monthly. The workshoops will focus on anything from the latest technology to commonly used tools with a unique feature. If you are interested in improving your skills with trainers from within the industry, sign up for one of the workshops and spend a day with your favorite innovative tool becoming an expert, or learn a new tool to improve your work";
            lbl.LineBreakMode = LineBreakMode.WordWrap;
        }
        //Back button click
        void Back_Tapped(object sender, System.EventArgs e)
        {
            Navigation.PopModalAsync();
        }
        //Home button click
        void Home_Tapped(object sender, System.EventArgs e)
        {
            App.Current.MainPage = new MainPage();
        }
        //Scan button click
        void Scan_Tapped(object sender, System.EventArgs e)
        {
            Navigation.PushModalAsync(new MainScanPage());
        }
    }
}
