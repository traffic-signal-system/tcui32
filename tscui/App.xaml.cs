using System;
using System.Diagnostics;
using System.Globalization;
using System.Windows;

namespace tscui
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
      
        protected override void OnStartup(StartupEventArgs e)
        {
           base.OnStartup(e);
            string Productname = System.Windows.Forms.Application.ProductName;
            Process[] p = Process.GetProcessesByName(Productname);
            if (p.Length > 1)
            {
                MessageBox.Show("程序已经在运行!", "信号机", MessageBoxButton.OK, MessageBoxImage.Error);
                Environment.Exit(0);
            }
           System.Windows.Forms.Application.EnableVisualStyles();
           LoadLanguage();
        }
    
        private void LoadLanguage()
        {
            CultureInfo currentCultureInfo = CultureInfo.CurrentCulture;
           // CultureInfo currentCultureInfo = CultureInfo.CreateSpecificCulture("zh_CN");
            ResourceDictionary langRd = null;
            try
            {
                langRd =Application.LoadComponent(new Uri(@"Resources/Lang/" + currentCultureInfo.Name + ".xaml", UriKind.Relative)) as ResourceDictionary;
            }
            catch
            {
                ;
            }
            //this.Resources.MergedDictionaries.Add(langRd);
            if (langRd != null)
            {
                if (this.Resources.MergedDictionaries.Count > 3)
                {
                    this.Resources.MergedDictionaries.RemoveAt(3);
                }
               this.Resources.MergedDictionaries.Add(langRd);
            }


        }
    }
}
