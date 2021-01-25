using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atack : MonoBehaviour
{
	bool isReloadNeed = false;
	private void OnTriggerEnter2D(Collider2D hitObject)
	{
		IDamageable hit = hitObject.GetComponent<IDamageable>();
		if (hit != null)
		{
			if (!isReloadNeed)
			{
				hit.Damage();
				isReloadNeed = true;
				StartCoroutine(DamageReloadRoutine());
			}
			
			
			
		}

	}


	IEnumerator DamageReloadRoutine() {

		
		yield return new WaitForSeconds(0.5f);
		isReloadNeed = false;
	}
}
