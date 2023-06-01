using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipController : MonoBehaviour
{
    Rigidbody2D rb; 
    public float speed; 

    public GameObject bulletPrefab; 

    public Transform firePoint; 

    private float fireTime; 

    public static bool canShoot; 

    public float fireRate; 

    public new Transform camera; 

    public GameObject FX_Explosion_1; 
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); 

        canShoot = true; 
        fireTime = 0; 
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");

        rb.velocity = new Vector3(horizontal * speed, 0, 0); 

        
        fireTime += Time.deltaTime; 

        if(fireTime > fireRate){
            Shoot(); 
        }else{
            // cant shoot
        }

        if(GameController.playerDie){
            Destroy(this.gameObject); 
        }
    }
    private void Shoot(){
        if(Input.GetKeyDown(KeyCode.Space)){
            //Shoot Animation 
            
            // verify and instatiate 
            if(canShoot){
                camera.GetComponent<ScreenShake>().start = true; 
                GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation); 
                
                fireTime = 0; 
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Asteroid"){
            Instantiate(FX_Explosion_1, transform.position, transform.rotation); 
            Destroy(other.gameObject); 
            GameController.hurt++; 
        }
    }
}
