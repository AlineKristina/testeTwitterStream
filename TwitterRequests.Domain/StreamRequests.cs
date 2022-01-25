using System.Threading.Tasks;
using RestSharp;
using Newtonsoft.Json;
using System.Text;

namespace TwitterRequests.Domain
{
    public class StreamRequests
    {
        private readonly string _token;


        public StreamRequests(string token)
        {
            _token = token;
        }

        public async Task<RestResponse> Get()
        {
            var uri = "https://api.twitter.com/2/tweets/search/recent?query=cat%20has%3Amedia%20-grumpy&max_results=10";
            var request = new RestClient();
            var addHeader = request.AddDefaultHeader("Authorization", $"Bearer {_token}");
            var response = await addHeader.GetAsync(new RestRequest(uri));
            return response;
        }

    }
}