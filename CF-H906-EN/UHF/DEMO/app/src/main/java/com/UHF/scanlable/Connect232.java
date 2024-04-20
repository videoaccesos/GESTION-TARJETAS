package com.UHF.scanlable;

import java.io.File;
import java.io.IOException;
import java.lang.reflect.Method;
import java.security.InvalidParameterException;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import com.UHF.scanlable.R;
import com.rfid.trans.RFIDLogCallBack;
import com.rfid.trans.ReaderParameter;

import android.Manifest;
import android.content.BroadcastReceiver;
import android.content.Context;
import android.content.IntentFilter;
import android.content.pm.PackageManager;
import android.media.AudioManager;
import android.media.SoundPool;
import android.os.Bundle;
import android.app.Activity;
import android.content.Intent;
import android.os.SystemClock;
import android.support.v4.app.ActivityCompat;
import android.support.v7.app.AppCompatActivity;
import android.util.Log;
import android.view.KeyEvent;
import android.view.Menu;
import android.view.View;
import android.view.View.OnClickListener;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.Spinner;
import android.widget.TableRow;
import android.widget.TextView;
import android.widget.Toast;
public class Connect232 extends AppCompatActivity {


		private static final String TAG = "COONECTRS232";
		private static String devport = "/dev/ttyHSL2";
		private static final boolean DEBUG = true;
		private TextView mConectButton;

		
		private TextView   mBaud9600View, mBaud19200View,  mBaud38400View,mBaud57600View,mBaud115200View;

		private int mPosPort = -1;

	String temp;
		String[] entries = null;
		String[] entryValues = null;
		private ArrayAdapter<String> spacom; 
		public static int baud = 115200;
	    String readerosType = null;
		@Override
		protected void onCreate(Bundle savedInstanceState) {
			super.onCreate(savedInstanceState);
			setContentView(R.layout.activity_connect232);
			mVirtualKeyListenerBroadcastReceiver = new VirtualKeyListenerBroadcastReceiver();
			IntentFilter intentFilter = new IntentFilter(Intent.ACTION_CLOSE_SYSTEM_DIALOGS);
			this.registerReceiver(mVirtualKeyListenerBroadcastReceiver, intentFilter);
			initSound();
			verifyStoragePermissions(this);
			mConectButton = (TextView) findViewById(R.id.textview_connect);

			mBaud9600View = (TextView) findViewById(R.id.baud_9600);
			mBaud19200View =  (TextView) findViewById(R.id.baud_19200);
			mBaud38400View =  (TextView) findViewById(R.id.baud_38400);
			mBaud57600View =  (TextView) findViewById(R.id.baud_57600);
			mBaud115200View =  (TextView) findViewById(R.id.baud_115200);


			
			baud = 57600;
			mBaud9600View.setOnClickListener(new OnClickListener() {
				@Override
				public void onClick(View v) {
					baud = 9600;
				}
			});

			mBaud19200View.setOnClickListener(new OnClickListener() {
				@Override
				public void onClick(View v) {
					baud = 19200;
				}
			});
			mBaud38400View.setOnClickListener(new OnClickListener() {
				@Override
				public void onClick(View v) {
					baud = 38400;
				}
			});
			mBaud57600View.setOnClickListener(new OnClickListener() {
				@Override
				public void onClick(View v) {
					baud = 57600;
				}
			});
			mBaud115200View.setOnClickListener(new OnClickListener() {
				@Override
				public void onClick(View v) {
					baud = 115200;
				}
			});
			

			mConectButton.setOnClickListener(new OnClickListener() {
				@Override
				public void onClick(View v) {
					try {
						int result = Reader.rrlib.Connect("/dev/ttyHSL0", baud,1);
						if(result==0){
							Intent intent;
							intent = new Intent().setClass(Connect232.this, MainActivity.class);
							startActivity(intent);
						}
						else
						{
							Toast.makeText(
									getApplicationContext(),
									getString(R.string.openport_failed),
									Toast.LENGTH_SHORT).show();
						}
					}catch (Exception e) 
					{
						Toast.makeText(
								getApplicationContext(),
								getString(R.string.openport_failed),
								Toast.LENGTH_SHORT).show();
					}
				}
			});
		}

	private static final int REQUEST_EXTERNAL_STORAGE = 1;
	private static String[] PERMISSIONS_STORAGE = {
			Manifest.permission.READ_EXTERNAL_STORAGE,
			Manifest.permission.WRITE_EXTERNAL_STORAGE
	};
	public static void verifyStoragePermissions(Activity activity) {

		// Check if we have write permission
		int permission = ActivityCompat.checkSelfPermission(activity, Manifest.permission.WRITE_EXTERNAL_STORAGE);

		if (permission != PackageManager.PERMISSION_GRANTED) {
			// We don't have permission so prompt the user
			ActivityCompat.requestPermissions(
					activity,
					PERMISSIONS_STORAGE,
					REQUEST_EXTERNAL_STORAGE
			);
		}
	}
    static HashMap<Integer, Integer> soundMap = new HashMap<Integer, Integer>();
    private static SoundPool soundPool;
    private static float volumnRatio;
    private static AudioManager am;
    private  void initSound(){
        soundPool = new SoundPool(10, AudioManager.STREAM_MUSIC, 5);
        soundMap.put(1, soundPool.load(this, R.raw.barcodebeep, 1));
        am = (AudioManager) this.getSystemService(AUDIO_SERVICE);// 实例化AudioManager对象
        Reader.rrlib.SetSoundID(soundMap.get(1),soundPool);
    }

	@Override
	protected void onResume() {
		// TODO Auto-generated method stub
		Reader.rrlib.PowerControll(null,true);
		SystemClock.sleep(1500);

		super.onResume();
	}
		public boolean onKeyDown(int keyCode, KeyEvent event) {
			if (keyCode == KeyEvent.KEYCODE_BACK) {
				
				finish();

				return true;
			}
			return super.onKeyDown(keyCode, event);
		}
		
		@Override
		protected void onDestroy() {
			// TODO Auto-generated method stub
			Reader.rrlib.PowerControll(null,false);
			this.unregisterReceiver(mVirtualKeyListenerBroadcastReceiver);
			super.onDestroy();
		}


	private VirtualKeyListenerBroadcastReceiver mVirtualKeyListenerBroadcastReceiver;
	public  static boolean mSwitchFlag = false;
	private class VirtualKeyListenerBroadcastReceiver extends BroadcastReceiver {
		private final String SYSTEM_REASON = "reason";
		private final String SYSTEM_HOME_KEY = "homekey";
		private final String SYSTEM_RECENT_APPS = "recentapps";

		@Override
		public void onReceive(Context context, Intent intent) {
			String action = intent.getAction();
			if (action.equals(Intent.ACTION_CLOSE_SYSTEM_DIALOGS)) {
				String systemReason = intent.getStringExtra(SYSTEM_REASON);
				if (systemReason != null) {
					Reader.rrlib.PowerControll(null,false);
					mSwitchFlag = true;
					if (systemReason.equals(SYSTEM_HOME_KEY)) {
						System.out.println("Press HOME key");
					} else if (systemReason.equals(SYSTEM_RECENT_APPS)) {
						System.out.println("Press RECENT_APPS key");
						//Reader.rrlib.set53CGPIOEnabled(false);
						//mSwitchFlag = true;
					}

				}
			}
		}
	}


}
