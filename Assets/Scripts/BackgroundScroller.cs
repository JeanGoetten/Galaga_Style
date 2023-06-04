using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    [Range(-5f,5f)]
    public float scrollSpeed = .5f; 
    private float offset; 
    private Material mat; 
    void Start()
    {
        mat = GetComponent<Renderer>().material; 
    }
    void Update()
    {
        offset += (scrollSpeed * Time.deltaTime)/10f; 
        mat.SetTextureOffset("_MainTex", new Vector2(0, offset)); 
    }
}
