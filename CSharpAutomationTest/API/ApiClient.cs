using RestSharp;
using RestSharp.Authenticators;
using RestSharp.Authenticators.OAuth2;
using RestSharp.Serializers.NewtonsoftJson;


namespace CSharpAutomationFramework.Core.API
{
    public class APIClient
    {
        private readonly RestClient _client;
        public RestRequest Request;
        public RestResponse Response;
        private RestClientOptions requestOption;

        public APIClient()
        {
            _client = new RestClient();
            Request = new RestRequest();
        }
        public APIClient(RestClient client)
        {
            _client = client;
            Request = new RestRequest();
        }
        public APIClient(string url)
        {
            var options = new RestClientOptions(url);
            _client = new RestClient(options, configureSerialization: s => s.UseNewtonsoftJson());
            Request = new RestRequest();
        }

        public APIClient(RestClientOptions options)
        {
            _client = new RestClient(options, configureSerialization: s => s.UseNewtonsoftJson());
            Request = new RestRequest();
        }
        public APIClient SetBasicAuthentication(string username, string password)
        {
            requestOption.Authenticator = new HttpBasicAuthenticator(username, password);
            return new APIClient(requestOption);
        }
        public APIClient SetRequestTokenAuthentication(string consumerKey, string consumerSecret)
        {
            requestOption.Authenticator = OAuth1Authenticator.ForRequestToken(consumerKey, consumerSecret); 
            return new APIClient(requestOption);
        }
        public APIClient SetAccessTokenAuthentication(string consumerKey, string consumerSecret, string authToken, string authTokenSecret)
        {
            requestOption.Authenticator = OAuth1Authenticator.ForAccessToken(
                consumerKey, consumerSecret,authToken,authTokenSecret);
            return new APIClient(requestOption);
        }
        public APIClient SetRequestHeaderAuthentication(string token, string authType = "Bearer")
        {
            requestOption.Authenticator = new OAuth2AuthorizationRequestHeaderAuthenticator(token,authType);
            return new APIClient(requestOption);
        }
        public APIClient SetJwtAuthenticator(string token)
        {
            requestOption.Authenticator = new JwtAuthenticator(token);
            return new APIClient(requestOption);
        }
        public APIClient ClearAuthenticator(string token)
        {
            requestOption.Authenticator = null;
            return new APIClient(requestOption);
        }
        public APIClient AddDefaultHeader(Dictionary<string,string> headers)
        {
            _client.AddDefaultHeaders(headers);
            return this;
        }
        public APIClient CreateRequest(string source = "")
        {
            Request = new RestRequest(source);  
            return this;
        }
        public APIClient AddHeader(string name,string value)
        {
            Request.AddHeader(name,value);
            return this;
        }
        public APIClient AddAuthorizationHeader(string value)
        {
            Request.AddHeader("Authorization", value);
            return this;
        }
        public APIClient AddParameter(string name, string value)
        {
            Request.AddParameter(name, value);
            return this;
        }
        public APIClient AddBody(object obj, string contentType = null)
        {
            Request.AddBody(obj);
            /*
            string json = JsonConvert.SerializeObject(obj);
            Request.AddStringBody(json,contentType??ContentType.Json);
            */
            return this;
        }
        public async Task<RestResponse> ExecuteGetAsync()
        {
            return await _client.ExecuteGetAsync(Request);
        }
        public async Task<RestResponse<T>> ExecuteGetAsync<T>()
        {
            return await _client.ExecuteGetAsync<T>(Request);
        }
        public async Task<RestResponse> ExecutePostAsync()
        {
            return await _client.ExecutePostAsync(Request);
        }
        public async Task<RestResponse<T>> ExecutePostAsync<T>()
        {
            return await _client.ExecutePostAsync<T>(Request);
        }
        public async Task<RestResponse> ExecuteDeleteAsync()
        {
            Request.Method = Method.Delete;
            return await _client.ExecuteAsync(Request);
        }
        public async Task<RestResponse> ExecutePutAsync()
        {
            return await _client.ExecutePutAsync(Request);
        }
        public async Task<RestResponse<T>> ExecutePutAsync<T>()
        {
            return await _client.ExecutePutAsync<T>(Request);
        }
    }
}


