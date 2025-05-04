using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media.Imaging;
using MinecraftLaunch.Base.Models.Game;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fluent_Launcher.Assets.Class
{
    class Type
    {
    }

    public abstract class ObservableObject : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }


    public partial class SettingsCardTagDescriptionInfos(string? header, IList<string>? description = null, BitmapImage? headerIcon = null, string? tag = null, object? parameter = null) : SettingsCardInfos(header, null, headerIcon, tag, parameter)
    {
        public new IList<string>? Description
        {
            get => description;
            set
            {
                if (description != value)
                {
                    description = value;
                    OnPropertyChanged(nameof(Description));
                }
            }
        }
    }

    public partial class SettingsCardInfos(string? header, string? description = null, BitmapImage? headerIcon = null, string? tag = null, object? parameter = null) : ObservableObject
    {
        public string? Header
        {
            get => header;
            set
            {
                if (header != value)
                {
                    header = value;
                    OnPropertyChanged(nameof(Header));
                }
            }
        }

        public string? Description
        {
            get => description;
            set
            {
                if (description != value)
                {
                    description = value;
                    OnPropertyChanged(nameof(Description));
                }
            }
        }

        public BitmapImage? HeaderIcon
        {
            get => headerIcon;
            set
            {
                if (headerIcon != value)
                {
                    headerIcon = value;
                    OnPropertyChanged(nameof(HeaderIcon));
                }
            }
        }

        public string? Tag
        {
            get => tag;
            set
            {
                if (tag != value)
                {
                    tag = value;
                    OnPropertyChanged(nameof(Tag));
                }
            }
        }

        public object? Parameter
        {
            get => parameter;
            set
            {
                if (parameter != value)
                {
                    parameter = value;
                    OnPropertyChanged(nameof(Parameter));
                }
            }
        }
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

    // 如果folderName为null或空字符串, 则使用第一个参数的最后一个文件夹作为名称
    public class RootPath(string path, string folderName = "", string latestInstanceId = "")
    {
        public string Path { get; set; } = path;
        public string FolderName { get; set; } = string.IsNullOrEmpty(folderName) ? System.IO.Path.GetFileName(path) : folderName;
        public string LatestInstanceId { get; set; } = latestInstanceId;
    }

    public partial class RootPathListShow(string folderName, string folderPath) : ObservableObject
    {
        private string _folderName = folderName;
        public string FolderName
        {
            get => _folderName;
            set
            {
                if (_folderName != value)
                {
                    _folderName = value;
                    OnPropertyChanged(nameof(FolderName));
                }
            }
        }

        private string _folderPath = folderPath;
        public string FolderPath
        {
            get => _folderPath;
            set
            {
                if (_folderPath != value)
                {
                    _folderPath = value;
                    OnPropertyChanged(nameof(FolderPath));
                }
            }
        }
    }

    public class InstancesDeatils(IList<SettingsCardTagDescriptionInfos>? settingsCardInfos, InstancesType type)
    {
        public IList<SettingsCardTagDescriptionInfos>? SettingsCardInfos { get; set; } = settingsCardInfos;
        public InstancesType Type { get; set; } = type;
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

    public partial class ModListShow(string name, string summary, List<string> categories, string downloadCount, string latestUpdate, BitmapImage icon) : ObservableObject
    {
        public string Name
        {
            get => name;
            set
            {
                if (name != value)
                {
                    name = value;
                    OnPropertyChanged(nameof(Name));
                }
            }
        }

        public string Summary
        {
            get => summary;
            set
            {
                if (summary != value)
                {
                    summary = value;
                    OnPropertyChanged(nameof(Summary));
                }
            }
        }

        public List<string> Categories
        {
            get => categories;
            set
            {
                if (categories != value)
                {
                    categories = value;
                    OnPropertyChanged(nameof(Categories));
                }
            }
        }

        public string DownloadCount
        {
            get => downloadCount;
            set
            {
                if (downloadCount != value)
                {
                    downloadCount = value;
                    OnPropertyChanged(nameof(DownloadCount));
                }
            }
        }

        public string LatestUpdate
        {
            get => latestUpdate;
            set
            {
                if (latestUpdate != value)
                {
                    latestUpdate = value;
                    OnPropertyChanged(nameof(LatestUpdate));
                }
            }
        }

        public BitmapImage Icon
        {
            get => icon;
            set
            {
                if (icon != value)
                {
                    icon = value;
                    OnPropertyChanged(nameof(Icon));
                }
            }
        }
    }

}
