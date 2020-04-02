using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Util.Store;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Authenticators;

namespace ImageGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Test().Wait();
        }

        static async Task Test()
        {
            var clientSecrets = new ClientSecrets
            {
                ClientId = "366202562869-d9k4okbr9vht7rbgc9tug7te5g3hrkfv.apps.googleusercontent.com",
                ClientSecret = "mR39I-3XpKsHGn7MbReW4xSc"
            };
            var credential = await GoogleWebAuthorizationBroker.AuthorizeAsync(
                    clientSecrets,
                    new[] { "https://www.googleapis.com/auth/photoslibrary" },
                    "user",
                    CancellationToken.None
            );
            var accessToken= await credential.GetAccessTokenForRequestAsync();
            var client = new RestClient("https://photoslibrary.googleapis.com");
            client.Authenticator = new JwtAuthenticator(accessToken);
            var request = new RestRequest("/v1/albums", DataFormat.Json);
            var response = client.Get(request);
            var data = JsonConvert.DeserializeObject<AlbumData>(response.Content);
        }
    }
}
