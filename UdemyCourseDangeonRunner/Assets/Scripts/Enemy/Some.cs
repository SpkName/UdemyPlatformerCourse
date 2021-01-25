using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Some : MonoBehaviour
{

	[SerializeField]
	protected int maxHealth;
	[SerializeField]
	protected int speed;
	[SerializeField]
	protected int gem;

	[SerializeField]
	protected Transform pointA, pointB;

	protected Transform enemyTransform;
	protected Animator enemyAnimator;
	protected SpriteRenderer enemySprite;
	protected Vector3 currentTarget;

	protected Player playerScrip;


	protected bool isHit = false;

	protected bool isInCombat = false;


	public virtual void Init() {
		enemySprite = transform.GetChild(0).GetComponent<SpriteRenderer>();
		enemyTransform = GetComponent<Transform>();
		enemyAnimator = transform.GetChild(0).GetComponent<Animator>();
		playerScrip = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
	}
	public void Start()
	{
		Init();	
	}
	public virtual void Update() {
		if (enemyAnimator.GetCurrentAnimatorStateInfo(0).IsName("Idle_anim"))
		{
			return;
		}
		Movement();

	}

	public virtual void Movement() {
		if (currentTarget == pointA.position)
		{
			enemySprite.flipX = true;
		}
		else
		{
			enemySprite.flipX = false;
		}
		if (transform.position == pointA.position)
		{
			currentTarget = pointB.position;
			enemyAnimator.SetTrigger("Idle_anim");
		}
		else if (transform.position == pointB.position)
		{
			enemyAnimator.SetTrigger("Idle_anim");
		}

		if (isHit == false)
		{
			transform.position = Vector3.MoveTowards(transform.position, currentTarget, speed * Time.deltaTime);
		}
	}
}
