﻿#pragma checksum "..\..\..\ReplenishAccountWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2C5AE4B02CFE114A95D4FE8F6B2FC2881F873C47"
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
using System.Windows.Controls.Ribbon;
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
using app15;


namespace app15 {
    
    
    /// <summary>
    /// ReplenishAccountWindow
    /// </summary>
    public partial class ReplenishAccountWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 33 "..\..\..\ReplenishAccountWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock RA_AccountId;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\..\ReplenishAccountWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock RA_AccountNumber;
        
        #line default
        #line hidden
        
        
        #line 69 "..\..\..\ReplenishAccountWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock RA_AccountCurrency;
        
        #line default
        #line hidden
        
        
        #line 87 "..\..\..\ReplenishAccountWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock RA_AccountBalance;
        
        #line default
        #line hidden
        
        
        #line 104 "..\..\..\ReplenishAccountWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox RA_TextBoxReplenishAmount;
        
        #line default
        #line hidden
        
        
        #line 112 "..\..\..\ReplenishAccountWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button RA_ButtonReplenish;
        
        #line default
        #line hidden
        
        
        #line 120 "..\..\..\ReplenishAccountWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button RA_ButtonCancel;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.10.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/app15;V1.0.0.0;component/replenishaccountwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\ReplenishAccountWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.10.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.RA_AccountId = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 2:
            this.RA_AccountNumber = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.RA_AccountCurrency = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 4:
            this.RA_AccountBalance = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 5:
            this.RA_TextBoxReplenishAmount = ((System.Windows.Controls.TextBox)(target));
            
            #line 106 "..\..\..\ReplenishAccountWindow.xaml"
            this.RA_TextBoxReplenishAmount.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.RA_TextBoxReplenishAmount_PreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 6:
            this.RA_ButtonReplenish = ((System.Windows.Controls.Button)(target));
            
            #line 115 "..\..\..\ReplenishAccountWindow.xaml"
            this.RA_ButtonReplenish.Click += new System.Windows.RoutedEventHandler(this.RA_ButtonReplenish_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.RA_ButtonCancel = ((System.Windows.Controls.Button)(target));
            
            #line 123 "..\..\..\ReplenishAccountWindow.xaml"
            this.RA_ButtonCancel.Click += new System.Windows.RoutedEventHandler(this.RA_ButtonCancel_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

