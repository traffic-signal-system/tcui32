using System;
using Apex.MVVM;
using tscui.Models;
using System.Windows;
using tscui.Service;

namespace tscui.Pages.Config
{
    /// <summary>
    /// The VariableSignViewModel ViewModel class.
    /// </summary>
    [ViewModel]
    public class ConfigViewModel : PageViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="VariableSignViewModel"/> class.
        /// </summary>
        public ConfigViewModel()
        {
            //  TODO: Use the following snippets to help build viewmodels:
            //      apexnp - Creates a Notifying Property
            //      apexc - Creates a Command.
            Title = (string)App.Current.Resources.MergedDictionaries[3]["tsc_menu_config"];
            SaveYellowFlashCommand = new Command(DoSaveYellowFlashCommand);
            BuildSNCommand = new Command(DoBuildSNCommand);
            SetLampCheckCommand = new Command(DoSetLampCheckCommand);
            SetCountDownCommand = new Command(DoSetCountDownCommand);
        }
        public Command SetCountDownCommand { get; private set; }
        private void DoSetCountDownCommand(object parameter)
        {
           //
        }

        public Command SetLampCheckCommand { get; private set; }
        private void DoSetLampCheckCommand(object parameter)
        {
            //Define.BUILD_SN;
            try
            {
                TscData t = Utils.Utils.GetTscDataByApplicationCurrentProperties();
                Udp.sendUdp(t.Node.sIpAddress, Define.GBT_PORT, Define.BUILD_SN);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        public Command SaveYellowFlashCommand { get; private set; }
        private void DoSaveYellowFlashCommand(object parameter)
        {
            //Define.SET_HARDWAVE_FLASH;
            byte[] bytes = new byte[2];
            
            byte syfr = sldYellowFlashRate;
            byte sdr = sldDutyRatio;
            bool rfs = rdoFlashSynch;
            bool rfa = rdoFlashAsynch;
            //占空比
            switch (sdr)
            {
                case 1:
                    bytes[0] = (byte)(bytes[0] | 0x00);
                    break;
                case 2:
                    bytes[0] = (byte)(bytes[0] | 0x10);
                    break;
                case 3:
                    bytes[0] = (byte)(bytes[0] | 0x20);
                    break;
                case 4:
                    bytes[0] = (byte)(bytes[0] | 0x30);
                    break;
                case 5:
                    bytes[0] = (byte)(bytes[0] | 0x40);
                    break;
                case 6:
                    bytes[0] = (byte)(bytes[0] | 0x50);
                    break;
                case 7:
                    bytes[0] = (byte)(bytes[0] | 0x60);
                    break;
                case 8:
                    bytes[0] = (byte)(bytes[0] | 0x70);
                    break;
                case 9:
                    bytes[0] = (byte)(bytes[0] | 0x80);
                    break;
                case 10:
                    bytes[0] = (byte)(bytes[0] | 0x90);

                    break;
                case 11:
                    bytes[0] = (byte)(bytes[0] | 0xa0);

                    break;
                case 12:
                    bytes[0] = (byte)(bytes[0] | 0xb0);

                    break;
                case 13:
                    bytes[0] = (byte)(bytes[0] | 0xc0);

                    break;
                case 14:
                    bytes[0] = (byte)(bytes[0] | 0xd0);

                    break;
                case 15:
                    bytes[0] = (byte)(bytes[0] | 0xe0);

                    break;
                case 16:
                    bytes[0] = (byte)(bytes[0] | 0xf0);

                    break;
                default:
                    break;
            }
            
            //黄闪频率
            switch (syfr)
            {
                case 1:
                    bytes[0] = (byte)(bytes[0] | 0x00);
                    break;
                case 2:
                    bytes[0] = (byte)(bytes[0] | 0x01);
                    break;
                case 3:
                    bytes[0] = (byte)(bytes[0] | 0x02);
                    break;
                case 4:
                    bytes[0] = (byte)(bytes[0] | 0x03);
                    break;
                case 5:
                    bytes[0] = (byte)(bytes[0] | 0x04);
                    break;
                case 6:
                    bytes[0] = (byte)(bytes[0] | 0x05);
                    break;
                case 7:
                    bytes[0] = (byte)(bytes[0] | 0x06);
                    break;
                case 8:
                    bytes[0] = (byte)(bytes[0] | 0x07);
                    break;
                case 9:
                    bytes[0] = (byte)(bytes[0] | 0x08);
                    break;
                case 10:
                    bytes[0] = (byte)(bytes[0] | 0x09);
                    
                    break;
                case 11:
                    bytes[0] = (byte)(bytes[0] | 0x0a);

                    break;
                case 12:
                    bytes[0] = (byte)(bytes[0] | 0x0b);

                    break;
                case 13:
                    bytes[0] = (byte)(bytes[0] | 0x0c);

                    break;
                case 14:
                    bytes[0] = (byte)(bytes[0] | 0x0d);

                    break;
                case 15:
                    bytes[0] = (byte)(bytes[0] | 0x0e);

                    break;
                case 16:
                    bytes[0] = (byte)(bytes[0] | 0x0f);

                    break;
                default:
                    break;
            }

            if(rfs == true)
            {
                bytes[1] = 0x01;
            }
            if(rfa == true)
            {
                bytes[1] = 0x02;
            }
            //sdr 
            Message msg = TscDataUtils.SetHardWaveFlash(bytes);
            MessageBox.Show(msg.msg);
        }
        
        public Command BuildSNCommand { get; private set; }
        private void DoBuildSNCommand(object parameter)
        {
           //Define.BUILD_SN;
            try
            {
                TscData t = Utils.Utils.GetTscDataByApplicationCurrentProperties();
                Udp.sendUdp(t.Node.sIpAddress, Define.GBT_PORT, Define.BUILD_SN);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
        /// <summary>
        /// The NotifyingProperty for the Name property.
        /// </summary>
        private NotifyingProperty SldYellowFlashRateProperty =
          new NotifyingProperty("sldYellowFlashRate", typeof(byte), default(byte));

        /// <summary>
        /// Gets or sets Name.
        /// </summary>
        /// <value>The value of Name.</value>
        public byte sldYellowFlashRate
        {
            get { return (byte)GetValue(SldYellowFlashRateProperty); }
            set { SetValue(SldYellowFlashRateProperty, value); }
        }
        
        /// <summary>
        /// The NotifyingProperty for the Name property.
        /// </summary>
        private NotifyingProperty SldDutyRatioProperty =
          new NotifyingProperty("sldDutyRatio", typeof(byte), default(byte));

        /// <summary>
        /// Gets or sets Name.rdoFlashSynch
        /// </summary>rdoFlashAsynch
        /// <value>The value of Name.</value>
        public byte sldDutyRatio
        {
            get { return (byte)GetValue(SldDutyRatioProperty); }
            set { SetValue(SldDutyRatioProperty, value); }
        }
        /// <summary>
        /// The NotifyingProperty for the Name property.
        /// </summary>
        private NotifyingProperty RdoFlashSynchProperty =
          new NotifyingProperty("rdoFlashSynch", typeof(bool), default(bool));

        /// <summary>
        /// Gets or sets Name.
        /// </summary>rdoFlashAsynch 同步闪
        /// <value>The value of Name.</value>
        public bool rdoFlashSynch
        {
            get { return (bool)GetValue(RdoFlashSynchProperty); }
            set { SetValue(RdoFlashSynchProperty, value); }
        }
        /// <summary>
        /// The NotifyingProperty for the Name property.
        /// </summary>
        private NotifyingProperty RdoFlashAsynchProperty =
          new NotifyingProperty("rdoFlashAsynch", typeof(bool), default(bool));

        /// <summary>
        /// Gets or sets 异步闪
        /// </summary>
        /// <value>The value of Name.</value>
        public bool rdoFlashAsynch
        {
            get { return (bool)GetValue(RdoFlashAsynchProperty); }
            set { SetValue(RdoFlashAsynchProperty, value); }
        }

        /// <summary>
        /// The NotifyingProperty for the Name property.
        /// </summary>
        private NotifyingProperty TxtHighTemperatureProperty =
          new NotifyingProperty("txtHighTemperature", typeof(int), default(int));

        /// <summary>
        /// Gets or sets Name.
        /// </summary>
        /// <value>The value of Name.</value>
        public int txtHighTemperature
        {
            get { return (int)GetValue(TxtHighTemperatureProperty); }
            set { SetValue(TxtHighTemperatureProperty, value); }
        }
        /// <summary>
        /// The NotifyingProperty for the Name property.
        /// </summary>
        private NotifyingProperty TxtLowTemperatureProperty =
          new NotifyingProperty("txtLowTemperature", typeof(int), default(int));

        /// <summary>
        /// Gets or sets Name.
        /// </summary>
        /// <value>The value of Name.</value>
        public int txtLowTemperature
        {
            get { return (int)GetValue(TxtLowTemperatureProperty); }
            set { SetValue(TxtLowTemperatureProperty, value); }
        }
        /// <summary>
        /// The NotifyingProperty for the Name property.
        /// </summary>
        private NotifyingProperty TxtHighVoltageProperty =
          new NotifyingProperty("txtHighVoltage", typeof(int), default(int));

        /// <summary>
        /// Gets or sets Name.
        /// </summary>
        /// <value>The value of Name.</value>
        public int txtHighVoltage
        {
            get { return (int)GetValue(TxtHighVoltageProperty); }
            set { SetValue(TxtHighVoltageProperty, value); }
        }
        /// <summary>
        /// The NotifyingProperty for the Name property.
        /// </summary>
        private NotifyingProperty TxtLowVoltageProperty =
          new NotifyingProperty("txtLowVoltage", typeof(int), default(int));

        /// <summary>
        /// Gets or sets Name.
        /// </summary>
        /// <value>The value of Name.</value>
        public int txtLowVoltage
        {
            get { return (int)GetValue(TxtLowVoltageProperty); }
            set { SetValue(TxtLowVoltageProperty, value); }
        } 
        /// <summary>
        /// The NotifyingProperty for the Name property.
        /// </summary>
        private NotifyingProperty TxtHighHumidityProperty =
          new NotifyingProperty("txtHighHumidity", typeof(int), default(int));

        /// <summary>
        /// Gets or sets Name.
        /// </summary>
        /// <value>The value of Name.</value>
        public int txtHighHumidity
        {
            get { return (int)GetValue(TxtHighHumidityProperty); }
            set { SetValue(TxtHighHumidityProperty, value); }
        }
        /// <summary>
        /// The NotifyingProperty for the Name property.
        /// </summary>
        private NotifyingProperty TxtLowHumidityProperty =
          new NotifyingProperty("txtLowHumidity", typeof(int), default(int));

        /// <summary>
        /// Gets or sets Name.txtDoorCheck
        /// </summary>
        /// <value>The value of Name.</value>
        public int txtLowHumidity
        {
            get { return (int)GetValue(TxtLowHumidityProperty); }
            set { SetValue(TxtLowHumidityProperty, value); }
        }
        /// <summary>
        /// The NotifyingProperty for the Name property.
        /// </summary>
        private NotifyingProperty TxtDoorCheckProperty =
          new NotifyingProperty("txtDoorCheck", typeof(int), default(int));

        /// <summary>
        /// Gets or sets Name.cbxDegradationModel
        /// </summary>
        /// <value>The value of Name.</value>
        public int txtDoorCheck
        {
            get { return (int)GetValue(TxtDoorCheckProperty); }
            set { SetValue(TxtDoorCheckProperty, value); }
        }
 
    }
}
