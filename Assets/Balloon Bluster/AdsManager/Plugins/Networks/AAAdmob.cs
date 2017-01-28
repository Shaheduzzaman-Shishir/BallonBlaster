#pragma warning disable 0168 // variable declared but not used.
#pragma warning disable 0219 // variable assigned but not used.
#pragma warning disable 0414 // private field assigned but not used.
#pragma warning disable 0618 // obslolete
#pragma warning disable 0108 
#pragma warning disable 0649 //never used


using UnityEngine;
using System.Collections;
using System;

#if ENABLE_ADMOB

using GoogleMobileAds.Api;

namespace AppAdvisory.Ads
{
	public class AAAdmob : AdBase, IInterstitial, IBanner
	{
		public string bannerId
		{
			get
			{
				return adIds.admobBannerID;
			}
		}

		public string interstitialID
		{
			get
			{
				return adIds.admobInterstitialID;
			}
		}
			
		public string Name()
		{
			return "AAAdmob";
		}

		public void Init()
		{
			//Debug.LogWarning("AAAdmob - Init");

			RequestBanner();

			RequestInterstitial();
		}

		BannerView bannerView;
		InterstitialAd interstitial;

		private void RequestBanner()
		{
			//Debug.LogWarning("AAAdmob - RequestBanner");
			if(!string.IsNullOrEmpty(bannerId))
			{
				// Create a 320x50 banner at the top of the screen.
				bannerView = new BannerView(bannerId, AdSize.SmartBanner, AdPosition.Bottom);
				// Create an empty ad request.
				AdRequest request = new AdRequest.Builder().Build();
				// Load the banner with the request.
				bannerView.LoadAd(request);
			}
		}

		private void RequestInterstitial()
		{
			//Debug.LogWarning("AAAdmob - RequestInterstitial");
			if(!string.IsNullOrEmpty(interstitialID))
			{
				// Initialize an InterstitialAd.
				interstitial = new InterstitialAd(interstitialID);
				// Create an empty ad request.
				AdRequest request = new AdRequest.Builder().Build();
				// Load the interstitial with the request.
				interstitial.LoadAd(request);
			}
		}



		public void ShowBanner()
		{
			//Debug.LogWarning("AAAdmob - ShowBanner");
			if(bannerView == null)
			{
				RequestBanner();

				bannerView.OnAdLoaded += delegate(object sender, EventArgs e) {
					bannerView.Show();
				};
			}
			else
			{
				bannerView.Show();
			}
		}

		public void HideBanner()
		{
			//Debug.LogWarning("AAAdmob - HideBanner");

			if(bannerView != null)
				bannerView.Hide();
		}
		public void DestroyBanner()
		{
			//Debug.LogWarning("AAAdmob - DestroyBanner");

			if(bannerView != null)
			{
				bannerView.Destroy();
			}
		}
		public bool IsReadyInterstitial()
		{
			bool isOK = false;

			if(interstitial != null)
			{
				isOK = interstitial.IsLoaded();

				if(!isOK)
				{
					CacheInterstitial();
				}
			}

			//Debug.LogWarning("AAAdmob - IsReadyInterstitial : " + isOK);

			return isOK;
		}
		public void CacheInterstitial()
		{
			//Debug.LogWarning("AAAdmob - CacheInterstitial");

			if(interstitial == null)
			{
				RequestInterstitial();
				return;
			}
			else
			{
				if(interstitial != null && !interstitial.IsLoaded())
				{
					interstitial.LoadAd( new AdRequest.Builder().Build());
				}
				else
				{
					RequestInterstitial();
				}
			}
		}
		public void ShowInterstitial()
		{
			//Debug.LogWarning("AAAdmob - ShowInterstitial");

			if(interstitial != null && !interstitial.IsLoaded())
			{
				interstitial.Show();
			}
			else
			{
				RequestInterstitial();
				interstitial.OnAdLoaded += delegate(object sender, EventArgs e) {
					interstitial.Show();
				};
			}
		}
	}
}

#endif