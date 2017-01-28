#pragma warning disable 0168 // variable declared but not used.
#pragma warning disable 0219 // variable assigned but not used.
#pragma warning disable 0414 // private field assigned but not used.
#pragma warning disable 0618 // obslolete
#pragma warning disable 0108 
#pragma warning disable 0649 //never used


using UnityEngine;
using System.Collections;
using System;

#if CHARTBOOST
using ChartboostSDK;

namespace AppAdvisory.Ads
{
	public class AAChartboost : AdBase, IInterstitial, IRewardedVideo
	{
		public string Name()
		{
			return "AAChartboost";
		}

		public void Init()
		{
			print("AAChartboost - Init");
			var c = FindObjectOfType<Chartboost>();

			if(c == null)
			{
				gameObject.AddComponent<Chartboost>();
			}

			Chartboost.setAutoCacheAds(true);

			Chartboost.cacheInterstitial (CBLocation.Default);
		}

	

		public bool IsReadyInterstitial()
		{
			bool isOK = Chartboost.hasInterstitial(CBLocation.Default);

			if(!isOK)
			{
				Chartboost.hasInterstitial(CBLocation.Default);
			}

			print("AAChartboost - IsReadyInterstitial : " + isOK.ToString());

			return isOK;
		}
		public void CacheInterstitial()
		{
			print("AAChartboost - CacheInterstitial");
			Chartboost.cacheInterstitial(CBLocation.Default);
		}
		public void ShowInterstitial()
		{
			print("AAChartboost - ShowInterstitial");
			Chartboost.showInterstitial (CBLocation.Default);
		}

		public bool IsReadyRewardedVideo()
		{
			bool isOK =  Chartboost.hasRewardedVideo(CBLocation.Default);

			if(!isOK)
			{
				Chartboost.hasRewardedVideo(CBLocation.Default);
			}

			print("AAChartboost - IsReadyRewardedVideo : " + isOK.ToString());

			return isOK;
		}
		public void CacheRewardedVideo()
		{
			print("AAChartboost - CacheRewardedVideo");
			Chartboost.cacheRewardedVideo(CBLocation.Default);
		}
		public void ShowRewardedVideo(Action<bool> success)
		{
			Chartboost.showRewardedVideo(CBLocation.Default);
			Chartboost.didFailToLoadRewardedVideo += delegate(CBLocation arg1, CBImpressionError arg2) 
			{
				Debug.Log ("user fail chartboost rewarded video - didFailToLoadRewardedVideo");

				print("AAChartboost - didFailToLoadRewardedVideo");

				if (success != null)
					success (false);
			};

			Chartboost.didCompleteRewardedVideo += delegate(CBLocation arg1, int arg2) 
			{
				Debug.Log ("user success chartboost rewarded video - didCompleteRewardedVideo");

				if (success != null)
					success (true);
			};

			Chartboost.didDismissRewardedVideo += delegate(CBLocation obj) 
			{
				Debug.Log ("user success chartboost rewarded video - didDismissRewardedVideo");

				if (success != null)
					success (false);
			};
		}
	}
}

#endif