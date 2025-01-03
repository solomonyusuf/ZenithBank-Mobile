using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Views;

namespace ZenithBank
{
    [Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, LaunchMode = LaunchMode.SingleTop, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
    public class MainActivity : MauiAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);


            var windowInsetsController = Window.InsetsController;

            if (windowInsetsController != null)
            {
                // Hide status and navigation bars
                windowInsetsController.Hide(WindowInsets.Type.NavigationBars());
                windowInsetsController.SystemBarsBehavior = (int)WindowInsetsControllerBehavior.ShowTransientBarsBySwipe;
            }
            // Optional: Set status bar and navigation bar colors (will not show in fullscreen)
            //Window.SetStatusBarColor(Android.Graphics.Color.Transparent);
            Window.SetNavigationBarColor(Android.Graphics.Color.Transparent);

            /*Window.StatusBarContrastEnforced = true;
            Window.NavigationBarContrastEnforced = true;*/


        }

    }
}
