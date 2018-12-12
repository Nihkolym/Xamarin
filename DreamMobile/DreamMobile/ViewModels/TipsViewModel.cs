using System;
using System.Collections.Generic;
using System.Text;
using DreamMobile.Infrastructure;
using DreamMobile.Helpers;

namespace DreamMobile.ViewModels
{
    public class TipsViewModel
    {
        public Status Sickness { get; set; }

        public int Temperature { get; set; }

        public int Humidity { get; set; }

        public int DesiresTemperature { get; set; }

        public int DesiresHumidity { get; set; }

        public string Greeting
        {
            get
            {
                StringBuilder stringBuilder = new StringBuilder(Settings.Username);
                stringBuilder.Append($", We advice you the next parameters with your sickness ({Settings.Sickness})");
                return stringBuilder.ToString();
            }
        }
    }
}
