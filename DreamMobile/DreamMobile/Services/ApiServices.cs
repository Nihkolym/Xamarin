using Dream.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using DreamMobile.Services;
using DreamMobile.Models;
using DreamMobile.Helpers;

namespace DreamMobile.Services
{
    public class ApiServices
    {
        internal async Task<bool> RegisterAsynk(string password, string confirmPassword, string email)
        {

            var model = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("email", email),
                new KeyValuePair<string, string>("password", password),
                new KeyValuePair<string, string>("lastName", email),
                new KeyValuePair<string, string>("firstName", email)
            };

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post,
                "http://10.0.2.2:8081/api/v1/users/signup")
            {
                Content = new FormUrlEncodedContent(model)
            };

            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.SendAsync(request);

            return response.IsSuccessStatusCode;
        }

        internal async Task<User> GetMe()
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get,
                "http://10.0.2.2:8081/api/v1/users/me")
            {
                Headers =
                {
                    Authorization = new AuthenticationHeaderValue(Settings.AccessToken)
                }
            };

            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.SendAsync(request).ConfigureAwait(false);

            string user = await response.Content.ReadAsStringAsync();

            User user1 = JsonConvert.DeserializeObject<User>(user, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                MissingMemberHandling = MissingMemberHandling.Ignore
            });

            return user1;
        }

        public async Task<string> LoginAsync(string userName, string password)
        {
            var keyValues = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("email", userName),
                new KeyValuePair<string, string>("password", password),
            };

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post,
                "http://10.0.2.2:8081/api/v1/users/login")
            {
                Content = new FormUrlEncodedContent(keyValues)
            };

            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.SendAsync(request);
            string jwt = await response.Content.ReadAsStringAsync();

            JObject jwtDynamic = JsonConvert.DeserializeObject<dynamic>(jwt, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                MissingMemberHandling = MissingMemberHandling.Ignore
            });

            var accessToken = jwtDynamic.Value<string>("token");

            return accessToken;
        }
    }
}
