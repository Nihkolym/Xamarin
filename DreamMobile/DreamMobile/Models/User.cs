using System;
using System.Collections.Generic;
using System.Text;

namespace DreamMobile.Models
{
    class User
    {
        public int id;
        public string email;
        public string password;
        public int idOfDisease;
        public int idOfPersonalReccomandation;
        public int age;
        public int gender;
        public Disease disease;
        public PersonalRecommandation personalReccomandation;
    }
}
