using System;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using MinecraftLaunch.Components.Installer;
using Fluent_Launcher.Assets.Class;
using Fluent_Launcher.Assets.Resources.Icons;
using System.Threading.Tasks;
using Microsoft.UI.Dispatching;
using System.Diagnostics;
using CommunityToolkit.WinUI.Controls;
using Microsoft.UI.Xaml.Media.Animation;
using MinecraftLaunch.Utilities;
using Convert = System.Convert;
using Microsoft.UI.Xaml.Navigation;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Fluent_Launcher.Assets.Pages.Download
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Page_InstancesList : Page
    {
        private static IList<SettingsCardListShow> FilteredInstances = [];
        
        public Page_InstancesList()
        {
            this.InitializeComponent();

            HttpUtil.Initialize();

            DispatcherQueue.GetForCurrentThread().TryEnqueue(async () =>
            {
                await Task.Delay(100); // 延迟异步操作
                await GetInstancesAsync();
            });

        }

        private async Task GetInstancesAsync()
        {
            GlobalVar.Instances = await VanillaInstaller.EnumerableMinecraftAsync().ToListAsync();

            foreach (var (item, i) in GlobalVar.Instances.Select((item, i) => (item, i)))
            {

                // 转换版本类型
                string instanceType = item.ReleaseTime.Month == 4 && item.ReleaseTime.Day == 1 ? "April Fool" : item.Type switch
                {
                    "release" => "Release",
                    "snapshot" => "Snapshot",
                    "old_alpha" => "Historical α",
                    "old_beta" => "Historical β",
                    _ => throw new NotImplementedException()
                };

                GlobalVar.InstanceListToShow.Add(new SettingsCardListShow
                {
                    Header = item.Id,
                    Description = $"{instanceType}  {item.ReleaseTime.ToString("d", CultureInfo.CurrentCulture)} {item.ReleaseTime.ToString("t", CultureInfo.CurrentCulture)}",
                    HeaderIcon = instanceType switch
                    {
                        "Release" => Icons.Grass_Block,
                        "Snapshot" => Icons.Crafting_Table,
                        "Historical α" => Icons.Dirt_Path,
                        "Historical β" => Icons.Dirt_Path,
                        "April Fool" => Icons.Furnace,
                        _ => throw new NotImplementedException()
                    },
                    Tag = i.ToString()
                });

            }

            FilteredInstances = GlobalVar.InstanceListToShow.Select(item => new SettingsCardListShow
            {
                Header = item.Header,
                Description = item.Description,
                HeaderIcon = item.HeaderIcon,
                Tag = item.Tag
            }).ToList();

            // 更新ListView
            ListView_Instances.ItemsSource = null;
            ListView_Instances.ItemsSource = FilteredInstances;
            // 隐藏ProgressBar
            ProgressBar.Visibility = Visibility.Collapsed;
            // 更新ComboBox
            ComboBox_Filter.SelectedIndex = 0;

        }

        private void ComboBox_Filter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //0 All
            //1 Release
            //2 Snapshot
            //3 Historical α
            //4 Historical β
            //5 April Fool

            var comboBox = sender as ComboBox;
            FilteredInstances.Clear();

            if (comboBox?.SelectedIndex == 0)
            {
                ListView_Instances.ItemsSource = null;
                ListView_Instances.ItemsSource = GlobalVar.InstanceListToShow;
                return;
            }

            var filteredInstances = comboBox?.SelectedIndex switch
            {
                1 => GlobalVar.Instances.Select((item, index) => (item, index)).Where(pair => pair.item.Type == "release").Select(pair => pair.index).ToList(),
                2 => GlobalVar.Instances.Select((item, index) => (item, index)).Where(pair => pair.item.Type == "snapshot").Select(pair => pair.index).ToList(),
                3 => GlobalVar.Instances.Select((item, index) => (item, index)).Where(pair => pair.item.Type == "old_alpha").Select(pair => pair.index).ToList(),
                4 => GlobalVar.Instances.Select((item, index) => (item, index)).Where(pair => pair.item.Type == "old_beta").Select(pair => pair.index).ToList(),
                5 => GlobalVar.Instances.Select((item, index) => (item, index)).Where(pair => pair.item.ReleaseTime.Month == 4 && pair.item.ReleaseTime.Day == 1).Select(pair => pair.index).ToList(),
                _ => throw new NotImplementedException()
            };
            foreach (var (item, i) in filteredInstances.Select((item, i) => (item, i)))
            {
                FilteredInstances.Add(GlobalVar.InstanceListToShow[filteredInstances[i]]);
            }

            if (FilteredInstances.Any())
            {
                ListView_Instances.ItemsSource = null;
                ListView_Instances.ItemsSource = FilteredInstances;
            }
        }

        private void SettingsCard_Instance_Click(object sender, RoutedEventArgs e)
        {
            // clickedCard.Tag代表了列表的索引
            var clickedCard = sender as SettingsCard;
            GlobalVar.SelectedInstanceIndex = Convert.ToInt32(clickedCard?.Tag);

            // 准备动画
            var animationElement = clickedCard?.FindName("Grid_InstanceDetail") as Grid;
            if (animationElement != null)
            {
                var animation = ConnectedAnimationService.GetForCurrentView().PrepareToAnimate("ForwardConnectedAnimation", animationElement);
                animation.Configuration = new DirectConnectedAnimationConfiguration();
                if (clickedCard?.DataContext is SettingsCardListShow targetItem)
                {
                    GlobalVar.BreadcrumbItems.Add(new(GlobalVar.InstanceListToShow[GlobalVar.SelectedInstanceIndex].Header ?? "", GlobalVar.InstanceListToShow[GlobalVar.SelectedInstanceIndex].Header ?? ""));
                    Frame.Navigate(typeof(Page_InstanceOption), targetItem, new SlideNavigationTransitionInfo() { Effect = SlideNavigationTransitionEffect.FromRight });
                }
            }
        }

    }
}
