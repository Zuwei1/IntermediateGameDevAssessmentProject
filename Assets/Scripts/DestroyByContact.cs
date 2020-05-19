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
	//	if(other.tag == "Boundry" || other.tag == "Enemy") {
		if(other.CompareTag("Boundry") || other.CompareTag("Enemy")) {
			return;
		}
		if(explosion != null) {
		Instantiate(explosion, transform.position, transform.rotation);
		}
		if(other.CompareTag("Player")) {
		Instantiate(playerExplosion, transform.position, transform.rotation);
		gameController.GameOver();
		}
		gameController.AddScore(scoreValue);
		Destroy(other.gameObject);
		Destroy(gameObject);
		
	}
}
