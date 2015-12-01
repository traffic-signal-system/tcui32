using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using tscui.Service;
using ThreadState = System.Threading.ThreadState;

namespace tscui.Models
{

    /// <summary>
    /// UDP操作工具类
    /// </summary>
    class Udp
    {
        #region 显示灯态的线程部分
        static Socket _socket;
        static IPEndPoint _local = new IPEndPoint(IPAddress.Parse("192.168.0.2"), 5238);
        static Thread _receiveThread = null;

        #region 开启接收线程
        public static void StartReceive()
        {
            try
            {
                _socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                bool aa = _socket.Connected;
                _receiveThread = new Thread(Receive);
                _receiveThread.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
              //  Console.WriteLine("接收线程失败");
            }
        }
        #endregion

        #region 向服务端发送数据

        public static bool sendUdp(string ipstr, int port, byte[] hex)
        {
            try
            {
                // int len;
                // bool flag = IsSocketConnected(_socket);
                IPEndPoint ip = new IPEndPoint(IPAddress.Parse(ipstr), port);
                _socket.SendTimeout = 1000;
                _socket.ReceiveTimeout = 1000;
                _socket.SendTo(hex, ip);
                return true;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
                return false;

            }
        }
        #endregion

        #region 关闭接收线程和socket连接
        public static void Close()
        {
            if (_receiveThread != null && _receiveThread.ThreadState == ThreadState.Running)
                _receiveThread.Abort();
           // if (_socket != null)
              //  _socket.Close();
        }
        #endregion

        #region 接收线程委托方法
        private static void Receive()
        {
            try
            {
                Thread.Sleep(500);
                if (_socket.Connected)
                {
                    _socket.Bind(_local);                  
                }
                _socket.ReceiveTimeout = 10000;
                while (true)
                {
                    byte[] buffer = new byte[255];
                    EndPoint remoteEP = (EndPoint)(new IPEndPoint(IPAddress.Any, 0));
                    int len = _socket.ReceiveFrom(buffer, ref remoteEP);
                    IPEndPoint ipEndPoint = remoteEP as IPEndPoint;
                    GBT_20999_Utils gb20999 = new GBT_20999_Utils(buffer, len);
                  //  Console.WriteLine("Receive Thread");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString() + _socket.Connected.ToString() + "UpdSocket类 Receive方法出错");
            }
        }
        #endregion

        #endregion



        #region 倒计时输出的部分
        static Socket _countDownSocket;
        static IPEndPoint _countDownLocal = new IPEndPoint(IPAddress.Parse("192.168.0.2"), 5238);
        static Thread _countDownReceiveThread = null;
        #region 开启接收线程
        public static void StartReceiveEchoCountDown()
        {
            try
            {

                _countDownSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                bool aa = _countDownSocket.Connected;
                _countDownReceiveThread = new Thread(ReceiveEchoCountDown);
                _countDownReceiveThread.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
        }
        #endregion

        #region 向服务端发送数据

        public static bool sendUdpEchoCountDown(string ipstr, int port, byte[] hex)
        {
            try
            {
                // int len;
                // bool flag = IsSocketConnected(_socket);
                IPEndPoint ip = new IPEndPoint(IPAddress.Parse(ipstr), port);
                //_countDownSocket.SendTimeout = 1000;
                //_countDownSocket.ReceiveTimeout = 1000;
                _countDownSocket.SendTo(hex, ip);
                return true;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
                return false;

            }
        }
        #endregion

        #region 关闭接收线程和socket连接
        public static void CloseEchoCountDown()
        {
            if (_countDownReceiveThread != null)
                _countDownReceiveThread.Abort();
            if (_countDownSocket != null)
                _countDownSocket.Close();
        }
        #endregion

        #region 接收线程委托方法
        private static void ReceiveEchoCountDown()
        {
            try
            {
                Thread.Sleep(500);
                if (_countDownSocket.Connected)
                {
                    _countDownSocket.Bind(_countDownLocal);
                }
                while (true)
                {
                    byte[] buffer = new byte[255];
                    EndPoint remoteEP = (EndPoint)(new IPEndPoint(IPAddress.Any, 0));
                    int len = _countDownSocket.ReceiveFrom(buffer, ref remoteEP);
                    IPEndPoint ipEndPoint = remoteEP as IPEndPoint;
                    //foreach (byte bt in buffer)
                    //{
                    //    Console.Write("{0:X2} ",bt);
                    //}
                    //Console.Write("\n");
                    EchoCountDownService gb20999 = new EchoCountDownService(buffer, len);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString() + _countDownSocket.Connected.ToString() + "UpdSocket类 Receive方法出错");
            }
        }
        #endregion
        #endregion


        /// <summary>
        /// 直接用SOCKET来进行UDP的发送和接收
        /// 此功能不关注发送到信号机后的返回数据，只对发送是否成功进行判断
        /// </summary>
        /// <param name="ipstr"></param>
        /// <param name="port"></param>
        /// <param name="hex"></param>
        /// <returns></returns>
        public static bool sendUdpNoReciveData(string ipstr, int port, byte[] hex)
        {
            int recv;
            Socket server = null;
            byte[] bytes = new byte[1024]; //这里字节数可以限制，不用65535个字节。接收字节数最多的一般是阶段配时，日志一类。设置为1K
            try
            {
                IPEndPoint ip = new IPEndPoint(IPAddress.Parse(ipstr), port);
                server = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                // string str = "Hello Server!";
                //bytes = System.Text.Encoding.ASCII.GetBytes(str);
                server.SendTimeout = 4000;
                server.ReceiveTimeout = 4000;
                server.SendTo(hex, ip);
                IPEndPoint sender = new IPEndPoint(IPAddress.Any, 0);
                EndPoint Remote = (EndPoint)(sender);
                //server.Bind(sender);
                recv = server.ReceiveFrom(bytes, ref Remote);
             //    Console.WriteLine("Message received from {0}", Remote.ToString());
                //str = System.Text.Encoding.ASCII.GetString(bytes, 0, recv);
             //   Console.WriteLine("Message: " + bytes[0]);
                server.Close();
                server = null;
                if (bytes[0] == 134)
                    return false;
                else 
                    return true;
            }
            catch (Exception exce)
            {
                Console.WriteLine(exce.ToString());
                server.Close();
                server = null;
                return false;
            }

        }
        /// <summary>
        /// UDPClient 封装类实现功能UDP的数据包 发送。
        /// 在使用AP比较复杂的网络时，请使用这个方法
        /// 
        /// </summary>
        /// <param name="strip"> IP地址</param>
        /// <param name="port">端口号，默认为5435</param>
        /// <param name="hex">指令</param>
        /// <returns>返回指令结果</returns>
        public static byte[] sendUdpClient(string strip,int port,byte[] hex)
        {
            
            UdpClient udpClient = new UdpClient();
            try
            {

                //ThreadPool.QueueUserWorkItem(SavePlan);
                udpClient.Connect(IPAddress.Parse(strip), port);
                // Sends a message to the host to which you have connected.
                Byte[] sendBytes = hex;//Encoding.ASCII.GetBytes("123456");
                udpClient.Client.SendTimeout = 3000;
                udpClient.Client.ReceiveTimeout = 3000;
                udpClient.Send(sendBytes, sendBytes.Length);
                //udpClient.EnableBroadcast = true;
                //udpClient.Ttl
                // Sends a message to a different host using optional hostname and port parameters.
               
                //UdpClient udpClientB = new UdpClient();
               // udpClientB.Send(sendBytes, sendBytes.Length, strip, port);     //向备用主机发消息
                //IPEndPoint object will allow us to read datagrams sent from any source.
                IPEndPoint RemoteIpEndPoint = new IPEndPoint(IPAddress.Any, 5435);  //接收端接受所有信息
                // Blocks until a message returns on this socket from a remote host.
                
                    Byte[] receiveBytes = udpClient.Receive(ref RemoteIpEndPoint);
                    string returnData = Encoding.ASCII.GetString(receiveBytes, 0, receiveBytes.Length);

                    udpClient.Close();
                  //  udpClientB.Close();

                    return receiveBytes;
               
            }
            catch (Exception exec)
            {
                Console.WriteLine(exec.ToString());
                return null;
            }
            
        }

        /// <summary>
        /// 直接对Socket进行操作，udp的发送和接收
        /// 此功能主要是在网线直接连接信号机的情况下使用。在复杂网络及有N多个路由的情况下，请使用sendUdpClient
        /// </summary>
        /// <param name="ipstr">IP地址</param>
        /// <param name="port">端口</param>
        /// <param name="hex">指令</param>
        /// <returns>返回的内容</returns>
        public static byte[] recvUdp(string ipstr, int port, byte[] hex)
        {
            int recv;
            Socket server = null;
            byte[] bytes = new byte[65535];
            byte[] result = { };
            try
            {
                IPEndPoint ip = new IPEndPoint(IPAddress.Parse(ipstr), port);
                server = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                // string str = "Hello Server!";
                server.ReceiveTimeout = 4000;
                server.SendTimeout = 4000;
                //bytes = System.Text.Encoding.ASCII.GetBytes(str);
                server.SendTo(hex, ip);
                IPEndPoint sender = new IPEndPoint(IPAddress.Any, 0);
                EndPoint Remote = (EndPoint)(sender);
                //server.Bind(sender);
                recv = server.ReceiveFrom(bytes, ref Remote);
                Debug.WriteLine("Message received from {0}", Remote.ToString());
                //str = System.Text.Encoding.ASCII.GetString(bytes, 0, recv);
           //     Debug.WriteLine("Message: " + bytes[0]);
                result = new byte[recv];
                Array.Copy(bytes, result, recv);
                server.Close();
                server = null;
                return result;
            }
            catch (Exception exce)
            {
                Console.WriteLine(exce.ToString());
                server.Close();
                server = null;
                return result;
            }

        }
        /// <summary>
        /// 得到本机的所以IP，如果只有一个网卡也就得
        /// 到一个IP，有多个就可以得到多少IP
        /// </summary>
        /// <returns></returns>
        public static List<IPAddress> getLocalHostIpAddress()
        {
            List<IPAddress> list = new List<IPAddress>();
            //for(int i=0;i)
            IPAddress[] ipa = Dns.GetHostByName(Dns.GetHostName()).AddressList;
            for (int i = 0; i < ipa.Length; i++)
                list.Add(ipa[i]);
            return list;
        }

        #region 车检器相关的部分

        private static Socket _checkCarSocket = null; 
      //  private static IPEndPoint _checkCarLocal = new IPEndPoint(IPAddress.Any, 0);
      //  static IPEndPoint _checkCarLocal = new IPEndPoint(IPAddress.Any, 5238);
     

        static Thread _checkCarReceiveThread = null;
        #region 开启线程
        public static void StartReceiveCheckCar()
        {
            try
            {
               // Thread.Sleep(500);
                IPEndPoint _checkCarLocal = new IPEndPoint(IPAddress.Any, 5238);
                _checkCarSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                _checkCarSocket.Bind(_checkCarLocal);
                _checkCarReceiveThread = new Thread(ReceiveCheckCar);
                _checkCarReceiveThread.Name = "CheckCarThread";
                _checkCarReceiveThread.IsBackground = true;
                _checkCarReceiveThread.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Detector Thread binding error!");
            }
        }
        #endregion
        #region 接收线程委托方法
        private static void ReceiveCheckCar()
        {
            try
            {
                //Thread.Sleep(200);
                while (true)
                {
                    byte[] buffer = new byte[255];
                    EndPoint remoteEP = (EndPoint)(new IPEndPoint(IPAddress.Any, 0));
                    int len = _checkCarSocket.ReceiveFrom(buffer, ref remoteEP);
                    CheckCarService gb20999 = new CheckCarService(buffer, len);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString()  + "  UpdSocket类 Receive方法出错");
            }
        }
        #endregion
        #region 关闭接收线程和socket连接
        public static void CloseCheckCar()
        {
            if (_checkCarReceiveThread != null)
                _checkCarReceiveThread.Abort();
            if (_checkCarSocket != null)
                _checkCarSocket.Close();
        }
        #endregion
        #region 向服务端发送数据

        public static bool sendUdpCheckCar(string ipstr, int port, byte[] hex)
        {
            try
            {
                // int len;
                // bool flag = IsSocketConnected(_socket);
                IPEndPoint ip = new IPEndPoint(IPAddress.Parse(ipstr), port);
                _checkCarSocket.SendTimeout = 1000;
                _checkCarSocket.ReceiveTimeout = 1000;
                _checkCarSocket.SendTo(hex, ip);
                return true;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
                return false;

            }
        }
        #endregion
        #endregion
    }
}
