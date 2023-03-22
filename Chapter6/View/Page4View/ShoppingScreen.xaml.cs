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
		_ =GetProductList();
	}
	private async Task GetCatagoryList()
	{
		await _viewModel.GetCatagoryDetailAsync();
	}

	private async Task GetProductList()
	{
		await _viewModel.GetProductDetailAsync();
	}
}