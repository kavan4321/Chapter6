using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace Chapter6.HttpModel.Page2HttpModel
{

    public class ActivityDetail
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("dueDate")]
        public DateTime DueDate { get; set; }

        [JsonProperty("completed")]
        public bool Completed { get; set; }
    }
}
