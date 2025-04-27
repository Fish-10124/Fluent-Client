using Fluent_Launcher.Assets.Pages.Home;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
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

namespace Fluent_Launcher.Assets.UserControls
{
    public sealed partial class UC_BreadcrumbBar : UserControl
    {

        // 定义一个依赖属性
        public static readonly DependencyProperty FrameProperty =
            DependencyProperty.Register(
                "Frame",                // 属性名称
                typeof(Frame),              // 属性类型
                typeof(UC_BreadcrumbBar),     // 所属控件的类型
                new PropertyMetadata("", OnMyPropertyChanged) // 默认值及回调
            );

        // CLR 封装
        public Frame Frame
        {
            get => (Frame)GetValue(FrameProperty);
            set => SetValue(FrameProperty, value);
        }

        // 属性变化回调（可选）
        private static void OnMyPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var newValue = (Frame)e.NewValue;
            CurrentFrame = newValue;
        }

        private static Frame? CurrentFrame;

        // KeyValuePair<Tag, Show>
        public ObservableCollection<KeyValuePair<Type, string>> Items
        {
            get;
            private set;
        } = [];

        public bool CanGoBack => Items.Count > 0;

        public UC_BreadcrumbBar()
        {
            this.InitializeComponent();
        }

        private void BreadcrumbBar_Title_ItemClicked(BreadcrumbBar sender, BreadcrumbBarItemClickedEventArgs args)
        {
            for (int i = Items.Count - 1; i > args.Index; i--)
            {
                Items.RemoveAt(i);
            }

            Frame.Navigate(Items[^1].Key);
        }

        // KeyValuePair<Type page, string show>
        public void AddItem(KeyValuePair<Type, string> item)
        {
            Items.Add(item);
        }

        public void GoBack()
        {
            Items.RemoveAt(Items.Count - 1);
        }
    }
}
