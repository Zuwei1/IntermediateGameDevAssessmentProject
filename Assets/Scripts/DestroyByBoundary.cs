using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByBoundary : MonoBehaviour
{
	private GameObject player;
	public GameObject playerExplosion;
	private void Start() {
		player = GameObject.FindGameObjectWithTag("Player");
	}
	void OnTriggerExit(Collider other) {
		if(other.gameObject.tag=="Enemy") {
		}
			if(player.gameObject != null)
			{
				if(other.gameObject.tag == "Enemy"){
		player.GetComponent<PlayerController>().health -= 5;
			if(player.gameObject.GetComponent<PlayerController>().health <= 0 )
			{
				 Instantiate(playerExplosion, player.gameObject.transform.position, player.gameObject.transform.rotation);
			//	Destroy(GameObject.FindGameObjectWithTag("Player"));
			}
				}
		}

		if(other.gameObject.tag == "bolt" || other.gameObject.tag == "enemybolt" || other.gameObject.tag == "Enemy" || other.gameObject.tag == "Bonus")
		{
			Destroy(other.gameObject);
		}
		}
	
}
