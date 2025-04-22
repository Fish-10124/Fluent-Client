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
        private MinecraftParser McParser;

        public Page_SelectInstance()
        {
            this.InitializeComponent();

            // 初始化 RootPaths
            foreach (var path in GlobalVar.Options.RootPaths)
            {
                RootPaths.Add(new(Path.GetFileName(path.Path), path.Path));
            }

            // 解析 Minecraft 实例
            McParser = new(GlobalVar.Options.RootPaths[GlobalVar.Options.CurrentRootPathIndex].Path);
            var instances = McParser.GetMinecrafts();

            ListView_InstanceFolders.SelectedIndex = GlobalVar.Options.CurrentRootPathIndex;

            // 遍历 Minecraft 实例
            ForEachInstances(instances);
            
        }

        private void ForEachInstances(List<MinecraftEntry> instances)
        {
            GlobalVar.InstancesDetails.Clear();

            foreach (var instance in instances)
            {
                var instanceTagInfos = Utils.InstanceEntryToTagInfos(instance);

                // 检查该类型的 InstancesDetails 是否已存在
                var type = (InstancesType)instanceTagInfos.parameter!;
                var existingDetails = GlobalVar.InstancesDetails.FirstOrDefault(item => item.Type == type);

                if (existingDetails == null)
                {
                    // 如果不存在该类型，则创建并添加新实例
                    var newDetails = new InstancesDeatils(new ObservableCollection<SettingsCardTagDescriptionInfos>(), type);

                    GlobalVar.InstancesDetails.Add(newDetails);
                    existingDetails = newDetails; // 更新引用以便后续操作
                }

                // 获取实例的索引
                var index = GlobalVar.InstancesDetails.IndexOf(existingDetails);

                // 往 SettingsCardInfos 中添加内容
                instanceTagInfos.Tag = index.ToString();
                var instanceDetails = instanceTagInfos;
                existingDetails.SettingsCardInfos?.Add(instanceTagInfos);
            }
        }

        private void ListView_Instances_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var listView = sender as ListView;
            GlobalVar.Options.CurrentInstanceId = (listView?.SelectedItem as SettingsCardTagDescriptionInfos)?.Header ?? throw new NullReferenceException("InstanceId was null!");
            
            // 在导航到其它页面之前, 设置最后一次选择的版本
            GlobalVar.Options.RootPaths[GlobalVar.Options.CurrentRootPathIndex].LatestInstanceId = GlobalVar.Options.CurrentInstanceId;
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

                // 在导航到其它页面之前, 设置最后一次选择的版本
                GlobalVar.Options.RootPaths[GlobalVar.Options.CurrentRootPathIndex].LatestInstanceId = instancesDetails?.Header!;

                Frame.Navigate(typeof(Page_InstanceOption), instancesDetails);
            }

        }

        private void ListView_InstanceFolders_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var listView = sender as ListView;
            var selectedPath = listView?.SelectedItem as RootPathListShow;

            // 解析 Minecraft 实例
            GlobalVar.Options.CurrentRootPathIndex = listView?.SelectedIndex ?? throw new Exception("Index parse faild!");
            McParser = new(GlobalVar.Options.RootPaths[GlobalVar.Options.CurrentRootPathIndex].Path);
            var instances = McParser.GetMinecrafts();
            ForEachInstances(instances);

            var latestInstanceId = GlobalVar.Options.RootPaths[GlobalVar.Options.CurrentRootPathIndex].LatestInstanceId;
            if (string.IsNullOrEmpty(latestInstanceId))
            {
                GlobalVar.Options.RootPaths[GlobalVar.Options.CurrentRootPathIndex].LatestInstanceId = instances.Count == 0 ? "" : instances[0].Id;
            }
        }
    }
}
