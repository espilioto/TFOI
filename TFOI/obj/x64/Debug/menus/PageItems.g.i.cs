﻿#pragma checksum "..\..\..\..\menus\PageItems.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "339B549AD8D2026DBBB88712A26DED15"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Microsoft.Expression.Media.Effects;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;
using TFOIBeta.menus;


namespace TFOIBeta.menus {
    
    
    /// <summary>
    /// PageItems
    /// </summary>
    public partial class PageItems : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 14 "..\..\..\..\menus\PageItems.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image back;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\..\menus\PageItems.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image back_;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\..\menus\PageItems.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.WrapPanel itemPanel;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\..\menus\PageItems.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock textItemName;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\..\menus\PageItems.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock textItemDescription;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\..\menus\PageItems.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock textItemStats;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\..\menus\PageItems.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dataGrid;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/TFOIBeta;component/menus/pageitems.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\menus\PageItems.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 10 "..\..\..\..\menus\PageItems.xaml"
            ((TFOIBeta.menus.PageItems)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Page_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.back = ((System.Windows.Controls.Image)(target));
            
            #line 14 "..\..\..\..\menus\PageItems.xaml"
            this.back.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.back_MouseDown);
            
            #line default
            #line hidden
            
            #line 14 "..\..\..\..\menus\PageItems.xaml"
            this.back.MouseEnter += new System.Windows.Input.MouseEventHandler(this.back_MouseEnter);
            
            #line default
            #line hidden
            
            #line 14 "..\..\..\..\menus\PageItems.xaml"
            this.back.MouseLeave += new System.Windows.Input.MouseEventHandler(this.back_MouseLeave);
            
            #line default
            #line hidden
            return;
            case 3:
            this.back_ = ((System.Windows.Controls.Image)(target));
            return;
            case 4:
            this.itemPanel = ((System.Windows.Controls.WrapPanel)(target));
            return;
            case 5:
            this.textItemName = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 6:
            this.textItemDescription = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 7:
            this.textItemStats = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 8:
            this.dataGrid = ((System.Windows.Controls.DataGrid)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
