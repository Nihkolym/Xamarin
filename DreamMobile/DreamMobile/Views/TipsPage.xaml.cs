using DreamMobile.Infrastructure;
using DreamMobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DreamMobile.Helpers;
using DreamMobile.Services;
using DreamMobile.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DreamMobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TipsPage : ContentPage
    {
        private string _temperature = Settings.Temperature;
        private string _humidity = Settings.Humidity;

        private string _desiresTemperature = Settings.DesiresTemperature;
        private string _desiresHumidity = Settings.DesiresHumidity;

        private RecommandationService _recService = new RecommandationService();

        EqualChecker equalChecker = new EqualChecker();

        public TipsPage()
        {
            InitializeComponent();

            PersonalRecommandation rec = _recService.getMyRec().Result;

            if (rec != null)
            {
                notes.Text = rec.notes;
                pose.Text = rec.pose;
            }

            DesiresTemperatureLabel.Text = _desiresTemperature;
            DesiresHumidityLabel.Text = _desiresHumidity;

            equalChecker.CheckIsEqual(_temperature, _desiresTemperature, DesiresTemperatureTextLabel, DesiresTemperatureLabel);
            equalChecker.CheckIsEqual(_humidity, _desiresHumidity, DesiresHumidityTextLabel, DesiresHumidityLabel);
        }
    }
}