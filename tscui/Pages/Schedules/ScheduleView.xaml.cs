using System;
using System.Collections.Generic;
using System.Data;
using System.Linq.Expressions;
using System.Windows.Controls;
using System.Windows.Navigation;
using Apex.MVVM;
using tscui.Service;
using tscui.Models;
using System.Threading;
using System.Windows;
using System.Windows.Threading;

namespace tscui.Pages.Schedules
{
    public enum OrderStatus { None, New, Processing, Shipped, Received };
    /// <summary>
    /// Interaction logic for CountDownView.xaml
    /// </summary>
    [View(typeof(ScheduleViewModel))]
    public partial class ScheduleView : UserControl,IView
    {
        private TscData td = Utils.Utils.GetTscDataByApplicationCurrentProperties();
        private Byte rowvisibleflag = 0;
        public ScheduleView()
        {
            InitializeComponent();
        }

        public void OnActivated()
        {
            //throw new NotImplementedException();
        }

        public void OnDeactivated()
        {
            //throw new NotImplementedException();
        }
        /// <summary>
        /// 得到eventid不为0 的第一条数据 的ScheduleId数据
        /// 并赋予sldScheduleID
        /// </summary>
        /// <param name="ls"></param>
        private void initSldScheduleId(List<Schedule> ls)
        {
            if (ls == null)
                return;
            foreach (Schedule s in ls)
            {
                if (s.ucEventId != 0)
                {
                    sldScheduleId.Value = s.ucId;
                    break;
                }
            }
        }
        /// <summary>
        /// 返回EventId不为0 的数据。
        /// 主要是EventId为0的数据不是合法的数据
        /// </summary>
        /// <param name="ls"></param>
        /// <returns></returns>
        private List<Schedule> initSchedule2DataGrid(List<Schedule> ls)
        {
            List<Schedule> newLs = new List<Schedule>();
            if (ls == null)
                return null;
            foreach (Schedule s in ls)
            {
                if(s.ucId == ((byte)sldScheduleId.Value))
                {
                    newLs.Add(s);
                }
            }
            return newLs;
        }
        
        private delegate void DelegateInitSchedule();
        private void DispatcherInitSchedule(object state)
        {
            this.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new DelegateInitSchedule(InitSchedule));
        }
        private void InitSchedule()
        {
           
            List<Schedule> ls = td.ListSchedule;
            initSldScheduleId(ls);   
            string selfcontrol = (string)App.Current.Resources.MergedDictionaries[3]["dic_schedule_self_control"];
            string off = (string)App.Current.Resources.MergedDictionaries[3]["dic_schedule_off"];
            string flashing = (string)App.Current.Resources.MergedDictionaries[3]["dic_schedule_flashing"];
            string allred = (string)App.Current.Resources.MergedDictionaries[3]["dic_schedule_allred"];
            string reaction = (string)App.Current.Resources.MergedDictionaries[3]["dic_schedule_reaction"];
            string secondreaction = (string)App.Current.Resources.MergedDictionaries[3]["dic_schedule_secondreaction"];
            string gpscoordination = (string)App.Current.Resources.MergedDictionaries[3]["dic_schedule_gpscoordination"];
            string one = (string)App.Current.Resources.MergedDictionaries[3]["dic_schedule_self_one"];
            string maincoordination = (string)App.Current.Resources.MergedDictionaries[3]["dic_maincoordination"];
            string system = (string)App.Current.Resources.MergedDictionaries[3]["dic_schedule_system"];
            string manual = (string)App.Current.Resources.MergedDictionaries[3]["dic_schedule_manual"];
            string PreAnalysis = (string)App.Current.Resources.MergedDictionaries[3]["dic_schedule_PreAnalysis"];

            List<ScheduleCtrl> lsc = new List<ScheduleCtrl>();
            lsc.Add(new ScheduleCtrl() { name = selfcontrol, value = (byte)0 });
            lsc.Add(new ScheduleCtrl() { name = off, value = (byte)1 });
            lsc.Add(new ScheduleCtrl() { name = flashing, value = 2 });
            lsc.Add(new ScheduleCtrl() { name = allred, value = 3 });
            lsc.Add(new ScheduleCtrl() { name = reaction, value = 6 });
            lsc.Add(new ScheduleCtrl() { name = secondreaction, value = 5 });
            lsc.Add(new ScheduleCtrl() { name = gpscoordination, value = 7 });
         //  lsc.Add(new ScheduleCtrl() { name = one, value = 8 });
            lsc.Add(new ScheduleCtrl() { name = maincoordination, value = 11 });
            lsc.Add(new ScheduleCtrl() { name = system, value = 12 });
            lsc.Add(new ScheduleCtrl() { name = manual, value = 13 });
            lsc.Add(new ScheduleCtrl() { name = PreAnalysis, value = 9 });
            cbxucCtrl.ItemsSource = lsc;

            List<Pattern> lp = td.ListPattern;
            ucTimePatternId.ItemsSource = lp;

            string hd = (string)App.Current.Resources.MergedDictionaries[3]["dic_schedule_hd_control"];
            string nofun = (string)App.Current.Resources.MergedDictionaries[3]["dic_schedule_no_fun"];
            string nospecial = (string)App.Current.Resources.MergedDictionaries[3]["dic_schedule_no_special"];
            List<ScheduleAuxOut> lsao = new List<ScheduleAuxOut>();
            lsao.Add(new ScheduleAuxOut() { name = hd, value = 8 });
            lsao.Add(new ScheduleAuxOut() { name = nofun, value = 0 });

            List<ScheduleSpecialOut> lsso = new List<ScheduleSpecialOut>();
            lsso.Add(new ScheduleSpecialOut() { name = nospecial, value = 0 });
            
        }
        private void UserControl_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
           
            if (td == null)
            {
                this.Visibility = Visibility.Hidden;
                return;
            }
            this.Visibility = Visibility.Visible;
            ThreadPool.QueueUserWorkItem(DispatcherInitSchedule);
        }


        private void sldScheduleId_ValueChanged(object sender, System.Windows.RoutedPropertyChangedEventArgs<double> e)
        {
            try
            {
                if (td == null)
                    return;
                rowvisibleflag = 0;
                scheduleDataGrid.ItemsSource = null;
                scheduleDataGrid.ItemsSource = initSchedule2DataGrid(td.ListSchedule);
            }
            catch (Exception ex)
            {
                return;
            }
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            foreach (Schedule chkSchedule in td.ListSchedule)
            {
                if (chkSchedule.ucEventId != 0 && chkSchedule.ucTimePatternId == 0)
                {
                    MessageBox.Show("非0时段序号的方案号未选择！","时段错误",MessageBoxButton.OK,MessageBoxImage.Error);
                    return;
                }
                if ((chkSchedule.ucHour < 0 || chkSchedule.ucHour > 23) ||(chkSchedule.ucMin < 0 || chkSchedule.ucMin > 59))
                {
                    MessageBox.Show("时间设置不符合规范!\r\n小时: 0-23\r\n分钟: 0-59","时段错误",MessageBoxButton.OK,MessageBoxImage.Error);
                    return;
                }
            }
            Message m = TscDataUtils.SetSchedule(td.ListSchedule);
            if (m.flag)
            {
                MessageBox.Show("时段保存成功！", "时段保存", MessageBoxButton.OK, MessageBoxImage.Information);
                sldScheduleId_ValueChanged(this,null);
            }
            else
            {
                MessageBox.Show("时段保存失败！", "时段保存", MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }

        private void scheduleDataGrid_LoadingRow(object sender, DataGridRowEventArgs e)
        {
         //   e.Row.Header = e.Row.GetIndex() + 1;
            e.Row.Header = "-";
            Schedule currentrowSchedule = e.Row.Item as Schedule;
            if (currentrowSchedule != null)
            {
                byte result = currentrowSchedule.ucEventId;
                if (result == 0)
                {
                    rowvisibleflag += 1;
                    e.Row.Header = "+";
                }

            }
            if (rowvisibleflag >= 2 && currentrowSchedule.ucEventId == 0)
            {
                e.Row.Visibility = Visibility.Collapsed;
            }
        }

        private void scheduleDataGrid_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            try
            {
                Schedule currentrowSchedule = e.Row.Item as Schedule;
                if (currentrowSchedule != null)
                {
                    byte result = currentrowSchedule.ucEventId;
                  //  if(result ==0x0)return ;
                }
                if ((e.Row.GetIndex() + 1) <= scheduleDataGrid.Items.Count)
                {
                    scheduleDataGrid.SelectedIndex = e.Row.GetIndex() + 1;
                    DataGridRow r =  
                        (DataGridRow) scheduleDataGrid.ItemContainerGenerator.ContainerFromIndex(e.Row.GetIndex() + 1);
                    r.Visibility = Visibility.Visible;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("时段序号行编辑异常!");
            }
        }

        private void Delete_ScheduleId(object sender, RoutedEventArgs e)
        {
            try
            {
                Schedule currentrowSchedule = scheduleDataGrid.SelectedItem as Schedule;
                if (currentrowSchedule == null || currentrowSchedule.ucEventId == 0x0)
                {
                    MessageBox.Show("删除子时段号非0!");
                    return;
                }
                if (
                    MessageBox.Show("确定要删除时段序号:" + Convert.ToByte(currentrowSchedule.ucEventId) + "?", "删除",
                        MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    currentrowSchedule.ucEventId = 0;
                    currentrowSchedule.ucCtrl = 0;
                    currentrowSchedule.ucHour = 0;
                    currentrowSchedule.ucMin = 0;
                    currentrowSchedule.ucTimePatternId = 0;
                    this.sldScheduleId_ValueChanged(this, null);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("时段序号删除异常!");
            }
        }


        private void Add_ScheduleId(object sender, RoutedEventArgs e)
        {
            try
            {
                Schedule currentrowSchedule = scheduleDataGrid.SelectedItem as Schedule;
                if (currentrowSchedule == null || currentrowSchedule.ucEventId != 0x0)
                {
                    MessageBox.Show("已经存在子时段号" + (byte)(scheduleDataGrid.SelectedIndex + 1));
                    return;
                }
                int addindex = scheduleDataGrid.SelectedIndex;
                    currentrowSchedule.ucEventId = (byte)(scheduleDataGrid.SelectedIndex+1);
                    this.sldScheduleId_ValueChanged(this, null);
                    scheduleDataGrid.SelectedItem = scheduleDataGrid.Items[addindex];
                    

            }
            catch (Exception ex)
            {
                MessageBox.Show("时段序号添加异常!");
            }

        }


    }
    public class ScheduleCtrl
    {
        public string name { get; set; }
        public byte value { get; set; }
    }
    public class ScheduleAuxOut
    {
        public string name { get; set; }
        public byte value { get; set; }
    }
    public class ScheduleSpecialOut
    {
        public string name { get; set; }
        public byte value { get; set; }
    }
    public class TimePatternId
    {
        public string name { get; set; }
        public byte value { get; set; }
    }
}
