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
using MinecraftLaunch.Base.Models.Network;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Fluent_Launcher.Assets.Pages.Download.Instances
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Page_InstancesList : Page
    {
        private static IList<SettingsCardInfos> FilteredInstances = [];
        private IList<VersionManifestEntry> Instances = [];
        private IList<SettingsCardInfos> InstanceListToShow = [];

        public Page_InstancesList()
        {
            this.InitializeComponent();

            HttpUtil.Initialize();

            _ = GetInstancesAsync();

        }

        private async Task GetInstancesAsync()
        {
            ProgressBar.Visibility = Visibility.Visible;

            Instances = await VanillaInstaller.EnumerableMinecraftAsync().ToListAsync();

            foreach (var (item, i) in Instances.Select((item, i) => (item, i)))
            {
                var type = item.ReleaseTime.Month == 4 && item.ReleaseTime.Day == 1 ? "aprilfool" : item.Type;

                // 转换版本类型
                string instanceType = Class.Convert.ConvertInstanceType(type)!;

                InstanceListToShow.Add(new SettingsCardInfos(header: item.Id,
                    description: $"{instanceType}  {item.ReleaseTime.ToString("d", CultureInfo.CurrentCulture)} {item.ReleaseTime.ToString("t", CultureInfo.CurrentCulture)}",
                    headerIcon: Class.Convert.ConvertInstanceIcon(type), tag: i.ToString()));

            }

            FilteredInstances = [.. InstanceListToShow.Select(item => new SettingsCardInfos(header: item.Header, description: item.Description, headerIcon: item.HeaderIcon, tag: item.Tag))];

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
                ListView_Instances.ItemsSource = InstanceListToShow;
                return;
            }

            var filteredInstances = comboBox?.SelectedIndex switch
            {
                1 => Instances.Select((item, index) => (item, index)).Where(pair => pair.item.Type == "release").Select(pair => pair.index).ToList(),
                2 => Instances.Select((item, index) => (item, index)).Where(pair => pair.item.Type == "snapshot").Select(pair => pair.index).ToList(),
                3 => Instances.Select((item, index) => (item, index)).Where(pair => pair.item.Type == "old_alpha").Select(pair => pair.index).ToList(),
                4 => Instances.Select((item, index) => (item, index)).Where(pair => pair.item.Type == "old_beta").Select(pair => pair.index).ToList(),
                5 => Instances.Select((item, index) => (item, index)).Where(pair => pair.item.ReleaseTime.Month == 4 && pair.item.ReleaseTime.Day == 1).Select(pair => pair.index).ToList(),
                _ => throw new NotImplementedException()
            };
            foreach (var (item, i) in filteredInstances.Select((item, i) => (item, i)))
            {
                FilteredInstances.Add(InstanceListToShow[filteredInstances[i]]);
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
            _ = int.TryParse(clickedCard?.Tag as string, out int SelectedInstanceIndex);

            // 准备动画
            var animationElement = clickedCard?.FindName("Grid_InstanceDetail") as Grid;
            if (animationElement != null)
            {
                var animation = ConnectedAnimationService.GetForCurrentView().PrepareToAnimate("InstancesListToOptionAnimation", animationElement);
                animation.Configuration = new DirectConnectedAnimationConfiguration();
                
                IList<object> navigateParameter = [InstanceListToShow[SelectedInstanceIndex], Instances[SelectedInstanceIndex]];

                Frame.Navigate(typeof(Page_InstanceOption), navigateParameter, new SlideNavigationTransitionInfo() { Effect = SlideNavigationTransitionEffect.FromRight });
            }
        }

    }
}
