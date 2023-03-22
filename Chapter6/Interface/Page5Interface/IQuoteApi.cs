using Refit;

namespace Chapter6.Interface.Page5Interface
{
    public interface IQuoteApi
    {
        [Get("/quotes")]
        Task<HttpResponseMessage> GetQuoteList();

        [Get("/random")]
        Task<HttpResponseMessage> GetRandomQuote();
    }
}
