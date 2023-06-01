using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    public float x_RightLimit;
    public float x_LeftLimit;
    public float timeToNewEnemy; 

    public GameObject asteroidPrefab; 

    private bool spawnControl; 

    private void Start() {
        spawnControl = true; 
    }

    private void Update() {

        if(spawnControl){
            spawnControl = false; 

            StartCoroutine(SpawnWithTime()); 
        }
        
    }

    private IEnumerator SpawnWithTime(){
        // Build random coordinates for spawn 
        float x = Random.Range(x_LeftLimit, x_RightLimit); 

        yield return new WaitForSeconds(timeToNewEnemy);

        Instantiate(asteroidPrefab, new Vector3(x, 7, 0), Quaternion.identity);

        spawnControl = true; 
    } 
}
