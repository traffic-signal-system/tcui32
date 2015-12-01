using System;
using System.Collections.Generic;
using Apex.MVVM;
using tscui.Models;

namespace tscui.Pages.CountDown
{
    /// <summary>
    /// The CountDownViewModel ViewModel class.
    /// </summary>
    [ViewModel]
    public class CountDownViewModel : PageViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CountDownViewModel"/> class.
        /// </summary>
        /// 
        public List<CntDownFlashDev>  tsCntDownFlashDevsList = new List<CntDownFlashDev>();
        public List<CntDownNewGb> tsCntDownDirecList = new List<CntDownNewGb>();

        public CountDownViewModel()
        {//  TODO: Use the following snippets to help build viewmodels:
            //      apexnp - Creates a Notifying Property
            //      apexc - Creates a Command.
            Title = (string)App.Current.Resources.MergedDictionaries[3]["tsc_menu_countdown"];
            TscData t = Utils.Utils.GetTscDataByApplicationCurrentProperties();
            if (t != null && tsCntDownFlashDevsList.Count == 0)
            {
                foreach (CntDownDev sCntDownDev in t.ListCntDownDev)
                {
                    CntDownFlashDev tmpCntDownFlashDev = new CntDownFlashDev();
                    tmpCntDownFlashDev.ucDevId = sCntDownDev.ucDevId;
                    tmpCntDownFlashDev.ucPhase = sCntDownDev.ucPhase;
                    tmpCntDownFlashDev.ucOverlapPhase = sCntDownDev.ucOverlapPhase;
                    tmpCntDownFlashDev.ucGreenFlashBreak = ((sCntDownDev.ucMode & 0x1)>0)?true:false;
                    tmpCntDownFlashDev.ucRedFlashBreak = (((sCntDownDev.ucMode>>1) & 0x1) > 0) ? true : false;
                    tmpCntDownFlashDev.ucSeconds = (Byte)((sCntDownDev.ucMode >> 3) & 0xf);
                    tmpCntDownFlashDev.ucSendFlashBreak = (((sCntDownDev.ucMode >> 2) & 0x1) > 0) ? true : false;
                    tsCntDownFlashDevsList.Add(tmpCntDownFlashDev);
                }

            }
            tsCntDownDirecList.Add(new CntDownNewGb() { DirecName = "北左", CountAddr = 0x0, CountAddr4Direc =0x0});
            tsCntDownDirecList.Add(new CntDownNewGb() { DirecName = "北直", CountAddr = 0x1, CountAddr4Direc = 0x0 });
            tsCntDownDirecList.Add(new CntDownNewGb() { DirecName = "北右", CountAddr = 0x2, CountAddr4Direc = 0x0 });
            tsCntDownDirecList.Add(new CntDownNewGb() { DirecName = "北人行", CountAddr = 0x3, CountAddr4Direc = 0x0 });
            tsCntDownDirecList.Add(new CntDownNewGb() { DirecName = "北二次过街", CountAddr = 0x4, CountAddr4Direc = 0x0 });
            tsCntDownDirecList.Add(new CntDownNewGb() { DirecName = "北调头", CountAddr = 0x5, CountAddr4Direc = 0x0 });
            tsCntDownDirecList.Add(new CntDownNewGb() { DirecName = "北特殊", CountAddr = 0x6, CountAddr4Direc = 0x0 });
            tsCntDownDirecList.Add(new CntDownNewGb() { DirecName = "北其他", CountAddr = 0x7, CountAddr4Direc = 0x0 });
            tsCntDownDirecList.Add(new CntDownNewGb() { DirecName = "东左", CountAddr = 0x8, CountAddr4Direc = 0x1 });
            tsCntDownDirecList.Add(new CntDownNewGb() { DirecName = "东直", CountAddr = 0x9, CountAddr4Direc = 0x1 });
            tsCntDownDirecList.Add(new CntDownNewGb() { DirecName = "东右", CountAddr = 0xa, CountAddr4Direc = 0x1 });
            tsCntDownDirecList.Add(new CntDownNewGb() { DirecName = "东人行", CountAddr = 0xb, CountAddr4Direc = 0x1 });
            tsCntDownDirecList.Add(new CntDownNewGb() { DirecName = "东二次过街", CountAddr = 0xc, CountAddr4Direc = 0x1 });
            tsCntDownDirecList.Add(new CntDownNewGb() { DirecName = "东调头", CountAddr = 0xd, CountAddr4Direc = 0x1 });
            tsCntDownDirecList.Add(new CntDownNewGb() { DirecName = "东特殊", CountAddr = 0xe, CountAddr4Direc = 0x1 });
            tsCntDownDirecList.Add(new CntDownNewGb() { DirecName = "东其他", CountAddr = 0xf, CountAddr4Direc = 0x1 });
            tsCntDownDirecList.Add(new CntDownNewGb() { DirecName = "南左", CountAddr = 0x10, CountAddr4Direc = 0x2 });
            tsCntDownDirecList.Add(new CntDownNewGb() { DirecName = "南直", CountAddr = 0x11, CountAddr4Direc = 0x2 });
            tsCntDownDirecList.Add(new CntDownNewGb() { DirecName = "南右", CountAddr = 0x12, CountAddr4Direc = 0x2 });
            tsCntDownDirecList.Add(new CntDownNewGb() { DirecName = "南人行", CountAddr = 0x13, CountAddr4Direc = 0x2 });
            tsCntDownDirecList.Add(new CntDownNewGb() { DirecName = "南二次过街", CountAddr = 0x14, CountAddr4Direc = 0x2 });
            tsCntDownDirecList.Add(new CntDownNewGb() { DirecName = "南调头", CountAddr = 0x15, CountAddr4Direc = 0x2 });
            tsCntDownDirecList.Add(new CntDownNewGb() { DirecName = "南特殊", CountAddr = 0x16, CountAddr4Direc = 0x2 });
            tsCntDownDirecList.Add(new CntDownNewGb() { DirecName = "南其他", CountAddr = 0x17, CountAddr4Direc = 0x2 });
            tsCntDownDirecList.Add(new CntDownNewGb() { DirecName = "西左", CountAddr = 0x18, CountAddr4Direc = 0x3 });
            tsCntDownDirecList.Add(new CntDownNewGb() { DirecName = "西直", CountAddr = 0x19, CountAddr4Direc = 0x3 });
            tsCntDownDirecList.Add(new CntDownNewGb() { DirecName = "西右", CountAddr = 0x1a, CountAddr4Direc = 0x3 });
            tsCntDownDirecList.Add(new CntDownNewGb() { DirecName = "西人行", CountAddr = 0x1b, CountAddr4Direc = 0x3 });
            tsCntDownDirecList.Add(new CntDownNewGb() { DirecName = "西二次过街", CountAddr = 0x1c, CountAddr4Direc = 0x3 });
            tsCntDownDirecList.Add(new CntDownNewGb() { DirecName = "西调头", CountAddr = 0x1d, CountAddr4Direc = 0x3 });
            tsCntDownDirecList.Add(new CntDownNewGb() { DirecName = "西特殊", CountAddr = 0x1e, CountAddr4Direc = 0x3 });
            tsCntDownDirecList.Add(new CntDownNewGb() { DirecName = "西其他", CountAddr = 0x1f, CountAddr4Direc = 0x3 });

            
        }
    }
    public  class CntDownFlashDev
    {
        private byte _ucDevId;
        private uint _ucPhase;
        private ushort _ucOverlapPhase;
        private bool _ucGreenFlashBreak;
        private bool _ucRedFlashBreak;
        private bool _ucSendFlashBreak;
        private byte _ucSeconds;

        public byte ucDevId
        {
            get { return _ucDevId; }
            set { _ucDevId = value; }
        }
        public uint ucPhase
        {
            get { return _ucPhase; }
            set { _ucPhase = value; }
        }
        public ushort ucOverlapPhase
        {
            get { return _ucOverlapPhase; }
            set { _ucOverlapPhase = value; }
        }
        public byte ucSeconds
        {
            get { return _ucSeconds; }
            set { _ucSeconds = value; }
        }

        public bool ucGreenFlashBreak
        {
            get { return _ucGreenFlashBreak; }
            set { _ucGreenFlashBreak = value; }
        }
        public bool ucRedFlashBreak
        {
            get { return _ucRedFlashBreak; }
            set { _ucRedFlashBreak = value; }
        }
        public bool ucSendFlashBreak
        {
            get { return _ucSendFlashBreak; }
            set { _ucSendFlashBreak = value; }
        }
    }


    public class CntDownNewGb
    {
        public string DirecName { get; set; }
        public Byte CountAddr { get; set; }
        public Byte CountAddr4Direc { get; set; }
    }

}
