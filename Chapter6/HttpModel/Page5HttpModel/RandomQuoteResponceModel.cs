using Newtonsoft.Json;

namespace Chapter6.HttpModel.Page5HttpModel
{
    public class RandomQuoteResponceModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("quote")]
        public string Quote { get; set; }

        [JsonProperty("author")]
        public string Author { get; set; }
    }
}
