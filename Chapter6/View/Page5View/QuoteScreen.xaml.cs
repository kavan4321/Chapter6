using Chapter6.ViewModel.Page5ViewModel.ViewModelQuote;

namespace Chapter6.View.Page5View;

public partial class QuoteScreen : ContentPage
{
	private QuoteViewModel _quoteViewModel;
	public QuoteScreen()
	{
		InitializeComponent();
		_quoteViewModel=(QuoteViewModel)BindingContext;
		_ = GetQuoteList();
	}

	 private async Task GetQuoteList()
	{
		await _quoteViewModel.GetQuoteListAsync();
	} 
}