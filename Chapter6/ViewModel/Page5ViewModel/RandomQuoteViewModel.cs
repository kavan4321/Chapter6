using Chapter6.Model;
using Chapter6.Model.Page5Model;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace Chapter6.ViewModel.Page5ViewModel.ViewmodelRandom;

public class RandomQuoteViewModel:INotifyPropertyChanged
{
    public event EventHandler<PageResult> GetRandomQuoteEvent;
    private GetRandomQuoteModel _getRandomQuoteModel;

    private string _author;
    public string Author
    {
        get => _author;
        set
        {
            _author = value;
            OnPropertyChanged();
        }
    }

    private string _quote;
    public string Quote
    {
        get => _quote;
        set
        {
            _quote = value;
            OnPropertyChanged();
        }
    }

    public ICommand RandomCommand { get;private set; }
    public RandomQuoteViewModel()
    {
        _getRandomQuoteModel=new GetRandomQuoteModel();
        _= GetRandomQuote();
        RandomCommand = new Command(() => { _ = GetRandomQuote(); });
    }

    public async Task GetRandomQuote()
    {
        var result=await _getRandomQuoteModel.GetRandomQuote();
        Author = _getRandomQuoteModel.Author;
        Quote = _getRandomQuoteModel.Quote;
        GetRandomQuoteEvent?.Invoke(this, result);
    }

    public event PropertyChangedEventHandler PropertyChanged;
    public void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
