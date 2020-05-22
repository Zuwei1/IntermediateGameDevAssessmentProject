using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tripleShot : MonoBehaviour
{
	private void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "Player"){
		other.GetComponent<PlayerController>().tripleShotActivated= true;
		Destroy(this.gameObject);
		}
	}
}
