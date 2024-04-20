package com.UHF.scanlable;

import java.sql.Date;
import java.text.SimpleDateFormat;

import com.UHF.scanlable.R;
import com.rfid.trans.ReaderParameter;
import com.rfid.trans.ReaderHelp;
import android.app.Activity;
import android.media.SoundPool;
import android.os.Bundle;
import android.os.Handler;
import android.view.View;
import android.view.View.OnClickListener;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.CheckBox;
import android.widget.Spinner;
import android.widget.TextView;

public class ScanView extends Activity implements OnClickListener{
	
	private TextView tvVersion;
	private TextView tvResult;
	private Spinner tvpowerdBm;
	private Spinner spType;
	private Spinner spMem;

	private Button bSetting;
	private Button bRead;
	
	private Button paramRead;
	private Button paramSet;

	private int soundid;
	private int tty_speed = 57600;
	private byte addr = (byte) 0xff; 
	private String[] strBand =new String[5]; 
    private String[] strmaxFrm =null; 
    private String[] strminFrm =null;
	private String[] strtime =new String[256];

	private String[] strjtTime =new String[21];
	private String[] strBaudRate =new String[5];
	Spinner jgTime;
	private ArrayAdapter<String> spada_jgTime;

	Spinner spBand;
    Spinner spmaxFrm;
	Spinner spminFrm;
	Spinner sptime;
	Spinner spqvalue;
	Spinner spsession;
	Spinner sptidaddr;
	Spinner sptidlen;
	Spinner spbaudRate;
	Button Setparam;
	Button Getparam;
	Button btSetBaud;
	Button btOpenrf;
	Button btCloserf;
	Button btAnswer;
	Button btActive;

    private TextView tvTemp;
    private TextView tvLoss;
    Button btReadTemp;
    Button btReadLoss;
    private ArrayAdapter<String> spada_Band;
    private ArrayAdapter<String> spada_maxFrm; 
    private ArrayAdapter<String> spada_minFrm;
	private ArrayAdapter<String> spada_time;
	private ArrayAdapter<String> spada_lowPwr;
	private ArrayAdapter<String> spada_qvalue;
    private ArrayAdapter<String> spada_session; 
    private ArrayAdapter<String> spada_tidaddr; 
    private ArrayAdapter<String> spada_tidlen;
	private ArrayAdapter<String> spada_baudrate;
	private static final String TAG = "SacnView";
	
	@Override
	protected void onCreate(Bundle savedInstanceState) {
		// TODO Auto-generated method stub  properties
		super.onCreate(savedInstanceState);	
		setContentView(R.layout.scan_view);
		initView();
	}
	
	private void initView(){

        tvTemp = (TextView)findViewById(R.id.txt_tempe);
        tvLoss= (TextView)findViewById(R.id.txt_loss);

        btReadTemp = (Button)findViewById(R.id.bt_Readtemp);
        btReadLoss = (Button)findViewById(R.id.bt_Readloss);


        tvVersion = (TextView)findViewById(R.id.version);
		tvResult = (TextView)findViewById(R.id.param_result);

		tvpowerdBm = (Spinner)findViewById(R.id.power_spinner);
		ArrayAdapter<CharSequence> adapter3 =  ArrayAdapter.createFromResource(this, R.array.Power_select, android.R.layout.simple_spinner_item);
		adapter3.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);
		tvpowerdBm.setAdapter(adapter3);

		tvpowerdBm.setSelection(33, true);

		bSetting = (Button)findViewById(R.id.pro_setting);
		bRead = (Button)findViewById(R.id.pro_read);
		paramRead = (Button)findViewById(R.id.ivt_read);
		paramSet = (Button)findViewById(R.id.ivt_setting);
		btOpenrf = (Button)findViewById(R.id.ivt_open);
		btCloserf = (Button)findViewById(R.id.ivt_close);
		btAnswer = (Button)findViewById(R.id.bt_answer);
		btActive = (Button)findViewById(R.id.bt_active);
		btSetBaud = (Button)findViewById(R.id.bt_SetBdRate);
		bSetting.setOnClickListener(this);
		bRead.setOnClickListener(this);
		paramRead.setOnClickListener(this);
		paramSet.setOnClickListener(this);
		btOpenrf.setOnClickListener(this);
		btCloserf.setOnClickListener(this);
		btAnswer.setOnClickListener(this);
		btActive.setOnClickListener(this);
		btSetBaud.setOnClickListener(this);
        btReadLoss.setOnClickListener(this);
        btReadTemp.setOnClickListener(this);
		//最大询查时间
		for(int index=0;index<256;index++)
		{
			strtime[index] = String.valueOf(index)+"*100ms";
		}
		sptime = (Spinner)findViewById(R.id.time_spinner);
		spada_time = new ArrayAdapter<String>(ScanView.this,
				android.R.layout.simple_spinner_item, strtime);
		spada_time.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);
		sptime.setAdapter(spada_time);
		sptime.setSelection(20,false);

		////////////Ƶ��ѡ��
		strBand[0]="Chinese band2";
		strBand[1]="US band";
		strBand[2]="Korean band";
		strBand[3]="EU band";
		strBand[4]="Chinese band1";

		strBaudRate[0] = "9600bps";
		strBaudRate[1] = "19200bps";
		strBaudRate[2] = "38400bps";
		strBaudRate[3] = "57600bps";
		strBaudRate[4] = "115200bps";


		spBand=(Spinner)findViewById(R.id.band_spinner);  
		spada_Band = new ArrayAdapter<String>(ScanView.this,  
	             android.R.layout.simple_spinner_item, strBand);  
		spada_Band.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);  
		spBand.setAdapter(spada_Band);  
		spBand.setSelection(1,false); 
		SetFre(2);////��ʼ��Ƶ��
		 // ���Spinner�¼�����  
		spBand.setOnItemSelectedListener(new Spinner.OnItemSelectedListener() {  
        public void onItemSelected(AdapterView<?> arg0, View arg1,  
                int arg2, long arg3) {  
            // TODO Auto-generated method stub  
            // ������ʾ��ǰѡ�����  
            arg0.setVisibility(View.VISIBLE);  
            if(arg2==0)SetFre(1);
            if(arg2==1)SetFre(2);
            if(arg2==2)SetFre(3);
            if(arg2==3)SetFre(4);
            if(arg2==4)SetFre(8);
            //ѡ��Ĭ��ֵ����ִ��  
        }  
        public void onNothingSelected(AdapterView<?> arg0) {  
            // TODO Auto-generated method stub  
        	}  
		});


		//strjtTime[0]="无间隔";
		for(int index=0;index<21;index++)
		{
			strjtTime[index] = String.valueOf(index*10)+"ms";
		}
		jgTime=(Spinner)findViewById(R.id.jgTime_spinner);
		spada_jgTime = new ArrayAdapter<String>(ScanView.this,
				android.R.layout.simple_spinner_item, strjtTime);
		spada_jgTime.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);
		jgTime.setAdapter(spada_jgTime);
		jgTime.setSelection(0,false);

		spqvalue=(Spinner)findViewById(R.id.qvalue_spinner);  
		ArrayAdapter<CharSequence> adapter =  ArrayAdapter.createFromResource(this, R.array.men_q, android.R.layout.simple_spinner_item);
		adapter.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);
		spqvalue.setAdapter(adapter); 
		spqvalue.setSelection(4, true);
		
		
		spsession=(Spinner)findViewById(R.id.session_spinner);  
		ArrayAdapter<CharSequence> adapter1 =  ArrayAdapter.createFromResource(this, R.array.men_s, android.R.layout.simple_spinner_item);
		adapter1.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);
		spsession.setAdapter(adapter1); 
		spsession.setSelection(1, true);
		
		sptidaddr=(Spinner)findViewById(R.id.tidptr_spinner);  
		sptidlen=(Spinner)findViewById(R.id.tidlen_spinner);  
		ArrayAdapter<CharSequence> adapter2 =  ArrayAdapter.createFromResource(this, R.array.men_tid, android.R.layout.simple_spinner_item);
		adapter2.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);
		sptidaddr.setAdapter(adapter2); 
		sptidaddr.setSelection(0, true);
		sptidlen.setAdapter(adapter2); 
		sptidlen.setSelection(0, true);

		spbaudRate=(Spinner)findViewById(R.id.baud_spinner);
		spada_baudrate= new ArrayAdapter<String>(ScanView.this,
				android.R.layout.simple_spinner_item, strBaudRate);
		spada_baudrate.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);
		spbaudRate.setAdapter(spada_baudrate);
		switch (Connect232.baud)
		{
			case 9600:
				spbaudRate.setSelection(0,true);
				break;
			case 38400:
				spbaudRate.setSelection(1,true);
				break;
			case 19200:
				spbaudRate.setSelection(2,true);
				break;
			case 57600:
				spbaudRate.setSelection(3,true);
				break;
			case 115200:
				spbaudRate.setSelection(4,true);
				break;
		}


		////////////查询类型
		spType=(Spinner)findViewById(R.id.IvtType_spinner);
		ArrayAdapter<CharSequence> spada_Type = ArrayAdapter.createFromResource(this, R.array.IvtType_select, android.R.layout.simple_spinner_item);
		spada_Type.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);
		spType.setAdapter(spada_Type);
		spType.setSelection(0,false);


		////////////查询区域
		spMem=(Spinner)findViewById(R.id.mixmem_spinner);
		ArrayAdapter<CharSequence> spada_Mem = ArrayAdapter.createFromResource(this, R.array.readmen_select, android.R.layout.simple_spinner_item);
		spada_Mem.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);
		spMem.setAdapter(spada_Mem);
		spMem.setSelection(1,false);

	}

	@Override
	public void onClick(View view) {
		try{
			if(view == paramRead)
			{
				ReaderParameter param = Reader.rrlib.GetInventoryPatameter();
				sptidlen.setSelection(param.Length, true);
				sptidaddr.setSelection(param.WordPtr, true);
				spqvalue.setSelection(param.QValue,true);
				sptime.setSelection(param.ScanTime,true);
				spType.setSelection(param.IvtType,true);
				spMem.setSelection(param.Memory-1,true);

				int sessionindex = param.Session;
				if(sessionindex==255) sessionindex=4;
				spsession.setSelection(sessionindex,true);
				jgTime.setSelection( param.Interval /10,true);
				Reader.writelog(getString(R.string.get_success),tvResult);
			}
			else if(view == paramSet)
			{
				ReaderParameter param = Reader.rrlib.GetInventoryPatameter();
				param.Length = sptidlen.getSelectedItemPosition();
				param.WordPtr = sptidaddr.getSelectedItemPosition();
				param.QValue = spqvalue.getSelectedItemPosition();
				param.ScanTime = sptime.getSelectedItemPosition();
				param.IvtType = spType.getSelectedItemPosition();
				param.Memory = spMem.getSelectedItemPosition()+1;
				int Session = spsession.getSelectedItemPosition();
				if(Session==4)Session=255;
				param.Session = Session;

				int jgTimes = jgTime.getSelectedItemPosition();
				param.Interval = jgTimes*10;
				Reader.rrlib.SetInventoryPatameter(param);
				Reader.writelog(getString(R.string.set_success),tvResult);
			}
			else if (view == bSetting){
				
				int MaxFre=0;
				int MinFre=0;
				int Power= tvpowerdBm.getSelectedItemPosition();
				int fband = spBand.getSelectedItemPosition();
				int band=0;
				if(fband==0)band=1;
				if(fband==1)band=2;
				if(fband==2)band=3;
				if(fband==3)band=4;
				if(fband==4)band=8;
				int Frequent= spminFrm.getSelectedItemPosition();
				MinFre = Frequent;
				Frequent= spmaxFrm.getSelectedItemPosition();
				MaxFre = Frequent;
				int Antenna=0;

				String temp="";
				int result = Reader.rrlib.SetRfPower((byte)Power);
				if(result!=0)
				{
					temp=getString(R.string.power_error);
				}


				result = Reader.rrlib.SetRegion((byte)band,(byte)MaxFre,(byte)MinFre);
				if(result!=0)
				{
					if(temp=="")
					temp=getString(R.string.frequent_error);
					else
						temp+=(",\r\n"+getString(R.string.frequent_error));
				}
				if(temp!="")
				{
					Reader.writelog(temp,tvResult);
				}
				else
				{
					Reader.writelog(getString(R.string.set_success),tvResult);
				}
			}else if (view == bRead){
				byte[]Version=new byte[2];
				byte[]Power=new byte[1];
				byte[]band=new byte[1];
				byte[]MaxFre=new byte[1];
				byte[]MinFre=new byte[1];
				int result = Reader.rrlib.GetReaderInformation(Version, Power, band, MaxFre, MinFre);
				if(result==0)
				{
					String hvn = String.valueOf(Version[0]);
					if(hvn.length()==1)hvn="0"+hvn;
					String lvn = String.valueOf(Version[1]);
					if(lvn.length()==1)lvn="0"+lvn;
					tvVersion.setText(hvn+"."+lvn);
					tvpowerdBm.setSelection(Power[0],true);
					SetFre(band[0]);
					int bandindex = band[0];
					if(bandindex ==8)
					{
						bandindex=bandindex-4;
					}
					else
					{
						bandindex=bandindex-1;
					}
					spBand.setSelection(bandindex,true);
					spminFrm.setSelection(MinFre[0],true);
					spmaxFrm.setSelection(MaxFre[0],true);
					//sptime.setSelection(ScanTime[0]&255,true);
					Reader.writelog(getString(R.string.get_success),tvResult);
				}
				else
				{
					Reader.writelog(getString(R.string.get_failed),tvResult);
				}
			}
			else if(view == btSetBaud)
			{
				int index = spbaudRate.getSelectedItemPosition();
				int baudRate=57600;
				switch(index)
				{
					case 0:
						baudRate = 9600;
						break;
					case 1:
						baudRate = 19200;
						break;
					case 2:
						baudRate = 38400;
						break;
					case 3:
						baudRate = 57600;
						break;
					case 4:
						baudRate = 115200;
						break;
				}


				int result = Reader.rrlib.SetBaudRate(baudRate);
				if(result==0)
				{
					Reader.writelog("设置成功",tvResult);
				}
				else
				{
					Reader.writelog("设置失败",tvResult);
				}
			}
		}catch(Exception ex)
		{}
	}
	
	
	private void SetFre(int m)
	{
		if(m==1){ 
		    strmaxFrm=new String[20];
         	strminFrm=new String[20];
         	for(int i=0;i<20;i++){
         		String temp="";
         		float values=(float) (920.125 + i * 0.25);
         		temp=String.valueOf(values)+"MHz";
         		strminFrm[i]=temp;
         		strmaxFrm[i]=temp;
         	}
         	spmaxFrm=(Spinner)findViewById(R.id.max_spinner);  
         	spada_maxFrm = new ArrayAdapter<String>(ScanView.this,  
                      android.R.layout.simple_spinner_item, strmaxFrm);  
         	spada_maxFrm.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);  
         	spmaxFrm.setAdapter(spada_maxFrm);  
         	spmaxFrm.setSelection(19,false);
         	
         	spminFrm=(Spinner)findViewById(R.id.min_spinner);  
         	spada_minFrm = new ArrayAdapter<String>(ScanView.this,  
                      android.R.layout.simple_spinner_item, strminFrm);  
         	spada_minFrm.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);  
         	spminFrm.setAdapter(spada_minFrm);  
         	spminFrm.setSelection(0,false);
     }else if(m==2){
     	strmaxFrm=new String[50];
     	strminFrm=new String[50];
     	for(int i=0;i<50;i++){
     		String temp="";
     		float values=(float) (902.75 + i * 0.5);
     		temp=String.valueOf(values)+"MHz";
     		strminFrm[i]=temp;
     		strmaxFrm[i]=temp;
     	}
     	spmaxFrm=(Spinner)findViewById(R.id.max_spinner);  
     	spada_maxFrm = new ArrayAdapter<String>(ScanView.this,  
                  android.R.layout.simple_spinner_item, strmaxFrm);  
     	spada_maxFrm.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);  
     	spmaxFrm.setAdapter(spada_maxFrm);  
     	spmaxFrm.setSelection(49,false);
     	
     	spminFrm=(Spinner)findViewById(R.id.min_spinner);  
     	spada_minFrm = new ArrayAdapter<String>(ScanView.this,  
                  android.R.layout.simple_spinner_item, strminFrm);  
     	spada_minFrm.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);  
     	spminFrm.setAdapter(spada_minFrm);  
     	spminFrm.setSelection(0,false);
     }else if(m==3){
      	strmaxFrm=new String[32];
      	strminFrm=new String[32];
      	for(int i=0;i<32;i++){
      		String temp="";
      		float values=(float) (917.1 + i * 0.2);
      		temp=String.valueOf(values)+"MHz";
      		strminFrm[i]=temp;
      		strmaxFrm[i]=temp;
      	}
      	spmaxFrm=(Spinner)findViewById(R.id.max_spinner);  
      	spada_maxFrm = new ArrayAdapter<String>(ScanView.this,  
                   android.R.layout.simple_spinner_item, strmaxFrm);  
      	spada_maxFrm.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);  
      	spmaxFrm.setAdapter(spada_maxFrm);  
      	spmaxFrm.setSelection(31,false);
      	
      	spminFrm=(Spinner)findViewById(R.id.min_spinner);  
      	spada_minFrm = new ArrayAdapter<String>(ScanView.this,  
                   android.R.layout.simple_spinner_item, strminFrm);  
      	spada_minFrm.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);  
      	spminFrm.setAdapter(spada_minFrm);  
      	spminFrm.setSelection(0,false);
      }else if(m==4){
       	strmaxFrm=new String[15];
       	strminFrm=new String[15];
       	for(int i=0;i<15;i++){
       		String temp="";
       		float values=(float) (865.1 + i * 0.2);
       		temp=String.valueOf(values)+"MHz";
       		strminFrm[i]=temp;
       		strmaxFrm[i]=temp;
       	}
       	spmaxFrm=(Spinner)findViewById(R.id.max_spinner);  
       	spada_maxFrm = new ArrayAdapter<String>(ScanView.this,  
                    android.R.layout.simple_spinner_item, strmaxFrm);  
       	spada_maxFrm.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);  
       	spmaxFrm.setAdapter(spada_maxFrm);  
       	spmaxFrm.setSelection(14,false);
       	
       	spminFrm=(Spinner)findViewById(R.id.min_spinner);  
       	spada_minFrm = new ArrayAdapter<String>(ScanView.this,  
                    android.R.layout.simple_spinner_item, strminFrm);  
       	spada_minFrm.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);  
       	spminFrm.setAdapter(spada_minFrm);  
       	spminFrm.setSelection(0,false);
       }else if(m==8){
		    strmaxFrm=new String[20];
         	strminFrm=new String[20];
         	for(int i=0;i<20;i++){
         		String temp="";
         		float values=(float) (840.125 + i * 0.25);
         		temp=String.valueOf(values)+"MHz";
         		strminFrm[i]=temp;
         		strmaxFrm[i]=temp;
         	}
         	spmaxFrm=(Spinner)findViewById(R.id.max_spinner);  
         	spada_maxFrm = new ArrayAdapter<String>(ScanView.this,  
                      android.R.layout.simple_spinner_item, strmaxFrm);  
         	spada_maxFrm.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);  
         	spmaxFrm.setAdapter(spada_maxFrm);  
         	spmaxFrm.setSelection(19,false);
         	
         	spminFrm=(Spinner)findViewById(R.id.min_spinner);  
         	spada_minFrm = new ArrayAdapter<String>(ScanView.this,  
                      android.R.layout.simple_spinner_item, strminFrm);  
         	spada_minFrm.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);  
         	spminFrm.setAdapter(spada_minFrm);  
         	spminFrm.setSelection(0,false);
       }
	}
}
