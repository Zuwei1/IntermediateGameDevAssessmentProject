using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.SerializableAttribute]
public class Boundary {
	public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour
{
	public int health = 100;
	public float tilt;
	public Boundary boundary;
	private AudioSource au;
	public GameObject shot;
	public GameObject tripleShot;
	public Transform []shotSpawns;
	public float fireRate;

	private float nextFire;

	public float speed;
	public bool speeding;
	public float originalSpeed;
	public float speedUp;
	public float speedTimer ;
	public float tripleShotTimer ;
	public bool tripleShotActivated;
	
	private float speededUpfirerate;
	private float originalFireRate = 0.5f;
	
	void Start() {
		au = GetComponent<AudioSource>();
		
	}
	void FixedUpdate(){
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");
		
		Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
		GetComponent<Rigidbody>().velocity = movement * speed;

		GetComponent<Rigidbody>().position = new Vector3(Mathf.Clamp(GetComponent<Rigidbody>().position.x,boundary.xMin,boundary.xMax),
		0.0f,Mathf.Clamp(GetComponent<Rigidbody>().position.z,boundary.zMin,boundary.zMax));

		GetComponent<Rigidbody>().rotation = Quaternion.Euler(0.0f, 0.0f, GetComponent<Rigidbody>().velocity.x * -tilt);
		
	}
	void Update() {
		if(/*Input.GetButton("Fire1")*/ Input.GetKey(KeyCode.Space) && Time.time > nextFire)
		{
			nextFire = Time.time + fireRate;
			//GameObject clone = 
			
			if(!tripleShotActivated)
			{
				Instantiate(shot, shotSpawns[0].position, new Quaternion(0,0,0,0));
			}
			if(tripleShotActivated)
			{
			foreach(var shotSpawn in shotSpawns)
			{
			Instantiate(tripleShot, shotSpawn.position, new Quaternion(0,0,0,0));
			}

			
		}
			au.Play();
		}
			if(tripleShotActivated)
			{
				fireRate = 0.3f;
				tripleShotTimer -= Time.deltaTime;
			if(tripleShotTimer <= 0)
			{
				tripleShotTimer = 5f;
				fireRate = originalFireRate;
				tripleShotActivated = false;
			}
			}
		if(speeding)
		{
			speed = speedUp;
			speedTimer -= Time.deltaTime;
			if(speedTimer <= 0)
			{
				speed = originalSpeed;
				speedTimer = 5f;
				speeding = false;
			}
		}
		
	}
}

