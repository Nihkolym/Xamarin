using System;
using System.Text;
using DreamMobile.Helpers;

namespace DreamMobile.ViewModels
{
    public class TipsViewModel
    {
        

        public int DesiresTemperature { get; set; }

        public int DesiresHumidity { get; set; }

        public string Greeting
        {
            get
            {
                StringBuilder stringBuilder = new StringBuilder(Settings.Username);
                stringBuilder.Append($", We advice you the next parameters according to your sickness ({Settings.Sickness})");
                return stringBuilder.ToString();
            }
        }

        public TipsViewModel()
        {
            Random random = new Random();
            DesiresTemperature = random.Next(15, 25);
            DesiresHumidity = random.Next(30, 60);
        }

    }
}
