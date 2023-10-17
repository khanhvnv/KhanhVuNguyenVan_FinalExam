using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unsplash.Test.Services.Models
{
    public class CollectionResponseDto
    {
        [JsonProperty("id")]
        public string id { get; set; }

        [JsonProperty("title")]
        public string title { get; set; }

        [JsonProperty("description")]
        public string description { get; set; }

        [JsonProperty("published_at")]
        public DateTime published_at { get; set; }

        [JsonProperty("last_collected_at")]
        public object last_collected_at { get; set; }

        [JsonProperty("updated_at")]
        public DateTime updated_at { get; set; }

        [JsonProperty("featured")]
        public bool featured { get; set; }

        [JsonProperty("total_photos")]
        public int total_photos { get; set; }

        [JsonProperty("private")]
        public bool @private { get; set; }

        [JsonProperty("share_key")]
        public string share_key { get; set; }

        [JsonProperty("tags")]
        public List<object> tags { get; set; }

        [JsonProperty("links")]
        public Links links { get; set; }

        [JsonProperty("user")]
        public User user { get; set; }

        [JsonProperty("cover_photo")]
        public object cover_photo { get; set; }

        [JsonProperty("preview_photos")]
        public object preview_photos { get; set; }
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
        public class Links
        {
            [JsonProperty("self")]
            public string self { get; set; }

            [JsonProperty("html")]
            public string html { get; set; }

            [JsonProperty("photos")]
            public string photos { get; set; }

            [JsonProperty("related")]
            public string related { get; set; }

            [JsonProperty("likes")]
            public string likes { get; set; }

            [JsonProperty("portfolio")]
            public string portfolio { get; set; }

            [JsonProperty("following")]
            public string following { get; set; }

            [JsonProperty("followers")]
            public string followers { get; set; }
        }

        public class ProfileImage
        {
            [JsonProperty("small")]
            public string small { get; set; }

            [JsonProperty("medium")]
            public string medium { get; set; }

            [JsonProperty("large")]
            public string large { get; set; }
        }

        public class Social
        {
            [JsonProperty("instagram_username")]
            public object instagram_username { get; set; }

            [JsonProperty("portfolio_url")]
            public object portfolio_url { get; set; }

            [JsonProperty("twitter_username")]
            public object twitter_username { get; set; }

            [JsonProperty("paypal_email")]
            public object paypal_email { get; set; }
        }

        public class User
        {
            [JsonProperty("id")]
            public string id { get; set; }

            [JsonProperty("updated_at")]
            public DateTime updated_at { get; set; }

            [JsonProperty("username")]
            public string username { get; set; }

            [JsonProperty("name")]
            public string name { get; set; }

            [JsonProperty("first_name")]
            public string first_name { get; set; }

            [JsonProperty("last_name")]
            public string last_name { get; set; }

            [JsonProperty("twitter_username")]
            public object twitter_username { get; set; }

            [JsonProperty("portfolio_url")]
            public object portfolio_url { get; set; }

            [JsonProperty("bio")]
            public object bio { get; set; }

            [JsonProperty("location")]
            public object location { get; set; }

            [JsonProperty("links")]
            public Links links { get; set; }

            [JsonProperty("profile_image")]
            public ProfileImage profile_image { get; set; }

            [JsonProperty("instagram_username")]
            public object instagram_username { get; set; }

            [JsonProperty("total_collections")]
            public int total_collections { get; set; }

            [JsonProperty("total_likes")]
            public int total_likes { get; set; }

            [JsonProperty("total_photos")]
            public int total_photos { get; set; }

            [JsonProperty("accepted_tos")]
            public bool accepted_tos { get; set; }

            [JsonProperty("for_hire")]
            public bool for_hire { get; set; }

            [JsonProperty("social")]
            public Social social { get; set; }
        }


    }
}
