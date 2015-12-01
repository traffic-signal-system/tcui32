using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Windows.Media;
using Apex.MVVM;
using Apex.Behaviours;
using tscui.Models;
using System.Windows;
using tscui.Service;
using Application = System.Windows.Application;
using EventLog = tscui.Models.EventLog;
using MessageBox = System.Windows.MessageBox;
using UserControl = System.Windows.Controls.UserControl;

namespace tscui.Pages.Log
{
    /// <summary>
    /// Interaction logic for ThePagesView.xaml
    /// </summary>
    [View(typeof (LogsViewModel))]
    public partial class LogsView : UserControl, IView
    {

        public LogsView()
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

        private void refreshLog()
        {

            TscData td = (TscData) Application.Current.Properties[Define.TSC_DATA];
            if (td == null)
            {
                MessageBox.Show((string) App.Current.Resources.MergedDictionaries[3]["msg_log_selected_tsc"]);

            }
            else
            {
                Loglistview.ItemsSource = null;
                Loglistview.ItemsSource = TscDataUtils.GetEventLog();
            }

        }

        private void btnGetLog_Click(object sender, RoutedEventArgs e)
        {
            refreshLog();
        }

        private void splLog_Loaded1(object sender, RoutedEventArgs e)
        {
            TscData td = Utils.Utils.GetTscDataByApplicationCurrentProperties();
            if (td == null)
            {
                this.Visibility = Visibility.Hidden;
            }
            this.Visibility = Visibility.Visible;
            refreshLog();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                TscData td = Utils.Utils.GetTscDataByApplicationCurrentProperties();
                if (td == null || Loglistview.Items.Count == 0)
                    return;
                byte[] ibStart = new byte[] {0xff, 0xff, 0xff, 0xff};
                byte[] ibEnd = new byte[] {0xff, 0xff, 0xff, 0xff};
                byte[] mybyte = new byte[13];

                mybyte[0] = 0x81;
                mybyte[1] = 0xe4;
                mybyte[2] = 0x0;
                mybyte[3] = 0x3;
                mybyte[4] = 0xff;

                mybyte[5] = ibStart[0];
                mybyte[6] = ibStart[1];
                mybyte[7] = ibStart[2];
                mybyte[8] = ibStart[3];
                mybyte[9] = ibEnd[0];
                mybyte[10] = ibEnd[1];
                mybyte[11] = ibEnd[2];
                mybyte[12] = ibEnd[3];
                bool bdelok = Udp.sendUdpNoReciveData(td.Node.sIpAddress, td.Node.iPort, mybyte);
                if (bdelok == true)
                {
                    Loglistview.ItemsSource = null;
                    MessageBox.Show("日志删除操作成功!", "日志", MessageBoxButton.OK, MessageBoxImage.Information);

                }
                else
                {
                    MessageBox.Show("日志删除操作失败!", "日志", MessageBoxButton.OK, MessageBoxImage.Error);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("删除日志异常！::>_<::!", "日志", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string filename = "";
                    filename = openFileDialog1.FileName;
                    string filepath = "Data Source=" + filename;
                    SQLiteDataAdapter s = new SQLiteDataAdapter();
                    using (SQLiteConnection conn = new SQLiteConnection(filepath))
                    {
                        conn.Open();
                        SQLiteCommand cmd = conn.CreateCommand();
                        cmd.CommandText = "select * from Tbl_EventLog;";
                        SQLiteDataReader dr = cmd.ExecuteReader();
                        List<EventLog> listLogs = new List<EventLog>();
                        while (dr.Read())
                        {
                            EventLog obj = new EventLog();
                            obj.ucEvtType = dr.GetByte(1);
                            obj.ucEventId = Convert.ToByte(dr.GetInt32(0));
                            obj.ulHappenTime = Convert.ToUInt32(dr.GetInt32(2));
                            obj.ulEvtValue = Convert.ToUInt32(dr.GetInt32(3));
                            obj.ulEventTime = Utils.Utils.ConvertIntDateTime(obj.ulHappenTime).ToString();
                            obj.sEventType = Utils.Utils.EventType2String(obj.ucEvtType);
                            obj.sEventDesc = Utils.Utils.EventDesc2String(obj.ulEvtValue, obj.ucEvtType);
                            listLogs.Add(obj);
                        }
                        Loglistview.ItemsSource = null;
                        Loglistview.ItemsSource = listLogs;
                        conn.Clone();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("本地日志加载异常！::>_<::!", "日志", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        private void Button_Click_ExportLog(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Loglistview.Items.Count <= 0) //SignInList是WPF中的ListView，即为数据源
                {
                    MessageBox.Show("日志为空，无法导出！::>_<::!", "日志", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                //此处的文本文件在工程下Bin的程序集目录下
                SaveFileDialog dlg = new SaveFileDialog();
                dlg.FileName = "tsclog.txt"; // Default file name
                dlg.DefaultExt = ".txt"; // Default file extension
                dlg.Filter = "日志文件|*.txt"; // Filter files by extension
                dlg.InitialDirectory = "C:\\";
                DialogResult result = dlg.ShowDialog();
                string tscdatapath = dlg.FileName;
                if (result == DialogResult.OK)
                {
                    StreamWriter swStream;
                    if (File.Exists(tscdatapath))
                    {
                        swStream = new StreamWriter(tscdatapath);
                    }
                    else
                    {
                        swStream = File.CreateText(tscdatapath);
                    }
                    swStream.Write(ListViewLogId.Header + "    ");
                    swStream.Write(ListViewLogType.Header + "                ");
                    swStream.Write(ListViewLogTime.Header + "                           ");
                    swStream.Write(ListViewLogContent.Header);
                    swStream.Write("\r\n"); //换行  
                    foreach (EventLog logitem in Loglistview.Items)
                    {
                        swStream.Write(logitem.ucEventId.ToString().PadRight(12));
                        swStream.Write(logitem.sEventType +
                                       string.Empty.PadRight((20 - Encoding.Default.GetByteCount(logitem.sEventType))));
                        swStream.Write(logitem.ulEventTime.PadRight(30));
                        swStream.Write(logitem.sEventDesc);
                        //按行写入一条记录
                        swStream.WriteLine();
                    }
                    //关闭流,释放资源
                    swStream.Flush();
                    swStream.Close();
                    //导入Txt文件后,自动打开文件
                    Process.Start("notepad.exe", tscdatapath);
                }
            }
            catch (Exception ex)
            {
                return;
            }
        }
    }

}
