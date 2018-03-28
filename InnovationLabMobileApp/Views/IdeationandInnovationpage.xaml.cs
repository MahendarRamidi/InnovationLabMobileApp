using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace InnovationLabMobileApp.Views
{
    public partial class IdeationandInnovationpage : ContentPage
    {
        public IdeationandInnovationpage()
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
            lbl.Text = "The Idea Exchange is a platform where FDA users can submit their ideas and collaborate with others. It leverages the knowledge, creativiry and business needs of the FDA community to inspire innovative ideas and builds collaborative teams of colleahues, partners, and the FDA Technology Innovation Team. \nBy connecting great minds through the Idea Exchange portal, the delected ideas are researched, tuned into white papers or transeormed into prototypes Show casing new or enhanced business solution to build a more modern and effective agency response to meet current and future FDA needs.";
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
