
using Chapter6.HttpModel.Page7HttpModel;
using Refit;

namespace Chapter6.Interface.Page7Interface
{
    public interface IEmployeeApi
    {
        [Get("/users")]
        Task<HttpResponseMessage> GetEmployeeList();
      
        [Post("/users")]
        Task<HttpResponseMessage> AddEmployee([Body] EmployeeRequestModel model);

        [Put("/users/{id}")]
        Task<HttpResponseMessage> UpdadeEmployee([Body] EmployeeRequestModel model,int id);

        [Delete("/users/{id}")]
        Task<HttpResponseMessage> DeleteEmployee(int id);
    }
}
