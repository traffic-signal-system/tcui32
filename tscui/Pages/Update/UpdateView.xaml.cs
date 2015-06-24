using System;
using System.Windows.Forms;
using Apex.MVVM;
using Apex.Behaviours;
using tscui.Service;
using tscui.Models;
using System.Windows;
using System.Collections.Generic;
using Application = System.Windows.Application;
using MessageBox = System.Windows.MessageBox;
using UserControl = System.Windows.Controls.UserControl;

namespace tscui.Pages.Update
{
    /// <summary>
    /// Interaction logic for TheShellView.xaml
    /// </summary>
    [View(typeof(UpdateViewModel))]
    public partial class UpdateView : UserControl, IView
    {
        private  TscData td;
        public UpdateView()
        {
            InitializeComponent();
        }

        public void OnActivated()
        {
            //  Fade in all of the elements.
            SlideFadeInBehaviour.DoSlideFadeIn(this);

            //  Handle the 'show popup' executed event.
           // ((UpdateViewModel)DataContext).ShowPopupCommand.Executed += ShowPopupCommand_Executed;
        }

        /// <summary>
        /// Handles the Executed event of the ShowPopupCommand.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="args">The <see cref="Apex.MVVM.CommandEventArgs"/> instance containing the event data.</param>
        void ShowPopupCommand_Executed(object sender, CommandEventArgs args)
        {
            //  Get the shell and show the example popup.
           // ApexBroker.GetShell().ShowPopup(new ExamplePopup());
        }

        public void OnDeactivated()
        {
            //  Remove the handler for the 'show popup' executed event.
           // ((UpdateViewModel)DataContext).ShowPopupCommand.Executed -= ShowPopupCommand_Executed;
        }

   private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            td = Utils.Utils.GetTscDataByApplicationCurrentProperties();
            if (td == null)
            {
                this.Visibility = Visibility.Hidden;
            }
            else
            {
                this.Visibility = Visibility.Visible;
            }
        }





        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string ftpaddr = td.Node.sIpAddress;
                FileListBox.Items.Clear();
                List<string> ftpfilelist = new List<string>();
                ftpfilelist = CFtp.GetFileList(ftpaddr, Pwdbox.Password);
                if (ftpfilelist.Count == 0)
                {
                    return;
                }
                ftpfilelist.ForEach(i => { FileListBox.Items.Add(i); });

            }
            catch (Exception ex)
            {

                MessageBox.Show("文件列表显示异常!", "文件列表", MessageBoxButton.OK,
        MessageBoxImage.Exclamation);

            }
        }

        private void DLfile_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SaveFileDialog dlg = new SaveFileDialog();
               dlg.FileName = FileListBox.SelectedItem.ToString();  // Default file name
               
               // dlg.DefaultExt = ".db"; // Default file extension
               // dlg.Filter = "程序(.aiton)|*.aiton|数据文件(.db)|*.db|其他类型文件(*.*)|*.*"; // Filter files by extension
                dlg.Filter = "所有类型文件(*.*)|*.*"; // Filter files by extension

                dlg.InitialDirectory = "C:\\";
                DialogResult result = dlg.ShowDialog();
                if (result == DialogResult.OK)
                {

                    string filepath = dlg.FileName;
                    string filename = FileListBox.SelectedItem.ToString();
                    string ftpaddr = td.Node.sIpAddress;
                    if (CFtp.DownLoadFile(filename, filepath, ftpaddr, Pwdbox.Password))
                    {
                        MessageBox.Show("成功下载文件:" + filepath, "下载", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        MessageBox.Show("下载失败!", "下载", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("下载操作异常!", "下载", MessageBoxButton.OK,
                    MessageBoxImage.Exclamation);
            }
        }

        private void DelFile_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string filename = FileListBox.SelectedItem.ToString();
                string ftpaddr = td.Node.sIpAddress;
                if (MessageBox.Show("确定要删除该文件?","删除",MessageBoxButton.YesNo) == MessageBoxResult.No)
                    return;
                if (CFtp.Delete(filename, ftpaddr, Pwdbox.Password))
                {
                    this.Button_Click(null, null);
                    MessageBox.Show("删除" + filename + "成功！", "删除", MessageBoxButton.OK,
                        MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("删除" + filename + "失败！", "删除", MessageBoxButton.OK,
                        MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("删除操作异常!", "删除", MessageBoxButton.OK,
                       MessageBoxImage.Exclamation);
            }
        }

        private void BackFile_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string filename = FileListBox.SelectedItem.ToString();
                string ftpaddr = td.Node.sIpAddress;
                if (filename.Equals("Gb.aiton"))
                {
                    Udp.sendUdpNoReciveData(td.Node.sIpAddress, td.Node.iPort, Define.UPDATE_TSC_START);
                    this.Button_Click(null, null);

                }
                else if(filename.Equals("GbAitonTsc.db"))
                {
                    Udp.sendUdpNoReciveData(td.Node.sIpAddress, td.Node.iPort, Define.UPDATE_DATABASE_START);
                    this.Button_Click(null, null);

                }
                else
                {
                    MessageBox.Show("非标准程序和数据文件,无法备份！", "备份", MessageBoxButton.OK,
                        MessageBoxImage.Error);
                    return;
                }
                MessageBox.Show("备份操作成！", "备份", MessageBoxButton.OK,
                       MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("备份操作异常!", "备份", MessageBoxButton.OK,
                       MessageBoxImage.Exclamation);
            }
        }

        private void UploadFile_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog uploadOpenFileDialog = new OpenFileDialog();
                uploadOpenFileDialog.Filter = "程序,数据文件|*.aiton;*.db|所有类型文件|*.*";
                string filename = "";
                string ftpaddr = td.Node.sIpAddress;
                if (uploadOpenFileDialog.ShowDialog() == DialogResult.OK)
                {

                    filename = uploadOpenFileDialog.FileName;
                    if (!CFtp.UploadFile(filename, ftpaddr, Pwdbox.Password))
                    {
                        MessageBox.Show("上传" + filename + "失败！", "上传", MessageBoxButton.OK,
                    MessageBoxImage.Error);
                    }
                    else
                    {
                        this.Button_Click(null, null);
                        MessageBox.Show("上传" + filename + "成功！", "上传", MessageBoxButton.OK,
                       MessageBoxImage.Information);
                    }
                }
                else
                {
                    return;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("上传操作异常！", "上传", MessageBoxButton.OK,
                   MessageBoxImage.Exclamation);
            }
        }

        private void Recover_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string filename = FileListBox.SelectedItem.ToString();
                string ftpaddr = td.Node.sIpAddress;
                if (filename.Equals("Gb.aiton.bak"))
                {
                    Udp.sendUdpNoReciveData(td.Node.sIpAddress, td.Node.iPort, Define.UPDATE_TSC_REVERSE);
                    this.Button_Click(null, null);

                }
                else if (filename.Equals("GbAitonTsc.db.bak"))
                {
                    Udp.sendUdpNoReciveData(td.Node.sIpAddress, td.Node.iPort, Define.UPDATE_DATABASE_REVERSE);
                    this.Button_Click(null, null);

                }
                else
                {
                    MessageBox.Show("非标准程序和数据文件,无法恢复！", "恢复", MessageBoxButton.OK,
                        MessageBoxImage.Error);
                    return;
                }
                MessageBox.Show("恢复操作成,信号机重启......！", "恢复", MessageBoxButton.OK,
                       MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("恢复操作异常!", "恢复", MessageBoxButton.OK,
                       MessageBoxImage.Exclamation);
            }
        }

        private void FileListBox_ContextMenuOpening(object sender, System.Windows.Controls.ContextMenuEventArgs e)
        {
            if (FileListBox.SelectedItems.Count == 0x0)
            {
                FileListBox.ContextMenu.Visibility = Visibility.Hidden;
            }
            else
            {
                FileListBox.ContextMenu.Visibility = Visibility.Visible;
            }
        }

        private void ReStart_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                byte[] mybyte = new byte[5];
                mybyte[0] = 0x81;
                mybyte[1] = 0xf6;
                mybyte[2] = 0x1;
                mybyte[3] = 0x0;
                mybyte[4] = 0x1;
                bool bRstart = Udp.sendUdpNoReciveData(td.Node.sIpAddress, td.Node.iPort, mybyte);
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
    }
}
