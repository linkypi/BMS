﻿#pragma checksum "..\..\..\..\BookManager\History.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "9EF06266DCB27A86A18F45A397D227C6"
//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.18449
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

using BMS.Common;
using BMS.MyControl;
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
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.Animation;
using Telerik.Windows.Controls.Carousel;
using Telerik.Windows.Controls.Data.PropertyGrid;
using Telerik.Windows.Controls.Docking;
using Telerik.Windows.Controls.DragDrop;
using Telerik.Windows.Controls.GridView;
using Telerik.Windows.Controls.Legend;
using Telerik.Windows.Controls.Primitives;
using Telerik.Windows.Controls.TransitionEffects;
using Telerik.Windows.Controls.TreeListView;
using Telerik.Windows.Controls.TreeView;
using Telerik.Windows.Data;
using Telerik.Windows.DragDrop;
using Telerik.Windows.DragDrop.Behaviors;
using Telerik.Windows.Input.Touch;
using Telerik.Windows.Shapes;


namespace BMS.BookManager {
    
    
    /// <summary>
    /// History
    /// </summary>
    public partial class History : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 38 "..\..\..\..\BookManager\History.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Telerik.Windows.Controls.RadBusyIndicator busy;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\..\..\BookManager\History.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox user;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\..\..\BookManager\History.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox isBorow;
        
        #line default
        #line hidden
        
        
        #line 60 "..\..\..\..\BookManager\History.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Telerik.Windows.Controls.RadButton search;
        
        #line default
        #line hidden
        
        
        #line 66 "..\..\..\..\BookManager\History.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DockPanel panel;
        
        #line default
        #line hidden
        
        
        #line 68 "..\..\..\..\BookManager\History.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Telerik.Windows.Controls.RadNumericUpDown pagesize;
        
        #line default
        #line hidden
        
        
        #line 69 "..\..\..\..\BookManager\History.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Telerik.Windows.Controls.RadDataPager page;
        
        #line default
        #line hidden
        
        
        #line 72 "..\..\..\..\BookManager\History.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Telerik.Windows.Controls.RadGridView GridList;
        
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
            System.Uri resourceLocater = new System.Uri("/BMS;component/bookmanager/history.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\BookManager\History.xaml"
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
            this.busy = ((Telerik.Windows.Controls.RadBusyIndicator)(target));
            return;
            case 2:
            this.user = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.isBorow = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 4:
            this.search = ((Telerik.Windows.Controls.RadButton)(target));
            
            #line 60 "..\..\..\..\BookManager\History.xaml"
            this.search.Click += new System.Windows.RoutedEventHandler(this.search_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.panel = ((System.Windows.Controls.DockPanel)(target));
            return;
            case 6:
            this.pagesize = ((Telerik.Windows.Controls.RadNumericUpDown)(target));
            
            #line 68 "..\..\..\..\BookManager\History.xaml"
            this.pagesize.SizeChanged += new System.Windows.SizeChangedEventHandler(this.pagesize_SizeChanged);
            
            #line default
            #line hidden
            return;
            case 7:
            this.page = ((Telerik.Windows.Controls.RadDataPager)(target));
            
            #line 69 "..\..\..\..\BookManager\History.xaml"
            this.page.PageIndexChanged += new System.EventHandler<Telerik.Windows.Controls.PageIndexChangedEventArgs>(this.page_PageIndexChanged);
            
            #line default
            #line hidden
            return;
            case 8:
            this.GridList = ((Telerik.Windows.Controls.RadGridView)(target));
            
            #line 72 "..\..\..\..\BookManager\History.xaml"
            this.GridList.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.GridList_MouseDoubleClick);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
