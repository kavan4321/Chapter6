
using Chapter6.HttpModel.Page2HttpModel;
using Chapter6.Interface.ActivityInterface;
using Chapter6.Model;
using Refit;

namespace Chapter6.EndPoint.Page2EndPoint
{
    public class UpdateActivityendPoint
    {
        public int Id { get; set; } 
        public ActivityRequestModel ActivityRequestModel { get; set; }

        public async Task<HttpResponseMessage> ExecuteAsync()
        {
            return await RestService.
                For<IActivityApi>("https://fakerestapi.azurewebsites.net/api/v1").
                UpdateActivity(ActivityRequestModel, Id);
        }
    }
}
