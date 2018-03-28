using InnovationLabMobileApp.Droid.Renderers;
using InnovationLabMobileApp.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(LoginButton), typeof(LoginButtonRenderer))]
namespace InnovationLabMobileApp.Droid.Renderers
{
    public class LoginButtonRenderer : ButtonRenderer
    {
        public LoginButtonRenderer()
        {

        }
        protected override void OnElementChanged(ElementChangedEventArgs<Button> e)
        {
            base.OnElementChanged(e);
            if (Control != null)
            {
                Control.Background = null;
            }
        }
    }
}