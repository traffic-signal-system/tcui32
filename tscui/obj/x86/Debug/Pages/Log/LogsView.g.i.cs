﻿#pragma checksum "..\..\..\..\..\Pages\Log\LogsView.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "835A399B3D0A7BE03C71C0E017486886"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18444
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Apex.Behaviours;
using Apex.Controls;
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
using System.Windows.Interactivity;
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
using tscui.Pages.Log;


namespace tscui.Pages.Log {
    
    
    /// <summary>
    /// LogsView
    /// </summary>
    public partial class LogsView : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 15 "..\..\..\..\..\Pages\Log\LogsView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal tscui.Pages.Log.LogsViewModel viewModel;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\..\..\Pages\Log\LogsView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel splLog;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\..\..\Pages\Log\LogsView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnGetLog;
        
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
            System.Uri resourceLocater = new System.Uri("/tscui;component/pages/log/logsview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\Pages\Log\LogsView.xaml"
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
            this.viewModel = ((tscui.Pages.Log.LogsViewModel)(target));
            return;
            case 2:
            this.splLog = ((System.Windows.Controls.StackPanel)(target));
            
            #line 21 "..\..\..\..\..\Pages\Log\LogsView.xaml"
            this.splLog.Loaded += new System.Windows.RoutedEventHandler(this.splLog_Loaded);
            
            #line default
            #line hidden
            return;
            case 3:
            this.btnGetLog = ((System.Windows.Controls.Button)(target));
            
            #line 22 "..\..\..\..\..\Pages\Log\LogsView.xaml"
            this.btnGetLog.Click += new System.Windows.RoutedEventHandler(this.btnGetLog_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
