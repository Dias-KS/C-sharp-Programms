﻿#pragma checksum "..\..\..\..\Views\Pages\RegPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "97B0B122778829CA1461C75A6C558E13DD70F9140DA1488E9C2FB84E8B458E64"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using PastryShop.Views.Pages;
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


namespace PastryShop.Views.Pages {
    
    
    /// <summary>
    /// RegPage
    /// </summary>
    public partial class RegPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 17 "..\..\..\..\Views\Pages\RegPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnBack;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\..\Views\Pages\RegPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txbLogin;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\..\..\Views\Pages\RegPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox pswPassword;
        
        #line default
        #line hidden
        
        
        #line 56 "..\..\..\..\Views\Pages\RegPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox pswPasswordDouble;
        
        #line default
        #line hidden
        
        
        #line 68 "..\..\..\..\Views\Pages\RegPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnRegistration;
        
        #line default
        #line hidden
        
        
        #line 76 "..\..\..\..\Views\Pages\RegPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnClean;
        
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
            System.Uri resourceLocater = new System.Uri("/PastryShop;component/views/pages/regpage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Views\Pages\RegPage.xaml"
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
            this.btnBack = ((System.Windows.Controls.Button)(target));
            
            #line 20 "..\..\..\..\Views\Pages\RegPage.xaml"
            this.btnBack.Click += new System.Windows.RoutedEventHandler(this.btnBack_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.txbLogin = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.pswPassword = ((System.Windows.Controls.PasswordBox)(target));
            
            #line 46 "..\..\..\..\Views\Pages\RegPage.xaml"
            this.pswPassword.PasswordChanged += new System.Windows.RoutedEventHandler(this.pswPassword_PasswordChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.pswPasswordDouble = ((System.Windows.Controls.PasswordBox)(target));
            
            #line 57 "..\..\..\..\Views\Pages\RegPage.xaml"
            this.pswPasswordDouble.PasswordChanged += new System.Windows.RoutedEventHandler(this.pswPasswordDouble_PasswordChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.btnRegistration = ((System.Windows.Controls.Button)(target));
            
            #line 72 "..\..\..\..\Views\Pages\RegPage.xaml"
            this.btnRegistration.Click += new System.Windows.RoutedEventHandler(this.btnRegistration_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.btnClean = ((System.Windows.Controls.Button)(target));
            
            #line 77 "..\..\..\..\Views\Pages\RegPage.xaml"
            this.btnClean.Click += new System.Windows.RoutedEventHandler(this.btnClean_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

