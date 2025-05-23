using Fluent_Launcher.Assets.Class;
using Fluent_Launcher.Assets.Dialogs;
using Fluent_Launcher.Assets.Pages.Home.InstanceOption;
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
using Microsoft.UI.Xaml.Shapes;
using MinecraftLaunch.Base.Enums;
using MinecraftLaunch.Base.Models.Game;
using MinecraftLaunch.Components.Parser;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.Storage.Pickers;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Fluent_Launcher.Assets.Pages.Home.SelectInstance
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Page_SelectInstance : Page
    {
        private ObservableCollection<RootPathListShow> RootPaths = [];
        private ObservableCollection<InstancesDeatils> InstancesDetails = [];

        private MinecraftParser McParser;

        public Page_SelectInstance()
        {
            this.InitializeComponent();

            // 初始化 RootPaths
            foreach (var path in GlobalVar.Options.RootPaths)
            {
                RootPaths.Add(new(string.IsNullOrEmpty(path.FolderName) ? System.IO.Path.GetFileName(path.Path) : path.FolderName, path.Path));
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
            InstancesDetails.Clear();

            foreach (var instance in instances)
            {
                var instanceTagInfos = Utils.InstanceEntryToTagInfos(instance);

                // 检查该类型的 InstancesDetails 是否已存在
                var type = (InstancesType)instanceTagInfos.Parameter!;
                var existingDetails = InstancesDetails.FirstOrDefault(item => item.Type == type);

                if (existingDetails == null)
                {
                    // 如果不存在该类型，则创建并添加新实例
                    var newDetails = new InstancesDeatils(new ObservableCollection<SettingsCardTagDescriptionInfos>(), type);

                    InstancesDetails.Add(newDetails);
                    existingDetails = newDetails; // 更新引用以便后续操作
                }

                // 获取实例的索引
                var index = InstancesDetails.IndexOf(existingDetails);

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

                // 在导航到其它页面之前, 设置最后一次选择的版本
                GlobalVar.Options.RootPaths[GlobalVar.Options.CurrentRootPathIndex].LatestInstanceId = instancesDetails?.Header!;

                Frame.Navigate(typeof(Page_InstanceOption), instancesDetails);
            }

        }

        private void ListView_InstanceFolders_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListView listView = (sender as ListView)!;

            // 解析 Minecraft 实例
            GlobalVar.Options.CurrentRootPathIndex = listView.SelectedIndex;
            McParser = new(GlobalVar.Options.RootPaths[GlobalVar.Options.CurrentRootPathIndex].Path);
            var instances = McParser.GetMinecrafts();
            ForEachInstances(instances);

            var latestInstanceId = GlobalVar.Options.RootPaths[GlobalVar.Options.CurrentRootPathIndex].LatestInstanceId;
            if (string.IsNullOrEmpty(latestInstanceId))
            {
                GlobalVar.Options.RootPaths[GlobalVar.Options.CurrentRootPathIndex].LatestInstanceId = instances.Count == 0 ? "" : instances[0].Id;
            }
        }

        private async void HyperlinkButton_SelectFolder_Click(object sender, RoutedEventArgs e)
        {
            HyperlinkButton button = (sender as HyperlinkButton)!;
            button.IsEnabled = false;

            var folderPicker = new FolderPicker();
            var hWnd = WinRT.Interop.WindowNative.GetWindowHandle(GlobalVar.CurrentWindow);
            WinRT.Interop.InitializeWithWindow.Initialize(folderPicker, hWnd);

            folderPicker.SuggestedStartLocation = PickerLocationId.Desktop;
            folderPicker.FileTypeFilter.Add("*");

            StorageFolder folder = await folderPicker.PickSingleFolderAsync();

            button.IsEnabled = true;

            if (folder == null)
            {
                return;
            }

            if (GlobalVar.Options.RootPaths.Any(item => item.Path.Equals(folder.Path)))
            {
                return;
            } 

            GlobalVar.Options.RootPaths.Add(new(folder.Path));
            RootPaths.Add(new(folder.Name, folder.Path));
        }

        private async void MenuFlyoutItem_Click(object sender, RoutedEventArgs e)
        {
            MenuFlyoutItem flyout = (sender as MenuFlyoutItem)!;
            RootPathListShow listViewItem = (flyout!.DataContext as RootPathListShow)!;
            var selectedItem = (ListView_InstanceFolders.SelectedItem as RootPathListShow)!;

            switch (flyout.Name)
            {
                case "MenuFlyoutItem_Rename":
                    var contentPage = new Page_FolderRenameDialog();
                    var dialog = new ContentDialog()
                    {
                        Title = "Folder name options",
                        PrimaryButtonText = "Confirm",
                        DefaultButton = ContentDialogButton.Primary,
                        IsSecondaryButtonEnabled = false,
                        CloseButtonText = "Cancel",
                        Content = contentPage,
                        Style = Application.Current.Resources["DefaultContentDialogStyle"] as Style,
                        XamlRoot = this.XamlRoot
                    };

                    contentPage.Init(listViewItem.FolderName);

                    // 显示ContentDialog
                    var result = await dialog.ShowAsync();

                    if (result == ContentDialogResult.Primary)
                    {
                        string newName = contentPage.GetName();
                        GlobalVar.Options.RootPaths.FirstOrDefault(item => item.Path.Equals(listViewItem.FolderPath))!.FolderName = newName;
                        RootPaths.FirstOrDefault(item => item.FolderPath.Equals(listViewItem.FolderPath))!.FolderName = newName;
                    }
                    
                    break;

                case "MenuFlyoutItem_Open":
                    Process.Start("explorer.exe", $"\"{listViewItem.FolderPath}\"");
                    break;

                case "MenuFlyoutItem_Refresh":
                    if (selectedItem.Equals(listViewItem))
                    {
                        InstancesDetails.Clear();
                        ForEachInstances(McParser.GetMinecrafts());
                    }
                    break;

                case "MenuFlyoutItem_Delete":
                    if (listViewItem.FolderPath.Equals(selectedItem.FolderPath))
                    {
                        ListView_InstanceFolders.SelectedIndex = ListView_InstanceFolders.SelectedIndex == 0 ? 1 : 0;
                    }

                    var removePath = GlobalVar.Options.RootPaths.FirstOrDefault(item => item.Path.Equals(listViewItem.FolderPath))!;
                    GlobalVar.Options.RootPaths.Remove(removePath);
                    RootPaths.Remove(listViewItem);
                    break;
            }
        }

        private void MenuFlyoutItem_Delete_Loaded(object sender, RoutedEventArgs e)
        {
            if (RootPaths.Count <= 1)
            {
                (sender as MenuFlyoutItem)!.IsEnabled = false;
            }
        }
    }
}
