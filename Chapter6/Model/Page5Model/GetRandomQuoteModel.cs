using Chapter6.EndPoint.Page5EndPoint.RandomEnd;
using Chapter6.HttpModel.Page5HttpModel;
using Newtonsoft.Json;
using Plugin.Connectivity;

namespace Chapter6.Model.Page5Model
{
     public class GetRandomQuoteModel
    {
        private GetRandomQuoteEndPoint _getRandomQuoteEndPoint;

        public List<RandomQuoteResponceModel> RandomQuote { get; set; }
        public GetRandomQuoteModel()
        {
            _getRandomQuoteEndPoint=new GetRandomQuoteEndPoint();
        }
        public async Task<PageResult> GetRandomQuote()
        {
            if(CrossConnectivity.Current.IsConnected)
            {
                var responce =await _getRandomQuoteEndPoint.ExecuteAsync();
                if (responce.IsSuccessStatusCode)
                {
                    var data = await responce.Content.ReadAsStringAsync();
                    var quote=JsonConvert.DeserializeObject<List<RandomQuoteResponceModel>>(data);
                    RandomQuote = quote;
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
