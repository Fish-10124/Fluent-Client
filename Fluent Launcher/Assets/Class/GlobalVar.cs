using CommunityToolkit.WinUI.Controls;
using Microsoft.UI.Xaml.Media.Imaging;
using MinecraftLaunch.Base.Models.Game;
using MinecraftLaunch.Base.Models.Network;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        public static readonly string DefaultRootPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), ".minecraft");


        public static ObservableCollection<KeyValuePair<string, string>> BreadcrumbItems { get; set; } = [];

        // 当前选择用于启动的实例
        public static string CurrentInstanceId { get; set; } = "None instance here!";

        private static Options? _options = new([DefaultRootPath], DefaultCurrentRootPathIndex, CurrentInstanceId);
        public static Options? Options
        {
            get => _options;
            set
            {
                _options = value;
                if (_options != null)
                {
                    RootPaths = _options.RootPath;
                    CurrentRootPathIndex = _options.CurrentRootPathIndex;
                    CurrentInstanceId = _options.CurrentInstanceId;
                }
            }
        }
        public static IList<string> RootPaths { get; set; } = Options?.RootPath ?? [];
        public static int CurrentRootPathIndex { get; set; } = Options?.CurrentRootPathIndex ?? DefaultCurrentRootPathIndex;
        public static string OptionsFolder { get; set; } = Path.Join(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "FluentLauncherOptions");

        // 检测设备中的Java
        public static IList<JavaEntry> Javas { get; set; } = [];

        // 启动时的配置
        public static LaunchConfig? LaunchConfig { get; set; }
    }
}
