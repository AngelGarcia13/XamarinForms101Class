using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace PrismSeries.Models
{
    public class Genre
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
