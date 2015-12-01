using System;
using System.Windows;
using System.Windows.Controls;
using Apex.MVVM;
using tscui.Models;
using tscui.ViewModels;
using Apex.Behaviours;

namespace tscui.Views
{
    /// <summary>
    /// Interaction logic for MusicView.xaml
    /// </summary>
    [View(typeof(ModuleViewModel))]
    public partial class ModuleView : UserControl, IView
    {
        public ModuleView()
        {
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

        private void btnRead_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                TscData td = Utils.Utils.GetTscDataByApplicationCurrentProperties();
                if (td == null)
                    return;
                string modulever = "";
                string error =  "版本: 查询失败!";
                byte[] queryver = new byte[5] { 0x80, 0xf9, 0x0, 0xff, 0x0 };

                 queryver[2] = 0x4;
                 byte[] result1 = Udp.recvUdp(td.Node.sIpAddress, Define.GBT_PORT, queryver);
                 Power1Ver.Content= (result1[5] == 0) ?( error) : ("版本: "+string.Format("{0,2:D2}V{1,2:D2}{2,2:D2}{3,2:D2}.{4,2:D2}" , result1[5], result1[6], result1[7], result1[8], result1[9]));
                 Power1Check.IsChecked = ((result1[5] != 0) ? true : false);
                 queryver[4] = 0x1;
                 byte[] result2 = Udp.recvUdp(td.Node.sIpAddress, Define.GBT_PORT, queryver);
                 Power2Ver.Content = (result2[5] == 0) ? (error) : ("版本: " + string.Format("{0,2:D2}V{1,2:D2}{2,2:D2}{3,2:D2}.{4,2:D2}",  result2[5], result2[6], result2[7], result2[8], result2[9]));
                 Power2Check.IsChecked = ((result2[5] != 0) ? true : false);
                 queryver[2] = 0x8;
                 queryver[4] = 0x0;
                 byte[] result3 = Udp.recvUdp(td.Node.sIpAddress, Define.GBT_PORT, queryver);
                 Macctrolver.Content = (result3[5] == 0) ? (error) : ("版本: " + string.Format("{0,2:D2}V{1,2:D2}{2,2:D2}{3,2:D2}.{4,2:D2}", result3[5], result3[6], result3[7], result3[8], result3[9]));
                 MacctrolOnline.IsChecked =((result3[5] != 0)?true :false);

                 queryver[2] = 0x9;
                 queryver[4] = 0x0;
                 byte[] result90 = Udp.recvUdp(td.Node.sIpAddress, Define.GBT_PORT, queryver);
                 MainBackver.Content = (result90[5] == 0) ? (error) : ("版本: " + string.Format("{0,2:D2}V{1,2:D2}{2,2:D2}{3,2:D2}.{4,2:D2}", result90[5], result90[6], result90[7], result90[8], result90[9]));
                 MainBackOnline.IsChecked = ((result3[5] != 0) ? true : false);

                 queryver[2] = 0xa;
                 queryver[4] = 0x0;
                 byte[] result4 = Udp.recvUdp(td.Node.sIpAddress, Define.GBT_PORT, queryver);
                 MainBoardLed.Content = (result4[5] == 0) ? (error) : ("版本: " + string.Format("{0,2:D2}V{1,2:D2}{2,2:D2}{3,2:D2}.{4,2:D2}", result4[5], result4[6], result4[7], result4[8], result4[9]));
                 MainBoardLedOnline.IsChecked = ((result4[5] != 0) ? true : false);

                 queryver[2] = 0x7;
                 byte[] result5 = Udp.recvUdp(td.Node.sIpAddress, Define.GBT_PORT, queryver);
                 FlashVer.Content = (result5[5] == 0) ? (error) : ("版本: " + string.Format("{0,2:D2}V{1,2:D2}{2,2:D2}{3,2:D2}.{4,2:D2}", result5[5], result5[6], result5[7], result5[8], result5[9]));
                 FlashOnline.IsChecked = ((result5[5] != 0) ? true : false);

                 queryver[2] = 0x5;
                 queryver[4] = 0x0;
                 byte[] result6 = Udp.recvUdp(td.Node.sIpAddress, Define.GBT_PORT, queryver);
                 Detector1Ver.Content = (result6[5] == 0) ? (error) : ("版本: " + string.Format("{0,2:D2}V{1,2:D2}{2,2:D2}{3,2:D2}.{4,2:D2}", result6[5], result6[6], result6[7], result6[8], result6[9]));
                 Detector1Online.IsChecked = ((result6[5] != 0) ? true : false);
                 queryver[2] = 0x5;
                 queryver[4] = 0x1;
                 byte[] result7 = Udp.recvUdp(td.Node.sIpAddress, Define.GBT_PORT, queryver);
                 Detector2Ver.Content = (result7[5] == 0) ? (error) : ("版本: " + string.Format("{0,2:D2}V{1,2:D2}{2,2:D2}{3,2:D2}.{4,2:D2}", result7[5], result7[6], result7[7], result7[8], result7[9]));
                 Detector2Online.IsChecked = ((result7[5] != 0) ? true : false);

                 queryver[2] = 0x6;
                 queryver[4] = 0x2;
                 byte[] result8 = Udp.recvUdp(td.Node.sIpAddress, Define.GBT_PORT, queryver);
                 Inject1Ver.Content = (result8[5] == 0) ? (error) : ("版本: " + string.Format("{0,2:D2}V{1,2:D2}{2,2:D2}{3,2:D2}.{4,2:D2}", result8[5], result8[6], result8[7], result8[8], result8[9]));
                 Inject1Online.IsChecked = ((result8[5] != 0) ? true : false);
                 queryver[2] = 0x6;
                 queryver[4] = 0x3;
                 byte[] result9 = Udp.recvUdp(td.Node.sIpAddress, Define.GBT_PORT, queryver);
                 Inject2Ver.Content = (result9[5] == 0) ? (error) : ("版本: " + string.Format("{0,2:D2}V{1,2:D2}{2,2:D2}{3,2:D2}.{4,2:D2}", result9[5], result9[6], result9[7], result9[8], result9[9]));
                 Inject2Online.IsChecked = ((result9[5] != 0) ? true : false);

                 queryver[2] = 0x3;
                 queryver[4] = 0x0;
                 byte[] result10 = Udp.recvUdp(td.Node.sIpAddress, Define.GBT_PORT, queryver);
                 Lamp1.Content = (result10[5] == 0) ? (error) : ("版本: " + string.Format("{0,2:D2}V{1,2:D2}{2,2:D2}{3,2:D2}.{4,2:D2}", result10[5], result10[6], result10[7], result10[8], result10[9]));
                 Lamp1Online.IsChecked = ((result10[5] != 0) ? true : false);
                 queryver[2] = 0x3;
                 queryver[4] = 0x1;
                 byte[] result11 = Udp.recvUdp(td.Node.sIpAddress, Define.GBT_PORT, queryver);
                 Lamp2.Content = (result11[5] == 0) ? (error) : ("版本: " + string.Format("{0,2:D2}V{1,2:D2}{2,2:D2}{3,2:D2}.{4,2:D2}", result11[5], result11[6], result11[7], result11[8], result11[9]));
                 Lamp2Online.IsChecked = ((result11[5] != 0) ? true : false);

                 queryver[2] = 0x3;
                 queryver[4] = 0x2;
                 byte[] result12 = Udp.recvUdp(td.Node.sIpAddress, Define.GBT_PORT, queryver);
                 Lamp3.Content = (result12[5] == 0) ? (error) : ("版本: " + string.Format("{0,2:D2}V{1,2:D2}{2,2:D2}{3,2:D2}.{4,2:D2}", result12[5], result12[6], result12[7], result12[8], result12[9]));
                 Lamp3Online.IsChecked = ((result12[5] != 0) ? true : false);
                 queryver[2] = 0x3;
                 queryver[4] = 0x3;
                 byte[] result13 = Udp.recvUdp(td.Node.sIpAddress, Define.GBT_PORT, queryver);
                 Lamp4.Content = (result13[5] == 0) ? (error) : ("版本: " + string.Format("{0,2:D2}V{1,2:D2}{2,2:D2}{3,2:D2}.{4,2:D2}", result13[5], result13[6], result13[7], result13[8], result13[9]));
                 Lamp4Online.IsChecked = ((result13[5] != 0) ? true : false);


                 queryver[2] = 0x3;
                 queryver[4] = 0x4;
                 byte[] result14 = Udp.recvUdp(td.Node.sIpAddress, Define.GBT_PORT, queryver);
                 Lamp5.Content = (result14[5] == 0) ? (error) : ("版本: " + string.Format("{0,2:D2}V{1,2:D2}{2,2:D2}{3,2:D2}.{4,2:D2}", result14[5], result14[6], result14[7], result14[8], result14[9]));
                 Lamp5Online.IsChecked = ((result14[5] != 0) ? true : false);
                 queryver[2] = 0x3;
                 queryver[4] = 0x5;
                 byte[] result15 = Udp.recvUdp(td.Node.sIpAddress, Define.GBT_PORT, queryver);
                 Lamp6.Content = (result15[5] == 0) ? (error) : ("版本: " + string.Format("{0,2:D2}V{1,2:D2}{2,2:D2}{3,2:D2}.{4,2:D2}", result15[5], result15[6], result15[7], result15[8], result15[9]));
                 Lamp6Online.IsChecked = ((result15[5] != 0) ? true : false);

                 queryver[2] = 0x3;
                 queryver[4] = 0x6;
                 byte[] result16 = Udp.recvUdp(td.Node.sIpAddress, Define.GBT_PORT, queryver);
                 Lamp7.Content = (result16[5] == 0) ? (error) : ("版本: " + string.Format("{0,2:D2}V{1,2:D2}{2,2:D2}{3,2:D2}.{4,2:D2}", result16[5], result16[6], result16[7], result16[8], result16[9]));
                 Lamp7Online.IsChecked = ((result16[5] != 0) ? true : false);
                 queryver[2] = 0x3;
                 queryver[4] = 0x7;
                 byte[] result17 = Udp.recvUdp(td.Node.sIpAddress, Define.GBT_PORT, queryver);
                 Lamp8.Content = (result17[5] == 0) ? (error) : ("版本: " + string.Format("{0,2:D2}V{1,2:D2}{2,2:D2}{3,2:D2}.{4,2:D2}", result17[5], result17[6], result17[7], result17[8], result17[9]));
                 Lamp8Online.IsChecked = ((result17[5] != 0) ? true : false);

                byte[] bGpsState = Udp.sendUdpClient(td.Node.sIpAddress, td.Node.iPort, Define.GETOPENCLOSE_GPS);
                if (bGpsState.Length == 0x4 && bGpsState[3] == 0x1)
                {
                    ChkGps.IsChecked = true;
                }
                else
                {
                    ChkGps.IsChecked = false;
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show("模块版本查询异常","模块版本",MessageBoxButton.OK,MessageBoxImage.Error);
            }
        }
    }
}
