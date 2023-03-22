using Chapter6.HttpModel.Page5HttpModel;
using Chapter6.Model;
using Chapter6.Model.Page5Model;
using CommunityToolkit.Maui.Core.Extensions;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace Chapter6.ViewModel.Page5ViewModel.ViewmodelRandom;

public class RandomQuoteViewModel:INotifyPropertyChanged
{
    public event EventHandler<PageResult> GetRandomQuoteEvent;
    private GetRandomQuoteModel _getRandomQuoteModel;
    private ObservableCollection<RandomQuoteResponceModel> _randomQoute;
    public ObservableCollection<RandomQuoteResponceModel> RandomQoute
    {
        get => _randomQoute;
        set
        {
            _randomQoute = value;
            OnPropertyChanged();
        }
    }

    public ICommand RandomCommand { get;private set; }
    public RandomQuoteViewModel()
    {
        _getRandomQuoteModel=new GetRandomQuoteModel();
    }

    public async Task GetRandomQuote()
    {
        var result=await _getRandomQuoteModel.GetRandomQuote();
        RandomQoute = _getRandomQuoteModel.RandomQuote.ToObservableCollection();
        GetRandomQuoteEvent?.Invoke(this, result);
    }
    public event PropertyChangedEventHandler PropertyChanged;
    public void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
