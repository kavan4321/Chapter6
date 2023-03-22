using Newtonsoft.Json;
using Refit;

namespace Chapter6.HttpModel.Page4HttpModel
{
    public class CategoryResponceModel
    {
        [JsonProperty("data")]
        public List<string> Catogory { get; set; }
    }
}
