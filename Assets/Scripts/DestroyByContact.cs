using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour
{
	public GameObject explosion;
	public GameObject playerExplosion;
	public int scoreValue;
	private GameController gameController;

	void Start() {
		GameObject gameControllerObject = GameObject.FindWithTag("GameController");
		if(gameControllerObject != null) {
			gameController = gameControllerObject.GetComponent<GameController>();
		}
		if(gameController == null) {
			Debug.Log("Cannot find game 'GameController' script");
		}
	}

	void OnTriggerEnter(Collider other) {
		if(other.CompareTag("Boundry") || other.CompareTag("Enemy") || other.CompareTag("enemybolt")||other.CompareTag("Bonus")  ) {
			return;
		}
		if(explosion != null) {
		Instantiate(explosion, transform.position, transform.rotation);
		
		}
		if(other.gameObject.tag == "Player")
		{
		Instantiate(explosion, transform.position,transform.rotation);
			other.GetComponent<PlayerController>().health -=10;
		if(other.GetComponent<PlayerController>().health == 0)
		{
		Instantiate(playerExplosion, transform.position, transform.rotation);
		Destroy(other.gameObject);
		gameController.GameOver();
		}
		}
		if(other.gameObject.tag == "bolt")
		{
			Destroy(other.gameObject);
		}
		gameController.AddScore(scoreValue);
		Destroy(this.gameObject);
		
	}
}
