using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media.Imaging;
using MinecraftLaunch.Base.Models.Game;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fluent_Launcher.Assets.Class
{
    class Type
    {
    }

    public class SettingsCardTagDescriptionInfos(string? header, IList<string>? description = null, BitmapImage? headerIcon = null, string? tag = null, object? parameter = null)
        : SettingsCardInfos(header, null, headerIcon, tag, parameter)
    {
        public new IList<string>? Description { get; set; } = description;
    }

    public class SettingsCardInfos(string? header, string? description = null, BitmapImage? headerIcon = null, string? tag = null, object? parameter = null)
    {
        public string? Header { get; set; } = header;
        public string? Description { get; set; } = description;
        public BitmapImage? HeaderIcon { get; set; } = headerIcon;
        public string? Tag { get; set; } = tag;
        public object? parameter { get; set; } = parameter; // 自定义参数
    }

    public class Options
    {
        public IList<RootPath> RootPaths { get; set; }
        public int CurrentRootPathIndex { get; set; }
        public string CurrentInstanceId { get; set; }
        public IList<OfflinePlayer> OfflinePlayers { get; set; }
        public int CurrentOfflinePlayer { get; set; }
        public LoginType LoginType { get; set; }

        // 参数化构造函数
        public Options(IList<RootPath> rootPaths, 
            int currentRootPathIndex, 
            string currentInstanceId, 
            IList<OfflinePlayer> offlinePlayers,
            int currentOfflinePlayer,
            LoginType loginWay)
        {
            RootPaths = rootPaths;
            CurrentRootPathIndex = currentRootPathIndex;
            CurrentInstanceId = currentInstanceId;
            OfflinePlayers = offlinePlayers;
            CurrentOfflinePlayer = currentOfflinePlayer;
            LoginType = loginWay;
        }

        // 默认构造函数
        public Options()
        {
            RootPaths = GlobalVar.DefaultRootPath;
            CurrentRootPathIndex = GlobalVar.DefaultCurrentRootPathIndex;
            CurrentInstanceId = GlobalVar.DefaultInstanceId;
            OfflinePlayers = [];
            CurrentOfflinePlayer = -1;
            LoginType = LoginType.Online;
        }
    }

    public class OfflinePlayer(string name, Guid uuid)
    {
        public string Name { get; set; } = name;
        public Guid Uuid { get; set; } = uuid;
    }

    public class RootPath(string path, string latestInstanceId)
    {
        public string Path { get; set; } = path;
        public string LatestInstanceId { get; set; } = latestInstanceId;
    }

    public class RootPathListShow(string folderName, string folderPath)
    {
        public string FolderName { get; set; } = folderName;
        public string FolderPath { get; set; } = folderPath;
    }

    public class InstancesDeatils(IList<SettingsCardTagDescriptionInfos>? settingsCardInfos, InstanceType type)
    {
        public IList<SettingsCardTagDescriptionInfos>? SettingsCardInfos { get; set; } = settingsCardInfos;
        public InstanceType Type { get; set; } = type;
    }

    // 在读取实例的ini文件时使用
    public class InstanceOptions
    {
        public static class Keys
        {
            public const string InstanceDescription = "instancedescription",
                            Independent = "independent",
                            WindowTitle = "windowtitle",
                            CustomInfomation = "custominfomation",
                            GameJava = "gamejava",
                            MemoryRadio = "memoryradio",
                            MemoryCustomize = "memorycustomize";
        }

        public const string IniSection = "InstanceOption";

        public string? InstanceDescription { get; set; }
        public bool Independency { get; set; }
        public string? WindowTitle { get; set; }
        public string? CustomInfomation { get; set; }
        public int GameJava { get; set; } // 代表GlobalVar.Javas[]的下标
        public int MemoryRadio { get; set; }
        public int MemoryCustomize { get; set; } // 单位是MB
    }

    public class ModListShow(string name, string summary, List<string> categories, string downloadCount, string latestUpdate, BitmapImage icon)
    {
        public string Name { get; set; } = name;
        public string Summary { get; set; } = summary;
        public List<string> Categories { get; set; } = categories;
        public string DownloadCount { get; set; } = downloadCount;
        public string LatestUpdate { get; set; } = latestUpdate;
        public BitmapImage Icon { get; set; } = icon;
    }

}
