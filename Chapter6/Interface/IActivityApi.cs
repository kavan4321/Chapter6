using Refit;

namespace Chapter6.Interface.ActivityInterface;
public interface IActivityApi
{
    [Get("/Activities")]
    Task<HttpResponseMessage> GetActivityList();
}
