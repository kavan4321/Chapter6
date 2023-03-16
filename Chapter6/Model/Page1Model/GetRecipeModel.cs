using Chapter6.EndPoint;
using Chapter6.HttpModel;
using Newtonsoft.Json;
using Plugin.Connectivity;
using System.Collections.ObjectModel;

namespace Chapter6.Model.Page1Model.RecipeModel
{
    public class GetRecipeModel
    {
        private GetRecipeEndPoint _getRecipeEndPoint;
        public ObservableCollection<RecipeDetail> RecipeDetails { get; set; }
        public GetRecipeModel()
        {
            _getRecipeEndPoint = new GetRecipeEndPoint();
        }

        public async Task<PageResult> GetRecipeDetailsAsync()
        {
            if (CrossConnectivity.Current.IsConnected)
            {
                var response = await _getRecipeEndPoint.ExecuteAsync();
                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();
                    var recipes = JsonConvert.DeserializeObject<RecipeResponseModel>(data);
                    RecipeDetails = recipes.RecipeDetails;
                    return new PageResult()
                    {
                        IsSuccess = true,
                    };                 
                }
                else
                {
                    return new PageResult()
                    {
                        IsSuccess = false,                      
                        Message = "Somthing went wrong"
                    };
                   
                }
            }
            else
            {
                return new PageResult()
                {
                    IsSuccess = false,
                    IsInternetError = true,
                    Message = "No Internet Connection"
                };
            }
        }
    }
}