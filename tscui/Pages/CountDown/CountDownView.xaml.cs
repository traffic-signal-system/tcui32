using System;
using System.Windows;
using Apex.MVVM;
using tscui.Models;
using tscui.Service;
using UserControl = System.Windows.Controls.UserControl;

namespace tscui.Pages.CountDown
{
    /// <summary>
    /// Interaction logic for CountDownView.xaml
    /// </summary>
    [View(typeof (CountDownViewModel))]
    public partial class CountDownView : UserControl, IView
    {
        private TscData td;
        public CountDownView()
        {
            td = Utils.Utils.GetTscDataByApplicationCurrentProperties();
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

        private void UserControl_Loaded(object sender, System.Windows.RoutedEventArgs e)
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
            dgdCountDown.ItemsSource = viewModel.tsCntDownFlashDevsList;
            NewGbCountDown.ItemsSource = viewModel.tsCntDownDirecList;
            GbPhaseCountDown.ItemsSource = td.ListCntDownDev;
<<<<<<< HEAD
            CountDownRead_Click(null, null);
=======
>>>>>>> 74e4ebd174211bd2f7215c892a9bd98ddb385798
        }

 

<<<<<<< HEAD

     
        private void UserControl_UnLoaded(object sender, RoutedEventArgs e)
        {
            viewModel.tsCntDownFlashDevsList.Clear();
=======

     
        private void UserControl_UnLoaded(object sender, RoutedEventArgs e)
        {
            viewModel.tsCntDownFlashDevsList.Clear();
        }


        private void CountDownSet_Click(object sender, RoutedEventArgs e)
        {
            try
            {
             if (CbxCntDown.SelectedIndex == 6)
             {
                 MessageBox.Show("未选择倒计时类型?","倒计时",MessageBoxButton.OK,MessageBoxImage.Question);
                 return;
             }
             #region 485倒计时设置
             if (CbxCntDown.SelectedIndex == 0x0 || CbxCntDown.SelectedIndex == 0x1)
                {
                    string result = "";
                    bool bgb2004 = false;

                 if (CbxCntDown.SelectedIndex == 0x0)
                 {
                        bgb2004 = Udp.sendUdpNoReciveData(td.Node.sIpAddress, td.Node.iPort,Define.SET_COUNT_DOWN_OPEN_NORMAL);
                        result = bgb2004 ? "国标(GAT508-2004)四方向倒计时设置成功!" : "国标(GAT508-2004)四方向倒计时设置失败!"; 
                  }
                 else
                 {
                     bgb2004 = Udp.sendUdpNoReciveData(td.Node.sIpAddress, td.Node.iPort, Define.SET_COUNT_DOWN_OPEN_NORMAL_PHASE);
                  
                     bool bSetCfg = TscDataUtils.SetCntDown();
                     result = (bgb2004 && bSetCfg) ? "国标(GAT508-2004)相位倒计时设置成功!" : "国标(GAT508-2004)相位倒计时设置失败!"; 

                 }
                    if (CbxBaudrate.SelectedIndex >= 0 && CbxBaudrate.SelectedIndex < 5)
                    {
                        byte[] baudrateset = new byte[] {0x81, 0xf6, 0x10, 0x0};
                        switch (CbxBaudrate.SelectedIndex)
                        {
                            case 0:
                                baudrateset[3] = 0x0;
                                break;
                            case 1:
                                baudrateset[3] = 0x1;
                                break;
                            case 2:
                                baudrateset[3] = 0x2;
                                break;
                            case 3:
                                baudrateset[3] = 0x3;
                                break;
                            case 4:
                                baudrateset[3] = 0x4;
                                break;
                            default:
                                baudrateset[3] = 0x0;
                                break;
                        }
                        bool b1 = Udp.sendUdpNoReciveData(td.Node.sIpAddress, td.Node.iPort, baudrateset);
                        if (b1 == true)
                        {
                            result = result + "\n\r波特率设置成功!";
                        }
                        else
                        {
                            result = result + "\n\r波特率设置失败!";
                        }
                    }
                    if (result.Length == 0)
                    {
                        MessageBox.Show("还未选择通讯式倒计时配置选项?", "倒计时", MessageBoxButton.OK, MessageBoxImage.Question);

                    }
                    else
                    {
                        MessageBox.Show(result, "倒计时", MessageBoxButton.OK, MessageBoxImage.Information);

                    }
                }
             #endregion

             #region 闪断式倒计时设置
             else if (CbxCntDown.SelectedIndex == 0x2)
             {
                 bool bSetCfg = true;
                 bool bSetFlashBreak= true ;
                 bool bSetFlashBreakTime = true;
                 bSetFlashBreak = Udp.sendUdpNoReciveData(td.Node.sIpAddress, td.Node.iPort, Define.SET_COUNT_DOWN_FLASHBREAK);
                    if (ChkSetFlashBreakPhase.IsChecked == true)
                    {
                        foreach (CntDownDev tscCntDownDev in td.ListCntDownDev)
                        {
                            foreach (CntDownFlashDev sCntDownFlashDev in viewModel.tsCntDownFlashDevsList)
                            {
                                if (tscCntDownDev.ucDevId == sCntDownFlashDev.ucDevId)
                                {
                                    tscCntDownDev.ucPhase = sCntDownFlashDev.ucPhase;
                                    tscCntDownDev.ucOverlapPhase = sCntDownFlashDev.ucOverlapPhase;
                                    tscCntDownDev.ucMode = (Byte) ((sCntDownFlashDev.ucGreenFlashBreak ? 1 : 0) |
                                                                   ((sCntDownFlashDev.ucRedFlashBreak ? 1 : 0) << 1) |
                                                                   ((sCntDownFlashDev.ucSeconds) << 3) |
                                                                   ((sCntDownFlashDev.ucSendFlashBreak ? 1 : 0) << 2));
                                    break;
                                }
                            }

                        }
                        bSetCfg = TscDataUtils.SetCntDown();
                    }
                 if (CbxFlashBreakTime.SelectedIndex != 0xB)
                 {
                     Define.SET_COUNT_DOWN_FLASHBREAKTIME[3] = (byte)CbxFlashBreakTime.SelectedIndex;
                     bSetFlashBreakTime = Udp.sendUdpNoReciveData(td.Node.sIpAddress, td.Node.iPort, Define.SET_COUNT_DOWN_FLASHBREAKTIME); ;
                 }
                    if (bSetFlashBreak == true && bSetCfg == true)
                    {
                        MessageBox.Show("触发式倒计时配置成功!","倒计时", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else if (bSetFlashBreak == false && bSetCfg == true)
                    {
                        MessageBox.Show("触发式倒计时配置失败!", "倒计时", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    else if(bSetFlashBreak == true && bSetCfg == false)
                    {
                        MessageBox.Show("触发式倒计时配置失败!", "倒计时", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    else
                    {
                        MessageBox.Show("触发式倒计时配置失败!", "倒计时", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
             #endregion
                #region 学习式倒计时设置
             else  if (CbxCntDown.SelectedIndex == 0x3)
                {
                    string result = "";
                    bool b4 = Udp.sendUdpNoReciveData(td.Node.sIpAddress, td.Node.iPort, Define.SET_COUNT_DOWN_CLOSE);
                    if (b4)
                    {
                        result = (string)App.Current.Resources.MergedDictionaries[3]["msg_config_countdown_close_success"];
                    }
                    else
                    {
                        result = (string)App.Current.Resources.MergedDictionaries[3]["msg_config_countdown_close_failed"];
                    }
                    MessageBox.Show(result, "倒计时", MessageBoxButton.OK, b4?MessageBoxImage.Information:MessageBoxImage.Error);

                }
                #endregion

                #region 通讯式倒计时新国标GAT508-2014
             else  if (CbxCntDown.SelectedIndex == 0x4)
                {
                    bool b4 = Udp.sendUdpNoReciveData(td.Node.sIpAddress, td.Node.iPort, Define.SET_COUNT_DOWN_OPEN_NEWGB);
                    MessageBox.Show(b4 ? "新国标(GAT508-2014)倒计时设置成功!" : "新国标(GAT508-2014)倒计时设置失败!", "倒计时", MessageBoxButton.OK, b4 ? MessageBoxImage.Information : MessageBoxImage.Error);

                }
             else   if (CbxCntDown.SelectedIndex == 0x5)
                {
                    bool b4 = Udp.sendUdpNoReciveData(td.Node.sIpAddress, td.Node.iPort, Define.SET_COUNT_DOWN_OPEN_NEWGB4D);
                    MessageBox.Show(b4 ? "新国标(GAT508-2014)四方向倒计时设置成功!" : "新国标(GAT508-2014)四方向倒计时设置失败!", "倒计时", MessageBoxButton.OK, b4 ? MessageBoxImage.Information : MessageBoxImage.Error);

                }
                #endregion

                #region GAT508-2004相位倒计时-最多支持8个
         

              #endregion
            }
            catch (Exception ex)
            {
                MessageBox.Show("倒计时配置异常!", "倒计时", MessageBoxButton.OK, MessageBoxImage.Exclamation);

            }
        }

        private void CbxCntDown_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (td == null)
                return;
            switch (CbxCntDown.SelectedIndex)
            {
                case 0x0:
                     communicatecountown.Visibility = Visibility.Visible;
                     GridFlashBreakCount.Visibility = Visibility.Hidden;
                     NewGbCountDown.Visibility = Visibility.Hidden;
                     GbPhaseCountDown.Visibility = Visibility.Hidden;
                     break;
                case 0x1:
                     communicatecountown.Visibility = Visibility.Visible;
                     GridFlashBreakCount.Visibility = Visibility.Hidden;
                     NewGbCountDown.Visibility = Visibility.Hidden;
                     GbPhaseCountDown.Visibility = Visibility.Visible;
                     break;
                case 0x2:
                     communicatecountown.Visibility = Visibility.Hidden;
                     GridFlashBreakCount.Visibility = Visibility.Visible;
                     NewGbCountDown.Visibility = Visibility.Hidden;
                     GbPhaseCountDown.Visibility = Visibility.Hidden;
                     break;
                case 0x3:
                     communicatecountown.Visibility = Visibility.Hidden;
                     GridFlashBreakCount.Visibility = Visibility.Hidden;
                      NewGbCountDown.Visibility = Visibility.Hidden;
                      GbPhaseCountDown.Visibility = Visibility.Hidden;
                      break;
                case 0x4:
                case 0x5:
                      communicatecountown.Visibility = Visibility.Hidden;
                      GridFlashBreakCount.Visibility = Visibility.Hidden;
                      NewGbCountDown.Visibility = Visibility.Visible;
                      GbPhaseCountDown.Visibility = Visibility.Hidden;
                    break;
                default:
                      communicatecountown.Visibility = Visibility.Hidden;
                      GridFlashBreakCount.Visibility = Visibility.Hidden;
                      NewGbCountDown.Visibility = Visibility.Hidden;
                      GbPhaseCountDown.Visibility = Visibility.Hidden;
                     break;
            }
        }

        private void CountDownRead_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string result = "";
                byte[] cntDownBytes = Udp.sendUdpClient(td.Node.sIpAddress, td.Node.iPort, Define.GET_TSC_COUNT_DOWN);
                if (cntDownBytes.Length != 0x5)
                {
                  //  MessageBox.Show("倒计时类类型读取非法！");
                    result += "倒计时类型读取非法！";
                }
                else
                {
                  //  MessageBox.Show("倒计时类型读取成功！");
                    result += "倒计时类型读取成功！";

                    if (cntDownBytes[3] == 0x0)
                    {
                        CbxCntDown.SelectedIndex = 0x3;
                    }
                    else if (cntDownBytes[3] == 0x1)
                    {
                        CbxCntDown.SelectedIndex = 0x0;
                      
                    }
                    else if (cntDownBytes[3] == 0x2)
                    {
                        CbxCntDown.SelectedIndex = 0x2;
                    }
                    else if (cntDownBytes[3] == 0x3)
                    {
                        CbxCntDown.SelectedIndex = 0x4;
                    }
                    else if (cntDownBytes[3] == 0x4)
                    {
                        CbxCntDown.SelectedIndex = 0x5;
                    }
                    else if (cntDownBytes[3] == 0x5)
                    {
                        CbxCntDown.SelectedIndex = 0x1;
                    }
                    else
                    {
                    //    MessageBox.Show("倒计时配置读取非法！");
                        result += "倒计时类型读取非法！";

                    }
                }
                if(CbxCntDown.SelectedIndex == 0x0)
                {
                    byte[] BaudrateBytes = Udp.sendUdpClient(td.Node.sIpAddress, td.Node.iPort, Define.GET_TSC_BAUDRATE);
                    if (BaudrateBytes.Length != 0x4)
                    {
                        //   MessageBox.Show("倒计时波特率配置读取非法！");
                        result += "\r\n倒计时波特率配置读取非法！";

                    }
                    else
                    {
                        Byte baudratecfg = BaudrateBytes[3];
                        if (baudratecfg >= 0x0 && baudratecfg <= 0x4)
                        {
                            CbxBaudrate.SelectedIndex = baudratecfg;
                            //MessageBox.Show("倒计时波特率配置读取成功！");
                            result += "\r\n倒计时波特率配置读取成功！";

                        }
                        else
                        {
                            // MessageBox.Show("倒计时波特率配置读取非法！");
                            result += "\r\n倒计时波特率配置读取非法！";

                        }
                    }
                }
                else if (CbxCntDown.SelectedIndex == 0x2)
                {
                    byte[] FlashBreakTimeBytes = Udp.sendUdpClient(td.Node.sIpAddress, td.Node.iPort, Define.GET_TSC_FLASHBRAKTIME);
                    if (FlashBreakTimeBytes.Length != 0x4)
                    {
                        //   MessageBox.Show("倒计时波特率配置读取非法！");
                        result += "\r\n闪断是倒计时闪断时间配置读取非法！";

                    }
                    else
                    {
                        CbxFlashBreakTime.SelectedIndex = FlashBreakTimeBytes[3];
                    }
                }
                MessageBox.Show(result, "倒计时", MessageBoxButton.OK, MessageBoxImage.Information);

            }


            catch (Exception ex)
            {
                MessageBox.Show("倒计时配置读取异常", "倒计时", MessageBoxButton.OK, MessageBoxImage.Exclamation);

            }
>>>>>>> 74e4ebd174211bd2f7215c892a9bd98ddb385798
        }


        private void CountDownSet_Click(object sender, RoutedEventArgs e)
        {
            try
            {
             if (CbxCntDown.SelectedIndex == 6)
             {
                 MessageBox.Show("未选择倒计时类型?","倒计时",MessageBoxButton.OK,MessageBoxImage.Question);
                 return;
             }
             #region 485倒计时设置
             if (CbxCntDown.SelectedIndex == 0x0 || CbxCntDown.SelectedIndex == 0x1)
                {
                    string result = "";
                    bool bgb2004 = false;

                 if (CbxCntDown.SelectedIndex == 0x0)
                 {
                        bgb2004 = Udp.sendUdpNoReciveData(td.Node.sIpAddress, td.Node.iPort,Define.SET_COUNT_DOWN_OPEN_NORMAL);
                        result = bgb2004 ? "国标(GAT508-2004)四方向倒计时设置成功!" : "国标(GAT508-2004)四方向倒计时设置失败!"; 
                  }
                 else
                 {
                     bgb2004 = Udp.sendUdpNoReciveData(td.Node.sIpAddress, td.Node.iPort, Define.SET_COUNT_DOWN_OPEN_NORMAL_PHASE);
                  
                     bool bSetCfg = TscDataUtils.SetCntDown();
                     result = (bgb2004 && bSetCfg) ? "国标(GAT508-2004)相位倒计时设置成功!" : "国标(GAT508-2004)相位倒计时设置失败!"; 

                 }
                    if (CbxBaudrate.SelectedIndex >= 0 && CbxBaudrate.SelectedIndex < 5)
                    {
                        byte[] baudrateset = new byte[] {0x81, 0xf6, 0x10, 0x0};
                        switch (CbxBaudrate.SelectedIndex)
                        {
                            case 0:
                                baudrateset[3] = 0x0;
                                break;
                            case 1:
                                baudrateset[3] = 0x1;
                                break;
                            case 2:
                                baudrateset[3] = 0x2;
                                break;
                            case 3:
                                baudrateset[3] = 0x3;
                                break;
                            case 4:
                                baudrateset[3] = 0x4;
                                break;
                            default:
                                baudrateset[3] = 0x0;
                                break;
                        }
                        bool b1 = Udp.sendUdpNoReciveData(td.Node.sIpAddress, td.Node.iPort, baudrateset);
                        if (b1 == true)
                        {
                            result = result + "\n\r波特率设置成功!";
                        }
                        else
                        {
                            result = result + "\n\r波特率设置失败!";
                        }
                    }
                    if (result.Length == 0)
                    {
                        MessageBox.Show("还未选择通讯式倒计时配置选项?", "倒计时", MessageBoxButton.OK, MessageBoxImage.Question);

                    }
                    else
                    {
                        MessageBox.Show(result, "倒计时", MessageBoxButton.OK, MessageBoxImage.Information);

                    }
                }
             #endregion

             #region 闪断式倒计时设置
             else if (CbxCntDown.SelectedIndex == 0x2)
             {
                 bool bSetCfg = true;
                 bool bSetFlashBreak= true ;
                 bool bSetFlashBreakTime = true;
                 bSetFlashBreak = Udp.sendUdpNoReciveData(td.Node.sIpAddress, td.Node.iPort, Define.SET_COUNT_DOWN_FLASHBREAK);
                    if (ChkSetFlashBreakPhase.IsChecked == true)
                    {
                        foreach (CntDownDev tscCntDownDev in td.ListCntDownDev)
                        {
                            foreach (CntDownFlashDev sCntDownFlashDev in viewModel.tsCntDownFlashDevsList)
                            {
                                if (tscCntDownDev.ucDevId == sCntDownFlashDev.ucDevId)
                                {
                                    tscCntDownDev.ucPhase = sCntDownFlashDev.ucPhase;
                                    tscCntDownDev.ucOverlapPhase = sCntDownFlashDev.ucOverlapPhase;
                                    tscCntDownDev.ucMode = (Byte) ((sCntDownFlashDev.ucGreenFlashBreak ? 1 : 0) |
                                                                   ((sCntDownFlashDev.ucRedFlashBreak ? 1 : 0) << 1) |
                                                                   ((sCntDownFlashDev.ucSeconds) << 3) |
                                                                   ((sCntDownFlashDev.ucSendFlashBreak ? 1 : 0) << 2));
                                    break;
                                }
                            }

                        }
                        bSetCfg = TscDataUtils.SetCntDown();
                    }
                 if (CbxFlashBreakTime.SelectedIndex != 0xB)
                 {
                     Define.SET_COUNT_DOWN_FLASHBREAKTIME[3] = (byte)CbxFlashBreakTime.SelectedIndex;
                     bSetFlashBreakTime = Udp.sendUdpNoReciveData(td.Node.sIpAddress, td.Node.iPort, Define.SET_COUNT_DOWN_FLASHBREAKTIME); ;
                 }
                    if (bSetFlashBreak == true && bSetCfg == true)
                    {
                        MessageBox.Show("触发式倒计时配置成功!","倒计时", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else if (bSetFlashBreak == false && bSetCfg == true)
                    {
                        MessageBox.Show("触发式倒计时配置失败!", "倒计时", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    else if(bSetFlashBreak == true && bSetCfg == false)
                    {
                        MessageBox.Show("触发式倒计时配置失败!", "倒计时", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    else
                    {
                        MessageBox.Show("触发式倒计时配置失败!", "倒计时", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
             #endregion
                #region 学习式倒计时设置
             else  if (CbxCntDown.SelectedIndex == 0x3)
                {
                    string result = "";
                    bool b4 = Udp.sendUdpNoReciveData(td.Node.sIpAddress, td.Node.iPort, Define.SET_COUNT_DOWN_CLOSE);
                    if (b4)
                    {
                        result = (string)App.Current.Resources.MergedDictionaries[3]["msg_config_countdown_close_success"];
                    }
                    else
                    {
                        result = (string)App.Current.Resources.MergedDictionaries[3]["msg_config_countdown_close_failed"];
                    }
                    MessageBox.Show(result, "倒计时", MessageBoxButton.OK, b4?MessageBoxImage.Information:MessageBoxImage.Error);

                }
                #endregion

                #region 通讯式倒计时新国标GAT508-2014
             else  if (CbxCntDown.SelectedIndex == 0x4)
                {
                    bool b4 = Udp.sendUdpNoReciveData(td.Node.sIpAddress, td.Node.iPort, Define.SET_COUNT_DOWN_OPEN_NEWGB);
                    MessageBox.Show(b4 ? "新国标(GAT508-2014)倒计时设置成功!" : "新国标(GAT508-2014)倒计时设置失败!", "倒计时", MessageBoxButton.OK, b4 ? MessageBoxImage.Information : MessageBoxImage.Error);

                }
             else   if (CbxCntDown.SelectedIndex == 0x5)
                {
                    bool b4 = Udp.sendUdpNoReciveData(td.Node.sIpAddress, td.Node.iPort, Define.SET_COUNT_DOWN_OPEN_NEWGB4D);
                    MessageBox.Show(b4 ? "新国标(GAT508-2014)四方向倒计时设置成功!" : "新国标(GAT508-2014)四方向倒计时设置失败!", "倒计时", MessageBoxButton.OK, b4 ? MessageBoxImage.Information : MessageBoxImage.Error);

                }
                #endregion

                #region GAT508-2004相位倒计时-最多支持8个
         

              #endregion
            }
            catch (Exception ex)
            {
                MessageBox.Show("倒计时配置异常!", "倒计时", MessageBoxButton.OK, MessageBoxImage.Exclamation);

            }
        }

        private void CbxCntDown_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (td == null)
                return;
            switch (CbxCntDown.SelectedIndex)
            {
                case 0x0:
                     communicatecountown.Visibility = Visibility.Visible;
                     GridFlashBreakCount.Visibility = Visibility.Hidden;
                     NewGbCountDown.Visibility = Visibility.Hidden;
                     GbPhaseCountDown.Visibility = Visibility.Hidden;
                     break;
                case 0x1:
                     communicatecountown.Visibility = Visibility.Visible;
                     GridFlashBreakCount.Visibility = Visibility.Hidden;
                     NewGbCountDown.Visibility = Visibility.Hidden;
                     GbPhaseCountDown.Visibility = Visibility.Visible;
                     break;
                case 0x2:
                     communicatecountown.Visibility = Visibility.Hidden;
                     GridFlashBreakCount.Visibility = Visibility.Visible;
                     NewGbCountDown.Visibility = Visibility.Hidden;
                     GbPhaseCountDown.Visibility = Visibility.Hidden;
                     break;
                case 0x3:
                     communicatecountown.Visibility = Visibility.Hidden;
                     GridFlashBreakCount.Visibility = Visibility.Hidden;
                      NewGbCountDown.Visibility = Visibility.Hidden;
                      GbPhaseCountDown.Visibility = Visibility.Hidden;
                      break;
                case 0x4:
                case 0x5:
                      communicatecountown.Visibility = Visibility.Hidden;
                      GridFlashBreakCount.Visibility = Visibility.Hidden;
                      NewGbCountDown.Visibility = Visibility.Visible;
                      GbPhaseCountDown.Visibility = Visibility.Hidden;
                    break;
                default:
                      communicatecountown.Visibility = Visibility.Hidden;
                      GridFlashBreakCount.Visibility = Visibility.Hidden;
                      NewGbCountDown.Visibility = Visibility.Hidden;
                      GbPhaseCountDown.Visibility = Visibility.Hidden;
                     break;
            }
        }

        private void CountDownRead_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string result = "";
                byte[] cntDownBytes = Udp.sendUdpClient(td.Node.sIpAddress, td.Node.iPort, Define.GET_TSC_COUNT_DOWN);
                if (cntDownBytes.Length != 0x5)
                {
                  //  MessageBox.Show("倒计时类类型读取非法！");
                    result += "倒计时类型读取非法！";
                }
                else
                {
                  //  MessageBox.Show("倒计时类型读取成功！");
                    result += "倒计时类型读取成功！";

                    if (cntDownBytes[3] == 0x0)
                    {
                        CbxCntDown.SelectedIndex = 0x3;
                    }
                    else if (cntDownBytes[3] == 0x1)
                    {
                        CbxCntDown.SelectedIndex = 0x0;
                      
                    }
                    else if (cntDownBytes[3] == 0x2)
                    {
                        CbxCntDown.SelectedIndex = 0x2;
                    }
                    else if (cntDownBytes[3] == 0x3)
                    {
                        CbxCntDown.SelectedIndex = 0x4;
                    }
                    else if (cntDownBytes[3] == 0x4)
                    {
                        CbxCntDown.SelectedIndex = 0x5;
                    }
                    else if (cntDownBytes[3] == 0x5)
                    {
                        CbxCntDown.SelectedIndex = 0x1;
                    }
                    else
                    {
                    //    MessageBox.Show("倒计时配置读取非法！");
                        result += "倒计时类型读取非法！";

                    }
                }
                if(CbxCntDown.SelectedIndex == 0x0)
                {
                    byte[] BaudrateBytes = Udp.sendUdpClient(td.Node.sIpAddress, td.Node.iPort, Define.GET_TSC_BAUDRATE);
                    if (BaudrateBytes.Length != 0x4)
                    {
                        //   MessageBox.Show("倒计时波特率配置读取非法！");
                        result += "\r\n倒计时波特率配置读取非法！";

                    }
                    else
                    {
                        Byte baudratecfg = BaudrateBytes[3];
                        if (baudratecfg >= 0x0 && baudratecfg <= 0x4)
                        {
                            CbxBaudrate.SelectedIndex = baudratecfg;
                            //MessageBox.Show("倒计时波特率配置读取成功！");
                            result += "\r\n倒计时波特率配置读取成功！";

                        }
                        else
                        {
                            // MessageBox.Show("倒计时波特率配置读取非法！");
                            result += "\r\n倒计时波特率配置读取非法！";

                        }
                    }
                }
                else if (CbxCntDown.SelectedIndex == 0x2)
                {
                    byte[] FlashBreakTimeBytes = Udp.sendUdpClient(td.Node.sIpAddress, td.Node.iPort, Define.GET_TSC_FLASHBRAKTIME);
                    if (FlashBreakTimeBytes.Length != 0x4)
                    {
                        //   MessageBox.Show("倒计时波特率配置读取非法！");
                        result += "\r\n闪断是倒计时闪断时间配置读取非法！";

                    }
                    else
                    {
                        CbxFlashBreakTime.SelectedIndex = FlashBreakTimeBytes[3];
                    }
                }
              //  MessageBox.Show(result, "倒计时", MessageBoxButton.OK, MessageBoxImage.Information);

            }


            catch (Exception ex)
            {
              //  MessageBox.Show("倒计时配置读取异常", "倒计时", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }
    }

 
    }

<<<<<<< HEAD
=======
 
    }

>>>>>>> 74e4ebd174211bd2f7215c892a9bd98ddb385798
