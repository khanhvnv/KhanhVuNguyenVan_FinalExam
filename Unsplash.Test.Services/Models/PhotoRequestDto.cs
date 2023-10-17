using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unsplash.Test.Services.Models
{
    public class PhotoRequestDto
    {
        [JsonProperty("id")]
        public string id { get; set; }
    }
}
