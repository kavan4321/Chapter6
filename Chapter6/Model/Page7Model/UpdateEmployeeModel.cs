
using Chapter6.EndPoint.Page7EndPoint;
using Chapter6.HttpModel.Page7HttpModel;
using Chapter6.ViewModel.Page7ViewModel.ViewModelEditEmployee;
using Newtonsoft.Json;
using Plugin.Connectivity;

namespace Chapter6.Model.Page7Model
{
    public class UpdateEmployeeModel
    {
        private UpdateEmployeeEndpoint _updateEmployeeEndpoint;
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public UpdateEmployeeModel()
        {
            _updateEmployeeEndpoint = new UpdateEmployeeEndpoint();
        }

        public async Task<PageResult> UpdateEmployeeAsync()
        {
            if (CrossConnectivity.Current.IsConnected)
            {
                var requestModel = new EmployeeRequestModel()
                {
                    FirstName=FirstName,
                    LastName=LastName,
                    Email=Email,
                };
                _updateEmployeeEndpoint.Id = Id;
                _updateEmployeeEndpoint.EmployeeRequestModel = requestModel;
                var respose = await _updateEmployeeEndpoint.ExecuteAsync();
                if (respose.IsSuccessStatusCode)
                {
                    var data = await respose.Content.ReadAsStringAsync();
                    var employee = JsonConvert.DeserializeObject<UpdateEmployeeResponceModel>(data);
                    return new PageResult()
                    {
                        IsSuccess = true,
                        Message = employee.UpdatedAt.ToString()
                    };
                }
                else
                {
                    return new PageResult()
                    {
                        IsSuccess = false,
                        Message = "Somthing went wrong"
                    };
                }
            }
            else
            {
                return new PageResult()
                {
                    IsSuccess = false,
                    IsInternetError = true,
                    Message = "No internet Connection"
                };
            }
        }
    }
}
