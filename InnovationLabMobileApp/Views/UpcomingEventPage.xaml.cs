using System;
using System.Collections.Generic;
using InnovationLabMobileApp.Models;
using Xamarin.Forms;

namespace InnovationLabMobileApp.Views
{
    public partial class UpcomingEventPage : ContentPage
    {
        CloudDataStore cloudStore = new CloudDataStore();
        List<UpcomingEvent> response;

        public UpcomingEventPage()
        {
            InitializeComponent();
            GetData();
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

            listView.ItemTemplate = new DataTemplate(typeof(viewCell));
            listView.SeparatorVisibility = SeparatorVisibility.None;
            listView.HasUnevenRows = true;

            listView.ItemSelected += (sender, e) =>
            {
                if (e.SelectedItem == null)
                {
                    return;
                }

                UpcomingEvent selected = listView.SelectedItem as UpcomingEvent;
                //Navigation.PushModalAsync(new PrototypesInfo(selected));
                ((ListView)sender).SelectedItem = null;
            };
        }
        // Getting Upcoming events Json Data
        async void GetData()
        {
            try
            {
                response = await cloudStore.GetUpcomingEvents();

                listView.ItemsSource = response;

            }
            catch (Exception ex)
            {

            }
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

        void Handle_Tapped(object sender, System.EventArgs e)
        {

        }
    }
    // List View Cell class
    public class viewCell : ViewCell
    {
        public viewCell()
        {
            Label label = new Label()
            {
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.StartAndExpand,
                TextColor = Color.Brown,
                FontAttributes = FontAttributes.Bold,
                FontSize = 17
            };
            label.SetBinding(Label.TextProperty, "EventName");

            Label stlabel = new Label()
            {
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.StartAndExpand,
                TextColor = Color.Black,
                FontAttributes = FontAttributes.Bold,
                FontSize = 17,
                Text = "Start Time:"
            };

            Label stlabel1 = new Label()
            {
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.StartAndExpand,
                TextColor = Color.Black,
                FontAttributes = FontAttributes.Bold,
                FontSize = 13,
            };
            stlabel1.SetBinding(Label.TextProperty, "Start");

            StackLayout stimestack = new StackLayout()
            {
                HorizontalOptions = LayoutOptions.StartAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                Children = { stlabel, stlabel1 }
            };

            Label etlabel = new Label()
            {
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.StartAndExpand,
                TextColor = Color.Black,
                FontAttributes = FontAttributes.Bold,
                FontSize = 17,
                Text = "End Time:"
            };

            Label etlabel1 = new Label()
            {
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.StartAndExpand,
                TextColor = Color.Black,
                FontAttributes = FontAttributes.Bold,
                FontSize = 13,
            };
            etlabel1.SetBinding(Label.TextProperty, "End");

            StackLayout etimestack = new StackLayout()
            {
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                Children = { etlabel, etlabel1 }
            };

            StackLayout timestack = new StackLayout()
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                Orientation = StackOrientation.Horizontal,
                Children = { stimestack, etimestack }
            };

            //BoxView box = new BoxView()
            //{
            //    HorizontalOptions = LayoutOptions.FillAndExpand,
            //    HeightRequest = 1,
            //    Color = Color.Black,
            //    VerticalOptions = LayoutOptions.End
            //};
            StackLayout stack = new StackLayout()
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                BackgroundColor = Color.FromHex("#FFE8C9"),
                Children = { label, timestack },
                Padding = 10
            };

            StackLayout Mainstack = new StackLayout()
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                BackgroundColor = Color.FromHex("#FFE8C9"),
                Children = { stack },
                Padding = new Thickness(0, 2, 0, 2)
            };

            StackLayout viewstack = new StackLayout()
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                BackgroundColor = Color.Red,
                Children = { Mainstack },
                Padding = new Thickness(0, 0, 0, 1)
            };
            View = viewstack;
        }
    }
}

