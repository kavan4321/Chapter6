
using Chapter6.HttpModel.Page6HttpModel;
using Refit;
using System.Threading.Tasks;

namespace Chapter6.Interface.Page6Interface
{
    public interface ISignInApi
    {
        [Post("/login")]
        Task<HttpResponseMessage> LoginDetails([Body] LoginRequestModel model);

        [Post("/register")]
        Task<HttpResponseMessage> RegisterDetails([Body] LoginRequestModel model);

    }
}
