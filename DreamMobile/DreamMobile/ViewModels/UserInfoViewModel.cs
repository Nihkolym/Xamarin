using System;
using System.Collections.Generic;
using System.Text;
using DreamMobile.Helpers;
using DreamMobile.Infrastructure;

namespace DreamMobile.ViewModels
{
    public class UserInfoViewModel
    {
        public string Username => Settings.Username;

        public string Gender => $"Your Gender ({Settings.Gender})";

        public string Sickness => $"Your Sickness  ({Settings.Sickness})";
        
    }
}
