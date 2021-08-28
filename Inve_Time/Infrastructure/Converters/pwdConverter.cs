using System;
using System.Globalization;
using System.Windows.Controls;
using System.Windows.Data;

namespace Inve_Time.Infrastructure.Converters
{
    internal class pwdConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            PasswordBox[] pwdBoxes = new PasswordBox[3];
            pwdBoxes[0] = values[0] as PasswordBox;
            pwdBoxes[1] = values[1] as PasswordBox;
            pwdBoxes[2] = values[2] as PasswordBox;
            return pwdBoxes;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
