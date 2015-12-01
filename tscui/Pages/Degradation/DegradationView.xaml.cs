using System.Windows.Controls;
using System.Windows.Threading;
using Apex.MVVM;
using Apex.Behaviours;
using System;
using System.Windows;
using System.Collections.Generic;
using tscui.Models;
using tscui.Service;

namespace tscui.Pages.Degradation
{
    /// <summary>
    /// Interaction logic for ThePagesView.xaml
    /// </summary>
    [View(typeof(DegradationViewModel))]
    public partial class DegradationView : UserControl, IView
    {
        private DispatcherTimer SendHeartBeattimer;

        public DegradationView()
        {
            InitializeComponent();
            viewModel.DegradationCommand.Executed += new CommandEventHandler(DegradationCommand_Executed);
            SendHeartBeattimer = new DispatcherTimer();
            SendHeartBeattimer.Interval = new TimeSpan(0, 0, 1);   //间隔1秒
            SendHeartBeattimer.Tick += new EventHandler(timer_Tick);
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            try
            {
                if (td == null)
                    return;
                bool bSetPscPara = false;

                bSetPscPara = Udp.sendUdpNoReciveData(td.Node.sIpAddress, Define.GBT_PORT, Define.DEGRADATION_UTC);
                if (bSetPscPara == false)
                {
                    MessageBox.Show("心跳发送失败!", "联网配置", MessageBoxButton.OK, MessageBoxImage.Information);
                    SendHeartBeattimer.Stop();
                }
            
            }
            catch (Exception)
            {
                return;
            }
        }

        void DegradationCommand_Executed(object sender, CommandEventArgs args)
        {
            //throw new NotImplementedException();
        }

        public void OnActivated()
        {
            //  Fade in all of the elements.
            SlideFadeInBehaviour.DoSlideFadeIn(this);
        }

        public void OnDeactivated()
        {
        }

        private void Degradation_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                Apex.ApexView.TscInfo ti = (Apex.ApexView.TscInfo)Application.Current.Properties[Define.TSC_INFO];
                if (ti == null)
                    return;
                int cbi = cbxDegradationModel.SelectedIndex;
                //
                int selectedItem = (int)cbxDegradationModel.SelectedValue;
                // String s = cbi.Content.ToString();
                if (selectedItem == 5)
                {
                    grdDegradation.Visibility = Visibility.Visible;
                    TscData td = (TscData)Application.Current.Properties[Define.TSC_DATA];
                    List<Pattern> ltp = td.ListPattern;
                    Dictionary<int, string> mydic = new Dictionary<int, string>();
                    for (int i = 1; i <= ltp.Count; i++)
                    {
                        mydic.Add(i, i.ToString());
                    }
                    

                    cbxDegradationBaseSchedule.ItemsSource = mydic;
                    cbxDegradationBaseSchedule.SelectedValuePath = "Key";
                    cbxDegradationBaseSchedule.DisplayMemberPath = "Value";
                }
                else
                {
                    grdDegradation.Visibility = Visibility.Hidden;
                    //byte[] byttmp = System.BitConverter.GetBytes(selectedItem);
                    //byte[] bbbb = { byttmp[0] };
                    //byte[] sendData = ByteUtils.concatByteArray(Define.DEGRADATION_UTC, bbbb);
                    //bool bl = Udp.sendUdp(ti.Ip, Define.GBT_PORT, sendData);
                    //if (bl)
                    //{
                    //    MessageBox.Show("联网降级数据保存成功！");
                    //}
                    //else
                    //{
                    //    MessageBox.Show("联网降级数据保存失败！");
                    //}
                }

            }
            catch (Exception ext)
            {
                MessageBox.Show(ext.Message);
            }

        }
        public void InitDegradation()
        {
            string soff = (string)App.Current.Resources.MergedDictionaries[3]["dic_degradation_off"];
            string flashing = (string)App.Current.Resources.MergedDictionaries[3]["dic_degradation_flashing"];
            string allred = (string)App.Current.Resources.MergedDictionaries[3]["dic_degradation_allred"];
            string schedule = (string)App.Current.Resources.MergedDictionaries[3]["dic_degradation_schedule"];
            string reaction = (string)App.Current.Resources.MergedDictionaries[3]["dic_degradation_reaction"];
            string coordination = (string)App.Current.Resources.MergedDictionaries[3]["dic_degradation_main_coordination"];
            string self = (string)App.Current.Resources.MergedDictionaries[3]["dic_degradation_self"];
            string manual = (string)App.Current.Resources.MergedDictionaries[3]["dic_degradation_manual"];
            string online = (string)App.Current.Resources.MergedDictionaries[3]["dic_degradation_online"];
            string line = (string)App.Current.Resources.MergedDictionaries[3]["dic_degradation_line"];
            Dictionary<int, string> mydic = new Dictionary<int, string>() { 
            {1,soff},
            {2,flashing},
            {3,allred},
            {5,schedule},
            {6,reaction},
            {11,coordination},
            {8,self},
            {10,manual},
            {12,online},
            {13,line}
            
            };
            cbxDegradationModel.ItemsSource = mydic;
            cbxDegradationModel.SelectedValuePath = "Key";
            cbxDegradationModel.DisplayMemberPath = "Value";

        }
        public void InitcbxDegradationBaseSchedule()
        {
            Dictionary<int, string> mydic = new Dictionary<int, string>() { 
            {1,"1"},
            {2,"2"},
            {3,"3"},
            {4,"4"},
            {5,"5"},
            {6,"6"},
            {7,"7"},
            {8,"8"},
            {9,"9"},
            {10,"10"},
            {11,"11"},
            {12,"12"},
            {13,"13"},
            {14,"14"},
            {15,"15"},
            {16,"16"}
            };
            cbxDegradationBaseSchedule.ItemsSource = mydic;
            cbxDegradationBaseSchedule.SelectedValuePath = "Key";
            cbxDegradationBaseSchedule.DisplayMemberPath = "Value";

        }
        private void UserControl_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            td = (TscData)Application.Current.Properties[Define.TSC_DATA];
            if(td == null)
            {
                return;

            }
            grdDegradation.Visibility = Visibility.Hidden;
            InitDegradation();
            InitcbxDegradationBaseSchedule();
        }
        TscData td;
        private void cbxDegradationBaseSchedule_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           td = (TscData)Application.Current.Properties[Define.TSC_DATA];
           if (td == null)
               return;
           List<Pattern> ltp = td.ListPattern;
            foreach (Pattern tp in ltp)
            {
                int i =tp.ucPatternId;
                if (i == (int)cbxDegradationBaseSchedule.SelectedValue)
                {
                    lblCycle.Content = tp.ucCycleTime;
                    List<StagePattern> lsp = td.ListStagePattern;
                    int countSP = 0;
                    foreach (StagePattern sp in lsp)
                    {
                        if (tp.ucStagePatternId == sp.ucStagePatternId && sp.usAllowPhase != 0)
                        {
                            countSP++;
                        }
                    }
                    lblStage.Content = countSP;
                }
            }
        }

        private void Chkheartbeat_Checked(object sender, RoutedEventArgs e)
        {
            try
            {
               SendHeartBeattimer.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show("心跳开启异常!", "联网配置", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        private void Chkheartbeat_Unchecked(object sender, RoutedEventArgs e)
        {
            try
            {
                SendHeartBeattimer.Stop();
            }
            catch (Exception ex)
            {
                MessageBox.Show("心跳关闭异常!", "联网配置", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }
    }
}
