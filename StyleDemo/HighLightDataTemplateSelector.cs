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
    class HighLightDataTemplateSelector:DataTemplateSelector
    {
        public DataTemplate Default { get; set; }

        public DataTemplate HighLightTemplate { get; set; }

        /// <summary>
        /// 属性
        /// </summary>
        public string EvaluteProperty { get; set; }

        /// <summary>
        /// 属性值
        /// </summary>
        public string EvalutePropertyValue { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            Type type = item.GetType();
            PropertyInfo propertyInfo = type.GetProperty(EvaluteProperty);
            if (propertyInfo.GetValue(item, null).ToString().Equals(EvalutePropertyValue))
            {
                return HighLightTemplate;
            }
            return Default;
        }
    }
}
