using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DreamMobile.Helpers;
using DreamMobile.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using DreamMobile.Services;

namespace DreamMobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserInfoPage : ContentPage
    {
        private TipsService _tipsService = new TipsService();
        private ApiServices _apiServices = new ApiServices();
        private RecommandationService _recommandation = new RecommandationService();
        private DiseaseService _diseaseService = new DiseaseService();

        private User user;

        public UserInfoPage()
        {
            InitializeComponent();

            user = _apiServices.GetMe().Result;

            email.Text = user.email;

            if(user.gender != 0) 
                genderPicker.SelectedItem = genderPicker.Items[user.gender - 1];

            agePicker.Text = user.age.ToString();

            Disease[] dis = _diseaseService.getAllDiseases().Result;

            for (int i = 0; i < dis.Length; i++)
            {
                picker.Items.Add(dis[i].name);
            }

            if (user.idOfDisease != 0)
                picker.SelectedItem = picker.Items[user.idOfDisease - 1];

        }

        private async void Picker_SelectedIndexChanged(object sender, EventArgs e)
        {
            Settings.Sickness = picker.Items[picker.SelectedIndex];

            user.idOfDisease = picker.SelectedIndex + 1;

            await _tipsService.UpdateUser(user);

            setData(await _recommandation.getMyRec());

        }

        private async void GenderPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            Settings.Gender = genderPicker.Items[genderPicker.SelectedIndex];

            user.gender = genderPicker.SelectedIndex + 1;

            await _tipsService.UpdateUser(user);

            setData(await _recommandation.getMyRec());
        }

        private async void Age_FocusChangeRequested(object sender, EventArgs e)
        {
            user.age = Convert.ToInt32(agePicker.Text);

            await _tipsService.UpdateUser(user);

            setData(await _recommandation.getMyRec());
        }

        private void setData(PersonalRecommandation pr)
        {
            Settings.DesiresTemperature = pr.temperature.ToString();
            Settings.DesiresHumidity = pr.humidity.ToString();
        }
    }
}