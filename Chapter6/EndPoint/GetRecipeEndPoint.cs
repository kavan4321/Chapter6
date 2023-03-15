
using Chapter6.Interface;
using Refit;

namespace Chapter6.EndPoint
{
    public class GetRecipeEndPoint
    {
        public async Task<HttpResponseMessage> ExecuteAsync()
        {
            return await RestService.For<IRecipeApi>("https://run.mocky.io/v3/").GetRecipeList();
        }

    }
}
