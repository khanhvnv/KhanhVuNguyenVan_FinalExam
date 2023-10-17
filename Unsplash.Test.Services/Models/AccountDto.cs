using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unsplash.Test.Services.Models
{
    public class AccountDto
    {
        [JsonProperty("username")]
        public string username { get; set; }

        [JsonProperty("email")]
        public string email { get; set; }

        [JsonProperty("password")]
        public string password { get; set; }

        [JsonProperty("id")]
        public string id { get; set; }

        [JsonProperty("tokenId")]
        public string tokenId { get; set; }

        [JsonProperty("first_name")]
        public string first_name { get; set; }

        [JsonProperty("name")]
        public string name { get; set; }
        
        [JsonProperty("last_name")]
        public string last_name { get; set; }
    }
}
