﻿#pragma checksum "..\..\..\forms\SibRegistrationForm.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "815E81329342BEDAE4D0575302CCA652E3A908FD"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Edir.forms;
using MaterialDesignThemes.MahApps;
using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
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


namespace Edir.forms {
    
    
    /// <summary>
    /// SibRegistrationForm
    /// </summary>
    public partial class SibRegistrationForm : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 13 "..\..\..\forms\SibRegistrationForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid SibGrid;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\forms\SibRegistrationForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGridTextColumn IDColumn;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\forms\SibRegistrationForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGridTextColumn NameColumn;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\forms\SibRegistrationForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGridTextColumn PhoneColumn;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\forms\SibRegistrationForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox ChildName;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\forms\SibRegistrationForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Phone;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\forms\SibRegistrationForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AddBtn;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\forms\SibRegistrationForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button EditBtn;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\..\forms\SibRegistrationForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button DeleteBtn;
        
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
            System.Uri resourceLocater = new System.Uri("/Edir;component/forms/sibregistrationform.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\forms\SibRegistrationForm.xaml"
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
            this.SibGrid = ((System.Windows.Controls.DataGrid)(target));
            
            #line 13 "..\..\..\forms\SibRegistrationForm.xaml"
            this.SibGrid.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.SibGrid_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.IDColumn = ((System.Windows.Controls.DataGridTextColumn)(target));
            return;
            case 3:
            this.NameColumn = ((System.Windows.Controls.DataGridTextColumn)(target));
            return;
            case 4:
            this.PhoneColumn = ((System.Windows.Controls.DataGridTextColumn)(target));
            return;
            case 5:
            this.ChildName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.Phone = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.AddBtn = ((System.Windows.Controls.Button)(target));
            
            #line 31 "..\..\..\forms\SibRegistrationForm.xaml"
            this.AddBtn.Click += new System.Windows.RoutedEventHandler(this.AddBtn_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.EditBtn = ((System.Windows.Controls.Button)(target));
            
            #line 40 "..\..\..\forms\SibRegistrationForm.xaml"
            this.EditBtn.Click += new System.Windows.RoutedEventHandler(this.EditBtn_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.DeleteBtn = ((System.Windows.Controls.Button)(target));
            
            #line 44 "..\..\..\forms\SibRegistrationForm.xaml"
            this.DeleteBtn.Click += new System.Windows.RoutedEventHandler(this.DeleteBtn_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
