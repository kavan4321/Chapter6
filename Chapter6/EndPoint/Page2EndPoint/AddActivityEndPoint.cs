
using Chapter6.HttpModel.Page2HttpModel;
using Chapter6.Interface.ActivityInterface;
using Refit;

namespace Chapter6.EndPoint.Page2EndPoint
{
    public class AddActivityEndPoint
    {
        public ActivityRequestModel ActivityRequest { get; set; }

        public async Task<HttpResponseMessage> ExcuteAsync()
        {
            return await RestService.
                For<IActivityApi>("https://fakerestapi.azurewebsites.net/api/v1").
                AddActivity(ActivityRequest);
        } 

    }
}
