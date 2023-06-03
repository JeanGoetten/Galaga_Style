using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    new AudioSource audio; 
    public GameController gameController; 
    public AudioClip music_1;
    public AudioClip music_2;
    public AudioClip music_end;

    private bool endGameStop; 
    void Start()
    {
        audio = GetComponent<AudioSource>();

        audio.clip = music_1;
        audio.Play();

        endGameStop = false; 
    }

    // Update is called once per frame
    void Update()
    {
        if(!gameController.playing && !endGameStop){
            SFX_EndTheme(); 
            endGameStop = true; 
        }
        Debug.Log("endGameStop " + endGameStop);
    }
    public void SFX_EndTheme(){
        audio.Stop();
        audio.PlayOneShot(music_end);
    }
}
