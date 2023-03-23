
using Chapter6.EndPoint.Page7EndPoint;
using Chapter6.HttpModel.Page7HttpModel;
using Newtonsoft.Json;
using Plugin.Connectivity;

namespace Chapter6.Model.Page7Model
{
     public class GetEmployeeModel
    {
        private GetEmployeeEndPoint _getEmployeeEndPoint;

        public List<EmployeeDetail> EmployeeDetails;
        public GetEmployeeModel()
        {
            _getEmployeeEndPoint = new GetEmployeeEndPoint();
        }

        public async Task<PageResult> GetEmployeeDetailAsync()
        {
            if (CrossConnectivity.Current.IsConnected)
            {
                var respose = await _getEmployeeEndPoint.ExecuteAsync();
                if (respose.IsSuccessStatusCode)
                {
                    var data = await respose.Content.ReadAsStringAsync();
                    var employee=JsonConvert.DeserializeObject<EmployeeResponceModel>(data);
                    EmployeeDetails = employee.EmployeeDetails;
                    return new PageResult()
                    {
                        IsSuccess = true
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
