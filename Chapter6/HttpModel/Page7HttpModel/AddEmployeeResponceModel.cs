
using Newtonsoft.Json;

namespace Chapter6.HttpModel.Page7HttpModel
{
    public class AddEmployeeResponceModel
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("createdAt")]
        public DateTime CreatedAt { get; set; }
    }
}
