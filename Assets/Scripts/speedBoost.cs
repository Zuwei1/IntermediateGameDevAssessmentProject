using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class speedBoost : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerController>().speeding = true;
            Destroy(this.gameObject);
        }

		if(other.gameObject.GetComponent<PlayerController>().speeding == true)
		{
			other.gameObject.GetComponent<PlayerController>().speedTimer = 5.0f;
		}
    }


}


