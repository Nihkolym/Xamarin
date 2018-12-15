using DreamMobile.Services;
using System.Windows.Input;
using Xamarin.Forms;
using DreamMobile.Helpers;
using System.Linq;

namespace DreamMobile.ViewModels
{
    public class LoginViewModel 
    {
        private ApiServices _apiServices = new ApiServices();
        
        public string Username { get; set; }
        
        
        public string Password { get; set; }
        
        public LoginViewModel()
        {
            Username = Settings.Username;
            Password = Settings.Password;
        }
    }
}
