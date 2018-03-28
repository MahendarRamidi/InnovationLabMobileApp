using System;
using Xamarin.Forms;
using XamForms.Controls;

namespace InnovationLabMobileApp.Views
{
    public class CalendarPage : ContentPage
    {
        #region Global Variables
        Calendar Calendar;
        #endregion
        public CalendarPage()
        {
            #region for Header Stack
            Label lblTitle = new Label()
            {
                Text = "Calendar",
                TextColor = Color.White,
                FontAttributes = FontAttributes.Bold,
                FontSize = 20,
                HorizontalOptions = LayoutOptions.StartAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                Margin = new Thickness(10, 0, 0, 0)
            };
            Label lblskip = new Label()
            {
                Text = "Skip",
                FontSize = 20,
                FontAttributes = FontAttributes.Bold,
                TextColor = Color.White,
                HorizontalOptions = LayoutOptions.EndAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                Margin = new Thickness(0, 0, 10, 0)
            };
            StackLayout stackSkip = new StackLayout()
            {
                Children = { lblskip },
                BackgroundColor = Color.FromHex("#301631"),
                HorizontalOptions = LayoutOptions.End,
                VerticalOptions = LayoutOptions.FillAndExpand
            };
            TapGestureRecognizer tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += lblskipTapped;
            stackSkip.GestureRecognizers.Add(tapGestureRecognizer);
            StackLayout stackHeader = new StackLayout()
            {
                Children = { lblTitle, stackSkip },
                Orientation = StackOrientation.Horizontal,
                BackgroundColor = Color.FromHex("#301631"),
                HeightRequest = 70,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.Start
            };
            #endregion

            #region Calendar
            Calendar = new Calendar()
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
            };
            Calendar.SelectedDate = DateTime.Now;
            Calendar.MinDate = DateTime.Now;
            Calendar.DateClicked += async (object sender, DateTimeEventArgs e) =>
            {
                MessagingCenter.Send(this, "H", e.DateTime.ToString("MM-dd-yyyy"));
                await Navigation.PopModalAsync();
            };
            #endregion
            #region Main Stack
            StackLayout stackMain = new StackLayout()
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Children = { stackHeader, Calendar },
                Spacing = 0
            };
            #endregion

            Content = stackMain;
        }
        #region lblskipTapped event
        void lblskipTapped(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }
        #endregion      
    }
}
