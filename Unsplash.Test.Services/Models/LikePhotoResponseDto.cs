using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unsplash.Test.Services.Models
{
  
    public class Photo
    {
        [JsonProperty("id")]
        public string id { get; set; }

        [JsonProperty("width")]
        public int width { get; set; }

        [JsonProperty("height")]
        public int height { get; set; }

        [JsonProperty("color")]
        public string color { get; set; }

        [JsonProperty("blur_hash")]
        public string blur_hash { get; set; }

        [JsonProperty("likes")]
        public int likes { get; set; }

        [JsonProperty("liked_by_user")]
        public bool liked_by_user { get; set; }

        [JsonProperty("description")]
        public string description { get; set; }

        [JsonProperty("urls")]
        public Urls urls { get; set; }

        [JsonProperty("links")]
        public Links links { get; set; }
    }

    public class LikePhotoResponseDto
    {
        [JsonProperty("photo")]
        public Photo photo { get; set; }

        [JsonProperty("user")]
        public User user { get; set; }
    }



  
}
