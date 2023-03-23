using Chapter6.HttpModel.Page7HttpModel;
using Chapter6.ViewModel.Page7ViewModel.ViewModelEditEmployee;
using CommunityToolkit.Maui.Alerts;

namespace Chapter6.View.Page7View;

public partial class EditEmployeeScreen : ContentPage
{
	private EditEmployeeViewModel _viewModel;
	public EditEmployeeScreen(EmployeeDetail employeeDetail)
	{
		InitializeComponent();
		_viewModel = (EditEmployeeViewModel)BindingContext;
		_viewModel.EmployeeDetail=employeeDetail;
        _viewModel.EditEmployeeEvent += _viewModel_EditEmployeeEvent;
	}

    private void _viewModel_EditEmployeeEvent(object sender, Model.PageResult e)
    {
        if(e.IsSuccess)
		{
			Toast.Make(e.Message, CommunityToolkit.Maui.Core.ToastDuration.Short).Show();
		}
		else
		{
            Toast.Make(e.Message, CommunityToolkit.Maui.Core.ToastDuration.Short).Show();
        }
    }
}