using ZenithBank.ViewModels;

namespace ZenithBank.Pages;

public partial class DashboardPage : ContentPage
{
	public DashboardPage()
	{
		InitializeComponent();

		var model = new DashboardViewModel();
		BindingContext = model;
	}
}