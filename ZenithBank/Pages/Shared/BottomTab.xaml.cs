using System.Windows.Input;

namespace ZenithBank.Pages.Shared;

public partial class BottomTab : ContentView
{
    public ICommand NavigateCommand { get; }

    public BottomTab()
	{
		InitializeComponent();
        NavigateCommand = new Command<string>(NavigateToPage);
        BindingContext = this;
    }

    private async void NavigateToPage(string pageName)
    {
        Type pageType = Type.GetType($"ZenithBank.Pages.{pageName}");
        if (pageType != null)
        {
            var pageInstance = (Page)Activator.CreateInstance(pageType);
            await Application.Current.MainPage.Navigation.PushAsync(pageInstance);
        }
    }
}