using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BindingDataValidationVerify
{
    public class Product : INotifyPropertyChanged, INotifyDataErrorInfo
    {
        /*
         *  INotifyDataErrorInfo/IDataErrorInfo
         *  允许使用非法值，数据会更新，但会标记出来（红框显示控件）
         */


        /*
         * INotifyDataErrorInfo开关 ValidatesOnNotifyDataErrors=true
         * IDataErrorInfo ValidatesOnDataErrors=true
         */

        private Dictionary<string, List<string>> errors = new Dictionary<string, List<string>>();
        public bool HasErrors => errors.Count > 0;

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, e);
        }

        public IEnumerable GetErrors(string propertyName)
        {
            if (string.IsNullOrEmpty(propertyName))
            {
                return errors.Values;
            }
            else
            {
                if (errors.ContainsKey(propertyName))
                {
                    return errors[propertyName];
                }
                return null;
            }
        }

        private void SetErrors(string propertyName, List<string> propertyErrors)
        {
            errors.Remove(propertyName);
            errors.Add(propertyName, propertyErrors);
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
        }

        private void ClearErrors(string propertyName)
        {
            errors.Remove(propertyName);
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
        }

        private string modelNumber;
        public string ModelNumber
        {
            get { return modelNumber; }
            set
            {
                modelNumber = value;
                bool valid = true;
                foreach (char c in modelNumber)
                {
                    if (!char.IsLetterOrDigit(c))
                    {
                        valid = false;
                        break;
                    }
                }
                if (!valid)
                {
                    List<string> errors = new List<string>();
                    errors.Add("The ModelNumber can only contain letters and numbers.");
                    SetErrors(nameof(ModelNumber), errors);
                }
                else
                {
                    ClearErrors(nameof(ModelNumber));
                }
                OnPropertyChanged(new PropertyChangedEventArgs("ModelNumber"));
            }
        }
    }
}
