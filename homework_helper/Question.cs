using System;
using Newtonsoft.Json;

namespace homework_helper
{
    class Question
    {
        public string Id { get; set; }

        [JsonProperty(PropertyName = "text")]
        public string Text { get; set; }

        [JsonProperty(PropertyName = "point")]
        public float Point { get; set; }

        [JsonProperty(PropertyName = "complete")]
        public bool Complete { get; set; }
    }
}