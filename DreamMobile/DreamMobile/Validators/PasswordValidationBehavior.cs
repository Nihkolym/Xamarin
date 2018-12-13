using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace DreamMobile.Validators
{
    public class PasswordValidationBehavior : Behavior<Entry>
    {
        protected override void OnAttachedTo(Entry bindable)
        {
            base.OnAttachedTo(bindable);

            bindable.TextChanged += Bindable_TextChanged;
        }

        protected override void OnDetachingFrom(Entry bindable)
        {
            base.OnDetachingFrom(bindable);

            bindable.TextChanged -= Bindable_TextChanged; 
        }

        private void Bindable_TextChanged(object sender, TextChangedEventArgs e)
        {
            string password = e.NewTextValue;
            Entry emailEntry = sender as Entry;

            emailEntry.BackgroundColor = password.Length>=6 ? Color.Transparent : Color.Red;
        }
    }
}
