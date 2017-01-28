using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;


public class Constant : MonoBehaviourHelper
{



	string shareMessage;
	public string url;
	public Texture2D smallIcon;



	public Color FailColor;

	public Color SuccessColor;

	public Color BackgroundColor;

	public Color DotColor;

	public Color SquareColor;

	public List<Color> backgroundColors = new List<Color>();

	public string GetShareMessage(){

		shareMessage = 
			"I'm on level "
			+ Util.GetMaxLevelUnlock()
			+ "! #"
			+ "Ballon Bluster"
			+ " by GnGTech Studio \n ";


		return shareMessage;
	}

	public Color RandomBrightColor()
	{
		if (backgroundColors == null || backgroundColors.Count == 0)
			return Color.white;

		return backgroundColors[UnityEngine.Random.Range(0,backgroundColors.Count)];
	}
}
