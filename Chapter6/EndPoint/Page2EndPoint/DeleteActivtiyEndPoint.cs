using Chapter6.Interface.ActivityInterface;
using Refit;

namespace Chapter6.EndPoint.Page2EndPoint
{
    public class DeleteActivtiyEndPoint
    {
        public int Id { get; set; }
        public async Task<HttpResponseMessage> ExecuteAsync()
        {
            return await RestService.
                For<IActivityApi>("https://fakerestapi.azurewebsites.net/api/v1").
                DeleteActivity(Id);
        }
    }
}
