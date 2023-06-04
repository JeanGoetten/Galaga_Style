using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    new AudioSource audio; 
    public GameController gameController; 
    public AudioClip music_theme;
    public AudioClip music_theme_low;
    public AudioClip music_end;

    private bool endGameStop; 
    void Start()
    {
        audio = GetComponent<AudioSource>();

        audio.clip = music_theme;
        audio.volume = 1f;
        audio.Play();

        endGameStop = false; 
    }

    // Update is called once per frame
    void Update()
    {
        if(!gameController.playing && !endGameStop){
            StartCoroutine(SFX_EndTheme()); 
            endGameStop = true; 
        }
        //Debug.Log("endGameStop " + endGameStop);
    }
    IEnumerator SFX_EndTheme(){
        audio.Stop();
        audio.PlayOneShot(music_end);
        yield return new WaitForSeconds(3f); 
        audio.clip = music_theme_low;
        audio.volume = 0.5f;
        audio.Play();
    }
}
