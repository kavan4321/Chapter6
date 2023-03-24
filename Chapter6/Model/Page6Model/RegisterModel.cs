
using Chapter6.EndPoint.Page6EndPoint;
using Chapter6.HttpModel.Page6HttpModel;
using Newtonsoft.Json;
using Plugin.Connectivity;

namespace Chapter6.Model.Page6Model
{
    public class RegisterModel
    {
        private RegisterEndPoint _registerEndPoint;
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public RegisterModel()
        {
            _registerEndPoint=new RegisterEndPoint();   
        }

        public async Task<PageResult> RegisterDetailsAsync()
        {
            if (CrossConnectivity.Current.IsConnected)
            {
                var requestModel = new LoginRequestModel()
                {                 
                    Email = Email,
                    Password = Password
                };
                _registerEndPoint.LoginRequestModel = requestModel;
                var response = await _registerEndPoint.ExecuteAsync();
                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();
                    var addemployee = JsonConvert.DeserializeObject<LoginResponceModel>(data);
                    return new PageResult()
                    {
                        IsSuccess = true,
                        Message = "SignUp Successfully"
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
