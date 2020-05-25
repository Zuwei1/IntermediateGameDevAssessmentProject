using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthPack : MonoBehaviour
{
	public int healAmount;
	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "Player")
		{
		other.GetComponent<PlayerController>().health += healAmount;
		}
		if(other.CompareTag("Boundry") || other.CompareTag("Enemy") || other.CompareTag("enemybolt")||other.CompareTag("Bonus") || other.CompareTag("bolt"))
		{
			return;
		}
		Destroy(this.gameObject);
	}
}
