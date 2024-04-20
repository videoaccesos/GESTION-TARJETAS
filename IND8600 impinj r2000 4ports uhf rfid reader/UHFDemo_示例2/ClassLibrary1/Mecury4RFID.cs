using System;
using System.Collections.Generic;
using System.Text;
using System.IO.Ports;
using System.Net;
using RFID;

namespace RFID
{
    /// <summary>
    /// Mecury4的读写器类
    /// </summary>
    public class Mecury4RFID: IRFID
    {
        private Reader.ReaderMethod reader;
        private byte btCurrentConnection = 0; //当前的连接 0:未连接 1：串口 2：TCP/IP

        private byte btCommandFlag; //读写器返回数据的状态   
        const byte ConstOK = 1; //1：操作成功完成。
        const byte ConstErrorCode = 100; //100：返回了错误代码。

        private string strReaderErrorCode = "";

        private byte[] btArrayUid = new byte[8];
        private byte[] btArrayReadData = new byte[300];
        private int nReadDataLen = 0;
        private byte btByteWritten = 0;

        public Mecury4RFID()
        {
            reader = new Reader.ReaderMethod();
            reader.AnalyCallback = AnalyData;
        }

        private string FormatErrorCode(byte btErrorCode)
        {
            string strErrorCode = "";
            switch (btErrorCode)
            {
                case 0x10:
                    strErrorCode = "命令已执行";
                    break;
                case 0x11:
                    strErrorCode = "命令执行失败";
                    break;
                case 0x20:
                    strErrorCode = "CPU 复位错误";
                    break;
                case 0x21:
                    strErrorCode = "打开CW 错误";
                    break;
                case 0x22:
                    strErrorCode = "天线未连接";
                    break;
                case 0x23:
                    strErrorCode = "写Flash 错误";
                    break;
                case 0x24:
                    strErrorCode = "读Flash 错误";
                    break;
                case 0x25:
                    strErrorCode = "设置发射功率错误";
                    break;
                case 0x31:
                    strErrorCode = "盘存标签错误";
                    break;
                case 0x32:
                    strErrorCode = "读标签错误";
                    break;
                case 0x33:
                    strErrorCode = "写标签错误";
                    break;
                case 0x34:
                    strErrorCode = "锁定标签错误";
                    break;
                case 0x35:
                    strErrorCode = "灭活标签错误";
                    break;
                case 0x36:
                    strErrorCode = "无可操作标签错误";
                    break;
                case 0x37:
                    strErrorCode = "成功盘存但访问失败";
                    break;
                case 0x38:
                    strErrorCode = "缓存为空";
                    break;
                case 0x40:
                    strErrorCode = "访问标签错误或访问密码错误";
                    break;
                case 0x41:
                    strErrorCode = "无效的参数";
                    break;
                case 0x42:
                    strErrorCode = "wordCnt 参数超过规定长度";
                    break;
                case 0x43:
                    strErrorCode = "MemBank 参数超出范围";
                    break;
                case 0x44:
                    strErrorCode = "Lock 数据区参数超出范围";
                    break;
                case 0x45:
                    strErrorCode = "LockType 参数超出范围";
                    break;
                case 0x46:
                    strErrorCode = "读卡器地址无效。";
                    break;
                case 0x47:
                    strErrorCode = "Antenna_id 超出范围";
                    break;
                case 0x48:
                    strErrorCode = "输出功率参数超出范围";
                    break;
                case 0x49:
                    strErrorCode = "射频规范区域参数超出范围";
                    break;
                case 0x4A:
                    strErrorCode = "波特率参数超过范围";
                    break;
                case 0x4B:
                    strErrorCode = "蜂鸣器设置参数超出范围";
                    break;
                case 0x4C:
                    strErrorCode = "EPC 匹配长度越界";
                    break;
                case 0x4D:
                    strErrorCode = "EPC 匹配长度错误";
                    break;
                case 0x4E:
                    strErrorCode = "EPC 匹配参数超出范围";
                    break;
                case 0x4F:
                    strErrorCode = "频率范围设置参数错误";
                    break;
                case 0x50:
                    strErrorCode = "无法接收标签的RN16";
                    break;
                case 0x51:
                    strErrorCode = "DRM 设置参数错误";
                    break;
                case 0x52:
                    strErrorCode = "PLL 不能锁定";
                    break;
                case 0x53:
                    strErrorCode = "射频芯片无响应";
                    break;
                case 0x54:
                    strErrorCode = "输出达不到指定的输出功率";
                    break;
                case 0x55:
                    strErrorCode = "版权认证未通过";
                    break;
                case 0x56:
                    strErrorCode = "频谱规范设置错误";
                    break;
                case 0x57:
                    strErrorCode = "输出功率过低";
                    break;
                default:
                    strErrorCode = "未知错误";
                    break;
            }
            return strErrorCode;
        }

        /// <summary>
        /// 将字符串按照指定长度截取并转存为字符数组，空格忽略
        /// </summary>
        /// <param name="strValue"></param>
        /// <param name="nLength"></param>
        /// <returns></returns>
        private string[] StringToStringArray(string strValue, int nLength)
        {
            string[] strAryResult = null;

            if (!string.IsNullOrEmpty(strValue))
            {
                System.Collections.ArrayList strListResult = new System.Collections.ArrayList();
                string strTemp = string.Empty;
                int nTemp = 0;

                for (int nloop = 0; nloop < strValue.Length; nloop++)
                {
                    if (strValue[nloop] == ' ')
                    {
                        continue;
                    }
                    else
                    {
                        nTemp++;

                        //校验截取的字符是否在A~F、0~9区间，不在则直接退出
                        System.Text.RegularExpressions.Regex reg = new System.Text.RegularExpressions.Regex(@"^(([A-F])*(\d)*)$");
                        if (!reg.IsMatch(strValue.Substring(nloop, 1)))
                        {
                            return strAryResult;
                        }

                        strTemp += strValue.Substring(nloop, 1);

                        //判断是否到达截取长度
                        if ((nTemp == nLength) || (nloop == strValue.Length - 1 && !string.IsNullOrEmpty(strTemp)))
                        {
                            strListResult.Add(strTemp);
                            nTemp = 0;
                            strTemp = string.Empty;
                        }
                    }
                }

                if (strListResult.Count > 0)
                {
                    strAryResult = new string[strListResult.Count];
                    strListResult.CopyTo(strAryResult);
                }
            }

            return strAryResult;
        }

        /// <summary>
        /// 字符数组转为16进制数组
        /// </summary>
        /// <param name="strAryHex"></param>
        /// <param name="nLen"></param>
        /// <returns></returns>
        private byte[] StringArrayToByteArray(string[] strAryHex, int nLen)
        {
            if (strAryHex.Length < nLen)
            {
                nLen = strAryHex.Length;
            }

            byte[] btAryHex = new byte[nLen];

            try
            {
                int nIndex = 0;
                foreach (string strTemp in strAryHex)
                {
                    btAryHex[nIndex] = Convert.ToByte(strTemp, 16);
                    nIndex++;
                }
            }
            catch (System.Exception ex)
            {

            }

            return btAryHex;
        }

        //等待读写器返回数据
        //输入参数 nTimeOut: 超时时间，单位mS
        private bool WaitReadData(int nTimeOut)
        {
            DateTime startTime;
            TimeSpan timeOutControl;
            startTime = DateTime.Now;
            strReaderErrorCode = "";
            btCommandFlag = 0;
            while (btCommandFlag == 0) //等待读写器返回数据完成，若超时，返回超时标志
            {
                timeOutControl = DateTime.Now - startTime;
                if (timeOutControl.TotalMilliseconds > nTimeOut)//超时返回 
                {
                   return false;
                }
            }
            return true;
        }
        //处理读写器返回的数据。
        //字节流的含义请参考通讯协议。
        //注意: btCommandFlag标志位要执行完所有的操作后最后置位。否则等待接收数据的线程可能会比数据操作先执行完毕。
        private void AnalyData(Reader.MessageTran msgTran)
        {
            if (msgTran.PacketType != 0xA0)
            {
                return;
            }
            switch (msgTran.Cmd)
            {
                case 0x61: //设置GPIO命令
                    btCommandFlag = ConstOK;
                    break;
                case 0x72: //读取读写器固件版本命令
                    btCommandFlag = ConstOK;
                    break;
                case 0x74: //切换天线命令
                    if (msgTran.AryData[0] == 0x10) //返回成功
                    {
                        btCommandFlag = ConstOK;
                    }
                    break;
                case 0xB0: //读6B标签UID命令
                    if (msgTran.AryData.Length == 1) // 读写器返回错误代码
                    {
                        strReaderErrorCode = FormatErrorCode(msgTran.AryData[0]); 
                        btCommandFlag = ConstErrorCode;
                       
                    }
                    if (msgTran.AryData.Length == 2) // 读写返回命令执行结束
                    {
                        btCommandFlag = ConstOK;
                    }
                    if (msgTran.AryData.Length == 9) // 读写返回标签UID数据
                    {
                        btArrayUid[0] = msgTran.AryData[1];
                        btArrayUid[1] = msgTran.AryData[2];
                        btArrayUid[2] = msgTran.AryData[3];
                        btArrayUid[3] = msgTran.AryData[4];
                        btArrayUid[4] = msgTran.AryData[5];
                        btArrayUid[5] = msgTran.AryData[6];
                        btArrayUid[6] = msgTran.AryData[7];
                        btArrayUid[7] = msgTran.AryData[8];
                    }
                    break;

                case 0xB1: //读6B标签 
                    if (msgTran.AryData.Length == 1)
                    {
                        strReaderErrorCode = FormatErrorCode(msgTran.AryData[0]);
                        btCommandFlag = ConstErrorCode;
                    }
                    else
                    {
                        
                        nReadDataLen = msgTran.AryData.Length - 1;
                        for (int i = 0; i < nReadDataLen; i++)
                        {
                            btArrayReadData[i] = msgTran.AryData[i + 1];
                        }
                        btCommandFlag = ConstOK;
                    }
                         
                    break;
                case 0xB2: //写6B标签 
                    if (msgTran.AryData.Length == 1)
                    {
                        strReaderErrorCode = FormatErrorCode(msgTran.AryData[0]);
                        btCommandFlag = ConstErrorCode;
                    }
                    if (msgTran.AryData.Length == 2)
                    {
                        btByteWritten = msgTran.AryData[1];
                        btCommandFlag = ConstOK;
                    }

                    break;
                default:
                    break;
            }
        }
        /// <summary>
        /// 连接读写器
        /// </summary>
        /// <param name="param">串口连接时为串口号，如COM1;网口连接时为IP加端口，如192.168.1.92:4000</param>
        /// <param name="deviceType">设备类型</param>
        /// <param name="errMsg">错误信息</param>
        /// <returns>成功失败标志</returns>
        public bool ConnectReader(string param, ThingMagic.DeviceType deviceType, ref string errMsg)
        {
            errMsg = string.Empty;
            int nReturnValue = 0;
            //串口连接
            if (deviceType == ThingMagic.DeviceType.Mecury4Serial)
            {
                nReturnValue = reader.OpenCom(param, 115200, out errMsg);
                if (nReturnValue != 0)
                {
                    btCurrentConnection = 0;
                    return false;
                }
                btCurrentConnection = 1;

            }
            //TCP/IP连接
            if (deviceType == ThingMagic.DeviceType.Mecury4TCP)
            {
                string strIpAddress = "";
                string strPort = "";
                
                for (int i = 0; i < param.Length; i ++)  //解析地址参数，将冒号前后分成IP地址和端口
                {
                    string temp = param.Substring(param.Length -i - 1 , 1);
                    if (temp == ":")
                    {
                        strIpAddress = param.Substring(0,param.Length - i - 1);
                        strPort = param.Substring(param.Length - i, i);
                        break;
                    }
                }
                IPAddress ipAddress = IPAddress.Parse(strIpAddress);
                int nPort = Convert.ToInt32(strPort);

                nReturnValue = reader.ConnectServer(ipAddress,nPort,out errMsg);
                 
                if (nReturnValue != 0)
                {
                    btCurrentConnection = 0;
                    return false;
                }
                btCurrentConnection = 2;
            }
            //测试与读写器的通讯，发送“读取固件版本”命令，如读写器有返回，则连接读写器成功，如果读写器没有返回，则连接读写器不成功
            for (int nTry = 0; nTry < 3; nTry++)
            {
                reader.GetFirmwareVersion(0xff);
                if (WaitReadData(1000) != true)
                {
                    if (nTry == 2)
                    {
                        errMsg = "串口成功打开但读写器没有响应";
                        return false;
                    }
                    else
                    {
                        continue;
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// 断开读写器
        /// </summary>
        /// <returns>成功失败标志</returns>
        public bool DisConnectReader(ref string errMsg)
        {
            errMsg = string.Empty;
            if (btCurrentConnection == 1)
            {
                reader.CloseCom();
            }
            if (btCurrentConnection == 2)
            {
                reader.SignOut();
            }
            btCurrentConnection = 0;
            return true;
        }

        /// <summary>
        /// 读取标签ID
        /// </summary>
        /// <param name="tryTimes">尝试次数，输入会小于10</param>//1-10
        /// <param name="tagID">标签ID</param>
        /// <param name="errMsg">错误信息</param>
        /// <returns>成功失败标志</returns>
        public bool ReadTagID(int AntennaID, int tryTimes, ref byte[] tagID, ref string errMsg)
        {
            for (int nTry = 0; nTry < tryTimes; nTry++)
            {
                //第一步：切换工作天线
                reader.SetWorkAntenna(0xff, (byte)AntennaID);
                if (WaitReadData(1000) != true)
                {
                    if (nTry == tryTimes - 1)
                    {
                        errMsg = "切换天线命令超时";
                        return false;
                    }
                    else
                    {
                        continue;
                    }
                }

                //第二步: 发送读UID命令

                for (int i = 0; i < 8; i++) //清空Uid数组
                {
                    btArrayUid[i] = 0;
                }

                reader.InventoryISO18000(0xff);
                if (WaitReadData(10000) != true)
                {
                    if (nTry == tryTimes - 1)
                    {
                        errMsg = "读18000-6B标签UID命令超时";
                        return false;
                    }
                    else
                    {
                        continue;
                    }
                }

                if (btCommandFlag == ConstErrorCode)
                {
                    if (nTry == tryTimes - 1)
                    {
                        errMsg = strReaderErrorCode;
                        return false;
                    }
                    else
                    {
                        continue;
                    }
                }

                for (int i = 0; i < 8; i++)  //UID数组有字节不为零则认为读到了UID
                {
                    if (btArrayUid[i] != 0)
                    {
                        for (int j = 0; j < 8; j++)  //只输出一个UID
                        {
                            tagID[j] = btArrayUid[j];
                        }
                        break;
                    }
                }
                return true;
            }
            return true;
        }

        /// <summary>
        /// 读取用户数据
        /// </summary>
        /// <param name="tryTimes">尝试次数，输入会小于10</param>
        /// <param name="tagID">要读取用户数据的标签ID</param>
        /// <param name="startPos">开始读取的位置</param>
        /// <param name="len">读取的数据长度</param>
        /// <param name="data">读取到的用户数据</param>
        /// <param name="errMsg">错误信息</param>
        /// <returns>成功失败标志</returns>
        public bool ReadUserData(int AntennaID, string tagID, int startPos, int len, int tryTimes, ref byte[] data, ref string errMsg)
        {

            for (int nTry = 0; nTry < tryTimes; nTry++)
            {
                //第一步：切换工作天线
                reader.SetWorkAntenna(0xff, (byte)AntennaID);
                if (WaitReadData(1000) != true)
                {
                    if (nTry == tryTimes - 1)
                    {
                        errMsg = "切换天线命令超时";
                        return false;
                    }
                    else
                    {
                        continue;
                    }
                }
                //第二步: 发送读标签命令
                string[] result = StringToStringArray(tagID.ToUpper(), 2);
                if (result == null)
                {
                    errMsg = "UID含有无效的字符";
                    return false;
                }
                if (result.GetLength(0) < 8)
                {
                    errMsg = "UID不等于8个字节";
                    return false;
                }
                byte[] btAryUID = StringArrayToByteArray(result, 8);
                reader.ReadTagISO18000(0xff, btAryUID, (byte)startPos, (byte)len);

                nReadDataLen = 0;

                if (WaitReadData(8000) != true)
                {
                    if (nTry == tryTimes - 1)
                    {
                        errMsg = "读标签数据超时";
                        return false;
                    }
                    else
                    {
                        continue;
                    }
                }

                if (btCommandFlag == ConstErrorCode)
                {
                    if (nTry == tryTimes - 1)
                    {
                        errMsg = strReaderErrorCode;
                        return false;
                    }
                    else
                    {
                        continue;
                    }

                }
                for (int i = 0; i < nReadDataLen; i++)  //操作成功，返回读取的数据
                {
                    data[i] = btArrayReadData[i];
                }
                return true;
            }
            return true;
        }

        /// <summary>
        /// 写入用户数据
        /// </summary>
        /// <param name="tryTimes">尝试次数，输入会小于10</param>
        /// <param name="tagID">要写入用户数据的标签ID</param>
        /// <param name="startPos">开始写入的位置</param>
        /// <param name="data">需要写入的用户数据</param>
        /// <param name="errMsg">错误信息</param>
        /// <returns>成功失败标志</returns>
        public bool WriteUserData(int AntennaID, string tagID, int startPos, byte[] data, int tryTimes, ref string errMsg)
        {
            for (int nTry = 0; nTry < tryTimes; nTry++)
            {
                //第一步：切换工作天线
                reader.SetWorkAntenna(0xff, (byte)AntennaID);
                if (WaitReadData(1000) != true)
                {
                    if (nTry == tryTimes - 1)
                    {
                        errMsg = "切换天线命令超时";
                        return false;
                    }
                    else
                    {
                        continue;
                    }
                }
                //第二步：写入数据
                string[] result = StringToStringArray(tagID.ToUpper(), 2);
                if (result == null)
                {
                    errMsg = "UID含有无效的字符";
                    return false;
                }
                if (result.GetLength(0) < 8)
                {
                    errMsg = "UID不等于8个字节";
                    return false;
                }
                byte[] btAryUID = StringArrayToByteArray(result, 8);

                int nDataLength = data.Length;

                btByteWritten = 0;

                reader.WriteTagISO18000(0xff, btAryUID, (byte)startPos, (byte)nDataLength, data);
                if (WaitReadData(15000) != true)
                {
                    if (nTry == tryTimes - 1)
                    {
                        errMsg = "写标签数据超时";
                        return false;
                    }
                    else
                    {
                        continue;
                    }
                }
                if (btCommandFlag == ConstErrorCode)
                {
                    if (nTry == tryTimes - 1)
                    {
                        errMsg = strReaderErrorCode;
                        return false;
                    }
                    else
                    {
                        continue;
                    }
                }
                if (btByteWritten != nDataLength)  //数据未全部写入。 一般是因为某个BYTE被LOCK住了，无须重试，直接返回。
                {
                    errMsg = "待写入数据" + nDataLength.ToString() + "字节,已成功写入数据" + btByteWritten.ToString() + "字节";
                    return false;
                }
                return true;
            }
            return true;
        }

        /// <summary>
        /// 设置GPIO端口、即报警灯设置
        /// </summary>
        /// <param name="port">端口号</param>
        /// <param name="state">需要设置的状态</param>
        /// <param name="errMsg">错误信息</param>
        /// <returns>成功失败标志</returns>
        public bool SetGPIO(int port, bool state, ref string errMsg)
        {
            if ((port != 3) && (port != 4))
            {
                errMsg = "输入参数错误,输出GPIO端口号为 3 或 4";
                return false;
            }
            byte btLevel = 0;
            if (state == true)
            {
                btLevel = 1;
            }
            else
            {
                btLevel = 0;
            }
            reader.WriteGpioValue(0xff, (byte)port, btLevel);

            if (WaitReadData(1000) != true)
            {
                errMsg = "设置GPIO超时";
                return false;
            }
            return true;
        }
    }
}

