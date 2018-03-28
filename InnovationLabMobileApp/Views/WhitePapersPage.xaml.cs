using System;
using System.Collections.Generic;
using InnovationLabMobileApp.Models;
using Xamarin.Forms;

namespace InnovationLabMobileApp.Views
{
    public partial class WhitePapersPage : ContentPage
    {
        CloudDataStore cloudStore = new CloudDataStore();
        List<WhitePaper> responses;
        List<WhitePaper> lst1 = new List<WhitePaper>();

        public static int value = 0;
        public WhitePapersPage()
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
            listViews.ItemTemplate = new DataTemplate(typeof(ListWhiteCell));
            listViews.SeparatorVisibility = SeparatorVisibility.None;
            listViews.ItemSelected += (sender, e) =>
            {
                if (e.SelectedItem == null)
                {
                    return;
                }

                WhitePaper selected = listViews.SelectedItem as WhitePaper;
                Navigation.PushModalAsync(new MainWhitePapersInfo(selected));
                ((ListView)sender).SelectedItem = null;
            };
        }
        // Getting White papers Json Data
        async void GetData()
        {
            try
            {
                responses = await cloudStore.GetWhitePapers();

                listViews.ItemsSource = responses;

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
    // List View Cell Class
    public class ListWhiteCell : ViewCell
    {
        public ListWhiteCell()
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

            if (WhitePapersPage.value == 0)
            {
                stack.BackgroundColor = Color.FromHex("#ffa755");
                WhitePapersPage.value++;
            }
            else if (WhitePapersPage.value == 1)
            {
                stack.BackgroundColor = Color.FromHex("#ff8a54");
                WhitePapersPage.value++;
            }
            else if (WhitePapersPage.value == 2)
            {
                stack.BackgroundColor = Color.FromHex("#de8275");
                WhitePapersPage.value++;
            }
            else if (WhitePapersPage.value == 3)
            {
                stack.BackgroundColor = Color.FromHex("#b0606d");
                WhitePapersPage.value++;
            }
            else if (WhitePapersPage.value == 4)
            {
                stack.BackgroundColor = Color.FromHex("#673453");
                WhitePapersPage.value = 0;
            }
            View = stack;
        }
    }
}


