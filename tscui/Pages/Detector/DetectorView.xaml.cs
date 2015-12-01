using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using Apex.MVVM;
using Apex.Behaviours;
using Apex;
using tscui.Detector;
using System.Windows;
using tscui.Models;
using tscui.Service;
using System.Threading;
using System.Windows.Threading;
using System.Windows.Media;
<<<<<<< HEAD
using Visifire.Charts;
=======
>>>>>>> 74e4ebd174211bd2f7215c892a9bd98ddb385798

namespace tscui.Pages.Detector
{
    /// <summary>
    /// Interaction logic for DetectorView.xaml
    /// </summary>
    [View(typeof (DetectorViewModel))]
    public partial class DetectorView : UserControl, IView
    {
        private TscData td;
        private bool DecBoard1Online;
        private bool DecBoard2Online;
        private bool InjecBoard1Online;
        private bool InjecBoard2Online;

        public DetectorView()
        {
<<<<<<< HEAD
            try
            {
                td = Utils.Utils.GetTscDataByApplicationCurrentProperties();
                InitializeComponent();
                SelectedDetectorId.ItemsSource = td.ListDetector;
                GridDectorsParams.ItemsSource = td.ListDetector;
                this.Deteccanvas.AddHandler(MouseLeftButtonDownEvent, new RoutedEventHandler(MouseLeftButton_Down));
                this.Deteccanvas.AddHandler(MouseRightButtonDownEvent, new RoutedEventHandler(MouseRightButton_Down));
                CreateChart();
            }
            catch (Exception ex)
            {
                MessageBox.Show("加载检测器配置异常!", "检测器", MessageBoxButton.OK, MessageBoxImage.Error);
            }
=======
            td = Utils.Utils.GetTscDataByApplicationCurrentProperties();
            InitializeComponent();
            this.Deteccanvas.AddHandler(TextBlock.MouseLeftButtonDownEvent, new RoutedEventHandler(MouseLeftButton_Down));
            this.Deteccanvas.AddHandler(TextBlock.MouseRightButtonDownEvent,new RoutedEventHandler(MouseRightButton_Down));
>>>>>>> 74e4ebd174211bd2f7215c892a9bd98ddb385798
            //   MessageBox.Show("Construct");
        }

        private void MouseRightButton_Down(object sender, RoutedEventArgs e)
        {
            try
            {
<<<<<<< HEAD
                if (e.OriginalSource != null)
=======
                TextBlock tb = e.OriginalSource as TextBlock;
                if (tb == null || tb.Text.Equals(""))
                {
                    return;
                }

                byte id = Convert.ToByte(tb.Text);
                List<Models.Detector> ld = td.ListDetector;
                foreach (Models.Detector d in ld)
>>>>>>> 74e4ebd174211bd2f7215c892a9bd98ddb385798
                {
                    TextBlock tb = e.OriginalSource as TextBlock;
                    if (tb == null || tb.Text.Equals(""))
                    {
<<<<<<< HEAD
                        return;
                    }

                    byte id = Convert.ToByte(tb.Text);
                    List<Models.Detector> ld = td.ListDetector;
                    foreach (Models.Detector d in ld)
                    {
                        if (d.ucDetectorId == id)
                        {
                            d.ucPhaseId = 0x00;
                            tb.Text = "";
                            tb.Background = Brushes.Transparent;
                            return;
                        }
=======
                        d.ucPhaseId = 0x00;
                        tb.Text = "";
                        tb.Background = Brushes.Transparent;
                        return;
>>>>>>> 74e4ebd174211bd2f7215c892a9bd98ddb385798
                    }
                }
            }
            catch (Exception ex)
            {
                return;
            }
        }

        private void MouseLeftButton_Down(object sender, RoutedEventArgs e)
        {
            try
            {
                if (e.OriginalSource != null)
                {
<<<<<<< HEAD
                    string detecid = "";
=======
>>>>>>> 74e4ebd174211bd2f7215c892a9bd98ddb385798
                    TextBlock tb = e.OriginalSource as TextBlock;
                    if (tb == null)
                    {
                        return;
                    }
                    else if (ChkCarmonitor.IsChecked == true)
                    {
                        MessageBox.Show("配置前须取消车辆检测监控!", "检测器", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;
                    }
<<<<<<< HEAD
                    detecid = tb.Text;
                    if (!detecid.Equals(""))
                    {
                        SelectedDetectorId.SelectedValue = tb.Text;
                    }
                    //ApexBroker.GetShell().ShowPopup(new DetectorPopup());
                    ApexBroker.GetShell().ShowPopup(new DetectorItem(DecBoard1Online, DecBoard2Online, InjecBoard1Online,
=======
                    //ApexBroker.GetShell().ShowPopup(new DetectorPopup());
                    ApexBroker.GetShell()
                        .ShowPopup(new DetectorItem(DecBoard1Online, DecBoard2Online, InjecBoard1Online,
>>>>>>> 74e4ebd174211bd2f7215c892a9bd98ddb385798
                            InjecBoard2Online));
                    int i = Utils.Utils.GetSelectedDetector();
                    if (i == 0)
                    {
                        return;
                    }
                    Byte DetectorDirect = 0xff;
                    Byte DetectorIndex = 0xff;
                    string setdetectorname = (e.OriginalSource as FrameworkElement).Name;
                    switch (setdetectorname)
                    {
                        case "detectorNorthLeft1":
                            DetectorDirect = Define.NORTH_LEFT;
                            DetectorIndex = 0x1;
                            break;
                        case "detectorNorthLeft2":
                            DetectorDirect = Define.NORTH_LEFT;
                            DetectorIndex = 0x2;
                            break;
                        case "detectorNorthLeft3":
                            DetectorDirect = Define.NORTH_LEFT;
                            DetectorIndex = 0x3;
                            break;
                        case "detectorNorthLeft4":
                            DetectorDirect = Define.NORTH_LEFT;
                            DetectorIndex = 0x4;
                            break;
                        case "detectorNorthStraight1":
                            DetectorDirect = Define.NORTH_STRAIGHT;
                            DetectorIndex = 0x1;
                            break;
                        case "detectorNorthStraight2":
                            DetectorDirect = Define.NORTH_STRAIGHT;
                            DetectorIndex = 0x2;
                            break;
                        case "detectorNorthStraight3":
                            DetectorDirect = Define.NORTH_STRAIGHT;
                            DetectorIndex = 0x3;
                            break;
                        case "detectorNorthStraight4":
                            DetectorDirect = Define.NORTH_STRAIGHT;
                            DetectorIndex = 0x4;
                            break;

                        case "detectorNorthRight1":
                            DetectorDirect = Define.NORTH_RIGHT;
                            DetectorIndex = 0x1;
                            break;
                        case "detectorNorthRight2":
                            DetectorDirect = Define.NORTH_RIGHT;
                            DetectorIndex = 0x2;
                            break;
                        case "detectorNorthRight3":
                            DetectorDirect = Define.NORTH_RIGHT;
                            DetectorIndex = 0x3;
                            break;
                        case "detectorNorthRight4":
                            DetectorDirect = Define.NORTH_RIGHT;
                            DetectorIndex = 0x4;
                            break;

                        case "detectorNorthOther1":
                            DetectorDirect = Define.NORTH_OTHER;
                            DetectorIndex = 0x1;
                            break;
                        case "detectorNorthOther2":
                            DetectorDirect = Define.NORTH_OTHER;
                            DetectorIndex = 0x2;
                            break;
                        case "detectorNorthOther3":
                            DetectorDirect = Define.NORTH_OTHER;
                            DetectorIndex = 0x3;
                            break;
                        case "detectorNorthOther4":
                            DetectorDirect = Define.NORTH_OTHER;
                            DetectorIndex = 0x4;
                            break;

                        case "detectorSouthLeft1":
                            DetectorDirect = Define.SOUTH_LEFT;
                            DetectorIndex = 0x1;
                            break;
                        case "detectorSouthLeft2":
                            DetectorDirect = Define.SOUTH_LEFT;
                            DetectorIndex = 0x2;
                            break;
                        case "detectorSouthLeft3":
                            DetectorDirect = Define.SOUTH_LEFT;
                            DetectorIndex = 0x3;
                            break;
                        case "detectorSouthLeft4":
                            DetectorDirect = Define.SOUTH_LEFT;
                            DetectorIndex = 0x4;
                            break;
                        case "detectorSouthStraight1":
                            DetectorDirect = Define.SOUTH_STRAIGHT;
                            DetectorIndex = 0x1;
                            break;
                        case "detectorSouthStraight2":
                            DetectorDirect = Define.SOUTH_STRAIGHT;
                            DetectorIndex = 0x2;
                            break;
                        case "detectorSouthStraight3":
                            DetectorDirect = Define.SOUTH_STRAIGHT;
                            DetectorIndex = 0x3;
                            break;
                        case "detectorSouthStraight4":
                            DetectorDirect = Define.SOUTH_STRAIGHT;
                            DetectorIndex = 0x4;
                            break;

                        case "detectorSouthRight1":
                            DetectorDirect = Define.SOUTH_RIGHT;
                            DetectorIndex = 0x1;
                            break;
                        case "detectorSouthRight2":
                            DetectorDirect = Define.SOUTH_RIGHT;
                            DetectorIndex = 0x2;
                            break;
                        case "detectorSouthRight3":
                            DetectorDirect = Define.SOUTH_RIGHT;
                            DetectorIndex = 0x3;
                            break;
                        case "detectorSouthRight4":
                            DetectorDirect = Define.SOUTH_RIGHT;
                            DetectorIndex = 0x4;
                            break;
                        case "detectorSouthOther1":
                            DetectorDirect = Define.SOUTH_OTHER;
                            DetectorIndex = 0x1;
                            break;
                        case "detectorSouthOther2":
                            DetectorDirect = Define.SOUTH_OTHER;
                            DetectorIndex = 0x2;
                            break;
                        case "detectorSouthOther3":
                            DetectorDirect = Define.SOUTH_OTHER;
                            DetectorIndex = 0x3;
                            break;
                        case "detectorSouthOther4":
                            DetectorDirect = Define.SOUTH_OTHER;
                            DetectorIndex = 0x4;
                            break;

                        case "detectorWestLeft1":
                            DetectorDirect = Define.WEST_LEFT;
                            DetectorIndex = 0x1;
                            break;
                        case "detectorWestLeft2":
                            DetectorDirect = Define.WEST_LEFT;
                            DetectorIndex = 0x2;
                            break;
                        case "detectorWestLeft3":
                            DetectorDirect = Define.WEST_LEFT;
                            DetectorIndex = 0x3;
                            break;
                        case "detectorWestLeft4":
                            DetectorDirect = Define.WEST_LEFT;
                            DetectorIndex = 0x4;
                            break;
                        case "detectorWestStraight1":
                            DetectorDirect = Define.WEST_STRAIGHT;
                            DetectorIndex = 0x1;
                            break;
                        case "detectorWestStraight2":
                            DetectorDirect = Define.WEST_STRAIGHT;
                            DetectorIndex = 0x2;
                            break;
                        case "detectorWestStraight3":
                            DetectorDirect = Define.WEST_STRAIGHT;
                            DetectorIndex = 0x3;
                            break;
                        case "detectorWestStraight4":
                            DetectorDirect = Define.WEST_STRAIGHT;
                            DetectorIndex = 0x4;
                            break;

                        case "detectorWestRight1":
                            DetectorDirect = Define.WEST_RIGHT;
                            DetectorIndex = 0x1;
                            break;
                        case "detectorWestRight2":
                            DetectorDirect = Define.WEST_RIGHT;
                            DetectorIndex = 0x2;
                            break;
                        case "detectorWestRight3":
                            DetectorDirect = Define.WEST_RIGHT;
                            DetectorIndex = 0x3;
                            break;
                        case "detectorWestRight4":
                            DetectorDirect = Define.WEST_RIGHT;
                            DetectorIndex = 0x4;
                            break;

                        case "detectorWestOther1":
                            DetectorDirect = Define.WEST_OTHER;
                            DetectorIndex = 0x1;
                            break;
                        case "detectorWestOther2":
                            DetectorDirect = Define.WEST_OTHER;
                            DetectorIndex = 0x2;
                            break;
                        case "detectorWestOther3":
                            DetectorDirect = Define.WEST_OTHER;
                            DetectorIndex = 0x3;
                            break;
                        case "detectorWestOther4":
                            DetectorDirect = Define.WEST_OTHER;
                            DetectorIndex = 0x4;
                            break;
                        case "detectorEastLeft1":
                            DetectorDirect = Define.EAST_LEFT;
                            DetectorIndex = 0x1;
                            break;
                        case "detectorEastLeft2":
                            DetectorDirect = Define.EAST_LEFT;
                            DetectorIndex = 0x2;
                            break;
                        case "detectorEastLeft3":
                            DetectorDirect = Define.EAST_LEFT;
                            DetectorIndex = 0x3;
                            break;
                        case "detectorEastLeft4":
                            DetectorDirect = Define.EAST_LEFT;
                            DetectorIndex = 0x4;
                            break;
                        case "detectorEastStraight1":
                            DetectorDirect = Define.EAST_STRAIGHT;
                            DetectorIndex = 0x1;
                            break;
                        case "detectorEastStraight2":
                            DetectorDirect = Define.EAST_STRAIGHT;
                            DetectorIndex = 0x2;
                            break;
                        case "detectorEastStraight3":
                            DetectorDirect = Define.EAST_STRAIGHT;
                            DetectorIndex = 0x3;
                            break;
                        case "detectorEastStraight4":
                            DetectorDirect = Define.EAST_STRAIGHT;
                            DetectorIndex = 0x4;
                            break;

                        case "detectorEastRight1":
                            DetectorDirect = Define.EAST_RIGHT;
                            DetectorIndex = 0x1;
                            break;
                        case "detectorEastRight2":
                            DetectorDirect = Define.EAST_RIGHT;
                            DetectorIndex = 0x2;
                            break;
                        case "detectorEastRight3":
                            DetectorDirect = Define.EAST_RIGHT;
                            DetectorIndex = 0x3;
                            break;
                        case "detectorEastRight4":
                            DetectorDirect = Define.EAST_RIGHT;
                            DetectorIndex = 0x4;
                            break;
                        case "detectorEastOther1":
                            DetectorDirect = Define.EAST_OTHER;
                            DetectorIndex = 0x1;
                            break;
                        case "detectorEastOther2":
                            DetectorDirect = Define.EAST_OTHER;
                            DetectorIndex = 0x2;
                            break;
                        case "detectorEastOther3":
                            DetectorDirect = Define.EAST_OTHER;
                            DetectorIndex = 0x3;
                            break;
                        case "detectorEastOther4":
                            DetectorDirect = Define.EAST_OTHER;
                            DetectorIndex = 0x4;
                            break;
                        default:
                            break;
                    }
                    if (DetectorDirect != 0xff && DetectorIndex != 0xff)
                    {
                        ClearDetectorId(i);
                        tb = e.OriginalSource as TextBlock;
                        List<Models.Detector> ld = td.ListDetector;
                        if (!tb.Text.Equals(""))
                        {
                            foreach (Models.Detector det in ld)
                            {
                                if (det.ucDetectorId == Convert.ToByte(tb.Text))
                                {
                                    det.ucPhaseId = 0;
                                    break;
                                }
                            }
                        }
                        tb.Text = i.ToString();
                        SetDetector(i, DetectorDirect, DetectorIndex);
<<<<<<< HEAD
                        SelectedDetectorId.SelectedValue = tb.Text;// displayOneDetector(i);
=======
                        displayOneDetector(i);
>>>>>>> 74e4ebd174211bd2f7215c892a9bd98ddb385798
                        //  MessageBox.Show("添加检测器" + DetectorIndex.ToString());
                    }
                    e.Handled = true;
                }
            }
            catch (Exception ex)
            {
                return;
            }
        }

        public void OnActivated()
        {
            SlideFadeInBehaviour.DoSlideFadeIn(this);
            ((DetectorViewModel) DataContext).ShowPopupCommandDetector1.Executed +=
                new CommandEventHandler(ShowPopupCommandDetector1_Executed);
            ((DetectorViewModel) DataContext).ShowPopupCommandDetector2.Executed +=
                new CommandEventHandler(ShowPopupCommandDetector2_Executed);
            ((DetectorViewModel) DataContext).ShowPopupCommandDetector3.Executed +=
                new CommandEventHandler(ShowPopupCommandDetector3_Executed);
            ((DetectorViewModel) DataContext).ShowPopupCommandDetector4.Executed +=
                new CommandEventHandler(ShowPopupCommandDetector4_Executed);
        }

        private void ShowPopupCommandDetector4_Executed(object sender, CommandEventArgs args)
        {
            throw new NotImplementedException();

        }

        private void ShowPopupCommandDetector3_Executed(object sender, CommandEventArgs args)
        {
            throw new NotImplementedException();
        }

        private void ShowPopupCommandDetector2_Executed(object sender, CommandEventArgs args)
        {
            throw new NotImplementedException();
        }

        private void ShowPopupCommandDetector1_Executed(object sender, CommandEventArgs args)
        {
            throw new NotImplementedException();
        }

        public void OnDeactivated()
        {
            ((DetectorViewModel) DataContext).ShowPopupCommandDetector1.Executed -=
                new CommandEventHandler(ShowPopupCommandDetector1_Executed);
            ((DetectorViewModel) DataContext).ShowPopupCommandDetector2.Executed -=
                new CommandEventHandler(ShowPopupCommandDetector2_Executed);
            ((DetectorViewModel) DataContext).ShowPopupCommandDetector3.Executed -=
                new CommandEventHandler(ShowPopupCommandDetector3_Executed);
            ((DetectorViewModel) DataContext).ShowPopupCommandDetector4.Executed -=
                new CommandEventHandler(ShowPopupCommandDetector4_Executed);
        }






        private void tbkD1_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            TextBlock tbkd = sender as TextBlock;
            DragDrop.DoDragDrop(tbkd, tbkd, DragDropEffects.Move);
        }

        private void tbkD2_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            TextBlock tbkd = sender as TextBlock;
            DragDrop.DoDragDrop(tbkd, tbkd, DragDropEffects.Move);
        }

        private void canvasNorthOtherDetector1_Drop(object sender, System.Windows.DragEventArgs e)
        {
            e.Data.GetFormats();
            if (e.Data.GetDataPresent("System.Windows.Controls.TextBlock"))
            {
                Canvas cv = sender as Canvas;
                TextBlock tbkd = e.Data.GetData("System.Windows.Controls.TextBlock") as TextBlock;
                WrapPanel wp = tbkd.Parent as WrapPanel;
                wp.Children.Remove(tbkd);
                cv.Children.Add(tbkd);
            }

            Console.WriteLine(e.Data);
        }

        private void canvasNorthOtherDetector2_Drop(object sender, System.Windows.DragEventArgs e)
        {
            e.Data.GetFormats();
            if (e.Data.GetDataPresent("System.Windows.Controls.TextBlock"))
            {
                TextBlock cv = sender as TextBlock;
                TextBlock tbkd = e.Data.GetData("System.Windows.Controls.TextBlock") as TextBlock;
                cv.Text = tbkd.Text;
                tbkd.Text = "";
                Console.WriteLine(cv.Text);
            }
        }

        private void t_Drop(object sender, System.Windows.DragEventArgs e)
        {
            e.Data.GetFormats();
            if (e.Data.GetDataPresent("System.Windows.Controls.TextBlock"))
            {
                TextBlock cv = sender as TextBlock;
                TextBlock tbkd = e.Data.GetData("System.Windows.Controls.TextBlock") as TextBlock;
                cv.Text = tbkd.Text;
                tbkd.Text = "";
                Console.WriteLine(cv.Text);
            }
        }

        private void tbkD1_Drop(object sender, System.Windows.DragEventArgs e)
        {
            e.Data.GetFormats();
            if (e.Data.GetDataPresent("System.Windows.Controls.TextBlock"))
            {
                TextBlock cv = sender as TextBlock;
                TextBlock tbkd = e.Data.GetData("System.Windows.Controls.TextBlock") as TextBlock;
                cv.Text = tbkd.Text;
                tbkd.Text = "";
                Console.WriteLine(cv.Text);
            }
        }

        public byte GetPhaseIdByDirec(byte direc)
        {
            byte result = new byte();
            //if (td == null)
            //    td = Utils.Utils.GetTscDataByApplicationCurrentProperties();
            //if (td == null)
            //    return 0;
            List<PhaseToDirec> lptd = td.ListPhaseToDirec;
            foreach (PhaseToDirec ptd in lptd)
            {
                if (ptd.ucId == direc)
                {
                    result = ptd.ucPhase;
                }
            }
            return result;
        }

        public byte GetOptionByCheckbox()
        {
            byte re = new byte();
            if (cbxCarType.IsChecked == true)
            {
                re = Convert.ToByte(re | 0x01);
            }
            if (cbxKeyRoad.IsChecked == true)
            {
                re = Convert.ToByte(re | 0x02);
            }
            if (cbxFlow.IsChecked == true)
            {
                re = Convert.ToByte(re | 0x04);
            }
            if (cbxOccupancy.IsChecked == true)
            {
                re = Convert.ToByte(re | 0x08);
            }
            if (cbxSpeed.IsChecked == true)
            {
                re = Convert.ToByte(re | 0x10);
            }
            if (cbxQueun.IsChecked == true)
            {
                re = Convert.ToByte(re | 0x20);
            }
            return re;
        }

        private byte GetDirecByte(byte direc)
        {
            byte result = new byte();
            if (direc >= Define.NORTH_TURN_AROUND && direc <= Define.NORTH_LEFT_STRAIGHT_RIGHT)
            {
                result = 0x01;
            }
            else if (direc >= Define.EAST_NORTH_TURN_AROUND && direc <= Define.EAST_NORTH_LEFT_STRAIGHT_RIGHT)
            {
                result = 0x02;
            }
            else if (direc >= Define.EAST_TURN_AROUND && direc <= Define.EAST_LEFT_STRAIGHT_RIGHT)
            {
                result = 0x04;
            }
            else if (direc >= Define.EAST_SOUTH_TURN_AROUND && direc <= Define.EAST_SOUTH_LEFT_STRAIGHT_RIGHT)
            {
                result = 0x08;
            }
            else if (direc >= Define.SOUTH_TURN_AROUND && direc <= Define.SOUTH_LEFT_STRAIGHT_RIGHT)
            {
                result = 0x10;
            }
            else if (direc >= Define.WEST_SOUTH_TURN_AROUND && direc <= Define.WEST_SOUTH_LEFT_STRAIGHT_RIGHT)
            {
                result = 0x20;
            }
            else if (direc >= Define.WEST_TURN_AROUND && direc <= Define.WEST_LEFT_STRAIGHT_RIGHT)
            {
                result = 0x40;
            }
            else if (direc >= Define.WEST_NORTH_TURN_AROUND && direc <= Define.WEST_NORTH_LEFT_STRAIGHT_RIGHT)
            {
                result = 0x80;
            }
            return result;
        }

        public byte GetDetFlag(int type, byte direc)
        {
            byte result = new byte();
            if (direc == Define.NORTH_OTHER || direc == Define.WEST_OTHER || direc == Define.EAST_OTHER ||
                direc == Define.SOUTH_OTHER)
            {
                if (type == 1)
                {
                    result = Define.DETECTOR_TYPE_STATEGY_BUS;
                }
                else if (type == 2)
                {
                    result = Define.DETECTOR_TYPE_REACTION_BUS;
                }
                else if (type == 3)
                {
                    result = Define.DETECTOR_TYPE_TACTICS_BUS;
                }
                else if (type == 4)
                {
                    result = Define.DETECTOR_TYPE_REQUEST_BUS;
                }
            }
            else if (direc == Define.NORTH_PEDESTRAIN_ONE || direc == Define.NORTH_PEDESTRAIN_TWO ||
                     direc == Define.EAST_PEDESTRAIN_ONE || direc == Define.EAST_PEDESTRAIN_TWO ||
                     direc == Define.SOUTH_PEDESTRAIN_ONE || direc == Define.SOUTH_PEDESTRAIN_TWO ||
                     direc == Define.WEST_PEDESTRAIN_ONE || direc == Define.WEST_PEDESTRAIN_TWO)
            {
                if (type == 1)
                {
                    result = Define.DETECTOR_TYPE_STATEGY_HUMAN;
                }
                else if (type == 2)
                {
                    result = Define.DETECTOR_TYPE_REACTION_HUMAN;
                }
                else if (type == 3)
                {
                    result = Define.DETECTOR_TYPE_TACTICS_HUMAN;
                }
                else if (type == 4)
                {
                    result = Define.DETECTOR_TYPE_REQUEST_HUMAN;
                }
            }
            else
            {
                if (type == 1)
                {
                    result = Define.DETECTOR_TYPE_STATEGY_CAR;
                }
                else if (type == 2)
                {
                    result = Define.DETECTOR_TYPE_REACTION_CAR;
                }
                else if (type == 3)
                {
                    result = Define.DETECTOR_TYPE_TACTICS_CAR;
                }
                else if (type == 4)
                {
                    result = Define.DETECTOR_TYPE_REQUEST_CAR;
                }
            }

            return result;
        }

        /// <summary>
        /// 设置检测器，在哪个位置都有不同的定义 
        /// 1、路口最外面的是 战略
        /// 2、路口外到内 第二个是感应
        /// 3、路口外到内 第三个是战术
        /// 4、路口 外到内第四个是请求
        /// </summary>
        /// <param name="i"></param>
        /// <param name="direc"></param>
        /// <param name="type"></param>
        public void SetDetector(int i, byte direc, int type)
        {
<<<<<<< HEAD
            Models.Detector d = new Models.Detector();
=======
            tscui.Models.Detector d = new Models.Detector();
>>>>>>> 74e4ebd174211bd2f7215c892a9bd98ddb385798
            bool newDetector = true;
            List<Models.Detector> ld = td.ListDetector;
            foreach (Models.Detector det in ld)
            {
                if (det.ucDetectorId == i)
                {
                    det.ucDetectorId = Convert.ToByte(i);
                    det.ucDetFlag = GetDetFlag(type, direc);
                    det.ucDirect = GetDirecByte(direc);
                    //det.ucOptionFlag = GetOptionByCheckbox();
                    det.ucPhaseId = GetPhaseIdByDirec(direc);
                 //   det.ucSaturationOccupy = d.ucSaturationOccupy;
                //    byte vt = 0;
                  //  if (tbkVaildTime.Text != "")
                  //  {
                  //      vt = Convert.ToByte(tbkVaildTime.Text);
                 //   }
                //    det.ucValidTime = vt;
                //    det.usSaturationFlow = d.usSaturationFlow;
                    newDetector = false;
                    break;
                }
            }
            if (newDetector == true)
            {d.ucDetectorId = Convert.ToByte(i);
                d.ucPhaseId = GetPhaseIdByDirec(direc);
                d.ucDetFlag = GetDetFlag(type, direc);
                d.ucDirect = GetDirecByte(direc);
<<<<<<< HEAD
              //  d.ucValidTime = Byte.Parse("0"); //Convert.ToByte(tbkVaildTime.Text); 
               // d.ucOptionFlag = GetOptionByCheckbox();
             //   d.usSaturationFlow = 0;
             //   d.ucSaturationOccupy = 0;
             //   newDetector = true;
=======
                d.ucValidTime = Byte.Parse("0"); //Convert.ToByte(tbkVaildTime.Text); 
                d.ucOptionFlag = GetOptionByCheckbox();
                d.usSaturationFlow = 0;
                d.ucSaturationOccupy = 0;
                newDetector = true;
>>>>>>> 74e4ebd174211bd2f7215c892a9bd98ddb385798
                ld.Add(d);
            }
        }

        public List<TextBlock> allDetecotr = new List<TextBlock>();

        /// <summary>
        /// 显示表单数据到界面上
        /// </summary>
        /// <param name="id"></param>
        public void displayOneDetector(int id)
        {
            try
            {
                List<Models.Detector> ld = td.ListDetector;
                foreach (Models.Detector d in ld)
                {
                    if (id == d.ucDetectorId)
                    {
<<<<<<< HEAD
                        SelectedDetectorId.SelectedValue = d.ucDetectorId.ToString();
                        tbkPhaseId.Text = Convert.ToString(d.ucPhaseId);byte detf = d.ucDetFlag;
=======
                        tbkPhaseId.Text = Convert.ToString(d.ucPhaseId);
                        /***********暂时没用到************
                        byte detf = d.ucDetFlag;
>>>>>>> 74e4ebd174211bd2f7215c892a9bd98ddb385798
                        if ((detf & 0x10) == 0x10)
                        {
                            rbnStategy.IsChecked = true;
                        }
                        if ((detf & 0x40) == 0x40)
                        {
                            rbnReaction.IsChecked = true;
                        }
                        if ((detf & 0x80) == 0x80)
                        {
                            rbnRequest.IsChecked = true;
                        }
                        if ((detf & 0x20) == 0x20)
                        {
                            rbnTactics.IsChecked = true;
                        }
                        if ((detf & 0x01) == 0x01)
                        {
                            rbnCar.IsChecked = true;
                        }
                        if ((detf & 0x02) == 0x02)
                        {
                            rbnBike.IsChecked = true;
                        }
                        if ((detf & 0x04) == 0x04)
                        {
                            rbnBus.IsChecked = true;
                        }
                        if ((detf & 0x08) == 0x08)
                        {
                            rbnPedestrain.IsChecked = true;
                        }

                        tbkVaildTime.Text = Convert.ToString(d.ucValidTime);
                        tbxFlow.Text = Convert.ToString(d.usSaturationFlow);
                        tbxOccupany.Text = Convert.ToString(d.ucSaturationOccupy);
                        byte opt = d.ucOptionFlag;
                        if ((opt & 0x01) == 0x01)
                        {
                            cbxCarType.IsChecked = true;
                        }
                        else
                        {
                            cbxCarType.IsChecked = false;
<<<<<<< HEAD
                        }
                        if ((opt & 0x02) == 0x02)
                        {
                            cbxKeyRoad.IsChecked = true;
                        }
                        else
                        {
                            cbxKeyRoad.IsChecked = false;
                        }
                        if ((opt & 0x04) == 0x04)
                        {

                            cbxFlow.IsChecked = true;
                        }
                        else
                        {
                            cbxFlow.IsChecked = false;
                        }
                        if ((opt & 0x08) == 0x08)
                        {
                            cbxOccupancy.IsChecked = true;
                        }
                        else
                        {
                            cbxOccupancy.IsChecked = false;
                        }
                        if ((opt & 0x10) == 0x10)
                        {
                            cbxSpeed.IsChecked = true;
                        }
                        else
                        {
                            cbxSpeed.IsChecked = false;
                        }
                        if ((opt & 0x20) == 0x20)
                        {
                            cbxQueun.IsChecked = true;
                        }
                        else
                        {
                            cbxQueun.IsChecked = false;
                        }
                       break;
=======
                        }
                        if ((opt & 0x02) == 0x02)
                        {
                            cbxKeyRoad.IsChecked = true;
                        }
                        else
                        {
                            cbxKeyRoad.IsChecked = false;
                        }
                        if ((opt & 0x04) == 0x04)
                        {

                            cbxFlow.IsChecked = true;
                        }
                        else
                        {
                            cbxFlow.IsChecked = false;
                        }
                        if ((opt & 0x08) == 0x08)
                        {
                            cbxOccupancy.IsChecked = true;
                        }
                        else
                        {
                            cbxOccupancy.IsChecked = false;
                        }
                        if ((opt & 0x10) == 0x10)
                        {
                            cbxSpeed.IsChecked = true;
                        }
                        else
                        {
                            cbxSpeed.IsChecked = false;
                        }
                        if ((opt & 0x20) == 0x20)
                        {
                            cbxQueun.IsChecked = true;
                        }
                        else
                        {
                            cbxQueun.IsChecked = false;
                        }
                        ***********暂时没用到************/

                        break;
>>>>>>> 74e4ebd174211bd2f7215c892a9bd98ddb385798
                    }

                }
            }
            catch (Exception ex)
            {
                ;
            }
        }

        /// <summary>
        /// 清空配置当前检测器在其它方向位置上的数字显示
        /// 并显示在当前配置的位置上。
        /// </summary>
        /// <param name="id"></param>
        public void ClearDetectorId(int id)
        {

            //清空之前放到的textblock
            foreach (TextBlock tb in allDetecotr)
            {
                if (!tb.Text.Equals(""))
                {
                    if (id == Convert.ToInt32(tb.Text))
                    {
                        tb.Text = "";
                        break;
                    }
                }
            }

        }

        private void UserControl_Unloaded(object sender, RoutedEventArgs e)
        {
            try
            {
                allDetecotr.Clear();
<<<<<<< HEAD
                if (GetParamPerTime.IsChecked == true)
                    GetParamPerTime.IsChecked = false;
                if (ChkCarmonitor.IsChecked == true)
                    ChkCarmonitor.IsChecked = false;
=======
>>>>>>> 74e4ebd174211bd2f7215c892a9bd98ddb385798
                //     ThreadPool.QueueUserWorkItem(SaveDetector);
            }
            catch (Exception ex)
            {
                MessageBox.Show("车检页面退出异常!");
            }
        }

        private void SaveDetector(object state)
        {
            //td = Utils.Utils.GetTscDataByApplicationCurrentProperties();

            Message m = TscDataUtils.SetDetector(td.ListDetector);
        }

        private delegate void DelegateCheckCar();

        //private void DispatcherCheckCar(object state)
        //{
        //    this.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new DelegateCheckCar(CheckCar));
        //}


        //private List<DetectorStateObject> CheckCarByte(byte[] data)
        //{
        //    List<DetectorState> lds = new List<DetectorState>();
        //    List<DetectorStateObject> ldso = new List<DetectorStateObject>();
        //    byte[] countDownArray = new byte[Define.DETECTOR_STATE_BYTE_LEN*Define.DETECTOR_STATE_BYTE_SIZE];
        //    Array.Copy(data, 4, countDownArray, 0, Define.DETECTOR_STATE_BYTE_LEN*Define.DETECTOR_STATE_BYTE_SIZE);
        //    byte[,] twoArray = ByteUtils.oneArray2TwoArray(countDownArray, Define.DETECTOR_STATE_BYTE_LEN,
        //        Define.DETECTOR_STATE_BYTE_SIZE);
        //    DetectorState ds;
        //    DetectorStateObject dso;
        //    for (int i = 0; i < Define.DETECTOR_STATE_BYTE_LEN; i++)
        //    {
        //        ds = new DetectorState();
        //        dso = new DetectorStateObject();

        //        dso.UcDetectorStateId = twoArray[i, 0];
        //        byte state = twoArray[i, 1];
        //        if (0x01 == (byte) (state & 0x01))
        //        {
        //            dso.UcDetectorState1 = 0x01;
        //        }
        //        if (0x02 == (byte) (state & 0x02))
        //        {
        //            dso.UcDetectorState2 = 0x01;
        //        }
        //        if (0x04 == (byte) (state & 0x04))
        //        {
        //            dso.UcDetectorState3 = 0x01;
        //        }
        //        if (0x08 == (byte) (state & 0x08))
        //        {
        //            dso.UcDetectorState4 = 0x01;
        //        }
        //        if (0x10 == (byte) (state & 0x10))
        //        {
        //            dso.UcDetectorState5 = 0x01;
        //        }
        //        if (0x20 == (byte) (state & 0x20))
        //        {
        //            dso.UcDetectorState6 = 0x01;
        //        }
        //        if (0x40 == (byte) (state & 0x40))
        //        {
        //            dso.UcDetectorState7 = 0x01;
        //        }
        //        if (0x80 == (byte) (state & 0x80))
        //        {
        //            dso.UcDetectorState8 = 0x01;
        //        }
        //        byte alert = twoArray[i, 2];
        //        if (0x01 == (byte) (alert & 0x01))
        //        {
        //            dso.UcDetectorStateAlert1 = 0x01;
        //        }
        //        if (0x02 == (byte) (alert & 0x02))
        //        {
        //            dso.UcDetectorStateAlert2 = 0x01;
        //        }
        //        if (0x04 == (byte) (alert & 0x04))
        //        {
        //            dso.UcDetectorStateAlert3 = 0x01;
        //        }
        //        if (0x08 == (byte) (alert & 0x08))
        //        {
        //            dso.UcDetectorStateAlert4 = 0x01;
        //        }
        //        if (0x10 == (byte) (alert & 0x10))
        //        {
        //            dso.UcDetectorStateAlert5 = 0x01;
        //        }
        //        if (0x20 == (byte) (alert & 0x20))
        //        {
        //            dso.UcDetectorStateAlert6 = 0x01;
        //        }
        //        if (0x40 == (byte) (alert & 0x40))
        //        {
        //            dso.UcDetectorStateAlert7 = 0x01;
        //        }
        //        if (0x80 == (byte) (alert & 0x80))
        //        {
        //            dso.UcDetectorStateAlert8 = 0x01;
        //        }

        //        ds.UcDetectorStateId = twoArray[i, 0];
        //        ds.UcDetectorState = twoArray[i, 1];
        //        ds.UcDetectorStateAlert = twoArray[i, 2];
        //        lds.Add(ds);
        //        ldso.Add(dso);
        //    }
        //    return ldso;
        //}

        private DispatcherTimer checkDispatcherTimer;
<<<<<<< HEAD
        private DispatcherTimer DetecParmasGetTimer;
=======
>>>>>>> 74e4ebd174211bd2f7215c892a9bd98ddb385798

        #region 检测通道是否正常闪烁切换标记，用于检测器，接口板无此检测

        private bool isDetectorAlert1 = true;
        private bool isDetectorAlert2 = true;
        private bool isDetectorAlert3 = true;
        private bool isDetectorAlert4 = true;
        private bool isDetectorAlert5 = true;
        private bool isDetectorAlert6 = true;
        private bool isDetectorAlert7 = true;
        private bool isDetectorAlert8 = true;
        private bool isDetectorAlert9 = true;
        private bool isDetectorAlert10 = true;
        private bool isDetectorAlert11 = true;
        private bool isDetectorAlert12 = true;
        private bool isDetectorAlert13 = true;
        private bool isDetectorAlert14 = true;
        private bool isDetectorAlert15 = true;
        private bool isDetectorAlert16 = true;

        private bool isDetectorAlert17 = true;
        private bool isDetectorAlert18 = true;
        private bool isDetectorAlert19 = true;
        private bool isDetectorAlert20 = true;
        private bool isDetectorAlert21 = true;
        private bool isDetectorAlert22 = true;
        private bool isDetectorAlert23 = true;
        private bool isDetectorAlert24 = true;
        private bool isDetectorAlert25 = true;
        private bool isDetectorAlert26 = true;
        private bool isDetectorAlert27 = true;
        private bool isDetectorAlert28 = true;
        private bool isDetectorAlert29 = true;
        private bool isDetectorAlert30 = true;
        private bool isDetectorAlert31 = true;
        private bool isDetectorAlert32 = true;

        #endregion

        public class Ccheckedcar
        {
            public int Num { get; set; }
            public string ChkBoarddNo { get; set; }
            public byte ChkChannel { get; set; }
            public string CheckedTime { get; set; }
        }


     private void CheckedDispatcherTimer_Tick(object sender, EventArgs e)
        {
            List<DetectorStateObject> listDSO = DetectorStateObjects.listDetectorStateObject;
          
            if (listDSO != null)
            {
                foreach (TextBlock tb in allDetecotr)
                {
                    string sid = tb.Text.Trim();
                    if (sid.Equals(""))
                    {
                        sid = "0";
                        continue;
                    }
                        
                    byte id = Convert.ToByte(sid);

                    foreach (DetectorStateObject dso in listDSO)
                    {
                        #region  1-9-17-25-33-41-49-57通道颜色改变
                        if ((id == 1 && dso.UcDetectorStateId == 1) || (id == 9 && dso.UcDetectorStateId == 2) || (id == 17 && dso.UcDetectorStateId == 3) || (id == 25 && dso.UcDetectorStateId == 4) ||
                            (id == 33 && dso.UcDetectorStateId == 5) || (id == 41 && dso.UcDetectorStateId == 6) || (id == 49 && dso.UcDetectorStateId == 7) || (id == 57 && dso.UcDetectorStateId == 8))
                        {
                            if (dso.UcDetectorStateAlert1 != 0)
                            {
                                if (isDetectorAlert1 == true)
                                    tb.Background = Brushes.Red;
                                else
                                    tb.Background = Brushes.Transparent;
                                isDetectorAlert1 = !isDetectorAlert1;
                            }
                            else if (dso.UcDetectorState1 != 0)
                            {
                                tb.Background = Brushes.Green;
                            }
                            else
                            {
                                tb.Background = Brushes.Transparent;
                            }
                            break;
                        }
                        #endregion
                        #region 2-10-18-26-34-42-50-58通道颜色改变
                        if ((id == 2 && dso.UcDetectorStateId == 1) || (id == 10 && dso.UcDetectorStateId == 2) || (id == 18 && dso.UcDetectorStateId == 3)||(id == 26 && dso.UcDetectorStateId == 4)||
                            (id == 34 && dso.UcDetectorStateId == 5) || (id == 42 && dso.UcDetectorStateId ==6) || (id == 50 && dso.UcDetectorStateId == 7) || (id == 58 && dso.UcDetectorStateId == 8))
                         {
                          if (dso.UcDetectorStateAlert2 != 0)
                          {
                              if (isDetectorAlert2 == true)
                                  tb.Background = Brushes.Red;
                              else
                                  tb.Background = Brushes.Transparent;
                              isDetectorAlert2 = !isDetectorAlert2;
                          }
                          else if (dso.UcDetectorState2 != 0)
                          {
                              tb.Background = Brushes.Green;
                          }
                          else
                          {
                              tb.Background = Brushes.Transparent;
                          }
                          break;
                      }
#endregion
                        #region 3-11-19-27-35-43-51-59通道颜色改变
                        if ((id == 3 && dso.UcDetectorStateId == 1) || (id == 11 && dso.UcDetectorStateId == 2) || (id == 19 && dso.UcDetectorStateId == 3)||(id == 27 && dso.UcDetectorStateId == 4)||
                            (id == 35 && dso.UcDetectorStateId == 5) || (id == 43 && dso.UcDetectorStateId == 6) || (id == 51 && dso.UcDetectorStateId == 7) || (id == 59 && dso.UcDetectorStateId == 8))
                      {
                          if (dso.UcDetectorStateAlert3 != 0)
                          {
                              if (isDetectorAlert3 == true)
                                  tb.Background = Brushes.Red;
                              else
                                  tb.Background = Brushes.Transparent;
                              isDetectorAlert3 = !isDetectorAlert3;
                          }
                          else if (dso.UcDetectorState3 != 0)
                          {
                              tb.Background = Brushes.Green;
                          }
                          else
                          {
                              tb.Background = Brushes.Transparent;
                          }
                          break;
                      }
#endregion
                        #region 4-12-20-28-36-44-52-60通道颜色改变
                        if ((id ==4 && dso.UcDetectorStateId == 1) || (id == 12 && dso.UcDetectorStateId == 2) || (id == 20 && dso.UcDetectorStateId == 3) || (id == 28 && dso.UcDetectorStateId == 4)||
                            (id == 36 && dso.UcDetectorStateId == 5) || (id == 44 && dso.UcDetectorStateId == 6) || (id == 52 && dso.UcDetectorStateId == 7) || (id == 60 && dso.UcDetectorStateId == 8))
                        {
                          if (dso.UcDetectorStateAlert4 != 0)
                          {
                              if(isDetectorAlert4 == true)
                                  tb.Background = Brushes.Red;
                              else
                                  tb.Background = Brushes.Transparent;
                              isDetectorAlert4 = !isDetectorAlert4;
                          }
                          else if (dso.UcDetectorState4 != 0)
                          {
                              tb.Background = Brushes.Green;
                          }
                          else
                          {
                              tb.Background = Brushes.Transparent;
                          }
                          break;
                      }
#endregion
                        #region 5-13-21-29-37-45-53-61通道颜色改变
                        if ((id == 5 && dso.UcDetectorStateId == 1) || (id == 13 && dso.UcDetectorStateId == 2) || (id == 21 && dso.UcDetectorStateId == 3)||(id == 29 && dso.UcDetectorStateId == 4)||
                            (id == 37 && dso.UcDetectorStateId == 5) || (id == 45 && dso.UcDetectorStateId == 6) || (id == 53 && dso.UcDetectorStateId == 7) || (id == 61 && dso.UcDetectorStateId == 8))
                      {
                          if (dso.UcDetectorStateAlert5 != 0)
                          {
                              if (isDetectorAlert5 == true)
                                  tb.Background = Brushes.Red;
                              else
                                  tb.Background = Brushes.Transparent;
                              isDetectorAlert5 = !isDetectorAlert5;
                          }
                          else if (dso.UcDetectorState5 != 0)
                          {
                              tb.Background = Brushes.Green;
                          }
                          else
                          {
                              tb.Background = Brushes.Transparent;
                          }
                          break;
                      }
#endregion
                        #region 6-14-22-30-38-46-54-62通道颜色改变
                        if ((id == 6 && dso.UcDetectorStateId == 1) || (id == 14 && dso.UcDetectorStateId == 2) || (id == 22 && dso.UcDetectorStateId == 3) || (id == 30 && dso.UcDetectorStateId == 4)||
                            (id == 38 && dso.UcDetectorStateId == 5) || (id == 46 && dso.UcDetectorStateId == 6) || (id == 54 && dso.UcDetectorStateId == 7) || (id == 62 && dso.UcDetectorStateId == 8))
                        {
                          if (dso.UcDetectorStateAlert6 != 0)
                          {
                              if (isDetectorAlert6 == true)
                                  tb.Background = Brushes.Red;
                              else
                                  tb.Background = Brushes.Transparent;
                              isDetectorAlert6 = !isDetectorAlert6;
                          }
                          else if (dso.UcDetectorState6 != 0)
                          {
                              tb.Background = Brushes.Green;
                          }
                          else
                          {
                              tb.Background = Brushes.Transparent;
                          }
                          break;
                      }
#endregion
                        #region 7-15-23-31-39-47-55-63通道颜色改变
                        if ((id == 7 && dso.UcDetectorStateId == 1) || (id == 15 && dso.UcDetectorStateId == 2) || (id == 23 && dso.UcDetectorStateId == 3)||(id == 31 && dso.UcDetectorStateId == 4)||
                            (id == 39 && dso.UcDetectorStateId == 5) || (id == 47 && dso.UcDetectorStateId == 6) || (id == 55 && dso.UcDetectorStateId == 7) || (id == 63 && dso.UcDetectorStateId == 8))
                      {
                          if (dso.UcDetectorStateAlert7 != 0)
                          {
                              if (isDetectorAlert7 == true)
                                  tb.Background = Brushes.Red;
                              else
                                  tb.Background = Brushes.Transparent;
                              isDetectorAlert7 = !isDetectorAlert7;
                          }
                          else if (dso.UcDetectorState7 != 0)
                          {
                              tb.Background = Brushes.Green;
                          }
                          else
                          {
                              tb.Background = Brushes.Transparent;
                          }
                          break;
                      }
#endregion
                        #region 8-16-24-32-40-48-56-64通道颜色改变
                        if ((id == 8 && dso.UcDetectorStateId == 1) || (id == 16 && dso.UcDetectorStateId == 2) || (id == 24 && dso.UcDetectorStateId == 3) || (id == 32 && dso.UcDetectorStateId == 4)||
                            (id == 40 && dso.UcDetectorStateId == 5) || (id == 48 && dso.UcDetectorStateId ==6) || (id == 56 && dso.UcDetectorStateId == 7) || (id == 64 && dso.UcDetectorStateId == 8))
                        {
                          if (dso.UcDetectorStateAlert8 != 0)
                          {
                              if (isDetectorAlert8 == true)
                                  tb.Background = Brushes.Red;
                              else
                                  tb.Background = Brushes.Transparent;
                              isDetectorAlert8 = !isDetectorAlert8;
                          }
                          else if (dso.UcDetectorState8 != 0)
                          {
                              tb.Background = Brushes.Green;
                          }
                          else
                          {
                              tb.Background = Brushes.Transparent;
                          }
                          break;
                      }
#endregion
                    }
                    if (tb.Background.Equals(Brushes.Green))
                    {
                        Ccheckedcar chkedcar = new Ccheckedcar();
                        chkedcar.Num = Listcheckcar.Items.Count + 1;
                        chkedcar.ChkBoarddNo = (id > 16) ?((id > 32)?((id>64)?"接口板2":"接口板1"):"检测器板2"):"检测器板1";
                        chkedcar.ChkChannel = id;
                        chkedcar.CheckedTime = DateTime.Now.ToString("MM-dd HH:mm:ss");
<<<<<<< HEAD
                        if( Listcheckcar.Items.Count >500)
                             Listcheckcar.Items.Clear();
=======
>>>>>>> 74e4ebd174211bd2f7215c892a9bd98ddb385798
                        Listcheckcar.Items.Add(chkedcar);
                    }
                }
            }
        }


        private delegate void DelegateInitAllDetector();
        private void DispatcherInitAllDetector(object state)
        {
            this.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new DelegateInitAllDetector(InitAllDetector));
        }
        private void InitAllDetector()
        {
            allDetecotr.Add(this.detectorEastLeft1);
            allDetecotr.Add(this.detectorEastLeft2);
            allDetecotr.Add(this.detectorEastLeft3);
            allDetecotr.Add(this.detectorEastLeft4);
            allDetecotr.Add(this.detectorEastOther1);
            allDetecotr.Add(this.detectorEastOther2);
            allDetecotr.Add(this.detectorEastOther3);
            allDetecotr.Add(this.detectorEastOther4);
            allDetecotr.Add(this.detectorEastRight1);
            allDetecotr.Add(this.detectorEastRight2);
            allDetecotr.Add(this.detectorEastRight3);
            allDetecotr.Add(this.detectorEastRight4);
            allDetecotr.Add(this.detectorEastStraight1);
            allDetecotr.Add(this.detectorEastStraight2);
            allDetecotr.Add(this.detectorEastStraight3);
            allDetecotr.Add(this.detectorEastStraight4);
            allDetecotr.Add(this.detectorNorthLeft1);
            allDetecotr.Add(this.detectorNorthLeft2);
            allDetecotr.Add(this.detectorNorthLeft3);
            allDetecotr.Add(this.detectorNorthLeft4);
            allDetecotr.Add(this.detectorNorthOther1);
            allDetecotr.Add(this.detectorNorthOther2);
            allDetecotr.Add(this.detectorNorthOther3);
            allDetecotr.Add(this.detectorNorthOther4);
            allDetecotr.Add(this.detectorNorthRight1);
            allDetecotr.Add(this.detectorNorthRight2);
            allDetecotr.Add(this.detectorNorthRight3);
            allDetecotr.Add(this.detectorNorthRight4);
            allDetecotr.Add(this.detectorNorthStraight1);
            allDetecotr.Add(this.detectorNorthStraight2);
            allDetecotr.Add(this.detectorNorthStraight3);
            allDetecotr.Add(this.detectorNorthStraight4);
            allDetecotr.Add(this.detectorSouthLeft1);
            allDetecotr.Add(this.detectorSouthLeft2);
            allDetecotr.Add(this.detectorSouthLeft3);
            allDetecotr.Add(this.detectorSouthLeft4);
            allDetecotr.Add(this.detectorSouthOther1);
            allDetecotr.Add(this.detectorSouthOther2);
            allDetecotr.Add(this.detectorSouthOther3);
            allDetecotr.Add(this.detectorSouthOther4);
            allDetecotr.Add(this.detectorSouthRight2);
            allDetecotr.Add(this.detectorSouthRight1);
            allDetecotr.Add(this.detectorSouthRight3);
            allDetecotr.Add(this.detectorSouthRight4);
            allDetecotr.Add(this.detectorSouthStraight1);
            allDetecotr.Add(this.detectorSouthStraight2);
            allDetecotr.Add(this.detectorSouthStraight3);
            allDetecotr.Add(this.detectorSouthStraight4);
            allDetecotr.Add(this.detectorWestLeft1);
            allDetecotr.Add(this.detectorWestLeft2);
            allDetecotr.Add(this.detectorWestLeft3);
            allDetecotr.Add(this.detectorWestLeft4);
            allDetecotr.Add(this.detectorWestOther1);
            allDetecotr.Add(this.detectorWestOther2);
            allDetecotr.Add(this.detectorWestOther3);
            allDetecotr.Add(this.detectorWestOther4);
            allDetecotr.Add(this.detectorWestRight1);
            allDetecotr.Add(this.detectorWestRight2);
            allDetecotr.Add(this.detectorWestRight3);
            allDetecotr.Add(this.detectorWestRight4);
            allDetecotr.Add(this.detectorWestStraight1);
            allDetecotr.Add(this.detectorWestStraight2);
            allDetecotr.Add(this.detectorWestStraight3);
            allDetecotr.Add(this.detectorWestStraight4);
            initDetectorDisplayTb();
        }
        private void displayDetectorId(byte id,tscui.Models.Detector d)
        {
            if (id == 0x01)//北左
            {
                if (0x10 == (d.ucDetFlag & 0x10)) // 战略线圈，属于最远一个线圈
                {
                    detectorNorthLeft1.Text = Convert.ToString(d.ucDetectorId);
                }
                else if (0x20 == (d.ucDetFlag & 0x20))// 战术线圈，属于第二远一个线圈
                {
                    detectorNorthLeft2.Text = Convert.ToString(d.ucDetectorId);
                }
                else if (0x40 == (d.ucDetFlag & 0x40))// 感应线圈，属于比较近一个线圈
                {
                    detectorNorthLeft3.Text = Convert.ToString(d.ucDetectorId);
                }
                else if (0x80 == (d.ucDetFlag & 0x80))// 请求线圈，属于最近一个线圈
                {
                    detectorNorthLeft4.Text = Convert.ToString(d.ucDetectorId);
                }
            }
            else if (id == 0x02) //北直
            {
                if (0x10 == (d.ucDetFlag & 0x10)) // 战略线圈，属于最远一个线圈
                {
                    detectorNorthStraight1.Text = Convert.ToString(d.ucDetectorId);
                }
                else if (0x20 == (d.ucDetFlag & 0x20))// 战术线圈，属于第二远一个线圈
                {
                    detectorNorthStraight2.Text = Convert.ToString(d.ucDetectorId);
                }
                else if (0x40 == (d.ucDetFlag & 0x40))// 感应线圈，属于比较近一个线圈
                {
                    detectorNorthStraight3.Text = Convert.ToString(d.ucDetectorId);
                }
                else if (0x80 == (d.ucDetFlag & 0x80))// 请求线圈，属于最近一个线圈
                {
                    detectorNorthStraight4.Text = Convert.ToString(d.ucDetectorId);
                }
            }
            else if (id == 0x04)//北右
            {
                if (0x10 == (d.ucDetFlag & 0x10)) // 战略线圈，属于最远一个线圈
                {
                    detectorNorthRight1.Text = Convert.ToString(d.ucDetectorId);
                }
                else if (0x20 == (d.ucDetFlag & 0x20))// 战术线圈，属于第二远一个线圈
                {
                    detectorNorthRight2.Text = Convert.ToString(d.ucDetectorId);
                }
                else if (0x40 == (d.ucDetFlag & 0x40))// 感应线圈，属于比较近一个线圈
                {
                    detectorNorthRight3.Text = Convert.ToString(d.ucDetectorId);
                }
                else if (0x80 == (d.ucDetFlag & 0x80))// 请求线圈，属于最近一个线圈
                {
                    detectorNorthRight4.Text = Convert.ToString(d.ucDetectorId);
                }
            }
            else if (id == 0x41)//东左
            {
                if (0x10 == (d.ucDetFlag & 0x10)) // 战略线圈，属于最远一个线圈
                {
                    detectorEastLeft1.Text = Convert.ToString(d.ucDetectorId);
                }
                else if (0x20 == (d.ucDetFlag & 0x20))// 战术线圈，属于第二远一个线圈
                {
                    detectorEastLeft2.Text = Convert.ToString(d.ucDetectorId);
                }
                else if (0x40 == (d.ucDetFlag & 0x40))// 感应线圈，属于比较近一个线圈
                {
                    detectorEastLeft3.Text = Convert.ToString(d.ucDetectorId);
                }
                else if (0x80 == (d.ucDetFlag & 0x80))// 请求线圈，属于最近一个线圈
                {
                    detectorEastLeft4.Text = Convert.ToString(d.ucDetectorId);
                }
            }
            else if (id == 0x42)//东直
            {
                if (0x10 == (d.ucDetFlag & 0x10)) // 战略线圈，属于最远一个线圈
                {
                    detectorEastStraight1.Text = Convert.ToString(d.ucDetectorId);
                }
                else if (0x20 == (d.ucDetFlag & 0x20))// 战术线圈，属于第二远一个线圈
                {
                    detectorEastStraight2.Text = Convert.ToString(d.ucDetectorId);
                }
                else if (0x40 == (d.ucDetFlag & 0x40))// 感应线圈，属于比较近一个线圈
                {
                    detectorEastStraight3.Text = Convert.ToString(d.ucDetectorId);
                }
                else if (0x80 == (d.ucDetFlag & 0x80))// 请求线圈，属于最近一个线圈
                {
                    detectorEastStraight4.Text = Convert.ToString(d.ucDetectorId);
                }
            }
            else if (id == 0x44)//东右
            {
                if (0x10 == (d.ucDetFlag & 0x10)) // 战略线圈，属于最远一个线圈
                {
                    detectorEastRight1.Text = Convert.ToString(d.ucDetectorId);
                }
                else if (0x20 == (d.ucDetFlag & 0x20))// 战术线圈，属于第二远一个线圈
                {
                    detectorEastRight2.Text = Convert.ToString(d.ucDetectorId);
                }
                else if (0x40 == (d.ucDetFlag & 0x40))// 感应线圈，属于比较近一个线圈
                {
                    detectorEastRight3.Text = Convert.ToString(d.ucDetectorId);
                }
                else if (0x80 == (d.ucDetFlag & 0x80))// 请求线圈，属于最近一个线圈
                {
                    detectorEastRight4.Text = Convert.ToString(d.ucDetectorId);
                }
            }
            else if (id == 0x81)//南左
            {
                if (0x10 == (d.ucDetFlag & 0x10)) // 战略线圈，属于最远一个线圈
                {
                    detectorSouthLeft1.Text = Convert.ToString(d.ucDetectorId);
                }
                else if (0x20 == (d.ucDetFlag & 0x20))// 战术线圈，属于第二远一个线圈
                {
                    detectorSouthLeft2.Text = Convert.ToString(d.ucDetectorId);
                }
                else if (0x40 == (d.ucDetFlag & 0x40))// 感应线圈，属于比较近一个线圈
                {
                    detectorSouthLeft3.Text = Convert.ToString(d.ucDetectorId);
                }
                else if (0x80 == (d.ucDetFlag & 0x80))// 请求线圈，属于最近一个线圈
                {
                    detectorSouthLeft4.Text = Convert.ToString(d.ucDetectorId);
                }
            }
            else if (id == 0x82)//南直
            {
                if (0x10 == (d.ucDetFlag & 0x10)) // 战略线圈，属于最远一个线圈
                {
                    detectorSouthStraight1.Text = Convert.ToString(d.ucDetectorId);
                }
                else if (0x20 == (d.ucDetFlag & 0x20))// 战术线圈，属于第二远一个线圈
                {
                    detectorSouthStraight2.Text = Convert.ToString(d.ucDetectorId);
                }
                else if (0x40 == (d.ucDetFlag & 0x40))// 感应线圈，属于比较近一个线圈
                {
                    detectorSouthStraight3.Text = Convert.ToString(d.ucDetectorId);
                }
                else if (0x80 == (d.ucDetFlag & 0x80))// 请求线圈，属于最近一个线圈
                {
                    detectorSouthStraight4.Text = Convert.ToString(d.ucDetectorId);
                }
            }
            else if (id == 0x84)//南右
            {
                if (0x10 == (d.ucDetFlag & 0x10)) // 战略线圈，属于最远一个线圈
                {
                    detectorSouthRight1.Text = Convert.ToString(d.ucDetectorId);
                }
                else if (0x20 == (d.ucDetFlag & 0x20))// 战术线圈，属于第二远一个线圈
                {
                    detectorSouthRight2.Text = Convert.ToString(d.ucDetectorId);
                }
                else if (0x40 == (d.ucDetFlag & 0x40))// 感应线圈，属于比较近一个线圈
                {
                    detectorSouthRight3.Text = Convert.ToString(d.ucDetectorId);
                }
                else if (0x80 == (d.ucDetFlag & 0x80))// 请求线圈，属于最近一个线圈
                {
                    detectorSouthRight4.Text = Convert.ToString(d.ucDetectorId);
                }
            }
            else if (id == 0xc1)//西左
            {
                if (0x10 == (d.ucDetFlag & 0x10)) // 战略线圈，属于最远一个线圈
                {
                    detectorWestLeft1.Text = Convert.ToString(d.ucDetectorId);
                }
                else if (0x20 == (d.ucDetFlag & 0x20))// 战术线圈，属于第二远一个线圈
                {
                    detectorWestLeft2.Text = Convert.ToString(d.ucDetectorId);
                }
                else if (0x40 == (d.ucDetFlag & 0x40))// 感应线圈，属于比较近一个线圈
                {
                    detectorWestLeft3.Text = Convert.ToString(d.ucDetectorId);
                }
                else if (0x80 == (d.ucDetFlag & 0x80))// 请求线圈，属于最近一个线圈
                {
                    detectorWestLeft4.Text = Convert.ToString(d.ucDetectorId);
                }
            }
            else if (id == 0xc2)//西直
            {
                if (0x10 == (d.ucDetFlag & 0x10)) // 战略线圈，属于最远一个线圈
                {
                    detectorWestStraight1.Text = Convert.ToString(d.ucDetectorId);
                }
                else if (0x20 == (d.ucDetFlag & 0x20))// 战术线圈，属于第二远一个线圈
                {
                    detectorWestStraight2.Text = Convert.ToString(d.ucDetectorId);
                }
                else if (0x40 == (d.ucDetFlag & 0x40))// 感应线圈，属于比较近一个线圈
                {
                    detectorWestStraight3.Text = Convert.ToString(d.ucDetectorId);
                }
                else if (0x80 == (d.ucDetFlag & 0x80))// 请求线圈，属于最近一个线圈
                {
                    detectorWestStraight4.Text = Convert.ToString(d.ucDetectorId);
                }
            }
            else if (id == 0xc4)//西右
            {
                if (0x10 == (d.ucDetFlag & 0x10)) // 战略线圈，属于最远一个线圈
                {
                    detectorWestRight1.Text = Convert.ToString(d.ucDetectorId);
                }
                else if (0x20 == (d.ucDetFlag & 0x20))// 战术线圈，属于第二远一个线圈
                {
                    detectorWestRight2.Text = Convert.ToString(d.ucDetectorId);
                }
                else if (0x40 == (d.ucDetFlag & 0x40))// 感应线圈，属于比较近一个线圈
                {
                    detectorWestRight3.Text = Convert.ToString(d.ucDetectorId);
                }
                else if (0x80 == (d.ucDetFlag & 0x80))// 请求线圈，属于最近一个线圈
                {
                    detectorWestRight4.Text = Convert.ToString(d.ucDetectorId);
                }
            }
            else if (id == 0x05)//北其它
            {
                if (0x10 == (d.ucDetFlag & 0x10)) // 战略线圈，属于最远一个线圈
                {
                    detectorNorthOther1.Text = Convert.ToString(d.ucDetectorId);
                }
                else if (0x20 == (d.ucDetFlag & 0x20))// 战术线圈，属于第二远一个线圈
                {
                    detectorNorthOther2.Text = Convert.ToString(d.ucDetectorId);
                }
                else if (0x40 == (d.ucDetFlag & 0x40))// 感应线圈，属于比较近一个线圈
                {
                    detectorNorthOther3.Text = Convert.ToString(d.ucDetectorId);
                }
                else if (0x80 == (d.ucDetFlag & 0x80))// 请求线圈，属于最近一个线圈
                {
                    detectorNorthOther4.Text = Convert.ToString(d.ucDetectorId);
                }
            }
            else if (id == 0x45)//东其它
            {
                if (0x10 == (d.ucDetFlag & 0x10)) // 战略线圈，属于最远一个线圈
                {
                    detectorEastOther1.Text = Convert.ToString(d.ucDetectorId);
                }
                else if (0x20 == (d.ucDetFlag & 0x20))// 战术线圈，属于第二远一个线圈
                {
                    detectorEastOther2.Text = Convert.ToString(d.ucDetectorId);
                }
                else if (0x40 == (d.ucDetFlag & 0x40))// 感应线圈，属于比较近一个线圈
                {
                    detectorEastOther3.Text = Convert.ToString(d.ucDetectorId);
                }
                else if (0x80 == (d.ucDetFlag & 0x80))// 请求线圈，属于最近一个线圈
                {
                    detectorEastOther4.Text = Convert.ToString(d.ucDetectorId);
                }
            }
            else if (id == 0x85)//南其它
            {
                if (0x10 == (d.ucDetFlag & 0x10)) // 战略线圈，属于最远一个线圈
                {
                    detectorSouthOther1.Text = Convert.ToString(d.ucDetectorId);
                }
                else if (0x20 == (d.ucDetFlag & 0x20))// 战术线圈，属于第二远一个线圈
                {
                    detectorSouthOther2.Text = Convert.ToString(d.ucDetectorId);
                }
                else if (0x40 == (d.ucDetFlag & 0x40))// 感应线圈，属于比较近一个线圈
                {
                    detectorSouthOther3.Text = Convert.ToString(d.ucDetectorId);
                }
                else if (0x80 == (d.ucDetFlag & 0x80))// 请求线圈，属于最近一个线圈
                {
                    detectorSouthOther4.Text = Convert.ToString(d.ucDetectorId);
                }
            }
            else if (id == 0xc5)//西其它
            {
                if (0x10 == (d.ucDetFlag & 0x10)) // 战略线圈，属于最远一个线圈
                {
                    detectorWestOther1.Text = Convert.ToString(d.ucDetectorId);
                }
                else if (0x20 == (d.ucDetFlag & 0x20))// 战术线圈，属于第二远一个线圈
                {
                    detectorWestOther2.Text = Convert.ToString(d.ucDetectorId);
                }
                else if (0x40 == (d.ucDetFlag & 0x40))// 感应线圈，属于比较近一个线圈
                {
                    detectorWestOther3.Text = Convert.ToString(d.ucDetectorId);
                }
                else if (0x80 == (d.ucDetFlag & 0x80))// 请求线圈，属于最近一个线圈
                {
                    detectorWestOther4.Text = Convert.ToString(d.ucDetectorId);
                }
            }
        }
        private void initDetectorDisplayTb()
        {
            try
            {
                List<tscui.Models.Detector> ld = td.ListDetector;
                List<PhaseToDirec> lptd = td.ListPhaseToDirec;
                if ( ld != null && ld.Count > 0)
                {
                    foreach (tscui.Models.Detector d in ld)
                    {
                        foreach (PhaseToDirec ptd in lptd)
                        {
                            if (ptd.ucPhase == d.ucPhaseId)
                            {
                                displayDetectorId(ptd.ucId, d);
                                break;
                            }
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("加载显示车检板异常!");
            }
        }
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            //td = Utils.Utils.GetTscDataByApplicationCurrentProperties();
            if (td == null)
            {
                this.Visibility = Visibility.Hidden;
                return;
            }
            else
            {
                this.Visibility = Visibility.Visible;
            }
        //    MessageBox.Show("Load");
            ThreadPool.QueueUserWorkItem(DispatcherInitAllDetector);
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

            queryver[2] = 0x6;
            queryver[4] = 0x2;
            byte[] result8 = Udp.recvUdp(td.Node.sIpAddress, Define.GBT_PORT, queryver);
            if (result8.Length == 0xa)
               InjecBoard1Online = ((result8[5] != 0) ? true : false);
            queryver[4] = 0x3;
            byte[] result9 = Udp.recvUdp(td.Node.sIpAddress, Define.GBT_PORT, queryver);
            if (result9.Length == 0xa)
                 InjecBoard2Online = ((result9[5] != 0) ? true : false);

        }

        private void btnRead_Click(object sender, RoutedEventArgs e)
        {
           
            List<Models.Detector> ld = td.ListDetector;

            foreach(Models.Detector d in ld)
            {
                Console.WriteLine(d.ToString());
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            Message m = TscDataUtils.SetDetector(td.ListDetector);
            if (m.flag)
            {
                MessageBox.Show(m.msg,m.obj,MessageBoxButton.OK,MessageBoxImage.Information);
            }
<<<<<<< HEAD
            else{
=======
            else
            {
>>>>>>> 74e4ebd174211bd2f7215c892a9bd98ddb385798
                MessageBox.Show(m.msg, m.obj, MessageBoxButton.OK, MessageBoxImage.Error);
            }
            SelectedDetectorId.ItemsSource = null;
            SelectedDetectorId.ItemsSource = td.ListDetector;
        }

        private void cbxCarType_Checked(object sender, RoutedEventArgs e)
        {
         
            List<Models.Detector> ld = td.ListDetector;
            byte detectorId = Convert.ToByte( Utils.Utils.GetSelectedDetector());
            foreach(Models.Detector d in ld)
            {
                if (d.ucDetectorId == detectorId)
                {
                    d.ucOptionFlag = (byte)(d.ucOptionFlag | 0x01);
                    return;
                }
            }
        }

        private void cbxCarType_Unchecked(object sender, RoutedEventArgs e)
        {
           
            List<Models.Detector> ld = td.ListDetector;
            byte detectorId = Convert.ToByte(Utils.Utils.GetSelectedDetector());
            foreach (Models.Detector d in ld)
            {
                if (d.ucDetectorId == detectorId)
                {
                    d.ucOptionFlag = (byte)(d.ucOptionFlag & 0xfe);
                    return;
                }
            }
        }

        private void cbxKeyRoad_Unchecked(object sender, RoutedEventArgs e)
        {
            List<Models.Detector> ld = td.ListDetector;
            byte detectorId = Convert.ToByte(Utils.Utils.GetSelectedDetector());
            foreach (Models.Detector d in ld)
            {
                if (d.ucDetectorId == detectorId)
                {
                    d.ucOptionFlag = (byte)(d.ucOptionFlag & 0xfd);
                    return;
                }
            }
        }

        private void cbxKeyRoad_Checked(object sender, RoutedEventArgs e)
        {
            List<Models.Detector> ld = td.ListDetector;
            byte detectorId = Convert.ToByte(Utils.Utils.GetSelectedDetector());
            foreach (Models.Detector d in ld)
            {
                if (d.ucDetectorId == detectorId)
                {
                    d.ucOptionFlag = (byte)(d.ucOptionFlag | 0x02);
                    return;
                }
            }
        }

        private void cbxFlow_Checked(object sender, RoutedEventArgs e)
        {
            List<Models.Detector> ld = td.ListDetector;
            byte detectorId = Convert.ToByte(Utils.Utils.GetSelectedDetector());
            foreach (Models.Detector d in ld)
            {
                if (d.ucDetectorId == detectorId)
                {
                    d.ucOptionFlag = (byte)(d.ucOptionFlag | 0x04);
                    return;
                }
            }
        }

        private void cbxOccupancy_Unchecked(object sender, RoutedEventArgs e)
        {
            List<Models.Detector> ld = td.ListDetector;
            byte detectorId = Convert.ToByte(Utils.Utils.GetSelectedDetector());
            foreach (Models.Detector d in ld)
            {
                if (d.ucDetectorId == detectorId)
                {
                    d.ucOptionFlag = (byte)(d.ucOptionFlag & 0xf7);
                    return;
                }
            }
        }

        private void cbxFlow_Unchecked(object sender, RoutedEventArgs e)
        {
            List<Models.Detector> ld = td.ListDetector;
            byte detectorId = Convert.ToByte(Utils.Utils.GetSelectedDetector());
            foreach (Models.Detector d in ld)
            {
                if (d.ucDetectorId == detectorId)
                {
                    d.ucOptionFlag = (byte)(d.ucOptionFlag & 0xfb);
                    return;
                }
            }
        }

        private void cbxSpeed_Unchecked(object sender, RoutedEventArgs e)
        {
            List<Models.Detector> ld = td.ListDetector;
            byte detectorId = Convert.ToByte(Utils.Utils.GetSelectedDetector());
            foreach (Models.Detector d in ld)
            {
                if (d.ucDetectorId == detectorId)
                {
                    d.ucOptionFlag = (byte)(d.ucOptionFlag & 0xef);
                    return;
                }
            }
        }

        private void cbxQueun_Unchecked(object sender, RoutedEventArgs e)
        {
            List<Models.Detector> ld = td.ListDetector;
            byte detectorId = Convert.ToByte(Utils.Utils.GetSelectedDetector());
            foreach (Models.Detector d in ld)
            {
                if (d.ucDetectorId == detectorId)
                {
                    d.ucOptionFlag = (byte)(d.ucOptionFlag & 0xdf);
                    return;
                }
            }
        }

        private void cbxOccupancy_Checked(object sender, RoutedEventArgs e)
        {
            td = Utils.Utils.GetTscDataByApplicationCurrentProperties();
            if (td == null)
                return;
            List<Models.Detector> ld = td.ListDetector;
            byte detectorId = Convert.ToByte(Utils.Utils.GetSelectedDetector());
            foreach (Models.Detector d in ld)
            {
                if (d.ucDetectorId == detectorId)
                {
                    d.ucOptionFlag = (byte)(d.ucOptionFlag | 0x08);
                    return;
                }
            }
        }

        private void cbxSpeed_Checked(object sender, RoutedEventArgs e)
        {
            td = Utils.Utils.GetTscDataByApplicationCurrentProperties();
            if (td == null)
                return;
            List<Models.Detector> ld = td.ListDetector;
            byte detectorId = Convert.ToByte(Utils.Utils.GetSelectedDetector());
            foreach (Models.Detector d in ld)
            {
                if (d.ucDetectorId == detectorId)
                {
                    d.ucOptionFlag = (byte)(d.ucOptionFlag | 0x10);
                    return;
                }
            }
        }

        private void cbxQueun_Checked(object sender, RoutedEventArgs e)
        {
            td = Utils.Utils.GetTscDataByApplicationCurrentProperties();
            if (td == null)
                return;
            List<Models.Detector> ld = td.ListDetector;
            byte detectorId = Convert.ToByte(Utils.Utils.GetSelectedDetector());
            foreach (Models.Detector d in ld)
            {
                if (d.ucDetectorId == detectorId)
                {
                    d.ucOptionFlag = (byte)(d.ucOptionFlag | 0x20);
                    return;
                }
            }
        }

        private void tbxFlow_TextChanged(object sender, TextChangedEventArgs e)
        {
            td = Utils.Utils.GetTscDataByApplicationCurrentProperties();
            if (td == null)
                return;
            List<Models.Detector> ld = td.ListDetector;
            byte detectorId = Convert.ToByte(Utils.Utils.GetSelectedDetector());
            foreach (Models.Detector d in ld)
            {
                if (d.ucDetectorId == detectorId)
                {
                    d.usSaturationFlow = Convert.ToInt16(tbxFlow.Text);
                    return;
                }
            }
        }

        private void tbxOccupany_TextChanged(object sender, TextChangedEventArgs e)
        {
            td = Utils.Utils.GetTscDataByApplicationCurrentProperties();
            if (td == null)
                return;
            List<Models.Detector> ld = td.ListDetector;
            byte detectorId = Convert.ToByte(Utils.Utils.GetSelectedDetector());
            foreach (Models.Detector d in ld)
            {
                if (d.ucDetectorId == detectorId)
                {
                    d.ucSaturationOccupy = Convert.ToByte(tbxOccupany.Text);
                    return;
                }
            }
        }

        private void tbkVaildTime_TextChanged(object sender, TextChangedEventArgs e)
        {
           
            List<Models.Detector> ld = td.ListDetector;
            byte detectorId = Convert.ToByte(Utils.Utils.GetSelectedDetector());
            foreach (Models.Detector d in ld)
            {
                if (d.ucDetectorId == detectorId)
                {
                    d.ucValidTime = Convert.ToByte(tbkVaildTime.Text);
                    return;
                }
            }
        }


        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
         
            Udp.StartReceiveCheckCar();
            Udp.sendUdpCheckCar(td.Node.sIpAddress, td.Node.iPort, Define.DETECTOR_STATUS_TABLE);
           
            checkDispatcherTimer = new DispatcherTimer();
            checkDispatcherTimer.Tick += new EventHandler(CheckedDispatcherTimer_Tick);
<<<<<<< HEAD
            checkDispatcherTimer.Interval = new TimeSpan(0,0,0,1); //500ms refresh
           checkDispatcherTimer.Start();
=======
            checkDispatcherTimer.Interval = new TimeSpan(0,0,0,0,500); //500ms refresh
           
            checkDispatcherTimer.Start();
>>>>>>> 74e4ebd174211bd2f7215c892a9bd98ddb385798
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            checkDispatcherTimer.Stop();
            Udp.sendUdpCheckCar(td.Node.sIpAddress, td.Node.iPort, Define.DETECTOR_DISABLED_STATUS_TABLE);
            Udp.CloseCheckCar();
<<<<<<< HEAD

        }

        private void Listcheckcar_MouseRightButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Listcheckcar.Items.Clear();
        }

        private void SelectedDetectorId_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           // MessageBox.Show(SelectedDetectorId.SelectedValue.ToString());
            int SeletedDetId = Convert.ToInt32(SelectedDetectorId.SelectedValue);
            if (SeletedDetId > 0)
            {
                Utils.Utils.SetSelectedDetector(SeletedDetId);
                displayOneDetector(SeletedDetId);
            }
            }

        private void CheckBox_Checked1(object sender, RoutedEventArgs e)
        {
            DetecParmasGetTimer = new DispatcherTimer();
            DetecParmasGetTimer.Tick += new EventHandler(CheckedDispatcherTimer1_Tick);
            DetecParmasGetTimer.Interval = new TimeSpan(0, 0, 5); //500ms refresh
            DetecParmasGetTimer.Start();
        }

        private void CheckedDispatcherTimer1_Tick(object sender, EventArgs e)
        {
            try
            {

                td.ListDetector = TscDataUtils.GetDetector();
                GridDectorsParams.ItemsSource = null;
                GridDectorsParams.ItemsSource = td.ListDetector;
            }
            catch (Exception ex)
            {
               // MessageBox.Show("检测器表加载异常!", "信号机", MessageBoxButton.OK, MessageBoxImage.Exclamation);

            }
        }

        private void CheckBox1_Unchecked(object sender, RoutedEventArgs e)
        {
            DetecParmasGetTimer.Stop();
        }
        public void CreateChart()
        {
            //_chart = new Chart(); //new一个图表元素
           // _chart.Height = 400;
            Chart char1 = new Chart();
            Title title = new Title();
            title.Text = "车检动态流量图表/分";
            Title title1 = new Title();
            title1.Text = "以分钟为单位";
            DetectorsChart.Titles.Add(title);//为图表添加一个Title
            DetectorsChart.Titles.Add(title1);
            Axis charAxisX = new Axis();
            charAxisX.Title = "检测器通道图1";
            DetectorsChart.AxesX.Add(charAxisX);//为图表添加一个AxesX

            Axis charAxisX1 = new Axis();
            charAxisX1.Title = "检测器通道图2";
            DetectorsChart.AxesX.Add(charAxisX1);//为图表添加一个AxesX

            Axis charAxisY = new Axis();
            charAxisY.Title = "车流量";
            DetectorsChart.AxesY.Add(charAxisY);//我图表添加一个AxesY

            Axis charAxisY1 = new Axis();
            charAxisY1.Title = "排队长度";
            charAxisY1.AxisType = AxisTypes.Secondary;
            DetectorsChart.AxesY.Add(charAxisY1);//我图表添加一个AxesY


            DetectorsChart.View3D = false;//图表以3D展示
            DetectorsChart.AnimationEnabled = false;
            Random rnd = new Random();//new一个随机数生成器

            DataPoint dataPoint;//数据点
            DataSeries dataSeries = new DataSeries();//数据系列
            dataSeries.RenderAs = RenderAs.StackedBar;//柱形展示
            dataSeries.LabelEnabled = true;
            dataSeries.LabelStyle = LabelStyles.Inside;
            dataSeries.LegendText = "检测器板";

            DataPoint dataPoint1;//数据点
            DataSeries dataSeries1 = new DataSeries();//数据系列
            dataSeries1.RenderAs = RenderAs.StackedColumn;//柱形展示
            dataSeries1.LabelEnabled = true;
            dataSeries1.LabelStyle = LabelStyles.Inside;
            dataSeries1.LegendText = "接口板";



            for (int i = 1; i <= 16; i++)
            {
                dataPoint = new DataPoint();

                dataPoint.AxisXLabel = "CH" + i; //x轴标签：时间
                dataPoint.YValue = rnd.Next(0, 50);//y轴值
                dataSeries.DataPoints.Add(dataPoint);//为数据系列添加一个数据点
            }

            for (int i = 1; i <= 32; i++)
            {
                dataPoint1 = new DataPoint();

                dataPoint1.AxisXLabel = "JT" + i; //x轴标签：时间

                dataPoint1.YValue = rnd.Next(10, 200);//y轴值
                dataSeries1.DataPoints.Add(dataPoint1);//为数据系列添加一个数据点
                dataSeries1.AxisYType = AxisTypes.Secondary;//次要轴线赋值

            }

            DetectorsChart.Series.Add(dataSeries);//为图表添加一个数据系列

            // _chart.Series.Add(dataSeries1);
            DetectorsChart.Theme = "Theme2";
            //  elementHost1.Child = _chart;
           // LayoutRoot.Children.Add(_chart);
            //  LayoutRoot.Children.Add(_chart);



            Random rand = new Random(DateTime.Now.Millisecond);     // Create a random class variable
        }

        private void charttypecbx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (charttypecbx.SelectedIndex >= 0x0 && DetectorsChart.Series.Count>0x0)
            {
                Byte selectIndex = (Byte)charttypecbx.SelectedIndex;
                switch (selectIndex)
                {
                    case 0x0:
                        (DetectorsChart.Series[0]).RenderAs = RenderAs.StackedBar;
                        break;
                    case 0x1:
                        (DetectorsChart.Series[0]).RenderAs = RenderAs.StackedColumn;
                        break;
                    case 0x2:
                        (DetectorsChart.Series[0]).RenderAs = RenderAs.Line;
                        break;                  
                    case 0x3:
                        (DetectorsChart.Series[0]).RenderAs = RenderAs.Radar;
                        break;
                }

            }
=======

>>>>>>> 74e4ebd174211bd2f7215c892a9bd98ddb385798
        }

        private void Listcheckcar_MouseRightButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Listcheckcar.Items.Clear();
        }
    }
}
