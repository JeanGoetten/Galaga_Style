using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidController : MonoBehaviour
{
    Rigidbody2D rb; 
    public float speed; 
    Animator anim; 

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); 

        anim = GetComponent<Animator>(); 
    }

    void Update()
    {
        rb.velocity = new Vector3(0, -1f * speed, 0); 
    }
}
