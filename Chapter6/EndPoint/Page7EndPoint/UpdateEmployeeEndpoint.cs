
using Chapter6.HttpModel.Page7HttpModel;
using Chapter6.Interface.Page7Interface;
using Refit;

namespace Chapter6.EndPoint.Page7EndPoint
{
    public class UpdateEmployeeEndpoint
    {
        public int Id { get; set; }
        public EmployeeRequestModel EmployeeRequestModel { get; set; }
        public async Task<HttpResponseMessage> ExecuteAsync()
        {
            return await RestService.
                For<IEmployeeApi>("https://reqres.in/api").
                UpdadeEmployee(EmployeeRequestModel,Id);
        }
    }
}
