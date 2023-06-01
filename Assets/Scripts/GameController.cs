using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public TMP_Text points_TXT;  
    public TMP_Text timer_TXT;  

    public GameObject win_TXT;  
    public GameObject lose_TXT;  

    public GameObject lifeStar1;  
    public GameObject lifeStar2;  
    public GameObject lifeStar3;  

    public static int points; 
    public static int hurt; 
    public static bool playerDie; 


    public float timeToDie = 60f; 

    private void Start() {
        points = 0; 
        hurt = 0; 
        playerDie = false; 

    }

    private void Update() {

        if(hurt == 1){
            lifeStar3.SetActive(false); 
        }
        if(hurt == 2){
            lifeStar2.SetActive(false); 
        }
        if(hurt == 3){
            lifeStar1.SetActive(false); 
            playerDie = true; 
            Lose(); 
        }

        if(timeToDie > 0){
            timeToDie -= Time.deltaTime; 
        }else{
            playerDie = true; 
            Lose(); 
        }

        points_TXT.text = points.ToString(); 
        //Debug.Log(points);
        timer_TXT.text = ((int)timeToDie).ToString(); 

        if(points >= 20){
            Win(); 
        }
    }
    public void Win(){
        win_TXT.SetActive(true); 
        //Debug.Log("você venceu");
        Time.timeScale = 0f;
    }
    public void Lose(){
        lose_TXT.SetActive(true); 
        //Debug.Log("você perdeu");
        Time.timeScale = 0f;
    }
}
