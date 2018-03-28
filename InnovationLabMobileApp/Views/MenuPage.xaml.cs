using System;
using System.Collections.Generic;
using InnovationLabMobileApp.Renderers;
using Xamarin.Forms;

namespace InnovationLabMobileApp.Views
{
    public partial class MenuPage : ContentPage
    {
        public MenuPage()
        {
            InitializeComponent();
            Icon = "";
            Title = "Menu";

            var menupageItems = new List<MenuPageItem>();
            menupageItems.Add(new MenuPageItem
            {
                Title = "Home",
                IconSource = "MenuHome.png",
            });
            menupageItems.Add(new MenuPageItem
            {
                Title = "About FDA Lab",
                IconSource = "MenuAboutLab.png",
            });
            menupageItems.Add(new MenuPageItem
            {
                Title = "Upcoming Events",
                IconSource = "MenuEvents.png",
            });
            menupageItems.Add(new MenuPageItem
            {
                Title = "Take the Lab Tour",
                IconSource = "MenuTour.png",
            });
            menupageItems.Add(new MenuPageItem
            {
                Title = "Take our Survey",
                IconSource = "MenuSurvey.png",
            });
            menupageItems.Add(new MenuPageItem
            {
                Title = "Register For Event",
                IconSource = "MenuRegister.png",
            });
            menupageItems.Add(new MenuPageItem
            {
                Title = "Idea Exchange",
                IconSource = "MenuIdeaExchange.png",
            });
            menupageItems.Add(new MenuPageItem
            {
                Title = "Logout",
                IconSource = "MenuLogout.png",
            });
            listView.ItemsSource = menupageItems;
            listView.ItemTemplate = new DataTemplate(typeof(Cell));
            listView.SeparatorVisibility = SeparatorVisibility.None;
            listView.ItemSelected += (sender, e) =>
            {
                try
                {
                    if (e.SelectedItem == null)
                        return;
                    var parentDetailView = (MasterDetailPage)this.Parent;
                    var item = (MenuPageItem)e.SelectedItem;
                    parentDetailView.IsPresented = false;

                    switch (item.Title)
                    {
                        case "Home":
                            parentDetailView.Detail = new LandingPage();

                            break;
                        case "About FDA Lab":
                            parentDetailView.Detail = new AboutFDAPage();
                            break;
                        case "Upcoming Events":
                            parentDetailView.Detail = new UpcomingEventPage();
                            break;
                        case "Take the Lab Tour":
                            parentDetailView.Detail = new ScheduleATourPage();
                            break;
                        case "Take our Survey":
                            parentDetailView.Detail = new TakeOurSurveyPage();
                            break;
                        case "Register For Event":
                            parentDetailView.Detail = new EventRegistrationPage();
                            break;
                        case "Idea Exchange":
                            parentDetailView.Detail = new IdeaExchangePage();
                            break;
                        case "Logout":
                            //parentDetailView.Detail = new LogInPage();
                            App.Current.MainPage = new LogInPage();
                            break;
                    }
                }
                catch (Exception ex)
                {

                }
                ((ListView)sender).SelectedItem = null;
            };

        }


        public class Cell : MyViewCell

        {
            public Cell()
            {
                var grid = new Grid()
                {
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    VerticalOptions = LayoutOptions.FillAndExpand,
                    BackgroundColor = Color.FromHex("#fbd0a9")
                };
                grid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });
                grid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });
                grid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Star });

                var image = new Image()
                {
                    VerticalOptions = LayoutOptions.CenterAndExpand,
                    HorizontalOptions = LayoutOptions.Start,
                    Margin = new Thickness(10, 0, 0, 0)
                };
                image.SetBinding(Image.SourceProperty, "IconSource");

                var label = new Label()
                {
                    VerticalOptions = LayoutOptions.CenterAndExpand,
                    HorizontalOptions = LayoutOptions.Start,
                    Margin = new Thickness(10, 0, 0, 0),
                    TextColor = Color.FromHex("#b52d03")

                };
                label.SetBinding(Label.TextProperty, "Title");

                var colanlabel = new Label()
                {
                    VerticalOptions = LayoutOptions.CenterAndExpand,
                    HorizontalOptions = LayoutOptions.End,
                    Text = ">",
                    TextColor = Color.FromHex("#893313"),
                    Margin = new Thickness(0, 0, 10, 0)
                };


                grid.Children.Add(image, 0, 0);
                grid.Children.Add(label, 1, 0);
                grid.Children.Add(colanlabel, 2, 0);

                BoxView box = new BoxView()
                {
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    HeightRequest = 1,
                    Color = Color.FromHex("#893313"),
                    VerticalOptions = LayoutOptions.End
                };
                StackLayout stack = new StackLayout()
                {
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    VerticalOptions = LayoutOptions.FillAndExpand,
                    Spacing = 0
                };
                stack.Children.Add(grid);
                stack.Children.Add(box);
                View = stack;
            }
        }

        public class MenuPageItem
        {
            public string Title { get; set; }

            public string IconSource { get; set; }
        }
    }
}

