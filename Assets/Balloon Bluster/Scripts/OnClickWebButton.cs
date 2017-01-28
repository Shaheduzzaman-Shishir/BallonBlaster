using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class OnClickWebButton : MonoBehaviour 
{
	public bool isAppleStore;
	public bool isGoogleStore;
	public bool isAmazonStore;

	public string urlAppleStore ;
	public string urlGoogleStore= "https://play.google.com/store/apps/dev?id=8449310898275657078";
	public string urlAmazonStore;

	void Start()
	{
		GetComponent<Button> ().onClick.AddListener (() => {
			if(isAppleStore)
				Application.OpenURL(urlAppleStore);
			else if(isGoogleStore)
				Application.OpenURL(urlGoogleStore);
			else if(isAmazonStore)
				Application.OpenURL(urlAmazonStore);
			else
				Application.OpenURL(urlAppleStore);
		});
	}

}
