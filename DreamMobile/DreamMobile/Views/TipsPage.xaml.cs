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
	public partial class TipsPage : ContentPage
	{
        private string _temperature = TemperatureViewModel.Temperature.ToString();
        private string _humidity = TemperatureViewModel.Humidity.ToString();

        private string _desiresTemperature = TipsViewModel.DesiresTemperature.ToString();
        private string _desiresHumidity = TipsViewModel.DesiresTemperature.ToString();

        EqualChecker equalChecker = new EqualChecker();

        public TipsPage ()
		{
			InitializeComponent ();

            DesiresTemperatureLabel.Text = _desiresTemperature;
            DesiresHumidityLabel.Text = _desiresHumidity;

            equalChecker.CheckIsEqual(_temperature, _desiresTemperature, DesiresTemperatureTextLabel, DesiresTemperatureLabel);
            equalChecker.CheckIsEqual(_humidity, _desiresHumidity, DesiresHumidityTextLabel, DesiresHumidityLabel);
        }
	}
}