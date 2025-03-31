using CommunityToolkit.WinUI.Controls;
using Microsoft.UI.Xaml.Media.Imaging;
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
        public static readonly string DefaultRootPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), ".minecraft");


        public static int SelectedInstanceIndex { get; set; }

        public static IList<VersionManifestEntry> Instances { get; set; } = [];

        public static IList<SettingsCardListShow> InstanceListToShow { get; set; } = [];

        public static ObservableCollection<KeyValuePair<string, string>> BreadcrumbItems { get; set; } = [new("Home", "Home")];

        private static Options? _options = new()
        {
            RootPath = [DefaultRootPath],
            CurrentRootPathIndex = DefaultCurrentRootPathIndex
        };
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
                }
            }
        }
        public static IList<string> RootPaths { get; set; } = Options?.RootPath ?? [];
        public static int CurrentRootPathIndex { get; set; } = Options?.CurrentRootPathIndex ?? DefaultCurrentRootPathIndex;
        public static string OptionsFolder { get; set; } = Path.Join(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "FluentLauncherOptions");
        
    }
}
