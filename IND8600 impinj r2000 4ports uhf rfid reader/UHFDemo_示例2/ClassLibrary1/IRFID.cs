using System;
using System.Collections.Generic;
using System.Text;

namespace RFID
{
    /// <summary>
    /// �豸���͵�ö�٣��������������ģ�����
    /// </summary>
    public enum DeviceType
    {
        /// <summary>
        /// Mecury4�豸�����ڣ�
        /// </summary>
        Mecury4TCP
    }

    /// <summary>
    /// RFID�豸�ײ㴦��ӿ�
    /// </summary>
    public interface IRFID
    {
        /// <summary>
        /// ���Ӷ�д��
        /// </summary>
        /// <param name="param">��������ʱΪ���ںţ���COM1;��������ʱΪIP�Ӷ˿ڣ���192.168.1.92:4000</param>
        /// <param name="deviceType">�豸����</param>
        /// <param name="errMsg">������Ϣ</param>
        /// <returns>�ɹ�ʧ�ܱ�־</returns>
        bool ConnectReader(string param, ThingMagic.DeviceType deviceType, ref string errMsg);

        /// <summary>
        /// �Ͽ���д��
        /// </summary>
        /// <returns>�ɹ�ʧ�ܱ�־</returns>
        bool DisConnectReader(ref string errMsg);

        /// <summary>
        /// ��ȡ��ǩID
        /// </summary>
        /// <param name="tryTimes">���Դ����������С��10</param>//1-10
        /// <param name="tagID">��ǩID</param>
        /// <param name="errMsg">������Ϣ</param>
        /// <returns>�ɹ�ʧ�ܱ�־</returns>
        bool ReadTagID(int AntennaID, int tryTimes, ref byte[] tagID, ref string errMsg);

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
        bool ReadUserData(int AntennaID, string tagID, int startPos, int len, int tryTimes, ref byte[] data, ref string errMsg);

        /// <summary>
        /// д���û�����
        /// </summary>
        /// <param name="tryTimes">���Դ����������С��10</param>
        /// <param name="tagID">Ҫд���û����ݵı�ǩID</param>
        /// <param name="startPos">��ʼд���λ��</param>
        /// <param name="data">��Ҫд����û�����</param>
        /// <param name="errMsg">������Ϣ</param>
        /// <returns>�ɹ�ʧ�ܱ�־</returns>
        bool WriteUserData(int AntennaID, string tagID, int startPos, byte[] data, int tryTimes, ref string errMsg);

        /// <summary>
        /// ����GPIO�˿ڡ�������������
        /// </summary>
        /// <param name="port">�˿ں�</param>
        /// <param name="state">��Ҫ���õ�״̬</param>
        /// <param name="errMsg">������Ϣ</param>
        /// <returns>�ɹ�ʧ�ܱ�־</returns>
        bool SetGPIO(int port, bool state, ref string errMsg);
    }
}

