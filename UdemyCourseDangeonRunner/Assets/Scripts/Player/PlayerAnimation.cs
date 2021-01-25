using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
	Animator _playerAnim;
	private SpriteRenderer _playerSpriterender;
	private SpriteRenderer _SwordSpriterender;
	Animator _SwordAnim;
	Transform SwordTransform;


	void Start()
    {
		_playerAnim = GetComponentInChildren<Animator>();
		_playerSpriterender = GetComponentInChildren<SpriteRenderer>();
		SwordTransform = transform.GetChild(1).GetComponent<Transform>();
		_SwordAnim = transform.GetChild(1).GetComponent<Animator>();
		_SwordSpriterender = transform.GetChild(1).GetComponent<SpriteRenderer>();
	}



	public void Moving(float value)
	{
		FlipTheSprite(value);

		_playerAnim.SetFloat("Move", Mathf.Abs(value));

	}

	private void FlipTheSprite(float value)
	{

		Vector3 tempPos=SwordTransform.localPosition;
		if (value > 0)
		{
			_playerSpriterender.flipX = false;
			_SwordSpriterender.flipX = false;
			_SwordSpriterender.flipY = false;
			
			tempPos.x = 1.01f;
			SwordTransform.localPosition = tempPos;

		}
		else if (value < 0)
		{
			_playerSpriterender.flipX = true;
			_SwordSpriterender.flipX = true;
			_SwordSpriterender.flipY = true;
			tempPos.x = -1.01f;
			SwordTransform.localPosition = tempPos;
		}
	}

	public void Jumping(bool isJump) {
		_playerAnim.SetBool("Jump", isJump);
	}
	public void LandAtack() {
		_playerAnim.SetTrigger("Atack");
		_SwordAnim.SetTrigger("SwordAnimation");
	}

	internal void Death()
	{
		_playerAnim.SetTrigger("Death");
	}
}
