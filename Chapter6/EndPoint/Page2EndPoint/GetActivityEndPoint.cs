using Chapter6.Interface.ActivityInterface;
using Refit;

namespace Chapter6.EndPoint.Page2EndPoint
{
    public class GetActivityEndPoint
    {
        public async Task<HttpResponseMessage> ExecuteAsync()
        {
            return await RestService.
                For<IActivityApi>("https://fakerestapi.azurewebsites.net/api/v1").
                GetActivityList();
        }
    }
}
