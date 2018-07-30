using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace PrismSeries.Models
{
    public class Images
    {
        [JsonProperty("poster")]
        public string Poster { get; set; }

        [JsonProperty("fanart")]
        public string Fanart { get; set; }

        [JsonProperty("banner")]
        public string Banner { get; set; }
    }
}
