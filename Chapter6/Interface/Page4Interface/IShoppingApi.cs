
using Refit;

namespace Chapter6.Interface.Page4Interface.ShoppingApi;

public interface IShoppingApi
{
    [Get("/categories")]
    Task<HttpResponseMessage> GetCategoryList();

    [Get("/category/{category}")]
    Task<HttpResponseMessage> GetProductList(string category);
}
