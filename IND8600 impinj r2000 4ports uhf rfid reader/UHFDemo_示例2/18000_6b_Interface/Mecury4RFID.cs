using System;
using System.Collections.Generic;
using System.Text;

using RFID;

namespace RFID
{
    /// <summary>
    /// Mecury4�Ķ�д����
    /// </summary>
    public class Mecury4RFID: IRFID
    {
        /// <summary>
        /// ���Ӷ�д��
        /// </summary>
        /// <param name="param">��������ʱΪ���ںţ���COM1;��������ʱΪIP�Ӷ˿ڣ���192.168.1.92:4000</param>
        /// <param name="deviceType">�豸����</param>
        /// <param name="errMsg">������Ϣ</param>
        /// <returns>�ɹ�ʧ�ܱ�־</returns>
        public bool ConnectReader(string param, ThingMagic.DeviceType deviceType, ref string errMsg)
        {
            return true;
        }

        /// <summary>
        /// �Ͽ���д��
        /// </summary>
        /// <returns>�ɹ�ʧ�ܱ�־</returns>
        public bool DisConnectReader(ref string errMsg)
        {
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
            return true;
        }
    }
}

