using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace BindingDataValidationVerify
{
    class UserInfoNew : INotifyPropertyChanged
    {
        string account;
        public string Account
        {
            get { return account; }
            set
            {
                account = value;
                OnPropertyChanged(new PropertyChangedEventArgs(nameof(Account)));
            }
        }
        public void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, e);
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }

    public class AccountValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            bool valid = true;
            foreach (char c in value.ToString())
            {
                if (!char.IsLetterOrDigit(c))
                {
                    valid = false;
                    break;
                }
            }
            if (!valid)
            {
                return new ValidationResult(valid, "The ModelNumber can only contain letters and numbers in new userinfo.");
            }
            return ValidationResult.ValidResult;
        }
    }
}
