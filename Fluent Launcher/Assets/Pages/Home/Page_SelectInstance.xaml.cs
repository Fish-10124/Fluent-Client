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
        public ObservableCollection<InstancesDeatils> InstancesDetails = [];

        public Page_SelectInstance()
        {
            this.InitializeComponent();

            // 初始化 RootPaths
            foreach (var path in GlobalVar.RootPaths)
            {
                RootPaths.Add(new(Path.GetFileName(path) ?? path, path));
            }

            // 解析 Minecraft 实例
            var mcParser = new MinecraftParser(GlobalVar.RootPaths[GlobalVar.CurrentRootPathIndex]);
            var instances = mcParser.GetMinecrafts();

            // 遍历 Minecraft 实例
            foreach (var instance in instances)
            {
                List<string> descriptions = [instance.Version.VersionId, instance.Version.Type.ToString()];
                BitmapImage headerIcon;
                InstanceType type;

                if (instance.IsVanilla)
                {
                    // 原版 Minecraft 图标和类型
                    headerIcon = GetVanillaIcon(instance.Version.Type);
                    type = InstanceType.Normal;
                }
                else
                {
                    // 模组 Minecraft 图标和类型
                    var modInstance = instance as ModifiedMinecraftEntry ?? throw new Exception("Instance parse failed!");
                    IList<ModLoaderInfo> modLoaders = modInstance.ModLoaders.ToList();

                    foreach (var modLoader in modLoaders)
                    {
                        descriptions.Add($"{modLoader.Type} {modLoader.Version}");
                    }

                    headerIcon = GetModLoaderIcon(modLoaders.First().Type);
                    type = InstanceType.Modified;
                }

                // 检查该类型的 InstancesDetails 是否已存在
                var existingDetails = InstancesDetails.FirstOrDefault(item => item.Type == type);

                if (existingDetails == null)
                {
                    // 如果不存在该类型，则创建并添加新实例
                    var newDetails = new InstancesDeatils
                    {
                        Type = type,
                        SettingsCardInfos = new ObservableCollection<SettingsCardTagDescriptionInfos>()
                    };

                    InstancesDetails.Add(newDetails);
                    existingDetails = newDetails; // 更新引用以便后续操作
                }

                // 获取实例的索引
                var index = InstancesDetails.IndexOf(existingDetails);

                // 往 SettingsCardInfos 中添加内容
                var instanceDetails = new SettingsCardTagDescriptionInfos
                {
                    Header = instance.Id,
                    Description = descriptions,
                    HeaderIcon = headerIcon,
                    Tag = index.ToString() // 将索引值设置为 Tag
                };
                existingDetails.SettingsCardInfos?.Add(instanceDetails);
            }

            // 获取原版 Minecraft 图标
            BitmapImage GetVanillaIcon(MinecraftVersionType type) =>
                type switch
                {
                    MinecraftVersionType.Release => Icons.Grass_Block,
                    MinecraftVersionType.PreRelease => Icons.Crafting_Table,
                    MinecraftVersionType.Snapshot => Icons.Crafting_Table,
                    MinecraftVersionType.OldBeta => Icons.Dirt_Path,
                    MinecraftVersionType.OldAlpha => Icons.Dirt_Path,
                    MinecraftVersionType.Unknown => Icons.Furnace,
                    _ => throw new NotImplementedException()
                };

            // 获取模组加载器图标
            BitmapImage GetModLoaderIcon(ModLoaderType type) =>
                type switch
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

        private void ListView_Instances_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var listView = sender as ListView;
            GlobalVar.CurrentInstanceId = (listView?.SelectedItem as SettingsCardTagDescriptionInfos)?.Header ?? throw new NullReferenceException("InstanceId was null!");
            Frame.Navigate(typeof(Page_Home));
        }

        private void HyperlinkButton_Settings_Click(object sender, RoutedEventArgs e)
        {
            var selectedElement = ((sender as HyperlinkButton)?.Parent as Grid)?.Parent as Grid;
            if (selectedElement == null)
            {
                return;
            }

            var instancesDetails = selectedElement.DataContext as SettingsCardTagDescriptionInfos;

            var animationElement = selectedElement;
            if (animationElement != null)
            {
                var animation = ConnectedAnimationService.GetForCurrentView().PrepareToAnimate("SelectInstanceToOptionAnimation", animationElement);
                animation.Configuration = new DirectConnectedAnimationConfiguration();

                GlobalVar.BreadcrumbItems.Clear();
                GlobalVar.BreadcrumbItems.Add(new("InstanceOptions", "Instance Options"));

                Frame.Navigate(typeof(Page_InstanceOption), instancesDetails);
            }

        }

    }
}
