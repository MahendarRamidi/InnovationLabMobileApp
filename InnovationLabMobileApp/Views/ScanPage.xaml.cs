﻿using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace InnovationLabMobileApp.Views
{
    public partial class ScanPage : ContentPage
    {
        public ScanPage()
        {
            InitializeComponent();
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
        }
        void ScanButton_Tapped(object sender, System.EventArgs e)
        {
            Navigation.PushModalAsync(new ScannerPage());
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
