using InnovationLabMobileApp.Droid.Renderers;
using InnovationLabMobileApp.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(MyPicker), typeof(MyPickerRenderer))]
namespace InnovationLabMobileApp.Droid.Renderers
{
    public class MyPickerRenderer : PickerRenderer
    {
        public MyPickerRenderer()
        {
        }
        protected override void OnElementChanged(ElementChangedEventArgs<Picker> e)
        {
            base.OnElementChanged(e);
            if (Control != null)
            {
                Control.Background = null;
            }
        }
    }
}
