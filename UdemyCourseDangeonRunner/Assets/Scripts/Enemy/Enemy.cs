using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{

	[SerializeField]
	protected int maxHealth;
	[SerializeField]
	protected int speed;
	[SerializeField]
	protected int gem;
	protected bool isDead=false;

	[SerializeField]
	protected Transform pointA, pointB;

	protected Transform enemyTransform;
	protected Animator enemyAnimator;
	protected SpriteRenderer enemySprite;
	protected Vector3 currentTarget;

	protected Player playerScrip;


	protected bool isHit = false;

	protected bool isInCombat = false;
	[SerializeField]
	protected GameObject _diamond;
	public virtual void Init()
	{
		enemySprite = transform.GetChild(0).GetComponent<SpriteRenderer>();
		enemyTransform = GetComponent<Transform>();
		enemyAnimator = transform.GetChild(0).GetComponent<Animator>();
		playerScrip = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
	}
	public void Start()
	{
		Init();
	}
	public virtual void Update()
	{
		if (enemyAnimator.GetCurrentAnimatorStateInfo(0).IsName("Idle_anim") && enemyAnimator.GetBool("InCombat") ==false)
		{
			return;
		}
		if (isDead)
		{
			return;
		}
		Movement();


	}

	public virtual void Movement()
	{
		if (currentTarget == pointA.position && enemyAnimator.GetBool("InCombat") == false )
		{
			enemySprite.flipX = true;
		}
		else if(currentTarget == pointB.position && enemyAnimator.GetBool("InCombat") == false)
		{
			enemySprite.flipX = false;
		}
		if (transform.position == pointA.position)
		{
			currentTarget = pointB.position;
			enemyAnimator.SetTrigger("Idle");
		}
		else if (transform.position == pointB.position)
		{
			currentTarget = pointA.position;
			enemyAnimator.SetTrigger("Idle");
		}

		if (isHit == false)
		{
			transform.position = Vector3.MoveTowards(transform.position, currentTarget, speed * Time.deltaTime);
		}

		if (IsPlayerGoAway())
		{
			isHit = false;
			enemyAnimator.SetBool("InCombat", false);
		}

		Vector3 direction = playerScrip.transform.localPosition - transform.localPosition;

		if (direction.x > 0 && enemyAnimator.GetBool("InCombat") == true)
		{

			enemySprite.flipX = false;
		}
		else if (direction.x < 0 && enemyAnimator.GetBool("InCombat") == true)
		{
			enemySprite.flipX = true;
		}
	}

	protected bool IsPlayerGoAway() {
	float distance = Vector3.Distance(transform.localPosition, playerScrip.transform.localPosition);
	return distance > 2f;
	}
}
