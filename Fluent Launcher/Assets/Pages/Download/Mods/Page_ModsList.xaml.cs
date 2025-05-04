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
using System.ComponentModel;
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
    public sealed partial class Page_ModsList : Page, INotifyPropertyChanged
    {
        private const string CfApiKey = "$2a$10$VGFy23o3WipEqFXpGyd67.OfYA13D/9NUym2jGnp3hznXKCmcHala";
        private const int CfMcGameId = 432;
        private const int CfModClassId = 6, CfModPackClassId = 4471;
        private const int CfPageSize = 50;

        private ObservableCollection<ModListShow> ModList = [];
        private int _currentPage = 1;

        private int CurrentPage
        {
            get => _currentPage;
            set
            {
                if (_currentPage != value)
                {
                    _currentPage = value;
                    OnPropertyChanged(nameof(CurrentPage)); // ´¥·¢ UI ¸üÐÂ
                }
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public Page_ModsList()
        {
            this.InitializeComponent();

            _ = GetMods();
        }

        private async Task GetMods()
        {
            ModList.Clear();
            Grid_PageFooter.Visibility = Visibility.Collapsed;
            ProgressBar.Visibility = Visibility.Visible;

            var cfApiClient = new ApiClient(CfApiKey);
            var mods = (await cfApiClient.SearchModsAsync(
                gameId: CfMcGameId, 
                classId: CfModClassId,
                sortField: ModsSearchSortField.Popularity,
                index: (CurrentPage - 1) * CfPageSize)).Data;
                     
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
            Grid_PageFooter.Visibility = Visibility.Visible;
        }

        private void HyperlinkButton_PageChange_Click(object sender, RoutedEventArgs e)
        {
            HyperlinkButton button = (sender as HyperlinkButton)!;
            switch (button.Name)
            {
                case "HyperlinkButton_First":
                    CurrentPage = 1;
                    break;

                case "HyperlinkButton_Previous":
                    CurrentPage--;
                    break;

                case "HyperlinkButton_Next":
                    CurrentPage++;
                    break;

                default:
                    break;
            }

            _ = GetMods();
        }
    }
}
