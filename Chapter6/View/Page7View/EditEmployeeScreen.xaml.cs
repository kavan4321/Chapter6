using Chapter6.HttpModel.Page7HttpModel;
using Chapter6.ViewModel.Page7ViewModel.ViewModelEditEmployee;

namespace Chapter6.View.Page7View;

public partial class EditEmployeeScreen : ContentPage
{
	private EditEmployeeViewModel _viewModel;
	public EditEmployeeScreen(EmployeeDetail employeeDetail)
	{
		InitializeComponent();
		_viewModel = (EditEmployeeViewModel)BindingContext;
		_viewModel.EmployeeDetail=employeeDetail;
	}
}