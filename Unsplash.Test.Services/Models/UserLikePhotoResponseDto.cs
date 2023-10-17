using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unsplash.Test.Services.Models
{
    public class ProfileImage
    {
        [JsonProperty("small")]
        public string small { get; set; }

        [JsonProperty("medium")]
        public string medium { get; set; }

        [JsonProperty("large")]
        public string large { get; set; }
    }

    public class UserLikePhotoResponseDto
    {
        [JsonProperty("id")]
        public string id { get; set; }

        [JsonProperty("created_at")]
        public DateTime created_at { get; set; }

        [JsonProperty("updated_at")]
        public DateTime updated_at { get; set; }

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

        [JsonProperty("user")]
        public User user { get; set; }

        [JsonProperty("current_user_collections")]
        public List<CurrentUserCollection> current_user_collections { get; set; }

        [JsonProperty("urls")]
        public Urls urls { get; set; }

        [JsonProperty("links")]
        public Links links { get; set; }
    }

 
}
