using CommunityToolkit.WinUI.Controls;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Media.Imaging;
using MinecraftLaunch.Base.Models.Game;
using MinecraftLaunch.Base.Models.Network;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace Fluent_Launcher.Assets.Class
{
    class GlobalVar
    {
        public const string OptionsFile = "FLOptions.json";
        public const int DefaultCurrentRootPathIndex = 0;
        public const int AnimationDelay = 100;
        public const string DefaultInstanceId = "";
        public const int DefaultOfflinePlayerIndex = -1;

        public static Window CurrentWindow { get; set; }

        public static readonly List<RootPath> DefaultRootPath = 
            [
                new(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), ".minecraft"))
            ];

        public static Options Options { get; set; } = new();
        public static string OptionsFolder { get; set; } = Path.Join(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "FluentLauncherOptions");

        // 检测设备中的Java
        public static IList<JavaEntry> Javas { get; set; } = [];

        // 版本的配置文件，用于启动游戏时给予参数
        public static InstanceOptions IniOptions { get; set; } = new();

        // 每个文件夹下最后一次启动的实例
        public static IList<string> LatestInstanceId { get; set; } = [];
    }
}
