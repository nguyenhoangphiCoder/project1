﻿#pragma checksum "..\..\..\ViewModel\LoginWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "E9BD4E30B4043352D9812722088E093633C2D2E3E421585B71593B5798FEF271"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
using Phanmemquanlybanhang.View;
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


namespace Phanmemquanlybanhang.View {
    
    
    /// <summary>
    /// LoginWindow
    /// </summary>
    public partial class LoginWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 82 "..\..\..\ViewModel\LoginWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Minimize;
        
        #line default
        #line hidden
        
        
        #line 125 "..\..\..\ViewModel\LoginWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Close;
        
        #line default
        #line hidden
        
        
        #line 219 "..\..\..\ViewModel\LoginWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtUser;
        
        #line default
        #line hidden
        
        
        #line 222 "..\..\..\ViewModel\LoginWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox pspw;
        
        #line default
        #line hidden
        
        
        #line 240 "..\..\..\ViewModel\LoginWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Login;
        
        #line default
        #line hidden
        
        
        #line 279 "..\..\..\ViewModel\LoginWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Close2;
        
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
            System.Uri resourceLocater = new System.Uri("/Phanmemquanlybanhang;component/viewmodel/loginwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\ViewModel\LoginWindow.xaml"
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
            
            #line 20 "..\..\..\ViewModel\LoginWindow.xaml"
            ((Phanmemquanlybanhang.View.LoginWindow)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Window_MouseDown);
            
            #line default
            #line hidden
            return;
            case 2:
            this.Minimize = ((System.Windows.Controls.Button)(target));
            
            #line 93 "..\..\..\ViewModel\LoginWindow.xaml"
            this.Minimize.Click += new System.Windows.RoutedEventHandler(this.btnMinimize_Cick);
            
            #line default
            #line hidden
            return;
            case 3:
            this.Close = ((System.Windows.Controls.Button)(target));
            
            #line 135 "..\..\..\ViewModel\LoginWindow.xaml"
            this.Close.Click += new System.Windows.RoutedEventHandler(this.Close_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.txtUser = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.pspw = ((System.Windows.Controls.PasswordBox)(target));
            return;
            case 6:
            this.Login = ((System.Windows.Controls.Button)(target));
            
            #line 250 "..\..\..\ViewModel\LoginWindow.xaml"
            this.Login.Click += new System.Windows.RoutedEventHandler(this.Login_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.Close2 = ((System.Windows.Controls.Button)(target));
            
            #line 289 "..\..\..\ViewModel\LoginWindow.xaml"
            this.Close2.Click += new System.Windows.RoutedEventHandler(this.Close1_Cick);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

