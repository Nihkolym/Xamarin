using System;
using System.Collections.Generic;
using System.Text;
using Dream.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using HealthyDream.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using DreamMobile.Models;

namespace DreamMobile.Services
{
    class TipsService
    {
        internal async Task<PersonalRecommandation> UpdateUser(User user)
        {
            var model = new List<KeyValuePair<string, string>>();

            if (user.gender != 0)
            {
                model.Add(new KeyValuePair<string, string>("gender", user.gender.ToString()));
            }

            if (user.idOfDisease != 0)
            {
                model.Add(new KeyValuePair<string, string>("idOfDisease", user.idOfDisease.ToString()));
            }

            if (user.age != 0)
            {
                model.Add(new KeyValuePair<string, string>("age", user.age.ToString()));
            }

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Put,
                "http://10.0.2.2:8081/api/v1/users/" + user.id)
            {
                Content = new FormUrlEncodedContent(model),
            };

            request.Headers.Add("Accept", "application /json");

            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.SendAsync(request);

            string rec = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<PersonalRecommandation>(rec, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                MissingMemberHandling = MissingMemberHandling.Ignore
            });
        }
    }
}
