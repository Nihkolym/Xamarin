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
    class RecommandationService
    {
        internal async Task<PersonalRecommandation> getMyRec()
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get,
                "http://10.0.2.2:8081/api/v1/users/myRec")
            {
                Headers =
                {
                    Authorization = new AuthenticationHeaderValue(Settings.AccessToken)
                }
            };

            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.SendAsync(request).ConfigureAwait(false);

            string rec = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<PersonalRecommandation>(rec, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                MissingMemberHandling = MissingMemberHandling.Ignore
            });
        }
    }
}
