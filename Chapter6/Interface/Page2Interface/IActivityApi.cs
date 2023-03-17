using Chapter6.HttpModel.Page2HttpModel;
using Refit;

namespace Chapter6.Interface.ActivityInterface;
public interface IActivityApi
{
   
    [Get("/Activities")]
    Task<HttpResponseMessage> GetActivityList();

    [Post("/Activities")]
    Task<HttpResponseMessage> AddActivity([Body] ActivityRequestModel model);

    [Put("/Activities/{id}")]
    Task<HttpResponseMessage> UpdateActivity([Body] ActivityRequestModel model, int id);
}
