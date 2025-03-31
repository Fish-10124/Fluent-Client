using Fluent_Launcher.Assets.Class;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Media.Imaging;
using Microsoft.UI.Xaml.Navigation;
using MinecraftLaunch.Base.Models.Game;
using MinecraftLaunch.Base.Enums;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text.Json;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Fluent_Launcher.Assets.Resources.Icons;
using Microsoft.UI.Xaml.Media.Animation;
using System.Threading.Tasks;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Fluent_Launcher.Assets.Pages.Home
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Page_InstanceOption : Page
    {

        public SettingsCardTagDescriptionInfos? InstanceDetails;

        public Page_InstanceOption()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            InstanceDetails = e.Parameter as SettingsCardTagDescriptionInfos ?? throw new NullReferenceException("Instance was null!");

            // 获取动画对象并保存
            var pendingAnimation = ConnectedAnimationService.GetForCurrentView().GetAnimation("SelectInstanceToOptionAnimation");

            // 使用延迟启动动画
            Grid_InstanceDetails.Loaded += async (s, args) =>
            {
                await Task.Delay(50); // 延迟 50 毫秒
                pendingAnimation?.TryStart(Grid_InstanceDetails);
            };
        }
    }
}
