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
	public Transform []shotSpawns;
	public float fireRate;

	private float nextFire;

	public float speed;
	public bool speeding;
	public float originalSpeed;
	public float speedUp;
	public float timer;

	public bool speedText;

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
		if(/*Input.GetButton("Fire1")*/ Input.GetKey(KeyCode.Space) && Time.time > nextFire) {
			nextFire = Time.time + fireRate;
			//GameObject clone = 
			foreach(var shotSpawn in shotSpawns)
			{
			Instantiate(shot, transform.position, new Quaternion(0,0,0,0));
			}
			au.Play();
		}
		if(speeding)
		{
			speed = speedUp;
			timer -= Time.deltaTime;
			if(timer <= 0)
			{
				speed = originalSpeed;
				timer = 5f;
				speeding = false;
			}
		}

	}
}

