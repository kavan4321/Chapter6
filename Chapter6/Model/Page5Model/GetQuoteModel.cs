
using Chapter6.EndPoint.Page5EndPoint;
using Chapter6.HttpModel.Page5HttpModel;
using Newtonsoft.Json;
using Plugin.Connectivity;

namespace Chapter6.Model.Page5Model
{
    public class GetQuoteModel
    {
        private GetQuoteEndPoint _getQuoteEndPoint;
        public List<QuoteDetail> QuoteDetails { get; set; }
        public GetQuoteModel()
        {
            _getQuoteEndPoint = new GetQuoteEndPoint();
        }

        public async Task<PageResult> GetQuoteDetailsAsync()
        {
            if (CrossConnectivity.Current.IsConnected)
            {
                var responce = await _getQuoteEndPoint.ExecuteAsync();
                if (responce.IsSuccessStatusCode)
                {
                    var date = await responce.Content.ReadAsStringAsync();
                    var quote = JsonConvert.DeserializeObject<QuoteResponceModel>(date);
                    QuoteDetails = quote.QuotesDetails;
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
                    Message = "No Internet Connection"
                };
            }
        }
    }  
}
