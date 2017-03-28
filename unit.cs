using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class unit : MonoBehaviour {

	public virtual void ReceiveDamage()
	{
		Die ();
	}

	public virtual void Die()
	{
		Destroy (gameObject);
	
	}
}
