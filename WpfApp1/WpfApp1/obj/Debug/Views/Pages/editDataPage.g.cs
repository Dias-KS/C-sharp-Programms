﻿#pragma checksum "..\..\..\..\Views\Pages\editDataPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "A4C54CA3B1DA6D3544B249E9A150ECCE8018E83947737A055550B1BB2232A4FA"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
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
using WpfApp1.Views.Pages;


namespace WpfApp1.Views.Pages {
    
    
    /// <summary>
    /// editDataPage
    /// </summary>
    public partial class editDataPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 26 "..\..\..\..\Views\Pages\editDataPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image Picture;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\..\Views\Pages\editDataPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnLoadImg;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\..\..\Views\Pages\editDataPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox NameBookTextBox;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\..\..\Views\Pages\editDataPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox ComboBoxGenre;
        
        #line default
        #line hidden
        
        
        #line 56 "..\..\..\..\Views\Pages\editDataPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox CountPageBookTextBox;
        
        #line default
        #line hidden
        
        
        #line 60 "..\..\..\..\Views\Pages\editDataPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox AuthorFirstNameComboBox;
        
        #line default
        #line hidden
        
        
        #line 68 "..\..\..\..\Views\Pages\editDataPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox PriceTextBox;
        
        #line default
        #line hidden
        
        
        #line 72 "..\..\..\..\Views\Pages\editDataPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox PublisherBookComboBox;
        
        #line default
        #line hidden
        
        
        #line 79 "..\..\..\..\Views\Pages\editDataPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BackButton;
        
        #line default
        #line hidden
        
        
        #line 90 "..\..\..\..\Views\Pages\editDataPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button SaveButton;
        
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
            System.Uri resourceLocater = new System.Uri("/WpfApp1;component/views/pages/editdatapage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Views\Pages\editDataPage.xaml"
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
            
            #line 7 "..\..\..\..\Views\Pages\editDataPage.xaml"
            ((WpfApp1.Views.Pages.editDataPage)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Page_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.Picture = ((System.Windows.Controls.Image)(target));
            return;
            case 3:
            this.btnLoadImg = ((System.Windows.Controls.Button)(target));
            
            #line 32 "..\..\..\..\Views\Pages\editDataPage.xaml"
            this.btnLoadImg.Click += new System.Windows.RoutedEventHandler(this.btnLoadImg_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.NameBookTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.ComboBoxGenre = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 6:
            this.CountPageBookTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.AuthorFirstNameComboBox = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 8:
            this.PriceTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 9:
            this.PublisherBookComboBox = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 10:
            this.BackButton = ((System.Windows.Controls.Button)(target));
            
            #line 82 "..\..\..\..\Views\Pages\editDataPage.xaml"
            this.BackButton.Click += new System.Windows.RoutedEventHandler(this.BackButton_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            this.SaveButton = ((System.Windows.Controls.Button)(target));
            
            #line 92 "..\..\..\..\Views\Pages\editDataPage.xaml"
            this.SaveButton.Click += new System.Windows.RoutedEventHandler(this.SaveButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

