using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleDestroyAfterTime : MonoBehaviour
{
    public float timeToDestroy = 0.5f;    
    void Update()
    {
        StartCoroutine(cd()); 
    }

    IEnumerator cd(){
        yield return new WaitForSeconds(timeToDestroy); 
        Destroy(this.gameObject); 
    }
}
