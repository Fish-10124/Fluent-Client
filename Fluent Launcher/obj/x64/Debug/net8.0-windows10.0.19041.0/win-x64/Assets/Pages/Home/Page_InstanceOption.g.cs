﻿#pragma checksum "D:\Fish_work\CSProjects\Fluent Launcher\Fluent-Client\Fluent Launcher\Assets\Pages\Home\Page_InstanceOption.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "05FA1FFE1C1A7C3A5EBFCC0C44B088831DD8896A2AA2C735C6E23191BC15E155"
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
    partial class Page_InstanceOption : 
        global::Microsoft.UI.Xaml.Controls.Page, 
        global::Microsoft.UI.Xaml.Markup.IComponentConnector
    {
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.UI.Xaml.Markup.Compiler"," 3.0.0.2503")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private static class XamlBindingSetters
        {
            public static void Set_Microsoft_UI_Xaml_Controls_RadioButtons_SelectedIndex(global::Microsoft.UI.Xaml.Controls.RadioButtons obj, global::System.Int32 value)
            {
                obj.SelectedIndex = value;
            }
            public static void Set_Microsoft_UI_Xaml_Controls_Primitives_RangeBase_Value(global::Microsoft.UI.Xaml.Controls.Primitives.RangeBase obj, global::System.Double value)
            {
                obj.Value = value;
            }
            public static void Set_Microsoft_UI_Xaml_Controls_ItemsControl_ItemsSource(global::Microsoft.UI.Xaml.Controls.ItemsControl obj, global::System.Object value, string targetNullValue)
            {
                if (value == null && targetNullValue != null)
                {
                    value = (global::System.Object) global::Microsoft.UI.Xaml.Markup.XamlBindingHelper.ConvertValue(typeof(global::System.Object), targetNullValue);
                }
                obj.ItemsSource = value;
            }
            public static void Set_Microsoft_UI_Xaml_Controls_Primitives_Selector_SelectedIndex(global::Microsoft.UI.Xaml.Controls.Primitives.Selector obj, global::System.Int32 value)
            {
                obj.SelectedIndex = value;
            }
            public static void Set_Microsoft_UI_Xaml_Controls_TextBox_Text(global::Microsoft.UI.Xaml.Controls.TextBox obj, global::System.String value, string targetNullValue)
            {
                if (value == null && targetNullValue != null)
                {
                    value = targetNullValue;
                }
                obj.Text = value ?? global::System.String.Empty;
            }
            public static void Set_Microsoft_UI_Xaml_Controls_ToggleSwitch_IsOn(global::Microsoft.UI.Xaml.Controls.ToggleSwitch obj, global::System.Boolean value)
            {
                obj.IsOn = value;
            }
            public static void Set_Microsoft_UI_Xaml_Controls_TextBlock_Text(global::Microsoft.UI.Xaml.Controls.TextBlock obj, global::System.String value, string targetNullValue)
            {
                if (value == null && targetNullValue != null)
                {
                    value = targetNullValue;
                }
                obj.Text = value ?? global::System.String.Empty;
            }
            public static void Set_Microsoft_UI_Xaml_Controls_TextBox_PlaceholderText(global::Microsoft.UI.Xaml.Controls.TextBox obj, global::System.String value, string targetNullValue)
            {
                if (value == null && targetNullValue != null)
                {
                    value = targetNullValue;
                }
                obj.PlaceholderText = value ?? global::System.String.Empty;
            }
            public static void Set_Microsoft_UI_Xaml_Controls_ItemsView_ItemsSource(global::Microsoft.UI.Xaml.Controls.ItemsView obj, global::System.Object value, string targetNullValue)
            {
                if (value == null && targetNullValue != null)
                {
                    value = (global::System.Object) global::Microsoft.UI.Xaml.Markup.XamlBindingHelper.ConvertValue(typeof(global::System.Object), targetNullValue);
                }
                obj.ItemsSource = value;
            }
            public static void Set_Microsoft_UI_Xaml_Media_ImageBrush_ImageSource(global::Microsoft.UI.Xaml.Media.ImageBrush obj, global::Microsoft.UI.Xaml.Media.ImageSource value, string targetNullValue)
            {
                if (value == null && targetNullValue != null)
                {
                    value = (global::Microsoft.UI.Xaml.Media.ImageSource) global::Microsoft.UI.Xaml.Markup.XamlBindingHelper.ConvertValue(typeof(global::Microsoft.UI.Xaml.Media.ImageSource), targetNullValue);
                }
                obj.ImageSource = value;
            }
        };

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.UI.Xaml.Markup.Compiler"," 3.0.0.2503")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private partial class Page_InstanceOption_obj7_Bindings :
            global::Microsoft.UI.Xaml.IDataTemplateExtension,
            global::Microsoft.UI.Xaml.Markup.IDataTemplateComponent,
            global::Microsoft.UI.Xaml.Markup.IXamlBindScopeDiagnostics,
            global::Microsoft.UI.Xaml.Markup.IComponentConnector,
            IPage_InstanceOption_Bindings
        {
            private global::MinecraftLaunch.Base.Models.Game.JavaEntry dataRoot;
            private bool initialized = false;
            private const int NOT_PHASED = (1 << 31);
            private const int DATA_CHANGED = (1 << 30);
            private bool removedDataContextHandler = false;

            // Fields for each control that has bindings.
            private global::System.WeakReference obj7;

            // Static fields for each binding's enabled/disabled state
            private static bool isobj7TextDisabled = false;

            public Page_InstanceOption_obj7_Bindings()
            {
            }

            public void Disable(int lineNumber, int columnNumber)
            {
                if (lineNumber == 95 && columnNumber == 48)
                {
                    isobj7TextDisabled = true;
                }
            }

            // IComponentConnector

            public void Connect(int connectionId, global::System.Object target)
            {
                switch(connectionId)
                {
                    case 7: // Assets\Pages\Home\Page_InstanceOption.xaml line 95
                        this.obj7 = new global::System.WeakReference(global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.TextBlock>(target));
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

            public void DataContextChangedHandler(global::Microsoft.UI.Xaml.FrameworkElement sender, global::Microsoft.UI.Xaml.DataContextChangedEventArgs args)
            {
                 if (this.SetDataRoot(args.NewValue))
                 {
                    this.Update();
                 }
            }

            // IDataTemplateExtension

            public bool ProcessBinding(uint phase)
            {
                throw new global::System.NotImplementedException();
            }

            public int ProcessBindings(global::Microsoft.UI.Xaml.Controls.ContainerContentChangingEventArgs args)
            {
                int nextPhase = -1;
                ProcessBindings(args.Item, args.ItemIndex, (int)args.Phase, out nextPhase);
                return nextPhase;
            }

            public void ResetTemplate()
            {
                Recycle();
            }

            // IDataTemplateComponent

            public void ProcessBindings(global::System.Object item, int itemIndex, int phase, out int nextPhase)
            {
                nextPhase = -1;
                switch(phase)
                {
                    case 0:
                        nextPhase = -1;
                        this.SetDataRoot(item);
                        if (!removedDataContextHandler)
                        {
                            removedDataContextHandler = true;
                            var rootElement = (this.obj7.Target as global::Microsoft.UI.Xaml.Controls.TextBlock);
                            if (rootElement != null)
                            {
                                rootElement.DataContextChanged -= this.DataContextChangedHandler;
                            }
                        }
                        this.initialized = true;
                        break;
                }
                this.Update_(global::WinRT.CastExtensions.As<global::MinecraftLaunch.Base.Models.Game.JavaEntry>(item), 1 << phase);
            }

            public void Recycle()
            {
            }

            // IPage_InstanceOption_Bindings

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
                    this.dataRoot = global::WinRT.CastExtensions.As<global::MinecraftLaunch.Base.Models.Game.JavaEntry>(newDataRoot);
                    return true;
                }
                return false;
            }

            // Update methods for each path node used in binding steps.
            private void Update_(global::MinecraftLaunch.Base.Models.Game.JavaEntry obj, int phase)
            {
                if (obj != null)
                {
                    if ((phase & (NOT_PHASED | (1 << 0))) != 0)
                    {
                        this.Update_JavaFolder(obj.JavaFolder, phase);
                    }
                }
            }
            private void Update_JavaFolder(global::System.String obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    // Assets\Pages\Home\Page_InstanceOption.xaml line 95
                    if (!isobj7TextDisabled)
                    {
                        if ((this.obj7.Target as global::Microsoft.UI.Xaml.Controls.TextBlock) != null)
                        {
                            XamlBindingSetters.Set_Microsoft_UI_Xaml_Controls_TextBlock_Text((this.obj7.Target as global::Microsoft.UI.Xaml.Controls.TextBlock), obj, null);
                        }
                    }
                }
            }
        }

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.UI.Xaml.Markup.Compiler"," 3.0.0.2503")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private partial class Page_InstanceOption_obj1_Bindings :
            global::Microsoft.UI.Xaml.Markup.IDataTemplateComponent,
            global::Microsoft.UI.Xaml.Markup.IXamlBindScopeDiagnostics,
            global::Microsoft.UI.Xaml.Markup.IComponentConnector,
            IPage_InstanceOption_Bindings
        {
            private global::Fluent_Launcher.Assets.Pages.Home.Page_InstanceOption dataRoot;
            private bool initialized = false;
            private const int NOT_PHASED = (1 << 31);
            private const int DATA_CHANGED = (1 << 30);
            private global::Microsoft.UI.Xaml.ResourceDictionary localResources;
            private global::System.WeakReference<global::Microsoft.UI.Xaml.FrameworkElement> converterLookupRoot;

            // Fields for each control that has bindings.
            private global::Microsoft.UI.Xaml.Controls.RadioButtons obj2;
            private global::Microsoft.UI.Xaml.Controls.Slider obj3;
            private global::Microsoft.UI.Xaml.Controls.ComboBox obj5;
            private global::Microsoft.UI.Xaml.Controls.TextBox obj8;
            private global::Microsoft.UI.Xaml.Controls.TextBox obj9;
            private global::Microsoft.UI.Xaml.Controls.ToggleSwitch obj10;
            private global::Microsoft.UI.Xaml.Controls.TextBlock obj12;
            private global::Microsoft.UI.Xaml.Controls.ItemsView obj13;
            private global::Microsoft.UI.Xaml.Media.ImageBrush obj15;
            private global::Microsoft.UI.Xaml.Controls.TextBox obj16;
            private global::Microsoft.UI.Xaml.Controls.TextBox obj17;

            // Static fields for each binding's enabled/disabled state
            private static bool isobj2SelectedIndexDisabled = false;
            private static bool isobj3ValueDisabled = false;
            private static bool isobj5ItemsSourceDisabled = false;
            private static bool isobj5SelectedIndexDisabled = false;
            private static bool isobj8TextDisabled = false;
            private static bool isobj9TextDisabled = false;
            private static bool isobj10IsOnDisabled = false;
            private static bool isobj12TextDisabled = false;
            private static bool isobj13ItemsSourceDisabled = false;
            private static bool isobj15ImageSourceDisabled = false;
            private static bool isobj16TextDisabled = false;
            private static bool isobj17PlaceholderTextDisabled = false;

            private Page_InstanceOption_obj1_BindingsTracking bindingsTracking;

            public Page_InstanceOption_obj1_Bindings()
            {
                this.bindingsTracking = new Page_InstanceOption_obj1_BindingsTracking(this);
            }

            public void Disable(int lineNumber, int columnNumber)
            {
                if (lineNumber == 120 && columnNumber == 92)
                {
                    isobj2SelectedIndexDisabled = true;
                }
                else if (lineNumber == 125 && columnNumber == 127)
                {
                    isobj3ValueDisabled = true;
                }
                else if (lineNumber == 92 && columnNumber == 77)
                {
                    isobj5ItemsSourceDisabled = true;
                }
                else if (lineNumber == 92 && columnNumber == 122)
                {
                    isobj5SelectedIndexDisabled = true;
                }
                else if (lineNumber == 88 && columnNumber == 124)
                {
                    isobj8TextDisabled = true;
                }
                else if (lineNumber == 84 && columnNumber == 119)
                {
                    isobj9TextDisabled = true;
                }
                else if (lineNumber == 80 && columnNumber == 73)
                {
                    isobj10IsOnDisabled = true;
                }
                else if (lineNumber == 41 && columnNumber == 61)
                {
                    isobj12TextDisabled = true;
                }
                else if (lineNumber == 43 && columnNumber == 100)
                {
                    isobj13ItemsSourceDisabled = true;
                }
                else if (lineNumber == 31 && columnNumber == 53)
                {
                    isobj15ImageSourceDisabled = true;
                }
                else if (lineNumber == 69 && columnNumber == 112)
                {
                    isobj16TextDisabled = true;
                }
                else if (lineNumber == 65 && columnNumber == 42)
                {
                    isobj17PlaceholderTextDisabled = true;
                }
            }

            // IComponentConnector

            public void Connect(int connectionId, global::System.Object target)
            {
                switch(connectionId)
                {
                    case 2: // Assets\Pages\Home\Page_InstanceOption.xaml line 120
                        this.obj2 = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.RadioButtons>(target);
                        break;
                    case 3: // Assets\Pages\Home\Page_InstanceOption.xaml line 125
                        this.obj3 = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.Slider>(target);
                        break;
                    case 5: // Assets\Pages\Home\Page_InstanceOption.xaml line 92
                        this.obj5 = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.ComboBox>(target);
                        break;
                    case 8: // Assets\Pages\Home\Page_InstanceOption.xaml line 88
                        this.obj8 = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.TextBox>(target);
                        break;
                    case 9: // Assets\Pages\Home\Page_InstanceOption.xaml line 84
                        this.obj9 = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.TextBox>(target);
                        break;
                    case 10: // Assets\Pages\Home\Page_InstanceOption.xaml line 80
                        this.obj10 = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.ToggleSwitch>(target);
                        break;
                    case 12: // Assets\Pages\Home\Page_InstanceOption.xaml line 41
                        this.obj12 = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.TextBlock>(target);
                        break;
                    case 13: // Assets\Pages\Home\Page_InstanceOption.xaml line 43
                        this.obj13 = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.ItemsView>(target);
                        break;
                    case 15: // Assets\Pages\Home\Page_InstanceOption.xaml line 31
                        this.obj15 = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Media.ImageBrush>(target);
                        break;
                    case 16: // Assets\Pages\Home\Page_InstanceOption.xaml line 69
                        this.obj16 = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.TextBox>(target);
                        break;
                    case 17: // Assets\Pages\Home\Page_InstanceOption.xaml line 65
                        this.obj17 = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.TextBox>(target);
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

            // IPage_InstanceOption_Bindings

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
                    this.dataRoot = global::WinRT.CastExtensions.As<global::Fluent_Launcher.Assets.Pages.Home.Page_InstanceOption>(newDataRoot);
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
            private void Update_(global::Fluent_Launcher.Assets.Pages.Home.Page_InstanceOption obj, int phase)
            {
                if (obj != null)
                {
                    if ((phase & (NOT_PHASED | (1 << 0))) != 0)
                    {
                        this.Update_InstanceDetails(obj.InstanceDetails, phase);
                    }
                }
                this.Update_Fluent_Launcher_Assets_Class_GlobalVar_IniOptions(global::Fluent_Launcher.Assets.Class.GlobalVar.IniOptions, phase);
                this.Update_Fluent_Launcher_Assets_Class_GlobalVar_Javas(global::Fluent_Launcher.Assets.Class.GlobalVar.Javas, phase);
            }
            private void Update_Fluent_Launcher_Assets_Class_GlobalVar_IniOptions(global::Fluent_Launcher.Assets.Class.InstanceOptions obj, int phase)
            {
                if (obj != null)
                {
                    if ((phase & (NOT_PHASED | (1 << 0))) != 0)
                    {
                        this.Update_Fluent_Launcher_Assets_Class_GlobalVar_IniOptions_MemoryRadio(obj.MemoryRadio, phase);
                        this.Update_Fluent_Launcher_Assets_Class_GlobalVar_IniOptions_MemoryCustomize(obj.MemoryCustomize, phase);
                        this.Update_Fluent_Launcher_Assets_Class_GlobalVar_IniOptions_GameJava(obj.GameJava, phase);
                        this.Update_Fluent_Launcher_Assets_Class_GlobalVar_IniOptions_CustomInfomation(obj.CustomInfomation, phase);
                        this.Update_Fluent_Launcher_Assets_Class_GlobalVar_IniOptions_WindowTitle(obj.WindowTitle, phase);
                        this.Update_Fluent_Launcher_Assets_Class_GlobalVar_IniOptions_Independent(obj.Independent, phase);
                        this.Update_Fluent_Launcher_Assets_Class_GlobalVar_IniOptions_InstanceDescription(obj.InstanceDescription, phase);
                    }
                }
            }
            private void Update_Fluent_Launcher_Assets_Class_GlobalVar_IniOptions_MemoryRadio(global::System.Int32 obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    // Assets\Pages\Home\Page_InstanceOption.xaml line 120
                    if (!isobj2SelectedIndexDisabled)
                    {
                        XamlBindingSetters.Set_Microsoft_UI_Xaml_Controls_RadioButtons_SelectedIndex(this.obj2, obj);
                    }
                }
            }
            private void Update_Fluent_Launcher_Assets_Class_GlobalVar_IniOptions_MemoryCustomize(global::System.Int32 obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    // Assets\Pages\Home\Page_InstanceOption.xaml line 125
                    if (!isobj3ValueDisabled)
                    {
                        XamlBindingSetters.Set_Microsoft_UI_Xaml_Controls_Primitives_RangeBase_Value(this.obj3, (global::System.Double)this.LookupConverter("MBToGBConverter").Convert(obj, typeof(global::System.Double), null, null));
                    }
                }
            }
            private void Update_Fluent_Launcher_Assets_Class_GlobalVar_Javas(global::System.Collections.Generic.IList<global::MinecraftLaunch.Base.Models.Game.JavaEntry> obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    // Assets\Pages\Home\Page_InstanceOption.xaml line 92
                    if (!isobj5ItemsSourceDisabled)
                    {
                        XamlBindingSetters.Set_Microsoft_UI_Xaml_Controls_ItemsControl_ItemsSource(this.obj5, obj, null);
                    }
                }
            }
            private void Update_Fluent_Launcher_Assets_Class_GlobalVar_IniOptions_GameJava(global::System.Int32 obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    // Assets\Pages\Home\Page_InstanceOption.xaml line 92
                    if (!isobj5SelectedIndexDisabled)
                    {
                        XamlBindingSetters.Set_Microsoft_UI_Xaml_Controls_Primitives_Selector_SelectedIndex(this.obj5, obj);
                    }
                }
            }
            private void Update_Fluent_Launcher_Assets_Class_GlobalVar_IniOptions_CustomInfomation(global::System.String obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    // Assets\Pages\Home\Page_InstanceOption.xaml line 88
                    if (!isobj8TextDisabled)
                    {
                        XamlBindingSetters.Set_Microsoft_UI_Xaml_Controls_TextBox_Text(this.obj8, obj, null);
                    }
                }
            }
            private void Update_Fluent_Launcher_Assets_Class_GlobalVar_IniOptions_WindowTitle(global::System.String obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    // Assets\Pages\Home\Page_InstanceOption.xaml line 84
                    if (!isobj9TextDisabled)
                    {
                        XamlBindingSetters.Set_Microsoft_UI_Xaml_Controls_TextBox_Text(this.obj9, obj, null);
                    }
                }
            }
            private void Update_Fluent_Launcher_Assets_Class_GlobalVar_IniOptions_Independent(global::System.Boolean obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    // Assets\Pages\Home\Page_InstanceOption.xaml line 80
                    if (!isobj10IsOnDisabled)
                    {
                        XamlBindingSetters.Set_Microsoft_UI_Xaml_Controls_ToggleSwitch_IsOn(this.obj10, obj);
                    }
                }
            }
            private void Update_InstanceDetails(global::Fluent_Launcher.Assets.Class.SettingsCardTagDescriptionInfos obj, int phase)
            {
                if (obj != null)
                {
                    if ((phase & (NOT_PHASED | (1 << 0))) != 0)
                    {
                        this.Update_InstanceDetails_Header(obj.Header, phase);
                        this.Update_InstanceDetails_Description(obj.Description, phase);
                        this.Update_InstanceDetails_HeaderIcon(obj.HeaderIcon, phase);
                    }
                }
            }
            private void Update_InstanceDetails_Header(global::System.String obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    // Assets\Pages\Home\Page_InstanceOption.xaml line 41
                    if (!isobj12TextDisabled)
                    {
                        XamlBindingSetters.Set_Microsoft_UI_Xaml_Controls_TextBlock_Text(this.obj12, obj, null);
                    }
                    // Assets\Pages\Home\Page_InstanceOption.xaml line 65
                    if (!isobj17PlaceholderTextDisabled)
                    {
                        XamlBindingSetters.Set_Microsoft_UI_Xaml_Controls_TextBox_PlaceholderText(this.obj17, obj, null);
                    }
                }
            }
            private void Update_InstanceDetails_Description(global::System.Collections.Generic.IList<global::System.String> obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    // Assets\Pages\Home\Page_InstanceOption.xaml line 43
                    if (!isobj13ItemsSourceDisabled)
                    {
                        XamlBindingSetters.Set_Microsoft_UI_Xaml_Controls_ItemsView_ItemsSource(this.obj13, obj, null);
                    }
                }
            }
            private void Update_InstanceDetails_HeaderIcon(global::Microsoft.UI.Xaml.Media.Imaging.BitmapImage obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    // Assets\Pages\Home\Page_InstanceOption.xaml line 31
                    if (!isobj15ImageSourceDisabled)
                    {
                        XamlBindingSetters.Set_Microsoft_UI_Xaml_Media_ImageBrush_ImageSource(this.obj15, obj, null);
                    }
                }
            }
            private void Update_Fluent_Launcher_Assets_Class_GlobalVar_IniOptions_InstanceDescription(global::System.String obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    // Assets\Pages\Home\Page_InstanceOption.xaml line 69
                    if (!isobj16TextDisabled)
                    {
                        XamlBindingSetters.Set_Microsoft_UI_Xaml_Controls_TextBox_Text(this.obj16, obj, null);
                    }
                }
            }

            [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.UI.Xaml.Markup.Compiler"," 3.0.0.2503")]
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            private class Page_InstanceOption_obj1_BindingsTracking
            {
                private global::System.WeakReference<Page_InstanceOption_obj1_Bindings> weakRefToBindingObj; 

                public Page_InstanceOption_obj1_BindingsTracking(Page_InstanceOption_obj1_Bindings obj)
                {
                    weakRefToBindingObj = new global::System.WeakReference<Page_InstanceOption_obj1_Bindings>(obj);
                }

                public Page_InstanceOption_obj1_Bindings TryGetBindingObject()
                {
                    Page_InstanceOption_obj1_Bindings bindingObject = null;
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
            case 2: // Assets\Pages\Home\Page_InstanceOption.xaml line 120
                {
                    this.RadioButtons_Memory = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.RadioButtons>(target);
                }
                break;
            case 3: // Assets\Pages\Home\Page_InstanceOption.xaml line 125
                {
                    this.Slider_Memory = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.Slider>(target);
                }
                break;
            case 4: // Assets\Pages\Home\Page_InstanceOption.xaml line 123
                {
                    this.RadioButton_CustomMemory = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.RadioButton>(target);
                }
                break;
            case 5: // Assets\Pages\Home\Page_InstanceOption.xaml line 92
                {
                    this.ComboBox_GameJava = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.ComboBox>(target);
                }
                break;
            case 8: // Assets\Pages\Home\Page_InstanceOption.xaml line 88
                {
                    this.TextBox_CustomInfomation = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.TextBox>(target);
                }
                break;
            case 9: // Assets\Pages\Home\Page_InstanceOption.xaml line 84
                {
                    this.TextBox_WindowTitle = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.TextBox>(target);
                }
                break;
            case 10: // Assets\Pages\Home\Page_InstanceOption.xaml line 80
                {
                    this.ToggleSwitch_Independent = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.ToggleSwitch>(target);
                }
                break;
            case 11: // Assets\Pages\Home\Page_InstanceOption.xaml line 23
                {
                    this.Grid_InstanceDetails = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.Grid>(target);
                }
                break;
            case 16: // Assets\Pages\Home\Page_InstanceOption.xaml line 69
                {
                    this.TextBox_Description = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.TextBox>(target);
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
            case 1: // Assets\Pages\Home\Page_InstanceOption.xaml line 2
                {                    
                    global::Microsoft.UI.Xaml.Controls.Page element1 = (global::Microsoft.UI.Xaml.Controls.Page)target;
                    Page_InstanceOption_obj1_Bindings bindings = new Page_InstanceOption_obj1_Bindings();
                    returnValue = bindings;
                    bindings.SetDataRoot(this);
                    bindings.SetConverterLookupRoot(this);
                    this.Bindings = bindings;
                    element1.Loading += bindings.Loading;
                    global::Microsoft.UI.Xaml.Markup.XamlBindingHelper.SetDataTemplateComponent(element1, bindings);
                }
                break;
            case 7: // Assets\Pages\Home\Page_InstanceOption.xaml line 95
                {                    
                    global::Microsoft.UI.Xaml.Controls.TextBlock element7 = (global::Microsoft.UI.Xaml.Controls.TextBlock)target;
                    Page_InstanceOption_obj7_Bindings bindings = new Page_InstanceOption_obj7_Bindings();
                    returnValue = bindings;
                    bindings.SetDataRoot(element7.DataContext);
                    element7.DataContextChanged += bindings.DataContextChangedHandler;
                    global::Microsoft.UI.Xaml.DataTemplate.SetExtensionInstance(element7, bindings);
                    global::Microsoft.UI.Xaml.Markup.XamlBindingHelper.SetDataTemplateComponent(element7, bindings);
                }
                break;
            }
            return returnValue;
        }
    }
}

