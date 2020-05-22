using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tripleShot : MonoBehaviour
{
	private void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "Player"){
		other.gameObject.GetComponent<PlayerController>().tripleShotActivated= true;
		Destroy(this.gameObject);
		}
		if(other.gameObject.GetComponent<PlayerController>().tripleShotActivated == true)
		{
			other.gameObject.GetComponent<PlayerController>().tripleShotTimer= 5.0f;
		}
	}
}
