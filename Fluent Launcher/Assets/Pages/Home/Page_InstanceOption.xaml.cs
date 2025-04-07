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
using MinecraftLaunch.Components.Parser;
using MinecraftLaunch.Utilities;
using System.Management;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Fluent_Launcher.Assets.Pages.Home
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Page_InstanceOption : Page
    {
        private static readonly MinecraftParser McParser = new(GlobalVar.RootPaths[GlobalVar.CurrentRootPathIndex]);
        private readonly IniFile IniFile = new(Path.Combine(Path.GetDirectoryName(McParser.GetMinecraft(GlobalVar.CurrentInstanceId).ClientJarPath)!, "FLOptions.ini"));

        public SettingsCardTagDescriptionInfos? InstanceDetails;

        public Page_InstanceOption()
        {
            this.InitializeComponent();

            ulong totalMemory;
            try
            {
                // 获取设备的总运行内存
                var searcher = new ManagementObjectSearcher("SELECT TotalPhysicalMemory FROM Win32_ComputerSystem");
                foreach(var obj in searcher.Get())
                {
                    totalMemory = (ulong)obj["TotalPhysicalMemory"];

                    Slider_Memory.Maximum = totalMemory / (1024 * 1024 * 1024);
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Faild to get RAM: {e.Message}");
            }

        }

        // 导航到这个页面的时候读配置文件
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            // 获取动画对象并保存
            var pendingAnimation = ConnectedAnimationService.GetForCurrentView().GetAnimation("SelectInstanceToOptionAnimation");

            InstanceDetails = e.Parameter as SettingsCardTagDescriptionInfos ?? throw new NullReferenceException("Instance was null!");

            // 使用延迟启动动画
            Grid_InstanceDetails.Loaded += async (s, args) =>
            {
                await Task.Delay(GlobalVar.AnimationDelay);
                pendingAnimation?.TryStart(Grid_InstanceDetails);
            };

            // 读取配置
            GlobalVar.IniOptions = Utils.ReadInstanceOptions(IniFile);
        }

        // 导航到别的页面的时候写配置文件
        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);

            // 设置配置
            static string? GetNullableText(string text) => string.IsNullOrEmpty(text) ? null : text;

            GlobalVar.IniOptions = new()
            {
                InstanceDescription = GetNullableText(TextBox_Description.Text),
                Independent = ToggleSwitch_Independent.IsOn,
                WindowTitle = GetNullableText(TextBox_WindowTitle.Text),
                CustomInfomation = GetNullableText(TextBox_CustomInfomation.Text),
                GameJava = string.IsNullOrEmpty(ComboBox_GameJava.Text) ? 0 : ComboBox_GameJava.SelectedIndex,
                MemoryRadio = RadioButtons_Memory.SelectedIndex,
                MemoryCustomize = (int)Slider_Memory.Value * 1024
            };

            // 先清空配置文件
            File.WriteAllText(IniFile.FilePath, string.Empty);
            // 写配置文件
            WriteIni(InstanceOptions.Keys.InstanceDescription, GlobalVar.IniOptions?.InstanceDescription);
            WriteIni(InstanceOptions.Keys.Independent, GlobalVar.IniOptions?.Independent);
            WriteIni(InstanceOptions.Keys.WindowTitle, GlobalVar.IniOptions?.WindowTitle);
            WriteIni(InstanceOptions.Keys.CustomInfomation, GlobalVar.IniOptions?.CustomInfomation);
            WriteIni(InstanceOptions.Keys.GameJava, GlobalVar.IniOptions?.GameJava);
            WriteIni(InstanceOptions.Keys.MemoryRadio, GlobalVar.IniOptions?.MemoryRadio);
            WriteIni(InstanceOptions.Keys.MemoryCustomize, GlobalVar.IniOptions?.MemoryCustomize);
        }

        // 如果值为空，就不写
        private void WriteIni(string key, object? value)
        {
            if (value != null)
            {
                IniFile.Write(InstanceOptions.IniSection, key, value.ToString()!);
            }
        }

    }
}
