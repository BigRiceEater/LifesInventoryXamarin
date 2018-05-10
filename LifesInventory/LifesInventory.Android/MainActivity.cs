using System.IO;
using Android.App;
using Android.Content.PM;
using Android.OS;
using Prism;
using Prism.Ioc;

namespace LifesInventory.Droid
{
    [Activity(Label = "LifesInventory", Icon = "@mipmap/ic_launcher", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App(new AndroidInitializer(), MainActivity.GetDbLocation()));
        }
        private static string GetDbLocation()
        {
            string dbName = "lifes_inventory_db.sqlite";
            string dbFolderPath = 
                System.Environment.GetFolderPath(
                    System.Environment.SpecialFolder.Personal);
            var location = Path.Combine(dbFolderPath, dbName);
            return location;
        }
    }

    public class AndroidInitializer : IPlatformInitializer
    {
        public void RegisterTypes(IContainerRegistry container)
        {
            // Register any platform specific implementations
        }
    }
}

