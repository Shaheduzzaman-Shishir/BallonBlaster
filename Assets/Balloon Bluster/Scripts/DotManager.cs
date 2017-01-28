using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Attached to the each obstacles
/// </summary>
public class DotManager : MonoBehaviourHelper 
{
	public bool isEnable = false;

	public float position = 0;

	public SpriteRenderer lineSprite;

	public bool isOnCircle;

	public SpriteRenderer DotSprite;

	bool _isBlack;
	/// <summary>
	/// is black = hazard. If write = to destroy
	/// </summary>
	public bool isBlack
	{
		get 
		{
			return _isBlack;
		}

		set
		{
			_isBlack = value;

			if (value)
			{
				DotSprite.color = constant.SquareColor;
				DotSprite.sortingOrder = 10;
			}
			else 
			{
				DotSprite.color = constant.DotColor;
				DotSprite.sortingOrder = 1;
				transform.localPosition = new Vector3 (transform.localPosition.x, transform.localPosition.y, transform.localPosition.z - 0.01f);
			}
			lineSprite.color = DotSprite.color;


		}
	}


	public Vector3 collisionPoint;


	void Awake()
	{
		isBlack = false;

		DotSprite.color = constant.DotColor;

		Reset ();
	}


	void Reset()
	{

		transform.rotation = Quaternion.identity;
		if(lineSprite!=null)
			lineSprite.color = Color.clear;

		isOnCircle = true;

		transform.localScale = Vector3.one;

		transform.rotation = Quaternion.identity;

		isBlack = false;

		DotSprite.color = new Color (DotSprite.color.r, DotSprite.color.g, DotSprite.color.b, 1f);
	}

	int ratio;

	/// <summary>
	/// Display the line of each hazard
	/// </summary>
	public void ActivateLine(Vector3 target, Transform CircleBorder){


		transform.position = target;

		position = Vector2.Distance(target,CircleBorder.position);

		transform.parent = CircleBorder;
		transform.localScale = Vector3.one;

		if(lineSprite!=null)
			lineSprite.transform.localScale = new Vector3 (position*100000/2, lineSprite.transform.localScale.y, lineSprite.transform.localScale.z);

	}
	/// <summary>
	/// If player touch a black square => game over
	/// </summary>
	void GameOverLogic(Collider2D col)
	{
		if (gameObject.name.Contains ("Square"))
		{

			if (col.CompareTag ("Player"))
			{
				if (col.gameObject.activeInHierarchy && gameObject.activeInHierarchy && !gameManager.isGameOver)
				{


					if (isBlack)
					{
						gameManager.GameOver (transform);

					}
					else
					{
						gameManager.SpawnParticleExplosionSquare (this);

						StopAll ();

					}
				}
			}
		}
	}

	public void StopAll()
	{
		if (lineSprite != null) {
			lineSprite.color = Color.clear;
		}
	}
	/// <summary>
	/// Trerred when enter an obtacle
	/// </summary>
	void OnTriggerEnter2D(Collider2D col){
		if (Application.isEditor ) {
		}
		GameOverLogic (col);

	}

}
