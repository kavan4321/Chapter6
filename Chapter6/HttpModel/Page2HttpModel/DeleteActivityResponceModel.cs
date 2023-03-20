
using Newtonsoft.Json;

namespace Chapter6.HttpModel.Page2HttpModel
{
    public class DeleteActivityResponceModel
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
