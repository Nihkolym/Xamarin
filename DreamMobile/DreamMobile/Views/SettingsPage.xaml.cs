using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.Multilingual;
using Xamarin.Forms;
using DreamMobile;
using Xamarin.Forms.Xaml;
using System.Resources;
using System.Globalization;

namespace DreamMobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingsPage : ContentPage
    {
        public SettingsPage()
        {
            InitializeComponent();
            languagePicker.SelectedItem = CrossMultilingual.Current.CurrentCultureInfo.EnglishName;
        }

        private void LanguagePicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            CrossMultilingual.Current.CurrentCultureInfo = CrossMultilingual.Current.NeutralCultureInfoList.ToList().First(element => element.EnglishName.Contains(languagePicker.SelectedItem.ToString()));
        }
    }
}