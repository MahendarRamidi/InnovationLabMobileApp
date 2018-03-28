using System;
using System.ComponentModel;
using InnovationLabMobileApp.iOS.Renderers;
using InnovationLabMobileApp.Renderers;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(LoginButton), typeof(LoginButtonRenderer))]
namespace InnovationLabMobileApp.iOS.Renderers
{
    public class LoginButtonRenderer: ButtonRenderer
    {
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            Control.Layer.BorderWidth = 0;
        }
    }
}
