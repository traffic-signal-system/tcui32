using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Apex.MVVM;
using tscui.ViewModels;
using Apex.Behaviours;
using tscui.Service;
using tscui.Models;

namespace tscui.Views
{
    /// <summary>
    /// Interaction logic for PicturesView.xaml
    /// </summary>
    [View(typeof(DetectorAdvancedViewModel))]
    public partial class DetectorAdvancedView : UserControl, IView
    {
        private TscData tscData = Utils.Utils.GetTscDataByApplicationCurrentProperties();
        private TscData td;

        private bool DecBoard1Online;
        private bool DecBoard2Online;
        public DetectorAdvancedView()
        {
            td = Utils.Utils.GetTscDataByApplicationCurrentProperties();
            InitializeComponent();
        }

        public void OnActivated()
        {
            //  Fade in all of the elements.
            SlideFadeInBehaviour.DoSlideFadeIn(this);
        }

        public void OnDeactivated()
        {
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                #region 检测器板1&2灵敏度等级和数值设
             
                string result = ""; //设置结果
                if (ChkBoxSlot1Grade.IsChecked == true)
                {
                    byte[] BytesSlot1Garde = new byte[8];
                    BytesSlot1Garde[0] =
                        (byte)
                            ((Convert.ToByte(sldDetector1.Value - 1)) | ((Convert.ToByte(sldDetector2.Value - 1)) << 4));
                    BytesSlot1Garde[1] =
                        (byte)
                            ((Convert.ToByte(sldDetector3.Value - 1)) | ((Convert.ToByte(sldDetector4.Value - 1)) << 4));
                    BytesSlot1Garde[2] =
                        (byte)
                            ((Convert.ToByte(sldDetector5.Value - 1)) | ((Convert.ToByte(sldDetector6.Value - 1)) << 4));
                    BytesSlot1Garde[3] =
                        (byte)
                            ((Convert.ToByte(sldDetector7.Value - 1)) | ((Convert.ToByte(sldDetector8.Value - 1)) << 4));
                    BytesSlot1Garde[4] =
                        (byte)
                            ((Convert.ToByte(sldDetector9.Value - 1)) | ((Convert.ToByte(sldDetector10.Value - 1)) << 4));
                    BytesSlot1Garde[5] =
                        (byte)
                            ((Convert.ToByte(sldDetector11.Value - 1)) |
                             ((Convert.ToByte(sldDetector12.Value - 1)) << 4));
                    BytesSlot1Garde[6] =
                        (byte)
                            ((Convert.ToByte(sldDetector13.Value - 1)) |
                             ((Convert.ToByte(sldDetector14.Value - 1)) << 4));
                    BytesSlot1Garde[7] =
                        (byte)
                            ((Convert.ToByte(sldDetector15.Value - 1)) |
                             ((Convert.ToByte(sldDetector16.Value - 1)) << 4));
                    bool bSendOk = TscDataUtils.SetDecBoardSensitivityAdv(BytesSlot1Garde, td.Node, 0x0);
                    if (DecWorkTypeCbx1.SelectedIndex != 0x0)
                    {
                        Byte DecWorkType = (Byte)(DecWorkTypeCbx1.SelectedIndex - 1);
                        bool bSendOk2 = TscDataUtils.SetDetecBdWorkType(td.Node, 0x0, DecWorkType);
                      if(bSendOk2 ==true)
                          result += "检测器板1工作方式设置成功!\r\n";
                      else
                          result += "检测器板1工作方式设置失败!\r\n";
                    }

                    if (bSendOk == true)
                        result += "检测器板1通道灵敏度等级设置成功!\r\n";
                    else
                        result += "检测器板1通道灵敏度等级设置失败!\r\n";
                }
                if (ChkBoxSlot1GradeData.IsChecked == true)
                {
                    byte[] BytesSlot1GrateData1to7 = new[]
                    {
                        Convert.ToByte(Slot1GradeLv1.Value), Convert.ToByte(Slot1GradeLv2.Value),
                        Convert.ToByte(Slot1GradeLv3.Value), Convert.ToByte(Slot1GradeLv4.Value),
                        Convert.ToByte(Slot1GradeLv5.Value), Convert.ToByte(Slot1GradeLv6.Value),
                        Convert.ToByte(Slot1GradeLv7.Value)
                    };
                    Message m1to7 = TscDataUtils.SetSensityvityDig1(BytesSlot1GrateData1to7, td.Node);

                    byte[] BytesSlot1GrateData8to14 = new[]
                    {
                        Convert.ToByte(Slot1GradeLv8.Value), Convert.ToByte(Slot1GradeLv9.Value),
                        Convert.ToByte(Slot1GradeLv10.Value), Convert.ToByte(Slot1GradeLv11.Value),
                        Convert.ToByte(Slot1GradeLv12.Value), Convert.ToByte(Slot1GradeLv13.Value),
                        Convert.ToByte(Slot1GradeLv14.Value)
                    };
                    Message m8to14 = TscDataUtils.SetSensityvityDig2(BytesSlot1GrateData8to14, td.Node);


                    byte[] BytesSlot1GrateData15to16 = new[]
                    {Convert.ToByte(Slot1GradeLv15.Value), Convert.ToByte(Slot1GradeLv16.Value)};
                    Message m15to16 = TscDataUtils.SetSensityvityDig3(BytesSlot1GrateData15to16, td.Node);
                    if (m1to7.flag && m8to14.flag && m15to16.flag)
                    {
                        result += "检测器板1灵敏度等级数值设置成功!\r\n";
                    }
                    else
                    {
                        result += "检测器板1灵敏度等级数值设置失败!\r\n";
                    }

                }
                if (ChkBoxSlot2Grade.IsChecked == true)
                {
                    byte[] BytesSlot2Garde = new byte[8];
                    BytesSlot2Garde[0] =
                        (byte)
                            ((Convert.ToByte(sldDetector21.Value - 1)) |
                             ((Convert.ToByte(sldDetector22.Value - 1)) << 4));
                    BytesSlot2Garde[1] =
                        (byte)
                            ((Convert.ToByte(sldDetector23.Value - 1)) |
                             ((Convert.ToByte(sldDetector24.Value - 1)) << 4));
                    BytesSlot2Garde[2] =
                        (byte)
                            ((Convert.ToByte(sldDetector25.Value - 1)) |
                             ((Convert.ToByte(sldDetector26.Value - 1)) << 4));
                    BytesSlot2Garde[3] =
                        (byte)
                            ((Convert.ToByte(sldDetector27.Value - 1)) |
                             ((Convert.ToByte(sldDetector28.Value - 1)) << 4));
                    BytesSlot2Garde[4] =
                        (byte)
                            ((Convert.ToByte(sldDetector29.Value - 1)) |
                             ((Convert.ToByte(sldDetector210.Value - 1)) << 4));
                    BytesSlot2Garde[5] =
                        (byte)
                            ((Convert.ToByte(sldDetector211.Value - 1)) |
                             ((Convert.ToByte(sldDetector212.Value - 1)) << 4));
                    BytesSlot2Garde[6] =
                        (byte)
                            ((Convert.ToByte(sldDetector213.Value - 1)) |
                             ((Convert.ToByte(sldDetector214.Value - 1)) << 4));
                    BytesSlot2Garde[7] =
                        (byte)
                            ((Convert.ToByte(sldDetector215.Value - 1)) |
                             ((Convert.ToByte(sldDetector216.Value - 1)) << 4));
                    if (DecWorkTypeCbx2.SelectedIndex != 0x0)
                    {
                        Byte DecWorkType = (Byte)(DecWorkTypeCbx2.SelectedIndex - 1);
                        bool bSendOk2 = TscDataUtils.SetDetecBdWorkType(td.Node, 0x0, DecWorkType);
                        if (bSendOk2 == true)
                            result += "检测器板2工作方式设置成功!\r\n";
                        else
                            result += "检测器板2工作方式设置失败!\r\n";
                    }
                    bool bSendOk = TscDataUtils.SetDecBoardSensitivityAdv(BytesSlot2Garde, td.Node, 0x1);
                    if (bSendOk == true)
                        result += "检测器板2通道灵敏度等级设置成功!\r\n";
                    else
                        result += "检测器板2通道灵敏度等级设置失败!\r\n";
                }
                if (ChkBoxSlot2GradeData.IsChecked == true)
                {
                    byte[] BytesSlot2GrateData1to7 = new[]
                    {
                        Convert.ToByte(Slot2GradeLv1.Value), Convert.ToByte(Slot2GradeLv2.Value),
                        Convert.ToByte(Slot2GradeLv3.Value), Convert.ToByte(Slot2GradeLv4.Value),
                        Convert.ToByte(Slot2GradeLv5.Value), Convert.ToByte(Slot2GradeLv6.Value),
                        Convert.ToByte(Slot2GradeLv7.Value)
                    };
                    Message m1to7 = TscDataUtils.SetSensityvityDig4(BytesSlot2GrateData1to7, td.Node);

                    byte[] BytesSlot2GrateData8to14 = new[]
                    {
                        Convert.ToByte(Slot2GradeLv8.Value), Convert.ToByte(Slot2GradeLv9.Value),
                        Convert.ToByte(Slot2GradeLv10.Value), Convert.ToByte(Slot2GradeLv11.Value),
                        Convert.ToByte(Slot2GradeLv12.Value), Convert.ToByte(Slot2GradeLv13.Value),
                        Convert.ToByte(Slot2GradeLv14.Value)
                    };
                    Message m8to14 = TscDataUtils.SetSensityvityDig5(BytesSlot2GrateData8to14, td.Node);


                    byte[] BytesSlot2GrateData15to16 = new[]
                    {Convert.ToByte(Slot2GradeLv15.Value), Convert.ToByte(Slot2GradeLv16.Value)};
                    Message m15to16 = TscDataUtils.SetSensityvityDig6(BytesSlot2GrateData15to16, td.Node);
                    if (m1to7.flag && m8to14.flag && m15to16.flag)
                    {
                        result += "检测器板1灵敏度数值设置成功!\r\n";
                    }
                    else
                    {
                        result += "检测器板1灵敏度数值设置失败!\r\n";
                    }

                }
                if (result.Equals(""))
                    MessageBox.Show("未选勾选需要配置的检测器板项目!","检测器高级参数",MessageBoxButton.OK,MessageBoxImage.Error);
                    
                else
                   MessageBox.Show(result, "检测器高级参数", MessageBoxButton.OK, MessageBoxImage.Information);


                #endregion
            }
            catch (Exception ex)
            {
                MessageBox.Show("设置检测器灵敏度参数异常", "检测器高级参数", MessageBoxButton.OK, MessageBoxImage.Exclamation);

            }

        }

        private void btnRead_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (ChkBoxSlot1Grade.IsChecked == false && ChkBoxSlot1GradeData.IsChecked == false
                    && ChkBoxSlot2Grade.IsChecked == false && ChkBoxSlot2GradeData.IsChecked == false)
                {
                    MessageBox.Show("请勾选检测器板查询参数项", "检测器高级参数", MessageBoxButton.OK, MessageBoxImage.Error);

                }
                if (ChkBoxSlot1Grade.IsChecked == true)
                {
                    List<byte> lb = TscDataUtils.GetSensitivityAdv11(td.Node);
                    sldDetector1.Value = lb[5] + 1;
                    sldDetector2.Value = lb[6] + 1;
                    sldDetector3.Value = lb[7] + 1;
                    sldDetector4.Value = lb[8] + 1;
                    sldDetector5.Value = lb[9] + 1;
                    sldDetector6.Value = lb[10] + 1;
                    sldDetector7.Value = lb[11] + 1;
                    sldDetector8.Value = lb[12] + 1;
                    List<byte> lb12 = TscDataUtils.GetSensitivityAdv12(td.Node);
                    sldDetector9.Value = lb12[5] + 1;
                    sldDetector10.Value = lb12[6] + 1;
                    sldDetector11.Value = lb12[7] + 1;
                    sldDetector12.Value = lb12[8] + 1;
                    sldDetector13.Value = lb12[9] + 1;
                    sldDetector14.Value = lb12[10] + 1;
                    sldDetector15.Value = lb12[11] + 1;
                    sldDetector16.Value = lb12[12] + 1;
                    DecWorkTypeCbx1.SelectedIndex = TscDataUtils.GetDetecBdWorkType(td.Node,0);
                }
                if (ChkBoxSlot2Grade.IsChecked == true)
                {
                    List<byte> lb21 = TscDataUtils.GetSensitivityAdv21(td.Node);
                    sldDetector21.Value = lb21[5] + 1;
                    sldDetector22.Value = lb21[6] + 1;
                    sldDetector23.Value = lb21[7] + 1;
                    sldDetector24.Value = lb21[8] + 1;
                    sldDetector25.Value = lb21[9] + 1;
                    sldDetector26.Value = lb21[10] + 1;
                    sldDetector27.Value = lb21[11] + 1;
                    sldDetector28.Value = lb21[12] + 1;

                    List<byte> lb22 = TscDataUtils.GetSensitivityAdv22(td.Node);
                    sldDetector29.Value = lb22[5] + 1;
                    sldDetector210.Value = lb22[6] + 1;
                    sldDetector211.Value = lb22[7] + 1;
                    sldDetector212.Value = lb22[8] + 1;
                    sldDetector213.Value = lb22[9] + 1;
                    sldDetector214.Value = lb22[10] + 1;
                    sldDetector215.Value = lb22[11] + 1;
                    sldDetector216.Value = lb22[12] + 1;
                    DecWorkTypeCbx2.SelectedIndex = TscDataUtils.GetDetecBdWorkType(td.Node, 1);
                }

                if (ChkBoxSlot1GradeData.IsChecked == true)
                {
                    List<byte> lbSlot1SentiAdvData1t07 = TscDataUtils.GetSensitivityAdvData1to7(td.Node);
                    Slot1GradeLv1.Value = lbSlot1SentiAdvData1t07[5];
                    Slot1GradeLv2.Value = lbSlot1SentiAdvData1t07[6];
                    Slot1GradeLv3.Value = lbSlot1SentiAdvData1t07[7];
                    Slot1GradeLv4.Value = lbSlot1SentiAdvData1t07[8];
                    Slot1GradeLv5.Value = lbSlot1SentiAdvData1t07[9];
                    Slot1GradeLv6.Value = lbSlot1SentiAdvData1t07[10];
                    Slot1GradeLv7.Value = lbSlot1SentiAdvData1t07[11];

                    List<byte> lbSlot1SentiAdvData8t014 = TscDataUtils.GetSensitivityAdvData8to14(td.Node);
                    Slot1GradeLv8.Value = lbSlot1SentiAdvData8t014[5];
                    Slot1GradeLv9.Value = lbSlot1SentiAdvData8t014[6];
                    Slot1GradeLv10.Value = lbSlot1SentiAdvData8t014[7];
                    Slot1GradeLv11.Value = lbSlot1SentiAdvData8t014[8];
                    Slot1GradeLv12.Value = lbSlot1SentiAdvData8t014[9];
                    Slot1GradeLv13.Value = lbSlot1SentiAdvData8t014[10];
                    Slot1GradeLv14.Value = lbSlot1SentiAdvData8t014[11];

                    List<byte> lbSlot1SentiAdvData15t016 = TscDataUtils.GetSensitivityAdvData15to16(td.Node);
                    Slot1GradeLv15.Value = lbSlot1SentiAdvData15t016[5];
                    Slot1GradeLv16.Value = lbSlot1SentiAdvData15t016[6];

                }
               if (ChkBoxSlot2GradeData.IsChecked == true)
              {
                  List<byte> lbSlot2SentiAdvData1t07 = TscDataUtils.Get2SensitivityAdvData1to7(td.Node);
                  Slot2GradeLv1.Value = lbSlot2SentiAdvData1t07[5];
                  Slot2GradeLv2.Value = lbSlot2SentiAdvData1t07[6];
                  Slot2GradeLv3.Value = lbSlot2SentiAdvData1t07[7];
                  Slot2GradeLv4.Value = lbSlot2SentiAdvData1t07[8];
                  Slot2GradeLv5.Value = lbSlot2SentiAdvData1t07[9];
                  Slot2GradeLv6.Value = lbSlot2SentiAdvData1t07[10];
                  Slot2GradeLv7.Value = lbSlot2SentiAdvData1t07[11];

                  List<byte> lbSlot2SentiAdvData8t014 = TscDataUtils.Get2SensitivityAdvData8to14(td.Node);
                  Slot2GradeLv8.Value = lbSlot2SentiAdvData8t014[5];
                  Slot2GradeLv9.Value = lbSlot2SentiAdvData8t014[6];
                  Slot2GradeLv10.Value = lbSlot2SentiAdvData8t014[7];
                  Slot2GradeLv11.Value = lbSlot2SentiAdvData8t014[8];
                  Slot2GradeLv12.Value = lbSlot2SentiAdvData8t014[9];
                  Slot2GradeLv13.Value = lbSlot2SentiAdvData8t014[10];
                  Slot2GradeLv14.Value = lbSlot2SentiAdvData8t014[11];

                  List<byte> lbSlot2SentiAdvData15t016 = TscDataUtils.Get2SensitivityAdvData15to16(td.Node);
                  Slot2GradeLv15.Value = lbSlot2SentiAdvData15t016[5];
                  Slot2GradeLv16.Value = lbSlot2SentiAdvData15t016[6];
              }
            }
            catch (Exception ex)
            {
                MessageBox.Show("读取检测器灵敏度参数异常", "检测器高级参数", MessageBoxButton.OK, MessageBoxImage.Exclamation);

            }

        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
           
            if (tscData == null)
            {
                this.Visibility = Visibility.Hidden;
                return;
            }
            else
            {
                this.Visibility = Visibility.Visible;
            }
            byte[] queryver = new byte[5] { 0x80, 0xf9, 0x0, 0xff, 0x0 };
            queryver[2] = 0x5;
            queryver[4] = 0x0;
            byte[] result6 = Udp.recvUdp(td.Node.sIpAddress, Define.GBT_PORT, queryver);
            if (result6.Length == 0xa)
                DecBoard1Online = ((result6[5] != 0) ? true : false);

            queryver[4] = 0x1;
            byte[] result7 = Udp.recvUdp(td.Node.sIpAddress, Define.GBT_PORT, queryver);
            if (result7.Length == 0xa)
                DecBoard2Online = ((result7[5] != 0) ? true : false);
            Slot1Grp.IsEnabled = DecBoard1Online;
            Slot2Grp.IsEnabled = DecBoard2Online;

        }
    }
}
