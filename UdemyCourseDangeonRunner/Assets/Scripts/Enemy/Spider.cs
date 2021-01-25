using System.Collections;
using UnityEngine;

public class Spider : Enemy, IDamageable
{
	public int Health { get; set; }
	public AcidEffect AceidPref;

	public override void Init()
	{
		base.Init();
		Health = base.maxHealth;
	}
	public override void Update()
	{
		//we don't need it
	}
	public void Damage()
    {

		if (isDead)
		{
			return;
		}
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
	public void AcidShoot() {

//		Debug.Log("Shoting Acid");
		Instantiate(AceidPref, transform.position, Quaternion.identity);
	}
}
