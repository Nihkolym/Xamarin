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

        public Status Sickness { get; set; }
    }
}
