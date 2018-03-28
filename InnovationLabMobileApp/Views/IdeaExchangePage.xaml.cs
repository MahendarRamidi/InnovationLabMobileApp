using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace InnovationLabMobileApp.Views
{
    public partial class IdeaExchangePage : ContentPage
    {
        CloudDataStore cloudStore = new CloudDataStore();
        public IdeaExchangePage()
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

            string[] businessCenterData = { "CBER", "CDER", "CDRH", "CFSAN", "CTP", "CVM", "NCTR", "OC", "ORA", "OIMT" };
            string[] ImpactpickerData = { "Impacts me or my team", "Impacts my office", "Impacts both internal and external (non FDA) group", "Impacts all of FDA" };
            string[] TechnologypickerData = { "IT Infrastructure", "Mobility", "Software","Storage Computing" };
            string[] SubTecnnologypickerData = { "Networking", "Server", "Other", "Mobile Apps", "Mobile Devices", "Mobile Tools", "Other",
                "Analytic Tool", "Collaboration Tool", "Other", "Cloud", "Database", "Other" };
            
            string[] IdeaTagspickerData = { "Big Data", "Visualization", "Analytics","Administrative - Deployment, PEO", 
            "Regulatory", "Scientific", "Research", "Cloud", "Mobile Friendly", "UI", "Prototype", "White Paper", "Other"};
            string[] ProjectStatuspickerData = { "Submitted", "Development", "Delivered" };

           
            BusinessUnitpicker.ItemsSource = businessCenterData;
            Impactpicker.ItemsSource = ImpactpickerData;
           
            Technologypicker.ItemsSource = TechnologypickerData;
            Technologypicker.SelectedIndexChanged += (object sender, EventArgs e) =>
            {
                if (Technologypicker.SelectedItem == "IT Infrastructure")
                {
                    string[] SubTechnology = { "Networking", "Server", "Other" };
                    if (SubTecnnologypicker.ItemsSource != null)
                    {
                        SubTecnnologypicker.ItemsSource = null;
                    }
                    SubTecnnologypicker.ItemsSource = SubTechnology;
                }
                else if (Technologypicker.SelectedItem == "Mobility")
                {
                    string[] SubTechnology = { "Mobile Apps", "Mobile Devices", "Mobile Tools", "Other" };
                    if (SubTecnnologypicker.ItemsSource != null)
                    {
                        SubTecnnologypicker.ItemsSource = null;
                    }
                    SubTecnnologypicker.ItemsSource = SubTechnology;
                }
                else if (Technologypicker.SelectedItem == "Software")
                {
                    string[] SubTechnology = { "Analytic Tool", "Collaboration Tool", "Other" };
                    if (SubTecnnologypicker.ItemsSource != null)
                    {
                        SubTecnnologypicker.ItemsSource = null;
                    }
                    SubTecnnologypicker.ItemsSource = SubTechnology;
                }
                else if (Technologypicker.SelectedItem == "Storage Computing")
                {
                    string[] SubTechnology = { "Cloud", "Database", "Other" };
                    if (SubTecnnologypicker.ItemsSource != null)
                    {
                        SubTecnnologypicker.ItemsSource = null;
                    }
                    SubTecnnologypicker.ItemsSource = SubTechnology;
                }
            };

            //SubTecnnologypicker.ItemsSource = SubTecnnologypickerData;
            IdeaTagspicker.ItemsSource = IdeaTagspickerData;
            ProjectStatuspicker.ItemsSource = ProjectStatuspickerData;

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

        void Cancel_Clicked(object sender, System.EventArgs e)
        {
            Subjectentry.Text = string.Empty;
            Descriptionentry.Text = string.Empty;
            Sponsorentry.Text = string.Empty;
            BusinessUnitpicker.SelectedItem = null;
            Impactpicker.SelectedItem = null;
            Technologypicker.SelectedItem = null;
            SubTecnnologypicker.SelectedItem = null;
            IdeaTagspicker.SelectedItem = null;
            ProjectStatuspicker.SelectedItem = null;
            IdeaOriginatorpicker.Text = string.Empty;
        }

        async void Submit_Clicked(object sender, System.EventArgs e)
        {
            try
            {
                if (Subjectentry.Text == null &&
                    Descriptionentry.Text == null &&
                    Sponsorentry.Text == null &&
                    BusinessUnitpicker.SelectedItem == null &&
                    Impactpicker.SelectedItem == null &&
                    Technologypicker.SelectedItem == null &&
                    SubTecnnologypicker.SelectedItem == null &&
                    IdeaTagspicker.SelectedItem == null &&
                    ProjectStatuspicker.SelectedItem == null &&
                    IdeaOriginatorpicker.Text == null)

                {
                    await DisplayAlert("Error", "Please Fill Missing Fields", "OK");
                }
                else if (Subjectentry.Text == null)
                {
                    await DisplayAlert("Error", "Please enter Subject.", "OK");
                }
                else if (Descriptionentry.Text == null)
                {
                    await DisplayAlert("Error", "Please enter Description.", "OK");
                }
                else if (Sponsorentry.Text == null)
                {
                    await DisplayAlert("Error", "Please enter Sponsor.", "OK");
                }
                else if (BusinessUnitpicker.SelectedItem == null)
                {
                    await DisplayAlert("Error", "Please select Business Unit.", "OK");
                }
                else if (Impactpicker.SelectedItem == null)
                {
                    await DisplayAlert("Error", "Please select Impact.", "OK");
                }
                else if (Technologypicker.SelectedItem == null)
                {
                    await DisplayAlert("Error", "Please select Technology.", "OK");
                }
                else if (SubTecnnologypicker.SelectedItem == null)
                {
                    await DisplayAlert("Error", "Please select SubTechnology.", "OK");
                }
                else if (IdeaTagspicker.SelectedItem == null)
                {
                    await DisplayAlert("Error", "Please select Idea Tags.", "OK");
                }
                else if (ProjectStatuspicker.SelectedItem == null)
                {
                    await DisplayAlert("Error", "Please select Project Status.", "OK");
                }
                else if (IdeaOriginatorpicker.Text == null)
                {
                    await DisplayAlert("Error", "Please enter Subject.", "OK");
                }
                else
                {
                    Dictionary<string, string> dict = new Dictionary<string, string>();
                    dict["Subject"] = Subjectentry.Text;
                    dict["Description"] = Descriptionentry.Text;
                    dict["Sponsor"] = Sponsorentry.Text;
                    dict["BusinessUnit"] = BusinessUnitpicker.SelectedItem.ToString();
                    dict["Impact"] = Impactpicker.SelectedItem.ToString();
                    dict["TechnologyArea"] = Technologypicker.SelectedItem.ToString();
                    dict["SubTechnologyArea"] = SubTecnnologypicker.SelectedItem.ToString();
                    dict["IdeaTags"] = IdeaTagspicker.SelectedItem.ToString();
                    dict["ProjectStatus"] = ProjectStatuspicker.SelectedItem.ToString();
                    dict["IdeaOriginator"] = IdeaOriginatorpicker.Text;

                    var isSuccess = await cloudStore.IdeaExchange(dict);
                    if (isSuccess)
                    {
                        Subjectentry.Text = string.Empty;
                        Descriptionentry.Text = string.Empty;
                        Sponsorentry.Text = null;
                        BusinessUnitpicker.SelectedItem = null;
                        Impactpicker.SelectedItem = null;
                        Technologypicker.SelectedItem = null;
                        SubTecnnologypicker.SelectedItem = null;
                        IdeaTagspicker.SelectedItem = null;
                        ProjectStatuspicker.SelectedItem = null;
                        IdeaOriginatorpicker.Text = string.Empty;

                        await DisplayAlert("Error", "Idea Submitted Successfully", "Ok");
                    }
                    else
                    {
                        await DisplayAlert("Error", "", "Ok");
                    }
                }

            }
            catch (Exception ex)
            {

            }
        }
    }
}
