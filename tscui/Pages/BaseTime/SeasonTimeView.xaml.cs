using System;
using System.Collections.Generic;
using System.Windows.Controls;
using Apex.MVVM;
using System.Windows;
using tscui.Models;
using tscui.Service;
using System.Threading;

namespace tscui.Pages.BaseTime
{
    /// <summary>
    /// Interaction logic for SeasonTimeView.xaml
    /// </summary>
    [View(typeof(SeasonTimeViewModel))]
    public partial class SeasonTimeView : UserControl
    {
        TscData td = (TscData)Application.Current.Properties[Define.TSC_DATA];
        public SeasonTimeView()
        {
            InitializeComponent();
        }

        private void Allday_Checked(object sender, System.Windows.RoutedEventArgs e)
        {
           
            Monday.IsChecked = true;
            Thursday.IsChecked = true;
            Tuesday.IsChecked = true;
            Wednesday.IsChecked = true;
            Friday.IsChecked = true;
            Saturday.IsChecked = true;
            Sunday.IsChecked = true;
        }

        private void Allday_Unchecked(object sender, System.Windows.RoutedEventArgs e)
        {
            Monday.IsChecked = false;
            Thursday.IsChecked = false;
            Tuesday.IsChecked = false;
            Wednesday.IsChecked = false;
            Friday.IsChecked = false;
            Saturday.IsChecked = false;
            Sunday.IsChecked = false;
        }
      

        private void initWeekdayDisplay(byte weekday)
        {
            //byte weekday = p.ucWeekFlag;
            for (int i = 1; i <= 7; i++)
            {
                if (((weekday >> i) & 0x01) == 0x01)
                {
                    if (i == 1)
                    {
                        Monday.IsChecked = true;
                    }
                    else if (i == 2)
                    {
                        Tuesday.IsChecked = true;
                    }
                    else if (i == 3)
                    {
                        Wednesday.IsChecked = true;
                    }
                    else if (i == 4)
                    {
                        Thursday.IsChecked = true;
                    }
                    else if (i == 5)
                    {
                        Friday.IsChecked = true;
                    }
                    else if (i == 6)
                    {
                        Saturday.IsChecked = true;
                    }
                    else if (i == 7)
                    {
                        Sunday.IsChecked = true;
                    }
                }
                else
                {
                    if (i == 1)
                    {
                        Monday.IsChecked = false;
                    }
                    else if (i == 2)
                    {
                        Tuesday.IsChecked = false;
                    }
                    else if (i == 3)
                    {
                        Wednesday.IsChecked = false;
                    }
                    else if (i == 4)
                    {
                        Thursday.IsChecked = false;
                    }
                    else if (i == 5)
                    {
                        Friday.IsChecked = false;
                    }
                    else if (i == 6)
                    {
                        Saturday.IsChecked = false;
                    }
                    else if (i == 7)
                    {
                        Sunday.IsChecked = false;
                    }
                }
            }
        }
        private void initScheduleId()
        {
            if (td == null)
                return;
            List<tscui.Models.Schedule> ls = td.ListSchedule;
            List<byte> li = new List<byte>();
            foreach (Schedule s in ls)
            {
                if (!li.Contains(s.ucId) && s.ucId != 0)
                {
                    li.Add(s.ucId);
                }
            }
            cbxScheduleId.ItemsSource = li;
        }
        private void UserControl_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            try
            {
               // td = (TscData)Application.Current.Properties[Define.TSC_DATA];
                if (td == null)
                {
                    this.Visibility = Visibility.Hidden;
                    return;
                }
                else
                {
                    this.Visibility = Visibility.Visible;
                }
                initScheduleId();
             
                List<Plan> lp = td.ListPlan;
                List<byte> lb = new List<byte>();
                List<Schedule> ls = td.ListSchedule;
                foreach (Schedule s in ls)
                {
                    if (!lb.Contains(s.ucId) && s.ucEventId != 0 && s.ucEventId != 0)
                    {
                        lb.Add(s.ucId);
                    }
                }
                cbxScheduleId.ItemsSource = lb;
                foreach(Plan p in lp)
                {
                    //如果没有数据不会进入
                    if (p.ucId>=21 && p.ucId <=30)
                    {
                        lbxPlanId.Items.Add(p.ucId);
                        lbxPlanId.SelectedIndex = 0x0;
                    }
                    
                }
               
            }
            catch(Exception ex)
            {
                MessageBox.Show("加载周时基异常!","时基",MessageBoxButton.OK,MessageBoxImage.Exclamation);
               
                //ApexBroker.GetShell().ShowPopup(new FailePopup());
            }
        }

        private void lbxPlanId_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (td == null)
                return;
            List<Plan> lp = td.ListPlan;
            Plan p1 = new Plan();
            foreach(Plan p in lp)
            {
                for (int i = 21; i <= 30;i++ )
                {
                    if (!(p.ucId == i) && !lbxPlanId.Items.Contains(Convert.ToByte(i)))
                    {
                        p1.ucId = Convert.ToByte(i);
                        p1.ucScheduleId = 1;
                        p1.usMonthFlag = 0;
                        p1.ucWeekFlag = 0;
                        p1.ulDayFlag = 0;
                        break;
                    }
                }
                break;    
            }
            if (p1.ucId <= 30 && p1.ucId >=21)
            {
                lbxPlanId.Items.Add(p1.ucId);
                lp.Add(p1);
            }
            
        }


        private void lbxPlanId_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (td == null)
                return;
            byte id = Convert.ToByte(lbxPlanId.SelectedItem);
            List<Plan> lp = td.ListPlan;
            foreach(Plan p in lp) 
            {
                if (p.ucId == id)
                {
                    cbxScheduleId.SelectedItem = p.ucScheduleId;
                    byte weekday =p.ucWeekFlag;
                    initWeekdayDisplay(weekday);
                    break;
                }
            }
        }

        private void cbxScheduleId_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (td == null)
                return;
            List<Plan> lp = td.ListPlan;
            foreach (Plan p in lp)
            {
                if (p.ucId == Convert.ToByte(lbxPlanId.SelectedItem))
                {
                    p.ucScheduleId = Convert.ToByte(cbxScheduleId.SelectedItem);
                    break;
                }
            }
        }

        private void Monday_Checked(object sender, RoutedEventArgs e)
        {
            if (td == null)
                return;
            List<Plan> lp = td.ListPlan;
            foreach (Plan p in lp)
            {
                if(p.ucId == Convert.ToByte(lbxPlanId.SelectedItem))
                {

                    p.ucWeekFlag = (byte)(p.ucWeekFlag | 0x02);
                    break;
                }
            }
        }

        private void Monday_Unchecked(object sender, RoutedEventArgs e)
        {
            if (td == null)
                return;
            List<Plan> lp = td.ListPlan;
            foreach (Plan p in lp)
            {
                if (p.ucId == Convert.ToByte(lbxPlanId.SelectedItem))
                {

                    p.ucWeekFlag = (byte)(p.ucWeekFlag & 0xfc);
                    break;
                }
            }
        }

        private void btnRead_Click(object sender, RoutedEventArgs e)
        {
            if (td == null)
                return;
            List<Plan> lp = td.ListPlan;
            foreach(Plan p in lp)
            {
                Console.WriteLine(p.ucWeekFlag);
            }
        }

        private void Tuesday_Checked(object sender, RoutedEventArgs e)
        {
            if (td == null)
                return;
            List<Plan> lp = td.ListPlan;
            foreach (Plan p in lp)
            {
                if (p.ucId == Convert.ToByte(lbxPlanId.SelectedItem))
                {

                    p.ucWeekFlag = (byte)(p.ucWeekFlag | 0x04);
                    break;
                }
            }
        }

        private void Wednesday_Checked(object sender, RoutedEventArgs e)
        {
            if (td == null)
                return;
            List<Plan> lp = td.ListPlan;
            foreach (Plan p in lp)
            {
                if (p.ucId == Convert.ToByte(lbxPlanId.SelectedItem))
                {

                    p.ucWeekFlag = (byte)(p.ucWeekFlag | 0x08);
                    break;
                }
            }
        }

        private void Thursday_Checked(object sender, RoutedEventArgs e)
        {
            if (td == null)
                return;
            List<Plan> lp = td.ListPlan;
            foreach (Plan p in lp)
            {
                if (p.ucId == Convert.ToByte(lbxPlanId.SelectedItem))
                {

                    p.ucWeekFlag = (byte)(p.ucWeekFlag | 0x10);
                    break;
                }
            }
        }

        private void Friday_Checked(object sender, RoutedEventArgs e)
        {
            if (td == null)
                return;
            List<Plan> lp = td.ListPlan;
            foreach (Plan p in lp)
            {
                if (p.ucId == Convert.ToByte(lbxPlanId.SelectedItem))
                {

                    p.ucWeekFlag = (byte)(p.ucWeekFlag | 0x20);
                    break;
                }
            }
        }

        private void Saturday_Checked(object sender, RoutedEventArgs e)
        {
            if (td == null)
                return;
            List<Plan> lp = td.ListPlan;
            foreach (Plan p in lp)
            {
                if (p.ucId == Convert.ToByte(lbxPlanId.SelectedItem))
                {

                    p.ucWeekFlag = (byte)(p.ucWeekFlag | 0x40);
                    break;
                }
            }
        }

        private void Sunday_Checked(object sender, RoutedEventArgs e)
        {
            if (td == null)
                return;
            List<Plan> lp = td.ListPlan;
            foreach (Plan p in lp)
            {
                if (p.ucId == Convert.ToByte(lbxPlanId.SelectedItem))
                {

                    p.ucWeekFlag = (byte)(p.ucWeekFlag | 0x80);
                    break;
                }
            }
        }

        private void Tuesday_Unchecked(object sender, RoutedEventArgs e)
        {
            if (td == null)
                return;
            List<Plan> lp = td.ListPlan;
            foreach (Plan p in lp)
            {
                if (p.ucId == Convert.ToByte(lbxPlanId.SelectedItem))
                {

                    p.ucWeekFlag = (byte)(p.ucWeekFlag & 0xfa);
                    break;
                }
            }
        }

        private void Wednesday_Unchecked(object sender, RoutedEventArgs e)
        {
            if (td == null)
                return;
            List<Plan> lp = td.ListPlan;
            foreach (Plan p in lp)
            {
                if (p.ucId == Convert.ToByte(lbxPlanId.SelectedItem))
                {

                    p.ucWeekFlag = (byte)(p.ucWeekFlag & 0xf6);
                    break;
                }
            }
        }

        private void Thursday_Unchecked(object sender, RoutedEventArgs e)
        {
            if (td == null)
                return;
            List<Plan> lp = td.ListPlan;
            foreach (Plan p in lp)
            {
                if (p.ucId == Convert.ToByte(lbxPlanId.SelectedItem))
                {

                    p.ucWeekFlag = (byte)(p.ucWeekFlag & 0xee);
                    break;
                }
            }
        }

        private void Friday_Unchecked(object sender, RoutedEventArgs e)
        {
            if (td == null)
                return;
            List<Plan> lp = td.ListPlan;
            foreach (Plan p in lp)
            {
                if (p.ucId == Convert.ToByte(lbxPlanId.SelectedItem))
                {

                    p.ucWeekFlag = (byte)(p.ucWeekFlag & 0xde);
                    break;
                }
            }
        }

        private void Saturday_Unchecked(object sender, RoutedEventArgs e)
        {
            if (td == null)
                return;
            List<Plan> lp = td.ListPlan;
            foreach (Plan p in lp)
            {
                if (p.ucId == Convert.ToByte(lbxPlanId.SelectedItem))
                {

                    p.ucWeekFlag = (byte)(p.ucWeekFlag & 0xbe);
                    break;
                }
            }
        }

        private void Sunday_Unchecked(object sender, RoutedEventArgs e)
        {
            if (td == null)
                return;
            List<Plan> lp = td.ListPlan;
            foreach (Plan p in lp)
            {
                if (p.ucId == Convert.ToByte(lbxPlanId.SelectedItem))
                {

                    p.ucWeekFlag = (byte)(p.ucWeekFlag & 0x7e);
                    break;
                }
            }
        }
        private void SavePlan()
        {
            if (td == null)
                td = Utils.Utils.GetTscDataByApplicationCurrentProperties();
            List<Plan> lp = td.ListPlan;
            foreach (Plan p in lp)
            {
                if (p.ucId >= 21 && p.ucId <= 30)
                {
                    p.usMonthFlag = 8190;
                    p.ulDayFlag = 4294967294;
                }
            }
            for (Byte planIndex = 0; planIndex < td.ListPlan.Count; planIndex++)
            {
                if (td.ListPlan[planIndex].ucId >= 21 && td.ListPlan[planIndex].ucId <= 30)
                {

                    if (td.ListPlan[planIndex].ucWeekFlag == 0x0)
                    {
                        for (Byte lbxplanidx = 0; lbxplanidx < lbxPlanId.Items.Count; lbxplanidx++)
                        {
                            if (td.ListPlan[planIndex].ucId == Convert.ToByte(lbxPlanId.Items[lbxplanidx]))
                            {
                                lbxPlanId.Items.RemoveAt(lbxplanidx);
                                break;
                            }
                        }
                        td.ListPlan.RemoveAt(planIndex);
                        --planIndex;
                    }

                }
            }
            bool m = TscDataUtils.SetPlanByWeekend(td.Node.sIpAddress, td.Node.iPort, lp);
            if (m)
            {
                MessageBox.Show("按周时基保存成功!", "时基", MessageBoxButton.OK, MessageBoxImage.Information);

            }
            else
            {
                MessageBox.Show("周时基保存失败!", "时基", MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }
        /// <summary>
        /// 多线程
        /// </summary>
        /// <param name="state"></param>
        private void SavePlan(object state)
        {
            //if (td == null)
            //    return;
            //List<Plan> lp = td.ListPlan;
            //foreach (Plan p in lp)
            //{
            //    if (p.ucId >= 21 && p.ucId <= 30)
            //    {
            //        p.usMonthFlag = 8190;
            //        p.ulDayFlag = 4294967294;
            //    }
            //}
            //for (Byte planIndex = 0; planIndex < td.ListPlan.Count; planIndex++)
            //{
            //    if (td.ListPlan[planIndex].ucId >= 21 && td.ListPlan[planIndex].ucId <=30)
            //    {
            //        if (td.ListPlan[planIndex].ucWeekFlag == 0x0)
            //            td.ListPlan.Remove(td.ListPlan[planIndex]);
            //    }
            //}

            //TscDataUtils.SetPlanByWeekend(td.Node.sIpAddress, td.Node.iPort, lp);
        }
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            SavePlan();
        }

        private void UserControl_Unloaded(object sender, RoutedEventArgs e)
        {
            //try
            //{ 
            //     ThreadPool.QueueUserWorkItem(SavePlan);
            //}
            //catch (Exception ex)
            //{
            //    ;//  MessageBox.Show("SeasonTime: " + ex.ToString());
            //}
        }

    

        private void Delete_Plan(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Convert.ToByte(lbxPlanId.SelectedItem) == 0x0)
                    return;
                if (
                    MessageBox.Show("确定要删除时基:" + Convert.ToByte(lbxPlanId.SelectedItem).ToString() + "?", "删除",
                        MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    for (Byte planindex = 0; planindex < td.ListPlan.Count; planindex++)
                    {
                        if (td.ListPlan[planindex].ucId >= 21 && td.ListPlan[planindex].ucId <= 30)
                        {
                            if (td.ListPlan[planindex].ucId == (Convert.ToByte(lbxPlanId.SelectedItem)))
                            {
                                td.ListPlan.RemoveAt(planindex);
                                break;
                            }
                        }
                    }
                    lbxPlanId.Items.Remove(lbxPlanId.SelectedItem);

                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("删除周时基异常!", "时基", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }
    }
}
