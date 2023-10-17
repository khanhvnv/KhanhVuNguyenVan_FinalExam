using Newtonsoft.Json;
using OpenQA.Selenium.DevTools.V114.DOM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unsplash.Test.Services.Models
{
    public class CurrentUserCollection
    {
        [JsonProperty("id")]
        public int id { get; set; }

        [JsonProperty("title")]
        public string title { get; set; }

        [JsonProperty("published_at")]
        public DateTime published_at { get; set; }

        [JsonProperty("last_collected_at")]
        public DateTime last_collected_at { get; set; }

        [JsonProperty("updated_at")]
        public DateTime updated_at { get; set; }

        [JsonProperty("cover_photo")]
        public object cover_photo { get; set; }

        [JsonProperty("user")]
        public object user { get; set; }
    }

    public class Exif
    {
        [JsonProperty("make")]
        public string make { get; set; }

        [JsonProperty("model")]
        public string model { get; set; }

        [JsonProperty("name")]
        public string name { get; set; }

        [JsonProperty("exposure_time")]
        public string exposure_time { get; set; }

        [JsonProperty("aperture")]
        public string aperture { get; set; }

        [JsonProperty("focal_length")]
        public string focal_length { get; set; }

        [JsonProperty("iso")]
        public int iso { get; set; }
    }

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
    }

    public class Location
    {
        [JsonProperty("city")]
        public string city { get; set; }

        [JsonProperty("country")]
        public string country { get; set; }

        [JsonProperty("position")]
        public Position position { get; set; }
    }

    public class Position
    {
        [JsonProperty("latitude")]
        public double latitude { get; set; }

        [JsonProperty("longitude")]
        public double longitude { get; set; }
    }

    public class PhotoResponseDto
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

        [JsonProperty("downloads")]
        public int downloads { get; set; }

        [JsonProperty("likes")]
        public int likes { get; set; }

        [JsonProperty("liked_by_user")]
        public bool liked_by_user { get; set; }

        [JsonProperty("public_domain")]
        public bool public_domain { get; set; }

        [JsonProperty("description")]
        public string description { get; set; }

        [JsonProperty("exif")]
        public Exif exif { get; set; }

        [JsonProperty("location")]
        public Location location { get; set; }

        [JsonProperty("tags")]
        public List<Tag> tags { get; set; }

        [JsonProperty("current_user_collections")]
        public List<CurrentUserCollection> current_user_collections { get; set; }

        [JsonProperty("urls")]
        public Urls urls { get; set; }

        [JsonProperty("links")]
        public Links links { get; set; }

        [JsonProperty("user")]
        public User user { get; set; }
    }

    public class Tag
    {
        [JsonProperty("title")]
        public string title { get; set; }
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

        [JsonProperty("portfolio_url")]
        public string portfolio_url { get; set; }

        [JsonProperty("bio")]
        public string bio { get; set; }

        [JsonProperty("location")]
        public string location { get; set; }

        [JsonProperty("total_likes")]
        public int total_likes { get; set; }

        [JsonProperty("total_photos")]
        public int total_photos { get; set; }

        [JsonProperty("total_collections")]
        public int total_collections { get; set; }

        [JsonProperty("links")]
        public Links links { get; set; }

        [JsonProperty("instagram_username")]
        public string instagram_username { get; set; }

        [JsonProperty("twitter_username")]
        public string twitter_username { get; set; }

        [JsonProperty("profile_image")]
        public ProfileImage profile_image { get; set; }
    }
}
