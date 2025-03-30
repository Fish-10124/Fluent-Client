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
using MinecraftLaunch.Launch;
using MinecraftLaunch.Utilities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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
        }

        private void myButton_Click(object sender, RoutedEventArgs e)
        {

            launch();

        }

        public async void launch()
        {
            var minecraftParser = new MinecraftParser("D:\\Download\\PCL\\.minecraft");

            var account = new OfflineAuthenticator().Authenticate("Player");
            var minecraft = minecraftParser.GetMinecraft("tacz-1.20.1-Forge_47.4.0");
            MinecraftRunner runner = new(new LaunchConfig
            {
                Account = account,
                IsEnableIndependency = true,
                JavaPath = new JavaEntry()
                {
                    Is64bit = true,
                    JavaPath = "D:\\java\\jdk-22\\bin\\javaw.exe"
                },
                MinMemorySize = 1024,
                MaxMemorySize = 6188
            }, minecraftParser);

            var process = await runner.RunAsync(minecraft);

            // ���
            process.Started += (_, _) =>
            {
                Debug.WriteLine("Launch successful!");
            };

            // �˳�
            process.OutputLogReceived += (_, args) =>
            {
                Debug.WriteLine(args.Data);
            };
        }
    }
}
