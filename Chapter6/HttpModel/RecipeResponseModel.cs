using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace Chapter6.HttpModel
{
    public class RecipeResponseModel
    {
        [JsonProperty("recipes")]
        public ObservableCollection<RecipeDetail> RecipeDetails { get; set; }
    }

    public class RecipeDetail
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
        public ImageSource ImageUrl { get; set; }
    }
}