using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Threading;

namespace UHFDemo
{
    public partial class R2000UartDemo : Form
    {
        private RFID.IRFID iRfid ;
        private string strCurrentUid;
        
        public R2000UartDemo()
        {
            InitializeComponent();
        }

        private void R2000UartDemo_Load(object sender, EventArgs e)
        {
            iRfid = new RFID.Mecury4RFID();

            strCurrentUid = "";

            //设置界面元素有效性
            gbRS232.Enabled = false;
            gbTcpIp.Enabled = false;
          
            //初始化连接读写器默认配置
            cmbComPort.SelectedIndex = 0;
            cmbBaudrate.SelectedIndex = 1;
            ipIpServer.IpAddressStr = "192.168.0.178";
            txtTcpPort.Text = "4001";
        }
     

        private void btnConnectRs232_Click(object sender, EventArgs e)
        {
            //处理串口连接读写器
            string strException = string.Empty;
            string strComPort = cmbComPort.Text;
            
            int nBaudrate=Convert.ToInt32(cmbBaudrate.Text);
            bool blRet = iRfid.ConnectReader(strComPort, ThingMagic.DeviceType.Mecury4Serial, ref strException);

            
            if (blRet != true)
            {
                string strLog = "连接读写器失败，失败原因： " + strException;

                WriteLog(lrtxtLog, strLog, 1);
                return;
            }
            else
            {
                string strLog = "与读写器通讯成功 " + strComPort + "@" + nBaudrate.ToString();
                WriteLog(lrtxtLog, strLog, 0);
               
            }
            
            //处理界面元素是否有效
            btnConnectRs232.Enabled = false;
            btnDisconnectRs232.Enabled = true;
            groupBox1.Enabled = true;

            //设置按钮字体颜色
            btnConnectRs232.ForeColor = Color.Black;
            btnDisconnectRs232.ForeColor = Color.Indigo;
           
        }

        private void btnDisconnectRs232_Click(object sender, EventArgs e)
        {
            string strException = string.Empty;
            //处理串口断开连接读写器

            iRfid.DisConnectReader(ref strException);
            //处理界面元素是否有效
            btnConnectRs232.Enabled = true;
            btnDisconnectRs232.Enabled = false;
            groupBox1.Enabled = false;

            //设置按钮字体颜色
            btnConnectRs232.ForeColor = Color.Indigo;
            btnDisconnectRs232.ForeColor = Color.Black;
           
        }

        private void btnConnectTcp_Click(object sender, EventArgs e)
        {
            try
            {
                //处理Tcp连接读写器
                string strException = string.Empty;
             
                string strParameter = "";

                strParameter = ipIpServer.IpAddressStr + ":" + txtTcpPort.Text;
                bool blRet = iRfid.ConnectReader(strParameter, ThingMagic.DeviceType.Mecury4TCP, ref strException);
                if (blRet != true)
                {
                    string strLog = "连接读写器失败，失败原因： " + strException;

                    WriteLog(lrtxtLog, strLog, 1);
                    return;
                }
                else
                {
                    string strLog = "连接读写器 " + ipIpServer.IpAddressStr + "@" + txtTcpPort.Text;
                    WriteLog(lrtxtLog, strLog, 0);
                   
                }

                //处理界面元素是否有效
                btnConnectTcp.Enabled = false;
                btnDisconnectTcp.Enabled = true;
                groupBox1.Enabled = true;

                //设置按钮字体颜色
                btnConnectTcp.ForeColor = Color.Black;
                btnDisconnectTcp.ForeColor = Color.Indigo;
              
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void btnDisconnectTcp_Click(object sender, EventArgs e)
        {
            string strException = string.Empty;
            iRfid.DisConnectReader(ref strException);
            //处理界面元素是否有效
            btnConnectTcp.Enabled = true;
            btnDisconnectTcp.Enabled = false;
            groupBox1.Enabled = false;

            //设置按钮字体颜色
            btnConnectTcp.ForeColor = Color.Indigo;
            btnDisconnectTcp.ForeColor = Color.Black;
        }
        private void rdbTcpIp_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbTcpIp.Checked)
            {
                gbTcpIp.Enabled = true;
                btnDisconnectTcp.Enabled = false;

                //设置按钮字体颜色
                btnConnectTcp.ForeColor = Color.Indigo;


                gbRS232.Enabled = false;
            }
        }

        private void rdbRS232_Click(object sender, EventArgs e)
        {
            if (rdbRS232.Checked)
            {
                gbRS232.Enabled = true;
                btnDisconnectRs232.Enabled = false;

                //设置按钮字体颜色
                btnConnectRs232.ForeColor = Color.Indigo;

                gbTcpIp.Enabled = false;
            }
        }

        private delegate void WriteLogUnSafe(CustomControl.LogRichTextBox logRichTxt, string strLog, int nType);
        private void WriteLog(CustomControl.LogRichTextBox logRichTxt, string strLog, int nType)
        {
            if (this.InvokeRequired)
            {
                WriteLogUnSafe InvokeWriteLog = new WriteLogUnSafe(WriteLog);
                this.Invoke(InvokeWriteLog, new object[] { logRichTxt, strLog, nType });
            }
            else
            {
                if (nType == 0)
                {
                    logRichTxt.AppendTextEx(strLog, Color.Indigo);
                }
                else
                {
                    logRichTxt.AppendTextEx(strLog, Color.Red);
                }
                logRichTxt.Select(logRichTxt.TextLength, 0);
                logRichTxt.ScrollToCaret();
            }
        }

        private void rdbRS232_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbRS232.Checked)
            {
                gbRS232.Enabled = true;
                btnConnectRs232.Enabled = true;
                btnDisconnectRs232.Enabled = false;

                //设置按钮字体颜色
                btnConnectRs232.ForeColor = Color.Indigo;

                gbTcpIp.Enabled = false;
            }
        }

        private void lrtxtLog_DoubleClick_1(object sender, EventArgs e)
        {
            lrtxtLog.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string strException = string.Empty;
            byte[] btTagUid = new byte[8];
            for (int i = 0; i < 8; i++) //清空标签UID数组
            {
                btTagUid[i] = 0; 
            }
            bool blRet = iRfid.ReadTagID(0, 1, ref btTagUid, ref strException);

            if (blRet == true)
            {
                bool blTagIdentified = false;

                for (int i = 0; i < 8; i++) //清空标签UID数组
                {
                    if (btTagUid[i] != 0)
                    {
                        blTagIdentified = true;
                        break;
                    }
                }
                if (blTagIdentified)
                {
                    string strHexUid = "18000-6B标签Uid: ";
                    for (int i = 0; i < 8; i++)
                    {
                        strHexUid = strHexUid + string.Format(" {0:X2}", btTagUid[i]);
                        strCurrentUid = strCurrentUid + string.Format(" {0:X2}", btTagUid[i]);
                    }
                    WriteLog(lrtxtLog, strHexUid, 0);
                }
                else
                {
                    string strInfo = "成功执行命令，但未读到标签UID";
                    WriteLog(lrtxtLog, strInfo, 0);
                }
            }
            else
            {
                WriteLog(lrtxtLog, strException, 1);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string strException = string.Empty;
            byte[] btArrayData = new byte[300];
            if (strCurrentUid.Length  == 0)
            {
                 MessageBox.Show("请先读UID");
                 return;
            }

            bool blRet = iRfid.ReadUserData(0, strCurrentUid, 0, 224, 1, ref btArrayData, ref strException);
            if (blRet == true)
            {
                string strTagData = " 标签数据： ";
                for (int i = 0; i < 224; i++)
                {
                    strTagData = strTagData + string.Format(" {0:X2}", btArrayData[i]);
                }
                WriteLog(lrtxtLog, strTagData, 0);
            }
            else
            {
                WriteLog(lrtxtLog, strException, 1);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string strException = string.Empty;
            byte[] btArrayData = new byte[216];  //216字节待写入数据
            for (int i = 0; i < 216; i ++)  //赋值写入数据，0x00 - 0xD7
            {
                btArrayData[i] = (byte)i;
            }
             
            if (strCurrentUid.Length == 0)
            {
                MessageBox.Show("请先读UID");
                return;
            }

            bool blRet = iRfid.WriteUserData(0, strCurrentUid, 8, btArrayData, 1, ref strException);
            if (blRet == true)
            {
                string strTagData = " 成功写入所有数据。";
                 
                WriteLog(lrtxtLog, strTagData, 0);
            }
            else
            {
                WriteLog(lrtxtLog, strException, 1);
            }



        }

        private void button6_Click(object sender, EventArgs e)
        {
            string strException = string.Empty;
            bool blRet = iRfid.SetGPIO(3, true, ref strException);
            if (blRet == true)
            {
                string strTagData = " 成功设置GPIO。";

                WriteLog(lrtxtLog, strTagData, 0);
            }
            else
            {
                WriteLog(lrtxtLog, strException, 1);
            }

        }

     

   

        


     
     
    

 
      
    
   
    }
}
