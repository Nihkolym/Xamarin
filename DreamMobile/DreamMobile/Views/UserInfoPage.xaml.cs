using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DreamMobile.Helpers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DreamMobile.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class UserInfoPage : ContentPage
	{
		public UserInfoPage ()
		{
			InitializeComponent ();
		}

        private void Picker_SelectedIndexChanged(object sender, EventArgs e)
        {
            Settings.Sickness = picker.Items[picker.SelectedIndex];
        }

        private void GenderPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            Settings.Gender = genderPicker.Items[genderPicker.SelectedIndex];
        }
    }
}