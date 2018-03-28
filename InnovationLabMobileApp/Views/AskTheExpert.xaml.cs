using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace InnovationLabMobileApp.Views
{
    public partial class AskTheExpert : ContentPage
    {
        public AskTheExpert()
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
            lbl.Text = "Techtalkx are 30-60 minute presentations by technology experts from private  industry and various government agencies within the technology community at an FDA Innovation Lab sponsored event. This forum is used to provide FDA with the opportunity to learn from the technology community. Techtalkx delivers the very core of an idea using a slide deck, a whiteboard, or live demonstration. Techtalkx are presented to a live audience within the FDA Innovation lab or on Location at another FDA site. \nThe FDA Innovation Lab TechTalkx sets the stage for innovative thinking and groundbreaking ideas.It is designed to spark conversations and connections trough powerful and thought - provoking videos and presentations.This is an FDA Innovation Lab event where possibilities come together with innovative ideas from science to business to global and FDA challenges.";
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
