using System;
using System.Collections.Generic;
using System.Windows.Controls;
using Apex.MVVM;
using Apex.Behaviours;
using tscui.Models;
using tscui.Service;
using System.Windows;

namespace tscui.Pages.BaseTime
{
    /// <summary>
    /// Interaction logic for BaseTimeView.xaml
    /// </summary>
    [View(typeof (BaseTimeViewModel))]
    public partial class BaseTimeView : UserControl, IView
    {
        private TscData td = Utils.Utils.GetTscDataByApplicationCurrentProperties();

        public BaseTimeView()
        {
            InitializeComponent();
        }

        public void OnActivated()
        {
            //throw new NotImplementedException();
            SlideFadeInBehaviour.DoSlideFadeIn(this);
        }

        public void OnDeactivated()
        {
            //throw new NotImplementedException();
        }

        private void btnRead_Click(object sender, System.Windows.RoutedEventArgs e)
        {

            List<Plan> lp = td.ListPlan;
            foreach (Plan p in lp)
            {
                Console.WriteLine(p.usMonthFlag);
            }
        }

        private void btnSave_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            try
            {
                for (Byte planindex = 0; planindex < td.ListPlan.Count; planindex++)
                {
                    if (td.ListPlan[planindex].ucId >= 30)
                    {
                        if (td.ListPlan[planindex].usMonthFlag == 0x0)
                        {
                            for (Byte lbxplanidx = 0; lbxplanidx < lbxPlanId.Items.Count; lbxplanidx++)
                            {
                                if (td.ListPlan[planindex].ucId == Convert.ToByte(lbxPlanId.Items[lbxplanidx]))
                                {
                                    lbxPlanId.Items.RemoveAt(lbxplanidx);
                                    break;
                                }
                            }
                            td.ListPlan.RemoveAt(planindex);
                            --planindex;
                        }
                    }
                }
                Message m = TscDataUtils.SetPlanByCalendar(td.ListPlan);
                if (m.flag)
                {
                    MessageBox.Show("按月时基保存成功!", "时基", MessageBoxButton.OK, MessageBoxImage.Information);

                }
                else
                {
                    MessageBox.Show("按月时基保存失败!", "时基", MessageBoxButton.OK, MessageBoxImage.Error);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("保存月时基异常!", "时基", MessageBoxButton.OK, MessageBoxImage.Exclamation);

            }
        }

        private void initMonth(ushort month)
        {
            cbxAllMonth_Unchecked(this, null);
            for (int i = 1; i <= 12; i++)
            {
                if (((month >> i) & 0x01) == 0x01)
                {
                    if (i == 1)
                    {
                        cbxJanuary.IsChecked = true;
                        continue;
                    }
                    if (i == 2)
                    {
                        cbxFebruary.IsChecked = true;
                        continue;

                    }
                    if (i == 3)
                    {
                        cbxMarch.IsChecked = true;
                        continue;

                    }
                    if (i == 4)
                    {
                        cbxApril.IsChecked = true;
                        continue;

                    }
                    if (i == 5)
                    {
                        cbxMay.IsChecked = true;
                        continue;

                    }
                    if (i == 6)
                    {
                        cbxJune.IsChecked = true;
                        continue;

                    }
                    if (i == 7)
                    {
                        cbxJuly.IsChecked = true;
                        continue;

                    }
                    if (i == 8)
                    {
                        cbxAugust.IsChecked = true;
                        continue;

                    }
                    if (i == 9)
                    {
                        cbxSeptember.IsChecked = true;
                        continue;

                    }
                    if (i == 10)
                    {
                        cbxOctober.IsChecked = true;
                        continue;

                    }
                    if (i == 11)
                    {
                        cbxNovember.IsChecked = true;
                        continue;

                    }
                    if (i == 12)
                    {
                        cbxDecember.IsChecked = true;
                        continue;

                    }
                }
              
            }
        }

        private void UserControl_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            try
            {
                if (td == null)
                {
                    this.Visibility = Visibility.Hidden;
                    return;
                }
                else
                {
                    this.Visibility = Visibility.Visible;
                }
                List<Plan> lp = td.ListPlan;
                List<Schedule> ls = td.ListSchedule;
                List<byte> lb = new List<byte>();
                foreach (Schedule s in ls)
                {
                    if (!lb.Contains(s.ucId) && s.ucEventId != 0 && s.ucEventId != 0)
                    {
                        lb.Add(s.ucId);
                    }
                }
                cbxScheduleId.ItemsSource = lb;
                foreach (Plan p in lp)
                {
                    if (p.ucId >= 31 && p.ucId <= 40)
                    {
                        lbxPlanId.Items.Add(p.ucId);
                       // cbxScheduleId.SelectedItem = p.ucScheduleId;
                      //  initMonth(p.usMonthFlag);
                        if (lbxPlanId.SelectedIndex != 0x0)
                             lbxPlanId.SelectedIndex = 0x0;
                       // break;
                    }
                }
             
            }
            catch (Exception ex)
            {
                MessageBox.Show("加载月时基界面异常!", "时基", MessageBoxButton.OK, MessageBoxImage.Exclamation);

            }

        }

        private void lbxPlanId_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {

            List<Plan> lp = td.ListPlan;
            Plan pt = new Plan();
            foreach (Plan p in lp)
            {
                for (byte i = 31; i <= 40; i++)
                {
                    if (!lbxPlanId.Items.Contains(i) && !(p.ucId == i))
                    {

                        pt.ucId = i;
                        pt.ucScheduleId = Convert.ToByte(cbxScheduleId.SelectedItem);
                        pt.ucWeekFlag = 254;
                        pt.ulDayFlag = 4294967294;
                        pt.usMonthFlag = 0;
                        break;
                    }
                }
                break;
            }
            if (pt.ucId >= 31 && pt.ucId <= 40)
            {
                lbxPlanId.Items.Add(pt.ucId);
                lp.Add(pt);
            }
        }

        private void lbxPlanId_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (td == null)
                return;
            byte id = Convert.ToByte(lbxPlanId.SelectedItem);
            List<Plan> lp = td.ListPlan;
            foreach (Plan p in lp)
            {
                if (p.ucId == id)
                {
                    cbxScheduleId.SelectedItem = p.ucScheduleId;
                    ushort month = p.usMonthFlag;
                    initMonth(month);
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

        private void cbxJanuary_Unchecked(object sender, System.Windows.RoutedEventArgs e)
        {
            if (td == null)
                return;
            List<Plan> lp = td.ListPlan;
            foreach (Plan p in lp)
            {
                if (p.ucId == Convert.ToByte(lbxPlanId.SelectedItem))
                {

                    p.usMonthFlag = (ushort) (p.usMonthFlag & 8188);
                    break;
                }
            }
        }

        private void cbxJanuary_Checked(object sender, System.Windows.RoutedEventArgs e)
        {
            if (td == null)
                return;
            List<Plan> lp = td.ListPlan;
            foreach (Plan p in lp)
            {
                if (p.ucId == Convert.ToByte(lbxPlanId.SelectedItem))
                {
                    p.usMonthFlag = (ushort) (p.usMonthFlag | 0x02);
                    break;
                }
            }
        }

        private void cbxFebruary_Checked(object sender, System.Windows.RoutedEventArgs e)
        {
            if (td == null)
                return;
            List<Plan> lp = td.ListPlan;
            foreach (Plan p in lp)
            {
                if (p.ucId == Convert.ToByte(lbxPlanId.SelectedItem))
                {

                    p.usMonthFlag = (ushort) (p.usMonthFlag | 0x04);
                    break;
                }
            }
        }

        private void cbxMarch_Checked(object sender, System.Windows.RoutedEventArgs e)
        {
            if (td == null)
                return;
            List<Plan> lp = td.ListPlan;
            foreach (Plan p in lp)
            {
                if (p.ucId == Convert.ToByte(lbxPlanId.SelectedItem))
                {

                    p.usMonthFlag = (ushort) (p.usMonthFlag | 0x08);
                    break;
                }
            }
        }

        private void cbxApril_Checked(object sender, System.Windows.RoutedEventArgs e)
        {
            if (td == null)
                return;
            List<Plan> lp = td.ListPlan;
            foreach (Plan p in lp)
            {
                if (p.ucId == Convert.ToByte(lbxPlanId.SelectedItem))
                {

                    p.usMonthFlag = (ushort) (p.usMonthFlag | 0x10);
                    break;
                }
            }
        }

        private void cbxMay_Checked(object sender, System.Windows.RoutedEventArgs e)
        {
            if (td == null)
                return;
            List<Plan> lp = td.ListPlan;
            foreach (Plan p in lp)
            {
                if (p.ucId == Convert.ToByte(lbxPlanId.SelectedItem))
                {

                    p.usMonthFlag = (ushort) (p.usMonthFlag | 32);
                    break;
                }
            }
        }

        private void cbxJune_Checked(object sender, System.Windows.RoutedEventArgs e)
        {
            if (td == null)
                return;
            List<Plan> lp = td.ListPlan;
            foreach (Plan p in lp)
            {
                if (p.ucId == Convert.ToByte(lbxPlanId.SelectedItem))
                {

                    p.usMonthFlag = (ushort) (p.usMonthFlag | 64);
                    break;
                }
            }
        }

        private void cbxJuly_Checked(object sender, System.Windows.RoutedEventArgs e)
        {
            if (td == null)
                return;
            List<Plan> lp = td.ListPlan;
            foreach (Plan p in lp)
            {
                if (p.ucId == Convert.ToByte(lbxPlanId.SelectedItem))
                {

                    p.usMonthFlag = (ushort) (p.usMonthFlag | 128);
                    break;
                }
            }
        }

        private void cbxAugust_Checked(object sender, System.Windows.RoutedEventArgs e)
        {
            if (td == null)
                return;
            List<Plan> lp = td.ListPlan;
            foreach (Plan p in lp)
            {
                if (p.ucId == Convert.ToByte(lbxPlanId.SelectedItem))
                {

                    p.usMonthFlag = (ushort) (p.usMonthFlag | 256);
                    break;
                }
            }
        }

        private void cbxSeptember_Checked(object sender, System.Windows.RoutedEventArgs e)
        {
            if (td == null)
                return;
            List<Plan> lp = td.ListPlan;
            foreach (Plan p in lp)
            {
                if (p.ucId == Convert.ToByte(lbxPlanId.SelectedItem))
                {

                    p.usMonthFlag = (ushort) (p.usMonthFlag | 512);
                    break;
                }
            }
        }

        private void cbxOctober_Checked(object sender, System.Windows.RoutedEventArgs e)
        {
            if (td == null)
                return;
            List<Plan> lp = td.ListPlan;
            foreach (Plan p in lp)
            {
                if (p.ucId == Convert.ToByte(lbxPlanId.SelectedItem))
                {
                    p.usMonthFlag = (ushort) (p.usMonthFlag | 1024);
                    break;
                }
            }
        }

        private void cbxNovember_Checked(object sender, System.Windows.RoutedEventArgs e)
        {
            if (td == null)
                return;
            List<Plan> lp = td.ListPlan;
            foreach (Plan p in lp)
            {
                if (p.ucId == Convert.ToByte(lbxPlanId.SelectedItem))
                {
                    p.usMonthFlag = (ushort) (p.usMonthFlag | 2048);
                    break;
                }
            }
        }

        private void cbxDecember_Checked(object sender, System.Windows.RoutedEventArgs e)
        {
            if (td == null)
                return;
            List<Plan> lp = td.ListPlan;
            foreach (Plan p in lp)
            {
                if (p.ucId == Convert.ToByte(lbxPlanId.SelectedItem))
                {

                    p.usMonthFlag = (ushort) (p.usMonthFlag | 4096);
                    break;
                }
            }
        }

        private void cbxFebruary_Unchecked(object sender, System.Windows.RoutedEventArgs e)
        {
            if (td == null)
                return;
            List<Plan> lp = td.ListPlan;
            foreach (Plan p in lp)
            {
                if (p.ucId == Convert.ToByte(lbxPlanId.SelectedItem))
                {

                    p.usMonthFlag = (ushort) (p.usMonthFlag & 8186);
                    break;
                }
            }
        }

        private void cbxMarch_Unchecked(object sender, System.Windows.RoutedEventArgs e)
        {
            if (td == null)
                return;
            List<Plan> lp = td.ListPlan;
            foreach (Plan p in lp)
            {
                if (p.ucId == Convert.ToByte(lbxPlanId.SelectedItem))
                {

                    p.usMonthFlag = (ushort) (p.usMonthFlag & 8182);
                    break;
                }
            }
        }

        private void cbxApril_Unchecked(object sender, System.Windows.RoutedEventArgs e)
        {
            if (td == null)
                return;
            List<Plan> lp = td.ListPlan;
            foreach (Plan p in lp)
            {
                if (p.ucId == Convert.ToByte(lbxPlanId.SelectedItem))
                {

                    p.usMonthFlag = (ushort) (p.usMonthFlag & 8174);
                    break;
                }
            }
        }

        private void cbxMay_Unchecked(object sender, System.Windows.RoutedEventArgs e)
        {
            if (td == null)
                return;
            List<Plan> lp = td.ListPlan;
            foreach (Plan p in lp)
            {
                if (p.ucId == Convert.ToByte(lbxPlanId.SelectedItem))
                {

                    p.usMonthFlag = (ushort) (p.usMonthFlag & 8158);
                    break;
                }
            }
        }

        private void cbxJune_Unchecked(object sender, System.Windows.RoutedEventArgs e)
        {
            if (td == null)
                return;
            List<Plan> lp = td.ListPlan;
            foreach (Plan p in lp)
            {
                if (p.ucId == Convert.ToByte(lbxPlanId.SelectedItem))
                {

                    p.usMonthFlag = (ushort) (p.usMonthFlag & 8126);
                    break;
                }
            }
        }

        private void cbxJuly_Unchecked(object sender, System.Windows.RoutedEventArgs e)
        {
            if (td == null)
                return;
            List<Plan> lp = td.ListPlan;
            foreach (Plan p in lp)
            {
                if (p.ucId == Convert.ToByte(lbxPlanId.SelectedItem))
                {

                    p.usMonthFlag = (ushort) (p.usMonthFlag & 8062);
                    break;
                }
            }
        }

        private void cbxAugust_Unchecked(object sender, System.Windows.RoutedEventArgs e)
        {
            if (td == null)
                return;
            List<Plan> lp = td.ListPlan;
            foreach (Plan p in lp)
            {
                if (p.ucId == Convert.ToByte(lbxPlanId.SelectedItem))
                {

                    p.usMonthFlag = (ushort) (p.usMonthFlag & 7934);
                    break;
                }
            }
        }

        private void cbxSeptember_Unchecked(object sender, System.Windows.RoutedEventArgs e)
        {
            if (td == null)
                return;
            List<Plan> lp = td.ListPlan;
            foreach (Plan p in lp)
            {
                if (p.ucId == Convert.ToByte(lbxPlanId.SelectedItem))
                {

                    p.usMonthFlag = (ushort) (p.usMonthFlag & 7678);
                    break;
                }
            }
        }

        private void cbxOctober_Unchecked(object sender, System.Windows.RoutedEventArgs e)
        {
            if (td == null)
                return;
            List<Plan> lp = td.ListPlan;
            foreach (Plan p in lp)
            {
                if (p.ucId == Convert.ToByte(lbxPlanId.SelectedItem))
                {

                    p.usMonthFlag = (ushort) (p.usMonthFlag & 7166);
                    break;
                }
            }
        }

        private void cbxNovember_Unchecked(object sender, System.Windows.RoutedEventArgs e)
        {
            if (td == null)
                return;
            List<Plan> lp = td.ListPlan;
            foreach (Plan p in lp)
            {
                if (p.ucId == Convert.ToByte(lbxPlanId.SelectedItem))
                {

                    p.usMonthFlag = (ushort) (p.usMonthFlag & 6142);
                    break;
                }
            }
        }

        private void cbxDecember_Unchecked(object sender, System.Windows.RoutedEventArgs e)
        {
            if (td == null)
                return;
            List<Plan> lp = td.ListPlan;
            foreach (Plan p in lp)
            {
                if (p.ucId == Convert.ToByte(lbxPlanId.SelectedItem))
                {

                    p.usMonthFlag = (ushort) (p.usMonthFlag & 4094);
                    break;
                }
            }
        }

        private void cbxAllMonth_Checked(object sender, System.Windows.RoutedEventArgs e)
        {
            cbxJanuary.IsChecked = true;
            cbxFebruary.IsChecked = true;
            cbxMarch.IsChecked = true;
            cbxApril.IsChecked = true;
            cbxMay.IsChecked = true;
            cbxJune.IsChecked = true;
            cbxJuly.IsChecked = true;
            cbxAugust.IsChecked = true;
            cbxSeptember.IsChecked = true;
            cbxOctober.IsChecked = true;
            cbxNovember.IsChecked = true;
            cbxDecember.IsChecked = true;
        }

        private void cbxAllMonth_Unchecked(object sender, System.Windows.RoutedEventArgs e)
        {
            cbxJanuary.IsChecked = false;
            cbxFebruary.IsChecked = false;
            cbxMarch.IsChecked = false;
            cbxApril.IsChecked = false;
            cbxMay.IsChecked = false;
            cbxJune.IsChecked = false;
            cbxJuly.IsChecked = false;
            cbxAugust.IsChecked = false;
            cbxSeptember.IsChecked = false;
            cbxOctober.IsChecked = false;
            cbxNovember.IsChecked = false;
            cbxDecember.IsChecked = false;
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
                        if (td.ListPlan[planindex].ucId >= 30)
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
                MessageBox.Show("删除月时基异常!", "时基", MessageBoxButton.OK, MessageBoxImage.Exclamation);

            }
        }
    }
}