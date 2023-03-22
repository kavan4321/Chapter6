
using Chapter6.EndPoint.Page4EndPoint;
using Chapter6.HttpModel.Page4HttpModel;
using Newtonsoft.Json;
using Plugin.Connectivity;

namespace Chapter6.Model.Page4Model
{
    public class GetProductModel
    {
        private GetProductEndPoint _getProductEndPoint;

        public string Catagory { get; set; }
        public List<ProductDetail> ProductDetails { get; set; }
        public GetProductModel()
        {
            _getProductEndPoint = new GetProductEndPoint();
        }
        public async Task<PageResult> GetProduvtDetailsAsync()
        {
            if (CrossConnectivity.Current.IsConnected)
            {
                _getProductEndPoint.Category = Catagory;
                var responce = await _getProductEndPoint.ExecuteAsync();
                if (responce.IsSuccessStatusCode)
                {
                    var data =await responce.Content.ReadAsStringAsync();
                    var product=JsonConvert.DeserializeObject<ProductResponceModel>(data);
                    ProductDetails = product.ProductsDetails;
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
}
