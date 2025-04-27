using CurseForge.APIClient;
using CurseForge.APIClient.Models;
using CurseForge.APIClient.Models.Mods;
using Fluent_Launcher.Assets.Class;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Media.Imaging;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Fluent_Launcher.Assets.Pages.Download.Mods
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Page_ModsList : Page
    {
        private ObservableCollection<ModListShow> ModList = [];

        public Page_ModsList()
        {
            this.InitializeComponent();

            _ = Test();
        }

        public async Task Test()
        {
            var cfApiClient = new ApiClient(GlobalVar.CfApiKey);
            var mods = (await cfApiClient.SearchModsAsync(
                gameId: GlobalVar.CfMcGameId, 
                classId: GlobalVar.CfModClassId,
                sortField: ModsSearchSortField.Popularity)).Data;

            foreach (var item in mods)
            {
                List<string> categories = [.. item.Categories.Select(category => Class.Convert.ConvertCfModType(category.Slug)!)];

                ModList.Add(new(item.Name, 
                    item.Summary, 
                    categories, 
                    item.DownloadCount.ToString("N0"), 
                    item.DateReleased.LocalDateTime.ToString("d"), 
                    new BitmapImage(new Uri(item.Logo.Url))));
                
            }

            ProgressBar.Visibility = Visibility.Collapsed;
        }
    }
}
