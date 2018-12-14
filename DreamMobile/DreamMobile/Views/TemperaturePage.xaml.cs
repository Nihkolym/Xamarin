using DreamMobile.Infrastructure;
using DreamMobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DreamMobile.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TemperaturePage : ContentPage
    {
        private string _temperature = TemperatureViewModel.Temperature.ToString();
        private string _humidity = TemperatureViewModel.Humidity.ToString();

        private string _desiresTemperature = TipsViewModel.DesiresTemperature.ToString();
        private string _desiresHumidity = TipsViewModel.DesiresTemperature.ToString();

        EqualChecker equalChecker = new EqualChecker(); 

        public TemperaturePage ()
        { 
			InitializeComponent ();

            TemperatureLabel.Text = _temperature;
            HumidityLabel.Text = _humidity;

            equalChecker.CheckIsEqual(_temperature, _desiresTemperature, TemperatureTextLabel, TemperatureLabel);
            equalChecker.CheckIsEqual(_humidity, _desiresHumidity, HumidityTextLabel, HumidityLabel);
        }
	}
}