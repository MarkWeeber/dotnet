﻿#pragma checksum "..\..\..\MainWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7DA26751D768F415DD624D79CD0B75AF2055F198"
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
    /// MainWindow
    /// </summary>
    public partial class MainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 11 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock UserNameTextBlock;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView ListViewCustomers;
        
        #line default
        #line hidden
        
        
        #line 102 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AddNewCustomer;
        
        #line default
        #line hidden
        
        
        #line 110 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button TransferBetweenTwoCustomers;
        
        #line default
        #line hidden
        
        
        #line 117 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ShowCustomerAccounts;
        
        #line default
        #line hidden
        
        
        #line 124 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button EditCustomerDetails;
        
        #line default
        #line hidden
        
        
        #line 135 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView ListViewTransactionHistory;
        
        #line default
        #line hidden
        
        
        #line 216 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView ListViewAccountsSatesLog;
        
        #line default
        #line hidden
        
        
        #line 297 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView ListViewCustomersChangeLog;
        
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
            System.Uri resourceLocater = new System.Uri("/app15;V1.0.0.0;component/mainwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\MainWindow.xaml"
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
            this.UserNameTextBlock = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 2:
            this.ListViewCustomers = ((System.Windows.Controls.ListView)(target));
            
            #line 31 "..\..\..\MainWindow.xaml"
            this.ListViewCustomers.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.ListViewCustomers_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 40 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.GridViewColumnHeader)(target)).Click += new System.Windows.RoutedEventHandler(this.CustomersListViewColumnHeader_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 51 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.GridViewColumnHeader)(target)).Click += new System.Windows.RoutedEventHandler(this.CustomersListViewColumnHeader_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 62 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.GridViewColumnHeader)(target)).Click += new System.Windows.RoutedEventHandler(this.CustomersListViewColumnHeader_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 73 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.GridViewColumnHeader)(target)).Click += new System.Windows.RoutedEventHandler(this.CustomersListViewColumnHeader_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 84 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.GridViewColumnHeader)(target)).Click += new System.Windows.RoutedEventHandler(this.CustomersListViewColumnHeader_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.AddNewCustomer = ((System.Windows.Controls.Button)(target));
            
            #line 106 "..\..\..\MainWindow.xaml"
            this.AddNewCustomer.Click += new System.Windows.RoutedEventHandler(this.AddNewCustomer_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.TransferBetweenTwoCustomers = ((System.Windows.Controls.Button)(target));
            
            #line 113 "..\..\..\MainWindow.xaml"
            this.TransferBetweenTwoCustomers.Click += new System.Windows.RoutedEventHandler(this.TransferBetweenTwoCustomers_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.ShowCustomerAccounts = ((System.Windows.Controls.Button)(target));
            
            #line 120 "..\..\..\MainWindow.xaml"
            this.ShowCustomerAccounts.Click += new System.Windows.RoutedEventHandler(this.ShowCustomerAccounts_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            this.EditCustomerDetails = ((System.Windows.Controls.Button)(target));
            
            #line 127 "..\..\..\MainWindow.xaml"
            this.EditCustomerDetails.Click += new System.Windows.RoutedEventHandler(this.EditCustomerDetails_Click);
            
            #line default
            #line hidden
            return;
            case 12:
            this.ListViewTransactionHistory = ((System.Windows.Controls.ListView)(target));
            return;
            case 13:
            
            #line 148 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.GridViewColumnHeader)(target)).Click += new System.Windows.RoutedEventHandler(this.TransactiontsListViewColumnHeader_Click);
            
            #line default
            #line hidden
            return;
            case 14:
            
            #line 159 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.GridViewColumnHeader)(target)).Click += new System.Windows.RoutedEventHandler(this.TransactiontsListViewColumnHeader_Click);
            
            #line default
            #line hidden
            return;
            case 15:
            
            #line 170 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.GridViewColumnHeader)(target)).Click += new System.Windows.RoutedEventHandler(this.TransactiontsListViewColumnHeader_Click);
            
            #line default
            #line hidden
            return;
            case 16:
            
            #line 181 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.GridViewColumnHeader)(target)).Click += new System.Windows.RoutedEventHandler(this.TransactiontsListViewColumnHeader_Click);
            
            #line default
            #line hidden
            return;
            case 17:
            
            #line 192 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.GridViewColumnHeader)(target)).Click += new System.Windows.RoutedEventHandler(this.TransactiontsListViewColumnHeader_Click);
            
            #line default
            #line hidden
            return;
            case 18:
            
            #line 203 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.GridViewColumnHeader)(target)).Click += new System.Windows.RoutedEventHandler(this.TransactiontsListViewColumnHeader_Click);
            
            #line default
            #line hidden
            return;
            case 19:
            this.ListViewAccountsSatesLog = ((System.Windows.Controls.ListView)(target));
            return;
            case 20:
            
            #line 229 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.GridViewColumnHeader)(target)).Click += new System.Windows.RoutedEventHandler(this.ListViewAccountsStatesLogColumnHeader_Click);
            
            #line default
            #line hidden
            return;
            case 21:
            
            #line 240 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.GridViewColumnHeader)(target)).Click += new System.Windows.RoutedEventHandler(this.ListViewAccountsStatesLogColumnHeader_Click);
            
            #line default
            #line hidden
            return;
            case 22:
            
            #line 251 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.GridViewColumnHeader)(target)).Click += new System.Windows.RoutedEventHandler(this.ListViewAccountsStatesLogColumnHeader_Click);
            
            #line default
            #line hidden
            return;
            case 23:
            
            #line 262 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.GridViewColumnHeader)(target)).Click += new System.Windows.RoutedEventHandler(this.ListViewAccountsStatesLogColumnHeader_Click);
            
            #line default
            #line hidden
            return;
            case 24:
            
            #line 273 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.GridViewColumnHeader)(target)).Click += new System.Windows.RoutedEventHandler(this.ListViewAccountsStatesLogColumnHeader_Click);
            
            #line default
            #line hidden
            return;
            case 25:
            
            #line 284 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.GridViewColumnHeader)(target)).Click += new System.Windows.RoutedEventHandler(this.ListViewCustomersChangeLogColumnHeader_Click);
            
            #line default
            #line hidden
            return;
            case 26:
            this.ListViewCustomersChangeLog = ((System.Windows.Controls.ListView)(target));
            return;
            case 27:
            
            #line 310 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.GridViewColumnHeader)(target)).Click += new System.Windows.RoutedEventHandler(this.ListViewCustomersChangeLogColumnHeader_Click);
            
            #line default
            #line hidden
            return;
            case 28:
            
            #line 321 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.GridViewColumnHeader)(target)).Click += new System.Windows.RoutedEventHandler(this.ListViewCustomersChangeLogColumnHeader_Click);
            
            #line default
            #line hidden
            return;
            case 29:
            
            #line 332 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.GridViewColumnHeader)(target)).Click += new System.Windows.RoutedEventHandler(this.ListViewCustomersChangeLogColumnHeader_Click);
            
            #line default
            #line hidden
            return;
            case 30:
            
            #line 343 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.GridViewColumnHeader)(target)).Click += new System.Windows.RoutedEventHandler(this.ListViewCustomersChangeLogColumnHeader_Click);
            
            #line default
            #line hidden
            return;
            case 31:
            
            #line 354 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.GridViewColumnHeader)(target)).Click += new System.Windows.RoutedEventHandler(this.ListViewCustomersChangeLogColumnHeader_Click);
            
            #line default
            #line hidden
            return;
            case 32:
            
            #line 365 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.GridViewColumnHeader)(target)).Click += new System.Windows.RoutedEventHandler(this.ListViewCustomersChangeLogColumnHeader_Click);
            
            #line default
            #line hidden
            return;
            case 33:
            
            #line 376 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.GridViewColumnHeader)(target)).Click += new System.Windows.RoutedEventHandler(this.ListViewCustomersChangeLogColumnHeader_Click);
            
            #line default
            #line hidden
            return;
            case 34:
            
            #line 387 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.GridViewColumnHeader)(target)).Click += new System.Windows.RoutedEventHandler(this.ListViewCustomersChangeLogColumnHeader_Click);
            
            #line default
            #line hidden
            return;
            case 35:
            
            #line 398 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.GridViewColumnHeader)(target)).Click += new System.Windows.RoutedEventHandler(this.ListViewCustomersChangeLogColumnHeader_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

