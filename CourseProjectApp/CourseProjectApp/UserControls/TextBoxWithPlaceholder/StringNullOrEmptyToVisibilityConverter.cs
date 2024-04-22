using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows;

namespace CourseProjectApp.UserControls.TextBoxWithPlaceholder
{
    public class StringNullOrEmptyToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string str && !string.IsNullOrEmpty(str))
                return Visibility.Collapsed; // Строка не пустая, скрываем элемент
            else
                return Visibility.Visible; // Строка пустая или null, показываем элемент
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
