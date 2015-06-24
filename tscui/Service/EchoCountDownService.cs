using System;
using System.Collections.Generic;
using tscui.Models;

namespace tscui.Service
{
    class EchoCountDownService
    {
        public EchoCountDownService(byte[] ba , int len)
        {
            SetCntDown(ba);
        }
        public void SetCntDown(byte[] byt)
        {
            try
            {
                EchoCntDowns._listEhoCntDown = new List<EhoCntDown>();
                byte[] countDownArray = new byte[Define.ECHO_COUNT_DOWN_RESULT_LEN*Define.ECHO_COUNT_DOWN_BYTE_SIZE];
                Array.Copy(byt, 3, countDownArray, 0, Define.ECHO_COUNT_DOWN_RESULT_LEN*Define.ECHO_COUNT_DOWN_BYTE_SIZE);
                byte[,] twoArray = ByteUtils.oneArray2TwoArray(countDownArray, Define.ECHO_COUNT_DOWN_RESULT_LEN,
                    Define.ECHO_COUNT_DOWN_BYTE_SIZE);
                EhoCntDown ecd;
                for (int i = 0; i < Define.ECHO_COUNT_DOWN_RESULT_LEN; i++)
                {
                    ecd = new EhoCntDown();
                    ecd.Color = ConvertCntDownByColor(twoArray[i, 1]);
                    ecd.Direc = ConvertCntDownByDirec(twoArray[i, 1]);
                    ecd.Type = ConvertCntDownByType(twoArray[i, 1]);
                    ecd.usFigure = Convert.ToUInt16((twoArray[i, 2] & 0xf)*100 + ((twoArray[i, 2] >> 4) & 0xf)*1000 +
                                         (twoArray[i, 3] & 0xf) + ((twoArray[i, 3] >> 4) & 0xf)*10 + 1);   //加1防止倒计时倒0
                //   Console.WriteLine("倒计时 "+ecd.usFigure);
                    if (ecd.usFigure !=1)
                      EchoCntDowns._listEhoCntDown.Add(ecd);
                 }
            }
            catch (Exception ex)
            {
                return;
            }


        }
        private ushort ConvertCntDownByFigure(byte[] ba)
        {
            ushort figure = new ushort();
            string a = Convert.ToString(ba[0] >> 4 & 0x0f);
            string b = Convert.ToString(ba[0] >> 4 & 0x0f);
            string c = Convert.ToString(ba[1] >> 4 & 0x0f);
            string d = Convert.ToString(ba[1] >> 4 & 0x0f);
            figure = Convert.ToUInt16(a + b + c + d);
            return figure;
        }
        private byte ConvertCntDownByColor(byte b)
        {
            byte newbye = new byte();
            newbye = (byte)(b & 0x03);
            return newbye;
        }
        private byte ConvertCntDownByDirec(byte b)
        {
            byte newbye = new byte();
            newbye = (byte)(b >> 2 & 0x07);
            return newbye;
        }
        private byte ConvertCntDownByType(byte b)
        {
            byte newbye = new byte();
            newbye = (byte)(b >>5 & 0x01);
            return newbye;
        }
    }
}
