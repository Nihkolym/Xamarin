using System;
using System.Text;
using DreamMobile.Helpers;

namespace DreamMobile.ViewModels
{
    public class TipsViewModel
    {
        public static int DesiresTemperature { get => 31; set { } }

        public static int DesiresHumidity  { get => 33; set { } }

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
        }

    }
}
