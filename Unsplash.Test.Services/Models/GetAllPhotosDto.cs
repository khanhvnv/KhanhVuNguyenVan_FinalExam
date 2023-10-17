using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unsplash.Test.Services.Models
{
    public class GetAllPhotosDto
    {
        [JsonProperty("id")]
        public string id { get; set; }

        [JsonProperty("slug")]
        public string slug { get; set; }

        [JsonProperty("created_at")]
        public DateTime created_at { get; set; }

        [JsonProperty("updated_at")]
        public DateTime updated_at { get; set; }

        [JsonProperty("promoted_at")]
        public object promoted_at { get; set; }

        [JsonProperty("width")]
        public int width { get; set; }

        [JsonProperty("height")]
        public int height { get; set; }

        [JsonProperty("color")]
        public string color { get; set; }

        [JsonProperty("blur_hash")]
        public string blur_hash { get; set; }

        [JsonProperty("description")]
        public string description { get; set; }

        [JsonProperty("alt_description")]
        public string alt_description { get; set; }

        [JsonProperty("breadcrumbs")]
        public List<object> breadcrumbs { get; set; }

        [JsonProperty("urls")]
        public Urls urls { get; set; }

        [JsonProperty("links")]
        public Links links { get; set; }

        [JsonProperty("likes")]
        public int likes { get; set; }

        [JsonProperty("liked_by_user")]
        public bool liked_by_user { get; set; }

        [JsonProperty("current_user_collections")]
        public List<object> current_user_collections { get; set; }

        [JsonProperty("sponsorship")]
        public Sponsorship sponsorship { get; set; }

        [JsonProperty("topic_submissions")]
        public TopicSubmissions topic_submissions { get; set; }

        [JsonProperty("user")]
        public User user { get; set; }

        public class Links
        {
            [JsonProperty("self")]
            public string self { get; set; }

            [JsonProperty("html")]
            public string html { get; set; }

            [JsonProperty("download")]
            public string download { get; set; }

            [JsonProperty("download_location")]
            public string download_location { get; set; }

            [JsonProperty("photos")]
            public string photos { get; set; }

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
            public string instagram_username { get; set; }

            [JsonProperty("portfolio_url")]
            public string portfolio_url { get; set; }

            [JsonProperty("twitter_username")]
            public string twitter_username { get; set; }

            [JsonProperty("paypal_email")]
            public object paypal_email { get; set; }
        }

        public class Sponsor
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
            public object last_name { get; set; }

            [JsonProperty("twitter_username")]
            public string twitter_username { get; set; }

            [JsonProperty("portfolio_url")]
            public string portfolio_url { get; set; }

            [JsonProperty("bio")]
            public string bio { get; set; }

            [JsonProperty("location")]
            public string location { get; set; }

            [JsonProperty("links")]
            public Links links { get; set; }

            [JsonProperty("profile_image")]
            public ProfileImage profile_image { get; set; }

            [JsonProperty("instagram_username")]
            public string instagram_username { get; set; }

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

        public class Sponsorship
        {
            [JsonProperty("impression_urls")]
            public List<string> impression_urls { get; set; }

            [JsonProperty("tagline")]
            public string tagline { get; set; }

            [JsonProperty("tagline_url")]
            public string tagline_url { get; set; }

            [JsonProperty("sponsor")]
            public Sponsor sponsor { get; set; }
        }

        public class TopicSubmissions
        {
        }

        public class Urls
        {
            [JsonProperty("raw")]
            public string raw { get; set; }

            [JsonProperty("full")]
            public string full { get; set; }

            [JsonProperty("regular")]
            public string regular { get; set; }

            [JsonProperty("small")]
            public string small { get; set; }

            [JsonProperty("thumb")]
            public string thumb { get; set; }

            [JsonProperty("small_s3")]
            public string small_s3 { get; set; }
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
            public object last_name { get; set; }

            [JsonProperty("twitter_username")]
            public string twitter_username { get; set; }

            [JsonProperty("portfolio_url")]
            public string portfolio_url { get; set; }

            [JsonProperty("bio")]
            public string bio { get; set; }

            [JsonProperty("location")]
            public string location { get; set; }

            [JsonProperty("links")]
            public Links links { get; set; }

            [JsonProperty("profile_image")]
            public ProfileImage profile_image { get; set; }

            [JsonProperty("instagram_username")]
            public string instagram_username { get; set; }

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
