using Chapter6.HttpModel.Page5HttpModel;
using Chapter6.Model;
using Chapter6.Model.Page5Model;
using CommunityToolkit.Maui.Core.Extensions;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Chapter6.ViewModel.Page5ViewModel.ViewModelQuote;

public class QuoteViewModel:INotifyPropertyChanged
{
    public event EventHandler<PageResult> QuoteEventHandler;
    private GetQuoteModel _getQuoteModel;
    private ObservableCollection<QuoteDetail> _quoteDetails;
    public ObservableCollection<QuoteDetail> QuoteDetails
    {
        get => _quoteDetails;
        set
        {
            _quoteDetails = value;
            OnPropertyChanged();
        }
    }

    public QuoteViewModel()
    {
        _getQuoteModel=new GetQuoteModel();
    }

    public async Task GetQuoteListAsync()
    {
        var result=await _getQuoteModel.GetQuoteDetailsAsync();
        QuoteDetails = _getQuoteModel.QuoteDetails.ToObservableCollection();
        QuoteEventHandler?.Invoke(this, result);
    }
    public event PropertyChangedEventHandler PropertyChanged;
    public void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
