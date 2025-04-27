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
using MinecraftLaunch.Components.Installer.Modpack;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Fluent_Launcher.Assets.Pages.Download.Instances
{

    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Page_InstanceOption : Page
    {
        // parameter属性表示是否有这个加载器
        private IList<SettingsCardInfos> ModloaderViews =
        [
            new(header: "NeoForge", description: "Mod loader, a branch of Forge.", headerIcon: Icons.NeoForge_Icon, parameter: false), // NeoForge
            new(header: "Forge", description: "Mod loader, used to load Forge mods.", headerIcon: Icons.Forge_Icon, parameter: false), // Forge
            new(header: "Optifine", description: "HD fix, installed as a mod when installed with other loaders.", headerIcon: Icons.OptiFine_Icon, parameter: false), // Optifine
            new(header: "Fabric", description: "Mod loader, used to load Fabric mods.", headerIcon: Icons.Fabric_Icon, parameter: false), // Fabric
            new(header: "Quilt", description: "Mod loader, a branch of Fabric.", headerIcon: Icons.Quilt_Icon, parameter: false) // Quilt
        ];
        private IList<SettingsCardInfos> PreinstallModViews = [
            new(header: "Fabric API"), // Fabric API
            new(header: "Quilted Fabric API (QFAPI)"), // QFAPI
            new(header: "Sodium"), // Sodium
            new(header: "Iris Shaders") // Iris
        ];

        private IList<ForgeInstallEntry> NeoforgeVersions = [];
        private IList<ForgeInstallEntry> ForgeVersions = [];
        private IList<OptifineInstallEntry> OptifineVersions = [];
        private IList<FabricInstallEntry> FabricVersions = [];
        private IList<QuiltInstallEntry> QuiltVersions = [];
        private VersionManifestEntry? CurrentInstanceVersion;

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
                    NeoforgeVersions = await ForgeInstaller.EnumerableForgeAsync(CurrentInstanceVersion?.Id, true).ToListAsync();
                    if (NeoforgeVersions.Any())
                    {
                        ModloaderViews[0].parameter = true;
                    }
                }), // 获取NeoForge版本
                Task.Run(async () =>
                {
                    ForgeVersions = await ForgeInstaller.EnumerableForgeAsync(CurrentInstanceVersion?.Id, false).ToListAsync();
                    if (ForgeVersions.Any())
                    {
                        ModloaderViews[1].parameter = true;
                    }
                }), // 获取Forge版本
                Task.Run(async () =>
                {
                    OptifineVersions = await OptifineInstaller.EnumerableOptifineAsync(CurrentInstanceVersion?.Id).ToListAsync();
                    if (OptifineVersions.Any())
                    {
                        ModloaderViews[2].parameter = true;
                    }
                }), // 获取Optifine版本
                Task.Run(async () =>
                {
                    FabricVersions = await FabricInstaller.EnumerableFabricAsync(CurrentInstanceVersion?.Id).ToListAsync();
                    if (FabricVersions.Any())
                    {
                        ModloaderViews[3].parameter = true;
                    }
                }), // 获取Fabric版本
                Task.Run(async () =>
                {
                    QuiltVersions = await QuiltInstaller.EnumerableQuiltAsync(CurrentInstanceVersion?.Id).ToListAsync();
                    if (QuiltVersions.Any())
                    {
                        ModloaderViews[4].parameter = true;
                    }
                }), // 获取Quilt版本
            };

            // 等待所有任务完成
            try
            {
                await Task.WhenAll(tasks);
            }
            catch (Flurl.Http.FlurlHttpException)
            {
                Debug.WriteLine("faild to request http!");
            }

            ItemView_Modloaders.ItemsSource = ModloaderViews;
            ProgressBar.Visibility = Visibility.Collapsed;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            // 获取动画对象并保存
            var pendingAnimation = ConnectedAnimationService.GetForCurrentView().GetAnimation("InstancesListToOptionAnimation");

            IList<object> parameters = (e.Parameter as IList<object>)!;

            CurrentInstanceVersion = parameters[1] as VersionManifestEntry;

            // 获取并显示版本信息
            SettingsCardInfos selectedInstance = (parameters[0] as SettingsCardInfos)!;
            ImageBrush_InstanceIcon.ImageSource = selectedInstance.HeaderIcon;
            TextBlock_InstanceInfoTitle.Text = selectedInstance.Header;
            TextBlock_InstanceInfoDescription.Text = selectedInstance.Description;
            TextBox_InstanceId.Text = TextBlock_InstanceInfoTitle.Text;

            // 使用延迟启动动画
            Grid_InstanceDetail.Loaded += async (s, args) =>
            {
                await Task.Delay(GlobalVar.AnimationDelay);
                pendingAnimation?.TryStart(Grid_InstanceDetail);
            };

        }

    }
}
