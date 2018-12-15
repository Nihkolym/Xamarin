using DreamMobile.ViewModels;
using Plugin.LocalNotifications;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Threading;

namespace DreamMobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ReminderPage : ContentPage
    {
        public ReminderPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            int period = RemindEntry == null ? 10000 : int.Parse(RemindEntry.Text) * 1000;
            Timer timer = new Timer(Notife, null, 0, period);

        }
        private void Notife(Object obj)
        {
            CrossLocalNotifications.Current.Show($"HealthyDream Reminds you", $"current temperature have to be " +
                  $"{TipsViewModel.DesiresTemperature} , yourr temperature is {TemperatureViewModel.Temperature}.");

        }
    }
}