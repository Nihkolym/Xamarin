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

        private static string _accessToken = "";
        
        public string Password { get; set; }
        
        public ICommand LoginCommand =>
            new Command(async () =>
            {
                _accessToken = await _apiServices.LoginAsync(Username, Password);
                Settings.AccessToken = _accessToken;
                if(_accessToken != "")
                {
                    Settings.Username = Username;
                    Settings.Password = Password;
                }

            });

        public LoginViewModel()
        {
            Username = Settings.Username;
            Password = Settings.Password;
        }
    }
}
