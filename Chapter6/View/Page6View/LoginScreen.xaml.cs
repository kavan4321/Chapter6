using Chapter6.ViewModel.Page6ViewModel.ViewModelLogin;
using CommunityToolkit.Maui.Alerts;

namespace Chapter6.View.Page6View;

public partial class LoginScreen : ContentPage
{
	private LoginViewModel _loginViewModel;
	public LoginScreen()
	{
		InitializeComponent();
		_loginViewModel = (LoginViewModel)BindingContext;
        _loginViewModel.LoginEvent += LoginViewModelLoginEvent;
	}

    private void LoginViewModelLoginEvent(object sender, Model.PageResult e)
    {
		if (e.IsSuccess)
		{
			Toast.Make(e.Message, CommunityToolkit.Maui.Core.ToastDuration.Short).Show();
		}
		else
		{
			Toast.Make(e.Message, CommunityToolkit.Maui.Core.ToastDuration.Short).Show();
		}
    }

    private async void TapGestureRecognizerTapped(object sender, TappedEventArgs e)
    {
		await Navigation.PushAsync(new SignUpScreen());
    }
}