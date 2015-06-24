﻿using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Apex.Controls;
using System.Diagnostics;

namespace tscui
{
    /// <summary>
    /// Interaction logic for tscuiWindow.xaml
    /// </summary>
    public partial class tscuiWindow : CustomWindow
    {
        public tscuiWindow()
        {
           // WindowState = System.Windows.WindowState.Maximized;
            InitializeComponent();
           tb.SetResourceReference(TextBlock.TextProperty,"tscinfo");
        }

        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void maximizeButton_Click(object sender, RoutedEventArgs e)
        {
           // WindowState = System.Windows.WindowState.Maximized;
        }

        private void restoreButton_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Normal;
        }

        private void minimizeButton_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void borderWindowTitle_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //  Is it a double click?
            if (e.ClickCount == 2)
            {
                //  Toggle between maximized and normal.
                WindowState = WindowState == WindowState.Maximized ? WindowState.Normal : WindowState.Maximized;
            }

            //  Is it a drag?
            if (e.ClickCount == 1)
                DragMove();
        }

        private void thumbTopLeft_DragDelta(object sender, System.Windows.Controls.Primitives.DragDeltaEventArgs e)
        {
            var desiredLeft = Left + e.HorizontalChange;
            var desiredTop = Top + e.VerticalChange;
            var desiredWidth = Width - e.HorizontalChange;
            var desiredHeight = Height - e.VerticalChange;
            Width = Math.Max(desiredWidth, MinWidth);
            Height = Math.Max(desiredHeight, MinHeight);
            Top = desiredTop;
            Left = desiredLeft;
        }

        private void thumbTop_DragDelta(object sender, System.Windows.Controls.Primitives.DragDeltaEventArgs e)
        {
            var desiredTop = Top + e.VerticalChange;
            var desiredHeight = Height - e.VerticalChange;
            Height = Math.Max(desiredHeight, MinHeight);
            Top = desiredTop;
        }

        private void thumbTopRight_DragDelta(object sender, System.Windows.Controls.Primitives.DragDeltaEventArgs e)
        {
            var desiredTop = Top + e.VerticalChange;
            var desiredHeight = Height - e.VerticalChange;
            var desiredWidth = Width + e.HorizontalChange;
            Width = Math.Max(desiredWidth, MinWidth);
            Height = Math.Max(desiredHeight, MinHeight);
            Top = desiredTop;
        }

        private void thumbLeft_DragDelta(object sender, System.Windows.Controls.Primitives.DragDeltaEventArgs e)
        {
            var desiredLeft = Left + e.HorizontalChange;
            var desiredWidth = Width - e.HorizontalChange;
            Width = Math.Max(desiredWidth, MinWidth);
            Left = desiredLeft;
        }

        private void thumbRight_DragDelta(object sender, System.Windows.Controls.Primitives.DragDeltaEventArgs e)
        {
            var desiredWidth = Width + e.HorizontalChange;
            Width = Math.Max(desiredWidth, MinWidth);
        }

        private void thumbBottomLeft_DragDelta(object sender, System.Windows.Controls.Primitives.DragDeltaEventArgs e)
        {
            var desiredLeft = Left + e.HorizontalChange;
            var desiredWidth = Width - e.HorizontalChange;
            var desiredHeight = Height + e.VerticalChange;
            Width = Math.Max(desiredWidth, MinWidth);
            Height = Math.Max(desiredHeight, MinHeight);
            Left = desiredLeft;
        }

        private void thumbBottom_DragDelta(object sender, System.Windows.Controls.Primitives.DragDeltaEventArgs e)
        {
            var desiredHeight = Height + e.VerticalChange;
            Height = Math.Max(desiredHeight, MinHeight);
        }

        private void thumbBottomRight_DragDelta(object sender, System.Windows.Controls.Primitives.DragDeltaEventArgs e)
        {
            var desiredWidth = Width + e.HorizontalChange;
            var desiredHeight = Height + e.VerticalChange;
            Width = Math.Max(desiredWidth, MinWidth);
            Height = Math.Max(desiredHeight, MinHeight);
        }

        private void zuneShell_Closed(object sender, EventArgs e)
        {
           // Console.WriteLine("zuneShell_Closed");
        }

        private void zuneShell_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Console.WriteLine("zuneShell_Closing");
            Process current = Process.GetCurrentProcess();
            current.Kill();
        }



        private void zuneShell_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            tscstatus.Width = this.Width;
        }
      
    }
}
