using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media.Imaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fluent_Launcher.Assets.Class
{
    class Type
    {
    }

    public class SettingsCardListShow
    {
        public string? Header { get; set; }
        public string? Description { get; set; }
        public BitmapImage? HeaderIcon { get; set; }
        public string? Tag { get; set; }
        public object? parameter { get; set; } // 自定义参数
    }

}
