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

namespace Dream.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class RegisterPage : ContentPage
	{
		public RegisterPage ()
		{
			InitializeComponent ();
		}
        

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LoginPage());
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            ErrorLable.Text = Settings.Username == "" && Settings.Password == "" ? "something went wrong" : "Yes, indeed!";
            ErrorLable.Text = Password.Text != ConfirmPassword.Text ? "Passwords do not match" : ErrorLable.Text;
            if(ErrorLable.Text == "Yes, indeed!")
            {
                ErrorLable.TextColor = Color.Green;
            }
        }
    }
}