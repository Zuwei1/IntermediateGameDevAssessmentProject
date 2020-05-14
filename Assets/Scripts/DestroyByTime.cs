using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByTime : MonoBehaviour
{
    // TODO: ATTACH THIS TO THE EXPLOSION ANIMATIONS
    public float lifetime;
    void Start()
    {
        Destroy(gameObject, lifetime);
    }

}
