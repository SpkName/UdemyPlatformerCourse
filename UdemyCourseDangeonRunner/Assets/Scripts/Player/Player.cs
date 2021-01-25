using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
public class Player : MonoBehaviour, IDamageable
{
	public int _diamond;
	private Rigidbody2D _playerRigid;
	[SerializeField]
	private float _jumpForce =5.0f;
	[SerializeField]
	private float _speed = 2f;
	[SerializeField]
	private LayerMask floorMask;
	PlayerAnimation _playerAnim;


	public int Health { get; set; }


	[SerializeField]
	private bool _isWaitng;

	public float Speed { get => _speed; set => _speed = value; }

	void Start()
    {
		_playerRigid = GetComponent<Rigidbody2D>();
		_playerAnim = GetComponent<PlayerAnimation>();
		Health = 4;
    }


	void Update()
	{

		Movement();

		if ((CrossPlatformInputManager.GetButtonDown("Attack")) &&  IsGround())
		{
			_playerAnim.LandAtack();
		}

	}

	private void Movement()
	{

		if ((Input.GetKeyDown(KeyCode.Space) || CrossPlatformInputManager.GetButtonDown("Jump")) & IsGround())
		{
			_playerRigid.velocity = new Vector2(_playerRigid.velocity.x, _jumpForce);
			StartCoroutine(ResetJumpRoutine());
			_playerAnim.Jumping(true);

		}
		float move = CrossPlatformInputManager.GetAxis("Horizontal");
		_playerAnim.Moving(move);
		_playerRigid.velocity = new Vector2(move * _speed, _playerRigid.velocity.y);
	}

	private bool IsGround()
	{
		RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.down, 0.6f, floorMask.value);
		if (hitInfo.collider != null)
		{
			if (!_isWaitng)
			{
				_playerAnim.Jumping(false);
				return true;
			}
		}
		return false;
	}

	IEnumerator ResetJumpRoutine() {
		_isWaitng = true;
		yield return new WaitForSeconds(0.1f);
		_isWaitng = false;

	}

	public void Damage () {
		Health--;
		UIManager.Instance.UpdateLivesCount(Health);
		if (Health == 0)
		{
			_playerAnim.Death();

		}


	}

	public void AddGems(int gems) {
		_diamond += gems;

		UIManager.Instance.GemCountUpdater(_diamond);
	}
}
