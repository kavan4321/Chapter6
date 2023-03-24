
using Chapter6.EndPoint.Page7EndPoint;
using Chapter6.HttpModel.Page7HttpModel;
using Newtonsoft.Json;
using Plugin.Connectivity;

namespace Chapter6.Model.Page7Model
{
    public class DeleteEmployeeModel
    {
        private DeleteEmployeeEndPoint _deleteEmployeeEndPoint;

        public int Id { get; set; }
        public DeleteEmployeeModel()
        {
            _deleteEmployeeEndPoint=new DeleteEmployeeEndPoint();
        }

        public async Task<PageResult> DeleteEmployeeAsync()
        {
            if (CrossConnectivity.Current.IsConnected)
            {
                
                _deleteEmployeeEndPoint.Id = Id;
                var respose = await _deleteEmployeeEndPoint.ExecuteAsync();
                if (respose.IsSuccessStatusCode)
                {
                    var data = await respose.Content.ReadAsStringAsync();
                    var employee = JsonConvert.DeserializeObject<DeleteEmployeeResponce>(data);
                    return new PageResult()
                    {
                        IsSuccess = true,
                        Message = "Data Delete successfully"
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
