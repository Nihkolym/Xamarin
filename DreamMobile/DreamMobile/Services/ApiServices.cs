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

namespace DreamMobile.Services
{
    public class ApiServices
    {
        internal async Task<bool> RegisterAsynk(string password, string confirmPassword, string email)
        {
            var client = new HttpClient();
            var model = new RegisterBindingModel
            {
                Email = email,
                Password = password,
                ConfirmPassword = confirmPassword
            };
            var json = JsonConvert.SerializeObject(model);
            HttpContent content = new StringContent(json);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            HttpResponseMessage response = await client.PostAsync("http://localhost:2273/api/account/register", content);
            
            return response.IsSuccessStatusCode;
        }

        public async Task<string> LoginAsync(string userName, string password)
        {
            var keyValues = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("username", userName),
                new KeyValuePair<string, string>("password", password),
                new KeyValuePair<string, string>("grant_type", "password")
            };

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post,
                "http://localhost:2273/Token")
            {
                Content = new FormUrlEncodedContent(keyValues)
            };

            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.SendAsync(request);
            string jwt = await response.Content.ReadAsStringAsync();

            JObject jwtDynamic = JsonConvert.DeserializeObject<dynamic>(jwt);

            var accessToken = jwtDynamic.Value<string>("access_token");

            return accessToken;
            }
    }
}
