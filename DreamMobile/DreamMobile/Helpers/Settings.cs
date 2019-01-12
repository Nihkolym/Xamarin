using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace DreamMobile.Helpers
{
    /// <summary>
    /// This is the Settings static class that can be used in your Core solution or in any
    /// of your client applications. All settings are laid out the same exact way with getters
    /// and setters. 
    /// </summary>
    public static class Settings
    {
        private static ISettings AppSettings
        {
            get
            {
                return CrossSettings.Current;
            }
        }
        public static string Username
        {
            get
            {
                return AppSettings.GetValueOrDefault("Username","");
            }
            set
            {
                AppSettings.AddOrUpdateValue("Username", value);
            }
        }
        public static string Password
        {
            get
            {
                return AppSettings.GetValueOrDefault("Password", "");
            }
            set
            {
                AppSettings.AddOrUpdateValue("Password", value);
            }
        }
        public static string AccessToken
        {
            get
            {
                return AppSettings.GetValueOrDefault("AccessToken", "");
            }
            set
            {
                AppSettings.AddOrUpdateValue("AccessToken", value);
            }
        }
        public static string Sickness
        {
            get
            {
                return AppSettings.GetValueOrDefault("Sickness", "Healthy");
            }
            set
            {
                AppSettings.AddOrUpdateValue("Sickness", value);
            }
        }
        public static string Gender
        {
            get
            {
                return AppSettings.GetValueOrDefault("Gender", "Male");
            }
            set
            {
                AppSettings.AddOrUpdateValue("Gender", value);
            }
        }

        public static string Temperature
        {
            get
            {
                return AppSettings.GetValueOrDefault("Temperature", "22");
            }
            set
            {
                AppSettings.AddOrUpdateValue("Temperature", value);
            }
        }

        public static string Humidity
        {
            get
            {
                return AppSettings.GetValueOrDefault("Humidity", "50");
            }
            set
            {
                AppSettings.AddOrUpdateValue("Humidity", value);
            }
        }

        public static string DesiresTemperature
        {
            get
            {
                return AppSettings.GetValueOrDefault("DesiresTemperature", "22");
            }
            set
            {
                AppSettings.AddOrUpdateValue("DesiresTemperature", value);
            }
        }

        public static string DesiresHumidity
        {
            get
            {
                return AppSettings.GetValueOrDefault("DesiresHumidity", "50");
            }
            set
            {
                AppSettings.AddOrUpdateValue("DesiresHumidity", value);
            }
        }

    }
}
