using DreamMobile.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DreamMobile.Helpers;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Dream.ViewModels;
using DreamMobile.Services;

namespace Dream.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class RegisterPage : ContentPage
	{
        private ApiServices _apiServices = new ApiServices();

        public RegisterPage ()
		{
			InitializeComponent ();
		}
        

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LoginPage());
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Register();
            ValidateRegistrationError();
        }

        private async Task Register()
        {
            bool isSuccess = await _apiServices.RegisterAsynk(Password.Text, ConfirmPassword.Text, EmailEntry.Text);
            if (isSuccess)
            {
                Settings.Username = EmailEntry.Text;
                Settings.Password = Password.Text;
            }
        }

        private void ValidateRegistrationError()
        {
            ErrorLable.Text = Settings.Username == "" && Settings.Password == "" ? "something went wrong" : "Yes, indeed!";
            ErrorLable.Text = Password.Text != ConfirmPassword.Text ? "Passwords do not match" : ErrorLable.Text;
            if (ErrorLable.Text == "Yes, indeed!")
            {
                ErrorLable.TextColor = Color.Green;
            }
        }
    }
}