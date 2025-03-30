using CommunityToolkit.WinUI.Controls;
using Microsoft.UI.Xaml.Media.Imaging;
using MinecraftLaunch.Base.Models.Network;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fluent_Launcher.Assets.Class
{
    class GlobalVar
    {
        public static int SelectedInstanceIndex { get; set; }

        public static IList<VersionManifestEntry> Instances { get; set; } = [];

        public static IList<SettingsCardListShow> InstanceListToShow { get; set; } = [];

        public static ObservableCollection<KeyValuePair<string, string>> BreadcrumbItems { get; set; } = [new("Home", "Home")];
    }
}
