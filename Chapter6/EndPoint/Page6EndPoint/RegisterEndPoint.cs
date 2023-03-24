
using Chapter6.HttpModel.Page6HttpModel;
using Chapter6.Interface.Page6Interface;
using Refit;

namespace Chapter6.EndPoint.Page6EndPoint
{
    public class RegisterEndPoint
    {
        public LoginRequestModel LoginRequestModel { get; set; }
        public async Task<HttpResponseMessage> ExecuteAsync()
        {

            return await RestService.
                For<ISignInApi>("https://reqres.in/api").
                LoginDetails(LoginRequestModel);
        }
    }
}
