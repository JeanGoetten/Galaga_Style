using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserController : MonoBehaviour
{
    Rigidbody2D rb; 
    private GameController gameController; 
    public float speed; 
    public GameObject FX_Explosion_1; 

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); 

        gameController = GameObject.Find("GameController").GetComponent<GameController>();
    }

    void Update()
    {
        rb.velocity = new Vector3(0, 1f * speed, 0); 
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Asteroid"){

            Instantiate(FX_Explosion_1, transform.position, transform.rotation); 
            Destroy(other.gameObject); 
            gameController.points++; 

            GameObject[] cams = GameObject.FindGameObjectsWithTag("MainCamera");

            foreach (GameObject cam in cams)
            {
                cam.GetComponent<ScreenShake>().start = true;
                //Debug.Log("shooted");
            }

            Destroy(this.gameObject); 
        }
    }
}
