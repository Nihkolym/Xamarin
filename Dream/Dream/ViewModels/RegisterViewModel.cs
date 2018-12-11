using DreamMobile.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace DreamMobile.ViewModels
{
    public class RegisterViewModel
    {
        ApiServices apiServices = new ApiServices();

        public string Email { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }

        public string Message { get; set; }

        public Command RegisterCommand
        {
            get
            {
                return new Command(async() =>
                {
                    await apiServices.RegisterAsynk(Email, Password, ConfirmPassword);
                    
                });
            }
        }
    }
}
