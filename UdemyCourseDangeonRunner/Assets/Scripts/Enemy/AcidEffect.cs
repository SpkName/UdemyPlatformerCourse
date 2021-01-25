using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcidEffect : MonoBehaviour
{
	float speed = 3f;
	Transform thisTransform;

	private void Start()
	{
		Destroy(this.gameObject, 5f);
		thisTransform = transform;
	}

	private void Update()
	{
		thisTransform.Translate(Vector3.right * Time.deltaTime*speed);
		
	}
	private void OnTriggerEnter2D(Collider2D hitObject)
	{
		IDamageable hit = hitObject.GetComponent<IDamageable>();
		if (hit != null)
		{
				hit.Damage();
			Destroy(this.gameObject);
		}

	}
}
