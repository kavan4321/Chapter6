using Chapter6.ViewModel.Page6ViewModel.ViewModelERegister;
using CommunityToolkit.Maui.Alerts;

namespace Chapter6.View.Page6View;

public partial class SignUpScreen : ContentPage
{
	private RegisterVieModel _viewModel;
	public SignUpScreen()
	{
		InitializeComponent();
		_viewModel=(RegisterVieModel)BindingContext;
        _viewModel.RegisterEvent += ViewModelRegisterEvent;
	}

    private void ViewModelRegisterEvent(object sender, Model.PageResult e)
    {
        if (e.IsSuccess)
        {
            Toast.Make(e.Message,CommunityToolkit.Maui.Core.ToastDuration.Short).Show();
        }
        else
        {
            Toast.Make(e.Message, CommunityToolkit.Maui.Core.ToastDuration.Short).Show();
        }
    }

    private async void TapGestureRecognizerTapped(object sender, TappedEventArgs e)
    {
		await Navigation.PopAsync();
    }
}