using Refit;

namespace Chapter6.Interface
{
    public interface IRecipeApi
    {
        [Get("/19d42796-27a9-4b70-b753-5e710ae6e339")]
        Task<HttpResponseMessage> GetRecipeList();
    }
}
