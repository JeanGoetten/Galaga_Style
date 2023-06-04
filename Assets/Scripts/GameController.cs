using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public TMP_Text points_TXT;  
    public TMP_Text timer_TXT;  

    public GameObject win_TXT;  
    public GameObject lose_TXT;  

    public GameObject lifeStar1;  
    public GameObject lifeStar2;  
    public GameObject lifeStar3;  

    public int points; 
    public int hurt; 
    public bool playerDie; 
    public bool playing; 


    public float timeToDie = 60f; 
    public int pointsToWin; 

    private void Awake() {
        playing = true; 
    }

    private void Start() {
        points = 0; 
        hurt = 0; 
        playerDie = false; 

        Cursor.visible = false; 
    }
    private void Update(){
        //Debug.Log("playing " + playing);
        if(!playing){
            StartCoroutine(Restart()); 
        }

        if(hurt == 1){
            lifeStar3.SetActive(false); 
        }
        if(hurt == 2){
            lifeStar2.SetActive(false); 
        }
        if(hurt == 3 && playing){
            lifeStar1.SetActive(false); 
            playerDie = true; 
            Lose(); 
        }

        if(timeToDie > 0 && playing){
            timeToDie -= Time.deltaTime; 
        }else if(timeToDie <= 0 && playing){
            playerDie = true; 
            Lose(); 
        }

        points_TXT.text = points.ToString(); 
        //Debug.Log(points);
        timer_TXT.text = ((int)timeToDie).ToString(); 

        if(points >= pointsToWin && playing){
            playerDie = false; 
            Win(); 
        }
    }
    public void Win(){
        win_TXT.SetActive(true); 
        //Debug.Log("você venceu");
        playing = false; 
    }
    public void Lose(){
        lose_TXT.SetActive(true); 
        //Debug.Log("você perdeu");
        playing = false; 
    }

    IEnumerator Restart(){
        yield return new WaitForSeconds(3f); 
        if(Input.anyKey){
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
    }
}
