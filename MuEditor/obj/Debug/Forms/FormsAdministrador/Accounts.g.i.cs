﻿#pragma checksum "..\..\..\..\Forms\FormsAdministrador\Accounts.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "772B0910F5CB38CCA9DD76333B0A654A072E290D2DAAAE581CBBF3813B7B90FB"
//------------------------------------------------------------------------------
// <auto-generated>
//     O código foi gerado por uma ferramenta.
//     Versão de Tempo de Execução:4.0.30319.42000
//
//     As alterações ao arquivo poderão causar comportamento incorreto e serão perdidas se
//     o código for gerado novamente.
// </auto-generated>
//------------------------------------------------------------------------------

using MuEditor.Forms.FormsAdministrador;
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


namespace MuEditor.Forms.FormsAdministrador {
    
    
    /// <summary>
    /// Accounts
    /// </summary>
    public partial class Accounts : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 34 "..\..\..\..\Forms\FormsAdministrador\Accounts.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid DatagridAccounts;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\..\Forms\FormsAdministrador\Accounts.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Account;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\..\..\Forms\FormsAdministrador\Accounts.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Email;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\..\..\Forms\FormsAdministrador\Accounts.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Register;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\..\..\Forms\FormsAdministrador\Accounts.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Credits;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\..\Forms\FormsAdministrador\Accounts.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox CurrentIP;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\..\..\Forms\FormsAdministrador\Accounts.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox TypeAccount;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\..\..\Forms\FormsAdministrador\Accounts.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox VipStatus;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\..\..\Forms\FormsAdministrador\Accounts.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox FindAccount;
        
        #line default
        #line hidden
        
        
        #line 69 "..\..\..\..\Forms\FormsAdministrador\Accounts.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TimeVip;
        
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
            System.Uri resourceLocater = new System.Uri("/MuEditor;component/forms/formsadministrador/accounts.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Forms\FormsAdministrador\Accounts.xaml"
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
            
            #line 8 "..\..\..\..\Forms\FormsAdministrador\Accounts.xaml"
            ((MuEditor.Forms.FormsAdministrador.Accounts)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Window_MouseDown);
            
            #line default
            #line hidden
            
            #line 8 "..\..\..\..\Forms\FormsAdministrador\Accounts.xaml"
            ((MuEditor.Forms.FormsAdministrador.Accounts)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.DatagridAccounts = ((System.Windows.Controls.DataGrid)(target));
            
            #line 34 "..\..\..\..\Forms\FormsAdministrador\Accounts.xaml"
            this.DatagridAccounts.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.DatagridAccounts_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.Account = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.Email = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.Register = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.Credits = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.CurrentIP = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.TypeAccount = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 9:
            this.VipStatus = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 10:
            this.FindAccount = ((System.Windows.Controls.TextBox)(target));
            
            #line 53 "..\..\..\..\Forms\FormsAdministrador\Accounts.xaml"
            this.FindAccount.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.FindAccount_TextChanged);
            
            #line default
            #line hidden
            return;
            case 11:
            
            #line 54 "..\..\..\..\Forms\FormsAdministrador\Accounts.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click_1);
            
            #line default
            #line hidden
            return;
            case 12:
            
            #line 61 "..\..\..\..\Forms\FormsAdministrador\Accounts.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 13:
            this.TimeVip = ((System.Windows.Controls.TextBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

