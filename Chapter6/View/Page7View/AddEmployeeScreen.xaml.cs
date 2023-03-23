using Chapter6.ViewModel.Page7ViewModel.ViewModelAddEmployee;
using CommunityToolkit.Maui.Alerts;

namespace Chapter6.View.Page7View;

public partial class AddEmployeeScreen : ContentPage
{
	private AddEmployeeViewModel _viewmodel;
	public AddEmployeeScreen()
	{
		InitializeComponent();
		_viewmodel = (AddEmployeeViewModel)BindingContext;
        _viewmodel.AddEmployeeEvent += ViewmodelAddEmployeeEvent;
	}
   
    private async void ViewmodelAddEmployeeEvent(object sender, Model.PageResult e)
    {
        if(e.IsSuccess)
        {
           await Navigation.PopAsync();
           _= Toast.Make(e.Message, CommunityToolkit.Maui.Core.ToastDuration.Short).Show();
        }
        else
        {
            _=Toast.Make(e.Message, CommunityToolkit.Maui.Core.ToastDuration.Short).Show();
        }
    }
}