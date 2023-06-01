using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FX_Controller : MonoBehaviour
{
    public AudioClip sfx_clip;
    void Start()
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.clip = sfx_clip;
        audio.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
