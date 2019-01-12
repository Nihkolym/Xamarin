using Dream.Views;
using DreamMobile.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using DreamMobile.Helpers;
using System.Reflection;
using DreamMobile.Services;
using DreamMobile.Localization.Resources;
using System.Threading;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace DreamMobile
{
    public partial class App : Application
    {



        public App()
        {
            InitializeComponent();

            SetupLocalization();

            if (Settings.AccessToken != "")
            {
                MainPage = new NavigationPage(new DetailPage());
            }
            else
            {
                MainPage = new NavigationPage(new RegisterPage());
            }
        }

        private static void SetupLocalization()
        {
            System.Diagnostics.Debug.WriteLine("====== resource debug info =========");
            var assembly = typeof(App).GetTypeInfo().Assembly;
            foreach (var res in assembly.GetManifestResourceNames())
                System.Diagnostics.Debug.WriteLine("found resource: " + res);
            System.Diagnostics.Debug.WriteLine("====================================");

            // This lookup NOT required for Windows platforms - the Culture will be automatically set
            if (Device.RuntimePlatform == Device.iOS || Device.RuntimePlatform == Device.Android)
            {
                // determine the correct, supported .NET culture
                var ci = DependencyService.Get<ILocalize>().GetCurrentCultureInfo();
                DreamMobile.Localization.Resources.Resources.Culture = ci; // set the RESX for resource localization
                DependencyService.Get<ILocalize>().SetLocale(ci); // set the Thread for locale-aware methods
            }
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
