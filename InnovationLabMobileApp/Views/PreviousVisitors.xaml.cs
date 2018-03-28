using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace InnovationLabMobileApp.Views
{
    public partial class PreviousVisitors : ContentPage
    {
        CloudDataStore cloudStore = new CloudDataStore();
        string[] response;
        List<User> lst = new List<User>();
        public static int value = 0;
        public PreviousVisitors()
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
            listView.ItemTemplate = new DataTemplate(typeof(Cell));
            listView.SeparatorVisibility = SeparatorVisibility.None;

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
      //Getting Json Data for 30 days visitors
        async void GetData()
        {
            try
            {
                response = await cloudStore.GetRegisteredUser();
                if (response != null)
                {
                    lst.Clear();
                    foreach (var i in response)
                    {
                        lst.Add(new User() { Name = i });
                    }

                    listView.ItemsSource = lst;
                }
                else
                {
                    await DisplayAlert("Error", "", "Ok");
                }

            }
            catch (Exception ex)
            {

            }
        }

      
    }
    //List View Cell
    public class Cell : ViewCell
    {
        public Cell()
        {
            Label label = new Label()
            {
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.StartAndExpand,
                TextColor = Color.FromHex("#301631"),
                Margin = new Thickness(10, 0, 0, 0),
            };
            label.SetBinding(Label.TextProperty, "Name");

            BoxView box = new BoxView()
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                HeightRequest = 1,
                Color = Color.FromHex("#FFE8C9"),
                VerticalOptions = LayoutOptions.End
            };
            StackLayout stack = new StackLayout()
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
            };
            stack.Children.Add(label);
            stack.Children.Add(box);

            if (PreviousVisitors.value == 0)
            {
                stack.BackgroundColor = Color.FromHex("#ffa755");
                PreviousVisitors.value++;
            }
            else if (PreviousVisitors.value == 1)
            {
                stack.BackgroundColor = Color.FromHex("#ff8a54");
                PreviousVisitors.value++;
            }
            else if (PreviousVisitors.value == 2)
            {
                stack.BackgroundColor = Color.FromHex("#de8275");
                PreviousVisitors.value++;
            }
            else if (PreviousVisitors.value == 3)
            {
                stack.BackgroundColor = Color.FromHex("#b0606d");
                PreviousVisitors.value++;
            }
            else if (PreviousVisitors.value == 4)
            {
                stack.BackgroundColor = Color.FromHex("#673453");
                PreviousVisitors.value = 0;
            }
            View = stack;
        }
   }

    public class User
    {
        public string Name { get; set; }
    }
}
