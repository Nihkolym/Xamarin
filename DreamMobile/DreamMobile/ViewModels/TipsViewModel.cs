using System;
using System.Collections.Generic;
using System.Text;
using DreamMobile.Infrastructure;

namespace DreamMobile.ViewModels
{
    public class TipsViewModel
    {
        public Status Sickness { get; set; }

        public int Temperature { get; set; }

        public int Humidity { get; set; }

        public int DesiresTemperature { get; set; }

        public int DesiresHumidity { get; set; }
    }
}
