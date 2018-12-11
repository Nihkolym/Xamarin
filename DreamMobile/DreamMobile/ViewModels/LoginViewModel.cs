using DreamMobile.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using DreamMobile.Helpers;

namespace DreamMobile.ViewModels
{
    public class LoginViewModel
    {
        private ApiServices _apiServices = new ApiServices();

        public string Username { get; set; }

        public string Password { get; set; }

        public ICommand LoginCommand
        {
            get
            {
                return new Command(async () =>
                {
                    var acessToken = await _apiServices.LoginAsync(Username, Password);
                    Settings.AccessToken = acessToken;

                });
            }
        }

        public LoginViewModel()
        {
            Username = Settings.Username;
            Password = Settings.Password;
        }
    }
}
