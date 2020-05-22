using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tripleShot : MonoBehaviour
{
	private void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "Player"){
		other.gameObject.GetComponent<PlayerController>().tripleShotActivated= true;
		if(other.gameObject.GetComponent<PlayerController>().tripleShotActivated == true)
		{
			other.gameObject.GetComponent<PlayerController>().tripleShotTimer= 5.0f;
		}
		Destroy(this.gameObject);
		}
		if(other.CompareTag("Boundry") || other.CompareTag("Enemy") || other.CompareTag("enemybolt")||other.CompareTag("Bonus"))
		{
			return;
		}
	}
}
