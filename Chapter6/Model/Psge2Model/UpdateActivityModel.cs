using Chapter6.EndPoint.Page2EndPoint;
using Chapter6.HttpModel.Page2HttpModel;
using Newtonsoft.Json;
using Plugin.Connectivity;

namespace Chapter6.Model.Psge2Model
{
    public class UpdateActivityModel
    {
        private UpdateActivityendPoint _updateActivityendPoint;

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DueDate { get; set; }
        public bool Complete { get; set; }

        public UpdateActivityModel()
        {
            _updateActivityendPoint = new UpdateActivityendPoint();
        }


        public async Task<PageResult> UpdateActivityDetailAsnyc()
        {
            if (CrossConnectivity.Current.IsConnected)
            {
                var requestModel = new ActivityRequestModel()
                {
                    Name = Name,
                    DueDate = DueDate,
                    Complete = Complete,
                };
                _updateActivityendPoint.Id=Id;
                _updateActivityendPoint.ActivityRequestModel = requestModel;
                var response = await _updateActivityendPoint.ExecuteAsync();
                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();
                    var activity = JsonConvert.DeserializeObject<AddActivityResponceModel>(data);
                    return new PageResult()
                    {
                        IsSuccess = true,
                        Message = "Activity Update successfully"
                    };
                }
                else
                {
                    return new PageResult()
                    {
                        IsSuccess = false,
                        Message = "Somthing went wrong",
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
