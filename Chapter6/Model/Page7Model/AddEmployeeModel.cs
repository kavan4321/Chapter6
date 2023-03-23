using Chapter6.EndPoint.Page7EndPoint;
using Chapter6.HttpModel.Page7HttpModel;
using Newtonsoft.Json;
using Plugin.Connectivity;
using System.Security.Cryptography;

namespace Chapter6.Model.Page7Model
{
    public class AddEmployeeModel
    {
        private AddEmployeeEndPoint _addEmployeeEndPoint;
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Image { get; set; }
        public AddEmployeeModel()
        {
            _addEmployeeEndPoint= new AddEmployeeEndPoint();
        }
        public async Task<PageResult> AddEmployeeDetailsAsync()
        {
            if (CrossConnectivity.Current.IsConnected)
            {
                var requestModel = new EmployeeRequestModel()
                {
                    Email = Email,
                    FirstName = FirstName,
                    LastName = LastName,
                    Image= Image,
                };
                _addEmployeeEndPoint.EmployeeRequestModel= requestModel;
                var response =await _addEmployeeEndPoint.ExecuteAsync();
                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();
                    var addemployee=JsonConvert.DeserializeObject<AddEmployeeResponceModel>(data);
                    return new PageResult()
                    {   
                        IsSuccess = true,
                        Message="Data Added Successfully"
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
