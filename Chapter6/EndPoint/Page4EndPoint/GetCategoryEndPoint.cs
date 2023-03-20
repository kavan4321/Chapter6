
using Chapter6.Interface.Page4Interface.ShoppingApi;
using Refit;

namespace Chapter6.EndPoint.Page4EndPoint
{
    public class GetCategoryEndPoint
    {
        public async Task<HttpResponseMessage> ExecuteAsync()
        {
            return await RestService.
                For<IShoppingApi>("https://dummyjson.com/products").GetCategoryList();
        }
    }
}
