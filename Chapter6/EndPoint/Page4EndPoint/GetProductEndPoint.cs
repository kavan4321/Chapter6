
using Chapter6.Interface.Page4Interface.ShoppingApi;
using Refit;

namespace Chapter6.EndPoint.Page4EndPoint
{
     public class GetProductEndPoint
    {
        public string Category { get; set; }

        public async  Task<HttpResponseMessage> ExecuteAsync()
        {
            return await RestService.
                For<IShoppingApi>("https://dummyjson.com/products").
                GetProductList(Category);
        }
    }
}
