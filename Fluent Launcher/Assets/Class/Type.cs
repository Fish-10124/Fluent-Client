using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media.Imaging;
using MinecraftLaunch.Base.Models.Game;
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
        public string CurrentInstanceId { get; set; }

        // 参数化构造函数
        public Options(IList<string> rootPaths, int currentRootPathIndex, string currentInstanceId)
        {
            RootPath = rootPaths;
            CurrentRootPathIndex = currentRootPathIndex;
            CurrentInstanceId = currentInstanceId;
        }

        // 默认构造函数
        public Options()
        {
            RootPath = [];
            CurrentRootPathIndex = 0;
            CurrentInstanceId = "";
        }
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
        public bool Independent { get; set; }
        public string? WindowTitle { get; set; }
        public string? CustomInfomation { get; set; }
        public int GameJava { get; set; } // 代表GlobalVar.Javas[]的下标
        public int MemoryRadio { get; set; }
        public int MemoryCustomize { get; set; } // 单位是MB
    }

}
