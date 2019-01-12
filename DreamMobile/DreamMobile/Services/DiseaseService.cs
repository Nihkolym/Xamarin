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
    class DiseaseService
    {
        internal async Task<Disease[]> getAllDiseases()
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get,
                "http://10.0.2.2:8081/api/v1/diseases");

            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.SendAsync(request).ConfigureAwait(false);

            string diseases = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<Disease[]>(diseases, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                MissingMemberHandling = MissingMemberHandling.Ignore
            });
        }
    }
}
