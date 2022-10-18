using System.Text.Json.Serialization;

namespace Property365.Web.Components.Demos.Models.GitHub
{
    public class Label
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("color")]
        public string Color { get; set; }
    }
}