using UnityEngine;
using UnityEditor;
using System.Collections;
using System.IO;


namespace AppAdvisory.Ads
{
	//[InitializeOnLoad]
	//class StartupHelper2
	//{
	//	static StartupHelper2()
	//	{
	//		EditorApplication.update += Startup;
	//	}
	//	static void Startup()
	//	{
	//
	//
	//		if(Time.realtimeSinceStartup < 1)
	//			return;
	//
	//
	//		EditorApplication.update -= Startup;
	//
	//		Debug.Log("StartupHelper2");
	//
	//		string[] guids = AssetDatabase.FindAssets("ADS_SETTING");
	//		if(guids == null || guids.Length == 0)
	//		{
	//			Debug.Log("StartupHelper2 ---- guids == null || guids.Length == 0");
	//
	//			SDEUtility.CreateAdIds();
	//
	//			return;
	//		}
	//
	//		Debug.Log("StartupHelper2 ---- NOTHING DONE");
	//
	//	}
	//
	//	public static void CreateAsset<T>(string name) where T : ScriptableObject
	//	{
	//		var asset = ScriptableObject.CreateInstance<T>();
	//		ProjectWindowUtil.CreateAsset(asset, name + ".asset");
	//	}
	//
	//} 



	[CustomEditor(typeof(ADIDS))]
	public class SDInspectorGUI : Editor
	{
		public bool DEBUG
		{
			get
			{
				bool _bool = PlayerPrefsX.GetBool("_AADEBUG",false);

				return _bool;
			}

			set
			{

				bool _bool = PlayerPrefsX.GetBool("_AADEBUG",false);

				if(_bool == value)
					return;


				PlayerPrefsX.SetBool("_AADEBUG",value);
				PlayerPrefs.Save();


				var stringAndroid = PlayerSettings.GetScriptingDefineSymbolsForGroup(BuildTargetGroup.Android);

				stringAndroid = stringAndroid.Replace("AADEBUG" + ";","");

				stringAndroid = stringAndroid.Replace("AADEBUG","");

				if(value)
				{
					stringAndroid = "AADEBUG" + ";" + stringAndroid;
				}

				PlayerSettings.SetScriptingDefineSymbolsForGroup(BuildTargetGroup.Android,stringAndroid);


				var stringIOS = PlayerSettings.GetScriptingDefineSymbolsForGroup(BuildTargetGroup.iOS);

				stringIOS = stringIOS.Replace("AADEBUG" + ";","");

				stringIOS = stringIOS.Replace("AADEBUG","");


				if(value)
				{
					stringIOS = "AADEBUG" + ";" + stringIOS;
				}

				PlayerSettings.SetScriptingDefineSymbolsForGroup(BuildTargetGroup.iOS,stringIOS);
			}
		}

		public bool EnableChartboost
		{
			get
			{
				bool _bool = PlayerPrefsX.GetBool("_EnableChartboost",false);

				return _bool;
			}

			set
			{

				bool _bool = PlayerPrefsX.GetBool("_EnableChartboost",false);

				if(_bool == value)
					return;


				PlayerPrefsX.SetBool("_EnableChartboost",value);
				PlayerPrefs.Save();


				var stringAndroid = PlayerSettings.GetScriptingDefineSymbolsForGroup(BuildTargetGroup.Android);

				stringAndroid = stringAndroid.Replace("CHARTBOOST" + ";","");

				stringAndroid = stringAndroid.Replace("CHARTBOOST","");

				if(value)
				{
					stringAndroid = "CHARTBOOST" + ";" + stringAndroid;
				}

				PlayerSettings.SetScriptingDefineSymbolsForGroup(BuildTargetGroup.Android,stringAndroid);


				var stringIOS = PlayerSettings.GetScriptingDefineSymbolsForGroup(BuildTargetGroup.iOS);

				stringIOS = stringIOS.Replace("CHARTBOOST" + ";","");

				stringIOS = stringIOS.Replace("CHARTBOOST","");


				if(value)
				{
					stringIOS = "CHARTBOOST" + ";" + stringIOS;
				}

				PlayerSettings.SetScriptingDefineSymbolsForGroup(BuildTargetGroup.iOS,stringIOS);
			}
		}

		public bool EnableAdmob
		{
			get
			{
				bool _bool = PlayerPrefsX.GetBool("_EnableAdmob",false);

				return _bool;
			}

			set
			{
				bool _bool = PlayerPrefsX.GetBool("_EnableAdmob",false);

				if(value == true)
				{
					EnableIAD = false;
				}

		
				GOOGLE_MOBILE_ADS = value;
		
		

				if(_bool == value)
					return;

			

				PlayerPrefsX.SetBool("_EnableAdmob",value);
				PlayerPrefs.Save();


				var stringAndroid = PlayerSettings.GetScriptingDefineSymbolsForGroup(BuildTargetGroup.Android);

				stringAndroid = stringAndroid.Replace("ENABLE_ADMOB" + ";","");

				stringAndroid = stringAndroid.Replace("ENABLE_ADMOB","");

				if(value)
				{
					stringAndroid = "ENABLE_ADMOB" + ";" + stringAndroid;
				}

				PlayerSettings.SetScriptingDefineSymbolsForGroup(BuildTargetGroup.Android,stringAndroid);


				var stringIOS = PlayerSettings.GetScriptingDefineSymbolsForGroup(BuildTargetGroup.iOS);

				stringIOS = stringIOS.Replace("ENABLE_ADMOB" + ";","");

				stringIOS = stringIOS.Replace("ENABLE_ADMOB","");

				if(value)
				{
					stringIOS = "ENABLE_ADMOB" + ";" + stringIOS;
				}

				PlayerSettings.SetScriptingDefineSymbolsForGroup(BuildTargetGroup.iOS,stringIOS);
			}
		}

		public bool EnableIAD
		{
			get
			{
				bool _bool = PlayerPrefsX.GetBool("_EnableIAD",false);

				return _bool;
			}

			set
			{
				bool _bool = PlayerPrefsX.GetBool("_EnableIAD",false);

				if(value == true)
				{
					EnableAdmob = false;
				}

				if(_bool == value)
					return;

				PlayerPrefsX.SetBool("_EnableIAD",value);
				PlayerPrefs.Save();


				var stringAndroid = PlayerSettings.GetScriptingDefineSymbolsForGroup(BuildTargetGroup.Android);

				stringAndroid = stringAndroid.Replace("IAD" + ";","");

				stringAndroid = stringAndroid.Replace("IAD","");

				if(value)
				{
					stringAndroid = "IAD" + ";" + stringAndroid;
				}

				PlayerSettings.SetScriptingDefineSymbolsForGroup(BuildTargetGroup.Android,stringAndroid);


				var stringIOS = PlayerSettings.GetScriptingDefineSymbolsForGroup(BuildTargetGroup.iOS);

				stringIOS = stringIOS.Replace("IAD" + ";","");

				stringIOS = stringIOS.Replace("IAD","");

				if(value)
				{
					stringIOS = "IAD" + ";" + stringIOS;
				}

				PlayerSettings.SetScriptingDefineSymbolsForGroup(BuildTargetGroup.iOS,stringIOS);
			}
		}

		public bool EnableAdcolony
		{
			get
			{
				bool _bool = PlayerPrefsX.GetBool("_EnableAdcolony",false);

				return _bool;
			}

			set
			{
				bool _bool = PlayerPrefsX.GetBool("_EnableAdcolony",false);

				if(_bool == value)
					return;

				PlayerPrefsX.SetBool("_EnableAdcolony",value);
				PlayerPrefs.Save();


				var stringAndroid = PlayerSettings.GetScriptingDefineSymbolsForGroup(BuildTargetGroup.Android);

				stringAndroid = stringAndroid.Replace("ENABLE_ADCOLONY" + ";","");

				stringAndroid = stringAndroid.Replace("ENABLE_ADCOLONY","");

				if(value)
				{
					stringAndroid = "ENABLE_ADCOLONY" + ";" + stringAndroid;
				}

				PlayerSettings.SetScriptingDefineSymbolsForGroup(BuildTargetGroup.Android,stringAndroid);


				var stringIOS = PlayerSettings.GetScriptingDefineSymbolsForGroup(BuildTargetGroup.iOS);

				stringIOS = stringIOS.Replace("ENABLE_ADCOLONY" + ";","");

				stringIOS = stringIOS.Replace("ENABLE_ADCOLONY","");

				if(value)
				{
					stringIOS = "ENABLE_ADCOLONY" + ";" + stringIOS;
				}

				PlayerSettings.SetScriptingDefineSymbolsForGroup(BuildTargetGroup.iOS,stringIOS);
			}
		}

		public bool GOOGLE_MOBILE_ADS
		{
			get
			{
				bool _bool = PlayerPrefsX.GetBool("_GOOGLE_MOBILE_ADS",false);

				return _bool;
			}

			set
			{
				bool _bool = PlayerPrefsX.GetBool("_GOOGLE_MOBILE_ADS",false);

		
				if(_bool == value)
					return;



				PlayerPrefsX.SetBool("_GOOGLE_MOBILE_ADS",value);
				PlayerPrefs.Save();


				var stringAndroid = PlayerSettings.GetScriptingDefineSymbolsForGroup(BuildTargetGroup.Android);

				stringAndroid = stringAndroid.Replace("GOOGLE_MOBILE_ADS" + ";","");

				stringAndroid = stringAndroid.Replace("GOOGLE_MOBILE_ADS","");

				if(value)
				{
					stringAndroid = "GOOGLE_MOBILE_ADS" + ";" + stringAndroid;
				}

				PlayerSettings.SetScriptingDefineSymbolsForGroup(BuildTargetGroup.Android,stringAndroid);


				var stringIOS = PlayerSettings.GetScriptingDefineSymbolsForGroup(BuildTargetGroup.iOS);

				stringIOS = stringIOS.Replace("GOOGLE_MOBILE_ADS" + ";","");

				stringIOS = stringIOS.Replace("GOOGLE_MOBILE_ADS","");

				if(value)
				{
					stringIOS = "GOOGLE_MOBILE_ADS" + ";" + stringIOS;
				}

				PlayerSettings.SetScriptingDefineSymbolsForGroup(BuildTargetGroup.iOS,stringIOS);
			}
		}

	

		public override void OnInspectorGUI()
		{
			if(!PlayerPrefs.HasKey("APP_ADVISORY_FIRST_TIME_ADD"))
			{
				Debug.Log("APP_ADVISORY_FIRST_TIME_ADD");
				PlayerPrefs.SetInt("APP_ADVISORY_FIRST_TIME_ADD",0);
				PlayerPrefs.Save();

				DEBUG = false;
				EnableChartboost = false;
				EnableAdmob = false;
				GOOGLE_MOBILE_ADS = false;
			
				EnableIAD = false;
				EnableAdcolony = false;
			}

			var stringIos = PlayerSettings.GetScriptingDefineSymbolsForGroup(BuildTargetGroup.iOS);
			var stringAndroid = PlayerSettings.GetScriptingDefineSymbolsForGroup(BuildTargetGroup.Android);

			if(!stringIos.Contains("APPADVISORY_ADS"))
			{
				stringIos = "APPADVISORY_ADS" + ";" + stringIos;

				PlayerSettings.SetScriptingDefineSymbolsForGroup(BuildTargetGroup.iOS,stringIos);
			}

			if(!stringAndroid.Contains("APPADVISORY_ADS"))
			{
				stringAndroid = "APPADVISORY_ADS" + ";" + stringAndroid;

				PlayerSettings.SetScriptingDefineSymbolsForGroup(BuildTargetGroup.Android,stringAndroid);
			}

			PlayerSettings.SetScriptingDefineSymbolsForGroup(BuildTargetGroup.Android,stringAndroid);
			ADIDS t  = (ADIDS)target;



	//		DrawDefaultInspector();

			EditorGUILayout.BeginHorizontal();
			if(GUILayout.Button("GET\nADMOB\nSDK",  GUILayout.Width(100), GUILayout.Height(50)))
			{
				Application.OpenURL("https://github.com/googleads/googleads-mobile-unity");
			}

			if(GUILayout.Button("GET\nCHARTBOOST\nSDK",  GUILayout.Width(100), GUILayout.Height(50)))
			{
				Application.OpenURL("https://answers.chartboost.com/hc/en-us/articles/201219745-Unity-SDK-Download");
			}

			if(GUILayout.Button("GET\nADCOLONY\nSDK",  GUILayout.Width(100), GUILayout.Height(50)))
			{
				Application.OpenURL("https://github.com/AdColony/AdColony-Unity-SDK");
			}

			EditorGUILayout.EndHorizontal();
			EditorGUILayout.Space();
			EditorGUILayout.Space();



			DEBUG = EditorGUILayout.BeginToggleGroup(new GUIContent("DEBUG   [?]", "Activate if you want to debug rewarded ads"), DEBUG);
			EditorGUILayout.EndToggleGroup();

			#if AADEBUG
			EditorGUILayout.LabelField("");
			t.rewardedVideoAlwaysReadyInSimulator = EditorGUILayout.BeginToggleGroup(new GUIContent("Rewarded Video Always READY In Simulator    [?]", "Rewarded Video Always READY In Simulators"), t.rewardedVideoAlwaysReadyInSimulator);
			EditorGUILayout.EndToggleGroup();

			EditorGUILayout.LabelField("");
			t.rewardedVideoAlwaysSuccessInSimulator = EditorGUILayout.BeginToggleGroup(new GUIContent("Rewarded Video Always SUCCESS In Simulator    [?]", "Rewarded Video Always SUCCESS In Simulators"), t.rewardedVideoAlwaysSuccessInSimulator);
			EditorGUILayout.EndToggleGroup();
			#endif

		

			EnableChartboost = EditorGUILayout.BeginToggleGroup(new GUIContent("Enable Chartboost    [?]", "Check it to use Chartboost. Download the Chartboost SDK here: https://answers.chartboost.com/hc/en-us/"), EnableChartboost);
			EditorGUILayout.EndToggleGroup();

			EnableAdcolony = EditorGUILayout.BeginToggleGroup(new GUIContent("Enable Adcolony    [?]", "Check it to use ADColony. Download the Adcolony SDK here: https://github.com/AdColony"), EnableAdcolony);
			EditorGUILayout.EndToggleGroup();

			#if UNITY_IOS
			EnableIAD = EditorGUILayout.BeginToggleGroup(new GUIContent("Enable iAd    [?]", "Check it to use iAD (Admob will be disabled)"), EnableIAD);
			EditorGUILayout.EndToggleGroup();

			EnableAdmob = EditorGUILayout.BeginToggleGroup(new GUIContent("Enable Admob    [?]", "Check it to use Admob (iAD will be disabled)"), EnableAdmob);
			EditorGUILayout.EndToggleGroup();
			#else
			EnableAdmob = EditorGUILayout.BeginToggleGroup(new GUIContent("Enable Admob    [?]", "Check it to use Admob"), EnableAdmob);
			EditorGUILayout.EndToggleGroup();
			#endif

			EditorGUILayout.Space();
			EditorGUILayout.Space();

			#if ENABLE_ADMOB
	//		EditorGUILayout.LabelField("ADMOB SDK BY");
	//		GOOGLE_MOBILE_ADS = EditorGUILayout.BeginToggleGroup(new GUIContent("GOOGLE MOBILE ADS BY GOOGLE    [?]", "Get the SDK here : https://github.com/googleads/googleads-mobile-unity"), GOOGLE_MOBILE_ADS);
	//		EditorGUILayout.EndToggleGroup();
	//		STAN_ASSET_GOOGLEMOBILEADS = EditorGUILayout.BeginToggleGroup("GOOGLE MOBILE ADS BY STAN ASSET", STAN_ASSET_GOOGLEMOBILEADS);
	//		EditorGUILayout.EndToggleGroup();
	//		STAN_ASSET_ANDROIDNATIVE = EditorGUILayout.BeginToggleGroup("GOOGLE MOBILE ADS BY ANDROID NATIVE ", STAN_ASSET_ANDROIDNATIVE);
	//		EditorGUILayout.EndToggleGroup();

		
			#if STAN_ASSET_GOOGLEMOBILEADS || STAN_ASSET_ANDROIDNATIVE || GOOGLE_MOBILE_ADS

			t.IsAdmobSettingsOpened = EditorGUILayout.Foldout(t.IsAdmobSettingsOpened, "ADMOB");

			if(t.IsAdmobSettingsOpened)
			{
				t.IsAdmobIOSSettingsOpened = EditorGUILayout.Foldout(t.IsAdmobIOSSettingsOpened, "     iOS ADMOB IDs");
				if(t.IsAdmobIOSSettingsOpened)
				{
					EditorGUILayout.LabelField(new GUIContent("Admob Banner Id iOS    [?]", "Please enter your Admob BANNER Id for iOS"));
					t.AdmobBannerIdIOS = EditorGUILayout.TextArea(t.AdmobBannerIdIOS);
					EditorGUILayout.LabelField(new GUIContent("Admob Interstitial Id iOS    [?]", "Please enter your Admob INTERSTITIAL Id for iOS"));
					t.AdmobInterstitialIdIOS = EditorGUILayout.TextArea(t.AdmobInterstitialIdIOS);
				}
				t.IsAdmobANDROIDSettingsOpened = EditorGUILayout.Foldout(t.IsAdmobANDROIDSettingsOpened, "     ANDROID ADMOB IDs");
				if(t.IsAdmobANDROIDSettingsOpened)
				{
					EditorGUILayout.LabelField(new GUIContent("Admob Interstitial Id Android    [?]", "Please enter your Admob BANNER Id for ANDROID"));
					t.AdmobBannerIdANDROID = EditorGUILayout.TextArea(t.AdmobBannerIdANDROID);
					EditorGUILayout.LabelField(new GUIContent("Admob Interstitial Id Android    [?]", "Please enter your Admob INTERSTITIAL Id for ANDROID"));
					t.AdmobInterstitialIdANDROID = EditorGUILayout.TextArea(t.AdmobInterstitialIdANDROID);
				}
//				t.IsAdmobAMAZONSettingsOpened = EditorGUILayout.Foldout(t.IsAdmobAMAZONSettingsOpened, "     ANDROID AMAZON IDs");
//				if(t.IsAdmobAMAZONSettingsOpened)
//				{
//					EditorGUILayout.LabelField(new GUIContent("Admob Interstitial Id Amazon    [?]", "Please enter your Admob BANNER Id for AMAZON"));
//					t.AdmobBannerIdAMAZON = EditorGUILayout.TextArea(t.AdmobBannerIdAMAZON);
//					EditorGUILayout.LabelField(new GUIContent("Admob Interstitial Id Amazon    [?]", "Please enter your Admob INTERSTITIAL Id for AMAZON"));
//					t.AdmobInterstitialIdAMAZON = EditorGUILayout.TextArea(t.AdmobInterstitialIdAMAZON);
//				}
			}
			EditorGUILayout.Space();
			EditorGUILayout.Space();
			#endif


			#endif


			#if UNITY_ADS

			t.IsUnityAdsSettingsOpened = EditorGUILayout.Foldout(t.IsUnityAdsSettingsOpened, "UNITY ADS");

			if(t.IsUnityAdsSettingsOpened)
			{
				EditorGUILayout.LabelField(new GUIContent("Rewarded video zone unity ads    [?]", "If you don't know what it is, have a look to the Unity Ads documentation: https://unityads.unity3d.com"));
				t.rewardedVideoZoneUnityAds = EditorGUILayout.TextField(t.rewardedVideoZoneUnityAds);
			}
			EditorGUILayout.Space();
			EditorGUILayout.Space();
			#endif


			#if ENABLE_ADCOLONY
			t.IsADColonySettingsOpened = EditorGUILayout.Foldout(t.IsADColonySettingsOpened, "ADCOLONY");

			if(t.IsADColonySettingsOpened)
			{

			#if ENABLE_ADCOLONY
		
				EditorGUILayout.LabelField(new GUIContent("ADColony App ID iOS    [?]", "Please enter your ADColony App ID for iOS"));
				t.AdColonyAppID_iOS = EditorGUILayout.TextField(t.AdColonyAppID_iOS);
	
				EditorGUILayout.Space();
				EditorGUILayout.Space();

		
				EditorGUILayout.LabelField(new GUIContent("ADColony App ID ANDROID    [?]", "Please enter your ADColony App ID for ANDROID"));
				t.AdColonyAppID_ANDROID = EditorGUILayout.TextField(t.AdColonyAppID_ANDROID);
	
				EditorGUILayout.Space();
				EditorGUILayout.Space();

					EditorGUILayout.BeginHorizontal();
					EditorGUILayout.LabelField(new GUIContent("ADColony Interstitial Video Zone Key iOS   [?]", "ADColony Interstitial Video Zone Key iOS"));
					EditorGUILayout.LabelField(new GUIContent("ADColony Interstitial Video Zone ID iOS   [?]", "ADColony Interstitial Video Zone ID iOS"));
					EditorGUILayout.EndHorizontal();
					EditorGUILayout.BeginHorizontal();
					t.AdColonyInterstitialVideoZoneKEY_iOS = EditorGUILayout.TextField(t.AdColonyInterstitialVideoZoneKEY_iOS);
					t.AdColonyInterstitialVideoZoneID_iOS = EditorGUILayout.TextField(t.AdColonyInterstitialVideoZoneID_iOS);
					EditorGUILayout.EndHorizontal();
					EditorGUILayout.Space();
					EditorGUILayout.Space();

					EditorGUILayout.BeginHorizontal();
					EditorGUILayout.LabelField(new GUIContent("ADColony Interstitial Video Zone Key Android   [?]", "ADColony Interstitial Video Zone Key Android"));
					EditorGUILayout.LabelField(new GUIContent("ADColony Interstitial Video Zone ID Android   [?]", "ADColony Interstitial Video Zone OD Android"));
					EditorGUILayout.EndHorizontal();
					EditorGUILayout.BeginHorizontal();
					t.AdColonyInterstitialVideoZoneKEY_ANDROID = EditorGUILayout.TextField(t.AdColonyInterstitialVideoZoneKEY_ANDROID);
					t.AdColonyInterstitialVideoZoneID_ANDROID = EditorGUILayout.TextField(t.AdColonyInterstitialVideoZoneID_ANDROID);
					EditorGUILayout.EndHorizontal();
					EditorGUILayout.Space();
					EditorGUILayout.Space();
				


		

					EditorGUILayout.BeginHorizontal();
					EditorGUILayout.LabelField(new GUIContent("ADColony Rewarded Video Zone Key iOS   [?]", "ADColony Rewarded Video Zone Key iOS"));
					EditorGUILayout.LabelField(new GUIContent("ADColony Rewarded Video Zone ID iOS   [?]", "ADColony Rewarded Video Zone ID iOS"));
					EditorGUILayout.EndHorizontal();
					EditorGUILayout.BeginHorizontal();
					t.AdColonyRewardedVideoZoneKEY_iOS = EditorGUILayout.TextField(t.AdColonyRewardedVideoZoneKEY_iOS);
					t.AdColonyRewardedVideoZoneID_iOS = EditorGUILayout.TextField(t.AdColonyRewardedVideoZoneID_iOS);
					EditorGUILayout.EndHorizontal();
					EditorGUILayout.Space();
					EditorGUILayout.Space();


					EditorGUILayout.BeginHorizontal();
					EditorGUILayout.LabelField(new GUIContent("ADColony Rewarded Video Zone Key Android   [?]", "ADColony Rewarded Video Zone Key Android"));
					EditorGUILayout.LabelField(new GUIContent("ADColony Rewarded Video Zone ID Android   [?]", "ADColony Rewarded Video Zone OD Android"));
					EditorGUILayout.EndHorizontal();
					EditorGUILayout.BeginHorizontal();
					t.AdColonyRewardedVideoZoneKEY_ANDROID = EditorGUILayout.TextField(t.AdColonyRewardedVideoZoneKEY_ANDROID);
					t.AdColonyRewardedVideoZoneID_ANDROID = EditorGUILayout.TextField(t.AdColonyRewardedVideoZoneID_ANDROID);
					EditorGUILayout.EndHorizontal();
					EditorGUILayout.Space();
					EditorGUILayout.Space();


			#endif
				
			}

		
		





			#endif



		

			#if ENABLE_ADMOB || CHARTBOOST || IAD || ADCOLONY_INTERSTITIAL

			EditorGUILayout.Space();
			EditorGUILayout.Space();


			#if BASED_TIME_INTERSTITIAL
			EditorGUILayout.LabelField("");
			EditorGUILayout.LabelField(new GUIContent("Number Of Minutes To Show Interstitial   [?]", "Number Of Minutes To Show Interstitial "));
			t.numberOfMinutesToShowAnInterstitialAtGameOver = EditorGUILayout.IntField(t.numberOfMinutesToShowAnInterstitialAtGameOver);
			#else
			EditorGUILayout.Space();
			EditorGUILayout.LabelField(new GUIContent("Number Of Play To Show Interstitial   [?]", "Number Of Play To Show Interstitial "));

			#endif



			EditorGUILayout.Space();
			t.ShowIntertitialAtStart = EditorGUILayout.BeginToggleGroup(new GUIContent("Show interstitial at start  [?]", "Check it if you want to display interstitals ads at launch"), t.ShowIntertitialAtStart);
			EditorGUILayout.EndToggleGroup();


			#endif


	//		serializedObject.Update();
	//		SerializedProperty _cc = serializedObject.FindProperty("cc");
	//		EditorGUILayout.PropertyField(_cc,true,null);
	//		serializedObject.ApplyModifiedProperties();

			if (GUI.changed)
			{
				EditorUtility.SetDirty(t); 
				PlayerPrefs.Save();
			}
		}
	}


}