using DreamMobile.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using DreamMobile.Helpers;

namespace Dream.ViewModels
{
    public class RegisterViewModel
    {
        ApiServices apiServices = new ApiServices();
        
        public string Username { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public string ConfirmPassword { get; set; }
        

        public Command RegisterCommand
        {
            get
            {
                return new Command(async() =>
                {
                bool isSuccess = await apiServices.RegisterAsynk(Password, ConfirmPassword, Email);
                    if (isSuccess)
                    {
                        Username = Email;
                        Settings.Username = Username;
                        Settings.Password = Password;
                    }
                    
                });
            }
        }
    }
}
