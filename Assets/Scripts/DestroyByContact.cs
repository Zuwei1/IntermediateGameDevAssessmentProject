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
		if(other.CompareTag("Player")) {
		//Instantiate(playerExplosion, transform.position, transform.rotation);
		Instantiate(explosion, transform.position,transform.rotation);
		//gameController.GameOver();
		}
		if(other.gameObject.tag == "Player")
		{
			other.GetComponent<PlayerController>().health -=1;
			Destroy(this.gameObject);
			return;
		}
		gameController.AddScore(scoreValue);
		Destroy(other.gameObject);
		Destroy(this.gameObject);
		
	}
}
