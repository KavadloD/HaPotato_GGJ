using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor.Tilemaps;

public class Bubble : MonoBehaviour
{
  public int amount = 1; // This could be any variable that changes over time
    public AudioLoudnessDetecton _wordDetector;
    private bool wordTriggered=false;
    public float volumeThresh=0.07f;
    [SerializeField] BubbleStatus gameStatus;
    [SerializeField] TMP_Text timerText;
    [SerializeField] GameObject win, lose, bubble;
    public int blowsNeeded;
    public int blowCount;
    private float startTime;
    private bool shot;
    private bool shotHasBeenChecked;
    private bool teacherTurned;
    private float StartTime;


    void Start(){
        blowCount = 0;
        shot = false;
        shotHasBeenChecked = false;
        startTime = Time.time;
    }
    
    void Update(){
        if(gameStatus == BubbleStatus.Ingame){
    
            // Check for timer loss and update time
            if(Time.time > StartTime + 5){
                gameStatus = BubbleStatus.Lost;
            }
            timerText.text = string.Format("{0:N3}", Time.time - StartTime);
        }
    
        // Enable win/loss test sprites
        if(gameStatus == BubbleStatus.Won){
            win.SetActive(true);
        }
        if(gameStatus == BubbleStatus.Lost){
            lose.SetActive(true);
        }
    }

    void FixedUpdate()
    {
        if (_wordDetector.volume >= volumeThresh)
        {
            _wordDetector.CakeTriggerer = false;
            wordTriggered = true;
        }
        if (wordTriggered == true)
        {
            blowCount++;
        }
        
        if(gameStatus == BubbleStatus.Ingame){

            if (blowCount < blowsNeeded)
            {
                Debug.Log("blow");
                blowCount++;
                bubble.transform.localScale =  new Vector3(bubble.transform.localScale.x + 0.5f,bubble.transform.localScale.y + 0.5f,bubble.transform.localScale.z + 0.5f);
                wordTriggered=false;
            }

            else if (blowCount >= blowsNeeded)
            {
                gameStatus = BubbleStatus.Won;
            }

        }
        
        
    }

    // The enum for gameStatus
    public enum BubbleStatus{Ingame, Lost, Won}
}
