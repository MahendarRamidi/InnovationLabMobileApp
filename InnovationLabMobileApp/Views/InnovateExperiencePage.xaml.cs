using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace InnovationLabMobileApp.Views
{
    public partial class InnovateExperiencePage : ContentPage
    {
        public InnovateExperiencePage()
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
            lbl.Text = "These Gold Labeled Private tours are offered once a month to provide an experience for you and your team to learn more about the new and exciting events in the FDA Innovation Lab through an invitation only event.\n\nOnce in the lab we will tour a variety of innovative technologies and tools currently being displayed. There is always something fun and exciting happening in the lab, whether it is a new data analytics tool, the VGo Robot, or building something on the 3D printer. We will also discuss any upcoming live events being hosted by the lab such as a Workshop, TechTalkx, or Ask the Expert event.\n\nThese tours provide groups with information about how the Technology innovation Team can assist with their business needs by bringing innovation into their Business Centers.";
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
