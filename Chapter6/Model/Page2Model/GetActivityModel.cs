using Chapter6.EndPoint.Page2EndPoint;
using Chapter6.HttpModel.Page2HttpModel;
using Newtonsoft.Json;
using Plugin.Connectivity;
using System.Collections.ObjectModel;

namespace Chapter6.Model.Psge2Model.ModelActivity;

public class GetActivityModel
{
    private GetActivityEndPoint _getActivityEndPoint;   
    public List<ActivityDetail> ActivityDetails { get; set; }   

    public GetActivityModel() 
    {
        _getActivityEndPoint = new GetActivityEndPoint();
    }

    public async Task<PageResult> GetActivityDetailsAsync()
    {
        if(CrossConnectivity.Current.IsConnected) 
        {
            var responce =await _getActivityEndPoint.ExecuteAsync();
            if (responce.IsSuccessStatusCode)
            {
                var data= await responce.Content.ReadAsStringAsync();
                var activity = JsonConvert.DeserializeObject<List<ActivityDetail>>(data);
                ActivityDetails = activity;
                return new PageResult()
                {
                    IsSuccess = true,
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
                Message = "No Internet Connection"
            };
        }
    }
}

