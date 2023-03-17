using Chapter6.ViewModel.Page2ViewModel.ViewModelActivity;
using Chapter6.ViewModel.Page2ViewModel.ViewModelAddActivity;
using CommunityToolkit.Maui.Alerts;

namespace Chapter6.View.Page2View;

public partial class AddActivityScreen : ContentPage
{
	private AddActivityViewModel _addActivityViewModel;
	public AddActivityScreen()
	{
		InitializeComponent();
		_addActivityViewModel = (AddActivityViewModel)BindingContext;
        _addActivityViewModel.AddEvent += ActivityViewModelAddEvent;

	}

    private async void ActivityViewModelAddEvent(object sender, Model.PageResult arg)
    {
		if (arg.IsSuccess)
		{
			await Navigation.PopAsync();
			_ = Toast.Make(arg.Message, CommunityToolkit.Maui.Core.ToastDuration.Short).Show();
		}
		else
		{
            _ = Toast.Make(arg.Message, CommunityToolkit.Maui.Core.ToastDuration.Short).Show();
		}
    }
}