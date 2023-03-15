using Chapter6.EndPoint;
using Chapter6.Model.HttpModel;
using Newtonsoft.Json;
using Plugin.Connectivity;

namespace Chapter6.Model.Page1Model
{
    public class GetRecipeModel
    {
        private GetRecipeEndPoint _getRecipeEndPoint;
        public List<RecipeDetails> RecipeDetails { get; set; }
        public GetRecipeModel()
        {
            _getRecipeEndPoint = new GetRecipeEndPoint();
        }

        public async Task<Result> GetRecipeDetailsAsync()
        {
            if(CrossConnectivity.Current.IsConnected)
            {
                var response=await _getRecipeEndPoint.ExecuteAsync();
                if(response.IsSuccessStatusCode)
                {
                    var data=await response.Content.ReadAsStringAsync();
                    var recipe= JsonConvert.DeserializeObject<RecipeResponseModel>(data);
                    RecipeDetails = recipe.RecipeDetails;
                    return new Result()
                    {
                        IsSuccess = true,
                    };
                }
                else
                {
                    return new Result()
                    {
                        IsSuccess = false,
                        Message = "Somthing went wrong"
                    };
                }
            }
            else
            {
                return new Result()
                {
                    IsSuccess = false,
                    IsInternetError = true,
                    Message="No Internet Connection"
                };
            }
        }

    }
}
