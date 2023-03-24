using Newtonsoft.Json;

namespace Chapter6.HttpModel.Page6HttpModel
{
    public class LoginRequestModel
    {
        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }
    }
}
