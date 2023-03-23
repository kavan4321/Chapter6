
using Chapter6.Interface.Page7Interface;
using Refit;

namespace Chapter6.EndPoint.Page7EndPoint
{
     public class GetEmployeeEndPoint
    {
        public async Task<HttpResponseMessage> ExecuteAsync()
        {
            return await RestService.
                For<IEmployeeApi>("https://reqres.in/api").
                GetEmployeeList();
        }
    }
}
