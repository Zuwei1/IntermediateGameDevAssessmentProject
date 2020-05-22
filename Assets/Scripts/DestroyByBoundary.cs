using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByBoundary : MonoBehaviour
{
	private GameObject player;
	
	private void Start() {
		player = GameObject.FindGameObjectWithTag("Player");
	}
	void OnTriggerExit(Collider other) {
		if(other.gameObject.tag=="Enemy") {
		player.GetComponent<PlayerController>().health -= 1;
		Destroy(other.gameObject);
		}
		if(other.gameObject.tag == "Bonus"){
			Destroy(other.gameObject);
			return;
		}
		if(other.gameObject.tag == "bolt" || other.gameObject.tag == "enemybolt")
		{
			Destroy(other.gameObject);
		}
	}
}
