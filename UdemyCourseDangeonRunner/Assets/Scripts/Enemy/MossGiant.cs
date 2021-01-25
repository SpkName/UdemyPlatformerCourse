using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MossGiant : Enemy, IDamageable
{
	public int Health { get; set; }


	public override void Init()
	{
		base.Init();
		Health = base.maxHealth;


	}

	public override void Update()
	{
		base.Update();



	}
	public void Damage()
	{
		if (isDead)
		{
			return;
		}
		isHit = true;
		enemyAnimator.SetTrigger("Hit");
		enemyAnimator.SetBool("InCombat", true);
		Health--;
		if (Health < 1)
		{


			isDead = true;
			enemyAnimator.SetTrigger("Death");
			if (_diamond != null)
			{
			_diamond = Instantiate(_diamond, transform.position, Quaternion.identity);
			_diamond.gameObject.GetComponent<Diamond>().Init(gem);
			}

		}
	}

	
}
