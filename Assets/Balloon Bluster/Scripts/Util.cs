using UnityEngine;
using System.Collections;
#if UNITY_5_3
using UnityEngine.SceneManagement;
#endif

public static class Util
{
	public static string COUNTGAMEOVER = "COUNTGAMEOVER";
	public static string LAST_LEVEL_PLAYED = "LEVEL_PLAYED";
	public static string LEVEL_UNLOCKED = "LEVEL";
	public static string SOUND_ON = "SOUND_ON";
	public static string NUMOFLEVELPLAYED = "NUMOFLEVELPLAYED";

	public static void SetCountGameOver(int count)
	{
		PlayerPrefs.SetInt(COUNTGAMEOVER, count);
		PlayerPrefs.Save();
	}

	public static int GetCountGameOver()
	{
		return PlayerPrefs.GetInt(COUNTGAMEOVER, 0);
	}

	public static void SetMaxLevelUnlock(int num)
	{
		PlayerPrefs.SetInt(LEVEL_UNLOCKED, num);
		PlayerPrefs.Save();
	}

	public static int GetMaxLevelUnlock()
	{
		return PlayerPrefs.GetInt(LEVEL_UNLOCKED, 1);
	}

	public static void SetLastLevelPlayed(int num)
	{
		PlayerPrefs.SetInt(LAST_LEVEL_PLAYED, num);
		PlayerPrefs.Save();
	}

	public static int GetLastLevelPlayed()
	{
		return PlayerPrefs.GetInt(LAST_LEVEL_PLAYED, 1);
	}

	public static void SetSound(bool ON)
	{
		if(ON)
			SetSoundOn();
		else
			SetSoundOff();
	}

	public static void SetSoundOn()
	{
		PlayerPrefs.SetInt(SOUND_ON, 1);
		PlayerPrefs.Save();
	}

	public static void SetSoundOff()
	{
		PlayerPrefs.SetInt(SOUND_ON, 0);
		PlayerPrefs.Save();
	}

	public static bool SoundIsOn()
	{
		return PlayerPrefs.GetInt(SOUND_ON,1) == 1;
	}

	public static void ReloadCurrentLevel()
	{
		#if UNITY_5_3
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		#else
		Application.LoadLevel (Application.loadedLevel);
		#endif
	}

	public static string GetCurrentLevelName()
	{
		#if UNITY_5_3
		return SceneManager.GetActiveScene().name;
		#else
		return Application.loadedLevelName;
		#endif
	}

	public static void SetNumberOfLevelPLayed(int num)
	{
		PlayerPrefs.SetInt(NUMOFLEVELPLAYED, num);
		PlayerPrefs.Save();
	}

	public static int GetNumberOfLevelPLayed()
	{
		return PlayerPrefs.GetInt(NUMOFLEVELPLAYED, 0);
	}

	public static bool ActivateButtonNext()
	{
		int currentLevel = GetLastLevelPlayed();
		int max = GetMaxLevelUnlock();
	
		bool canUnlock = false;

		if(currentLevel < max)
			canUnlock = true;

//		Debug.Log("current = " + currentLevel + " - max = " + max + " ---> canUnlock = " + canUnlock);

		return canUnlock;
	}

	public static bool ActivateButtonLast()
	{
		int currentLevel = GetLastLevelPlayed();

		bool canUnlock = false;

		if(currentLevel > 1)
			canUnlock = true;

		return canUnlock;
	}
}
