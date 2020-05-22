using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthPack : MonoBehaviour
{
	public int healAmount;
	void OnTriggerEnter(Collider other)
	{
		
		other.GetComponent<PlayerController>().health += healAmount;
		Destroy(this.gameObject);
	}
}
