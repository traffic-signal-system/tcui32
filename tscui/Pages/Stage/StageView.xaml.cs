using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Media;
using Apex.MVVM;
using Apex.Behaviours;
using System.Windows;
using System.Windows.Media.Imaging;
using tscui.Models;
using tscui.Service;
using System.Windows.Threading;

namespace tscui.Pages.Stage
{
    /// <summary>
    /// Interaction logic for StageView.xaml
    /// </summary>
    [View(typeof(StageViewModel))]
    public partial class StageView : UserControl,IView
    {
        public static List<StageItem> lsi = new List<StageItem>();
        public delegate void InitStageItemToLSI();
        public delegate void DelegateInitcbxCoordination();
        public delegate void DelegateInitStageNumber();

        public byte CopyedstageId;
        TscData td;
        private void initStageItemList()
        {
                lsi.Add(stage1);
                lsi.Add(stage2);
                lsi.Add(stage3);
                lsi.Add(stage4);
                lsi.Add(stage5);
                lsi.Add(stage6);
                lsi.Add(stage7);
                lsi.Add(stage8);
                lsi.Add(stage9);
                lsi.Add(stage10);
                lsi.Add(stage11);
                lsi.Add(stage12);
                lsi.Add(stage13);
                lsi.Add(stage14);
                lsi.Add(stage15);
                lsi.Add(stage16);
            
                return;
          
        }
        public static StageItem currentStage ;
        public StageView()
        {
            td=  Utils.Utils.GetTscDataByApplicationCurrentProperties();
            InitializeComponent();
            this.Stageviewcanvas.AddHandler(Image.MouseLeftButtonDownEvent, new RoutedEventHandler(StageImageMouseLeftButton_Down));
            this.Stageviewcanvas.AddHandler(Image.MouseRightButtonDownEvent, new RoutedEventHandler(StageImageMouseRightButton_Down));


        }

        private void StageImageMouseRightButton_Down(object sender, RoutedEventArgs e)
        {
            try
            {
                
                if (e.OriginalSource != null)
                {
                    Image ClickImage = e.OriginalSource as Image;
                    if (ClickImage != null )
                    {
                        if (currentStage != null)
                        {
                            List<StagePattern> lsp = td.ListStagePattern;
                            List<PhaseToDirec> lptd = td.ListPhaseToDirec;
                            Byte DirecNumber = 0xff;
                            string DirecName = ClickImage.Name;

                            BitmapImage imageredlight = new BitmapImage(new Uri("/tscui;component/Resources/Images/redlight.png", UriKind.Relative));
                            BitmapImage imageredlight1 = new BitmapImage(new Uri("/tscui;component/Resources/Images/redlight1.png", UriKind.Relative));

                            switch (DirecName)
                            {
                                case "northLeft":
                                    currentStage.northLeft.Source = imageredlight;
                                    northLeft.Source = imageredlight;
                                    DirecNumber = Define.NORTH_LEFT;
                                    break;
                                case "northStraight":
                                    currentStage.northStraight.Source = imageredlight;
                                    northStraight.Source = imageredlight;
                                    DirecNumber = Define.NORTH_STRAIGHT;
                                    break;
                                case "northRight":
                                    currentStage.northRight.Source = imageredlight;
                                    northRight.Source = imageredlight;
                                    DirecNumber = Define.NORTH_RIGHT;
                                    break;
                                case "northPedestrain1":
                                    currentStage.northPedestrain1.Source = imageredlight1;
                                    northPedestrain1.Source = imageredlight1;
                                    DirecNumber = Define.NORTH_PEDESTRAIN_ONE;
                                    break;
                                case "northPedestrain2":
                                    currentStage.northPedestrain2.Source = imageredlight1;
                                    northPedestrain2.Source = imageredlight1;
                                    DirecNumber = Define.NORTH_PEDESTRAIN_TWO;
                                    break;
                                case "northTurn":
                                    currentStage.northTurn.Source = imageredlight;
                                    northTurn.Source = imageredlight;
                                    DirecNumber = Define.NORTH_TURN_AROUND;

                                    //MessageBox.Show("NorthTurn");
                                    break;
                                case "northOther":
                                    currentStage.northOther.Source = imageredlight;
                                    northOther.Source = imageredlight;
                                    DirecNumber = Define.NORTH_OTHER;
                                    break;
                                case "WestNorthOther":
                                    currentStage.westNorthOther.Source = imageredlight;
                                    WestNorthOther.Source = imageredlight;
                                    DirecNumber = Define.NORTH_LEFT_STRAIGHT_RIGHT;
                                    break;

                                case "eastLeft":
                                    currentStage.eastLeft.Source = imageredlight1;
                                    eastLeft.Source = imageredlight1;
                                    DirecNumber = Define.EAST_LEFT;
                                    break;
                                case "eastStraight":
                                    currentStage.eastStraight.Source = imageredlight1;
                                    eastStraight.Source = imageredlight1;
                                    DirecNumber = Define.EAST_STRAIGHT;
                                    break;
                                case "eastRight":
                                    currentStage.eastRight.Source = imageredlight1;
                                    eastRight.Source = imageredlight1;
                                    DirecNumber = Define.EAST_RIGHT;
                                    break;
                                case "eastPedestrain1":
                                    currentStage.eastPedestrain1.Source = imageredlight;
                                    eastPedestrain1.Source = imageredlight;
                                    DirecNumber = Define.EAST_PEDESTRAIN_ONE;
                                    break;
                                case "eastPedestrain2":
                                    currentStage.eastPedestrain2.Source = imageredlight;
                                    eastPedestrain2.Source = imageredlight;
                                    DirecNumber = Define.EAST_PEDESTRAIN_TWO;
                                    break;
                                case "eastTurn":
                                    currentStage.eastTurn.Source = imageredlight1;
                                    eastTurn.Source = imageredlight1;
                                    DirecNumber = Define.EAST_TURN_AROUND;
                                    break;
                                case "eastOther":
                                    currentStage.eastOther.Source = imageredlight1;
                                    eastOther.Source = imageredlight1;
                                    DirecNumber = Define.EAST_OTHER;
                                    break;
                                case "eastNorthOther":
                                    currentStage.eastNorthOther.Source = imageredlight1;
                                    eastNorthOther.Source = imageredlight1;
                                    DirecNumber = Define.EAST_LEFT_STRAIGHT_RIGHT;
                                    break;
                                //南
                                case "southLeft":
                                    currentStage.southLeft.Source = imageredlight;
                                    southLeft.Source = imageredlight;
                                    DirecNumber = Define.SOUTH_LEFT;
                                    break;
                                case "southStraight":
                                    currentStage.southStraight.Source = imageredlight;
                                    southStraight.Source = imageredlight;
                                    DirecNumber = Define.SOUTH_STRAIGHT;
                                    break;
                                case "southRight":
                                    currentStage.southRight.Source = imageredlight;
                                    southRight.Source = imageredlight;
                                    DirecNumber = Define.SOUTH_RIGHT;
                                    break;
                                case "southPedestrain1":
                                    currentStage.southPedestrain1.Source = imageredlight1;
                                    southPedestrain1.Source = imageredlight1;
                                    DirecNumber = Define.SOUTH_PEDESTRAIN_ONE;
                                    break;
                                case "southPedestrain2":
                                    currentStage.southPedestrain2.Source = imageredlight1;
                                    southPedestrain2.Source = imageredlight1;
                                    DirecNumber = Define.SOUTH_PEDESTRAIN_TWO;
                                    break;
                                case "southTurn":
                                    currentStage.southTurn.Source = imageredlight;
                                    southTurn.Source = imageredlight;
                                    // southTurn.Visibility = Visibility.Hidden;
                                    DirecNumber = Define.SOUTH_TURN_AROUND;
                                    // Xceed.Wpf.Toolkit.MessageBox.Show("南调头");
                                    break;
                                case "southOther":
                                    currentStage.southOther.Source = imageredlight;
                                    southOther.Source = imageredlight;
                                    DirecNumber = Define.SOUTH_OTHER;
                                    // Xceed.Wpf.Toolkit.MessageBox.Show("南其他");
                                    break;
                                case "eastSouthOther":
                                    currentStage.eastSouthOther.Source = imageredlight;
                                    eastSouthOther.Source = imageredlight;
                                    DirecNumber = Define.SOUTH_LEFT_STRAIGHT_RIGHT;
                                    break;
                                //西
                                case "westLeft":
                                    currentStage.westLeft.Source = imageredlight1;
                                    westLeft.Source = imageredlight1;
                                    DirecNumber = Define.WEST_LEFT;
                                    break;
                                case "westStraight":
                                    currentStage.westStraight.Source = imageredlight1;
                                    westStraight.Source = imageredlight1;
                                    DirecNumber = Define.WEST_STRAIGHT;
                                    break;
                                case "westRight":
                                    currentStage.westRight.Source = imageredlight1;
                                    westRight.Source = imageredlight1;
                                    DirecNumber = Define.WEST_RIGHT;
                                    break;
                                case "westPedestrain1":
                                    currentStage.westPedestrain1.Source = imageredlight;
                                    westPedestrain1.Source = imageredlight;
                                    DirecNumber = Define.WEST_PEDESTRAIN_ONE;
                                    break;
                                case "westPedestrain2":
                                    currentStage.westPedestrain2.Source = imageredlight;
                                    westPedestrain2.Source = imageredlight;
                                    DirecNumber = Define.WEST_PEDESTRAIN_TWO;
                                    break;
                                case "westTurn":
                                    currentStage.westTurn.Source = imageredlight1;
                                    westTurn.Source = imageredlight1;
                                    DirecNumber = Define.WEST_TURN_AROUND;
                                    break;
                                case "westOther":
                                    currentStage.westOther.Source = imageredlight1;
                                    westOther.Source = imageredlight1;
                                    DirecNumber = Define.WEST_OTHER;
                                    break;
                                case "westSouthOther":
                                    currentStage.westSouthOther.Source = imageredlight1;
                                    westSouthOther.Source = imageredlight1;
                                    DirecNumber = Define.WEST_LEFT_STRAIGHT_RIGHT;
                                    break;
                                default:
                                    return;

                            }
                            foreach (StagePattern sp in lsp)
                            {
                                if (sp.ucStagePatternId == ((byte)sldStagePatternId.Value))
                                {
                                    if (Convert.ToByte(currentStage.lblNumber.Content) == sp.ucStageNo)
                                    {
                                        uint ap = sp.usAllowPhase;

                                        foreach (PhaseToDirec ptd in lptd)
                                        {
                                            if (ptd.ucId == DirecNumber)
                                            {
                                                sp.usAllowPhase = returnUnAllowPhase(ptd, ap);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show((string)App.Current.Resources.MergedDictionaries[3]["msg_stage_selected_stage"], "阶段配时", MessageBoxButton.OK, MessageBoxImage.Information);

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("取消方向相位放行异常!", "阶段配时", MessageBoxButton.OK, MessageBoxImage.Exclamation);

            }
        }

        private void StageImageMouseLeftButton_Down(object sender, RoutedEventArgs e)
        {
            try
            {
                
                if (e.OriginalSource != null)
                {
                    Image ClickImage = e.OriginalSource as Image;
                    if (ClickImage != null)
                    {
                        if (currentStage != null)
                         {
                             List<PhaseToDirec> lptd = td.ListPhaseToDirec;
                             List<Pattern> lp = td.ListPattern;
                             List<StagePattern> lsp = td.ListStagePattern;
                             Byte DirecNumber = 0xff;
                             string DirecName = ClickImage.Name;
                             BitmapImage imaggreenlight = new BitmapImage(new Uri("/tscui;component/Resources/Images/greenlight.png", UriKind.Relative));
                             BitmapImage imagegreenlight1 = new BitmapImage(new Uri("/tscui;component/Resources/Images/greenlight1.png", UriKind.Relative));
                             switch (DirecName)
                             {
                                 case "northLeft" :
                                      currentStage.northLeft.Source = imaggreenlight;
                                      northLeft.Source = imaggreenlight;
                                      DirecNumber = Define.NORTH_LEFT;
                                     break;
                                 case  "northStraight":
                                     currentStage.northStraight.Source = imaggreenlight;
                                     northStraight.Source = imaggreenlight;
                                     DirecNumber = Define.NORTH_STRAIGHT;
                                     break;
                                 case "northRight":
                                     currentStage.northRight.Source = imaggreenlight;
                                     northRight.Source = imaggreenlight;
                                     DirecNumber = Define.NORTH_RIGHT;
                                     break;
                                 case "northPedestrain1" :
                                     currentStage.northPedestrain1.Source = imagegreenlight1;
                                     northPedestrain1.Source = imagegreenlight1;
                                     DirecNumber = Define.NORTH_PEDESTRAIN_ONE;
                                     break;
                                 case "northPedestrain2":
                                     currentStage.northPedestrain2.Source = imagegreenlight1;
                                     northPedestrain2.Source = imagegreenlight1;
                                     DirecNumber = Define.NORTH_PEDESTRAIN_TWO;
                                     break;
                                 case "northTurn":
                                     currentStage.northTurn.Source = imaggreenlight;
                                     northTurn.Source = imaggreenlight;
                                     DirecNumber = Define.NORTH_TURN_AROUND;
                                     break;
                                 case "northOther":
                                     currentStage.northOther.Source = imaggreenlight;
                                     northOther.Source = imaggreenlight;
                                     DirecNumber = Define.NORTH_OTHER;
                                     break;
                                 case "WestNorthOther":
                                     currentStage.westNorthOther.Source = imaggreenlight;
                                     WestNorthOther.Source = imaggreenlight;
                                     DirecNumber = Define.NORTH_LEFT_STRAIGHT_RIGHT;
                                     break;

                                 case "eastLeft":
                                     currentStage.eastLeft.Source = imagegreenlight1;
                                     eastLeft.Source = imagegreenlight1;
                                     DirecNumber = Define.EAST_LEFT;
                                     break;
                                 case "eastStraight":
                                     currentStage.eastStraight.Source = imagegreenlight1;
                                     eastStraight.Source = imagegreenlight1;
                                     DirecNumber = Define.EAST_STRAIGHT;
                                     break;
                                 case "eastRight":
                                     currentStage.eastRight.Source = imagegreenlight1;
                                     eastRight.Source = imagegreenlight1;
                                     DirecNumber = Define.EAST_RIGHT;
                                     break;
                                 case "eastPedestrain1":
                                     currentStage.eastPedestrain1.Source = imaggreenlight;
                                     eastPedestrain1.Source = imaggreenlight;
                                     DirecNumber = Define.EAST_PEDESTRAIN_ONE;
                                     break;
                                 case "eastPedestrain2":
                                     currentStage.eastPedestrain2.Source = imaggreenlight;
                                     eastPedestrain2.Source = imaggreenlight;
                                     DirecNumber = Define.EAST_PEDESTRAIN_TWO;
                                     break;
                                 case "eastTurn":
                                     currentStage.eastTurn.Source = imagegreenlight1;
                                     eastTurn.Source = imagegreenlight1;
                                     DirecNumber = Define.EAST_TURN_AROUND;
                                     break;
                                 case "eastOther":
                                     currentStage.eastOther.Source = imagegreenlight1;
                                     eastOther.Source = imagegreenlight1;
                                     DirecNumber = Define.EAST_OTHER;
                                     break;
                                 case "eastNorthOther":
                                     currentStage.eastNorthOther.Source = imagegreenlight1;
                                     eastNorthOther.Source = imagegreenlight1;
                                     DirecNumber = Define.EAST_LEFT_STRAIGHT_RIGHT;
                                     break;
                                 //南
                                 case "southLeft":
                                     currentStage.southLeft.Source = imaggreenlight;
                                     southLeft.Source = imaggreenlight;
                                     DirecNumber = Define.SOUTH_LEFT;
                                     break;
                                 case "southStraight":
                                     currentStage.southStraight.Source = imaggreenlight;
                                     southStraight.Source = imaggreenlight;
                                     DirecNumber = Define.SOUTH_STRAIGHT;
                                     break;
                                 case "southRight":
                                     currentStage.southRight.Source = imaggreenlight;
                                     southRight.Source = imaggreenlight;
                                     DirecNumber = Define.SOUTH_RIGHT;
                                     break;
                                 case "southPedestrain1":
                                     currentStage.southPedestrain1.Source = imagegreenlight1;
                                     southPedestrain1.Source = imagegreenlight1;
                                     DirecNumber = Define.SOUTH_PEDESTRAIN_ONE;
                                     break;
                                 case "southPedestrain2":
                                     currentStage.southPedestrain2.Source = imagegreenlight1;
                                     southPedestrain2.Source = imagegreenlight1;
                                     DirecNumber = Define.SOUTH_PEDESTRAIN_TWO;
                                     break;
                                 case "southTurn":
                                     currentStage.southTurn.Source = imaggreenlight;
                                     southTurn.Source = imaggreenlight;
                                    // southTurn.Visibility = Visibility.Hidden;
                                     DirecNumber = Define.SOUTH_TURN_AROUND;
                                    // Xceed.Wpf.Toolkit.MessageBox.Show("南调头");
                                     break;
                                 case "southOther":
                                     currentStage.southOther.Source = imaggreenlight;
                                     southOther.Source = imaggreenlight;
                                     DirecNumber = Define.SOUTH_OTHER;
                                    // Xceed.Wpf.Toolkit.MessageBox.Show("南其他");
                                     break;
                                 case "eastSouthOther":
                                     currentStage.eastSouthOther.Source = imaggreenlight;
                                     eastSouthOther.Source = imaggreenlight;
                                     DirecNumber = Define.SOUTH_LEFT_STRAIGHT_RIGHT;
                                     break;
                                 //西
                                 case "westLeft":
                                     currentStage.westLeft.Source = imagegreenlight1;
                                     westLeft.Source = imagegreenlight1;
                                     DirecNumber = Define.WEST_LEFT;
                                     break;
                                 case "westStraight":
                                     currentStage.westStraight.Source = imagegreenlight1;
                                     westStraight.Source = imagegreenlight1;
                                     DirecNumber = Define.WEST_STRAIGHT;
                                     break;
                                 case "westRight":
                                     currentStage.westRight.Source = imagegreenlight1;
                                     westRight.Source = imagegreenlight1;
                                     DirecNumber = Define.WEST_RIGHT;
                                     break;
                                 case "westPedestrain1":
                                     currentStage.westPedestrain1.Source = imaggreenlight;
                                     westPedestrain1.Source = imaggreenlight;
                                     DirecNumber = Define.WEST_PEDESTRAIN_ONE;
                                     break;
                                 case "westPedestrain2":
                                     currentStage.westPedestrain2.Source = imaggreenlight;
                                     westPedestrain2.Source = imaggreenlight;
                                     DirecNumber = Define.WEST_PEDESTRAIN_TWO;
                                     break;
                                 case "westTurn":
                                     currentStage.westTurn.Source = imagegreenlight1;
                                     westTurn.Source = imagegreenlight1;
                                     DirecNumber = Define.WEST_TURN_AROUND;
                                     break;
                                 case "westOther":
                                     currentStage.westOther.Source = imagegreenlight1;
                                     westOther.Source = imagegreenlight1;
                                     DirecNumber = Define.WEST_OTHER;
                                     break;
                                 case "westSouthOther":
                                     currentStage.westSouthOther.Source = imagegreenlight1;
                                     westSouthOther.Source = imagegreenlight1;
                                     DirecNumber = Define.WEST_LEFT_STRAIGHT_RIGHT;
                                     break;
                                 default:
                                     return;

                             }
                             foreach (PhaseToDirec ptd in lptd)
                             {
                                 if (ptd.ucId == DirecNumber)
                                 {
                                     if (ptd.ucPhase != 0)
                                     {
                                         setPatternAndStagePattern(lp, lsp, currentStage, ptd);
                                         break;

                                     }
                                 }
                             }
                        }
                    else
                    {
                       MessageBox.Show((string)App.Current.Resources.MergedDictionaries[3]["msg_stage_selected_stage"], "阶段配时", MessageBoxButton.OK, MessageBoxImage.Information);

                    }
                  }
                    e.Handled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("选择方向相位放行异常!", "阶段配时", MessageBoxButton.OK, MessageBoxImage.Exclamation);

            }
        }
        
        public void OnActivated()
        {
            //throw new NotImplementedException();
            SlideFadeInBehaviour.DoSlideFadeIn(this);
        }

        public void OnDeactivated()
        {
            //throw new NotImplementedException();
        }
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            td = Utils.Utils.GetTscDataByApplicationCurrentProperties();
            if (td == null)
            {
                this.Visibility = Visibility.Hidden;
                return;
            }
            this.Visibility = Visibility.Visible;
            //初始化当前阶段
            currentStage = stage1;
            DispatcherInitStageNum();
            DispatcherInitStageItem();
            DispatcherInitCoordination();
            //初始化所有数据到界面上
         //   initStageAttriable(t);
          
           

        }
        private void UserControl_Unloaded(object sender, RoutedEventArgs e)
        {
            lsi.Clear();
        }
        public void BigMap4SmallMap(StageItem si)
        {
            try
            {
                //北方向
                this.northLeft.Source = si.northLeft.Source;
                this.northStraight.Source = si.northStraight.Source;
                this.northRight.Source = si.northRight.Source;
                this.northOther.Source = si.northOther.Source;
                this.northPedestrain1.Source = si.northPedestrain1.Source;
                this.northPedestrain2.Source = si.northPedestrain2.Source;
                this.northTurn.Source = si.northTurn.Source;
                this.WestNorthOther.Source = si.westNorthOther.Source;
                //南方向
                this.southLeft.Source = si.southLeft.Source;
                this.southStraight.Source = si.southStraight.Source;
                this.southRight.Source = si.southRight.Source;
                this.southOther.Source = si.southOther.Source;
                this.southPedestrain1.Source = si.southPedestrain1.Source;
                this.southPedestrain2.Source = si.southPedestrain2.Source;
                this.southTurn.Source = si.southTurn.Source;
                this.eastSouthOther.Source = si.eastSouthOther.Source;

                //东方向
                this.eastLeft.Source = si.eastLeft.Source;
                this.eastStraight.Source = si.eastStraight.Source;
                this.eastRight.Source = si.eastRight.Source;
                this.eastOther.Source = si.eastOther.Source;
                this.eastPedestrain1.Source = si.eastPedestrain1.Source;
                this.eastPedestrain2.Source = si.eastPedestrain2.Source;
                this.eastTurn.Source = si.eastTurn.Source;
                this.eastNorthOther.Source = si.eastNorthOther.Source;

                //西方向
                this.westLeft.Source = si.westLeft.Source;
                this.westStraight.Source = si.westStraight.Source;
                this.westRight.Source = si.westRight.Source;
                this.westOther.Source = si.westOther.Source;
                this.westPedestrain1.Source = si.westPedestrain1.Source;
                this.westPedestrain2.Source = si.westPedestrain2.Source;
                this.westTurn.Source = si.westTurn.Source;
                this.westSouthOther.Source = si.westSouthOther.Source;
            }
            catch (Exception ex)
            {

                MessageBox.Show("右边小图转左边大图异常!", "阶段配时", MessageBoxButton.OK, MessageBoxImage.Exclamation);

            }

        }



        /// <summary>
        /// 通过点击小图，可以将数据更新给
        /// 周期
        /// 相位差
        /// 协调相位
        /// 感应
        /// 红灯时间
        /// 绿灯时间
        /// 黄灯时间
        /// </summary>
        /// <param name="currentStage"></param>
        private void smallMap4Form(StageItem currentStage)
        {
            try
            {
                TscData t = Utils.Utils.GetTscDataByApplicationCurrentProperties();
                List<Pattern> lp = t.ListPattern;
                if (t.ListStagePattern.Count == 0)
                {
                    StagePattern newStagePattern = new StagePattern();
                    newStagePattern.ucStagePatternId = Convert.ToByte(sldStagePatternId.Value);
                    newStagePattern.ucStageNo = 1;
                    newStagePattern.ucGreenTime = 10;
                    newStagePattern.ucYellowTime = 3;
                    newStagePattern.ucRedTime = 0;
                    newStagePattern.usAllowPhase = 0;
                    newStagePattern.ucOption = 1;
                    t.ListStagePattern.Add(newStagePattern);
                }
                List<StagePattern> lsp = t.ListStagePattern;

                foreach (Pattern p in lp)
                {
                    if (sldSchemeId.Value == p.ucPatternId)
                    {
                        if (p.ucStagePatternId == (byte)(sldStagePatternId.Value))
                        {
                            tbxCycle.Text = p.ucCycleTime.ToString();
                            tbxOffset.Text = p.ucOffset.ToString();
                            cbxCoordination.SelectedItem = p.ucCoorPhase;
                            cbxReaction.IsChecked = false;
                        }
                        foreach (StagePattern sp in lsp)
                        {

                            if (sp.ucStagePatternId == Convert.ToByte(sldStagePatternId.Value) && sp.ucStageNo == Convert.ToByte(currentStage.lblNumber.Content.ToString()))
                            {
                                sldGreenTime.Value = sp.ucGreenTime;
                                sldYellowTime.Value = sp.ucYellowTime;
                                sldRedTime.Value = sp.ucRedTime;
                                ChkIgnoreStage.IsChecked = (sp.ucOption & 0x2) ==0x2 ? true : false;
                                break;
                                }
                        }
                    }


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("获取阶段" + currentStage.lblNumber + "信息异常!", "阶段配时", MessageBoxButton.OK, MessageBoxImage.Exclamation);

            }


        }
       
        private uint returnUnAllowPhase(PhaseToDirec  ptd, uint ap)
        {
            uint temp = 1;
            uint c = (~(temp << (ptd.ucPhase - 1))) & ap;
            //ap = c;
            return c;
        }
        /// <summary>
        /// /返回当前 checkbox是否被选中
        /// 选中：  表示为感应阶段，0x00
        /// 不选中：表示不是感应阶段，0x01
        /// </summary>
        /// <returns></returns>
        public byte returnReactionTrueOrFalse()
        {
            if (cbxReaction.IsChecked == true)
            {
                return 0x00;
            }
            else
            {
                return 0x01;
            }
        }
        /// <summary>
        /// 将allowPhase 通过左移 phase -1 位。
        /// </summary>
        /// <param name="phase"></param>
        /// <param name="allowPhase"></param>
        /// <returns></returns>
        private uint returnAllowPhase(byte phase,uint allowPhase)
        {
            uint temp = 1;
            //uint tempint = Convert.ToUInt32(phase);
            uint c = (temp << (phase-1)) | allowPhase;
            return c;
        }
        private void setPatternAndStagePattern(List<Pattern> lp ,List<StagePattern> lsp , StageItem currentStage,PhaseToDirec ptd)
        {
            //判断是新增加stage还是，老的更新用的
            Pattern ptemp= null;
            bool newPattern = false;
            bool oldPattern = false;
            foreach(Pattern p in lp)
            {
                if ((byte)(sldSchemeId.Value) == p.ucPatternId )
                {
                    p.ucCoorPhase = Convert.ToByte(cbxCoordination.SelectedItem);
                    p.ucCycleTime = Convert.ToByte(tbxCycle.Text);
                    p.ucOffset = Convert.ToByte(tbxOffset.Text);
                    p.ucPatternId = Convert.ToByte(sldSchemeId.Value);
                    p.ucStagePatternId = Convert.ToByte(sldStagePatternId.Value);
                    oldPattern = true;
               
                }
                else
                {
                    newPattern = true;
                }
            
            }
            if (!oldPattern)
            {
                if (newPattern)
                {
                    ptemp = new Pattern();
                    ptemp.ucCoorPhase = Convert.ToByte(cbxCoordination.SelectedItem);
                    ptemp.ucCycleTime = Convert.ToByte(tbxCycle.Text);
                    ptemp.ucOffset = Convert.ToByte(tbxOffset.Text);
                    ptemp.ucPatternId = Convert.ToByte(sldSchemeId.Value);
                    ptemp.ucStagePatternId = Convert.ToByte(sldStagePatternId.Value);
                    lp.Add(ptemp);
                }
               
            }
       
            foreach (StagePattern sp in lsp)
            {
                if (sp.ucStagePatternId == (byte)(sldStagePatternId.Value))
                {
                    
                    if (sp.ucStageNo == Convert.ToByte(currentStage.lblNumber.Content))
                    {
                        sp.ucStagePatternId = Convert.ToByte(sldStagePatternId.Value);
                        sp.ucStageNo = Convert.ToByte(currentStage.lblNumber.Content);
                        sp.ucGreenTime = Convert.ToByte(sldGreenTime.Value);
                        sp.ucYellowTime = Convert.ToByte(sldYellowTime.Value);
                        sp.ucRedTime = Convert.ToByte(sldRedTime.Value);
                        sp.ucOption = returnReactionTrueOrFalse();
                        sp.usAllowPhase = returnAllowPhase(ptd.ucPhase, sp.usAllowPhase);
                      //  Console.WriteLine(sp.usAllowPhase);
                        break;
                    }
                    else if(sp.ucStageNo == 0)
                    {
                        sp.ucStagePatternId = Convert.ToByte(sldStagePatternId.Value);
                        sp.ucStageNo = Convert.ToByte(currentStage.lblNumber.Content);
                        sp.ucGreenTime = Convert.ToByte(sldGreenTime.Value);
                        sp.ucYellowTime = Convert.ToByte(sldYellowTime.Value);
                        sp.ucRedTime = Convert.ToByte(sldRedTime.Value);
                        sp.ucOption = returnReactionTrueOrFalse();
                        sp.usAllowPhase = returnAllowPhase(ptd.ucPhase, sp.usAllowPhase);
                      //  Console.WriteLine(sp.usAllowPhase);
                        break;
                    }
                    else
                    {
                        //MessageBox.Show("研发专用，程序异常。没有进行stage，stageNo 不为0，也不为小图上的编号\n");
                    }
                }
            }
               
        }
   
        #region 子阶段鼠标单击选中处理
        private void stage1_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
           
            currentStage = stage1;
            BigMap4SmallMap(currentStage);
            smallMap4Form(currentStage);
            stageNumber.Content = currentStage.lblNumber.Content;
        }
        private void stage2_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (stageNumber.Content.Equals("2"))
                return;
            currentStage = stage2;
            BigMap4SmallMap(currentStage);
            smallMap4Form(currentStage);
            stageNumber.Content = currentStage.lblNumber.Content;
        }

        private void stage3_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (stageNumber.Content.Equals("3"))
                return;
            currentStage = stage3;
            BigMap4SmallMap(currentStage);
            smallMap4Form(currentStage);
            stageNumber.Content = currentStage.lblNumber.Content;
        }

        private void stage4_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (stageNumber.Content.Equals("4"))
                return;
            currentStage = stage4;
            BigMap4SmallMap(currentStage);
            smallMap4Form(currentStage);
            stageNumber.Content = currentStage.lblNumber.Content;
        }

        private void stage5_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (stageNumber.Content.Equals("5"))
                return;
            currentStage = stage5;
            BigMap4SmallMap(currentStage);
            smallMap4Form(currentStage);
            stageNumber.Content = currentStage.lblNumber.Content;
        }

        private void stage6_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (stageNumber.Content.Equals("6"))
                return;
            currentStage = stage6;
            BigMap4SmallMap(currentStage);
            smallMap4Form(currentStage);
            stageNumber.Content = currentStage.lblNumber.Content;
        }

        private void stage7_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (stageNumber.Content.Equals("7"))
                return;
            currentStage = stage7;
            BigMap4SmallMap(currentStage);
            smallMap4Form(currentStage);
            stageNumber.Content = currentStage.lblNumber.Content;
        }

        private void stage8_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (stageNumber.Content.Equals("8"))
                return;
            currentStage = stage8;
            BigMap4SmallMap(currentStage);//MessageBox.Show("stage1");
            smallMap4Form(currentStage);
            stageNumber.Content = currentStage.lblNumber.Content;
        }

        private void stage9_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (stageNumber.Content.Equals("9"))
                return;
            currentStage = stage9;
            BigMap4SmallMap(currentStage); //MessageBox.Show("stage1");
            smallMap4Form(currentStage);
            stageNumber.Content = currentStage.lblNumber.Content;
        }

        private void stage10_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (stageNumber.Content.Equals("10"))
                return;
            currentStage = stage10;
            BigMap4SmallMap(currentStage);//MessageBox.Show("stage1");
            smallMap4Form(currentStage);
            stageNumber.Content = currentStage.lblNumber.Content;
        }

        private void stage11_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (stageNumber.Content.Equals("11"))
                return;
            currentStage = stage11;
            BigMap4SmallMap(currentStage);//MessageBox.Show("stage1");
            smallMap4Form(currentStage);
            stageNumber.Content = currentStage.lblNumber.Content;
        }

        private void stage12_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (stageNumber.Content.Equals("12"))
                return;
            currentStage = stage12;
            BigMap4SmallMap(currentStage);//MessageBox.Show("stage1");
            smallMap4Form(currentStage);
            stageNumber.Content = currentStage.lblNumber.Content;
        }

        private void stage13_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (stageNumber.Content.Equals("13"))
                return;
            currentStage = stage13;
            BigMap4SmallMap(currentStage); //MessageBox.Show("stage1");
            smallMap4Form(currentStage);
            stageNumber.Content = currentStage.lblNumber.Content;
        }

        private void stage14_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (stageNumber.Content.Equals("14"))
                return;
            currentStage = stage14;
            BigMap4SmallMap(currentStage);//MessageBox.Show("stage1");
            smallMap4Form(currentStage);
            stageNumber.Content = currentStage.lblNumber.Content;
        }

        private void stage15_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (stageNumber.Content.Equals("15"))
                return;
            currentStage = stage15;
            BigMap4SmallMap(currentStage);//MessageBox.Show("stage1");
            smallMap4Form(currentStage);
            stageNumber.Content = currentStage.lblNumber.Content;
        }

        private void stage16_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (stageNumber.Content.Equals("16"))
                return;
            currentStage = stage16;
            smallMap4Form(currentStage);
            BigMap4SmallMap(currentStage); //MessageBox.Show("stage1");
            stageNumber.Content = currentStage.lblNumber.Content;
        }
        #endregion
        private bool savePattern()
        {
            try
            {
              // List<Pattern> lp = t.ListPattern;
                Pattern newpattern = new Pattern();
                newpattern.ucPatternId = (byte)(sldSchemeId.Value);
                newpattern.ucCycleTime = Convert.ToByte(tbxCycle.Text);
                newpattern.ucCoorPhase = Convert.ToByte(cbxCoordination.Text);
                newpattern.ucOffset = Convert.ToByte(tbxOffset.Text);
                newpattern.ucStagePatternId = Convert.ToByte(sldStagePatternId.Value);
                bool baddnewpattern = true;
                bool bvalidstagepatternid = false;  //判断是否阶段配时阶段数为0

                foreach (StagePattern sp in td.ListStagePattern)
                {
                    if (newpattern.ucStagePatternId == sp.ucStagePatternId)
                    {
                        if (sp.ucStageNo > 0)
                        {
                            bvalidstagepatternid = true;
                            break;
                        }
                    }
                }
                if (bvalidstagepatternid == false)
                {
                    MessageBox.Show("该方案对应阶段配时"+(byte)sldStagePatternId.Value+"没配置放行相位,方案无法保存!\r\n须先配置放行相位","方案",MessageBoxButton.OK,MessageBoxImage.Error);
                    return false;
                }
                if (td.ListPattern !=  null)
                {
                    foreach (Pattern p in td.ListPattern)
                    {
                        if (p.ucPatternId == ((byte) sldSchemeId.Value))
                        {
                            p.ucCycleTime = newpattern.ucCycleTime;
                            p.ucCoorPhase = newpattern.ucCoorPhase;
                            p.ucOffset = newpattern.ucOffset;
                            p.ucStagePatternId = newpattern.ucStagePatternId;
                            baddnewpattern = false;
                            break;
                        }
                    }
                }

                if (baddnewpattern == true)
                    {
                        MessageBox.Show("添加新方案"+((byte)sldSchemeId.Value), "方案", MessageBoxButton.OK, MessageBoxImage.Information);
                        if(td.ListPattern ==null)
                            td.ListPattern = new List<Pattern>();
                        td.ListPattern.Add(newpattern);
                    }
                return true;

            }
            catch (Exception ex)
            {
                MessageBox.Show("方案保存异常!", "方案", MessageBoxButton.OK,MessageBoxImage.Error);
                return false;
            }
        }
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
          
            if (ChkCopyStage.IsChecked == true)
            {
                bool validsourcestage = false;
                foreach (StagePattern newsp in td.ListStagePattern)
                {
                    if (newsp.ucStagePatternId == (byte)(sldStagePatternId.Value) && newsp.ucStageNo > 0)
                    {
                        MessageBox.Show("阶段配时" + newsp.ucStagePatternId + "存在放行相位,须先清空!", "阶段配时", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }

                }
                foreach (StagePattern sp in td.ListStagePattern)
                {
                    if (sp.ucStagePatternId == CopyedstageId && sp.ucStageNo > 0)
                    {
                        validsourcestage = true;
                        break;
                    }
                }
                if (validsourcestage == true)
                {
                       foreach (StagePattern sp in td.ListStagePattern)
                      {
                         if (sp.ucStagePatternId == CopyedstageId && sp.ucStageNo > 0)
                          {
                              foreach (StagePattern sp1 in td.ListStagePattern)
                              {
                                  if (sp1.ucStagePatternId == (byte) (sldStagePatternId.Value) && sp1.ucStageNo == 0)
                                  {
                                      sp1.ucStageNo = sp.ucStageNo;
                                      sp1.ucGreenTime = sp.ucGreenTime;
                                      sp1.ucRedTime = sp.ucRedTime;
                                      sp1.ucYellowTime = sp.ucYellowTime;
                                      sp1.usAllowPhase = sp.usAllowPhase;
                                      sp1.ucOption = sp.ucOption;
                                      break;
                                  }

                              }
                          }
                      }
                    
                }
                else
                {
                    MessageBox.Show("源阶段配时" + CopyedstageId + "无任何放行相位，无法复制给阶段配时" + tbkStagePatternId.Text, "阶段配时", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                
            }
            Message msgStagePattern = TscDataUtils.SetStagePattern(td.ListStagePattern);
      
            if(msgStagePattern != null)
                MessageBox.Show(ChkCopyStage.IsChecked == true ? "复制" + msgStagePattern.msg : msgStagePattern.msg, "阶段配时", MessageBoxButton.OK, msgStagePattern.flag == true ? MessageBoxImage.Information : MessageBoxImage.Error);

        }

        private void btnRead_Click(object sender, RoutedEventArgs e)
        {
           
            bool bsaveok = savePattern();
            if (bsaveok == false)
                return;
            Message msgPattern = TscDataUtils.SetPattern(td.ListPattern);
            if(msgPattern != null)
                MessageBox.Show(msgPattern.msg,"方案",MessageBoxButton.OK,msgPattern.flag==true?MessageBoxImage.Information:MessageBoxImage.Error);
        }
        private void visiableStage(StagePattern sp)
        {
            if (sp == null)
                return;
            switch (sp.ucStageNo)
            {
                case 1:
                    stage1.Visibility = Visibility.Visible;
                    break;
                case 2:
                    stage2.Visibility = Visibility.Visible;
                    break;
                case 3:
                    stage3.Visibility = Visibility.Visible;
                    break;
                case 4:
                    stage4.Visibility = Visibility.Visible;
                    break;
                case 5:
                    stage5.Visibility = Visibility.Visible;
                    break;
                case 6:
                    stage6.Visibility = Visibility.Visible;
                    break;
                case 7:
                    stage7.Visibility = Visibility.Visible;
                    break;
                case 8:
                    stage8.Visibility = Visibility.Visible;
                    break;
                case 9:
                    stage9.Visibility = Visibility.Visible;
                    break;
                case 10:
                    stage10.Visibility = Visibility.Visible;
                    break;
                case 11:
                    stage11.Visibility = Visibility.Visible;
                    break;
                case 12:
                    stage12.Visibility = Visibility.Visible;
                    break;
                case 13:
                    stage13.Visibility = Visibility.Visible;
                    break;
                case 14:
                    stage14.Visibility = Visibility.Visible;
                    break;
                case 15:
                    stage15.Visibility = Visibility.Visible;
                    break;
                case 16:
                    stage16.Visibility = Visibility.Visible;
                    break;
                default:
                    break;
            }
           
        }
        /// <summary>
        /// 问题代码 ，请不要调用
        /// </summary>
        /// <param name="l"></param>
        public void initcbxCoordination()
        {
          
            List<PhaseToDirec> lptd = td.ListPhaseToDirec;
            if (lptd == null)
                return;
            foreach (PhaseToDirec ptd in lptd)
            {
                if (ptd.ucPhase != 0)
                {
                    cbxCoordination.Items.Add(ptd.ucPhase);
                }
            }
        }
        /// <summary>
        /// 初始化每个Stage的编号。
        /// </summary>
        public void initStageNumber()
        {
            stage1.lblNumber.Content = "1";
            stage2.lblNumber.Content = "2";
            stage3.lblNumber.Content = "3";
            stage4.lblNumber.Content = "4";
            stage5.lblNumber.Content = "5";
            stage6.lblNumber.Content = "6";
            stage7.lblNumber.Content = "7";
            stage8.lblNumber.Content = "8";
            stage9.lblNumber.Content = "9";
            stage10.lblNumber.Content = "10";
            stage11.lblNumber.Content = "11";
            stage12.lblNumber.Content = "12";
            stage13.lblNumber.Content = "13";
            stage14.lblNumber.Content = "14";
            stage15.lblNumber.Content = "15";
            stage16.lblNumber.Content = "16";
        }

       
        /// <summary>
        /// 初始化数据
        /// </summary>
        /// <param name="t"></param>
        /// <summary>
        /// 根据方向表，可以得到哪个方向有配置相位。哪个方向没有配置相位，
        /// 根据方向表的相位字段，可以将方向隐藏起来
        /// </summary>
        /// <param name="ptd"></param>
        /// <param name="sp"></param>
        private void initDirecArrow(PhaseToDirec ptd, StagePattern sp)
        {
            if (ptd == null || sp == null)
                return;
            byte direcValue = ptd.ucId;
            if (ptd.ucPhase == 0)
            {
                StageItem si = returnStageItemObjectByStageNo(sp.ucStageNo);
                switch (direcValue)
                {
                    //北方
                    case Define.NORTH_LEFT :
                         si.northLeft.Visibility = Visibility.Hidden;
                         northLeft.Visibility = Visibility.Hidden;
                        break;
                    case Define.NORTH_STRAIGHT:
                        si.northStraight.Visibility = Visibility.Hidden;
                        northStraight.Visibility = Visibility.Hidden;
                        break;
                    case Define.NORTH_RIGHT:
                        si.northRight.Visibility = Visibility.Hidden;
                        northRight.Visibility = Visibility.Hidden;
                        break;
                    case Define.NORTH_PEDESTRAIN_ONE:
                        si.northPedestrain1.Visibility = Visibility.Hidden;
                        northPedestrain1.Visibility = Visibility.Hidden;
                        break;
                     case Define.NORTH_PEDESTRAIN_TWO:
                        si.northPedestrain2.Visibility = Visibility.Hidden;
                        northPedestrain2.Visibility = Visibility.Hidden;
                        break;
                     case Define.NORTH_TURN_AROUND:
                        si.northTurn.Visibility = Visibility.Hidden;
                        northTurn.Visibility = Visibility.Hidden;
                        break;
                     case Define.NORTH_OTHER:
                        si.northOther.Visibility = Visibility.Hidden;
                        northOther.Visibility = Visibility.Hidden;
                        break;
                     case Define.NORTH_LEFT_STRAIGHT_RIGHT:
                        si.westNorthOther.Visibility = Visibility.Hidden;
                        WestNorthOther.Visibility = Visibility.Hidden;
                        break;
                    //东方
                     case Define.EAST_LEFT:
                        si.eastLeft.Visibility = Visibility.Hidden;
                        eastLeft.Visibility = Visibility.Hidden;
                        break;
                     case Define.EAST_STRAIGHT:
                        si.eastStraight.Visibility = Visibility.Hidden;
                        eastStraight.Visibility = Visibility.Hidden;
                        break;
                     case Define.EAST_RIGHT:
                        si.eastRight.Visibility = Visibility.Hidden;
                        eastRight.Visibility = Visibility.Hidden;
                        break;
                     case Define.EAST_PEDESTRAIN_ONE:
                        si.eastPedestrain1.Visibility = Visibility.Hidden;
                        eastPedestrain1.Visibility = Visibility.Hidden;
                        break;
                     case Define.EAST_PEDESTRAIN_TWO:
                        si.eastPedestrain2.Visibility = Visibility.Hidden;
                        eastPedestrain2.Visibility = Visibility.Hidden;
                        break;
                     case Define.EAST_TURN_AROUND:
                        si.eastTurn.Visibility = Visibility.Hidden;
                        eastTurn.Visibility = Visibility.Hidden;
                        break;
                     case Define.EAST_OTHER:
                        si.eastOther.Visibility = Visibility.Hidden;
                        eastOther.Visibility = Visibility.Hidden;
                        break;
                     case Define.EAST_LEFT_STRAIGHT_RIGHT:
                        si.eastNorthOther.Visibility = Visibility.Hidden;
                        eastNorthOther.Visibility = Visibility.Hidden;
                        break;
                    //南方
                     case Define.SOUTH_LEFT:
                        si.southLeft.Visibility = Visibility.Hidden;
                        southLeft.Visibility = Visibility.Hidden;
                        break;
                     case Define.SOUTH_STRAIGHT:
                        si.southStraight.Visibility = Visibility.Hidden;
                        southStraight.Visibility = Visibility.Hidden;
                        break;
                     case Define.SOUTH_RIGHT:
                        si.southRight.Visibility = Visibility.Hidden;
                        southRight.Visibility = Visibility.Hidden;
                        break;
                     case Define.SOUTH_PEDESTRAIN_ONE:
                        si.southPedestrain1.Visibility = Visibility.Hidden;
                        southPedestrain1.Visibility = Visibility.Hidden;
                        break;
                     case Define.SOUTH_PEDESTRAIN_TWO:
                        si.southPedestrain2.Visibility = Visibility.Hidden;
                        southPedestrain2.Visibility = Visibility.Hidden;
                        break;
                     case Define.SOUTH_TURN_AROUND:
                        si.southTurn.Visibility = Visibility.Hidden;
                        southTurn.Visibility = Visibility.Hidden;
                        break;
                     case Define.SOUTH_OTHER:
                        si.southOther.Visibility = Visibility.Hidden;
                        southOther.Visibility = Visibility.Hidden;
                        break;
                     case Define.SOUTH_LEFT_STRAIGHT_RIGHT:
                        si.eastSouthOther.Visibility = Visibility.Hidden;
                        eastSouthOther.Visibility = Visibility.Hidden;
                        break;
                    //西方
                     case Define.WEST_LEFT:
                        si.westLeft.Visibility = Visibility.Hidden;
                        westLeft.Visibility = Visibility.Hidden;
                        break;
                     case Define.WEST_STRAIGHT:
                        si.westStraight.Visibility = Visibility.Hidden;
                        westStraight.Visibility = Visibility.Hidden;
                        break;
                     case Define.WEST_RIGHT:
                        si.westRight.Visibility = Visibility.Hidden;
                        westRight.Visibility = Visibility.Hidden;
                        break;
                     case Define.WEST_PEDESTRAIN_ONE:
                        si.westPedestrain1.Visibility = Visibility.Hidden;
                        westPedestrain1.Visibility = Visibility.Hidden;
                        break;
                     case Define.WEST_PEDESTRAIN_TWO:
                        si.westPedestrain2.Visibility = Visibility.Hidden;
                        westPedestrain2.Visibility = Visibility.Hidden;
                        break;
                     case Define.WEST_TURN_AROUND:
                        si.westTurn.Visibility = Visibility.Hidden;
                        westTurn.Visibility = Visibility.Hidden;
                        break;
                     case Define.WEST_OTHER:
                        si.westOther.Visibility = Visibility.Hidden;
                        westOther.Visibility = Visibility.Hidden;
                        break;
                     case Define.WEST_LEFT_STRAIGHT_RIGHT:
                        si.westSouthOther.Visibility = Visibility.Hidden;
                        westSouthOther.Visibility = Visibility.Hidden;
                        break;
                    default:
                        break;
                }
            }
      
        }
        /// <summary>
        /// 通过stageno 得到stageitem对象
        /// </summary>
        /// <param name="stageNo"></param>
        /// <returns></returns>
        private StageItem returnStageItemObjectByStageNo(byte stageNo)
        {
            switch (stageNo)
            {
                case 1:
                    return stage1;
                case 2:
                    return stage2;
                case 3:
                    return stage3;
                case 4:
                    return stage4;
                case 5:
                    return stage5;
                case 6:
                    return stage6;
                case 7:
                    return stage7;
                case 8:
                    return stage8;
                case 9:
                    return stage9;
                case 10:
                    return stage10;
                case 11:
                    return stage11;
                case 12:
                    return stage12;
                case 13:
                    return stage13;
                case 14:
                    return stage14;
                case 15:
                    return stage15;
                case 16:
                    return stage16;
                default:
                    return null;
            }
            
            
        }

        private void ResetStageDirec(StageItem si)
        {
            if (si == null)
                return;
            BitmapImage redBitmapImage = new BitmapImage(new Uri("/tscui;component/Resources/Images/redlight.png", UriKind.Relative));
            BitmapImage redBitmapImage1 = new BitmapImage(new Uri("/tscui;component/Resources/Images/redlight1.png", UriKind.Relative));
            //北方
            si.northPedestrain1.Source = redBitmapImage1;
            si.northPedestrain2.Source = redBitmapImage1;
            si.northLeft.Source = redBitmapImage;
            si.northStraight.Source = redBitmapImage;
            si.northRight.Source = redBitmapImage;
            si.northOther.Source = redBitmapImage;
            si.northTurn.Source = redBitmapImage;
            si.westNorthOther.Source = redBitmapImage;
            //东方
            si.eastPedestrain1.Source = redBitmapImage;
            si.eastPedestrain2.Source = redBitmapImage;
            si.eastLeft.Source = redBitmapImage1;
            si.eastStraight.Source = redBitmapImage1;
            si.eastRight.Source = redBitmapImage1;
            si.eastOther.Source = redBitmapImage1;
            si.eastTurn.Source = redBitmapImage1;
            si.eastNorthOther.Source = redBitmapImage1;

            //南方
            si.southPedestrain1.Source = redBitmapImage1;
            si.southPedestrain2.Source = redBitmapImage1;
            si.southLeft.Source = redBitmapImage;
            si.southOther.Source = redBitmapImage;
            si.southRight.Source = redBitmapImage;
            si.southStraight.Source = redBitmapImage;
            si.southTurn.Source = redBitmapImage;
            si.eastSouthOther.Source = redBitmapImage;

            //西方
            si.westPedestrain1.Source = redBitmapImage;
            si.westPedestrain2.Source = redBitmapImage;
            si.westLeft.Source = redBitmapImage1;
            si.westStraight.Source = redBitmapImage1;
            si.westRight.Source = redBitmapImage1;
            si.westOther.Source = redBitmapImage1;
            si.westTurn.Source = redBitmapImage1;
            si.westSouthOther.Source = redBitmapImage1;
        }


        /// <summary>
        /// 通过方向 表和阶段表可以确定，相应的相位已经配置上去。
        /// </summary>
        /// <param name="ptd"></param>
        /// <param name="sp"></param>
        private void InitStageDirec(PhaseToDirec ptd,StagePattern sp)
        {
            if (ptd == null || sp == null)
            {
                MessageBox.Show("相位方向表或阶段配时表为空，无法初始化阶段配时图");
                return;
            }
            StageItem si = returnStageItemObjectByStageNo(sp.ucStageNo);
            BitmapImage greenimage = new BitmapImage(new Uri("/tscui;component/Resources/Images/greenlight.png", UriKind.Relative));
            BitmapImage greenimage1 = new BitmapImage(new Uri("/tscui;component/Resources/Images/greenlight1.png", UriKind.Relative));
            new BitmapImage(new Uri("/tscui;component/Resources/Images/greenlight.png", UriKind.Relative)); 
            switch (ptd.ucId)
            {
                //北方
                case  (Define.NORTH_PEDESTRAIN_ONE) :
                    si.northPedestrain1.Source = greenimage1;
                    break;
                case (Define.NORTH_PEDESTRAIN_TWO):
                    si.northPedestrain2.Source = greenimage1;
                    break;
                case (Define.NORTH_LEFT):
                    si.northLeft.Source = greenimage;
                    break;
                case (Define.NORTH_STRAIGHT):
                    si.northStraight.Source = greenimage;
                    break;
                case (Define.NORTH_RIGHT):
                    si.northRight.Source = greenimage;
                    break;
                case (Define.NORTH_TURN_AROUND):
                    si.northTurn.Source = greenimage;
                    break;
                case (Define.NORTH_OTHER):
                    si.northOther.Source = greenimage;
                    break;
                case (Define.NORTH_LEFT_STRAIGHT_RIGHT):
                    si.westNorthOther.Source = greenimage;
                    break;
                  //南方
                case (Define.SOUTH_PEDESTRAIN_ONE):
                    si.southPedestrain1.Source = greenimage1;
                    break;
                case (Define.SOUTH_PEDESTRAIN_TWO):
                    si.southPedestrain2.Source = greenimage1;
                    break;
                case (Define.SOUTH_LEFT):
                    si.southLeft.Source = greenimage;
                    break;
                case (Define.SOUTH_STRAIGHT):
                    si.southStraight.Source = greenimage;
                    break;
                case (Define.SOUTH_RIGHT):
                    si.southRight.Source = greenimage;
                    break;
                case (Define.SOUTH_TURN_AROUND) :
                    si.southTurn.Source = greenimage;
                    break;
                case (Define.SOUTH_OTHER) :
                    si.southOther.Source = greenimage;
                    break;
                case (Define.SOUTH_LEFT_STRAIGHT_RIGHT):
                    si.eastSouthOther.Source = greenimage;
                    break;
                //东方
                case (Define.EAST_PEDESTRAIN_ONE):
                    si.eastPedestrain1.Source = greenimage;
                    break;
                case (Define.EAST_PEDESTRAIN_TWO):
                    si.eastPedestrain2.Source = greenimage;
                    break;
                case (Define.EAST_LEFT):
                    si.eastLeft.Source = greenimage1;
                    break;
                case (Define.EAST_STRAIGHT):
                    si.eastStraight.Source = greenimage1;
                    break;
                case (Define.EAST_RIGHT):
                    si.eastRight.Source = greenimage1;
                    break;
                case (Define.EAST_TURN_AROUND):
                    si.eastTurn.Source = greenimage1;
                    break;
                case (Define.EAST_OTHER):
                    si.eastOther.Source = greenimage1;
                    break;
                case (Define.EAST_LEFT_STRAIGHT_RIGHT):
                    si.eastNorthOther.Source = greenimage1;
                    break;
                //西方
                case (Define.WEST_PEDESTRAIN_ONE):
                    si.westPedestrain1.Source = greenimage;
                    break;
                case (Define.WEST_PEDESTRAIN_TWO):
                    si.westPedestrain2.Source = greenimage;
                    break;
                case (Define.WEST_LEFT):
                    si.westLeft.Source = greenimage1;
                    break;
                case (Define.WEST_STRAIGHT):
                    si.westStraight.Source = greenimage1;
                    break;
                case (Define.WEST_RIGHT):
                    si.westRight.Source = greenimage1;
                    break;
                case (Define.WEST_TURN_AROUND):
                    si.westTurn.Source = greenimage1;
                    break;
                case (Define.WEST_OTHER):
                    si.westOther.Source = greenimage1;
                    break;
                case (Define.WEST_LEFT_STRAIGHT_RIGHT):
                    si.westSouthOther.Source = greenimage1;
                    break;
                default:
                    break;
            }

            return;
           
        

        }
        

        private void DispatcherInitStageNum()
        {
            this.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new DelegateInitStageNumber(initStageNumber));
        }
        private void DispatcherInitStageItem()
        {
            this.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new InitStageItemToLSI(initStageItemList));
        }
        private void DispatcherInitCoordination()
        {
            this.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new DelegateInitcbxCoordination(initcbxCoordination));
        }
       

        private void hiddenStageAll()
        {
            foreach (StageItem si in lsi)
            {
              si.Visibility = Visibility.Hidden;
            }
        }
        /// <summary>
        /// 隐藏所有的stage 图
        /// </summary>
        private void hiddenStage(StagePattern sp)
        {
          
            foreach (StageItem si in lsi)
            {
                if (sp.usAllowPhase == 0)
                {
                    si.Visibility = Visibility.Hidden;
                    //break;
                }
            }
        }
        private void clearStageByDeleteStage(TscData t,StageItem si)
        {
            if (t == null)
                return;
            List<StagePattern> lsp = t.ListStagePattern;
            foreach(StagePattern sp in lsp)
            {
                if(sldStagePatternId.Value == sp.ucStagePatternId)
                {
                    if (sp.ucStageNo == Convert.ToByte(si.lblNumber.Content))
                    {
                        sp.ucStageNo = 0;
                        sp.ucGreenTime = 0;
                        sp.ucOption = 0;
                        sp.ucRedTime = 0;
                        sp.ucYellowTime = 0;
                        sp.usAllowPhase = 0;
                    }
                }
                
            }
        }
        private void ScrollViewer_MouseRightButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            try
            {
                if (Equals(lsi[0],stage1))
                {
                    lsi.Reverse();
                }
                foreach (StageItem si in lsi)
                {
                    if (si.Visibility == Visibility.Visible)
                    {
                        if (MessageBox.Show("确定删除阶段"+si.lblNumber.Content+"吗?", "删除", MessageBoxButton.YesNo) == MessageBoxResult.No)
                        {
                            return;
                        }
                       
                        si.Visibility = Visibility.Hidden;
                        clearStageByDeleteStage(td, si);
                        bigMapInitArllowRed();
                        lsi.Reverse();
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("删除阶段");
            }
        }
        private void bigMapInitArllowRed()
        {
            BitmapImage redlight = new BitmapImage(new Uri("/tscui;component/Resources/Images/redlight.png", UriKind.Relative));
            BitmapImage redlight1 = new BitmapImage(new Uri("/tscui;component/Resources/Images/redlight1.png", UriKind.Relative));
            //北方
            northLeft.Source = redlight;
            northOther.Source = redlight;
            northRight.Source = redlight;
            northStraight.Source = redlight;
            northPedestrain1.Source = redlight1;
            northPedestrain2.Source = redlight1;
            northTurn.Source = redlight;
            WestNorthOther.Source = redlight;
            //东方
            eastLeft.Source = redlight1;
            eastOther.Source = redlight1;
            eastRight.Source = redlight1;
            eastStraight.Source = redlight1;
            eastPedestrain1.Source = redlight;
            eastPedestrain2.Source = redlight;
            eastTurn.Source = redlight1;
            eastNorthOther.Source = redlight1;
            //南方
            southLeft.Source = redlight;
            southOther.Source = redlight;
            southRight.Source = redlight;
            southStraight.Source = redlight;
            southPedestrain1.Source = redlight1;
            southPedestrain2.Source = redlight1;
            southTurn.Source = redlight;
            eastSouthOther.Source = redlight;
            //西方
            westLeft.Source = redlight1;
            westOther.Source = redlight1;
            westRight.Source = redlight1;
            westStraight.Source = redlight1;
            westPedestrain1.Source = redlight;
            westPedestrain2.Source = redlight;
            westTurn.Source = redlight1;
            westSouthOther.Source = redlight1;

        }
        private void createStageByInitArllowRed(StageItem si)
        {
            BitmapImage redlight = new BitmapImage(new Uri("/tscui;component/Resources/Images/redlight.png", UriKind.Relative));
            BitmapImage redlight1 = new BitmapImage(new Uri("/tscui;component/Resources/Images/redlight1.png", UriKind.Relative));
            //北方
            si.northLeft.Source  = redlight;
            si.northOther.Source = redlight;
            si.northRight.Source = redlight;
            si.northStraight.Source = redlight;
            si.northPedestrain1.Source = redlight1;
            si.northPedestrain2.Source = redlight1;
            si.northTurn.Source = redlight;
            si.westNorthOther.Source = redlight;
            //东方
            si.eastLeft.Source = redlight1;
            si.eastOther.Source = redlight1;
            si.eastRight.Source = redlight1;
            si.eastStraight.Source = redlight1;
            si.eastPedestrain1.Source = redlight;
            si.eastPedestrain2.Source = redlight;
            si.eastTurn.Source = redlight1;
            si.eastNorthOther.Source = redlight1;
            //南方
            si.southLeft.Source = redlight;
            si.southOther.Source = redlight;
            si.southRight.Source = redlight;
            si.southStraight.Source = redlight;
            si.southPedestrain1.Source = redlight1;
            si.southPedestrain2.Source = redlight1;
            si.southTurn.Source = redlight;
            si.eastSouthOther.Source = redlight;
            //西方
            si.westLeft.Source = redlight1;
            si.westOther.Source = redlight1;
            si.westRight.Source = redlight1;
            si.westStraight.Source = redlight1;
            si.westPedestrain1.Source = redlight;
            si.westPedestrain2.Source = redlight;
            si.westTurn.Source = redlight1;
            si.westSouthOther.Source = redlight1;
        }
        /// <summary>
        /// 双击，创建新的stage
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ScrollViewer_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (lsi[0] != stage1)
            {
                lsi.Reverse();
            }
            foreach(StageItem si in lsi)
            {
                if (si.Visibility == Visibility.Hidden)
                {
                    si.Visibility = Visibility.Visible;
                    createStageByInitArllowRed(si);
                    break;
                }
            }
        }

        #region 阶段配时-切换方案号
        private void sldSchemeId_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            initStageAttriableByPatternId();
        }
        private void initStageAttriableByPatternId()
        {
            try
            {
               // TscData td = Utils.Utils.GetTscDataByApplicationCurrentProperties();
                if (td == null)
                    return;
                else if (td.ListPattern == null)
                {
                    MessageBox.Show("信号机方案表为空!", "阶段配时", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    return;
                }

                List<Pattern> lp = td.ListPattern;
                if (lp.Count == 0)
                {
                    MessageBox.Show("未能加载到任何合法方案!","阶段配时",MessageBoxButton.OK,MessageBoxImage.Error);
                    return;
                }
                foreach (Pattern p in lp)
                {
                    if (p.ucPatternId ==((byte) sldSchemeId.Value))
                    {
                        tbxCycle.Text = p.ucCycleTime.ToString();
                        cbxCoordination.SelectedItem = p.ucCoorPhase;
                        tbxOffset.Text = p.ucOffset.ToString();
                        sldStagePatternId.Value = p.ucStagePatternId;
                        sldStagePatternId.Background = Brushes.White;
                        return;
                    }

                }
               // hiddenStageAll(); //当前方案号没有对应的阶段配时号
                sldStagePatternId.Background = Brushes.DarkRed;
            }
            catch (Exception ex)
            {
                MessageBox.Show("方案表加载异常!", "阶段配时", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }
        #endregion
        #region 阶段配时-切换阶段配时号
        private void sldStagePatternId_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (td == null)
                return;
            if (ChkCopyStage.IsChecked == true)
            {
                
            }
            else
            {
                DisplayStageByStagePatternIdChange();

            }
        }
        private void DisplayStageByStagePatternIdChange()
        {
            try
            {
                List<StagePattern> lsp = td.ListStagePattern;
                List<PhaseToDirec> lptd = td.ListPhaseToDirec;
                //每次都要把stage清空，再由下面的进行显示 
                hiddenStageAll();
                foreach (StagePattern sp in lsp)
                {
                    if (((byte)sldStagePatternId.Value) == sp.ucStagePatternId)
                    {
                        if (sp.ucStageNo != 0)
                        {
                            //在进行显示之前将所有的相位重置成红灯状态
                            StageItem si = returnStageItemObjectByStageNo(sp.ucStageNo);
                            ResetStageDirec(si);

                            visiableStage(sp); //stage 默认是不显示的。只有存在的情况下才显示出来。ucStageNo为0不存在。
                            //if (sldStagePatternId.Value == sp.ucStagePatternId)
                            //{
                            uint ap = sp.usAllowPhase;
                            for (int i = 0; i < 32; i++)
                            {
                                if (((ap >> i) & 0x01) == 0x01)
                                {
                                    foreach (PhaseToDirec ptd in lptd)
                                    {
                                        if (ptd.ucPhase != 0)
                                        {
                                            if (ptd.ucPhase == (i + 1))
                                            {
                                                //初始化
                                                InitStageDirec(ptd, sp);
                                                //Define.NORTH_LEFT
                                            }
                                        }
                                        else
                                        {
                                            initDirecArrow(ptd, sp);
                                        }

                                    }
                                }
                            }
                            //sldGreenTime.Value = sp.ucGreenTime;
                            //sldYellowTime.Value = sp.ucYellowTime;
                            //sldRedTime.Value = sp.ucRedTime;
                            //cbxReaction.IsChecked = true;//sp.ucOption;
                            // sp.ucStageNo   各个阶段编号，已经固定生成
                            //}
                        }
                    }

                }
                if (lsp.Count > 0)
                {
                    currentStage = stage1;
                    foreach (StagePattern sp in lsp)
                    {
                        if (sp.ucStagePatternId == Convert.ToByte(sldStagePatternId.Value) && sp.ucStageNo == Convert.ToByte(currentStage.lblNumber.Content.ToString()))
                        {
                            sldGreenTime.Value = sp.ucGreenTime;
                            sldYellowTime.Value = sp.ucYellowTime;
                            sldRedTime.Value = sp.ucRedTime;
                            //ChkIgnoreStage.IsChecked = (sp.ucOption & 0x2) == 0x2 ? true : false;
                            break;
                        }
                    }
                    BigMap4SmallMap(currentStage);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("获取阶段配时信息异常!", "阶段配时", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }
        #endregion




        private void sldGreenTime_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            try
            {
                //  Thread.Sleep(500);
                Slider sld = sldGreenTime;
                td = Utils.Utils.GetTscDataByApplicationCurrentProperties();
                if (td == null)
                    return;
                List<StagePattern> lsp = td.ListStagePattern;
                foreach (StagePattern sp in lsp)
                {
                    if (currentStage != null && sldStagePatternId != null && sld!=null)
                    {
                        if (sp.ucStagePatternId == Convert.ToByte(sldStagePatternId.Value) && Convert.ToByte(currentStage.lblNumber.Content) == sp.ucStageNo)
                        {
                            sp.ucGreenTime = Convert.ToByte(sld.Value);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                  MessageBox.Show(ex.ToString(), "阶段配时", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            
        }

        private void sldYellowTime_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

            try
            {
                //  Thread.Sleep(500);
                Slider sld = sldYellowTime;
                td = Utils.Utils.GetTscDataByApplicationCurrentProperties();
                if (td == null)
                    return;
                List<StagePattern> lsp = td.ListStagePattern;
                foreach (StagePattern sp in lsp)
                {
                    if (currentStage != null && sldStagePatternId != null && sld != null)
                    {
                        if (sp.ucStagePatternId == Convert.ToByte(sldStagePatternId.Value) && Convert.ToByte(currentStage.lblNumber.Content) == sp.ucStageNo)
                        {
                            sp.ucYellowTime = Convert.ToByte(sld.Value);
                        }
                    }

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "阶段配时", MessageBoxButton.OK, MessageBoxImage.Exclamation);

            }
        }

        private void sldRedTime_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

            try
            {
                ///   Thread.Sleep(500);
                Slider sld = sldRedTime;
                td = Utils.Utils.GetTscDataByApplicationCurrentProperties();
                if (td == null)
                    return;
                List<StagePattern> lsp = td.ListStagePattern;
                foreach (StagePattern sp in lsp)
                {
                    if (currentStage != null && sldStagePatternId != null && sld != null)
                    {
                        if (sp.ucStagePatternId == Convert.ToByte(sldStagePatternId.Value) && Convert.ToByte(currentStage.lblNumber.Content) == sp.ucStageNo)
                        {
                            sp.ucRedTime = Convert.ToByte(sld.Value);
                        }
                    }

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "阶段配时", MessageBoxButton.OK, MessageBoxImage.Exclamation);

            }
           
        }

        private void ChkCopyStage_Checked(object sender, RoutedEventArgs e)
        {
            CopyedstageId = (byte)(sldStagePatternId.Value);
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            try
            {
               
                td = Utils.Utils.GetTscDataByApplicationCurrentProperties();
                if (td == null)
                    return;
                List<StagePattern> lsp = td.ListStagePattern;
                foreach (StagePattern sp in lsp)
                {
                    if (currentStage != null && sldStagePatternId != null )
                    {
                        if (sp.ucStagePatternId == Convert.ToByte(sldStagePatternId.Value) && Convert.ToByte(currentStage.lblNumber.Content) == sp.ucStageNo)
                        {
                            sp.ucOption |= 0x2;
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                return;
            }

        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            try
            {

                td = Utils.Utils.GetTscDataByApplicationCurrentProperties();
                if (td == null)
                    return;
                List<StagePattern> lsp = td.ListStagePattern;
                foreach (StagePattern sp in lsp)
                {
                    if (currentStage != null && sldStagePatternId != null)
                    {
                        if (sp.ucStagePatternId == Convert.ToByte(sldStagePatternId.Value) && Convert.ToByte(currentStage.lblNumber.Content) == sp.ucStageNo)
                        {
                            sp.ucOption &= 0xFD;
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                return;
            }
        }



    }
}
