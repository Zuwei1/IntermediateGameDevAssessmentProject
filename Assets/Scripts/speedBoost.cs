using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class speedBoost : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
		if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerController>().speeding = true;
		if(other.gameObject.GetComponent<PlayerController>().speeding == true)
		{
			other.gameObject.GetComponent<PlayerController>().speedTimer = 5.0f;
		}
            Destroy(this.gameObject);
        }
		if(other.CompareTag("Boundry") || other.CompareTag("Enemy") || other.CompareTag("enemybolt")||other.CompareTag("Bonus"))
		{
			return;
		}
		
    }


}


