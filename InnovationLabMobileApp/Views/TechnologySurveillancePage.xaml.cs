using System;
using System.Collections.Generic;
using InnovationLabMobileApp.Models;
using Xamarin.Forms;

namespace InnovationLabMobileApp.Views
{
    public partial class TechnologySurveillancePage : ContentPage
    {
        CloudDataStore cloudStore = new CloudDataStore();
        List<TechSurv> responses;
        List<TechSurv> lst2 = new List<TechSurv>();
        public static int value = 0;
        public TechnologySurveillancePage()
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
            listViewt.ItemTemplate = new DataTemplate(typeof(ListTechCell));
            listViewt.SeparatorVisibility = SeparatorVisibility.None;
            listViewt.ItemSelected += (sender, e) =>
            {
                if (e.SelectedItem == null)
                {
                    return;
                }

                TechSurv selected = listViewt.SelectedItem as TechSurv;
                Navigation.PushModalAsync(new MainTechnologySurvInfo(selected));
                ((ListView)sender).SelectedItem = null;
            };
        }
        // Getting Json White Papers data
        async void GetData()
        {
            try
            {
                responses = await cloudStore.GetTechSurv();

                listViewt.ItemsSource = responses;

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
        public class ListTechCell : ViewCell
        {
        public ListTechCell()
            {
                Label label = new Label()
                {
                    VerticalOptions = LayoutOptions.CenterAndExpand,
                    HorizontalOptions = LayoutOptions.StartAndExpand,
                    TextColor = Color.FromHex("#301631"),
                    Margin = new Thickness(10, 0, 0, 0)

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

            if (TechnologySurveillancePage.value == 0)
                {
                    stack.BackgroundColor = Color.FromHex("#ffa755");
                    TechnologySurveillancePage.value++;
                }
            else if (TechnologySurveillancePage.value == 1)
                {
                    stack.BackgroundColor = Color.FromHex("#ff8a54");
                    TechnologySurveillancePage.value++;
                }
            else if (TechnologySurveillancePage.value == 2)
                {
                    stack.BackgroundColor = Color.FromHex("#de8275");
                    TechnologySurveillancePage.value++;
                }
            else if (TechnologySurveillancePage.value == 3)
                {
                    stack.BackgroundColor = Color.FromHex("#b0606d");
                    TechnologySurveillancePage.value++;
                }
            else if (TechnologySurveillancePage.value == 4)
                {
                    stack.BackgroundColor = Color.FromHex("#673453");
                    TechnologySurveillancePage.value = 0;
                }
                View = stack;
            }
        }
}