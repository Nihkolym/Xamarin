using Dream.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DreamMobile.Helpers;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using DreamMobile.ViewModels;
using System.Threading;
using DreamMobile.Services;

namespace DreamMobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        private ApiServices _apiServices = new ApiServices();


        private string _accessToken = "";

        public LoginPage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegisterPage());
        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            await Login();

            await PushMainPage();

        }

        private async Task PushMainPage()
        {
            if (Settings.AccessToken.Any())
            {
                await Navigation.PushAsync(new DetailPage());
            }
        }

        private async Task Login()
        {
            _accessToken = await _apiServices.LoginAsync(EmailEntry.Text, PasswordEntry.Text);
            Settings.AccessToken = _accessToken;
            if (_accessToken != "")
            {
                Settings.Username = EmailEntry.Text;
                Settings.Password = PasswordEntry.Text;
            }
        }
    }
}