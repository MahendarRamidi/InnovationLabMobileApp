using Foundation;
using UIKit;

namespace InnovationLabMobileApp.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();

            #region For ZXing
            ZXing.Net.Mobile.Forms.iOS.Platform.Init();
            #endregion

            LoadApplication(new App());

            return base.FinishedLaunching(app, options);
        }
    }
}
