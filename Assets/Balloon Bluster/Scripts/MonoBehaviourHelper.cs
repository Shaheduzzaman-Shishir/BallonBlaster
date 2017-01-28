using UnityEngine;
using System.Collections;

/// <summary>
/// A class to avoid some duplicate code.
/// </summary>
public class MonoBehaviourHelper : MonoBehaviour 
{
	PoolSystem _poolSystem;
	/// <summary>
	/// Reference to the pool system
	/// </summary>
	public PoolSystem poolSystem
	{
		get
		{
			if (_poolSystem == null)
				_poolSystem = FindObjectOfType<PoolSystem> ();

			return _poolSystem;
		}
	}

	SoundManager _soundManager;
	/// <summary>
	/// Reference to the sound manager
	/// </summary>
	public SoundManager soundManager
	{
		get
		{
			if (_soundManager == null)
				_soundManager = FindObjectOfType<SoundManager> ();

			return _soundManager;
		}
	}


	GameManager _gameManager;
	/// <summary>
	/// Reference to the game manager
	/// </summary>
	public GameManager gameManager
	{
		get
		{
			if (_gameManager == null)
				_gameManager = FindObjectOfType<GameManager> ();

			return _gameManager;
		}
	}

	CanvasManager _canvasManager;
	/// <summary>
	/// Reference to the canas manager
	/// </summary>
	public CanvasManager canvasManager
	{
		get
		{
			if (_canvasManager == null)
				_canvasManager = FindObjectOfType<CanvasManager> ();

			return _canvasManager;
		}
	}

	Constant _constant;
	/// <summary>
	/// Reference to the Constant GameObject
	/// </summary>
	public Constant constant
	{
		get
		{
			if (_constant == null)
				_constant = FindObjectOfType<Constant> ();

			return _constant;
		}
	}

	LevelManager _levelManager;
	/// <summary>
	/// Reference to the LevelManager GameObject
	/// </summary>
	public LevelManager levelManager
	{
		get
		{
			if (_levelManager == null)
				_levelManager = FindObjectOfType<LevelManager> ();

			return _levelManager;
		}
	}

	GuyAnim _guyAnim;
	/// <summary>
	/// Reference to the player animation script logic
	/// </summary>
	public GuyAnim guyAnim
	{
		get
		{
			if (_guyAnim == null)
				_guyAnim = FindObjectOfType<GuyAnim> ();

			return _guyAnim;
		}
	}

	Transform _PLAYER;
	/// <summary>
	/// Reference to the player transform
	/// </summary>
	public Transform PLAYER
	{
		get
		{
			if (_PLAYER == null)
				_PLAYER = guyAnim.transform.parent;

			return _PLAYER;
		}
	}
}
