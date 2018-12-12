using System;
using System.Collections.Generic;
using System.Text;

namespace DreamMobile.ViewModels
{
    public class TemperatureViewModel
    {
        public int Temperature { get; set; }

        public int Humidity { get; set; }

        public TemperatureViewModel()
        {
            Random random = new Random();
            Temperature = random.Next(15, 25);
            Humidity = random.Next(30, 60);
        }
    }
}
