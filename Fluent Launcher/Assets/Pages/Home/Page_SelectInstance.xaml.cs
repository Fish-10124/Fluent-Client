using Fluent_Launcher.Assets.Class;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using MinecraftLaunch.Base.Models.Game;
using MinecraftLaunch.Components.Parser;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Fluent_Launcher.Assets.Pages.Home
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Page_SelectInstance : Page
    {
        private ObservableCollection<RootPathListShow> RootPaths = [];
        private List<MinecraftEntry> Instances = [];

        public Page_SelectInstance()
        {
            this.InitializeComponent();

            foreach (var item in GlobalVar.RootPaths)
            {
                RootPaths.Add(new()
                {
                    FolderName = Path.GetFileName(item) ?? item,
                    FolderPath = item
                });
            }

            MinecraftParser mcParser = new(GlobalVar.RootPaths[GlobalVar.CurrentRootPathIndex]);
            Instances = mcParser.GetMinecrafts();
        }

        private void ListBox_AllInstance_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var listBox = sender as ListBox;
            if (listBox == null)
            {
                return;
            }
            // Instances[listBox.SelectedIndex]
        }
    }
}
