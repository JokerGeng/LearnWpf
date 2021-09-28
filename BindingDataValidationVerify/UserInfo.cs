using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BindingDataValidationVerify
{
    public class UserInfo : INotifyPropertyChanged, IDataErrorInfo
    {

        /*
         *  INotifyDataErrorInfo/IDataErrorInfo
         *  允许使用非法值，数据会更新，但会标记出来（红框显示控件）
         */

        /*
        * INotifyDataErrorInfo开关 ValidatesOnNotifyDataErrors=true
        * IDataErrorInfo ValidatesOnDataErrors=true
        */

        private string account;

        [Required]
        [CustomValidation(typeof(ValidationExceptionRules), "CheckAccout")]
        public string Account
        {
            get { return account; }
            set
            {
                account=value;
                OnPropertyChanged(new PropertyChangedEventArgs(nameof(Account)));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, e);
        }

        private string error;


        public string Error
        {
            get => error; 
            set
            {
                error = value;
                OnPropertyChanged(new PropertyChangedEventArgs(nameof(Error)));
            }
        }

        public string this[string columnName]
        { 
            get
            {
                var vc = new ValidationContext(this,null,null);
                vc.MemberName = columnName;
                var rs = new List<ValidationResult>();
                var result = Validator.TryValidateProperty(this.GetType().GetProperty(columnName).GetValue(this, null), vc, rs);
                if(rs.Count>0)
                {
                    return string.Join(Environment.NewLine, rs.Select(r => r.ErrorMessage).ToArray());
                }
                return string.Empty;
            }
        }

    }

    public class ValidationExceptionRules
    { 
        public static ValidationResult CheckAccout(string account)
        {
            bool valid = true;
            foreach (char c in account)
            {
                if (!char.IsLetterOrDigit(c))
                {
                    valid = false;
                    break;
                }
            }
            if(!valid)
            {
                return new ValidationResult("The ModelNumber can only contain letters and numbers.");
            }
            return ValidationResult.Success;
        }
    }
}
