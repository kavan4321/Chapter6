using Chapter6.EndPoint.Page4EndPoint;
using Chapter6.HttpModel.Page4HttpModel;
using CommunityToolkit.Maui.Core.Extensions;
using Newtonsoft.Json;
using Plugin.Connectivity;
using System.Collections.ObjectModel;

namespace Chapter6.Model.Page4Model.Model.Catogary;

public class GetCatogaryModel
{
    private GetCategoryEndPoint _getCategoryEndPoint;
    public List<string> CatogaryDetails { get; set; }

    public GetCatogaryModel() 
    { 
        _getCategoryEndPoint = new GetCategoryEndPoint();
    }
    public async Task<PageResult> GetCatogaryDetailAsync()
    {
        if (CrossConnectivity.Current.IsConnected)
        {
            var responce= await _getCategoryEndPoint.ExecuteAsync();
            if (responce.IsSuccessStatusCode)
            {
                var data= await responce.Content.ReadAsStringAsync();
                var catogary = JsonConvert.DeserializeObject<List<string>>(data);
                CatogaryDetails = catogary;
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
                Message = "No Internet connection"
            };
        }
    }
}
