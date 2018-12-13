using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace DreamMobile.Validators
{
    public class EmailValidationBehavior : Behavior<Entry>
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
            string email = e.NewTextValue;
            string emailPattern = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";
            Entry emailEntry = sender as Entry;

            emailEntry.BackgroundColor = Regex.IsMatch(email, emailPattern) ? Color.Transparent : Color.Red;
        }
    }
}
