using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using System;
#if APPADVISORY_ADS
using AppAdvisory.Ads;
#endif
/// <summary>
/// In Charge to display and managed all the UI elements in the game
/// </summary>
public class CanvasManager : MonoBehaviourHelper
{
	public int NumberOfWinOrLoseToShowInterstitial = 5;

	AudioSource _music;
	/// <summary>
	/// Reference to the music AudioSource
	/// </summary>
	public AudioSource music
	{
		get 
		{
			if (_music == null)
				_music = Camera.main.GetComponentInChildren<AudioSource> ();

			return _music;
		}
	}

	public Text levelText;

	public Button buttonNextLevel;
	public Button buttonLastLevel;

	public Button buttonSetting;

	public Button buttonUnlock;

	public Button buttonLike;
	public Button buttonLeaderboard;
	public Button buttonRate;
	public Button buttonShare;
	public Button buttonMoreGames;
	public Button buttonSound;

	/// <summary>
	/// Get the max level the player could play. A level is playable if the player unlock the previous level. for exemple: to player the level 10, the player have to cleared the level 
	/// </summary>
	int maxLevel
	{
		get 
		{
			return Util.GetMaxLevelUnlock();
		}
	}
	/// <summary>
	/// Get the last level the player played
	/// </summary>
	int lastLevel
	{
		get 
		{
			return Util.GetLastLevelPlayed();
		}
	}
	/// <summary>
	/// Set all the UI In Game Buttons
	/// </summary>
	void SetButtons()
	{

		buttonLastLevel.onClick.AddListener (() => {
			buttonUnlock.transform.DOKill();
			buttonUnlock.transform.DOScale(Vector3.zero,0.3f);
			Util.SetCountGameOver(0);
			ButtonLogic ();
			OnClickedButtonPreviousLevel();
			ButtonLogic ();
		});


		buttonNextLevel.onClick.AddListener (() => {
			buttonNextLevel.transform.DOKill();
			buttonNextLevel.transform.DOScale(Vector3.zero,0.3f);
			Util.SetCountGameOver(0);
			ButtonLogic ();
			OnClickedButtonNextLevel();
			ButtonLogic ();
		});


		foreach (Transform t in buttonSetting.transform.parent) 
		{
			if (t.GetComponent<Canvas> () != null)
				t.GetComponent<Canvas> ().sortingOrder = 10 - t.GetSiblingIndex ();
		}

		var gridLayoutGroup = buttonSetting.GetComponentInParent<GridLayoutGroup>();
		gridLayoutGroup.spacing = new Vector2(0,-43);

		buttonSetting.onClick.AddListener (() => {

			buttonSetting.enabled = false;

			float startvalue = 10;
			float endvalue = -43;

			if(gridLayoutGroup.spacing.y == -43)
			{
				startvalue = -43;
				endvalue = 10;

				buttonSetting.transform.DORotate ( new Vector3(0, 0, 360), 1, RotateMode.FastBeyond360);
			}
			else
			{
				buttonSetting.transform.DORotate ( new Vector3(0, 0, -360), 1, RotateMode.FastBeyond360);
			}



			DOVirtual.Float(startvalue, endvalue, 1, (float value) => {
				gridLayoutGroup.spacing = new Vector2(0,value);
			}).OnComplete(() => {
				buttonSetting.enabled = true;
			});
		});

		buttonUnlock.onClick.AddListener (() => {
			buttonUnlock.transform.DOScale(Vector3.zero,0.3f);
			ShowRewardedVideoGameOver();
		});

		buttonUnlock.transform.localScale = Vector3.zero;


		buttonLike.onClick.AddListener (() => {
			string facebookApp = "fb://profile/515431001924232" ;
			string facebookAddress = "https://www.facebook.com/gngtech/";

			float startTime;
			startTime = Time.timeSinceLevelLoad;

			Application.OpenURL(facebookApp);

			if (Time.timeSinceLevelLoad - startTime <= 1f)
			{
				Application.OpenURL(facebookAddress);
			}

		});

		buttonLeaderboard.onClick.AddListener (() => {

			Application.Quit();

		});


		buttonRate.onClick.AddListener (() => {
			Application.OpenURL ("https://play.google.com/store/apps/dev?id=8449310898275657078");
			
		});


		buttonShare.onClick.AddListener (() => {
			Application.OpenURL ("https://www.facebook.com/gamertodeveloper/");
		});



		buttonMoreGames.onClick.AddListener (() => {
			Application.OpenURL ("https://play.google.com/store/apps/dev?id=8449310898275657078");
		});

		if (!Util.SoundIsOn()) 
		{
			music.Stop ();
			buttonSound.transform.GetChild (0).gameObject.SetActive (false);
			buttonSound.transform.GetChild (1).gameObject.SetActive (true);
		}
		else 
		{
			music.Play ();
			buttonSound.transform.GetChild (0).gameObject.SetActive (true);
			buttonSound.transform.GetChild (1).gameObject.SetActive (false);
		}

		buttonSound.onClick.AddListener (() => {
			TurnSound();
		});
	}
	/// <summary>
	/// Turn on/off the sounds in the game
	/// </summary>
	void TurnSound()
	{
		if (Util.SoundIsOn()) 
		{
			music.Stop ();
			Util.SetSoundOff();
			buttonSound.transform.GetChild (0).gameObject.SetActive (false);
			buttonSound.transform.GetChild (1).gameObject.SetActive (true);
		}
		else 
		{
			music.Play ();
			Util.SetSoundOn();
			buttonSound.transform.GetChild (0).gameObject.SetActive (true);
			buttonSound.transform.GetChild (1).gameObject.SetActive (false);
		}
			
		PlayerPrefs.Save();
	}

	void Awake()
	{
		DOTween.Init ();


		SetButtons ();


		ButtonLogic ();

	}

	/// <summary>
	/// Show rewarded video at game over
	/// </summary>
	private void ShowRewardedVideoGameOver()
	{
		gameManager.success = false;
		gameManager.isGameOver = false;

		#if APPADVISORY_ADS
		if(AdsManager.instance.IsReadyRewardedVideo())
		{
			AdsManager.instance.ShowRewardedVideo ((bool success) => {
				if(success)
					PlayNextLevel ();
			});
		}
		#endif
	}


	/// <summary>
	/// Display the next and/or last button (the arrow around the level at the top of the screen)
	/// </summary>
	public void ButtonLogic()
	{
//		if (gameManager.isGameOver || gameManager.success) 
//		{
//			SetButtonActive(buttonLastLevel,false);
//			SetButtonActive(buttonNextLevel,false);
//			return;
//		}

		SetButtonActive(buttonLastLevel, Util.ActivateButtonLast());

		SetButtonActive(buttonNextLevel, Util.ActivateButtonNext());

	}
	/// <summary>
	/// Activate and enable - or not - buttons
	/// </summary>
	void SetButtonActive(Button b,bool isActive)
	{
		if (isActive) 
		{
			b.GetComponent<Image> ().color = new Color(b.GetComponent<Image> ().color.r,b.GetComponent<Image> ().color.g,b.GetComponent<Image> ().color.b,1);
			b.interactable = true;
			b.transform.localScale = new Vector3(0.7f, 0.7f, 1f);
		}
		else 
		{
			b.GetComponent<Image> ().color = new Color(b.GetComponent<Image> ().color.r,b.GetComponent<Image> ().color.g,b.GetComponent<Image> ().color.b,0);
			b.interactable = false;
			b.transform.localScale = new Vector3(0.7f, 0.7f, 1f);
		}

	}

	IEnumerator Start()
	{
		yield return new WaitForSeconds (0.1f);

		PlayLevel (lastLevel);
	}
	/// <summary>
	/// When the player failed, we show an unlock button ONLY IF there is a rewarded video available
	/// </summary>
	void ShowButtonUnlock()
	{
		#if APPADVISORY_ADS
		if (AdsManager.instance.IsReadyRewardedVideo()) 
		{
			if (buttonUnlock.transform.localScale.x == 1) 
			{
				buttonUnlock.transform.DOScale (Vector3.one * 1.5f, 0.3f).SetLoops (6, LoopType.Yoyo);
			}
			else
			{
				buttonUnlock.transform.DOScale (Vector3.one, 0.3f);
			}
		} 
		return;
		#endif




	}

	void ShowAdsLogic()
	{
		#if APPADVISORY_ADS
		int count = PlayerPrefs.GetInt("GAMEOVER_COUNT",0);
		count ++;
		if(count > NumberOfWinOrLoseToShowInterstitial)
		{
			if(AdsManager.instance.IsReadyInterstitial())
			{
				PlayerPrefs.SetInt("GAMEOVER_COUNT",0);
				AdsManager.instance.ShowInterstitial ();
			}
			else
			{
				PlayerPrefs.SetInt("GAMEOVER_COUNT",count);
			}
		}
		else
		{
			PlayerPrefs.SetInt("GAMEOVER_COUNT",count);
		}
		PlayerPrefs.Save();
		#endif
	}
	/// <summary>
	/// Animation when the player fails 
	/// </summary>
	public void AnimationCameraGameOver(Vector3 impactPosition)
	{

		FindObjectOfType<RateUsManager>().CheckIfPromptRateDialogue();

		ShowAdsLogic();

		ShowButtonUnlock();

		ReplayCurrentLevel (lastLevel);
	}
	/// <summary>
	/// Animation when the player cleared a level 
	/// </summary>
	public void AnimationCameraSuccess()
	{
		Util.SetCountGameOver(0);

		FindObjectOfType<RateUsManager>().CheckIfPromptRateDialogue();

		ShowAdsLogic();

		buttonUnlock.transform.DOScale(Vector3.zero,0.3f);

		PlayNextLevel ();
	}
	/// <summary>
	/// Run the level logic on the UI side
	/// </summary>
	private void PlayLevel(int level)
	{
		levelText.text = "Level " + level.ToString() + " / 1200";

		if(level > maxLevel)
			Util.SetMaxLevelUnlock(level);

		Util.SetLastLevelPlayed(level);

		ButtonLogic ();

		gameManager.CreateGame (level);


	}
	/// <summary>
	/// Method called when the player clicked on the left arrow on the left of the level text on the top of the screen during the game
	/// </summary>
	private void OnClickedButtonPreviousLevel()
	{
		int last = lastLevel;

		last--;

		if (last < 1)
			last = 1;

		levelText.text = "Level " + last.ToString();
		//			levelTextMesh.text = last.ToString();
		PlayLevel (last);


	}
	/// <summary>
	/// Method called when the player clicked on the right arrow on the roght of the level text on the top of the screen during the game
	/// </summary>
	private void OnClickedButtonNextLevel()
	{

		PlayNextLevel ();



	}
	/// <summary>
	/// Method called when the player failed and so ... we replay the current level
	/// </summary>
	private void ReplayCurrentLevel(int level)
	{
		Camera.main.transform.DOMove (new Vector3 (0, Camera.main.transform.position.y, -10), 0.3f).OnComplete (() => {
			PlayLevel (level);
		});

	}
	/// <summary>
	/// Method called when the player have to play the next level (if the current level is cleared, or if the payer taps/Clicks on the next button or if the player see a rewarded video to unlock the current level
	/// </summary>
	private void PlayNextLevel()
	{
		int last = lastLevel;

		last++;

		levelText.text = "Level " + last.ToString();

		PlayLevel (last);

	}
}
