using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Fluent_Launcher.Assets.Pages.Download.Mods;
using System.Diagnostics;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Fluent_Launcher.Assets.Pages.Home.InstanceOption
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Page_InstanceOptionBase : Page
    {
        public Page_InstanceOptionBase()
        {
            this.InitializeComponent();
            
            BreadcrumbBar_Title.AddItem(new(typeof(Page_InstanceOption), "Instance Option"));
        }

        private void Frame_Content_Navigated(object sender, NavigationEventArgs e)
        {
            Frame frame = (sender as Frame)!;

            if (e.NavigationMode == NavigationMode.Back)
            {
                Debug.WriteLine("GoBack");
            }
            else
            {
                /*
                if (frame.Content.GetType() == typeof(Page_ModsOptions))
                {
                    // VersionManifestEntry instance = ((e.Parameter as List<object>)![1] as VersionManifestEntry)!;
                    // BreadcrumbBar_Title.AddItem(new(typeof(Page_InstanceOption), instance.Id));
                }
                */
            }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            Frame_Content.Navigate(typeof(Page_InstanceOption), e.Parameter);
        }
    }
}
