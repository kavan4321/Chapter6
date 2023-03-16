using Chapter6.HttpModel;
using Chapter6.Model;
using Chapter6.Model.Page1Model.RecipeModel;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace Chapter6.ViewModel.Page1ViewModel.RecipeViewModel;

public class RecipeViewModel : INotifyPropertyChanged
{
    public EventHandler<PageResult> GetEventHandler;

    private GetRecipeModel _getRecipeModel;
    private ObservableCollection<RecipeDetail> _recipeDetails;
    public ObservableCollection<RecipeDetail> RecipeDetails
    {
        get => _recipeDetails;
        set
        {
            _recipeDetails = value;
            OnPropertyChanged();
        }
    }

    public ICommand RefreshCommand { get;private set; }


    private bool _isRefresh;
    public bool IsRefresh
    {
        get => _isRefresh;
        set
        {
            _isRefresh = value;
            OnPropertyChanged();
        }
    }

    private bool _isLoading;
    public bool IsLoading
    {
        get => _isLoading;
        set
        {
            _isLoading= value;
            OnPropertyChanged();
        }
    }

    private bool _collectionShow;
    public bool CollectionShow
    {
        get => _collectionShow;
        set
        {
            _collectionShow = value;
            OnPropertyChanged();
        }
    }

    public RecipeViewModel()
    {
        _getRecipeModel = new GetRecipeModel();
        RefreshCommand = new Command(Refresh);
    }


    public void Refresh() 
    { 
        if(IsRefresh==true) 
        {
            _ = GetRecipeListAsync();
            IsRefresh = false;
        }
    }

    public async Task GetRecipeListAsync()
    {
       
        IsLoading = true;
        CollectionShow = false;
        var result = await _getRecipeModel.GetRecipeDetailsAsync();
        RecipeDetails = _getRecipeModel.RecipeDetails;
        GetEventHandler?.Invoke(this, result);
        IsLoading=false;
        CollectionShow = true;

    }



    public event PropertyChangedEventHandler PropertyChanged;
    public void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}