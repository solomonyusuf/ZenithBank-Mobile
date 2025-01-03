using CommunityToolkit.Maui.Behaviors;
using CommunityToolkit.Maui.Core;
using ZenithBank.Pages.Authentication;

namespace ZenithBank.Pages;

public partial class WelcomePage : ContentPage
{
	public WelcomePage()
	{
		InitializeComponent();
        var currentTheme = Application.Current!.UserAppTheme;
        var currentIndex = currentTheme == AppTheme.Light ? 0 : 1;
        ThemeSegmentedControl.SelectedIndex = currentIndex;

        var theme = SecureStorage.GetAsync("theme").Result;
        var card = SecureStorage.GetAsync("cardTheme").Result;
        //#656768
        if (theme == null) SecureStorage.SetAsync("theme", currentIndex.ToString());
        if (card == null)
        {
            if (currentIndex == 0)
                SecureStorage.SetAsync("cardTheme", "WhiteSmoke");
            else
                SecureStorage.SetAsync("cardTheme", "#3d3d3d");
        };
    }
    private async void OnLoginClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new LoginPage());
    }

    private async void OnRegisterClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new RegisterPage());
    }

    private void SfSegmentedControl_SelectionChanged(object sender, Syncfusion.Maui.Toolkit.SegmentedControl.SelectionChangedEventArgs e)
    {
        Application.Current!.UserAppTheme = e.NewIndex == 0 ? AppTheme.Light : AppTheme.Dark;

        var currentTheme = Application.Current!.UserAppTheme;
        var currentIndex = currentTheme == AppTheme.Light ? 0 : 1;
        ThemeSegmentedControl.SelectedIndex = currentIndex;
        
        if (currentIndex == 1)
        {
         
            SecureStorage.SetAsync("cardTheme", "#3d3d3d");
            var statusBarBehavior = new StatusBarBehavior
            {
                StatusBarColor = Color.Parse("#17171a"),
                StatusBarStyle = StatusBarStyle.LightContent
            };

            // Apply it to the current page
            this.Behaviors.Add(statusBarBehavior);
        }
        else
        {
            SecureStorage.SetAsync("cardTheme", "WhiteSmoke");
            var statusBarBehavior = new StatusBarBehavior
            {
                StatusBarColor = Colors.WhiteSmoke,
                StatusBarStyle = StatusBarStyle.DarkContent
            };

            // Apply it to the current page
            this.Behaviors.Add(statusBarBehavior);
        }
    }
}