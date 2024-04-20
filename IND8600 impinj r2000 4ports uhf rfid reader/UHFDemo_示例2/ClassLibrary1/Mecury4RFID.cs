using System;
using System.Collections.Generic;
using System.Text;
using System.IO.Ports;
using System.Net;
using RFID;

namespace RFID
{
    /// <summary>
    /// Mecury4�Ķ�д����
    /// </summary>
    public class Mecury4RFID: IRFID
    {
        private Reader.ReaderMethod reader;
        private byte btCurrentConnection = 0; //��ǰ������ 0:δ���� 1������ 2��TCP/IP

        private byte btCommandFlag; //��д���������ݵ�״̬   
        const byte ConstOK = 1; //1�������ɹ���ɡ�
        const byte ConstErrorCode = 100; //100�������˴�����롣

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
                    strErrorCode = "������ִ��";
                    break;
                case 0x11:
                    strErrorCode = "����ִ��ʧ��";
                    break;
                case 0x20:
                    strErrorCode = "CPU ��λ����";
                    break;
                case 0x21:
                    strErrorCode = "��CW ����";
                    break;
                case 0x22:
                    strErrorCode = "����δ����";
                    break;
                case 0x23:
                    strErrorCode = "дFlash ����";
                    break;
                case 0x24:
                    strErrorCode = "��Flash ����";
                    break;
                case 0x25:
                    strErrorCode = "���÷��书�ʴ���";
                    break;
                case 0x31:
                    strErrorCode = "�̴��ǩ����";
                    break;
                case 0x32:
                    strErrorCode = "����ǩ����";
                    break;
                case 0x33:
                    strErrorCode = "д��ǩ����";
                    break;
                case 0x34:
                    strErrorCode = "������ǩ����";
                    break;
                case 0x35:
                    strErrorCode = "����ǩ����";
                    break;
                case 0x36:
                    strErrorCode = "�޿ɲ�����ǩ����";
                    break;
                case 0x37:
                    strErrorCode = "�ɹ��̴浫����ʧ��";
                    break;
                case 0x38:
                    strErrorCode = "����Ϊ��";
                    break;
                case 0x40:
                    strErrorCode = "���ʱ�ǩ���������������";
                    break;
                case 0x41:
                    strErrorCode = "��Ч�Ĳ���";
                    break;
                case 0x42:
                    strErrorCode = "wordCnt ���������涨����";
                    break;
                case 0x43:
                    strErrorCode = "MemBank ����������Χ";
                    break;
                case 0x44:
                    strErrorCode = "Lock ����������������Χ";
                    break;
                case 0x45:
                    strErrorCode = "LockType ����������Χ";
                    break;
                case 0x46:
                    strErrorCode = "��������ַ��Ч��";
                    break;
                case 0x47:
                    strErrorCode = "Antenna_id ������Χ";
                    break;
                case 0x48:
                    strErrorCode = "������ʲ���������Χ";
                    break;
                case 0x49:
                    strErrorCode = "��Ƶ�淶�������������Χ";
                    break;
                case 0x4A:
                    strErrorCode = "�����ʲ���������Χ";
                    break;
                case 0x4B:
                    strErrorCode = "���������ò���������Χ";
                    break;
                case 0x4C:
                    strErrorCode = "EPC ƥ�䳤��Խ��";
                    break;
                case 0x4D:
                    strErrorCode = "EPC ƥ�䳤�ȴ���";
                    break;
                case 0x4E:
                    strErrorCode = "EPC ƥ�����������Χ";
                    break;
                case 0x4F:
                    strErrorCode = "Ƶ�ʷ�Χ���ò�������";
                    break;
                case 0x50:
                    strErrorCode = "�޷����ձ�ǩ��RN16";
                    break;
                case 0x51:
                    strErrorCode = "DRM ���ò�������";
                    break;
                case 0x52:
                    strErrorCode = "PLL ��������";
                    break;
                case 0x53:
                    strErrorCode = "��ƵоƬ����Ӧ";
                    break;
                case 0x54:
                    strErrorCode = "����ﲻ��ָ�����������";
                    break;
                case 0x55:
                    strErrorCode = "��Ȩ��֤δͨ��";
                    break;
                case 0x56:
                    strErrorCode = "Ƶ�׹淶���ô���";
                    break;
                case 0x57:
                    strErrorCode = "������ʹ���";
                    break;
                default:
                    strErrorCode = "δ֪����";
                    break;
            }
            return strErrorCode;
        }

        /// <summary>
        /// ���ַ�������ָ�����Ƚ�ȡ��ת��Ϊ�ַ����飬�ո����
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

                        //У���ȡ���ַ��Ƿ���A~F��0~9���䣬������ֱ���˳�
                        System.Text.RegularExpressions.Regex reg = new System.Text.RegularExpressions.Regex(@"^(([A-F])*(\d)*)$");
                        if (!reg.IsMatch(strValue.Substring(nloop, 1)))
                        {
                            return strAryResult;
                        }

                        strTemp += strValue.Substring(nloop, 1);

                        //�ж��Ƿ񵽴��ȡ����
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
        /// �ַ�����תΪ16��������
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

        //�ȴ���д����������
        //������� nTimeOut: ��ʱʱ�䣬��λmS
        private bool WaitReadData(int nTimeOut)
        {
            DateTime startTime;
            TimeSpan timeOutControl;
            startTime = DateTime.Now;
            strReaderErrorCode = "";
            btCommandFlag = 0;
            while (btCommandFlag == 0) //�ȴ���д������������ɣ�����ʱ�����س�ʱ��־
            {
                timeOutControl = DateTime.Now - startTime;
                if (timeOutControl.TotalMilliseconds > nTimeOut)//��ʱ���� 
                {
                   return false;
                }
            }
            return true;
        }
        //�����д�����ص����ݡ�
        //�ֽ����ĺ�����ο�ͨѶЭ�顣
        //ע��: btCommandFlag��־λҪִ�������еĲ����������λ������ȴ��������ݵ��߳̿��ܻ�����ݲ�����ִ����ϡ�
        private void AnalyData(Reader.MessageTran msgTran)
        {
            if (msgTran.PacketType != 0xA0)
            {
                return;
            }
            switch (msgTran.Cmd)
            {
                case 0x61: //����GPIO����
                    btCommandFlag = ConstOK;
                    break;
                case 0x72: //��ȡ��д���̼��汾����
                    btCommandFlag = ConstOK;
                    break;
                case 0x74: //�л���������
                    if (msgTran.AryData[0] == 0x10) //���سɹ�
                    {
                        btCommandFlag = ConstOK;
                    }
                    break;
                case 0xB0: //��6B��ǩUID����
                    if (msgTran.AryData.Length == 1) // ��д�����ش������
                    {
                        strReaderErrorCode = FormatErrorCode(msgTran.AryData[0]); 
                        btCommandFlag = ConstErrorCode;
                       
                    }
                    if (msgTran.AryData.Length == 2) // ��д��������ִ�н���
                    {
                        btCommandFlag = ConstOK;
                    }
                    if (msgTran.AryData.Length == 9) // ��д���ر�ǩUID����
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

                case 0xB1: //��6B��ǩ 
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
                case 0xB2: //д6B��ǩ 
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
        /// ���Ӷ�д��
        /// </summary>
        /// <param name="param">��������ʱΪ���ںţ���COM1;��������ʱΪIP�Ӷ˿ڣ���192.168.1.92:4000</param>
        /// <param name="deviceType">�豸����</param>
        /// <param name="errMsg">������Ϣ</param>
        /// <returns>�ɹ�ʧ�ܱ�־</returns>
        public bool ConnectReader(string param, ThingMagic.DeviceType deviceType, ref string errMsg)
        {
            errMsg = string.Empty;
            int nReturnValue = 0;
            //��������
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
            //TCP/IP����
            if (deviceType == ThingMagic.DeviceType.Mecury4TCP)
            {
                string strIpAddress = "";
                string strPort = "";
                
                for (int i = 0; i < param.Length; i ++)  //������ַ��������ð��ǰ��ֳ�IP��ַ�Ͷ˿�
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
            //�������д����ͨѶ�����͡���ȡ�̼��汾��������д���з��أ������Ӷ�д���ɹ��������д��û�з��أ������Ӷ�д�����ɹ�
            for (int nTry = 0; nTry < 3; nTry++)
            {
                reader.GetFirmwareVersion(0xff);
                if (WaitReadData(1000) != true)
                {
                    if (nTry == 2)
                    {
                        errMsg = "���ڳɹ��򿪵���д��û����Ӧ";
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
        /// �Ͽ���д��
        /// </summary>
        /// <returns>�ɹ�ʧ�ܱ�־</returns>
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
        /// ��ȡ��ǩID
        /// </summary>
        /// <param name="tryTimes">���Դ����������С��10</param>//1-10
        /// <param name="tagID">��ǩID</param>
        /// <param name="errMsg">������Ϣ</param>
        /// <returns>�ɹ�ʧ�ܱ�־</returns>
        public bool ReadTagID(int AntennaID, int tryTimes, ref byte[] tagID, ref string errMsg)
        {
            for (int nTry = 0; nTry < tryTimes; nTry++)
            {
                //��һ�����л���������
                reader.SetWorkAntenna(0xff, (byte)AntennaID);
                if (WaitReadData(1000) != true)
                {
                    if (nTry == tryTimes - 1)
                    {
                        errMsg = "�л��������ʱ";
                        return false;
                    }
                    else
                    {
                        continue;
                    }
                }

                //�ڶ���: ���Ͷ�UID����

                for (int i = 0; i < 8; i++) //���Uid����
                {
                    btArrayUid[i] = 0;
                }

                reader.InventoryISO18000(0xff);
                if (WaitReadData(10000) != true)
                {
                    if (nTry == tryTimes - 1)
                    {
                        errMsg = "��18000-6B��ǩUID���ʱ";
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

                for (int i = 0; i < 8; i++)  //UID�������ֽڲ�Ϊ������Ϊ������UID
                {
                    if (btArrayUid[i] != 0)
                    {
                        for (int j = 0; j < 8; j++)  //ֻ���һ��UID
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
        /// ��ȡ�û�����
        /// </summary>
        /// <param name="tryTimes">���Դ����������С��10</param>
        /// <param name="tagID">Ҫ��ȡ�û����ݵı�ǩID</param>
        /// <param name="startPos">��ʼ��ȡ��λ��</param>
        /// <param name="len">��ȡ�����ݳ���</param>
        /// <param name="data">��ȡ�����û�����</param>
        /// <param name="errMsg">������Ϣ</param>
        /// <returns>�ɹ�ʧ�ܱ�־</returns>
        public bool ReadUserData(int AntennaID, string tagID, int startPos, int len, int tryTimes, ref byte[] data, ref string errMsg)
        {

            for (int nTry = 0; nTry < tryTimes; nTry++)
            {
                //��һ�����л���������
                reader.SetWorkAntenna(0xff, (byte)AntennaID);
                if (WaitReadData(1000) != true)
                {
                    if (nTry == tryTimes - 1)
                    {
                        errMsg = "�л��������ʱ";
                        return false;
                    }
                    else
                    {
                        continue;
                    }
                }
                //�ڶ���: ���Ͷ���ǩ����
                string[] result = StringToStringArray(tagID.ToUpper(), 2);
                if (result == null)
                {
                    errMsg = "UID������Ч���ַ�";
                    return false;
                }
                if (result.GetLength(0) < 8)
                {
                    errMsg = "UID������8���ֽ�";
                    return false;
                }
                byte[] btAryUID = StringArrayToByteArray(result, 8);
                reader.ReadTagISO18000(0xff, btAryUID, (byte)startPos, (byte)len);

                nReadDataLen = 0;

                if (WaitReadData(8000) != true)
                {
                    if (nTry == tryTimes - 1)
                    {
                        errMsg = "����ǩ���ݳ�ʱ";
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
                for (int i = 0; i < nReadDataLen; i++)  //�����ɹ������ض�ȡ������
                {
                    data[i] = btArrayReadData[i];
                }
                return true;
            }
            return true;
        }

        /// <summary>
        /// д���û�����
        /// </summary>
        /// <param name="tryTimes">���Դ����������С��10</param>
        /// <param name="tagID">Ҫд���û����ݵı�ǩID</param>
        /// <param name="startPos">��ʼд���λ��</param>
        /// <param name="data">��Ҫд����û�����</param>
        /// <param name="errMsg">������Ϣ</param>
        /// <returns>�ɹ�ʧ�ܱ�־</returns>
        public bool WriteUserData(int AntennaID, string tagID, int startPos, byte[] data, int tryTimes, ref string errMsg)
        {
            for (int nTry = 0; nTry < tryTimes; nTry++)
            {
                //��һ�����л���������
                reader.SetWorkAntenna(0xff, (byte)AntennaID);
                if (WaitReadData(1000) != true)
                {
                    if (nTry == tryTimes - 1)
                    {
                        errMsg = "�л��������ʱ";
                        return false;
                    }
                    else
                    {
                        continue;
                    }
                }
                //�ڶ�����д������
                string[] result = StringToStringArray(tagID.ToUpper(), 2);
                if (result == null)
                {
                    errMsg = "UID������Ч���ַ�";
                    return false;
                }
                if (result.GetLength(0) < 8)
                {
                    errMsg = "UID������8���ֽ�";
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
                        errMsg = "д��ǩ���ݳ�ʱ";
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
                if (btByteWritten != nDataLength)  //����δȫ��д�롣 һ������Ϊĳ��BYTE��LOCKס�ˣ��������ԣ�ֱ�ӷ��ء�
                {
                    errMsg = "��д������" + nDataLength.ToString() + "�ֽ�,�ѳɹ�д������" + btByteWritten.ToString() + "�ֽ�";
                    return false;
                }
                return true;
            }
            return true;
        }

        /// <summary>
        /// ����GPIO�˿ڡ�������������
        /// </summary>
        /// <param name="port">�˿ں�</param>
        /// <param name="state">��Ҫ���õ�״̬</param>
        /// <param name="errMsg">������Ϣ</param>
        /// <returns>�ɹ�ʧ�ܱ�־</returns>
        public bool SetGPIO(int port, bool state, ref string errMsg)
        {
            if ((port != 3) && (port != 4))
            {
                errMsg = "�����������,���GPIO�˿ں�Ϊ 3 �� 4";
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
                errMsg = "����GPIO��ʱ";
                return false;
            }
            return true;
        }
    }
}

