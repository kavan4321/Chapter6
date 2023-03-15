
using Newtonsoft.Json;

namespace Chapter6.Model.HttpModel
{
    public class RecipeResponseModel
    {
        public string Status { get; set; }

        [JsonProperty("recipes")]
        public List<RecipeDetails> RecipeDetails { get; set; }

    }
    public class RecipeDetails
    {
        [JsonProperty("id")]
        public long Id { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("time_to_prepare")]
        public string TimeToPrepare { get; set; }

        [JsonProperty("image_url")]
        public string ImageUrl { get; set; }
    }
}