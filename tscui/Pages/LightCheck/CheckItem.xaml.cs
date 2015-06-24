using System.Windows;
using System.Windows.Controls;
namespace tscui.Pages.LightCheck
{
    /// <summary>
    /// CheckItem.xaml 的交互逻辑
    /// </summary>
    public partial class CheckItem : UserControl
    {
        
        public CheckItem()
        {
            InitializeComponent();
        }
        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            R1.IsChecked = true;
            R2.IsChecked = true;
            R3.IsChecked = true;
            R4.IsChecked = true;

            G1.IsChecked = true;
            G2.IsChecked = true;
            G3.IsChecked = true;
            G4.IsChecked = true;
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            R1.IsChecked = false;
            R2.IsChecked = false;
            R3.IsChecked = false;
            R4.IsChecked = false;

            G1.IsChecked = false;
            G2.IsChecked = false;
            G3.IsChecked = false;
            G4.IsChecked = false;
        }

       
    }
}
