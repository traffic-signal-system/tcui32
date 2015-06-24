using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Media.Effects;
using Apex.MVVM;
using Apex.Behaviours;
using System.Windows;
using Apex;
using tscui.Pages.Music;
using tscui.Views;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using tscui.Service;
using tscui.Models;
using System.Windows.Threading;
using System.Threading;

namespace tscui.Pages.Phase
{
    /// <summary>
    /// Interaction logic for PhaseView.xaml
    /// </summary>
    [View(typeof(PhaseViewModel))]
    public partial class PhaseView : UserControl, IView
    {
        System.Windows.Threading.DispatcherTimer dispatcherTimer1;
        private Byte rotate = 0;
        private Image LastImage = null;
        TscData tdData;
        public PhaseView()
        {
            InitializeComponent();
            this.TrafficCanvas.AddHandler(Image.MouseLeftButtonDownEvent, new RoutedEventHandler(ImageMouseLeftButton_Down));
        }

        private void ImageMouseLeftButton_Down(object sender, RoutedEventArgs e)
        {
            try
            {
                if (e.OriginalSource != null)
                {
                    Image ClickImage = e.OriginalSource as Image;
                    if (ClickImage != null)
                    {
                        if (ClickImage.Name != "backgroundimage")
                        {
                            DirecPhaseCombox.Text = ClickImage.ToolTip.ToString();
                            BlurEffect newBlurEffect =
                                new BlurEffect();
                            newBlurEffect.Radius = 5;
                            ClickImage.Effect = newBlurEffect;
                            if (LastImage != null) LastImage.Effect = null;
                            LastImage = ClickImage;
                        }

                        e.Handled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("获取方向异常!");
            }
        }
        public void OnActivated()
        {
            //  Fade in all of the elements.
            SlideFadeInBehaviour.DoSlideFadeIn(this);
            //  Handle the 'show popup' executed event.ShowPopupCommandSouthRight/ShowPopupCommandSouthOther
            ((PhaseViewModel)DataContext).ShowPopupCommandSouthLeft.Executed += ShowPopupCommandSouthLeft_Executed;
            ((PhaseViewModel)DataContext).ShowPopupCommandSouthStaight.Executed += ShowPopupCommandSouthStaight_Executed;
            ((PhaseViewModel)DataContext).ShowPopupCommandSouthRight.Executed += ShowPopupCommandSouthRight_Executed;
            ((PhaseViewModel)DataContext).ShowPopupCommandSouthOther.Executed += ShowPopupCommandSouthOther_Executed;
            ((PhaseViewModel)DataContext).ShowFailePopup.Executed += ShowFailePopup_Excuted;
            
            
        }
        void ShowFailePopup_Excuted(object sender, CommandEventArgs args)
        {
            FailePopup ep1 = new FailePopup();
            ApexBroker.GetShell().ShowPopup(ep1);
 
        }
        void ShowPopupCommandSouthRight_Executed(object sender, CommandEventArgs args)
        {
            ;
        }
        void ShowPopupCommandSouthOther_Executed(object sender, CommandEventArgs args)
        {
            ;
        }
        void ShowPopupCommandSouthStaight_Executed(object sender, CommandEventArgs args)
        {
            ;

        }

        void ep1_RadioSelectedEvent()
        {
            ;
        }
        void ep2_RadioSelectedEvent()
        {
            ;

        }
        void ep3_RadioSelectedEvent()
        {
            ;
        }
        void ep4_RadioSelectedEvent()
        {
            ;
        }
        void ShowPopupCommandSouthLeft_Executed(object sender, CommandEventArgs args)
        {
            ;
        }
        public void OnDeactivated()
        {
            //  Remove the handler for the 'show popup' executed event.
            ((PhaseViewModel)DataContext).ShowPopupCommandSouthLeft.Executed -= ShowPopupCommandSouthLeft_Executed;
            ((PhaseViewModel)DataContext).ShowPopupCommandSouthStaight.Executed -= ShowPopupCommandSouthStaight_Executed;
            ((PhaseViewModel)DataContext).ShowPopupCommandSouthRight.Executed -= ShowPopupCommandSouthRight_Executed;
            ((PhaseViewModel)DataContext).ShowPopupCommandSouthOther.Executed -= ShowPopupCommandSouthOther_Executed;
            ((PhaseViewModel)DataContext).ShowFailePopup.Executed += ShowFailePopup_Excuted;
        }



        List<DirecNumer> dirnum = new List<DirecNumer>();
        private void InitDirecNumber()
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
            dirnum.Add(new DirecNumer() { name = "东特殊", value = 0x47 });


            dirnum.Add(new DirecNumer() { name = "南左", value = 129 });
            dirnum.Add(new DirecNumer() { name = "南直", value = 130 });
            dirnum.Add(new DirecNumer() { name = "南右", value = 132 });
            dirnum.Add(new DirecNumer() { name = "南人行", value = 136 });
            dirnum.Add(new DirecNumer() { name = "南二次过街", value = 0x98 });
            dirnum.Add(new DirecNumer() { name = "南调头", value = 0x80 });
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


        List<ChannelPhaseOverlap> lcpo = new List<ChannelPhaseOverlap>();
        private void InitPhaseOverlap()
        {
            for (byte a = 1; a < 33; a++)
                lcpo.Add(new ChannelPhaseOverlap() { id = a, name = "p" + a, isPhase = true });
            for (byte b = 1; b < 17; b++)
                lcpo.Add(new ChannelPhaseOverlap() { id = b, name = "op" + b, isPhase = false });
        }

        #region 设置相位按钮隐藏
        //private void SetPhaseButtonShow(bool swichflag)
        //{
        //    try
        //    {
        //        switch (swichflag)
        //        {
        //            case false:
        //                this.SouthLeft.Visibility = System.Windows.Visibility.Hidden;
        //                this.SouthRight.Visibility = System.Windows.Visibility.Hidden;
        //                this.SouthStraight.Visibility = System.Windows.Visibility.Hidden;
        //                this.SouthOther.Visibility = System.Windows.Visibility.Hidden;
        //                this.NorthLeft.Visibility = System.Windows.Visibility.Hidden;
        //                this.NorthRight.Visibility = System.Windows.Visibility.Hidden;
        //                this.NorthStraight.Visibility = System.Windows.Visibility.Hidden; ;
        //                this.NorthOther.Visibility = System.Windows.Visibility.Hidden;
        //                this.WestLeft.Visibility = System.Windows.Visibility.Hidden;
        //                this.WestRight.Visibility = System.Windows.Visibility.Hidden;
        //                this.WestStraight.Visibility = System.Windows.Visibility.Hidden;
        //                this.WestOther.Visibility = System.Windows.Visibility.Hidden;
        //                this.EastLeft.Visibility = System.Windows.Visibility.Hidden;
        //                this.EastRight.Visibility = System.Windows.Visibility.Hidden;
        //                this.EastStraight.Visibility = System.Windows.Visibility.Hidden;
        //                this.EastOther.Visibility = System.Windows.Visibility.Hidden;
        //                this.EastPedestrain1.Visibility = System.Windows.Visibility.Hidden;
        //                this.WestPedestrain1.Visibility = System.Windows.Visibility.Hidden;
        //                this.NorthPedestrain1.Visibility = System.Windows.Visibility.Hidden;
        //                this.SouthPedestrain1.Visibility = System.Windows.Visibility.Hidden;
        //                this.imgWestTurn.Visibility = Visibility.Hidden;
        //                this.imgEastTurn.Visibility = Visibility.Hidden;
        //                this.imgSouthTurn.Visibility = Visibility.Hidden;
        //                this.imgNorthTurn.Visibility = Visibility.Hidden;


        //                break;
        //            case true:
        //                this.SouthLeft.Visibility = System.Windows.Visibility.Visible;
        //                this.SouthRight.Visibility = System.Windows.Visibility.Visible;
        //                this.SouthStraight.Visibility = System.Windows.Visibility.Visible;
        //                this.SouthOther.Visibility = System.Windows.Visibility.Visible;
        //                this.NorthLeft.Visibility = System.Windows.Visibility.Visible;
        //                this.NorthRight.Visibility = System.Windows.Visibility.Visible;
        //                this.NorthStraight.Visibility = System.Windows.Visibility.Visible; ;
        //                this.NorthOther.Visibility = System.Windows.Visibility.Visible;
        //                this.WestLeft.Visibility = System.Windows.Visibility.Visible;
        //                this.WestRight.Visibility = System.Windows.Visibility.Visible;
        //                this.WestStraight.Visibility = System.Windows.Visibility.Visible;
        //                this.WestOther.Visibility = System.Windows.Visibility.Visible;
        //                this.EastLeft.Visibility = System.Windows.Visibility.Visible;
        //                this.EastRight.Visibility = System.Windows.Visibility.Visible;
        //                this.EastStraight.Visibility = System.Windows.Visibility.Visible;
        //                this.EastOther.Visibility = System.Windows.Visibility.Visible;
        //                this.EastPedestrain1.Visibility = System.Windows.Visibility.Visible;
        //                this.WestPedestrain1.Visibility = System.Windows.Visibility.Visible;
        //                this.NorthPedestrain1.Visibility = System.Windows.Visibility.Visible;
        //                this.SouthPedestrain1.Visibility = System.Windows.Visibility.Visible;
        //                this.imgWestTurn.Visibility = Visibility.Visible;
        //                this.imgEastTurn.Visibility = Visibility.Visible;
        //                this.imgSouthTurn.Visibility = Visibility.Visible;
        //                this.imgNorthTurn.Visibility = Visibility.Visible;
        //                break;

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.ToString());
        //    }

        //}
       
        #endregion


        #region 刷新灯组状态

       

        private void LampRhshStar()
        {
            dispatcherTimer1 = new DispatcherTimer();
            dispatcherTimer1.Tick += new EventHandler(dispatcherTimer1_Tick);
            dispatcherTimer1.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer1.Start();
 
        }
        private void UpdateLampColor(PhaseToDirec pPtd, byte colorType)
        {
            if (pPtd == null)
                return;
            BitmapImage setBitmapImage, setBitmapImage1;
            byte direcValue = pPtd.ucId;
            if (colorType == Define.LAMP_RED)
            {
                if (direcValue == Define.NORTH_PEDESTRAIN_ONE)
                    Console.WriteLine("NORTH_PEDESTRAIN_ONE red");
                
                setBitmapImage = new BitmapImage(new Uri("/tscui;component/Resources/Images/redlight.png", UriKind.Relative));
                setBitmapImage1 = new BitmapImage(new Uri("/tscui;component/Resources/Images/redlight1.png", UriKind.Relative));
            }
            else if (colorType == Define.LAMP_YELLOW)
            {
                setBitmapImage = new BitmapImage(new Uri("/tscui;component/Resources/Images/yellowlight.png", UriKind.Relative));
                setBitmapImage1 = new BitmapImage(new Uri("/tscui;component/Resources/Images/yellowlight1.png", UriKind.Relative));
            }
            else if (colorType == Define.LAMP_GREEN)
            {
                if (direcValue == Define.NORTH_PEDESTRAIN_ONE)
                    Console.WriteLine("NORTH_PEDESTRAIN_ONE green");
                setBitmapImage = new BitmapImage(new Uri("/tscui;component/Resources/Images/greenlight.png", UriKind.Relative));
                setBitmapImage1 = new BitmapImage(new Uri("/tscui;component/Resources/Images/greenlight1.png", UriKind.Relative));
            }
            else
            {
                return;
            }
            switch (direcValue)
            { //北方
                case (Define.NORTH_LEFT):
                    imgNorthLeft.Source = setBitmapImage;
                    break;
                case (Define.NORTH_STRAIGHT):
                    imgNorthStraight.Source = setBitmapImage;
                    break;
                case (Define.NORTH_RIGHT):
                    imgNorthRight.Source = setBitmapImage;
                    break;
                case (Define.NORTH_PEDESTRAIN_ONE):
                    imgNorthPedestrain1.Source = setBitmapImage1;
                    break;
                case (Define.NORTH_PEDESTRAIN_TWO):
                    imgNorthPedestrain2.Source = setBitmapImage1;
                    break;
                case (Define.NORTH_TURN_AROUND):
                    imgNorthTurn.Source = setBitmapImage;
                    break;
                case (Define.NORTH_OTHER):
                    imgNorthOther.Source = setBitmapImage;
                    break;
                case (Define.NORTH_LEFT_STRAIGHT_RIGHT):
                    imgWestNorthOther.Source = setBitmapImage;
                    break;
                //东方
                case (Define.EAST_LEFT):
                    imgEastLeft.Source = setBitmapImage1;
                    break;
                case (Define.EAST_STRAIGHT):
                    imgEastStraight.Source = setBitmapImage1;
                    break;
                case (Define.EAST_RIGHT):
                    imgEastRight.Source = setBitmapImage1;
                    break;
                case (Define.EAST_PEDESTRAIN_ONE):
                    imgEastPedestrain1.Source = setBitmapImage;
                    break;
                case (Define.EAST_PEDESTRAIN_TWO):
                    imgEastPedestrain2.Source = setBitmapImage;
                    break;
                case (Define.EAST_TURN_AROUND):
                    imgEastTurn.Source = setBitmapImage1;
                    break;
                case (Define.EAST_OTHER):
                    imgEastOther.Source = setBitmapImage1;
                    break;
                case (Define.EAST_LEFT_STRAIGHT_RIGHT):
                    imgEastNorthOther.Source = setBitmapImage1;
                    break;
                //南方
                case (Define.SOUTH_LEFT):
                    imgSouthLeft.Source = setBitmapImage;
                    break;
                case (Define.SOUTH_STRAIGHT):
                    imgSouthStraight.Source = setBitmapImage;
                    break;
                case (Define.SOUTH_RIGHT):
                    imgSouthRight.Source = setBitmapImage;
                    break;
                case (Define.SOUTH_PEDESTRAIN_ONE):
                    imSouthPedestrain1.Source = setBitmapImage1;
                    break;
                case (Define.SOUTH_PEDESTRAIN_TWO):
                    imSouthPedestrain2.Source = setBitmapImage1;
                    break;
                case (Define.SOUTH_TURN_AROUND):
                    imgSouthTurn.Source = setBitmapImage;
                    break;
                case (Define.SOUTH_OTHER):
                    imgSouthOther.Source = setBitmapImage;
                    break;
                case (Define.SOUTH_LEFT_STRAIGHT_RIGHT):
                    imgEastSouthOther.Source = setBitmapImage;
                    break;
                //西方
                case (Define.WEST_LEFT):
                    imgWestLeft.Source = setBitmapImage1;
                    break;
                case (Define.WEST_STRAIGHT):
                    imgWestStraight.Source = setBitmapImage1;
                    break;
                case (Define.WEST_RIGHT):
                    imgWestRight.Source = setBitmapImage1;
                    break;
                case (Define.WEST_PEDESTRAIN_ONE):
                    imgWestPedestrain1.Source = setBitmapImage;
                    break;
                case (Define.WEST_PEDESTRAIN_TWO):
                    imgWestPedestrain2.Source = setBitmapImage;
                    break;
                case (Define.WEST_TURN_AROUND):
                    imgWestTurn.Source = setBitmapImage1;
                    break;
                case (Define.WEST_OTHER):
                    imgWestOther.Source = setBitmapImage1;
                    break;
                case (Define.WEST_LEFT_STRAIGHT_RIGHT):
                    imgWestSouthOther.Source = setBitmapImage1;
                    break;
            }

        }
        private void dispatcherTimer1_Tick(object sender, EventArgs e)
        {
            List<Channel> lc = tdData.ListChannel;
            List<PhaseToDirec> lptd = tdData.ListPhaseToDirec;
           
            if (ReportTscStatus.resportSuccessFlag)
            {
                this.workmode_label.Content = "工作模式：" + ReportTscStatus.sWorkModel;
                this.controlmode_label.Content = "控制方式：" + ReportTscStatus.sControlModel;
                this.workstatus_label.Content = "工作状态：" + ReportTscStatus.sWorkStatus;
                this.Lbl_RunPlanId.Content = "时基号：" + ReportTscStatus.iPlanId;
                this.Lbl_RunPlanType.Content = "时基类型:" + ((ReportTscStatus.iPlanId > 30) ? "月时基" : ((ReportTscStatus.iPlanId > 20)?"周时基":"特殊月日时基"));
                this.time_NO_label.Content = "方案号：" + ReportTscStatus.iCurrentTimePattern;
                this.run_NO_label.Content = "时段号：" + ReportTscStatus.iCurrentSchedule;
                this.lblCurrentStage.Content = "当前阶段：" + ReportTscStatus.iCurrentStage;
                 this.label_CycleTime.Content = "周期时长： " + ReportTscStatus.iCycleTime;
                 this.label_iCurrentStagePattern.Content = "阶段配时号： " + ReportTscStatus.iCurrentStagePattern;
                 this.label_iStageCount.Content = "阶段总数： " + ReportTscStatus.iStageCount;
                 this.label_iStageTotalTime.Content ="阶段总时长： " + ReportTscStatus.iStageTotalTime;
                 this.label_iStageRunTime.Content = "阶段运行时长： " + ReportTscStatus.iStageRunTime;
                 if (ReportTscStatus.sControlModel.Equals("手动") && rbnManaul.IsChecked == false && rbnSelf.IsChecked != true)
                    rbnManaul.IsChecked = true;
                 if (ReportTscStatus.sWorkStatus.Equals("闪光") && RadLampFlash.IsChecked == false)
                     RadLampFlash.IsChecked = true;
                 else if (ReportTscStatus.sWorkStatus.Equals("全红") && RadLampRed.IsChecked == false)
                     RadLampRed.IsChecked = true;
            List <uint> redList    =   ReportTscStatus.listChannelRedStatus;
            List <uint> yellowList =   ReportTscStatus.listChannelYellowStatus;
            List <uint> greenList  =   ReportTscStatus.listChannelGreenStatus;
            #region 图片刷新
            for (int i = 0; i < redList.Count; i++) //redList.Count == yellowList.Count == greenList.Count
            {
                foreach (Channel c in lc)
                {
                    if ((i+1) == c.ucId)
                    {
                        foreach (PhaseToDirec ptd in lptd)
                        {
                            if (ptd.ucPhase != 0)
                            {
                                if (ptd.ucPhase == c.ucSourcePhase && c.ucType != 0x4)
                                {
                                    if (redList[i] == 1)
                                    {
                                        UpdateLampColor(ptd,Define.LAMP_RED);
                                         break;
                                    }
                                    else if(yellowList[i]==1)
                                    {
                                        UpdateLampColor(ptd, Define.LAMP_YELLOW);
                                        break;
                                    }
                                    else if (greenList[i] == 1)
                                    {
                                        UpdateLampColor(ptd, Define.LAMP_GREEN);
                                        break;
                                    }
                                }
                               /// break;
                            }
                            else
                            {
                                if (ptd.ucOverlapPhase != 0)
                                {
                                    if (ptd.ucOverlapPhase == c.ucSourcePhase && c.ucType==0x4)
                                    {
                                        if(redList[i] == 1)
                                        {
                                           // updateRed(ptd);
                                            UpdateLampColor(ptd, Define.LAMP_RED);
                                             break;
                                        }
                                        else if (yellowList[i] == 1)
                                        {
                                            UpdateLampColor(ptd, Define.LAMP_YELLOW);
                                            break;
                                        }
                                        else if (greenList[i] == 1)
                                        {
                                            UpdateLampColor(ptd, Define.LAMP_GREEN);
                                            break;
                                        }
                                       
                                    }
                                    
                                }
                            }
                           // break;
                        }
                        break;
                    }
                    
                }
                
                //南行左
            
            }
            #endregion

            #region 刷新黄灯绿灯旧代码
                /*
           
            for (int i = 0; i < yellowList.Count; i++)
            {
                foreach (Channel c in lc)
                {
                    if ((i + 1) == c.ucId)
                    {
                        foreach (PhaseToDirec ptd in lptd)
                        {
                            if (ptd.ucPhase != 0)
                            {
                                if (ptd.ucPhase == c.ucSourcePhase && c.ucType != 0x4)
                                {
                                    if (yellowList[i] == 1)
                                    {
                                        // updateYellow(ptd);
                                        UpdateLampColor(ptd, Define.LAMP_YELLOW);

                                        break;
                                    }
                                }
                            }
                            else
                            {
                                if (ptd.ucOverlapPhase != 0)
                                {
                                    if (ptd.ucOverlapPhase == c.ucSourcePhase && c.ucType == 0x4)
                                    {
                                        if (yellowList[i] == 1)
                                        {
                                            // updateYellow(ptd);
                                            UpdateLampColor(ptd, Define.LAMP_YELLOW);

                                              break;
                                        }
                                    }
                                }
                            }
                        }
                         break;
                    }

                }
            }

            #endregion

            #region 绿灯图片刷新
            for (int i = 0; i < greenList.Count; i++)
            {
                foreach (Channel c in lc)
                {
                    if ((i + 1) == c.ucId)
                    {
                        foreach (PhaseToDirec ptd in lptd)
                        {
                            if (ptd.ucPhase != 0)
                            {
                                if (ptd.ucPhase == c.ucSourcePhase && c.ucType != 0x4)
                                {
                                    if (greenList[i] == 1)
                                    {
                                        // updateGreen(ptd);
                                      //  if (i == 3)
                                         //   Console.WriteLine("Green" + i);
                                            UpdateLampColor(ptd, Define.LAMP_GREEN);

                                         break;
                                    }

                                }
                            }
                            else
                            {
                                if (ptd.ucOverlapPhase != 0)
                                {
                                    if (ptd.ucOverlapPhase == c.ucSourcePhase && c.ucType == 0x4)
                                    {
                                        if (greenList[i] == 1)
                                        {
                                            //  updateGreen(ptd);
                                            //if (i == 3)
                                            //    Console.WriteLine("OverGreen" + i);
                                            //Console.WriteLine("OverlapPhase "+i);
                                            UpdateLampColor(ptd, Define.LAMP_GREEN);
                                             break;
                                        }
                                    }
                                }
                            }

                        }
                        break;
                    }

                }

            }
            #endregion
*/
        #endregion

            }
            
           

           
        }
        #endregion
   
        private void lampRush_CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            try
            {
                this.GrpDirecPhase.Visibility = Visibility.Hidden; //隐藏方向相位 信息
                //ReportTscStatus reportTscStatus = new Models.ReportTscStatus();
                TscDataUtils.GetReportStatus();
                LampRhshStar();
            }
            catch(Exception ex)
            {
                MessageBox.Show("刷新当前相位运行状态异常!","相位状态",MessageBoxButton.OK,MessageBoxImage.Exclamation);
            }
            
        }
      
        private void InitPhaseToButtonByDirec()
        {
            if (tdData == null)
                return;
            tdData = Utils.Utils.GetTscDataByApplicationCurrentProperties();

            if (DirecPhaseCombox.Items.Count == 0)//   InitDirecNumber();
            {
                if (dirnum.Count == 0)
                {
                    InitDirecNumber();
                }
                DirecPhaseCombox.ItemsSource = dirnum;
            }

            if (DirectPhaseIdCombox.Items.Count == 0)
            {

                if (lcpo.Count ==0)
                    InitPhaseOverlap();
                DirectPhaseIdCombox.ItemsSource = lcpo;
            }
           
          
        }

      
       
        private delegate void DelegateInitPhaseToButtonByDirec();
        private void DispatcherInitPhaseToButtonByDirec(object state)
        {
            this.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new DelegateInitPhaseToButtonByDirec(InitPhaseToButtonByDirec));
        }
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            tdData = Utils.Utils.GetTscDataByApplicationCurrentProperties();
            if (tdData == null)
            {
                MessageBox.Show((string)App.Current.Resources.MergedDictionaries[3]["msg_log_selected_tsc"]);
                this.Visibility = Visibility.Hidden;
                return;
            }
            this.Visibility = Visibility.Visible;
            ThreadPool.QueueUserWorkItem(DispatcherInitPhaseToButtonByDirec);
        }
    
    
        private void lampRush_CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            
            //if (tdData == null)
            //    tdData = Utils.Utils.GetTscDataByApplicationCurrentProperties();
            this.GrpDirecPhase.Visibility = Visibility.Visible;

            dispatcherTimer1.Stop();
            Udp.sendUdp(tdData.Node.sIpAddress, tdData.Node.iPort, Define.REPORT_TSC_STATUS_CANCEL);
            Udp.Close();
        }


        private void UserControl_Unloaded(object sender, RoutedEventArgs e)
        {
            try
            {
                if(echoCountDownDispatcherTimer != null)
                {
                    echoCountDownDispatcherTimer.Stop();
                }
                if(dispatcherTimer1 != null)
                {
                    dispatcherTimer1.Stop();
                }
                if (cbxEchoCountDown.IsChecked == true)
                {
                    this.cbxEchoCountDown_Unchecked(this,null);
                }
                if (lampRush_CheckBox.IsChecked == true)
                {
                    this.lampRush_CheckBox_Unchecked(this,null);
                }
                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString(), "相位异常", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            
        }

        DispatcherTimer echoCountDownDispatcherTimer;
        private void cbxEchoCountDown_Checked(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("倒计时仅限多时段控制下正确显示,\r\n需在【外设】-【倒计时】开启旧国标四方向!", "倒计时", MessageBoxButton.OK, MessageBoxImage.Warning);

            WestCntDown.Visibility  = Visibility;
            NorthCntDown.Visibility = Visibility;
            SouthCntDown.Visibility = Visibility;
            EastCntDown.Visibility  = Visibility;
            SouthCntDown.Text = "00";
            NorthCntDown.Text = "00";
            EastCntDown.Text  = "00";
            WestCntDown.Text  = "00";
            TscData td = (TscData)Application.Current.Properties[Define.TSC_DATA];
            //EchoCntDowns echoCountDown = new EchoCntDowns();
            Udp.StartReceiveEchoCountDown();
            Udp.sendUdpEchoCountDown(td.Node.sIpAddress, Define.GBT_PORT, Define.ECHO_TSC_COUNT_DOWN);
            
            echoCountDownDispatcherTimer = new DispatcherTimer();
            echoCountDownDispatcherTimer.Tick += new EventHandler(CountDownDispatcherTimer_Tick);
            echoCountDownDispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            echoCountDownDispatcherTimer.Start();

        }
        private void CountDownDispatcherTimer_Tick(object sender, EventArgs e)
        {
            if (EchoCntDowns._listEhoCntDown == null) 
                return;
            foreach(EhoCntDown ecd in EchoCntDowns._listEhoCntDown)
            {
                ecd.usFigure--;

                if(ecd.Direc == 0)
                {
                    if (ecd.Color == 0x01)
                    {
                        NorthCntDown.Foreground = new SolidColorBrush(Colors.Green);
                    }
                    else if (ecd.Color == 0x02)
                    {
                        NorthCntDown.Foreground = new SolidColorBrush(Colors.Yellow);
                    }
                    else if (ecd.Color == 0x03)
                    {
                        NorthCntDown.Foreground = new SolidColorBrush(Colors.Red);
                    }   
                    NorthCntDown.Text = "" + ecd.usFigure;
                    continue;
                }
                if (ecd.Direc == 1)
                {
                    if (ecd.Color == 0x01)
                    {
                        EastCntDown.Foreground = new SolidColorBrush(Colors.Green);
                    }
                    else if (ecd.Color == 0x02)
                    {
                        EastCntDown.Foreground = new SolidColorBrush(Colors.Yellow);
                    }
                    else if (ecd.Color == 0x03)
                    {
                        EastCntDown.Foreground = new SolidColorBrush(Colors.Red);
                    }
                    EastCntDown.Text = "" + ecd.usFigure;
                    continue;
                }
                if (ecd.Direc == 2)
                {
                    if (ecd.Color == 0x01)
                    {
                        SouthCntDown.Foreground = new SolidColorBrush(Colors.Green);
                    }
                    else if (ecd.Color == 0x02)
                    {
                        SouthCntDown.Foreground = new SolidColorBrush(Colors.Yellow);
                    }
                    else if (ecd.Color == 0x03)
                    {
                        SouthCntDown.Foreground = new SolidColorBrush(Colors.Red);
                    }
                    SouthCntDown.Text = "" + ecd.usFigure;
                    continue;
                }
                if (ecd.Direc == 3)
                {
                    if (ecd.Color == 0x01)
                    {
                        WestCntDown.Foreground = new SolidColorBrush(Colors.Green);
                    }
                    else if (ecd.Color == 0x02)
                    {
                        WestCntDown.Foreground = new SolidColorBrush(Colors.Yellow);
                    }
                    else if (ecd.Color == 0x03)
                    {
                        WestCntDown.Foreground = new SolidColorBrush(Colors.Red);
                    }
                    WestCntDown.Text = "" + ecd.usFigure;
                    continue;
                }
            }
            
        }

        private void cbxEchoCountDown_Unchecked(object sender, RoutedEventArgs e)
        {
            
            if (tdData == null)
                tdData = Utils.Utils.GetTscDataByApplicationCurrentProperties();
            Udp.sendUdp(tdData.Node.sIpAddress, tdData.Node.iPort, Define.ECHO_TSC_COUNT_DOWN_CANCEL);
            echoCountDownDispatcherTimer.Stop();        
            WestCntDown.Visibility = Visibility.Hidden;
            NorthCntDown.Visibility = Visibility.Hidden;
            SouthCntDown.Visibility = Visibility.Hidden;
            EastCntDown.Visibility = Visibility.Hidden;
        }

        private void rbnManaul_Checked(object sender, RoutedEventArgs e)
        {
         
            if (ReportTscStatus.sControlModel.Equals("手动"))
            {
                RadLampFlash.IsEnabled = true;
                RadLampRed.IsEnabled = true;
            //    RadLampOff.IsEnabled = true;
                btnNextStep.IsEnabled = true;
                btnNextPhase.IsEnabled = true;
                btnEast.IsEnabled = true;
                btnNorth.IsEnabled = true;
                btnSouth.IsEnabled = true;
                btnWest.IsEnabled = true;
                return;

            }
            bool bok = TscDataUtils.SetCtrlMunual();
            if (bok)
            {
                RadLampFlash.IsEnabled = true;
                RadLampRed.IsEnabled = true;
               // RadLampOff.IsEnabled = true;
                btnNextStep.IsEnabled = true;
                btnNextPhase.IsEnabled = true;
                btnEast.IsEnabled = true;
                btnNorth.IsEnabled = true;
                btnSouth.IsEnabled = true;
                btnWest.IsEnabled = true;
                MessageBox.Show("手动控制命令发送成功!", "手动控制", MessageBoxButton.OK, MessageBoxImage.Information);

            }
            else
            {
                MessageBox.Show("手动控制命令发送失败!", "手动控制", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
        }
        private void rbnSelf_Checked(object sender, RoutedEventArgs e)
        {
          
            if (!ReportTscStatus.sControlModel.Equals("手动"))
            {
                MessageBox.Show("当前非手动控制!", "手动控制", MessageBoxButton.OK, MessageBoxImage.Error);
                return;

            }
            bool bok = TscDataUtils.SetCtrlSelf();
            if (bok)
            {
                RadLampFlash.IsEnabled = false;
                RadLampRed.IsEnabled = false;
                btnNextStep.IsEnabled = false;
                btnNextPhase.IsEnabled = false;
                btnEast.IsEnabled = false;
                btnNorth.IsEnabled = false;
                btnSouth.IsEnabled = false;
                btnWest.IsEnabled = false;
                MessageBox.Show("自主控制指令发送成功!","自主控制",MessageBoxButton.OK,MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("自动控制指令发送失败!", "自主控制", MessageBoxButton.OK, MessageBoxImage.Error);
            }
          
        }

        private void btnNextStep_Click(object sender, RoutedEventArgs e)
        {
            Message msg = TscDataUtils.SetNextStep();
        }
        
        private void btnNextPhase_Click(object sender, RoutedEventArgs e)
        {
            Message msg = TscDataUtils.SetNextPhase();
        }

        private void btnNorth_Click(object sender, RoutedEventArgs e)
        {
            btnNextStep.IsEnabled = false;
            btnNextPhase.IsEnabled = false;
            Message msg = TscDataUtils.SetCtrlNorth();
        }

        private void btnEast_Click(object sender, RoutedEventArgs e)
        {
            btnNextStep.IsEnabled = false;
            btnNextPhase.IsEnabled = false;
            Message msg = TscDataUtils.SetCtrlEast();
        }

        private void btnSouth_Click(object sender, RoutedEventArgs e)
        {
            btnNextStep.IsEnabled = false;
            btnNextPhase.IsEnabled = false;
            Message msg = TscDataUtils.SetCtrlSouth();
        }

        private void btnWest_Click(object sender, RoutedEventArgs e)
        {
            btnNextStep.IsEnabled = false;
            btnNextPhase.IsEnabled = false;
            Message msg = TscDataUtils.SetCtrlWest();
        }

        private void DirecPhaseCombox_SelectChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                tdData = Utils.Utils.GetTscDataByApplicationCurrentProperties();
                if (tdData == null)
                {
                    return;
                }
                opchannels.Content = "";
                roadcount.Content = "";
                DirectPhaseIdCombox.SelectedIndex = -1;
                List<PhaseToDirec> tscdirecphase = tdData.ListPhaseToDirec;

                foreach (PhaseToDirec direcphase in tscdirecphase)
                {
                    if (DirecPhaseCombox.SelectedIndex == -1)
                        return;
                    if (direcphase.ucId == ((DirecNumer)(DirecPhaseCombox.SelectedValue)).value)
                    {
                        roadcount.Content = direcphase.ucRoadCnt.ToString();
                        foreach (ChannelPhaseOverlap cpo in lcpo)
                        {
                            if (cpo.id == direcphase.ucPhase && cpo.isPhase == true && direcphase.ucOverlapPhase == 0)
                            {
                                DirectPhaseIdCombox.SelectedIndex = cpo.id - 1;
                                break;
                            }
                            else if (cpo.id == direcphase.ucOverlapPhase && cpo.isPhase == false && direcphase.ucPhase == 0)
                            {
                                DirectPhaseIdCombox.SelectedIndex = cpo.id + 0x20 - 1;
                                break;
                            }

                        }
                        foreach (Channel ch in tdData.ListChannel)
                        {
                            byte phaseid = ((ChannelPhaseOverlap) (DirectPhaseIdCombox.SelectedValue)).id;
                            bool bisphase =((ChannelPhaseOverlap) (DirectPhaseIdCombox.SelectedValue)).isPhase;
                            if (phaseid == ch.ucSourcePhase)
                            {
                                if ((bisphase == true && ch.ucType != 0x4) || (bisphase == false && ch.ucType == 0x4))
                                {
                                    opchannels.Content += ch.ucId.ToString() + " ,";
                                    if (ch.ucType == 0x4)
                                    {
                                        opchannels.Background = Brushes.Yellow;
                                    }
                                    else if (ch.ucType == 0x3)
                                    {
                                        opchannels.Background = Brushes.Green;
                                    }
                                    else
                                    {
                                        opchannels.Background = Brushes.Red;
                                    }
                                }
                            }
                        }
                        break;
                    }
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show("获取方向相关参数异常!","相位状态",MessageBoxButton.OK,MessageBoxImage.Exclamation);
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            switch (rotate%4)
            {
                case 0:
                    TrafficCanvas.RenderTransform = new RotateTransform(90);
                    EastCntDown.RenderTransform = new RotateTransform(-90);
                    WestCntDown.RenderTransform = new RotateTransform(-90);
                    NorthCntDown.RenderTransform = new RotateTransform(-90);
                    SouthCntDown.RenderTransform = new RotateTransform(-90);
                    rotate++;
                    break;
                case 1:
                    TrafficCanvas.RenderTransform = new RotateTransform(180);
                    EastCntDown.RenderTransform = new RotateTransform(-180);
                    WestCntDown.RenderTransform = new RotateTransform(-180);
                    NorthCntDown.RenderTransform = new RotateTransform(-180);
                    SouthCntDown.RenderTransform = new RotateTransform(-180);
                    rotate++;
                    break;
                case 2:
                    TrafficCanvas.RenderTransform = new RotateTransform(270);
                    EastCntDown.RenderTransform = new RotateTransform(-270);
                    WestCntDown.RenderTransform = new RotateTransform(-270);
                    NorthCntDown.RenderTransform = new RotateTransform(-270);
                    SouthCntDown.RenderTransform = new RotateTransform(-270);
                    rotate++;
                    break;
                case 3:
                    TrafficCanvas.RenderTransform = new RotateTransform(360);
                    EastCntDown.RenderTransform = new RotateTransform(-360);
                    WestCntDown.RenderTransform = new RotateTransform(-360);
                    NorthCntDown.RenderTransform = new RotateTransform(-360);
                    SouthCntDown.RenderTransform = new RotateTransform(-360);
                    rotate++;
                    break;
                default:
                    TrafficCanvas.RenderTransform = new RotateTransform(0);
                    break;
            }
           
          
        }

        private void LampFlashCheck(object sender, RoutedEventArgs e)
        {

            if (ReportTscStatus.sWorkStatus.Equals("闪光"))
            {
                btnNextStep.IsEnabled = false;
                btnNextPhase.IsEnabled = false;
                btnNorth.IsEnabled = false;
                btnEast.IsEnabled = false;
                btnSouth.IsEnabled = false;
                btnWest.IsEnabled = false;
                return;
            }
         
            bool bok = TscDataUtils.SetFlash();
            if (bok)
            {
                btnNextStep.IsEnabled = false;
                btnNextPhase.IsEnabled = false;
                btnNorth.IsEnabled = false;
                btnEast.IsEnabled = false;
                btnSouth.IsEnabled = false;
                btnWest.IsEnabled = false;
                MessageBox.Show("黄闪命令发送成功!", "手控", MessageBoxButton.OK, MessageBoxImage.Information);

            }
            else
            {
                MessageBox.Show("黄闪命令发送失败!", "手控", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void LampRedCheck(object sender, RoutedEventArgs e)
        {
            if (ReportTscStatus.sWorkStatus.Equals("全红"))
            {
                btnNextStep.IsEnabled = false;
                btnNextPhase.IsEnabled = false;
                btnNorth.IsEnabled = false;
                btnEast.IsEnabled = false;
                btnSouth.IsEnabled = false;
                btnWest.IsEnabled = false;
                return;
            }
            bool bok = TscDataUtils.SetRed();
            if (bok)
            {
                btnNextStep.IsEnabled = false;
                btnNextPhase.IsEnabled = false;
                btnNorth.IsEnabled = false;
                btnEast.IsEnabled = false;
                btnSouth.IsEnabled = false;
                btnWest.IsEnabled = false;
                MessageBox.Show("全红命令发送成功!", "手控", MessageBoxButton.OK, MessageBoxImage.Information);

            }
            else
            {
                MessageBox.Show("全红命令发送失败!", "手控", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        //private void LampOffCheck(object sender, RoutedEventArgs e)
        //{
        //    bool bok = TscDataUtils.SetOff();
        //    if (bok)
        //    {
        //        MessageBox.Show("熄灯指令发送成功!");
        //        btnNextStep.IsEnabled = false;
        //        btnNextPhase.IsEnabled = false;
        //    }
        //    else
        //    {
        //        MessageBox.Show("熄灯指令发送失败!");

        //    }
        //}


    }
}
