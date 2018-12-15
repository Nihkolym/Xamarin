using DreamMobile.ViewModels;
using Plugin.LocalNotifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DreamMobile.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ReminderPage : ContentPage
	{
		public ReminderPage ()
		{
			InitializeComponent ();
		}

        private void Button_Clicked(object sender, EventArgs e)
        {
             CrossLocalNotifications.Current.Show($"HealthyDream Reminds you", $"current temperature have to be " +
                 $"{TipsViewModel.DesiresTemperature} , yourr temperature is {TemperatureViewModel.Temperature}.", 0 , DateTime.Now.AddSeconds(1));
        }
    }
}