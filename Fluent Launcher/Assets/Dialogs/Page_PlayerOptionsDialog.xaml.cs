using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Fluent_Launcher.Assets.Dialogs
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Page_PlayerOptionsDialog : Page
    {
        public Page_PlayerOptionsDialog()
        {
            this.InitializeComponent();
        }

        public string GetPlayerName()
        {
            return TextBox_Name.Text;
        }

        public string GetPlayerUUID()
        {
            return TextBox_UUID.Text;
        }

        public void Init(string playerName, Guid uuid)
        {
            TextBox_Name.Text = playerName;
            TextBox_UUID.Text = uuid.ToString();
        }
    }
}
