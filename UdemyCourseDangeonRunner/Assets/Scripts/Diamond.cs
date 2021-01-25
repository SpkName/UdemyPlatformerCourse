using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond : MonoBehaviour
{
	public int _value;
	private Player _player;
	//onTrigerEneter
	//Check for player
	//add value to player
	public void Init(int value)
	{
		_value = value;
	}
	private void Start()
	{
		_player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
	}
	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Player"))
		{
			if (_player != null)
			{
				_player.AddGems(_value);
				Destroy(this.gameObject);

			}


		}
	}
}
