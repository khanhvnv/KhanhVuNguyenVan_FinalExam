using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unsplash.Test.Services.Models
{
    public class PhotoCollectionRequestDto
    {
        [JsonProperty("collection_id")]
        public string collection_id { get; set; }

        [JsonProperty("photo_id")]
        public string photo_id { get; set; }
    }
}
