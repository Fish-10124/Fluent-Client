using Fluent_Launcher.Assets.Class;
using Fluent_Launcher.Assets.Pages.Home;
using Fluent_Launcher.Assets.Pages.Home.InstanceOption;
using Fluent_Launcher.Assets.Pages.Home.SelectInstance;
using Microsoft.UI.Dispatching;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Media.Animation;
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
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Fluent_Launcher.Assets.Pages.Home
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Page_Home : Page
    {

        private MinecraftEntry? Minecraft;
        private static MinecraftParser? MinecraftParser = new(GlobalVar.Options.RootPaths[GlobalVar.Options.CurrentRootPathIndex].Path);
        private static LaunchConfig? LaunchConfig;
        private IniFile? IniFile;

        public ObservableCollection<OfflinePlayer> OfflinePlayerList = [.. GlobalVar.Options.OfflinePlayers];
        public bool IsLaunchable = false;

        public Page_Home()
        {
            this.InitializeComponent();

            this.Loaded += async (s, args) =>
            {
                await SetupAsync();
            };
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            ComboBox_Name.SelectedIndex = GlobalVar.Options.CurrentOfflinePlayer;

            MinecraftParser = new(GlobalVar.Options.RootPaths[GlobalVar.Options.CurrentRootPathIndex].Path);

            if (string.IsNullOrEmpty(GlobalVar.Options.CurrentInstanceId))
            {
                GlobalVar.Options.CurrentInstanceId = GlobalVar.Options.RootPaths[GlobalVar.Options.CurrentRootPathIndex].LatestInstanceId;
            }

            try
            {
                Minecraft = MinecraftParser.GetMinecraft(GlobalVar.Options.CurrentInstanceId);

                // 读取配置
                IniFile = new(Path.Combine(Path.GetDirectoryName(Minecraft?.ClientJarPath)!, "FLOptions.ini"));
                GlobalVar.IniOptions = Utils.ReadInstanceOptions(IniFile);
            }
            catch (DirectoryNotFoundException)
            {
                Minecraft = null;
                GlobalVar.Options.CurrentInstanceId = "";
            }

        }

        private async Task SetupAsync()
        {
            if (!GlobalVar.Javas.Any())
            {
                GlobalVar.Javas = await JavaUtil.EnumerableJavaAsync().ToListAsync();
            }

            ProgressBar.Visibility = Visibility.Collapsed;
        }

        private void Button_Launch_Click(object sender, RoutedEventArgs e)
        {
            string nameText = ComboBox_Name.Text;
            if (string.IsNullOrEmpty(nameText))
            {
                InfoBar_ErrorInfo.Title = "Wronged player name";
                InfoBar_ErrorInfo.Message = "Name can't be empty!";
                InfoBar_ErrorInfo.IsOpen = true;
                return;
            }
            if (nameText.Trim().Length == 0)
            {
                InfoBar_ErrorInfo.Title = "Wronged player name";
                InfoBar_ErrorInfo.Message = "Is't spaces? What are you doing?";
                InfoBar_ErrorInfo.IsOpen = true;
                return;
            }

            AddOfflineName();

            Launch();
        }

        public async void Launch()
        {
            var account = new OfflineAuthenticator().Authenticate(ComboBox_Name.Text, 
                GlobalVar.Options.OfflinePlayers[GlobalVar.Options.CurrentOfflinePlayer].Uuid);
            LaunchConfig = new()
            {
                Account = account,
                JavaPath = GlobalVar.Javas[GlobalVar.IniOptions!.GameJava],
                IsEnableIndependency = GlobalVar.IniOptions!.Independency,
                MinMemorySize = 1024,
                MaxMemorySize = GlobalVar.IniOptions.MemoryRadio == 2 ? GlobalVar.IniOptions.MemoryCustomize : 6 * 1024,
                LauncherName = GlobalVar.IniOptions.WindowTitle
            };
            MinecraftRunner runner = new(LaunchConfig, MinecraftParser);

            var process = await runner.RunAsync(Minecraft);

            // 输出
            process.Started += (_, _) =>
            {
                Debug.WriteLine("Launch successful!");
            };

            // 退出
            process.OutputLogReceived += (_, args) =>
            {
                Debug.WriteLine(args.Data);
            };
        }

        private void Button_SelectInstance_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Page_SelectInstanceBase));
        }

        private void Button_InstanceOption_Click(object sender, RoutedEventArgs e)
        {
            var instanceTagInfos = Utils.InstanceEntryToTagInfos(Minecraft ?? throw new NullReferenceException("Minecraft was null!"));
            Frame.Navigate(typeof(Page_InstanceOptionBase), instanceTagInfos);
        }

        private void ComboBox_Name_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            GlobalVar.Options.CurrentOfflinePlayer = ComboBox_Name.SelectedIndex;
        }

        private async void HyperlinkButton_OfflineAccountSettings_Click(object sender, RoutedEventArgs e)
        {
            var contentPage = new Page_PlayerOptionsDialog();
            var dialog = new ContentDialog()
            {
                Title = "Player info options",
                PrimaryButtonText = "Confirm",
                DefaultButton = ContentDialogButton.Primary,
                IsSecondaryButtonEnabled = false,
                CloseButtonText = "Cancel",
                Content = contentPage,
                Style = Application.Current.Resources["DefaultContentDialogStyle"] as Style,
                XamlRoot = this.XamlRoot
            };

            AddOfflineName();

            int currentPlayerIndex = GlobalVar.Options.CurrentOfflinePlayer;
            contentPage.Init(ComboBox_Name.Text, GlobalVar.Options.OfflinePlayers[currentPlayerIndex].Uuid);

            // 显示ContentDialog
            var result = await dialog.ShowAsync();

            // 判断结果
            if (result == ContentDialogResult.Primary)
            {
                var playerName = contentPage.GetPlayerName();
                Guid playerUUID;
                if (string.IsNullOrEmpty(playerName))
                {
                    InfoBar_ErrorInfo.Title = "Wronged player name";
                    InfoBar_ErrorInfo.Message = "Name can't be empty!";
                    InfoBar_ErrorInfo.IsOpen = true;
                    return;
                }
                if (playerName.Trim().Length == 0)
                {
                    InfoBar_ErrorInfo.Title = "Wronged player name";
                    InfoBar_ErrorInfo.Message = "Is't spaces? What are you doing?";
                    InfoBar_ErrorInfo.IsOpen = true;
                    return;
                }
                try
                {
                    playerUUID = Guid.Parse(contentPage.GetPlayerUUID().Trim());
                }
                catch (Exception)
                {
                    InfoBar_ErrorInfo.Title = "Wronged UUID";
                    InfoBar_ErrorInfo.Message = "UUID was empty or wronged format!";
                    InfoBar_ErrorInfo.IsOpen = true;
                    return;
                }

                var newProfile = new OfflinePlayer(playerName, playerUUID);
                OfflinePlayerList[currentPlayerIndex].Name = playerName;
                OfflinePlayerList[currentPlayerIndex].Uuid = playerUUID;
                GlobalVar.Options.OfflinePlayers[currentPlayerIndex].Name = playerName;
                GlobalVar.Options.OfflinePlayers[currentPlayerIndex].Uuid = playerUUID;
            }
          
            GlobalVar.Options.CurrentOfflinePlayer = currentPlayerIndex;
            ComboBox_Name.SelectedIndex = currentPlayerIndex;
            
        }

        private void AddOfflineName()
        {
            var name = ComboBox_Name.Text.Trim();
            if (string.IsNullOrEmpty(name))
            {
                return;
            }

            var foundItem = GlobalVar.Options.OfflinePlayers.FirstOrDefault(pair => pair.Name == name);
            if (foundItem == null)
            {
                // 在所有离线玩家中没有当前的玩家名，说明这是一个新的玩家
                // 需要被添加到列表中
                var player = new OfflinePlayer(name, Guid.NewGuid());
                GlobalVar.Options.OfflinePlayers.Add(player);
                OfflinePlayerList.Add(player);

                GlobalVar.Options.CurrentOfflinePlayer = OfflinePlayerList.Count - 1;
            }
        }

        private void Pivot_LoginType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var pivot = sender as Pivot;
            GlobalVar.Options.LoginType = pivot?.SelectedIndex switch
            {
                0 => LoginType.Online,
                1 => LoginType.Offline,
                _ => throw new NotImplementedException()
            };
        }
    }
}
