using Chapter6.EndPoint.Page2EndPoint;
using Chapter6.HttpModel.Page2HttpModel;
using Newtonsoft.Json;
using Plugin.Connectivity;

namespace Chapter6.Model.Psge2Model
{
    public class DeleteActivityModel
    {
        private DeleteActivtiyEndPoint _deleteActivtiyEndPoint;

        public int Id { get; set; }
        public DeleteActivityModel()
        {
            _deleteActivtiyEndPoint = new DeleteActivtiyEndPoint();
        }
        public async Task<PageResult> DeleteActivityAsync()
        {
            if (CrossConnectivity.Current.IsConnected)
            {
                _deleteActivtiyEndPoint.Id = Id;
                var responce = await _deleteActivtiyEndPoint.ExecuteAsync();
                if (responce.IsSuccessStatusCode)
                {
                    var data = await responce.Content.ReadAsStringAsync();
                    var activity = JsonConvert.DeserializeObject<DeleteActivityResponceModel>(data);
                    return new PageResult()
                    {
                        IsSuccess = true,
                        Message = "Activity Deleted Successfully"
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
