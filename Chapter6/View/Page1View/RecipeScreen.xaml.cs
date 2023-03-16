using Chapter6.ViewModel.Page1ViewModel.RecipeViewModel;
namespace Chapter6.View.Page1View;
public partial class RecipeScreen : ContentPage
{
    private RecipeViewModel _recipeViewModel;
    public RecipeScreen()
    {
        InitializeComponent();
        GetInstance();
        _ = GetRecipeList();
    }
    private void GetInstance()
    {
        _recipeViewModel = (RecipeViewModel)BindingContext;
    }
    private async Task GetRecipeList()
    {
        await _recipeViewModel.GetRecipeListAsync();
    }
}
