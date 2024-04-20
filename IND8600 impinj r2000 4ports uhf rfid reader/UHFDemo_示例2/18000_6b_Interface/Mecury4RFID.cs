using System;
using System.Collections.Generic;
using System.Text;

using RFID;

namespace RFID
{
    /// <summary>
    /// Mecury4的读写器类
    /// </summary>
    public class Mecury4RFID: IRFID
    {
        /// <summary>
        /// 连接读写器
        /// </summary>
        /// <param name="param">串口连接时为串口号，如COM1;网口连接时为IP加端口，如192.168.1.92:4000</param>
        /// <param name="deviceType">设备类型</param>
        /// <param name="errMsg">错误信息</param>
        /// <returns>成功失败标志</returns>
        public bool ConnectReader(string param, ThingMagic.DeviceType deviceType, ref string errMsg)
        {
            return true;
        }

        /// <summary>
        /// 断开读写器
        /// </summary>
        /// <returns>成功失败标志</returns>
        public bool DisConnectReader(ref string errMsg)
        {
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
            return true;
        }
    }
}

