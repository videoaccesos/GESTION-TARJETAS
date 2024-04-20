package com.UHF.scanlable;


import android.app.Activity;
import android.os.Bundle;
import android.os.Handler;
import android.view.View;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Spinner;
import android.widget.TextView;

public class FDActivity extends Activity implements View.OnClickListener {
    Button btRead;
    private ArrayAdapter<String> spada_epc;
    Spinner spepc;
    TextView tvResult;
    EditText c_pwd;
    EditText edt_source;
    EditText edt_temp;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_f_d);
        initView();
    }

    private void initView()
    {
        spepc = (Spinner)findViewById(R.id.fd_spinner);
        tvResult = (TextView)findViewById(R.id.fd_result);
        btRead = (Button)findViewById(R.id.button_fd_read);
        btRead.setOnClickListener(this);

        c_pwd = (EditText)findViewById(R.id.fd_pwd);
        c_pwd.setText("00000000");
        edt_source = (EditText)findViewById(R.id.fd_source);
        edt_temp = (EditText)findViewById(R.id.fd_temp);
    }
    @Override
    protected void onResume() {
        // TODO Auto-generated method stub
        int epcCount = ScanMode.mlist.size();
        String[]epcdata = new String[epcCount];
        for (int i = 0; i < ScanMode.mlist.size(); i++) {
            String temp = ScanMode.mlist.get(i);
            epcdata[i] = temp;
        }

        spada_epc = new ArrayAdapter<String>(FDActivity.this,
                android.R.layout.simple_spinner_item, epcdata);
        spada_epc.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);
        spepc.setAdapter(spada_epc);
        if(epcCount>0)
            spepc.setSelection(0,false);

        super.onResume();
    }
    @Override
    public void onClick(View v) {
        if(v == btRead)
        {
            try{
                String str="";
                if(spepc.getSelectedItem()!=null)
                    str = spepc.getSelectedItem().toString();
                String Password =c_pwd.getText().toString();
                byte MeaType = 0;
                byte ResultSel=1;
                byte FieldChkEn=0;
                byte EPStorageEn=0;
                byte UserBlockAddr=0;
                byte[]Temp = new byte[2];
                int result =0x30;
                byte ReadLen=0;
                byte AuthType=0;
                byte[]AuthPwd = new byte[4];
                byte[]Data = new byte[4];
                int[]dataLen = new int[1];
                boolean success=false;
                for(int m=0;m<5;m++)
                {

                    /*byte[]memdata = new byte[20000];
                    int StartAddr1 = 0x1000;
                    int ReadLenq = 0x4C00;

                    long beginTime = System.currentTimeMillis();
                    result = Reader.rrlib.Fd_ExtReadMemory(str,StartAddr1,ReadLenq,Password,AuthType,"00000000",memdata,dataLen);
                    long endTime = System.currentTimeMillis()-beginTime;*/

                    result = Reader.rrlib.Fd_GetTemperature(str,MeaType,ResultSel,FieldChkEn,EPStorageEn,UserBlockAddr,Password,Temp);
                    if(result==0)
                    {
                        int result2=0x30;
                        for(int n=0;n<5;n++)
                        {
                            int StartAddr = 0xB040;
                            ReadLen = (byte)0x04;
                            AuthType=(byte)0xFF;
                            AuthPwd[0]=AuthPwd[1]=AuthPwd[2]=AuthPwd[3]=(byte)0;
                            for(int p=0;p<5;p++)
                            {
                                result2 =  Reader.rrlib.Fd_ReadMemory(str,StartAddr,ReadLen,Password,AuthType,"00000000",Data);
                                if(result2==0) break;
                            }

                            if(result2==0)
                            {
                                if(Data[0]==~(Data[1]))
                                {
                                    success =true;
                                }
                                else
                                {
                                    success =false;
                                }
                                break;
                            }
                        }
                        break;
                    }
                }
                if(success)
                {
                    edt_source.setText(Util.bytesToHexString(Temp,0,2));
                    int countTemp = (Temp[0]&255)*256 +(Temp[1]&255);
                    int preci = (Data[0]&255)>>7;
                    String ftemp = GetTemp(countTemp,preci);
                    edt_temp.setText(ftemp+"℃");
                    Reader.writelog(getString(R.string.get_success), tvResult);
                }
                else
                {
                    edt_source.setText("");
                    edt_temp.setText("");
                    Reader.writelog(getString(R.string.get_failed), tvResult);
                }

            }catch(Exception ex)
            {
                Reader.writelog(getString(R.string.get_failed), tvResult);
            }
        }
    }

    private String GetTemp(int tempCount,int preci)
    {

        String temp ="";
        tempCount = tempCount & 0x03FF;
        float ft =0.00f;
        if ((tempCount>>9)==0)//正数
        {
            tempCount = tempCount & 0x01FF;

            if (preci==0)//小数点2位
            {
                ft = (tempCount >> 2) + (tempCount & 0x03) * 0.25f;

            }
            else////小数点3位
            {
                ft = (tempCount >> 3) + (tempCount & 0x07) * 0.125f;
            }
            temp =String.valueOf(ft);
        }
        else//负数
        {
            tempCount = (~(tempCount & 0x01FF))+1;
            if (preci == 0)//小数点2位
            {
                ft = (tempCount >> 2) + (tempCount & 0x03) * 0.25f;
            }
            else////小数点3位
            {
                ft = (tempCount >> 3) + (tempCount & 0x07) * 0.125f;
            }
            temp ="-"+String.valueOf(ft);
        }
        return temp;
    }
}
