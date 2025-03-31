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

    public class SettingsCardTagDescriptionInfos : SettingsCardInfos
    {
        public new IList<string>? Description { get; set; }
    }

    public class SettingsCardInfos
    {
        public string? Header { get; set; }
        public string? Description { get; set; }
        public BitmapImage? HeaderIcon { get; set; }
        public string? Tag { get; set; }
        public object? parameter { get; set; } // 自定义参数
    }

    public class Options
    {
        public IList<string> RootPath { get; set; }
        public int CurrentRootPathIndex { get; set; }

        // 参数化构造函数
        public Options(IList<string> rootPaths, int currentRootPathIndex)
        {
            RootPath = rootPaths;
            CurrentRootPathIndex = currentRootPathIndex;
        }

        // 默认构造函数
        public Options()
        {
            RootPath = [];
            CurrentRootPathIndex = 0;
        }
    }

    public class RootPathListShow
    {
        public required string FolderName { get; set; }
        public required string FolderPath { get; set; }
    }

}
