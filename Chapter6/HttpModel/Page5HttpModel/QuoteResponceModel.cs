
using Chapter6.EndPoint.Page5EndPoint;
using Newtonsoft.Json;

namespace Chapter6.HttpModel.Page5HttpModel
{
    public class QuoteResponceModel
    {
        [JsonProperty("quotes")]
        public List<QuoteDetail> QuotesDetails { get; set; }

        [JsonProperty("total")]
        public int Total { get; set; }

        [JsonProperty("skip")]
        public int Skip { get; set; }

        [JsonProperty("limit")]
        public int Limit { get; set; }
    }
    public class QuoteDetail
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("quote")]
        public string Quote { get; set; }

        [JsonProperty("author")]
        public string Author { get; set; }
    }
}
