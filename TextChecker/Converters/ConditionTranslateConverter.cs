using System;
using System.Globalization;
using System.Windows.Data;
using TextChecker.Core;

namespace TextChecker.Converters
{
    public class ConditionTranslateConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value is string str)
            {
                if (str == ConditionEnum.IsEqual.ToString())
                    return "równa się";
                if (str == ConditionEnum.StartsWith.ToString())
                    return "zaczyna się od";
                if (str == ConditionEnum.EndsWith.ToString())
                    return "kończy się na";
                if (str == ConditionEnum.Contains.ToString())
                    return "zawiera";
            }

            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
