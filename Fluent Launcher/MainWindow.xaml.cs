using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.Json;
using Fluent_Launcher.Assets.Class;
using Fluent_Launcher.Assets.Pages.Home;
using Fluent_Launcher.Assets.Pages.Download.Instances;
using Fluent_Launcher.Assets.Pages.Download.Mods;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Windows.Storage;

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

        private static List<NavigationViewItem> HistoryNavigationViewItem = [];

        private static readonly Dictionary<string, KeyValuePair<string, System.Type>> NavigationTagPagePairs = new()
        {
            {"Home", new("Home", typeof(Page_Home))},
            {"Instances", new("Instances", typeof(Page_InstancesBase))},
            {"Mod", new("Mod", typeof(Page_ModsBase))}
        };

        public MainWindow()
        {
            this.InitializeComponent();

            GlobalVar.CurrentWindow = this;
            GlobalVar.CurrentWindow.ExtendsContentIntoTitleBar = true;

            // �ָ����ڿ��
            var localSettings = ApplicationData.Current.LocalSettings;
            // localSettings.Values.Clear(); // ������տ������
            if (localSettings.Values.TryGetValue("WindowWidth", out object? width) && localSettings.Values.TryGetValue("WindowHeight", out object? height))
            {
                this.AppWindow.Resize(new Windows.Graphics.SizeInt32((int)width, (int)height));
            }

            try
            {
                // �������ļ�
                var optionsContent = File.ReadAllText(OptionsFile);
                GlobalVar.Options = JsonSerializer.Deserialize<Options>(optionsContent) ?? throw new NullReferenceException("options file parse faild!");
            }
            catch(Exception)
            {
                // �����κδ���, �����ļ�������, JSON��ʽ����ȷ��, ������һ���µ������ļ�
                GlobalVar.Options = new Options();
            }

            NavigationView.SelectedItem = NavigationView.MenuItems[0];
            Frame_Content.Navigate(typeof(Page_Home));

            HistoryNavigationViewItem = [ NavigationView.SelectedItem as NavigationViewItem ];
        }

        private static void CreateDefaultOptionsFile()
        {
            string optionJson = JsonSerializer.Serialize(GlobalVar.Options, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            File.WriteAllText(OptionsFile, optionJson);
            
        }

        public void NavigateFrame(System.Type pageType, KeyValuePair<string, string> breadcrumbBarHeader)
        {
            if (pageType == null)
            {
                return;
            }
            Frame_Content.Navigate(pageType);
        }

        public static void SaveWindowState(int width, int height)
        {
            var localSettings = ApplicationData.Current.LocalSettings;

            // ������
            localSettings.Values["WindowWidth"] = width;
            localSettings.Values["WindowHeight"] = height;
        }

        private void Window_Closed(object sender, WindowEventArgs args)
        {
            Frame_Content.Navigate(typeof(Page_Home));

            var bounds = this.Bounds;
            SaveWindowState((int)bounds.Width, (int)bounds.Height);

            // ���û��OptionsFile������һ��
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

        private void NavigationView_BackRequested(NavigationView sender, NavigationViewBackRequestedEventArgs args)
        {
            Frame_Content.GoBack();
            ChangeNavigationItem(true, HistoryNavigationViewItem[^2]);
            HistoryNavigationViewItem.RemoveAt(HistoryNavigationViewItem.Count - 1);
            if (HistoryNavigationViewItem.Count <= 1)
            {
                NavigationView.IsBackEnabled = false;
            }
        }

        private void ChangeNavigationItem(bool isBack, NavigationViewItem args)
        {

            if (args.Content.ToString() == "settings")
            {
                // Frame_Content.Navigate(typeof(Page_Settings));
            }
            else
            {
                if (args == null || !args.SelectsOnInvoked) return;

                NavigationTagPagePairs.TryGetValue(args.Tag.ToString()!, out var page);
                NavigateFrame(page.Value, new(args.Tag.ToString()!, page.Key));
            }

            if (isBack)
            {
                NavigationView.ItemInvoked -= NavigationView_ItemInvoked;
                NavigationView.SelectedItem = args;
                NavigationView.ItemInvoked += NavigationView_ItemInvoked;
            }
            else
            {
                NavigationView.IsBackEnabled = true;
            }
        }

        private void NavigationView_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            NavigationViewItem navigationItem = (args.InvokedItemContainer as NavigationViewItem)!;

            if (navigationItem.SelectsOnInvoked)
            {
                NavigationTagPagePairs.TryGetValue(navigationItem.Tag.ToString()!, out var page);
                if (Frame_Content.CurrentSourcePageType.Equals(page.Value))
                {
                    return;
                }

                if (navigationItem.Equals(HistoryNavigationViewItem[^1]))
                {
                    ChangeNavigationItem(true, navigationItem!);
                }
                else
                {
                    HistoryNavigationViewItem.Add(navigationItem!);
                    ChangeNavigationItem(false, navigationItem!);
                }
            }
        }
    }
}
