using System;
using Android.App;
using Android.Content.PM;
using Android.OS;

namespace InnovationLabMobileApp.Droid
{
    [Activity(Label = "InnovationLabMobileApp.Droid", Icon = "@drawable/FDAicon", Theme = "@style/MyTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);

            #region For ZXing
            ZXing.Net.Mobile.Forms.Android.Platform.Init();
            #endregion


            LoadApplication(new App());
        }

        #region For  Permissions
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Permission[] grantResults)
        {
            ZXing.Net.Mobile.Android.PermissionsHandler.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
        #endregion
    }
}
