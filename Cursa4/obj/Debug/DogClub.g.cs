#pragma checksum "..\..\DogClub.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "4A0BBA68BCCA10F3B53907875B4AE957AE39021D6FA94EE74348CEA2B5C91A5A"
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
    /// DogClub
    /// </summary>
    public partial class DogClub : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\DogClub.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid d1;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\DogClub.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label l1;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\DogClub.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox t1;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\DogClub.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label l2;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\DogClub.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox t2;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\DogClub.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button b1;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\DogClub.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button b2;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\DogClub.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button b3;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\DogClub.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button b4;
        
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
            System.Uri resourceLocater = new System.Uri("/Lab 4;component/dogclub.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\DogClub.xaml"
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
            this.d1 = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 2:
            this.l1 = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            this.t1 = ((System.Windows.Controls.TextBox)(target));
            
            #line 15 "..\..\DogClub.xaml"
            this.t1.KeyUp += new System.Windows.Input.KeyEventHandler(this.t1up);
            
            #line default
            #line hidden
            
            #line 15 "..\..\DogClub.xaml"
            this.t1.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.td);
            
            #line default
            #line hidden
            return;
            case 4:
            this.l2 = ((System.Windows.Controls.Label)(target));
            return;
            case 5:
            this.t2 = ((System.Windows.Controls.TextBox)(target));
            
            #line 17 "..\..\DogClub.xaml"
            this.t2.KeyUp += new System.Windows.Input.KeyEventHandler(this.t2up);
            
            #line default
            #line hidden
            
            #line 17 "..\..\DogClub.xaml"
            this.t2.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.td);
            
            #line default
            #line hidden
            return;
            case 6:
            this.b1 = ((System.Windows.Controls.Button)(target));
            
            #line 19 "..\..\DogClub.xaml"
            this.b1.Click += new System.Windows.RoutedEventHandler(this.b1_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.b2 = ((System.Windows.Controls.Button)(target));
            
            #line 20 "..\..\DogClub.xaml"
            this.b2.Click += new System.Windows.RoutedEventHandler(this.b2_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.b3 = ((System.Windows.Controls.Button)(target));
            
            #line 21 "..\..\DogClub.xaml"
            this.b3.Click += new System.Windows.RoutedEventHandler(this.b3_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.b4 = ((System.Windows.Controls.Button)(target));
            
            #line 22 "..\..\DogClub.xaml"
            this.b4.Click += new System.Windows.RoutedEventHandler(this.b4_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

