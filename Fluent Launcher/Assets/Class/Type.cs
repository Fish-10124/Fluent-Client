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
        public IList<RootPath> RootPaths { get; set; }
        public int CurrentRootPathIndex { get; set; }
        public string CurrentInstanceId { get; set; }
        public IList<KeyValuePair<string, Guid>> OfflinePlayers { get; set; }
        public int CurrentOfflinePlayer { get; set; }
        public LoginType LoginType { get; set; }

        // 参数化构造函数
        public Options(IList<RootPath> rootPaths, 
            int currentRootPathIndex, 
            string currentInstanceId, 
            IList<KeyValuePair<string, Guid>> offlinePlayers,
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

    public class InstancesDeatils
    {
        public IList<SettingsCardTagDescriptionInfos>? SettingsCardInfos { get; set; } = [];
        public InstanceType Type { get; set; }
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

}
