using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
	public float speed = 3.0f;
	
	void Start() {
		GetComponent<Rigidbody>().velocity = transform.forward * speed;
	}

	void Update()
	{
		if(FindObjectOfType<GameController>().score >= FindObjectOfType<GameController>().nextWavescore) 
		{
			speed -= 0.5f;
		}
	}
}
