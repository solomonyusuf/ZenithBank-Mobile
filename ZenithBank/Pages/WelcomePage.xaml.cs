using CommunityToolkit.Maui.Behaviors;
using CommunityToolkit.Maui.Core;
using ZenithBank.Pages.Authentication;

namespace ZenithBank.Pages;

public partial class WelcomePage : ContentPage
{
	public WelcomePage()
	{
		InitializeComponent();
        var theme = SecureStorage.GetAsync("theme").Result;
        var card = SecureStorage.GetAsync("cardTheme").Result;

        var currentTheme = Application.Current!.UserAppTheme;
        var currentIndex = currentTheme == AppTheme.Light ? 0 : 1;
       
        ThemeSegmentedControl.SelectedIndex = currentIndex;
 
        if (theme == null) 
            SecureStorage.SetAsync("theme", currentIndex.ToString());
        else
            ThemeSegmentedControl.SelectedIndex = int.Parse(theme);

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

        SecureStorage.SetAsync("theme", $"{currentIndex}");

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