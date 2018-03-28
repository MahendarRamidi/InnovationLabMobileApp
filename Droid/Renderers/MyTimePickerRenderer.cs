using System;
using InnovationLabMobileApp.Droid.Renderers;
using InnovationLabMobileApp.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
[assembly: ExportRenderer(typeof(MyTimePicker), typeof(MyTimePickerRenderer))]
namespace InnovationLabMobileApp.Droid.Renderers
{
    public class MyTimePickerRenderer : TimePickerRenderer
    {
        public MyTimePickerRenderer()
        {
        }
        protected override void OnElementChanged(ElementChangedEventArgs<TimePicker> e)
        {
            base.OnElementChanged(e);
            if (Control != null)
            {
                Control.Background = null;
            }
        }
    }
}
