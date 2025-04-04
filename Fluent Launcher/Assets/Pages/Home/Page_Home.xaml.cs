using Fluent_Launcher.Assets.Class;
using Fluent_Launcher.Assets.Pages.Home;
using Microsoft.UI.Dispatching;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using MinecraftLaunch.Base.Models.Authentication;
using MinecraftLaunch.Base.Models.Game;
using MinecraftLaunch.Components.Authenticator;
using MinecraftLaunch.Components.Parser;
using MinecraftLaunch.Extensions;
using MinecraftLaunch.Launch;
using MinecraftLaunch.Utilities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Fluent_Launcher.Assets.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Page_Home : Page
    {
        public Page_Home()
        {
            this.InitializeComponent();

            this.Loaded += async (s, args) =>
            {
                await SetupAsync();
            };
            
        }
        private async Task SetupAsync()
        {
            if (!GlobalVar.Javas.Any())
            {
                GlobalVar.Javas = await JavaUtil.EnumerableJavaAsync().ToListAsync();
            }

            ProgressBar.Visibility = Visibility.Collapsed;
        }

        private void myButton_Click(object sender, RoutedEventArgs e)
        {

            Launch();

        }

        public async void Launch()
        {
            var minecraftParser = new MinecraftParser(GlobalVar.RootPaths[GlobalVar.CurrentRootPathIndex]);

            var account = new OfflineAuthenticator().Authenticate("Player");
            var minecraft = minecraftParser.GetMinecraft(GlobalVar.CurrentInstanceId);
            MinecraftRunner runner = new(new LaunchConfig
            {
                Account = account,
                IsEnableIndependency = true,
                JavaPath = minecraft.GetAppropriateJava(GlobalVar.Javas),
                MinMemorySize = 1024,
                MaxMemorySize = 6188
            }, minecraftParser);

            var process = await runner.RunAsync(minecraft);

            // Êä³ö
            process.Started += (_, _) =>
            {
                Debug.WriteLine("Launch successful!");
            };

            // ÍË³ö
            process.OutputLogReceived += (_, args) =>
            {
                Debug.WriteLine(args.Data);
            };
        }

        private void Button_SelectInstance_Click(object sender, RoutedEventArgs e)
        {
            GlobalVar.BreadcrumbItems.Clear();
            GlobalVar.BreadcrumbItems.Add(new("SelectInstance", "Select Instance"));
            Frame.Navigate(typeof(Page_SelectInstance));
        }
    }
}
