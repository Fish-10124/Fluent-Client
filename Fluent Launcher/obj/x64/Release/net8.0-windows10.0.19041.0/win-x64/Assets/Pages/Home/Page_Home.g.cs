﻿#pragma checksum "D:\Fish_work\CSProjects\Fluent Launcher\Fluent-Client\Fluent Launcher\Assets\Pages\Home\Page_Home.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "E74577A1E1FCDF59D9BB59EAA01541F7F1B44F46BEFD1A7D8F357D10C9F798FE"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Fluent_Launcher.Assets.Pages
{
    partial class Page_Home : 
        global::Microsoft.UI.Xaml.Controls.Page, 
        global::Microsoft.UI.Xaml.Markup.IComponentConnector
    {
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.UI.Xaml.Markup.Compiler"," 3.0.0.2503")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private static class XamlBindingSetters
        {
            public static void Set_Microsoft_UI_Xaml_Controls_Control_IsEnabled(global::Microsoft.UI.Xaml.Controls.Control obj, global::System.Boolean value)
            {
                obj.IsEnabled = value;
            }
            public static void Set_Microsoft_UI_Xaml_Controls_Pivot_SelectedIndex(global::Microsoft.UI.Xaml.Controls.Pivot obj, global::System.Int32 value)
            {
                obj.SelectedIndex = value;
            }
            public static void Set_Microsoft_UI_Xaml_Controls_TextBlock_Text(global::Microsoft.UI.Xaml.Controls.TextBlock obj, global::System.String value, string targetNullValue)
            {
                if (value == null && targetNullValue != null)
                {
                    value = targetNullValue;
                }
                obj.Text = value ?? global::System.String.Empty;
            }
            public static void Set_Microsoft_UI_Xaml_Controls_ItemsControl_ItemsSource(global::Microsoft.UI.Xaml.Controls.ItemsControl obj, global::System.Object value, string targetNullValue)
            {
                if (value == null && targetNullValue != null)
                {
                    value = (global::System.Object) global::Microsoft.UI.Xaml.Markup.XamlBindingHelper.ConvertValue(typeof(global::System.Object), targetNullValue);
                }
                obj.ItemsSource = value;
            }
        };

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.UI.Xaml.Markup.Compiler"," 3.0.0.2503")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private partial class Page_Home_obj1_Bindings :
            global::Microsoft.UI.Xaml.Markup.IComponentConnector,
            IPage_Home_Bindings
        {
            private global::Fluent_Launcher.Assets.Pages.Page_Home dataRoot;
            private bool initialized = false;
            private const int NOT_PHASED = (1 << 31);
            private const int DATA_CHANGED = (1 << 30);
            private global::Microsoft.UI.Xaml.ResourceDictionary localResources;
            private global::System.WeakReference<global::Microsoft.UI.Xaml.FrameworkElement> converterLookupRoot;

            // Fields for each control that has bindings.
            private global::Microsoft.UI.Xaml.Controls.Pivot obj4;
            private global::Microsoft.UI.Xaml.Controls.Button obj5;
            private global::Microsoft.UI.Xaml.Controls.TextBlock obj8;
            private global::Microsoft.UI.Xaml.Controls.ComboBox obj9;

            private Page_Home_obj1_BindingsTracking bindingsTracking;

            public Page_Home_obj1_Bindings()
            {
                this.bindingsTracking = new Page_Home_obj1_BindingsTracking(this);
            }

            // IComponentConnector

            public void Connect(int connectionId, global::System.Object target)
            {
                switch(connectionId)
                {
                    case 4: // Assets\Pages\Home\Page_Home.xaml line 20
                        this.obj4 = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.Pivot>(target);
                        break;
                    case 5: // Assets\Pages\Home\Page_Home.xaml line 55
                        this.obj5 = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.Button>(target);
                        break;
                    case 8: // Assets\Pages\Home\Page_Home.xaml line 62
                        this.obj8 = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.TextBlock>(target);
                        break;
                    case 9: // Assets\Pages\Home\Page_Home.xaml line 37
                        this.obj9 = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.ComboBox>(target);
                        break;
                    default:
                        break;
                }
            }
                        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.UI.Xaml.Markup.Compiler"," 3.0.0.2503")]
                        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
                        public global::Microsoft.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target) 
                        {
                            return null;
                        }

            // IPage_Home_Bindings

            public void Initialize()
            {
                if (!this.initialized)
                {
                    this.Update();
                }
            }
            
            public void Update()
            {
                this.Update_(this.dataRoot, NOT_PHASED);
                this.initialized = true;
            }

            public void StopTracking()
            {
                this.bindingsTracking.ReleaseAllListeners();
                this.initialized = false;
            }

            public void DisconnectUnloadedObject(int connectionId)
            {
                throw new global::System.ArgumentException("No unloadable elements to disconnect.");
            }

            public bool SetDataRoot(global::System.Object newDataRoot)
            {
                this.bindingsTracking.ReleaseAllListeners();
                if (newDataRoot != null)
                {
                    this.dataRoot = global::WinRT.CastExtensions.As<global::Fluent_Launcher.Assets.Pages.Page_Home>(newDataRoot);
                    return true;
                }
                return false;
            }

            public void Activated(object obj, global::Microsoft.UI.Xaml.WindowActivatedEventArgs data)
            {
                this.Initialize();
            }

            public void Loading(global::Microsoft.UI.Xaml.FrameworkElement src, object data)
            {
                this.Initialize();
            }
            public void SetConverterLookupRoot(global::Microsoft.UI.Xaml.FrameworkElement rootElement)
            {
                this.converterLookupRoot = new global::System.WeakReference<global::Microsoft.UI.Xaml.FrameworkElement>(rootElement);
            }

            public global::Microsoft.UI.Xaml.Data.IValueConverter LookupConverter(string key)
            {
                if (this.localResources == null)
                {
                    global::Microsoft.UI.Xaml.FrameworkElement rootElement;
                    this.converterLookupRoot.TryGetTarget(out rootElement);
                    this.localResources = rootElement.Resources;
                    this.converterLookupRoot = null;
                }
                return (global::Microsoft.UI.Xaml.Data.IValueConverter) (this.localResources.ContainsKey(key) ? this.localResources[key] : global::Microsoft.UI.Xaml.Application.Current.Resources[key]);
            }

            // Update methods for each path node used in binding steps.
            private void Update_(global::Fluent_Launcher.Assets.Pages.Page_Home obj, int phase)
            {
                if (obj != null)
                {
                    if ((phase & (NOT_PHASED | (1 << 0))) != 0)
                    {
                        this.Update_OfflinePlayerList(obj.OfflinePlayerList, phase);
                    }
                }
                this.Update_Fluent_Launcher_Assets_Class_GlobalVar_Options(global::Fluent_Launcher.Assets.Class.GlobalVar.Options, phase);
            }
            private void Update_Fluent_Launcher_Assets_Class_GlobalVar_Options(global::Fluent_Launcher.Assets.Class.Options obj, int phase)
            {
                if (obj != null)
                {
                    if ((phase & (NOT_PHASED | (1 << 0))) != 0)
                    {
                        this.Update_Fluent_Launcher_Assets_Class_GlobalVar_Options_LoginType(obj.LoginType, phase);
                        this.Update_Fluent_Launcher_Assets_Class_GlobalVar_Options_CurrentInstanceId(obj.CurrentInstanceId, phase);
                    }
                }
                if ((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    // Assets\Pages\Home\Page_Home.xaml line 55
                    XamlBindingSetters.Set_Microsoft_UI_Xaml_Controls_Control_IsEnabled(this.obj5, (global::System.Boolean)this.LookupConverter("InstanceEnableConverter").Convert(obj, typeof(global::System.Boolean), null, null));
                }
            }
            private void Update_Fluent_Launcher_Assets_Class_GlobalVar_Options_LoginType(global::Fluent_Launcher.Assets.Class.LoginType obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    // Assets\Pages\Home\Page_Home.xaml line 20
                    XamlBindingSetters.Set_Microsoft_UI_Xaml_Controls_Pivot_SelectedIndex(this.obj4, (global::System.Int32)this.LookupConverter("LoginTypeToIndexConverter").Convert(obj, typeof(global::System.Int32), null, null));
                }
            }
            private void Update_Fluent_Launcher_Assets_Class_GlobalVar_Options_CurrentInstanceId(global::System.String obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    // Assets\Pages\Home\Page_Home.xaml line 62
                    XamlBindingSetters.Set_Microsoft_UI_Xaml_Controls_TextBlock_Text(this.obj8, (global::System.String)this.LookupConverter("InstanceIdConverter").Convert(obj, typeof(global::System.String), null, null), null);
                }
            }
            private void Update_OfflinePlayerList(global::System.Collections.ObjectModel.ObservableCollection<global::System.Collections.Generic.KeyValuePair<global::System.String, global::System.Guid>> obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    // Assets\Pages\Home\Page_Home.xaml line 37
                    XamlBindingSetters.Set_Microsoft_UI_Xaml_Controls_ItemsControl_ItemsSource(this.obj9, obj, null);
                }
            }

            [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.UI.Xaml.Markup.Compiler"," 3.0.0.2503")]
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            private class Page_Home_obj1_BindingsTracking
            {
                private global::System.WeakReference<Page_Home_obj1_Bindings> weakRefToBindingObj; 

                public Page_Home_obj1_BindingsTracking(Page_Home_obj1_Bindings obj)
                {
                    weakRefToBindingObj = new global::System.WeakReference<Page_Home_obj1_Bindings>(obj);
                }

                public Page_Home_obj1_Bindings TryGetBindingObject()
                {
                    Page_Home_obj1_Bindings bindingObject = null;
                    if (weakRefToBindingObj != null)
                    {
                        weakRefToBindingObj.TryGetTarget(out bindingObject);
                        if (bindingObject == null)
                        {
                            weakRefToBindingObj = null;
                            ReleaseAllListeners();
                        }
                    }
                    return bindingObject;
                }

                public void ReleaseAllListeners()
                {
                }

            }
        }

        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.UI.Xaml.Markup.Compiler"," 3.0.0.2503")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 2: // Assets\Pages\Home\Page_Home.xaml line 79
                {
                    this.ProgressBar = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.ProgressBar>(target);
                }
                break;
            case 3: // Assets\Pages\Home\Page_Home.xaml line 81
                {
                    this.InfoBar_ErrorInfo = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.InfoBar>(target);
                }
                break;
            case 4: // Assets\Pages\Home\Page_Home.xaml line 20
                {
                    this.Pivot_LoginType = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.Pivot>(target);
                    ((global::Microsoft.UI.Xaml.Controls.Pivot)this.Pivot_LoginType).SelectionChanged += this.Pivot_LoginType_SelectionChanged;
                }
                break;
            case 5: // Assets\Pages\Home\Page_Home.xaml line 55
                {
                    this.Button_Launch = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.Button>(target);
                    ((global::Microsoft.UI.Xaml.Controls.Button)this.Button_Launch).Click += this.Button_Launch_Click;
                }
                break;
            case 6: // Assets\Pages\Home\Page_Home.xaml line 72
                {
                    this.Button_SelectInstance = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.Button>(target);
                    ((global::Microsoft.UI.Xaml.Controls.Button)this.Button_SelectInstance).Click += this.Button_SelectInstance_Click;
                }
                break;
            case 7: // Assets\Pages\Home\Page_Home.xaml line 73
                {
                    this.Button_InstanceOption = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.Button>(target);
                    ((global::Microsoft.UI.Xaml.Controls.Button)this.Button_InstanceOption).Click += this.Button_InstanceOption_Click;
                }
                break;
            case 9: // Assets\Pages\Home\Page_Home.xaml line 37
                {
                    this.ComboBox_Name = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.ComboBox>(target);
                    ((global::Microsoft.UI.Xaml.Controls.ComboBox)this.ComboBox_Name).SelectionChanged += this.ComboBox_Name_SelectionChanged;
                }
                break;
            case 10: // Assets\Pages\Home\Page_Home.xaml line 41
                {
                    this.HyperlinkButton_OfflineAccountSettings = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.HyperlinkButton>(target);
                    ((global::Microsoft.UI.Xaml.Controls.HyperlinkButton)this.HyperlinkButton_OfflineAccountSettings).Click += this.HyperlinkButton_OfflineAccountSettings_Click;
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
            switch(connectionId)
            {
            case 1: // Assets\Pages\Home\Page_Home.xaml line 2
                {                    
                    global::Microsoft.UI.Xaml.Controls.Page element1 = (global::Microsoft.UI.Xaml.Controls.Page)target;
                    Page_Home_obj1_Bindings bindings = new Page_Home_obj1_Bindings();
                    returnValue = bindings;
                    bindings.SetDataRoot(this);
                    bindings.SetConverterLookupRoot(this);
                    this.Bindings = bindings;
                    element1.Loading += bindings.Loading;
                }
                break;
            }
            return returnValue;
        }
    }
}

