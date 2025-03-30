using Fluent_Launcher.Assets.Class;
using Fluent_Launcher.Assets.Resources.Icons;
using Microsoft.UI.Dispatching;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Media.Animation;
using Microsoft.UI.Xaml.Navigation;
using MinecraftLaunch.Base.Models.Network;
using MinecraftLaunch.Components.Installer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Fluent_Launcher.Assets.Pages.Download
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Page_InstanceOption : Page
    {
        // parameter属性表示是否有这个加载器
        private IList<SettingsCardListShow> ModloaderViews =
        [
            new()
            {
                Header = "NeoForge",
                Description = "Mod loader, a branch of Forge.",
                HeaderIcon = Icons.NeoForge_Icon,
                parameter = false
            },
            new()
            {
                Header = "Forge",
                Description = "Mod loader, used to load Forge mods.",
                HeaderIcon = Icons.Forge_Icon,
                parameter = false
            },
            new()
            {
                Header = "Optifine",
                Description = "HD fix, installed as a mod when installed with other loaders.",
                HeaderIcon = Icons.OptiFine_Icon,
                parameter = false
            },
            new()
            {
                Header = "Fabric",
                Description = "Mod loader, used to load Fabric mods.",
                HeaderIcon = Icons.Fabric_Icon,
                parameter = false
            },
            new()
            {
                Header = "Quilt",
                Description = "Mod loader, a branch of Fabric.",
                HeaderIcon = Icons.Quilt_Icon,
                parameter = false
            }
        ];

        private IList<ForgeInstallEntry> NeoforgeVersions = [];
        private IList<ForgeInstallEntry> ForgeVersions = [];
        private IList<OptifineInstallEntry> OptifineVersions = [];
        private IList<FabricInstallEntry> FabricVersions = [];
        private IList<QuiltInstallEntry> QuiltVersions = [];

        private readonly VersionManifestEntry CurrentInstanceVersion = GlobalVar.Instances[GlobalVar.SelectedInstanceIndex];

        public Page_InstanceOption()
        {
            this.InitializeComponent();

            DispatcherQueue.GetForCurrentThread().TryEnqueue(async () =>
            {
                await Task.Delay(100); // 延迟异步操作
                await GetModLoaders();
            });

        }

        private async Task GetModLoaders()
        {
            // 创建任务列表
            var tasks = new List<Task>
            {
                Task.Run(async () =>
                {
                    NeoforgeVersions = await ForgeInstaller.EnumerableForgeAsync(CurrentInstanceVersion.Id, true).ToListAsync();
                    if (NeoforgeVersions.Any())
                    {
                        ModloaderViews[0].parameter = true;
                    }
                }), // 获取NeoForge版本
                Task.Run(async () =>
                {
                    ForgeVersions = await ForgeInstaller.EnumerableForgeAsync(CurrentInstanceVersion.Id, false).ToListAsync();
                    if (ForgeVersions.Any())
                    {
                        ModloaderViews[1].parameter = true;
                    }
                }), // 获取Forge版本
                Task.Run(async () =>
                {
                    OptifineVersions = await OptifineInstaller.EnumerableOptifineAsync(CurrentInstanceVersion.Id).ToListAsync();
                    if (OptifineVersions.Any())
                    {
                        ModloaderViews[2].parameter = true;
                    }
                }), // 获取Optifine版本
                Task.Run(async () =>
                {
                    FabricVersions = await FabricInstaller.EnumerableFabricAsync("1.20.1").ToListAsync();
                    if (FabricVersions.Any())
                    {
                        ModloaderViews[3].parameter = true;
                    }
                }), // 获取Fabric版本
                Task.Run(async () =>
                {
                    QuiltVersions = await QuiltInstaller.EnumerableQuiltAsync(CurrentInstanceVersion.Id).ToListAsync();
                    if (QuiltVersions.Any())
                    {
                        ModloaderViews[4].parameter = true;
                    }
                }) // 获取Quilt版本
            };

            // 等待所有任务完成
            await Task.WhenAll(tasks);

            ItemView_Modloaders.ItemsSource = ModloaderViews;
            ProgressBar.Visibility = Visibility.Collapsed;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            // 获取并显示版本信息
            var selectedInstance = GlobalVar.InstanceListToShow[GlobalVar.SelectedInstanceIndex];
            ImageBrush_InstanceIcon.ImageSource = selectedInstance.HeaderIcon;
            TextBlock_InstanceInfoTitle.Text = selectedInstance.Header;
            TextBlock_InstanceInfoDescription.Text = selectedInstance.Description;
            TextBox_InstanceId.Text = TextBlock_InstanceInfoTitle.Text;

            // 获取动画对象并保存
            var pendingAnimation = ConnectedAnimationService.GetForCurrentView().GetAnimation("ForwardConnectedAnimation");

            // 使用延迟启动动画
            Grid_InstanceDetail.Loaded += async (s, args) =>
            {
                await Task.Delay(50); // 延迟 50 毫秒
                pendingAnimation?.TryStart(Grid_InstanceDetail);
            };

        }

    }
}
