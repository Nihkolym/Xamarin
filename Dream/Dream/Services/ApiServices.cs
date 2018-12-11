using DreamMobile.Models;
using Newtonsoft.Json;
using ObjCRuntime;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace DreamMobile.Services
{
    public class ApiServices
    {
        internal async Task<bool> RegisterAsynk(string email, string password, string confirmPassword)
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

            HttpResponseMessage response = await client.PostAsync("http://192.168.0.106:45455/api/account/register", content);


            return response.IsSuccessStatusCode;
        }
    }
}
