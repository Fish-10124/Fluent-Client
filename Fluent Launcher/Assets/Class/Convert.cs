using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Data;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fluent_Launcher.Assets.Class
{
    class Convert
    {
    }

    public partial class VisibilityConverter : IValueConverter
    {
        public object Convert(object value, System.Type targetType, object parameter, string language)
        {
            bool isEnabled = (bool)value;
            return isEnabled ? Visibility.Collapsed : Visibility.Visible;
        }

        public object ConvertBack(object value, System.Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }

    public partial class TextWrappingConverter : IValueConverter
    {
        public object Convert(object value, System.Type targetType, object parameter, string language)
        {
            bool isEnabled = (bool)value;
            return isEnabled ? TextWrapping.Wrap : TextWrapping.NoWrap;
        }

        public object ConvertBack(object value, System.Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }

    public partial class InstanceIdConverter : IValueConverter
    {
        public object Convert(object value, System.Type targetType, object parameter, string language)
        {
            return value as string == "" ? "None instance here!" : value;
        }

        public object ConvertBack(object value, System.Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }

    public partial class InstanceEnableConverter : IValueConverter
    {
        public object Convert(object value, System.Type targetType, object parameter, string language)
        {
            var options = value as Options;
            return options?.CurrentInstanceId != "" &&
                !string.IsNullOrEmpty(options?.OfflinePlayers[options.CurrentOfflinePlayer].Key);
        }

        public object ConvertBack(object value, System.Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }

    public partial class MBToGBConverter : IValueConverter
    {
        public object Convert(object value, System.Type targetType, object parameter, string language)
        {
            return (double)(int)value / 1024;
        }

        public object ConvertBack(object value, System.Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }

    public partial class TextBoolConverter : IValueConverter
    {
        public object Convert(object value, System.Type targetType, object parameter, string language)
        {
            return string.IsNullOrEmpty(value as string) ? false : true;
        }

        public object ConvertBack(object value, System.Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }

    public partial class LoginTypeToIndexConverter : IValueConverter
    {
        public object Convert(object value, System.Type targetType, object parameter, string language)
        {
            return (LoginType)value switch
            {
                LoginType.Online => 0,
                LoginType.Offline => 1,
                _ => throw new NotImplementedException()
            };
        }

        public object ConvertBack(object value, System.Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
