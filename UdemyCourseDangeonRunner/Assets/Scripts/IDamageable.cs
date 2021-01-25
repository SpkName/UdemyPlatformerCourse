using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable 
{
	[SerializeField]int Health { get; set; }
	void Damage();
}
