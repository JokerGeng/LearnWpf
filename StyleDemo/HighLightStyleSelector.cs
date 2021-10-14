using StoreDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace StyleDemo
{
    class HighLightStyleSelector:StyleSelector
    {
        public Style Default { get; set; }

        public Style HighLightStyle { get; set; }

        public string EvaluteProperty { get; set; }

        public string EvalutePropertyValue { get; set; }

        public override Style SelectStyle(object item, DependencyObject container)
        {
            //Product product = (Product)item;
            Type type = item.GetType();
            PropertyInfo propertyInfo = type.GetProperty(EvaluteProperty);
            if(propertyInfo.GetValue(item,null).ToString().Equals(EvalutePropertyValue))
            {
                return HighLightStyle;
            }
            return Default;
        }
    }
}
