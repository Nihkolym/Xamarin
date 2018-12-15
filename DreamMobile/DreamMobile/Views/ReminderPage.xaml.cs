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
        private Timer timer;

        public ReminderPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            int period = RemindEntry.Text == null ? 10000 : int.Parse(RemindEntry.Text) * 1000;
            timer = new Timer(Notife, null, 0, period);

        }
        private void Notife(Object obj)
        {
            CrossLocalNotifications.Current.Show($"HealthyDream Reminds you", $"current temperature have to be " +
                  $"{TipsViewModel.DesiresTemperature} , yourr temperature is {TemperatureViewModel.Temperature}.", id: 101);
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            CrossLocalNotifications.Current.Cancel(101);
            timer.Dispose();
        }
    }
}