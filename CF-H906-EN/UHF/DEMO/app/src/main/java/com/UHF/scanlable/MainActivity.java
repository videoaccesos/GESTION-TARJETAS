package com.UHF.scanlable;

import com.UHF.scanlable.R;
//import com.UHF.scanlable.UHfData.UHfGetData;

import android.app.AlertDialog;
import android.content.BroadcastReceiver;
import android.content.Context;
import android.content.DialogInterface;
import android.content.IntentFilter;
import android.content.pm.PackageManager;
import android.os.Bundle;
import android.app.Activity;
import android.app.TabActivity;
import android.content.Intent;
import android.os.SystemClock;
import android.support.annotation.NonNull;
import android.view.Menu;
import android.view.Window;
import android.widget.TabHost;

import java.util.ArrayList;
import java.util.List;

public class MainActivity extends TabActivity {
	
	private TabHost myTabHost;

	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		requestWindowFeature(Window.FEATURE_NO_TITLE);
		setContentView(R.layout.activity_main);
		myTabHost = getTabHost();
		Intent intent0 = new Intent(this,ScanMode.class);
		Intent intent1 = new Intent(this,ReadWriteActivity.class);
		Intent intent2 = new Intent(this,ScanView.class);
		//Intent intent3 = new Intent(this,FSTActivity.class);
		//Intent intent4 = new Intent(this,FDActivity.class);
		
		TabHost.TabSpec tabSpec0 = myTabHost.newTabSpec(getString(R.string.tab_scan)).setIndicator(getString(R.string.tab_scan)).setContent(intent0);
		TabHost.TabSpec tabSpec1 = myTabHost.newTabSpec(getString(R.string.tab_rw)).setIndicator(getString(R.string.tab_rw)).setContent(intent1);
		TabHost.TabSpec tabSpec2 = myTabHost.newTabSpec(getString(R.string.tab_param)).setIndicator(getString(R.string.tab_param)).setContent(intent2);
		//TabHost.TabSpec tabSpec3 = myTabHost.newTabSpec(getString(R.string.tab_fst)).setIndicator(getString(R.string.tab_fst)).setContent(intent3);
		//TabHost.TabSpec tabSpec4 = myTabHost.newTabSpec(getString(R.string.tab_fd)).setIndicator(getString(R.string.tab_fd)).setContent(intent4);

		myTabHost.addTab(tabSpec0);
		myTabHost.addTab(tabSpec1);
		//myTabHost.addTab(tabSpec3);
		//myTabHost.addTab(tabSpec4);
		myTabHost.addTab(tabSpec2);
		myTabHost.setCurrentTab(0);
    }

	@Override
	public boolean onCreateOptionsMenu(Menu menu) {
		return true;
	}
	@Override
	protected void onResume() {
		// TODO Auto-generated method stub
		if(Connect232.mSwitchFlag)
		{
			Reader.rrlib.PowerControll(null,true);
			SystemClock.sleep(1000);
		}


		super.onResume();
	}
	@Override
	protected void onPause() {
		// TODO Auto-generated method stub
		//Reader.rrlib.DisConnect();
		super.onPause();
	}

	@Override
	protected void onDestroy() {
		// TODO Auto-generated method stub
		super.onDestroy();

		Reader.rrlib.DisConnect();
	}

	@Override
	public void onRequestPermissionsResult(int requestCode, @NonNull String[] permissions, @NonNull int[] grantResults) {
		super.onRequestPermissionsResult(requestCode, permissions, grantResults);

		switch (requestCode){
			case 102:
				if (grantResults.length>0){
					List<String> deniedPermissions = new ArrayList<>();
					List<String> grantedPermissions = new ArrayList<>();
					for (int i = 0; i < grantResults.length; i++) {
						int grantResult = grantResults[i];
						if (grantResult != PackageManager.PERMISSION_GRANTED){
							String permission = permissions[i];
							deniedPermissions.add(permission);
						}else{
							String permission = permissions[i];
							grantedPermissions.add(permission);
						}
					}
					if (deniedPermissions.isEmpty()){


					}else{

					}
				}
				break;
		}
	}


}
