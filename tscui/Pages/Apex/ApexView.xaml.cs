using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;

using Apex.MVVM;
using Apex.Behaviours;
using tscui.Models;
using System.Net;
using System.Threading;
using System.Net.Sockets;
using tscui.Service;

namespace tscui.Pages.Apex
{
    /// <summary>
    /// Interaction logic for ApexView.xaml
    /// </summary>
    [View(typeof(ApexViewModel))]
    public partial class ApexView : UserControl, IView
    {
        
        UdpClient recevieUdpClient = null;
      //  List<TscInfo> listTscInfo = null;
        private delegate void ShowMsgCallBack(TscInfo tscInfo);
     
        private ShowMsgCallBack showMsgCallBack ;

       // TscInfo currentTI = null;

        public ApexView()
        {
            InitializeComponent();
            showMsgCallBack = new ShowMsgCallBack(ShowMsg);
        }
        private void ShowMsg(TscInfo tscInfo)
        {
            TscInfoList.Items.Add(tscInfo);
        }


        // 显示消息回调方法
      
        /// <summary>
        /// 系统启动后，
        /// 系统自动会将在线的信号机进行搜索。并将数据填写到列表中
        /// 这个方法是处理：选中后，以后的配置的信号机都是选中的参数
 
        void myListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TscInfo ti = (TscInfo)TscInfoList.SelectedItem;
            if (ti == null)
            {
                return;;
            }
            Application.Current.Properties[Define.TSC_INFO] = ti;
            InitTscData(ti);
            TextIP.Text = ti.Ip;}
        public void InitTscData(TscInfo ti)
        {
            TscData td = new TscData();
            Node node = new Node(ti.Ip, ti.Name, ti.Version, ti.Port);
            td.Node = node;
            Application.Current.Resources["tscinfo"] = "当前信号机IP地址:" + ti.Ip + "       端口号:" + ti.Port + "       版本:" + ti.Version;
            Application.Current.Properties[Define.TSC_DATA] = td;

            // 对选中的信号机进行数据库生成
          //  SQLiteHelper.CreateDB("c:\\"+ti.Ip + ".db");
            try
            {
                td.ListSchedule = TscDataUtils.GetSchedule();
                if (td.ListSchedule == null)
                {
                    MessageBox.Show("信号机时段表加载失败,信号机参数加载中断退出!","信号机",MessageBoxButton.OK,MessageBoxImage.Error);
                    Application.Current.Properties[Define.TSC_DATA] = null;

                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("时段表加载异常,数据库加载中断退出!", "信号机", MessageBoxButton.OK, MessageBoxImage.Exclamation);

                return;
            }
            try
            {
                td.ListPlan = TscDataUtils.GetPlan();
                if (td.ListPlan == null)
                {
                    MessageBox.Show("信号机时基表加载失败,参数加载中断退出!", "信号机", MessageBoxButton.OK, MessageBoxImage.Error);

                    Application.Current.Properties[Define.TSC_DATA] = null;
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("时基表加载异常,参数加载中断退出!", "信号机", MessageBoxButton.OK, MessageBoxImage.Exclamation);

                return;
            }
            try
            {
                td.ListModule = TscDataUtils.GetModule();
                if (td.ListModule == null)
                {
                    MessageBox.Show("信号机模块表加载失败!", "信号机", MessageBoxButton.OK, MessageBoxImage.Warning);                 
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("模块表加载异常!", "信号机", MessageBoxButton.OK, MessageBoxImage.Exclamation);

            }
            try
            {
                td.ListPhase = TscDataUtils.GetPhase();
                if (td.ListPhase == null)
                {
                    MessageBox.Show("信号机相位表加载异常,参数加载中断退出!", "信号机", MessageBoxButton.OK, MessageBoxImage.Error);

                    Application.Current.Properties[Define.TSC_DATA] = null;
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("相位表加载异常,数据库加载中断退出!", "信号机", MessageBoxButton.OK, MessageBoxImage.Exclamation);

                return;
            }
            try
            {
                td.ListCollision = TscDataUtils.GetCollision();
                if (td.ListCollision == null)
                {
                    MessageBox.Show("信号机加载相位冲突表失败!", "信号机", MessageBoxButton.OK, MessageBoxImage.Error);

                    Application.Current.Properties[Define.TSC_DATA] = null;
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("相位冲突表加载异常!", "信号机", MessageBoxButton.OK, MessageBoxImage.Exclamation);

            }
            try
            {
                td.ListDetector = TscDataUtils.GetDetector();
                if (td.ListDetector == null)
                {
                    MessageBox.Show("信号机网络异常,检查网络!", "信号机", MessageBoxButton.OK, MessageBoxImage.Error);

                    Application.Current.Properties[Define.TSC_DATA] = null;
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("检测器表加载异常!", "信号机", MessageBoxButton.OK, MessageBoxImage.Exclamation);

            }
            try
            {
                td.ListChannel = TscDataUtils.GetChannel();
                if (td.ListChannel == null)
                {
                    MessageBox.Show("信号机网络异常,检查网络!", "信号机", MessageBoxButton.OK, MessageBoxImage.Error);

                    Application.Current.Properties[Define.TSC_DATA] = null;
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("通道表加载异常,数据库加载中断退出!", "信号机", MessageBoxButton.OK, MessageBoxImage.Exclamation);

                return;
            }
            try
            {
                td.ListPattern = TscDataUtils.GetPattern();

                if (td.ListPattern == null)
                {
                    MessageBox.Show("方案表加载为空!!!", "信号机", MessageBoxButton.OK, MessageBoxImage.Warning);

               //     Application.Current.Properties[Define.TSC_DATA] = null;
             //       return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("方案表加载异常!!!", "信号机", MessageBoxButton.OK, MessageBoxImage.Warning);

          //      return;
            }
            try
            {
                td.ListStagePattern = TscDataUtils.GetStagePattern();
                if (td.ListStagePattern == null)
                {
                    MessageBox.Show("阶段配时表加载为空!", "信号机", MessageBoxButton.OK, MessageBoxImage.Error);
                   // Application.Current.Properties[Define.TSC_DATA] = null;
                   // return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("阶段表加载异常,数据库加载中断退出!", "信号机", MessageBoxButton.OK, MessageBoxImage.Exclamation);

              //  return;
            }
            try
            {
                td.ListOverlapPhase = TscDataUtils.GetOverlapPhase();
                if (td.ListOverlapPhase == null)
                {
                    MessageBox.Show("跟随相位表加载为空!", "信号机", MessageBoxButton.OK, MessageBoxImage.Error);

                   // Application.Current.Properties[Define.TSC_DATA] = null;
                   // return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("跟随相位表加载异常!", "信号机", MessageBoxButton.OK, MessageBoxImage.Exclamation);

            }
            try
            {
                td.ListPhaseToDirec = TscDataUtils.GetPhaseToDirec();
                if (td.ListPhaseToDirec == null)
                {
                    MessageBox.Show("信号机网络异常,检查网络!", "信号机", MessageBoxButton.OK, MessageBoxImage.Error);

                    Application.Current.Properties[Define.TSC_DATA] = null;
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("方向表加载异常!", "信号机", MessageBoxButton.OK, MessageBoxImage.Exclamation);

                return;
            }
            try
            {
                td.ListLampCheck = TscDataUtils.GetLampCheck();
                if (td.ListLampCheck == null)
                {
                    MessageBox.Show("信号机网络异常,检查网络!", "信号机", MessageBoxButton.OK, MessageBoxImage.Error);

                    Application.Current.Properties[Define.TSC_DATA] = null;
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("灯泡检测表加载异常!", "信号机", MessageBoxButton.OK, MessageBoxImage.Exclamation);

            }
            try
            {
                td.ListCntDownDev = TscDataUtils.GetCntDown();
                if (td.ListCntDownDev == null)
                {
                    MessageBox.Show("信号机网络异常,检查网络!", "信号机", MessageBoxButton.OK, MessageBoxImage.Error);

                    Application.Current.Properties[Define.TSC_DATA] = null;
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("闪断式倒计时表加载异常!", "信号机", MessageBoxButton.OK, MessageBoxImage.Exclamation);

            }

          //  currentTI = null;
        }
        public void RunThreadRecevie()
        {
            try
            {
                // 创建并实例化IP终端结点
                IPEndPoint ipEndPoint =new IPEndPoint(IPAddress.Any, 8899);
                // 实例化UDP客户端（可用于实名发送和接收）
                if (recevieUdpClient == null)
                {
                    recevieUdpClient = new UdpClient(ipEndPoint);
                }
                ThreadPool.QueueUserWorkItem(AddListViewTscData);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("信号机网络接收异常,检查网络!", "信号机", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            
        }
        private object objLock = new object();
        void AddListViewTscData(object state)
        {
            // 创建并实例化IP终端结点
            IPEndPoint ipEndPoint = new IPEndPoint(IPAddress.Any, 0);
          //  listTscInfo = new List<TscInfo>();
            try
                {
            // 消息接收循环
            while (true)
            {
                
                    if (recevieUdpClient == null)
                    {
                        MessageBox.Show("退出广播接收线程!", "信号机", MessageBoxButton.OK, MessageBoxImage.Error);

                        return;
                    }
                    if (recevieUdpClient.Available > 0)
                    {
                        // 同步阻塞接收消息
                        lock (objLock)
                        {

                            byte[] byt = recevieUdpClient.Receive(ref ipEndPoint);
                            string msg = Encoding.Default.GetString(byt);
                            if (byt.Length > 6)
                            {
                                string pot1 = Convert.ToString(byt[6], 16);
                                string pot2 = Convert.ToString(byt[7], 16);
                                string tt = pot1 + pot2;
                                string tscId = Convert.ToString(byt[3]);
                                string tscName = byt[0] + "" + byt[1] + "" + byt[2] + "" + byt[3];
                                string tscIp = byt[0] + "." + byt[1] + "." + byt[2] + "." + byt[3];
                                int tscPort = Convert.ToInt32(tt, 16);
                                string tscVersion = (byt[8] == 0x0 ? "未知版本" : ((byt[8] == 0x1 ? "V16" : "V32") + String.Format("{0:X}", byt[9]) + String.Format("{0:D2}", byt[10])));

                                TscInfo titemp = new TscInfo(tscId, tscName, tscIp, tscVersion, tscPort);
                              //  if (currentTI == null)
                               //     currentTI = titemp;
                               // listTscInfo.Add(titemp);
                                TscInfoList.Dispatcher.Invoke(showMsgCallBack, titemp);

                            }
                        }
                    }
                    
                }
               
            }
            catch (Exception ex)
            {
                // 接收发生异常
                Console.WriteLine(ex.ToString());
               // MessageBox.Show("网络出现异常，请联系软件厂商！");
            }
        }
        public void SendBroadCastByAllTscInfo()
        {
            // 创建IP终端结点
            try
            {
                // 广播模式（由系统自动提供广播地址）
              //  IPAddress broadAddress = IPAddress.Parse("192.168.255.255");
                IPEndPoint ipEndPoint = new IPEndPoint(IPAddress.Broadcast, Define.BROADCAST_PORT);
                // 准备发送的数据
                byte[] sendData = Encoding.Default.GetBytes("123456");
                recevieUdpClient.Send(sendData, sendData.Length, ipEndPoint);}
            catch (Exception ext)
            {
                MessageBox.Show("网络广播出现问题,请检测网络!" + ext.Message, "信号机", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
        }
      
     
        public class TscInfo
        {
            private string _id;
            private string _name;
            private string _ip;
            private string _version;
            private int _port;
            public int Port
            {
                get { return _port; }
                set { _port = value; }
            }

            public string Version
            {
                get { return _version; }
                set { _version = value; }
            }
            public string Id
            {
                get { return _id; }
                set { _id = value; }
            }

            public string Name
            {
                get { return _name; }
                set { _name = value; }
            }
            public string Ip
            {
                get { return _ip; }
                set { _ip = value; }
            }

            public TscInfo(string id, string name, string ip,string version,int port)
            {
                _id = id;
                _name = name;
                _ip = ip;
                _version = version;
                _port = port;
            }
            public TscInfo()
            {
                _id = "";
                _name = "";
                _ip = "";
                _version = "";
                _port = 0;
            }
        }
 
       
        

        public void OnActivated()
        {
            //  Fade in all of the elements.
            SlideFadeInBehaviour.DoSlideFadeIn(this);
        }

        public void OnDeactivated()
        {
        }

        public void RefreshGridView()
        {
            TscInfoList.Items.Clear();
            RunThreadRecevie();
            SendBroadCastByAllTscInfo();
        }
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            if (TscInfoList.Items.Count>0)
             TscInfoList.Items.Clear();
            Application.Current.Properties[Define.TSC_DATA] = null;
            Application.Current.Resources["tscinfo"] ="当前信号机IP地址:000.000.000.000      端口号:0000       版本:0000";
            SendBroadCastByAllTscInfo();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
           // showMsgCallBack = new ShowMsgCallBack(ShowMsg);
            RefreshGridView();
        }

        private void UserControl_Unloaded(object sender, RoutedEventArgs e)
        {
             recevieUdpClient.Close();      
            //if(currentTI != null)
            //{
            //    InitTscData(currentTI);
            //}
        }

        private void Click_TscIP(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (!Utils.Utils.bIp(TextIP.Text) && TextIP.Text != String.Empty) 
                  
            {
                MessageBox.Show("请输入正确IP地址！", "指定IP", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            TscInfo tscInfo = new TscInfo("99", "Tsc32", TextIP.Text, "V329999", 5435);
            TscInfoList.Items.Add(tscInfo);            
        }
    

    }
}
