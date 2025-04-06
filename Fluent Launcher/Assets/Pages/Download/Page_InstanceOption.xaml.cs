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
using System.Diagnostics.CodeAnalysis;
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
        // parameter���Ա�ʾ�Ƿ������������
        private IList<SettingsCardInfos> ModloaderViews =
        [
            new()
            {
                Header = "NeoForge",
                Description = "Mod loader, a branch of Forge.",
                HeaderIcon = Icons.NeoForge_Icon,
                parameter = false
            }, // NeoForge
            new()
            {
                Header = "Forge",
                Description = "Mod loader, used to load Forge mods.",
                HeaderIcon = Icons.Forge_Icon,
                parameter = false
            }, // Forge
            new()
            {
                Header = "Optifine",
                Description = "HD fix, installed as a mod when installed with other loaders.",
                HeaderIcon = Icons.OptiFine_Icon,
                parameter = false
            }, // Optifine
            new()
            {
                Header = "Fabric",
                Description = "Mod loader, used to load Fabric mods.",
                HeaderIcon = Icons.Fabric_Icon,
                parameter = false
            }, // Fabric
            new()
            {
                Header = "Quilt",
                Description = "Mod loader, a branch of Fabric.",
                HeaderIcon = Icons.Quilt_Icon,
                parameter = false
            } // Quilt
        ];
        private IList<SettingsCardInfos> PreinstallModViews = [
            new()
            {
                Header = "Fabric API"
            }, // Fabric API
            new()
            {
                Header = "Quilted Fabric API (QFAPI)"
            }, // QFAPI
            new()
            {
                Header = "Sodium"
            }, // Sodium
            new()
            {
                Header = "Iris Shaders"
            } // Iris
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
                await Task.Delay(100); // �ӳ��첽����
                await GetModLoaders();
            });

        }

        private async Task GetModLoaders()
        {
            // ���������б�
            var tasks = new List<Task>
            {
                Task.Run(async () =>
                {
                    NeoforgeVersions = await ForgeInstaller.EnumerableForgeAsync(CurrentInstanceVersion?.Id, true).ToListAsync();
                    if (NeoforgeVersions.Any())
                    {
                        ModloaderViews[0].parameter = true;
                    }
                }), // ��ȡNeoForge�汾
                Task.Run(async () =>
                {
                    ForgeVersions = await ForgeInstaller.EnumerableForgeAsync(CurrentInstanceVersion?.Id, false).ToListAsync();
                    if (ForgeVersions.Any())
                    {
                        ModloaderViews[1].parameter = true;
                    }
                }), // ��ȡForge�汾
                Task.Run(async () =>
                {
                    OptifineVersions = await OptifineInstaller.EnumerableOptifineAsync(CurrentInstanceVersion?.Id).ToListAsync();
                    if (OptifineVersions.Any())
                    {
                        ModloaderViews[2].parameter = true;
                    }
                }), // ��ȡOptifine�汾
                Task.Run(async () =>
                {
                    FabricVersions = await FabricInstaller.EnumerableFabricAsync("1.20.1").ToListAsync();
                    if (FabricVersions.Any())
                    {
                        ModloaderViews[3].parameter = true;
                    }
                }), // ��ȡFabric�汾
                Task.Run(async () =>
                {
                    QuiltVersions = await QuiltInstaller.EnumerableQuiltAsync(CurrentInstanceVersion?.Id).ToListAsync();
                    if (QuiltVersions.Any())
                    {
                        ModloaderViews[4].parameter = true;
                    }
                }), // ��ȡQuilt�汾
            };

            // �ȴ������������
            await Task.WhenAll(tasks);

            ItemView_Modloaders.ItemsSource = ModloaderViews;
            ProgressBar.Visibility = Visibility.Collapsed;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            // ��ȡ�������󲢱���
            var pendingAnimation = ConnectedAnimationService.GetForCurrentView().GetAnimation("InstancesListToOptionAnimation");

            var parameters = e.Parameter as IList<object> ?? throw new NullReferenceException("parameter was null!");

            CurrentInstanceVersion = parameters[1] as VersionManifestEntry ?? throw new Exception("parameter parse faild!");

            // ��ȡ����ʾ�汾��Ϣ
            var selectedInstance = parameters[0] as SettingsCardInfos ?? throw new Exception("parameter parse faild!");
            ImageBrush_InstanceIcon.ImageSource = selectedInstance.HeaderIcon;
            TextBlock_InstanceInfoTitle.Text = selectedInstance.Header;
            TextBlock_InstanceInfoDescription.Text = selectedInstance.Description;
            TextBox_InstanceId.Text = TextBlock_InstanceInfoTitle.Text;

            // ʹ���ӳ���������
            Grid_InstanceDetail.Loaded += async (s, args) =>
            {
                await Task.Delay(GlobalVar.AnimationDelay);
                pendingAnimation?.TryStart(Grid_InstanceDetail);
            };

        }

    }
}
