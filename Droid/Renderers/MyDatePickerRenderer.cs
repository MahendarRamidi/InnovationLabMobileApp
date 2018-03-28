using System;
using InnovationLabMobileApp.Droid.Renderers;
using InnovationLabMobileApp.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(MyDatePicker), typeof(MyDatePickerRenderer))]
namespace InnovationLabMobileApp.Droid.Renderers
{
    public class MyDatePickerRenderer : DatePickerRenderer
    {
        public MyDatePickerRenderer()
        {
        }
        protected override void OnElementChanged(ElementChangedEventArgs<DatePicker> e)
        {
            base.OnElementChanged(e);
            if (Control != null)
            {
                Control.Background = null;
            }
        }
    }
}
