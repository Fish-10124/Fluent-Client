﻿#pragma checksum "D:\Fish_work\CSProjects\Fluent Launcher\Fluent-Client\Fluent Launcher\Assets\Pages\Home\Page_SelectInstance.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "3E21C2C061F246A61905030A34822F4D0761BFA0BB3C58D1F8AB51A4486D8B8D"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Fluent_Launcher.Assets.Pages.Home
{
    partial class Page_SelectInstance : 
        global::Microsoft.UI.Xaml.Controls.Page, 
        global::Microsoft.UI.Xaml.Markup.IComponentConnector
    {
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.UI.Xaml.Markup.Compiler"," 3.0.0.2503")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private static class XamlBindingSetters
        {
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
        private partial class Page_SelectInstance_obj1_Bindings :
            global::Microsoft.UI.Xaml.Markup.IDataTemplateComponent,
            global::Microsoft.UI.Xaml.Markup.IXamlBindScopeDiagnostics,
            global::Microsoft.UI.Xaml.Markup.IComponentConnector,
            IPage_SelectInstance_Bindings
        {
            private global::Fluent_Launcher.Assets.Pages.Home.Page_SelectInstance dataRoot;
            private bool initialized = false;
            private const int NOT_PHASED = (1 << 31);
            private const int DATA_CHANGED = (1 << 30);

            // Fields for each control that has bindings.
            private global::Microsoft.UI.Xaml.Controls.ListView obj2;
            private global::Microsoft.UI.Xaml.Controls.ListBox obj3;

            // Static fields for each binding's enabled/disabled state
            private static bool isobj2ItemsSourceDisabled = false;
            private static bool isobj3ItemsSourceDisabled = false;

            public Page_SelectInstance_obj1_Bindings()
            {
            }

            public void Disable(int lineNumber, int columnNumber)
            {
                if (lineNumber == 20 && columnNumber == 39)
                {
                    isobj2ItemsSourceDisabled = true;
                }
                else if (lineNumber == 36 && columnNumber == 55)
                {
                    isobj3ItemsSourceDisabled = true;
                }
            }

            // IComponentConnector

            public void Connect(int connectionId, global::System.Object target)
            {
                switch(connectionId)
                {
                    case 2: // Assets\Pages\Home\Page_SelectInstance.xaml line 20
                        this.obj2 = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.ListView>(target);
                        break;
                    case 3: // Assets\Pages\Home\Page_SelectInstance.xaml line 36
                        this.obj3 = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.ListBox>(target);
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

            // IDataTemplateComponent

            public void ProcessBindings(global::System.Object item, int itemIndex, int phase, out int nextPhase)
            {
                nextPhase = -1;
            }

            public void Recycle()
            {
                return;
            }

            // IPage_SelectInstance_Bindings

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
            }

            public void DisconnectUnloadedObject(int connectionId)
            {
                throw new global::System.ArgumentException("No unloadable elements to disconnect.");
            }

            public bool SetDataRoot(global::System.Object newDataRoot)
            {
                if (newDataRoot != null)
                {
                    this.dataRoot = global::WinRT.CastExtensions.As<global::Fluent_Launcher.Assets.Pages.Home.Page_SelectInstance>(newDataRoot);
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

            // Update methods for each path node used in binding steps.
            private void Update_(global::Fluent_Launcher.Assets.Pages.Home.Page_SelectInstance obj, int phase)
            {
                if (obj != null)
                {
                    if ((phase & (NOT_PHASED | (1 << 0))) != 0)
                    {
                        this.Update_RootPaths(obj.RootPaths, phase);
                        this.Update_Instances(obj.Instances, phase);
                    }
                }
            }
            private void Update_RootPaths(global::System.Collections.ObjectModel.ObservableCollection<global::Fluent_Launcher.Assets.Class.RootPathListShow> obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    // Assets\Pages\Home\Page_SelectInstance.xaml line 20
                    if (!isobj2ItemsSourceDisabled)
                    {
                        XamlBindingSetters.Set_Microsoft_UI_Xaml_Controls_ItemsControl_ItemsSource(this.obj2, obj, null);
                    }
                }
            }
            private void Update_Instances(global::System.Collections.Generic.List<global::MinecraftLaunch.Base.Models.Game.MinecraftEntry> obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    // Assets\Pages\Home\Page_SelectInstance.xaml line 36
                    if (!isobj3ItemsSourceDisabled)
                    {
                        XamlBindingSetters.Set_Microsoft_UI_Xaml_Controls_ItemsControl_ItemsSource(this.obj3, obj, null);
                    }
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
            case 3: // Assets\Pages\Home\Page_SelectInstance.xaml line 36
                {
                    this.ListBox_AllInstance = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.ListBox>(target);
                    ((global::Microsoft.UI.Xaml.Controls.ListBox)this.ListBox_AllInstance).SelectionChanged += this.ListBox_AllInstance_SelectionChanged;
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
            case 1: // Assets\Pages\Home\Page_SelectInstance.xaml line 2
                {                    
                    global::Microsoft.UI.Xaml.Controls.Page element1 = (global::Microsoft.UI.Xaml.Controls.Page)target;
                    Page_SelectInstance_obj1_Bindings bindings = new Page_SelectInstance_obj1_Bindings();
                    returnValue = bindings;
                    bindings.SetDataRoot(this);
                    this.Bindings = bindings;
                    element1.Loading += bindings.Loading;
                    global::Microsoft.UI.Xaml.Markup.XamlBindingHelper.SetDataTemplateComponent(element1, bindings);
                }
                break;
            }
            return returnValue;
        }
    }
}

