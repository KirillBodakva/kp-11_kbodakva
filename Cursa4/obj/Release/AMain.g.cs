﻿#pragma checksum "..\..\AMain.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "17B2BBF392B4074C55CF46CCB47E69A2A13D388A2A7C65004025FB9A235F24E1"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Lab_4;
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


namespace Lab_4 {
    
    
    /// <summary>
    /// MainWindow
    /// </summary>
    public partial class MainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 12 "..\..\AMain.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dt;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\AMain.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cb;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\AMain.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button b1;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\AMain.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button b2;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\AMain.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button b3;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\AMain.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button b4;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\AMain.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button b5;
        
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
            System.Uri resourceLocater = new System.Uri("/Lab 4;component/amain.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\AMain.xaml"
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
            this.dt = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 2:
            this.cb = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 3:
            this.b1 = ((System.Windows.Controls.Button)(target));
            
            #line 31 "..\..\AMain.xaml"
            this.b1.Click += new System.Windows.RoutedEventHandler(this.b1_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.b2 = ((System.Windows.Controls.Button)(target));
            
            #line 35 "..\..\AMain.xaml"
            this.b2.Click += new System.Windows.RoutedEventHandler(this.b2_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.b3 = ((System.Windows.Controls.Button)(target));
            
            #line 39 "..\..\AMain.xaml"
            this.b3.Click += new System.Windows.RoutedEventHandler(this.b3_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.b4 = ((System.Windows.Controls.Button)(target));
            
            #line 41 "..\..\AMain.xaml"
            this.b4.Click += new System.Windows.RoutedEventHandler(this.b4_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.b5 = ((System.Windows.Controls.Button)(target));
            
            #line 44 "..\..\AMain.xaml"
            this.b5.Click += new System.Windows.RoutedEventHandler(this.b5_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

