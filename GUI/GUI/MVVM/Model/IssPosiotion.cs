using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.MVVM.Model
{
    public class IssPosition
    {
        [JsonProperty("latitude")]
        public Double latitude { get; set; }

        [JsonProperty("longitude")]
        public Double longitude { get; set; }
    }
}
