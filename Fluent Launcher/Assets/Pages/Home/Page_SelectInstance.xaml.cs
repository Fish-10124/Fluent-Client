using Fluent_Launcher.Assets.Class;
using Fluent_Launcher.Assets.Resources.Icons;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Media.Animation;
using Microsoft.UI.Xaml.Media.Imaging;
using Microsoft.UI.Xaml.Navigation;
using MinecraftLaunch.Base.Enums;
using MinecraftLaunch.Base.Models.Game;
using MinecraftLaunch.Components.Parser;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Fluent_Launcher.Assets.Pages.Home
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Page_SelectInstance : Page
    {
        private ObservableCollection<RootPathListShow> RootPaths = [];
        private IList<ModifiedMinecraftEntry?> Instances = [];
        public ObservableCollection<SettingsCardTagDescriptionInfos?> InstanceDetails = [];

        public Page_SelectInstance()
        {
            this.InitializeComponent();

            foreach (var item in GlobalVar.RootPaths)
            {
                RootPaths.Add(new()
                {
                    FolderName = Path.GetFileName(item) ?? item,
                    FolderPath = item
                });
            }

            MinecraftParser mcParser = new(GlobalVar.RootPaths[GlobalVar.CurrentRootPathIndex]);
            var instances = mcParser.GetMinecrafts();
            foreach (var item in instances)
            {
                IList<string> descriptions = [item.Version.VersionId, item.Version.Type.ToString()];
                BitmapImage headerIcon;

                // 如果是原版
                if (item.IsVanilla)
                {
                    headerIcon = item.Version.Type switch
                    {
                        MinecraftVersionType.Release => Icons.Grass_Block,
                        MinecraftVersionType.PreRelease => Icons.Crafting_Table,
                        MinecraftVersionType.Snapshot => Icons.Crafting_Table,
                        MinecraftVersionType.OldBeta => Icons.Dirt_Path,
                        MinecraftVersionType.OldAlpha => Icons.Dirt_Path,
                        MinecraftVersionType.Unknown => Icons.Furnace,
                        _ => throw new NotImplementedException()
                    };
                }
                else
                {
                    var instance = item as ModifiedMinecraftEntry ?? throw new Exception("Instance parse faild!");

                    // 获取模组加载器的类型和版本
                    IList<ModLoaderInfo> modLoaders = [];
                    foreach (var modloader in instance.ModLoaders)
                    {
                        descriptions.Add($"{modloader.Type} {modloader.Version}");
                        modLoaders.Add(modloader);
                    }

                    // 设置图标
                    headerIcon = modLoaders[0].Type switch
                    {
                        ModLoaderType.Any => Icons.Furnace,
                        ModLoaderType.Forge => Icons.Forge_Icon,
                        ModLoaderType.Cauldron => Icons.Furnace,
                        ModLoaderType.LiteLoader => Icons.LiteLoader_Icon,
                        ModLoaderType.Fabric => Icons.Fabric_Icon,
                        ModLoaderType.Quilt => Icons.Quilt_Icon,
                        ModLoaderType.NeoForge => Icons.NeoForge_Icon,
                        ModLoaderType.OptiFine => Icons.OptiFine_Icon,
                        ModLoaderType.Unknown => Icons.Furnace,
                        _ => throw new NotImplementedException()
                    };
                }

                InstanceDetails.Add(new()
                {
                    Header = item?.Id,
                    Description = descriptions,
                    HeaderIcon = headerIcon
                });
            }
        }

        private void ListView_AllInstance_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var listView = sender as ListView;
            if (listView == null)
            {
                return;
            }

            GlobalVar.BreadcrumbItems.Clear();
            GlobalVar.BreadcrumbItems.Add(new("InstanceOptions", "Instance Options"));
            Frame.Navigate(typeof(Page_InstanceOption), InstanceDetails[listView.SelectedIndex]);
        }
    }
}
