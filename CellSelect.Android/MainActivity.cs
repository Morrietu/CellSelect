using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;
using System.IO;

namespace CellSelect.Droid
{
    [Activity(Label = "CellSelect", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize )]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Name of locally stored database
            string fileName = "cellselectDB.sqlite";
            // Location of locally stored database
            string fileLocation = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            // Combines name and location into one string
            string fullPath = Path.Combine(fileLocation, fileName);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            // Combined string is passed to App constructor
            LoadApplication(new App(fullPath));
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}