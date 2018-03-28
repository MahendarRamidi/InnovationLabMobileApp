using System;
using System.Collections.Generic;
using InnovationLabMobileApp.Models;
using Xamarin.Forms;

namespace InnovationLabMobileApp.Views
{
    public partial class PrototypesPage : ContentPage
    {
        CloudDataStore cloudStore = new CloudDataStore();
        List<Prototype> response;
       

        public static int value = 0;

        public PrototypesPage()
        {
            InitializeComponent();
            GetData();
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
            listView.ItemTemplate = new DataTemplate(typeof(ListCell));
            listView.SeparatorVisibility = SeparatorVisibility.None;
            listView.ItemSelected += (sender, e) =>
            {
                if (e.SelectedItem == null)
                {
                    return;
                }

                Prototype selected = listView.SelectedItem as Prototype;
                Navigation.PushModalAsync(new MainPrototypesInfo(selected));
                ((ListView)sender).SelectedItem = null;
            };
        }
        // Getting Prototypes json data
        async void GetData()
        {
            try
            {
                response = await cloudStore.GetPrototypes();

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
    }
    // List View Cell class
    public class ListCell : ViewCell
    {
        public ListCell()
        {
            Label label = new Label()
            {
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.StartAndExpand,
                TextColor = Color.FromHex("#301631"),
                Margin = new Thickness(10, 0, 0, 0),
              //  FontAttributes=FontAttributes.Bold,
               // FontSize=20
            };
            label.SetBinding(Label.TextProperty, "name");

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

            if (PrototypesPage.value == 0)
            {
                stack.BackgroundColor = Color.FromHex("#ffa755");
                PrototypesPage.value++;
            }
            else if (PrototypesPage.value == 1)
            {
                stack.BackgroundColor = Color.FromHex("#ff8a54");
                PrototypesPage.value++;
            }
            else if (PrototypesPage.value == 2)
            {
                stack.BackgroundColor = Color.FromHex("#de8275");
                PrototypesPage.value++;
            }
            else if (PrototypesPage.value == 3)
            {
                stack.BackgroundColor = Color.FromHex("#b0606d");
                PrototypesPage.value++;
            }
            else if (PrototypesPage.value == 4)
            {
                stack.BackgroundColor = Color.FromHex("#673453");
                PrototypesPage.value = 0;
            }
            View = stack;
        }
    }
}


