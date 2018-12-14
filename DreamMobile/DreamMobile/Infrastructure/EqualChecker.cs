using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace DreamMobile.Infrastructure
{
    public class EqualChecker
    {

        public void CheckIsEqual(string actual, string desired, Label text, Label value)
        {
            text.BackgroundColor = desired != actual ? Color.Red : Color.Green;
            value.BackgroundColor = desired != actual ? Color.Red : Color.Green;
        }
    }
}
