using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text.Json;
using System.Threading;
using Fluent_Launcher.Assets.Class;
using Fluent_Launcher.Assets.Pages;
using Fluent_Launcher.Assets.Pages.Download;
using Flurl.Util;
using Microsoft.UI;
using Microsoft.UI.Windowing;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using MinecraftLaunch.Components.Parser;
using MinecraftLaunch.Utilities;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.ViewManagement;
using WinRT;
using Type = System.Type;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Fluent_Launcher
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {

        private static readonly string OptionsFile = Path.Join(GlobalVar.OptionsFolder, GlobalVar.OptionsFile);

        public MainWindow()
        {
            this.InitializeComponent();

            Window window = this;
            window.ExtendsContentIntoTitleBar = true;

            // 恢复窗口宽高
            var localSettings = ApplicationData.Current.LocalSettings;
            // localSettings.Values.Clear(); // 用于清空宽高设置
            if (localSettings.Values.TryGetValue("WindowWidth", out object? width) && localSettings.Values.TryGetValue("WindowHeight", out object? height))
            {
                this.AppWindow.Resize(new Windows.Graphics.SizeInt32((int)width, (int)height));
            }

            FileInfo fileInfo = new(OptionsFile);

            try
            {
                // 读配置文件
                var optionsContent = File.ReadAllText(OptionsFile);
                GlobalVar.Options = JsonSerializer.Deserialize<Options>(optionsContent) ?? throw new NullReferenceException("options file parse faild!");
            }
            catch(Exception)
            {
                // 出现任何错误, 例如文件不存在, JSON格式不正确等, 都创建一个新的配置文件
                GlobalVar.Options = new Options();
            }

            NavigationView.SelectedItem = NavigationView.MenuItems[0];
            Frame_Content.Navigate(typeof(Page_Home));
        }

        private static void CreateDefaultOptionsFile()
        {
            string optionJson = JsonSerializer.Serialize(GlobalVar.Options, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            File.WriteAllText(OptionsFile, optionJson);
            
        }

        private void NavigationView_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            if (args.IsSettingsInvoked)
            {
                //Frame_Content.Navigate(typeof(Page_Settings));
            }
            else
            {
                var invokedItem = args.InvokedItemContainer as NavigationViewItem;

                if (invokedItem == null || !invokedItem.SelectsOnInvoked) return;

                NavigateFrame(invokedItem.Tag switch
                {
                    "Home" => typeof(Page_Home),
                    "Instances" => typeof(Page_InstancesList),
                    "Mod" => typeof(Page_DownloadMod),
                    _ => typeof(Page_Home)
                }, new(invokedItem.Tag.ToString() ?? "",
                invokedItem.Content.ToString() == "Home" ? // 如果在主页，就不显示标题
                "" : invokedItem.Content.ToString() ?? ""));
            }
        }

        public void NavigateFrame(Type pageType, KeyValuePair<string, string> breadcrumbBarHeader)
        {
            if (pageType == null)
            {
                return;
            }
            GlobalVar.BreadcrumbItems.Clear();
            GlobalVar.BreadcrumbItems.Add(breadcrumbBarHeader);
            Frame_Content.Navigate(pageType);
        }

        public static void SaveWindowState(int width, int height)
        {
            var localSettings = ApplicationData.Current.LocalSettings;

            // 保存宽高
            localSettings.Values["WindowWidth"] = width;
            localSettings.Values["WindowHeight"] = height;
        }

        private void Window_Closed(object sender, WindowEventArgs args)
        {
            Frame_Content.Navigate(typeof(Page_Home));

            var bounds = this.Bounds;
            SaveWindowState((int)bounds.Width, (int)bounds.Height);

            // 如果没有OptionsFile，创建一个
            if (!File.Exists(OptionsFile))
            {
                if (!Directory.Exists(GlobalVar.OptionsFolder))
                {
                    Directory.CreateDirectory(GlobalVar.OptionsFolder);
                }
            }

            CreateDefaultOptionsFile();

        }

        private void Frame_Content_Navigated(object sender, Microsoft.UI.Xaml.Navigation.NavigationEventArgs e)
        {
            GC.Collect();
        }

        private void BreadcrumbBar_Header_ItemClicked(BreadcrumbBar sender, BreadcrumbBarItemClickedEventArgs args)
        {
            if (GlobalVar.BreadcrumbItems[args.Index].Key == "Instances")
            {
                NavigateFrame(typeof(Page_InstancesList), new("Instances", "Instances"));
            }
        }

    }
}
