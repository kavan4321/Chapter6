
using Chapter6.HttpModel.Page7HttpModel;
using Chapter6.ViewModel.Page7ViewModel.ViewModelEmployee;
using CommunityToolkit.Maui.Alerts;

namespace Chapter6.View.Page7View;

public partial class EmployeeScreen : ContentPage
{
	private EmployeeViewModel _viewModel;
	public EmployeeScreen()
	{
		InitializeComponent();
		_viewModel = (EmployeeViewModel)BindingContext;
        _viewModel.GetEmployeeEvent += ViewModelGetEmployeeEvent;
        _viewModel.EditEvent += ViewModelEditEvent;
        _viewModel.DeleteEmployeeEvent += ViewModelDeleteEmployeeEvent;
		_ = GetEmployeeList();

	}



    private void ViewModelDeleteEmployeeEvent(object sender, Model.PageResult e)
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

    private async void ViewModelEditEvent(object sender, EventArgs e)
    {
		EmployeeDetail employeeDetail = new()
		{
			Id = _viewModel.Id,
			FirstName=_viewModel.FirstName,
			LastName=_viewModel.LastName,
			Avatar=_viewModel.Avatar,
			Email= _viewModel.Email,
		};
		await Navigation.PushAsync(new EditEmployeeScreen(employeeDetail));	
    }

    private void ViewModelGetEmployeeEvent(object sender, Model.PageResult e)
    {
		if (e.IsSuccess == false)
		{
			Toast.Make(e.Message,CommunityToolkit.Maui.Core.ToastDuration.Short).Show();
		}
		else
		{
            Toast.Make(e.Message, CommunityToolkit.Maui.Core.ToastDuration.Short).Show();
        }
    }


    private async Task GetEmployeeList()
	{
		await _viewModel.GetEmployeeListAsync();
	}

    private void AddButtonClicked(object sender, EventArgs e)
    {
		Navigation.PushAsync(new AddEmployeeScreen());
    }
}