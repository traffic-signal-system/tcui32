﻿#pragma checksum "..\..\..\..\..\Pages\Log\LogsView.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "BF76EC49300EB3DB73CCBA39AC4D392C"
//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

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
        
        
        #line 17 "..\..\..\..\..\Pages\Log\LogsView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel splLog;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\..\..\Pages\Log\LogsView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnGetLog;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\..\..\Pages\Log\LogsView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView Loglistview;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\..\..\Pages\Log\LogsView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.GridViewColumn ListViewLogId;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\..\..\Pages\Log\LogsView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.GridViewColumn ListViewLogType;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\..\..\Pages\Log\LogsView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.GridViewColumn ListViewLogTime;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\..\..\..\Pages\Log\LogsView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.GridViewColumn ListViewLogContent;
        
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
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal System.Delegate _CreateDelegate(System.Type delegateType, string handler) {
            return System.Delegate.CreateDelegate(delegateType, this, handler);
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
            
            #line 9 "..\..\..\..\..\Pages\Log\LogsView.xaml"
            ((tscui.Pages.Log.LogsView)(target)).Loaded += new System.Windows.RoutedEventHandler(this.splLog_Loaded1);
            
            #line default
            #line hidden
            return;
            case 2:
            this.splLog = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 3:
            this.btnGetLog = ((System.Windows.Controls.Button)(target));
            
            #line 20 "..\..\..\..\..\Pages\Log\LogsView.xaml"
            this.btnGetLog.Click += new System.Windows.RoutedEventHandler(this.btnGetLog_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.Loglistview = ((System.Windows.Controls.ListView)(target));
            return;
            case 5:
            this.ListViewLogId = ((System.Windows.Controls.GridViewColumn)(target));
            return;
            case 6:
            this.ListViewLogType = ((System.Windows.Controls.GridViewColumn)(target));
            return;
            case 7:
            this.ListViewLogTime = ((System.Windows.Controls.GridViewColumn)(target));
            return;
            case 8:
            this.ListViewLogContent = ((System.Windows.Controls.GridViewColumn)(target));
            return;
            case 9:
            
            #line 42 "..\..\..\..\..\Pages\Log\LogsView.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            
            #line 43 "..\..\..\..\..\Pages\Log\LogsView.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click_1);
            
            #line default
            #line hidden
            return;
            case 11:
            
            #line 44 "..\..\..\..\..\Pages\Log\LogsView.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click_ExportLog);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

