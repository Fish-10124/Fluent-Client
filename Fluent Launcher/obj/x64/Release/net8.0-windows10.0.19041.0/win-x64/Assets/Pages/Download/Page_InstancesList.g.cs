﻿#pragma checksum "D:\Fish_work\CSProjects\Fluent Launcher\Fluent-Client\Fluent Launcher\Assets\Pages\Download\Page_InstancesList.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "2C3800BE4C5FEB974466C82C90090C231183831C3EB0818FED1307917A213566"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Fluent_Launcher.Assets.Pages.Download
{
    partial class Page_InstancesList : 
        global::Microsoft.UI.Xaml.Controls.Page, 
        global::Microsoft.UI.Xaml.Markup.IComponentConnector
    {

        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.UI.Xaml.Markup.Compiler"," 3.0.0.2503")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 2: // Assets\Pages\Download\Page_InstancesList.xaml line 87
                {
                    this.ProgressBar = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.ProgressBar>(target);
                }
                break;
            case 3: // Assets\Pages\Download\Page_InstancesList.xaml line 47
                {
                    this.ListView_Instances = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.ListView>(target);
                }
                break;
            case 5: // Assets\Pages\Download\Page_InstancesList.xaml line 52
                {
                    global::CommunityToolkit.WinUI.Controls.SettingsCard element5 = global::WinRT.CastExtensions.As<global::CommunityToolkit.WinUI.Controls.SettingsCard>(target);
                    ((global::CommunityToolkit.WinUI.Controls.SettingsCard)element5).Click += this.SettingsCard_Instance_Click;
                }
                break;
            case 8: // Assets\Pages\Download\Page_InstancesList.xaml line 35
                {
                    this.ComboBox_Filter = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.ComboBox>(target);
                    ((global::Microsoft.UI.Xaml.Controls.ComboBox)this.ComboBox_Filter).SelectionChanged += this.ComboBox_Filter_SelectionChanged;
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }


        /// <summary>
        /// GetBindingConnector(int connectionId, object target)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.UI.Xaml.Markup.Compiler"," 3.0.0.2503")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Microsoft.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Microsoft.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}

