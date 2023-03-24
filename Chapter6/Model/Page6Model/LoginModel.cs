
using Chapter6.EndPoint.Page6EndPoint;
using Chapter6.HttpModel.Page6HttpModel;
using Newtonsoft.Json;
using Plugin.Connectivity;

namespace Chapter6.Model.Page6Model
{
    public class LoginModel
    {
        private LoginEndPoint _loginEndPoint;
        public string Email { get; set; }
        public string Password { get; set; }

        public LoginModel()
        {
            _loginEndPoint= new LoginEndPoint();
        }

        public async Task<PageResult> LoginDetailsAsync()
        {
            if (CrossConnectivity.Current.IsConnected)
            {
                var requestModel = new LoginRequestModel()
                {
                    Email = Email,
                    Password = Password
                };
                _loginEndPoint.LoginRequestModel = requestModel;
                var response = await _loginEndPoint.ExecuteAsync();
                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();
                    var addemployee = JsonConvert.DeserializeObject<LoginResponceModel>(data);
                    return new PageResult()
                    {
                        IsSuccess = true,
                        Message = "Login Successfully"
                    };
                }
                else
                {
                    return new PageResult()
                    {
                        IsSuccess = false,
                        Message = "Somthing went Wrong"
                    };
                }
            }
            else
            {
                return new PageResult()
                {
                    IsSuccess = false,
                    IsInternetError = true,
                    Message = "No Internet Connection"
                };
            }
        }
    }
}
