package com.UHF.scanlable;

import java.io.IOException;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.LinkedHashMap;
import java.util.List;
import java.util.Map;
import java.util.Timer;
import java.util.TimerTask;

import com.UHF.scanlable.R;
import com.rfid.trans.ReadTag;
import com.rfid.trans.TagCallback;
//import com.UHF.scanlable.UHfData.InventoryTagMap;

import android.app.Activity;
import android.app.ActivityGroup;
import android.content.Context;
import android.content.Intent;
import android.os.Bundle;
import android.os.Handler;
import android.os.Message;
import android.os.SystemClock;
import android.text.TextUtils;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.View.OnClickListener;
import android.view.ViewGroup;
import android.view.Window;
import android.widget.AdapterView;
import android.widget.AdapterView.OnItemClickListener;
import android.widget.AdapterView.OnItemSelectedListener;
import android.widget.CompoundButton.OnCheckedChangeListener;
import android.widget.ArrayAdapter;
import android.widget.BaseAdapter;
import android.widget.Button;
import android.widget.CheckBox;
import android.widget.CompoundButton;
import android.widget.LinearLayout;
import android.widget.ListView;
import android.widget.PopupWindow;
import android.widget.RadioButton;
import android.widget.RadioGroup;
import android.widget.SimpleAdapter;
import android.widget.Spinner;
import android.widget.TextView;
import android.widget.Toast;

public class ScanMode extends Activity implements OnClickListener, OnItemClickListener,OnItemSelectedListener{

	private int inventoryFlag = 1;
	Handler handler;
	private ArrayList<HashMap<String, String>> tagList;
	SimpleAdapter adapter;
	Button BtClear;
	TextView tv_count;
	TextView tv_time;
	TextView tv_alltag;
	RadioGroup RgInventory;
	RadioButton RbInventorySingle;
	RadioButton RbInventoryLoop;
	Button Btimport;
	Button BtInventory;
	ListView LvTags;
	//   private Button btnFilter;//过滤
	private LinearLayout llContinuous;
	private HashMap<String, String> map;
	PopupWindow popFilter;
	public boolean isStopThread=false;
	MsgCallback callback = new MsgCallback();
	private static final int MSG_UPDATE_LISTVIEW = 0;
	private static final int MSG_UPDATE_TIME = 1;
	private static final int MSG_UPDATE_ERROR = 2;
	private static final int MSG_UPDATE_STOP = 3;
	private Timer timer;
	public long beginTime;
	public long CardNumber;
	public static List<String> mlist = new ArrayList<String>();

	@Override
	protected void onCreate(Bundle savedInstanceState) {
		// TODO Auto-generated method stub
		super.onCreate(savedInstanceState);
		try
		{
			setContentView(R.layout.query);
			tagList = new ArrayList<HashMap<String, String>>();
			BtClear = (Button) findViewById(R.id.BtClear);
			Btimport = (Button)findViewById(R.id.BtImport);
			tv_count = (TextView)findViewById(R.id.tv_count);
			tv_time = (TextView)findViewById(R.id.tv_times);
			tv_alltag = (TextView)findViewById(R.id.tv_alltag);
			RgInventory = (RadioGroup) findViewById(R.id.RgInventory);
			String tr = "";
			RbInventorySingle = (RadioButton) findViewById(R.id.RbInventorySingle);
			RbInventoryLoop = (RadioButton) findViewById(R.id.RbInventoryLoop);

			BtInventory = (Button)findViewById(R.id.BtInventory);
			LvTags = (ListView) findViewById(R.id.LvTags);

			llContinuous = (LinearLayout)findViewById(R.id.llContinuous);

			adapter = new SimpleAdapter(this, tagList, R.layout.listtag_items,
					new String[]{"tagUii", "tagLen", "tagCount", "tagRssi"},
					new int[]{R.id.TvTagUii, R.id.TvTagLen, R.id.TvTagCount,
							R.id.TvTagRssi});

			BtClear.setOnClickListener(this);
			Btimport.setOnClickListener(this);
			RgInventory.setOnCheckedChangeListener(new RgInventoryCheckedListener());
			BtInventory.setOnClickListener(this);

			Reader.rrlib.SetCallBack(callback);

			LvTags.setAdapter(adapter);
			clearData();
			Log.i("MY", "UHFReadTagFragment.EtCountOfTags=" + tv_count.getText());
			handler = new Handler() {
				@Override
				public void handleMessage(Message msg) {
					try{
						switch (msg.what) {
							case MSG_UPDATE_LISTVIEW:
								String result = msg.obj+"";
								String[] strs = result.split(",");
								if(strs.length==2)
								{
									addEPCToList(strs[0], strs[1]);
								}
								else
								{
									addEPCToList(strs[0]+","+strs[1], strs[2]);
								}

								break;
							case MSG_UPDATE_TIME:
								String ReadTime = msg.obj+"";
								tv_time.setText(ReadTime);
								break;
							case MSG_UPDATE_ERROR:

								break;
							case MSG_UPDATE_STOP:
								setViewEnabled(true);
								BtInventory.setText(getString(R.string.btInventory));
								break;
							default:
								break;
						}
					}catch(Exception ex)
					{ex.toString();}
				}
			};
		}
		catch(Exception e)
		{
			
		}
	}

	public class RgInventoryCheckedListener implements RadioGroup.OnCheckedChangeListener {
		@Override
		public void onCheckedChanged(RadioGroup group, int checkedId) {
			// llContinuous.setVisibility(View.GONE);
			if (checkedId == RbInventorySingle.getId()) {
				inventoryFlag = 0;
			} else if (checkedId == RbInventoryLoop.getId()) {
				inventoryFlag = 1;
			}
		}
	}

	private void setViewEnabled(boolean enabled) {
		RbInventorySingle.setEnabled(enabled);
		RbInventoryLoop.setEnabled(enabled);
		//   btnFilter.setEnabled(enabled);
		BtClear.setEnabled(enabled);
	}


	public int checkIsExist(String strEPC) {
		int existFlag = -1;
		if (strEPC==null ||strEPC.length()==0) {
			return existFlag;
		}
		String tempStr = "";
		for (int i = 0; i < tagList.size(); i++) {
			HashMap<String, String> temp = new HashMap<String, String>();
			temp = tagList.get(i);
			tempStr = temp.get("tagUii");
			if (strEPC.equals(tempStr)) {
				existFlag = i;
				break;
			}
		}
		return existFlag;
	}

	private void clearData() {
		tv_count.setText("0");
		tv_time.setText("0");
		tv_alltag.setText("0");
		tagList.clear();
		mlist.clear();
		CardNumber =0;
		Log.i("MY", "tagList.size " + tagList.size());
		adapter.notifyDataSetChanged();
	}
	/**
	 * 添加EPC到列表中
	 *
	 * @param
	 */
	private void addEPCToList(String rfid, String rssi) {
		if (!TextUtils.isEmpty(rfid)) {
			String epc="";
			String[] data = rfid.split(",");
			if(data.length==1)
			{
				epc = data[0];
			}
			else
			{
				epc = "EPC:"+data[0]+"\r\nMem:"+data[1];
			}

			int index = checkIsExist(epc);
			map = new HashMap<String, String>();

			map.put("tagUii", epc);
			map.put("tagCount", String.valueOf(1));
			map.put("tagRssi", rssi);
			CardNumber++;
			if (index == -1) {
				tagList.add(map);
				LvTags.setAdapter(adapter);
				tv_count.setText("" + adapter.getCount());
				mlist.add(data[0]);
			} else {
				int tagcount = Integer.parseInt(
						tagList.get(index).get("tagCount"), 10) + 1;

				map.put("tagCount", String.valueOf(tagcount));

				tagList.set(index, map);

			}
			tv_alltag.setText(String.valueOf(CardNumber));
			adapter.notifyDataSetChanged();

		}
	}
	
	@Override
	protected void onResume() {
		// TODO Auto-generated method stub
		super.onResume();
		isStopThread =false;
	}
	
	@Override
	public void onClick(View arg0) {
		try
		{
			if(arg0 == BtInventory)
			{
				readTag();
			}
			else if(arg0 == BtClear)
			{
				clearData();
			}

		}
		catch(Exception e)
		{
			stopInventory();
		}
	}

	private void readTag() {
		if (BtInventory.getText().equals(getString(R.string.btInventory)))// 识别标签
		{
			switch (inventoryFlag) {
				case 0:// 单步
				{
					List<ReadTag> newlist = new ArrayList<ReadTag>();
					//int result =Reader.rrlib.InventoryOnce((byte)0,(byte)4,(byte)0,(byte)0,(byte)0x80,(byte)0,(byte)10,newlist);
					Reader.rrlib.ScanRfid();
				}
				break;
				case 1:
				{
					int result = Reader.rrlib.StartRead();
					if(result==0)
					{
						BtInventory.setText(getString(R.string.title_stop_Inventory));
						setViewEnabled(false);
						if(timer == null) {
							beginTime = System.currentTimeMillis();
							timer = new Timer();
							timer.schedule(new TimerTask() {
								@Override
								public void run() {
									long ReadTime = System.currentTimeMillis() - beginTime;
									Message msg = handler.obtainMessage();
									msg.what = MSG_UPDATE_TIME;
									msg.obj = String.valueOf(ReadTime) ;
									handler.sendMessage(msg);
								}
							}, 0, 20);
						}

					}
				}
				break;
				default:
					break;
			}
		} else {// 停止识别

			stopInventory();
		}
	}
	private void stopInventory(){
		Reader.rrlib.StopRead();

		if(timer != null){
			timer.cancel();
			timer = null;
			BtInventory.setText(getString(R.string.btStoping));
		}
	}

	public class MsgCallback implements TagCallback {

		@Override
		public void tagCallback(ReadTag arg0) {

			// TODO Auto-generated method stub
			String epc="";
			String mem="";
			if(arg0.epcId!=null)
				epc = arg0.epcId.toUpperCase();
			if(arg0.memId!=null)
				mem = arg0.memId.toUpperCase();
			String rssi = String.valueOf(arg0.rssi);
			Message msg = handler.obtainMessage();
			msg.what = MSG_UPDATE_LISTVIEW;
			if(mem.length()==0)
				msg.obj =epc+","+rssi ;
			else
				msg.obj =epc+","+mem+","+rssi ;
			handler.sendMessage(msg);
		}

		@Override
		public void StopReadCallBack() {
			// TODO Auto-generated method stub

			Message msg = handler.obtainMessage();
			msg.what = MSG_UPDATE_STOP;
			msg.obj ="" ;
			handler.sendMessage(msg);
		}
	};
	
	@Override
	public void onItemClick(AdapterView<?> arg0, View arg1, int position, long arg3) {

	}
	
	@Override
	protected void onPause() {
		// TODO Auto-generated method stub
		super.onPause();
		stopInventory();
	}
	
	@Override
	protected void onDestroy() {
		// TODO Auto-generated method stub
		super.onDestroy();
	}
	

	
	@Override
	public void onItemSelected(AdapterView<?> arg0, View arg1, int position,
			long arg3) {
	}



	@Override
	public void onNothingSelected(AdapterView<?> arg0) {
		// TODO Auto-generated method stub
		
	}
}
