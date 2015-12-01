using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Apex.MVVM;
using Apex.Behaviours;
using tscui.Models;

using System.Windows.Threading;
using System.Threading;
using Xceed.Wpf.Toolkit;
using tscui.Service;

namespace tscui.Pages.Music
{
    /// <summary>
    /// Interaction logic for MusicView.xaml
    /// </summary>
    [View(typeof(MusicViewModel))]
    public partial class MusicView : UserControl, IView
    {
        TscData tdData;
        int currentPhaseId = 0;
        public MusicView()
        {
            InitializeComponent();
            this.PhaseGrid.AddHandler(Label.MouseLeftButtonDownEvent, new RoutedEventHandler(MouseLeftButton_Down));
        }

        private void MouseLeftButton_Down(object sender, RoutedEventArgs e)
        {
            if (e.OriginalSource != null)
            {
                Label ChannelLabel = e.OriginalSource as Label;
                if (ChannelLabel !=  null)
                {
                    for (Byte index = 1; index <= 32; index++)
                    {
                        if (ChannelLabel.Name.Equals("lblChannel" + index))
                        {
                            tbxChannelId.Text = index.ToString();
                            e.Handled = true;
                            break;
                        }
                    }
                   
                }
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
        private delegate void DelegateInitPhaseType();
        private void DispatcherInitPhaseType()
        {
            this.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new DelegateInitPhaseType(InitPhaseType));
        }

        private delegate void DelegatePhaseOption();
        private void DispatcherPhaseOption()
        {
            this.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new DelegatePhaseOption(InitPhaseOption));
        }
        private delegate void DelegateOverlapPhaseType();
        private void DispatcherOverlapPhaseType()
        {
            this.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new DelegateOverlapPhaseType(InitOverlapPhaseType));
        }

        private delegate void DelegateOverlap();
        private void DispatcherOverlap()
        {
            this.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new DelegateOverlap(InitOverlap));
        }

    
        public List<DirecNumer> dirnum = new List<DirecNumer>();
        public void InitDirecNumber()
        {
            dirnum.Add(new DirecNumer() { name = "北左", value = 1 });
            dirnum.Add(new DirecNumer() { name = "北直", value = 2 });
            dirnum.Add(new DirecNumer() { name = "北右", value = 4 });
            dirnum.Add(new DirecNumer() { name = "北人行", value = 8 });
            dirnum.Add(new DirecNumer() { name = "北二次过街", value = 0x18 });
            dirnum.Add(new DirecNumer() { name = "北调头", value = 0 });
            dirnum.Add(new DirecNumer() { name = "北其他", value = 5 });
            dirnum.Add(new DirecNumer() { name = "北特殊", value = 0x7 });

            dirnum.Add(new DirecNumer() { name = "东左", value = 65 });
            dirnum.Add(new DirecNumer() { name = "东直", value = 66 });
            dirnum.Add(new DirecNumer() { name = "东右", value = 68 });
            dirnum.Add(new DirecNumer() { name = "东人行", value = 72 });
            dirnum.Add(new DirecNumer() { name = "东二次过街", value = 0x58 });
            dirnum.Add(new DirecNumer() { name = "东调头", value = 0x40 });
            dirnum.Add(new DirecNumer() { name = "东其他", value = 69 });
            dirnum.Add(new DirecNumer() {name = "东特殊", value = 0x47});


            dirnum.Add(new DirecNumer() { name = "南左", value = 129 });
            dirnum.Add(new DirecNumer() { name = "南直", value = 130 });
            dirnum.Add(new DirecNumer() { name = "南右", value = 132 });
            dirnum.Add(new DirecNumer() { name = "南人行", value = 136 });
            dirnum.Add(new DirecNumer() { name = "南二次过街", value = 0x98 });
            dirnum.Add(new DirecNumer() {name = "南调头", value = 0x80});
            dirnum.Add(new DirecNumer() { name = "南其他", value = 133 });
            dirnum.Add(new DirecNumer() { name = "南特殊", value = 0x87 });

            dirnum.Add(new DirecNumer() { name = "西左", value = 193 });
            dirnum.Add(new DirecNumer() { name = "西直", value = 194 });
            dirnum.Add(new DirecNumer() { name = "西右", value = 196 });
            dirnum.Add(new DirecNumer() { name = "西人行", value = 200 });
            dirnum.Add(new DirecNumer() { name = "西二次过街", value = 0xd8 });
            dirnum.Add(new DirecNumer() { name = "西调头", value = 0xc0 });
            dirnum.Add(new DirecNumer() { name = "西其他", value = 197 });
            dirnum.Add(new DirecNumer() { name = "西特殊", value = 0xc7 });
           
        }

        List<ChannelType> lct = new List<ChannelType>();
        List<ChannelFlash> lcf = new List<ChannelFlash>();
        private void InitChannel()
        {
            lct.Add(new ChannelType() { name = "其它", value = 1 });
            lct.Add(new ChannelType() { name = "机动车", value = 2 });
            lct.Add(new ChannelType() { name = "行人", value = 3 });
            lct.Add(new ChannelType() { name = "跟随相位", value = 4 });

            lcf.Add(new ChannelFlash() { name = "未设置", value = 0 });
            lcf.Add(new ChannelFlash() { name = "黄灯闪(前半秒亮)", value = 2 });
            lcf.Add(new ChannelFlash() { name = "黄灯闪(后半秒亮)", value = 10 });
            lcf.Add(new ChannelFlash() { name = "红灯闪(前半秒亮)", value = 4 });
            lcf.Add(new ChannelFlash() { name = "红灯闪(后半秒亮)", value = 12 });
            

            cbxChannelType.ItemsSource = lct;
            cbxAutoFlash.ItemsSource = lcf;
        }

        List<PhaseType> lpt = new List<PhaseType>();
        private void InitPhaseType()
        {
            
            lpt.Add(new PhaseType() { typeName = "固定相位", ucType = 0x80 });
            lpt.Add(new PhaseType() { typeName = "特定相位", ucType = 0x40 });
            lpt.Add(new PhaseType() { typeName = "弹性相位", ucType = 0x20 });
            lpt.Add(new PhaseType() { typeName = "关键相位", ucType = 0x10 });
            lpt.Add(new PhaseType() { typeName = "未知", ucType = 0 });
            cbxPhaseType.ItemsSource = lpt;
        }
        List<PhaseOption> lpo = new List<PhaseOption>();
        private void InitPhaseOption()
        {
            
            lpo.Add(new PhaseOption() { optionName = "同阶放行", ucOption = 0x10 });
            lpo.Add(new PhaseOption() { optionName = "人车放行", ucOption = 0x08 });
            lpo.Add(new PhaseOption() { optionName = "特定相位出现", ucOption = 0x04 });
            lpo.Add(new PhaseOption() { optionName = "人行过街相位", ucOption = 0x02 });
            lpo.Add(new PhaseOption() { optionName = "相位启用", ucOption = 0x01 });
            lpo.Add(new PhaseOption() { optionName = "未知", ucOption = 0 });
            cbxPhaseOption.ItemsSource = lpo;
        }

        List<OverlapPhaseType> lopt = new List<OverlapPhaseType>();
        private void InitOverlapPhaseType()
        {
            
            lopt.Add(new OverlapPhaseType() { name = "其他", value = 1 });
            lopt.Add(new OverlapPhaseType() { name = "正常", value = 2 });
            lopt.Add(new OverlapPhaseType() { name = "最小绿灯黄灯", value = 3 });
            lopt.Add(new OverlapPhaseType() { name = "未知", value = 0 });
            cbxOperateType.ItemsSource = lopt;

        }

        public List<ChannelPhaseOverlap> lcpo = new List<ChannelPhaseOverlap>();
        public void Initpoplist()
        {
            for (byte a = 1; a < 33; a++)
                lcpo.Add(new ChannelPhaseOverlap() { id = a, name = "p" + a, isPhase = true });
            for (byte b = 1; b < 17; b++)
                lcpo.Add(new ChannelPhaseOverlap() { id = b, name = "op" + b, isPhase = false });
            lcpo.Add(new ChannelPhaseOverlap() { id = 0x0, name = "null", isPhase = false });
        }

        private void InitOverlap()
        {
            tdData = Utils.Utils.GetTscDataByApplicationCurrentProperties();

            List<Models.Phase> lp = tdData.ListPhase;
           
            ccbIncludePhase1.ItemsSource = lp;
            ccbCorrectPhase.ItemsSource = lp;
            

            DirectPhaseId.ItemsSource = lcpo; //初始化方向相位
            ChannelPhaseId.ItemsSource = lcpo;//初始化通道相位
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            tdData = Utils.Utils.GetTscDataByApplicationCurrentProperties();
            if (tdData == null)
            {
                this.Visibility = Visibility.Hidden;
                return;
            }
            this.Visibility = Visibility.Visible;
            if(lcpo.Count == 0)
                Initpoplist();
            //下拉框数据填充
            Thread tDispatcherOverlap = new Thread(DispatcherOverlap);
            tDispatcherOverlap.IsBackground = true;
            tDispatcherOverlap.Start();
            Thread tDispatcherOverlapPhaseType = new Thread(DispatcherOverlapPhaseType);
            tDispatcherOverlapPhaseType.IsBackground = true;
            tDispatcherOverlapPhaseType.Start();
            Thread tDispatcherPhaseOption = new Thread(DispatcherPhaseOption);
            tDispatcherPhaseOption.IsBackground = true;
            tDispatcherPhaseOption.Start();
            Thread tDispatcherInitPhaseType = new Thread(DispatcherInitPhaseType);
            tDispatcherInitPhaseType.IsBackground = true;
            tDispatcherInitPhaseType.Start();
            InitChannel();
            //初始化显示相位数据与通道关联
         //   InitPhaseChannel();
            FreshPhaseChannelShow();
         //   InitDirecNumber();
            if (DirecCombox.Items.Count == 0)
            {
                if(dirnum.Count == 0)
                    InitDirecNumber();
                DirecCombox.ItemsSource = dirnum;
            }
            

        }


        private void FreshPhaseChannelShow()
        {
            try
            {
                List<Channel> channels = tdData.ListChannel;
                Byte ChannelId = 0x0;
                foreach (Channel c in channels)
                {
                    ChannelId = c.ucId;
                    Label LblChannelShow = (Label) groupBox1.FindName("lblChannel" + ChannelId);
                    Label LblPhaseShow = (Label) groupBox1.FindName("LblPhase" + ChannelId);
                    if (LblChannelShow == null || LblPhaseShow == null)
                        continue;
                    else if (c.ucType == 1)
                    {
//其它 
                        LblPhaseShow.Content = lcpo[c.ucSourcePhase - 1].name;
                        LblChannelShow.Background = Brushes.Gray;
                        LblPhaseShow.Foreground = Brushes.Gray;
                    }
                    else if (c.ucType == 2)
                    {
//机动车相位
                        LblPhaseShow.Content = lcpo[c.ucSourcePhase - 1].name;
                        LblChannelShow.Background = Brushes.DarkRed;
                        LblPhaseShow.Foreground = Brushes.DarkRed;
                    }
                    else if (c.ucType == 3)
                    {
                        // 人行相位
                        LblPhaseShow.Content = lcpo[c.ucSourcePhase - 1].name;
                        LblChannelShow.Background = Brushes.Green;
                        LblPhaseShow.Foreground = Brushes.Green;
                    }
                    else if (c.ucType == 4)
                    {
                        //跟随相位
                        LblPhaseShow.Content = lcpo[c.ucSourcePhase + 0x20 - 1].name;
                        LblChannelShow.Background = Brushes.DarkOrange;
                        LblPhaseShow.Foreground = Brushes.DarkOrange;
                    }

                }
            }
            catch (Exception ex)
            {
                return;
            }

        }


      

        private byte currentOverlapPhase = 0;
   
        private void ClearPhaseContentById()
        {
            try
            {
                tbxFixedGreenTime.Text = "";
                tbxGreenFlash.Text = "";
                tbxMax1Time.Text = "";
                tbxMax2Time.Text = "";
                tbxMinGreenTime.Text = "";

                // cbxPhaseOption.SelectedItem = po;

                tbxPedestrainClearTime.Text = "";
                tbxPedestrainCrossTime.Text = "";

                //cbxPhaseType.SelectedItem = pt;
            }
            catch (Exception ex)
            {

            }
           
               
        }
        private void tbxPhaseId_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                tdData = Utils.Utils.GetTscDataByApplicationCurrentProperties();
                if (tdData == null)
                    return;
                tbxPhaseId.Background = Brushes.LightGray;
                List<Models.Phase> phases = tdData.ListPhase;
                ClearPhaseContentById();
                if (Byte.Parse(tbxPhaseId.Text) != 0)
                {
                    ClearPhaseContentById();
                    pchannels.Content = "";
                    foreach (Models.Phase p in phases)
                    {
                        if (p.ucId == Byte.Parse(tbxPhaseId.Text))
                        {

                            tbxFixedGreenTime.Text = "" + p.ucFixedGreen;
                            tbxGreenFlash.Text = "" + p.ucGreenFlash;
                            tbxMax1Time.Text = "" + p.ucMaxGreen1;
                            tbxMax2Time.Text = "" + p.ucMaxGreen2;
                            tbxMinGreenTime.Text = "" + p.ucMinGreen;
                            tbxUintDelayTime.Text = "" + p.ucGreenDelayUnit;
                            foreach (PhaseOption po in lpo)
                            {
                                if (po.ucOption == p.ucOption)
                                {
                                    cbxPhaseOption.SelectedItem = po;
                                }
                            }

                            tbxPedestrainClearTime.Text = "" + p.ucPedestrianClear;
                            tbxPedestrainCrossTime.Text = "" + p.ucPedestrianGreen;
                            foreach (PhaseType pt in lpt)
                            {
                                if (pt.ucType == p.ucType)
                                {
                                    cbxPhaseType.SelectedItem = pt;
                                }
                            }
                            foreach (Channel ch in tdData.ListChannel)
                            {
                                if (p.ucId == ch.ucSourcePhase && ch.ucType != 0x4)
                                    pchannels.Content += ch.ucId.ToString() + " ,";
                            }
                            foreach (ChannelPhaseOverlap oorp in lcpo)
                            {
                                if (p.ucId == oorp.id && oorp.isPhase == true)
                                {
                                    DirectPhaseId.SelectedIndex = oorp.id - 1;
                                    break;
                                }
                            }
                            tbxPhaseId.Background = Brushes.DarkRed;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("获取相位参数异常","高级相位",MessageBoxButton.OK,MessageBoxImage.Exclamation);
            }
        }
        private void ClearOverlapContentById()
        {
        
            tbxTailGreen.Text = "0";
            tbxRedTime.Text = "0";
            tbxYellowTime.Text = "0";
        }
        private void tbxOverlapPhaseId_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                tdData = Utils.Utils.GetTscDataByApplicationCurrentProperties();
                if (tdData == null)
                {
                    return;
                }
                tbxOverlapPhaseId.Background = Brushes.LightGray;
                List<OverlapPhase> overlapPhases = tdData.ListOverlapPhase;
         //       List<Models.Phase> phases = tdData.ListPhase;
                if (Byte.Parse(tbxOverlapPhaseId.Text) != 0)
                {
                    ClearOverlapContentById();
                    ccbCorrectPhase.Text = "";
                    ccbIncludePhase1.Text = "";
                    opchannels.Content = "";
                    // DirecCombox.SelectedIndex = -1;
                    ccbIncludePhase1.SelectedItems.Clear();

                    foreach (OverlapPhase op in overlapPhases)
                    {
                        if (op.ucId == Byte.Parse(tbxOverlapPhaseId.Text))
                        {
                            tbxOverlapPhaseId.Background = label11_Copy3.Background;
                         
                            ccbIncludePhase1.SelectedItems.Clear();
                            for (int j = 0; j < op.ucIncludePhaseLen; j++)
                            {
                              
                                ccbIncludePhase1.Text += op.ucIncludePhase[j] + " ,";
                                
                                ccbIncludePhase1.SelectedItems.Add(ccbIncludePhase1.Items[op.ucIncludePhase[j]-1]);
                                
                            }
                            //  ccbIncludePhase1.SelectedItemsOverride = listInclude;
                            foreach (OverlapPhaseType opt in lopt)
                            {
                                if (opt.value == op.ucOperateType)
                                {
                                    cbxOperateType.SelectedItem = opt;
                                    break;
                                }
                            }
                            //     for (Byte k = 0; k < t.ListOverlapPhase.Count; k++)
                            foreach (Channel ch in tdData.ListChannel)
                            {
                                if (op.ucId == ch.ucSourcePhase && ch.ucType == 0x4)
                                    opchannels.Content += ch.ucId+ " ,";
                            }
                            foreach (ChannelPhaseOverlap oorp in lcpo)
                            {
                                if (op.ucId == oorp.id && oorp.isPhase == false)
                                {
                                    DirectPhaseId.SelectedIndex = oorp.id + 32 - 1;
                                    break;
                                }
                            }
                            tbxTailGreen.Text = "" + op.ucTailGreen;
                            tbxRedTime.Text   = "" + op.ucTailRed;
                            tbxYellowTime.Text = "" + op.ucTailYellow;
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("获取跟随相位参数异常", "高级相位", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }
        private void ClearChannelContentById()
        {
            cbxAutoFlash.SelectedItem = new ChannelFlash();
            cbxChannelType.SelectedItem = new  ChannelType();
        }
        private void tbxChannelId_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                tdData = Utils.Utils.GetTscDataByApplicationCurrentProperties();
                if (tdData == null)
                {
                    return;
                }
                tbxChannelId.Background = Brushes.LightGray;
                List<Channel> channels = tdData.ListChannel;
                if (Convert.ToByte(tbxChannelId.Text) != 0)
                {
                    ClearChannelContentById();
                    foreach (Channel channel in channels)
                    {
                        if (channel.ucId == Convert.ToByte(tbxChannelId.Text))
                        {
                            foreach (ChannelFlash cf in lcf)
                            {
                                if (cf.value == channel.ucFlashAuto)
                                {
                                    cbxAutoFlash.SelectedItem = cf;
                                    break;
                                }
                            }
                            foreach (ChannelType ct in lct)
                            {
                                if (ct.value == channel.ucType)
                                {
                                    cbxChannelType.SelectedItem = ct;
                                    if (channel.ucType == 0x2)
                                    {
                                        tbxChannelId.Background = Brushes.DarkRed;
                                    }
                                    else
                                    if (channel.ucType == 0x3)
                                    {
                                         tbxChannelId.Background = Brushes.Green;
                                    }
                                    else if (channel.ucType == 0x4)
                                    {
                                        tbxChannelId.Background = Brushes.Yellow;

                                    }
                                    break;
                                }
                            }
                            foreach (ChannelPhaseOverlap cpo in lcpo)
                            {
                                if (cpo.id == channel.ucSourcePhase)
                                {
                                    if (channel.ucType == 0x4)
                                        ChannelPhaseId.SelectedIndex = cpo.id + 32 - 1;
                                    else
                                    {
                                        ChannelPhaseId.SelectedIndex = cpo.id - 1;
                                    }
                                    DirectPhaseId.SelectedIndex = ChannelPhaseId.SelectedIndex;
                                    break;
                                }
                            }
                         
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("获取通道参数异常", "高级相位", MessageBoxButton.OK, MessageBoxImage.Exclamation);

            }
        }
      
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                tdData = Utils.Utils.GetTscDataByApplicationCurrentProperties();
                bool bmultiselect = false;
                List<tscui.Models.Phase> phases = tdData.ListPhase;
                if (MultisetCheck.IsChecked == true)
                {
                    foreach (UIElement checkbox in multisetbox.Items)
                    {
                        CheckBox phaseCheckBox = (CheckBox) checkbox;
                        if (phaseCheckBox.IsChecked == true && phaseCheckBox.Name != "AllChecks")
                        {
                            if (bmultiselect == false)
                                bmultiselect = true;
                            foreach (tscui.Models.Phase p in phases)
                            {
                                if (p.ucId == Byte.Parse(phaseCheckBox.Content.ToString()))
                                {
                                    p.ucFixedGreen = Byte.Parse(tbxFixedGreenTime.Text);
                                    p.ucGreenDelayUnit = Byte.Parse(tbxUintDelayTime.Text);
                                    p.ucGreenFlash = Byte.Parse(tbxGreenFlash.Text);
                                    p.ucMaxGreen1 = Byte.Parse(tbxMax1Time.Text);
                                    p.ucMaxGreen2 = Byte.Parse(tbxMax2Time.Text);
                                    p.ucMinGreen = Byte.Parse(tbxMinGreenTime.Text);
                                    p.ucPedestrianClear = Byte.Parse(tbxPedestrainClearTime.Text);
                                    p.ucPedestrianGreen = Byte.Parse(tbxPedestrainCrossTime.Text);
                                }
                            }

                        }

                    }
                    if (bmultiselect == false)
                    {
                        System.Windows.MessageBox.Show("多选设置未选中任何相位", "高级相位", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }

                }
                else
                {
                    foreach (Models.Phase p in phases)
                    {
                        if (p.ucId == Byte.Parse(tbxPhaseId.Text))
                        {
                            p.ucExtend = 0;
                            p.ucFixedGreen = Byte.Parse(tbxFixedGreenTime.Text);
                            p.ucGreenDelayUnit = Byte.Parse(tbxUintDelayTime.Text);
                            p.ucGreenFlash = Byte.Parse(tbxGreenFlash.Text);
                            p.ucMaxGreen1 = Byte.Parse(tbxMax1Time.Text);
                            p.ucMaxGreen2 = Byte.Parse(tbxMax2Time.Text);
                            p.ucMinGreen = Byte.Parse(tbxMinGreenTime.Text);
                            PhaseOption po = ((PhaseOption) cbxPhaseOption.SelectedValue);
                            p.ucOption = Convert.ToByte(po.ucOption);
                            p.ucPedestrianClear = Byte.Parse(tbxPedestrainClearTime.Text);
                            p.ucPedestrianGreen = Byte.Parse(tbxPedestrainCrossTime.Text);
                            p.ucType = Convert.ToByte(((PhaseType) cbxPhaseType.SelectedValue).ucType);
                        }
                    }
                }
                Message m = TscDataUtils.SetPhase(phases);
                System.Windows.MessageBox.Show(m.msg);
            }
            catch (Exception  ex)
            {
                System.Windows.MessageBox.Show("保存相位参数异常", "高级相位", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }
        
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                tdData = Utils.Utils.GetTscDataByApplicationCurrentProperties();
           
                bool newOverPhase = true;
                List<OverlapPhase> overlapPhases = tdData.ListOverlapPhase;
                OverlapPhase op = new OverlapPhase();
                op.ucId = Byte.Parse(tbxOverlapPhaseId.Text);
                int correctCount = ccbCorrectPhase.SelectedItems.Count;
                byte[] bytesCorrect = new byte[0x20];
                for (int j = 0; j < correctCount; j++)
                {
                    bytesCorrect[j] = Convert.ToByte(((tscui.Models.Phase) ccbCorrectPhase.SelectedItems[j]).ucId);
                }
                op.ucCorrectPhase = bytesCorrect;
                op.ucCorrectPhaseLen = Convert.ToByte(ccbCorrectPhase.SelectedItems.Count);
                op.ucTailGreen = Convert.ToByte(tbxTailGreen.Text);
                op.ucTailRed = Convert.ToByte(tbxRedTime.Text);
                op.ucTailYellow = Convert.ToByte(tbxYellowTime.Text);

                //includePhase list
                int includeCount = ccbIncludePhase1.SelectedItems.Count;
                byte[] bytesinclude = new byte[0x20];
                for (int i = 0; i < includeCount; i++)
                {
                    bytesinclude[i] = Convert.ToByte(((Models.Phase) ccbIncludePhase1.SelectedItems[i]).ucId);
                }
                op.ucIncludePhase = bytesinclude;
                op.ucIncludePhaseLen = Convert.ToByte(ccbIncludePhase1.SelectedItems.Count);
                op.ucOperateType = Convert.ToByte(((OverlapPhaseType) cbxOperateType.SelectedValue).value);

                foreach (OverlapPhase tscop in overlapPhases)
                {
                    if (tscop.ucId == op.ucId)
                    {
                        tscop.ucOperateType = op.ucOperateType;
                        tscop.ucIncludePhaseLen = op.ucIncludePhaseLen;
                        Array.Copy(op.ucIncludePhase, tscop.ucIncludePhase, 0x20);
                        tscop.ucCorrectPhaseLen = op.ucCorrectPhaseLen;
                        Array.Copy(op.ucCorrectPhase, tscop.ucCorrectPhase, 0x20);
                        tscop.ucTailGreen = op.ucTailGreen;
                        tscop.ucTailRed = op.ucTailRed;
                        tscop.ucTailYellow = op.ucTailYellow;
                        newOverPhase = false;
                        break;
                    }
                }
                if (newOverPhase == true)
                {
                    tdData.ListOverlapPhase.Add(op);
                }
                Message m = TscDataUtils.SetOverlapPhase(overlapPhases);
                System.Windows.MessageBox.Show(m.msg);
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("保存跟随相位参数异常", "高级相位", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            try
            {
                tdData = Utils.Utils.GetTscDataByApplicationCurrentProperties();
                List<Channel> channels = tdData.ListChannel;
                foreach (Channel channel in channels)
                {
                    if (channel.ucId == Convert.ToByte(tbxChannelId.Text))
                    {
                        channel.ucFlashAuto = Convert.ToByte(((ChannelFlash) cbxAutoFlash.SelectedValue).value);
                        channel.ucType = Convert.ToByte(((ChannelType) cbxChannelType.SelectedValue).value);
                        ChannelPhaseOverlap cpo = (ChannelPhaseOverlap) ChannelPhaseId.SelectedValue;
                        channel.ucSourcePhase = cpo.id;
                        if ((channel.ucType == 0x4 && ChannelPhaseId.SelectedIndex < 32) ||
                            (channel.ucType == 0x2 && ChannelPhaseId.SelectedIndex >= 32 && ChannelPhaseId.SelectedIndex != 48)) //48是相位号0
                        {
                            System.Windows.MessageBox.Show("选择的通道类型和相位类型号不匹配", "高级相位", MessageBoxButton.OK, MessageBoxImage.Error);
                            return;
                        }
                        break;
                    }
                }
                Message m = TscDataUtils.SetChannel(channels);
                System.Windows.MessageBox.Show(m.msg);
                FreshPhaseChannelShow();
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("保存通道参数异常", "高级相位", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }

        }
       
        private void btnDirec_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                tdData = Utils.Utils.GetTscDataByApplicationCurrentProperties();
            
                List<PhaseToDirec> direcs = tdData.ListPhaseToDirec;
                foreach (PhaseToDirec ptd in direcs)
                {
                    if (ptd.ucId == Convert.ToByte(((DirecNumer)DirecCombox.SelectedValue).value))
                    {
                        ChannelPhaseOverlap cpo = (ChannelPhaseOverlap)DirectPhaseId.SelectedValue;
                       
                        if (DirectPhaseId.SelectedIndex == -1 || cpo.id == 0)
                        {
                            ptd.ucPhase = 0;
                            ptd.ucOverlapPhase = 0;
                        }
                        else
                        {
                            
                            if (cpo.isPhase == true)
                            {
                                foreach (PhaseToDirec ptdphase in direcs)
                                {
                                    if (ptdphase.ucPhase == cpo.id && ptdphase.ucId != ptd.ucId)
                                    {
                                        foreach ( DirecNumer direcname in dirnum)
                                        {
                                            if (direcname.value == ptdphase.ucId)
                                            {
                                               // MessageBox.Show("该相位已经被分配到->"+ direcname.name);
                                                System.Windows.MessageBox.Show("该相位已经被分配到->" + direcname.name + "\r\n请先解除" + direcname.name + "与该相位关联" + "\r\n" + direcname.name + "选择下拉列表最后00相位保存!", "高级相位", MessageBoxButton.OK, MessageBoxImage.Error);

                                                return;
                                            }
                                        }
                                       
                                    }

                                }
                                ptd.ucPhase = cpo.id;
                                ptd.ucOverlapPhase = 0;
                            }
                            else
                            {
                                foreach (PhaseToDirec ptdphase in direcs)
                                {
                                    if (ptdphase.ucOverlapPhase == cpo.id && ptdphase.ucId != ptd.ucId)
                                    {
                                        foreach (DirecNumer direcname in dirnum)
                                        {
                                            if (direcname.value == ptdphase.ucId)
                                            {
                                                System.Windows.MessageBox.Show("该相位已经被分配到->" + direcname.name + "\r\n请先解除" + direcname.name + "与该相位关联" + "\r\n" + direcname.name + "选择下拉列表最后00相位保存!", "高级相位", MessageBoxButton.OK, MessageBoxImage.Error);

                                                return;
                                            }
                                        }

                                       
                                    }

                                }
                                ptd.ucOverlapPhase = cpo.id;
                                ptd.ucPhase = 0;
                            }
                        }
                        ptd.ucRoadCnt = Convert.ToByte(tbxRoadCnt.Text);
                        break;
                    }
                }



                Message m = TscDataUtils.SetPhaseToDirec(direcs);
                System.Windows.MessageBox.Show(m.msg);
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("保存方向相位参数异常", "高级相位", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }
        


        private void bsrRoadCount_Spin(object sender, SpinEventArgs e)
        {
            ButtonSpinner spinner = (ButtonSpinner)sender;
            TextBox txtBox = (TextBox)spinner.Content;

            int value = String.IsNullOrEmpty(txtBox.Text) ? 0 : Convert.ToInt32(txtBox.Text);
            if (e.Direction == SpinDirection.Increase)
                value++;
            else
                value--;
            if (value <= 1)
            {
                value = 1;
            }
            txtBox.Text = value.ToString();
        }

        private void bsrChannelId_Spin(object sender, SpinEventArgs e)
        {
            ButtonSpinner spinner = (ButtonSpinner)sender;
            TextBox txtBox = (TextBox)spinner.Content;

            int value = String.IsNullOrEmpty(txtBox.Text) ? 0 : Convert.ToInt32(txtBox.Text);
            if (e.Direction == SpinDirection.Increase)
                value++;
            else
                value--;
            if (value <= 1)
            {
                value = 1;
            }
            else if (value >= 32)
            {
                value = 32;
            }
            txtBox.Text = value.ToString();
        }

        private void bsrOverlapPhaseId_Spin(object sender, SpinEventArgs e)
        {
            ButtonSpinner spinner = (ButtonSpinner)sender;
            TextBox txtBox = (TextBox)spinner.Content;

            int value = String.IsNullOrEmpty(txtBox.Text) ? 0 : Convert.ToInt32(txtBox.Text);
            if (e.Direction == SpinDirection.Increase)
                value++;
            else
                value--;
            if (value <= 1)
            {
                value = 1;
            }
            else if (value >= 16)
            {
                value = 16;
            }
            txtBox.Text = value.ToString();
        }

        private void bsrGreenTime_Spin_1(object sender, SpinEventArgs e)
        {
            ButtonSpinner spinner = (ButtonSpinner)sender;
            TextBox txtBox = (TextBox)spinner.Content;

            int value = String.IsNullOrEmpty(txtBox.Text) ? 0 : Convert.ToInt32(txtBox.Text);
            if (e.Direction == SpinDirection.Increase)
                value++;
            else
                value--;
            if (value <= 1)
            {
                value = 1;
            }
            txtBox.Text = value.ToString();
        }

        private void bsrYellowTime_Spin_1(object sender, SpinEventArgs e)
        {
            ButtonSpinner spinner = (ButtonSpinner)sender;
            TextBox txtBox = (TextBox)spinner.Content;

            int value = String.IsNullOrEmpty(txtBox.Text) ? 0 : Convert.ToInt32(txtBox.Text);
            if (e.Direction == SpinDirection.Increase)
                value++;
            else
                value--;
            if (value <= 1)
            {
                value = 1;
            }
            txtBox.Text = value.ToString();
        }

        private void bsrRedTime_Spin_1(object sender, SpinEventArgs e)
        {
            ButtonSpinner spinner = (ButtonSpinner)sender;
            TextBox txtBox = (TextBox)spinner.Content;

            int value = String.IsNullOrEmpty(txtBox.Text) ? 0 : Convert.ToInt32(txtBox.Text);
            if (e.Direction == SpinDirection.Increase)
                value++;
            else
                value--;
            if (value <= 1)
            {
                value = 1;
            }
            txtBox.Text = value.ToString();
        }

        private void phaseId_Spin(object sender, SpinEventArgs e)
        {
            ButtonSpinner spinner = (ButtonSpinner)sender;
            TextBox txtBox = (TextBox)spinner.Content;

            int value = String.IsNullOrEmpty(txtBox.Text) ? 0 : Convert.ToInt32(txtBox.Text);
            
            if (e.Direction == SpinDirection.Increase)
                value++;
            else
                value--;
            if (value <= 1)
            {
                value = 1;
            }
            else if (value >= 32)
            {
                value = 32;
            }
            txtBox.Text = value.ToString();
        }

        private void bsrPedestrainClearTime_Spin(object sender, SpinEventArgs e)
        {
            ButtonSpinner spinner = (ButtonSpinner)sender;
            TextBox txtBox = (TextBox)spinner.Content;

            int value = String.IsNullOrEmpty(txtBox.Text) ? 0 : Convert.ToInt32(txtBox.Text);
            if (e.Direction == SpinDirection.Increase)
                value++;
            else
                value--;
            if (value <= 1)
            {
                value = 1;
            }
            txtBox.Text = value.ToString();
        }

        private void bsrPedestrainCrossTime_Spin(object sender, SpinEventArgs e)
        {
            ButtonSpinner spinner = (ButtonSpinner)sender;
            TextBox txtBox = (TextBox)spinner.Content;

            int value = String.IsNullOrEmpty(txtBox.Text) ? 0 : Convert.ToInt32(txtBox.Text);
            if (e.Direction == SpinDirection.Increase)
                value++;
            else
                value--;
            if (value <= 1)
            {
                value = 1;
            }
            txtBox.Text = value.ToString();
        }

        private void bsrGreenFlash_Spin_1(object sender, SpinEventArgs e)
        {
            ButtonSpinner spinner = (ButtonSpinner)sender;
            TextBox txtBox = (TextBox)spinner.Content;

            int value = String.IsNullOrEmpty(txtBox.Text) ? 0 : Convert.ToInt32(txtBox.Text);
            if (e.Direction == SpinDirection.Increase)
                value++;
            else
                value--;
            if (value <= 1)
            {
                value = 1;
            }
            txtBox.Text = value.ToString();
        }

        private void bsrMax2Time_Spin_1(object sender, SpinEventArgs e)
        {
            ButtonSpinner spinner = (ButtonSpinner)sender;
            TextBox txtBox = (TextBox)spinner.Content;

            int value = String.IsNullOrEmpty(txtBox.Text) ? 0 : Convert.ToInt32(txtBox.Text);
            if (e.Direction == SpinDirection.Increase)
                value++;
            else
                value--;
            if (value <= 1)
            {
                value = 1;
            }
            txtBox.Text = value.ToString();
        }

        private void bsrMax1Time_Spin_1(object sender, SpinEventArgs e)
        {
            ButtonSpinner spinner = (ButtonSpinner)sender;
            TextBox txtBox = (TextBox)spinner.Content;

            int value = String.IsNullOrEmpty(txtBox.Text) ? 0 : Convert.ToInt32(txtBox.Text);
            if (e.Direction == SpinDirection.Increase)
                value++;
            else
                value--;
            if (value <= 1)
            {
                value = 1;
            }
            txtBox.Text = value.ToString();
        }

        private void bsrUintDelayTime_Spin_1(object sender, SpinEventArgs e)
        {
            ButtonSpinner spinner = (ButtonSpinner)sender;
            TextBox txtBox = (TextBox)spinner.Content;

            int value = String.IsNullOrEmpty(txtBox.Text) ? 0 : Convert.ToInt32(txtBox.Text);
            if (e.Direction == SpinDirection.Increase)
                value++;
            else
                value--;
            if (value <= 1)
            {
                value = 1;
            }
            txtBox.Text = value.ToString();
        }

        private void bsrFixedGreenTime_Spin_1(object sender, SpinEventArgs e)
        {
            ButtonSpinner spinner = (ButtonSpinner)sender;
            TextBox txtBox = (TextBox)spinner.Content;

            int value = String.IsNullOrEmpty(txtBox.Text) ? 0 : Convert.ToInt32(txtBox.Text);
            if (e.Direction == SpinDirection.Increase)
                value++;
            else
                value--;
            if (value <= 1)
            {
                value = 1;
            }
            txtBox.Text = value.ToString();
        }

        private void bsrMinGreenTime_Spin_1(object sender, SpinEventArgs e)
        {
            ButtonSpinner spinner = (ButtonSpinner)sender;
            TextBox txtBox = (TextBox)spinner.Content;

            int value = String.IsNullOrEmpty(txtBox.Text) ? 0 : Convert.ToInt32(txtBox.Text);
            if (e.Direction == SpinDirection.Increase)
                value++;
            else
                value--;
            if (value <= 1)
            {
                value = 1;
            }
            txtBox.Text = value.ToString();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            try
            {
                TscData td = Utils.Utils.GetTscDataByApplicationCurrentProperties();
                List<Channel> lc = td.ListChannel;
                
                foreach (Channel c in lc)
                {
                    byte channelId = c.ucId;
                    c.ucSourcePhase = ((ChannelPhaseOverlap)((ComboBox)this.FindName("channel" + channelId)).SelectedValue).id;
                    if (((ChannelPhaseOverlap)((ComboBox)this.FindName("channel" + channelId)).SelectedValue).isPhase == false)
                        c.ucType = 0x4;
                   

                }
                Message m = TscDataUtils.SetChannel(lc);
                System.Windows.MessageBox.Show(m.msg);
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("保存通道相位出错", "高级相位", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

    

        private void MultisetCheck_Click(object sender, RoutedEventArgs e)
        {
            if (MultisetCheck.IsChecked == false)
            {
                foreach (UIElement checkbox in multisetbox.Items)
                {
                    CheckBox phaseCheckBox = (CheckBox)checkbox;
                    phaseCheckBox.IsChecked = false;
                }
                
            }
        }

        private void DirecCombox_SelectChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                tdData = Utils.Utils.GetTscDataByApplicationCurrentProperties();
                if (tdData == null)
                {
                    return;
                }
                if (bdirecphase.IsChecked == true)
                    return;
                List<PhaseToDirec> tscdirecphase = tdData.ListPhaseToDirec;
          
                foreach (PhaseToDirec direcphase in tscdirecphase)
                {
                    if (DirecCombox.SelectedIndex == -1)
                        return;
                    if (direcphase.ucId == ((DirecNumer)(DirecCombox.SelectedValue)).value)
                     {
                            tbxRoadCnt.Text = direcphase.ucRoadCnt.ToString();
                            foreach (ChannelPhaseOverlap cpo in lcpo)
                            {
                                if (cpo.id == direcphase.ucPhase && cpo.isPhase == true && direcphase.ucOverlapPhase ==0)
                                {
                                    DirectPhaseId.SelectedIndex = cpo.id - 1;
                                    break;
                                }
                                else if(cpo.id == direcphase.ucOverlapPhase && cpo.isPhase == false && direcphase.ucPhase ==0)
                                {
                                    DirectPhaseId.SelectedIndex = cpo.id +0x20- 1;
                                    break;
                                }

                            }
                         break;
                     }
                   }
                
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("获取方向相关参数异常", "高级相位", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        private void DirectPhaseId_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                tdData = Utils.Utils.GetTscDataByApplicationCurrentProperties();
                if (tdData == null)
                {
                    return;
                }
                if (bdirecphase.IsChecked == true)
                    return;
                List<PhaseToDirec> tscdirecphase = tdData.ListPhaseToDirec;

                DirecCombox.SelectedIndex = -1;
                tbxRoadCnt.Text = "";
                foreach (PhaseToDirec direcphase in tscdirecphase)
                {
                    if ((direcphase.ucPhase == ((ChannelPhaseOverlap)(DirectPhaseId.SelectedValue)).id && ((ChannelPhaseOverlap)(DirectPhaseId.SelectedValue)).isPhase==true) || 
                        (direcphase.ucOverlapPhase == ((ChannelPhaseOverlap)(DirectPhaseId.SelectedValue)).id && ((ChannelPhaseOverlap)(DirectPhaseId.SelectedValue)).isPhase==false))
                    {
                        tbxRoadCnt.Text = direcphase.ucRoadCnt.ToString();
                        foreach (DirecNumer dn in dirnum)
                        {
                            if (dn.value == direcphase.ucId)
                            {
                                DirecCombox.SelectedItem = dn;
                                break;
                            }
                        }
                        break;
                    }
                }

                if (((ChannelPhaseOverlap)DirectPhaseId.SelectedValue).isPhase == false)
                 tbxOverlapPhaseId.Text = ((ChannelPhaseOverlap) DirectPhaseId.SelectedValue).id.ToString();
                else
                    tbxPhaseId.Text = ((ChannelPhaseOverlap)DirectPhaseId.SelectedValue).id.ToString();

            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("获取相位方向参数异常", "高级相位", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }


        }

        private void allchecked(object sender, RoutedEventArgs e)
        {
            foreach (UIElement checkbox in multisetbox.Items)
            {
                CheckBox phaseCheckBox = (CheckBox) checkbox;
                if (phaseCheckBox.IsChecked == false && phaseCheckBox.Name != "AllChecks")
                {
                    phaseCheckBox.IsChecked = true;
                }
            }
        }

        private void allunchecked(object sender, RoutedEventArgs e)
        {
            foreach (UIElement checkbox in multisetbox.Items)
            {
                CheckBox phaseCheckBox = (CheckBox)checkbox;
                if (phaseCheckBox.IsChecked == true && phaseCheckBox.Name != "AllChecks")
                {
                    phaseCheckBox.IsChecked = false;
                }
            }
        }

      
    }
}
