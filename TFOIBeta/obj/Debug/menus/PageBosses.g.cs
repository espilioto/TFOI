﻿#pragma checksum "..\..\..\menus\PageBosses.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "DD1F926D1080913FF3BE94A5C8563338"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

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
    /// PageBosses
    /// </summary>
    public partial class PageBosses : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 14 "..\..\..\menus\PageBosses.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image back;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\menus\PageBosses.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image back_;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\menus\PageBosses.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.WrapPanel bossPanel;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\menus\PageBosses.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock textBossInfo;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\menus\PageBosses.xaml"
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
            System.Uri resourceLocater = new System.Uri("/TFOIBeta;component/menus/pagebosses.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\menus\PageBosses.xaml"
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
            
            #line 11 "..\..\..\menus\PageBosses.xaml"
            ((System.Windows.Controls.Grid)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Grid_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.back = ((System.Windows.Controls.Image)(target));
            
            #line 14 "..\..\..\menus\PageBosses.xaml"
            this.back.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.back_MouseDown);
            
            #line default
            #line hidden
            
            #line 14 "..\..\..\menus\PageBosses.xaml"
            this.back.MouseEnter += new System.Windows.Input.MouseEventHandler(this.back_MouseEnter);
            
            #line default
            #line hidden
            
            #line 14 "..\..\..\menus\PageBosses.xaml"
            this.back.MouseLeave += new System.Windows.Input.MouseEventHandler(this.back_MouseLeave);
            
            #line default
            #line hidden
            return;
            case 3:
            this.back_ = ((System.Windows.Controls.Image)(target));
            return;
            case 4:
            this.bossPanel = ((System.Windows.Controls.WrapPanel)(target));
            return;
            case 5:
            this.textBossInfo = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 6:
            this.dataGrid = ((System.Windows.Controls.DataGrid)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

