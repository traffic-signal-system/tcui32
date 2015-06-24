using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace tscui.Pages.Log
{
    /// <summary>
    /// The ThePagesViewModel ViewModel class.
    /// </summary>
    public class LogsViewModel : PageViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ThePagesViewModel"/> class.
        /// </summary>
        public LogsViewModel()
        {
            Title = (string)App.Current.Resources.MergedDictionaries[3]["tsc_menu_log"];
        }
    }
    public class ListViewHelper
    {

        #region 附加依赖属性定义

        public static readonly DependencyProperty SortEnabledProperty =DependencyProperty.RegisterAttached("SortEnabled", typeof(bool), typeof(ListViewHelper),
            new PropertyMetadata(OnSortEnabledChanged));
        public static readonly DependencyProperty SortPropertyProperty =DependencyProperty.RegisterAttached("SortProperty", typeof(string), typeof(ListViewHelper),
            new PropertyMetadata(OnSortPropertyChanged));
        #endregion

        #region 依赖属性封装

        public static bool GetSortEnabled(ListView lv)
        {
            return (bool)lv.GetValue(SortEnabledProperty);
        }

        public static void SetSortEnabled(ListView lv, bool value)
        {
            lv.SetValue(SortEnabledProperty, value);
        }
        
        public static string GetSortProperty(GridViewColumn column)
        {
            return (string)column.GetValue(SortPropertyProperty);
        }

        public static void SetSortProperty(GridViewColumn column, string propName)
        {
            column.SetValue(SortPropertyProperty, propName);
        }
        #endregion


        #region 属性改变事件

        static void OnSortEnabledChanged(DependencyObject dobj, DependencyPropertyChangedEventArgs e)
        {
            var listview = dobj as ListView;

            if (listview != null)
            {

                if ((bool)e.NewValue)

                    listview.AddHandler(GridViewColumnHeader.ClickEvent, new RoutedEventHandler(OnGridViewColumnHeaderClicked));
                else
                    listview.RemoveHandler(GridViewColumnHeader.ClickEvent, new RoutedEventHandler(OnGridViewColumnHeaderClicked));
            }

        }

        static void OnSortPropertyChanged(DependencyObject dobj, DependencyPropertyChangedEventArgs e)
        {

            var column = dobj as GridViewColumn;

            var propName = (string)e.NewValue;

            if (column.DisplayMemberBinding == null && column.CellTemplate == null && propName != null)
            {

                var binding = new Binding(propName);

                column.DisplayMemberBinding = binding;

            }

        }
        #endregion

        #region UI事件和辅助函数
        static void OnGridViewColumnHeaderClicked(object sender, RoutedEventArgs e)
        {

            var header = e.OriginalSource as GridViewColumnHeader;

            var listview = sender as ListView;

            string propName;

            if (listview != null && header != null && (propName = GetSortProperty(header.Column)) != null)
            {

                UpdateSortDescription(CollectionViewSource.GetDefaultView(listview.ItemsSource), propName);

            }

        }

        static void UpdateSortDescription(ICollectionView view, string propName)
        {

            ListSortDirection direction = ListSortDirection.Ascending;

            if (view.SortDescriptions.Count > 0 && view.SortDescriptions[0].PropertyName == propName)
            {

                if (view.SortDescriptions[0].Direction == ListSortDirection.Ascending)

                    direction = ListSortDirection.Descending;
            }
            view.SortDescriptions.Clear();
            view.SortDescriptions.Add(new SortDescription(propName, direction));
        }
        #endregion
    }
}
