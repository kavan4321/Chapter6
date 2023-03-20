using Chapter6.EndPoint.Page2EndPoint;
using Chapter6.HttpModel.Page2HttpModel;
using Newtonsoft.Json;
using Plugin.Connectivity;
using System.Diagnostics;

namespace Chapter6.Model.Psge2Model
{
    public class AddActivityModel
    {
        private AddActivityEndPoint _activityEndPoint;

        public string Name { get; set; }
        public DateTime DueDate { get; set; }
        public bool Complete { get; set; }

        public AddActivityModel()
        {
            _activityEndPoint = new AddActivityEndPoint();  
        }

        public async Task<PageResult> AddActivityDetailsAsync()
        {
            if (CrossConnectivity.Current.IsConnected)
            {
                var requestModel = new ActivityRequestModel()
                {
                    Name= Name,
                    DueDate = DueDate,
                    Complete = Complete,
                };
                _activityEndPoint.ActivityRequest = requestModel;
                var response = await _activityEndPoint.ExcuteAsync();
                if (response.IsSuccessStatusCode)
                {
                    var data=await response.Content.ReadAsStringAsync();
                    var activity= JsonConvert.DeserializeObject<AddActivityResponceModel>(data);
                    return new PageResult()
                    {
                        IsSuccess=true,
                        Message = "Activity added successfully"
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
