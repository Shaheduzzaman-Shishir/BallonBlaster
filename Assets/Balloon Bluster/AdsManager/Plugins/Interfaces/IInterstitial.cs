using UnityEngine;
using System.Collections;

namespace AppAdvisory.Ads
{
	public interface IInterstitial : IIBase
	{
		bool IsReadyInterstitial();
		void CacheInterstitial();
		void ShowInterstitial();
	}
}