
using Newtonsoft.Json;

namespace Chapter6.HttpModel.Page7HttpModel
{
    public class UpdateEmployeeResponceModel
    {
        [JsonProperty("updatedAt")]
        public DateTime UpdatedAt { get; set; }
    }
}
