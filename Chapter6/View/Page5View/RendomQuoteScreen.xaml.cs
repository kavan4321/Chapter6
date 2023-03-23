using Chapter6.ViewModel.Page5ViewModel.ViewmodelRandom;

namespace Chapter6.View.Page5View;

public partial class RendomQuoteScreen : ContentPage
{
	private RandomQuoteViewModel _randomQuoteViewModel;
	public RendomQuoteScreen()
	{
		InitializeComponent();
		_randomQuoteViewModel= (RandomQuoteViewModel)BindingContext;
		_ = GetRandomList();
	}
	private async Task GetRandomList()
	{
		await _randomQuoteViewModel.GetRandomQuote();
	}
}