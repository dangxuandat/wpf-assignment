using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace WPF_Assignment_Version2.Converter
{
    public class Converter : IValueConverter
    {
        private string GetEnumDesciption(Enum enumObj)
        {
            FieldInfo fieldInfo = enumObj.GetType().GetField(enumObj.ToString());
            object[] attributeArray = fieldInfo.GetCustomAttributes(false);
            if(attributeArray.Length == 0)
            {
                return enumObj.ToString();
            }
            else
            {
                DescriptionAttribute attribute = null;
                foreach (var att in attributeArray)
                {
                    if(att is DescriptionAttribute)
                    {
                        attribute = att as DescriptionAttribute; // cast to DescriptionAttribute
                    }
                }
                if(attribute != null)
                {
                    return attribute.Description;
                }
                return enumObj.ToString();
            }
        }
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Enum myEnum = (Enum) value;
            string description = GetEnumDesciption(myEnum);
            return description;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
