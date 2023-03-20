using Chapter6.ViewModel.Page4ViewModel.ViewModelShopping;

namespace Chapter6.View.Page4View;

public partial class ShoppingScreen : ContentPage
{
	private ShoppingViewModel _viewModel;
	public ShoppingScreen()
	{
		InitializeComponent();
		_viewModel = (ShoppingViewModel)BindingContext;
		_ = GetCatagoryList();
	}
	private async Task GetCatagoryList()
	{
		await _viewModel.GetCatagoryDetailAsync();
	}
}