
using Chapter6.Model.HttpModel;
using Chapter6.Model.Page1Model;
using CommunityToolkit.Maui.Core.Extensions;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Chapter6.ViewModel.Page1ViewModel.RecipeViewModel;

public class RecipeViewModel:INotifyPropertyChanged
{
    public event EventHandler<Result> GetEventHandler;

    private GetRecipeModel _getRecipeModel;
    private ObservableCollection<RecipeDetails> _recipeDetails;
    public ObservableCollection<RecipeDetails> RecipeDetails 
    {
        get { return _recipeDetails; }
        set {
            _recipeDetails = value;
            OnPropertyChanged();
        }
    }
    
   
    public async Task GetRecipeListAsync()
    {
        var result=await _getRecipeModel.GetRecipeDetailsAsync();
        RecipeDetails = _getRecipeModel.RecipeDetails.ToObservableCollection();
        GetEventHandler?.Invoke(this, result);
    }



    public event PropertyChangedEventHandler PropertyChanged;
    public void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
