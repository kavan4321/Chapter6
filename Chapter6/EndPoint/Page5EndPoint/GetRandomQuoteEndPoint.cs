using Chapter6.Interface.Page5Interface;
using Refit;

namespace Chapter6.EndPoint.Page5EndPoint.RandomEnd;

public class GetRandomQuoteEndPoint
{
    public async Task<HttpResponseMessage> ExecuteAsync()
    {
        return await RestService.
            For<IQuoteApi>("https://dummyjson.com/quotes").
            GetRandomQuote();
    }
}
