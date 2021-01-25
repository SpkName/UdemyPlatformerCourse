using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderAnimEvent : MonoBehaviour
{
	Spider _spider;


	private void Start()
	{
//		_spider = GameObject.FindObjectOfType<Spider>();
		_spider = transform.parent.GetComponent<Spider>();
		
	}
	public void Fire() {
		_spider.AcidShoot();
	//	Debug.Log("Spider shoud fire");
	}
}
