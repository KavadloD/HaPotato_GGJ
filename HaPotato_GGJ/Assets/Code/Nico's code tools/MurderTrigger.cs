using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MurderTrigger : MonoBehaviour
{
    public int amount = 2; // This could be any variable that changes over time
    public AudioLoudnessDetecton _wordDetector;
    private bool wordTriggered;
    public float volumeThresh;
    
    private float targetTime;
    
    private GameObject neutralSprite;
    private GameObject winSprite;
    private GameObject loseSprite;

    void Awake()
    {
        neutralSprite = this.transform.GetChild(0).gameObject; 
        winSprite = this.transform.GetChild(1).gameObject;
        loseSprite = this.transform.GetChild(2).gameObject;
        
        targetTime = 5;
    }

    void FixedUpdate()
    {
        //Checks threshold and switches to lose state if detects greater noise
        if (_wordDetector.volume >= volumeThresh)
        {
            _wordDetector.MurderTrigger = false;
            wordTriggered = true;
        }
        if (wordTriggered == true)
        {
            amount--;
        }

        if (amount < 2)
        {
            Debug.Log("Lose Condition met");

            neutralSprite.SetActive(false);
            loseSprite.SetActive(true);

            wordTriggered = false;
        }
        else if (amount == 2)
        {
            neutralSprite.SetActive(true);
            Debug.Log("Neutral Condition met");
            wordTriggered = false;

            targetTime -= Time.deltaTime;

            //After allotted time switches to win state for being quiet 
            if (targetTime <= 0.0f && amount == 2)
            {
                amount++;
            }
        }
        else if (amount > 2)
        {
            neutralSprite.SetActive(false);
            winSprite.SetActive(true);
            Debug.Log("Win Condition met");
            wordTriggered = false;
        }
    }
}