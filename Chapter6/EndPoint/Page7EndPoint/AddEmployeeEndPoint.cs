using Chapter6.HttpModel.Page7HttpModel;
using Chapter6.Interface.Page7Interface;
using Chapter6.Model;
using Refit;

namespace Chapter6.EndPoint.Page7EndPoint
{
    public class AddEmployeeEndPoint
    {
        public EmployeeRequestModel EmployeeRequestModel { get; set; }

        public async Task<HttpResponseMessage> ExecuteAsync()
        {
            return await RestService.
                For<IEmployeeApi>("https://reqres.in/api").
                AddEmployee(EmployeeRequestModel);
        }
    }
}
