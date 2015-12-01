using System;
using System.Collections.Generic;
using System.Net;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Threading;
using Apex.MVVM;
using Apex.Behaviours;
using tscui.Models;
using System.Windows;
using tscui.Service;
using System.Threading;
using Application = System.Windows.Application;
using MessageBox = System.Windows.MessageBox;
using UserControl = System.Windows.Controls.UserControl;

namespace tscui.Pages.Config
{
    /// <summary>
    /// Interaction logic for VariableSignView.xaml
    /// </summary>
    [View(typeof (ConfigViewModel))]
    public partial class ConfigView : UserControl, IView
    {
        private TscData tdData;
        private DispatcherTimer showDispatcherTimer;
        private Thread TimingThread;


        public ConfigView()
        {
            InitializeComponent();
            tdData = Utils.Utils.GetTscDataByApplicationCurrentProperties();
            showDispatcherTimer = new DispatcherTimer();
            showDispatcherTimer.Tick += new EventHandler(DispatcherTimer_Tick);
            showDispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            showDispatcherTimer.Start();
        }

        private void DispatcherTimer_Tick(object sender, EventArgs e)
        {
            dtpTiming.Value = DateTime.Now;
        }

        public void OnActivated()
        {
            SlideFadeInBehaviour.DoSlideFadeIn(this);
        }

        public void OnDeactivated()
        {
            //throw new NotImplementedException();
        }

        /// <summary>
        /// 显示检测器的灵敏度
        /// </summary>

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (tdData == null)
            {
                MessageBox.Show((string) App.Current.Resources.MergedDictionaries[3]["msg_log_selected_tsc"]);
                this.Visibility = Visibility.Hidden;
                return;
            }
            else
            {
                this.Visibility = Visibility.Visible;

            }
            //显示检测器的灵敏度
            ip.Text = tdData.Node.sIpAddress;
            //RunThreadTiming();
        }




        private void dtpTiming_Loaded(object sender, RoutedEventArgs e)
        {
            dtpTiming.Value = DateTime.Now;
        }

        private void btnTiming_Click(object sender, RoutedEventArgs e)
        {
            DateTime dt = (DateTime) dtpTiming.Value;
            bool bok = TscDataUtils.Timing(dt, tdData.Node);
            if (!bok)
                MessageBox.Show("校时失败，检查IP地址！", "校时", MessageBoxButton.OK, MessageBoxImage.Error);

            else
                MessageBox.Show("校时命令发送成功！", "校时", MessageBoxButton.OK, MessageBoxImage.Information);
        }


        private void bRstartTsc_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                byte[] mybyte = new byte[5];
                mybyte[0] = 0x81;
                mybyte[1] = 0xf6;
                mybyte[2] = 0x1;
                mybyte[3] = 0x0;
                mybyte[4] = 0x1;
                bool bRstart = Udp.sendUdpNoReciveData(tdData.Node.sIpAddress, tdData.Node.iPort, mybyte);
                if (!bRstart)
                {
                    MessageBox.Show("重启命令发送失败！", "重启信号机", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    Application.Current.Properties[Define.TSC_DATA] = null;
                    Application.Current.Resources["tscinfo"] = "当前信号机IP地址:000.000.000.000      端口号:0000       版本:0000";
                    MessageBox.Show("重启命令发送成功！", "重启信号机", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("系统重启命令发送异常！", "重启信号机", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        private void bNetWorkConfig_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                if ((!Utils.Utils.bIp(ip.Text) && ip.Text != String.Empty) ||
                    (!Utils.Utils.bIp(netmask.Text) && netmask.Text != String.Empty) ||
                    (!Utils.Utils.bIp(gateway.Text) && gateway.Text != String.Empty))
                {
                    MessageBox.Show("请检查网络参数格式设置是否正确！", "网络配置", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                byte[] netparams = new byte[7] {0x81, 0xf6, 0x0, 0x0, 0x0, 0x0, 0x0};

                if (ip.Text.Trim() != String.Empty)
                {
                    IPAddress newip = IPAddress.Parse(ip.Text);
                    byte[] tmpip = newip.GetAddressBytes();
                    netparams[2] = 0x6;
                    netparams[3] = tmpip[0];
                    netparams[4] = tmpip[1];
                    netparams[5] = tmpip[2];
                    netparams[6] = tmpip[3];
                    Udp.sendUdpNoReciveData(tdData.Node.sIpAddress, Define.GBT_PORT, netparams);
                    //  Thread.Sleep(300);

                }
                if (netmask.Text.Trim() != String.Empty)
                {
                    IPAddress newip = IPAddress.Parse(netmask.Text);
                    byte[] tmpip = newip.GetAddressBytes();
                    netparams[2] = 0x7;
                    netparams[3] = tmpip[0];
                    netparams[4] = tmpip[1];
                    netparams[5] = tmpip[2];
                    netparams[6] = tmpip[3];
                    Udp.sendUdpNoReciveData(tdData.Node.sIpAddress, Define.GBT_PORT, netparams);
                    //  Thread.Sleep(300);

                }
                if (gateway.Text.Trim() != String.Empty)
                {
                    IPAddress newip = IPAddress.Parse(gateway.Text);
                    byte[] tmpip = newip.GetAddressBytes();
                    netparams[2] = 08;
                    netparams[3] = tmpip[0];
                    netparams[4] = tmpip[1];
                    netparams[5] = tmpip[2];
                    netparams[6] = tmpip[3];
                    Udp.sendUdpNoReciveData(tdData.Node.sIpAddress, Define.GBT_PORT, netparams);
                    // Thread.Sleep(300);

                }
                MessageBox.Show("网络参数已提交,重启信号机生效！", "网络配置", MessageBoxButton.OK, MessageBoxImage.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show("网络参数提交异常！", "网络配置", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        private void bInitTsc_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MessageBoxResult msgBoxResult = MessageBox.Show("确定要重置信号机数据吗?", "数据重置", MessageBoxButton.YesNo,
                    MessageBoxImage.Question);
                if (msgBoxResult == MessageBoxResult.No)
                    return;
                bool bok = Udp.sendUdpNoReciveData(tdData.Node.sIpAddress, tdData.Node.iPort,
                    Define.UPDATE_DATABASE_START);
                if (bok)
                {
                    MessageBox.Show("信号机数据重置命令发送成功,请重启信号机!", "数据重置", MessageBoxButton.OK, MessageBoxImage.Information);
                    this.bRstartTsc_Click(this, null);
                }
                else
                {
                    MessageBox.Show("信号机数据重置命令发送失败!", "数据重置", MessageBoxButton.OK, MessageBoxImage.Error);

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("信号机数据重置命令发送异常!", "数据重置", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        private void UserControl_UnLoaded(object sender, RoutedEventArgs e)
        {
            showDispatcherTimer.Stop();
            showDispatcherTimer = null;
        }

        private void manualtime_checked(object sender, RoutedEventArgs e)
        {
            showDispatcherTimer.Stop();
        }

        private void manualtime_unchecked(object sender, RoutedEventArgs e)
        {
            showDispatcherTimer.Start();
        }

        private void btnGetTime_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (tdData == null)
                    return;
                Int32 localtimesec = TscDataUtils.GetTime(0, tdData.Node);
                if (localtimesec != 0)
                {
                    if (Manualchk.IsChecked == false)
                        Manualchk.IsChecked = true;
                    DateTime dt = new DateTime(1970, 1, 1, 0, 0, 0);
                    dtpTiming.Value = dt.AddSeconds(localtimesec - 8*3600);
                    MessageBox.Show("信号机时间获取成功!", "信号机时间", MessageBoxButton.OK, MessageBoxImage.Information);


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("信号机时间获取异常!", "信号机时间", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }

        }

        
    }
}
