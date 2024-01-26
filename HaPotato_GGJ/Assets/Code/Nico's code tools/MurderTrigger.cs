using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MurderTrigger : MonoBehaviour
{
    public int amount = 2; // This could be any variable that changes over time
    public AudioLoudnessDetecton _wordDetector;
    private bool wordTriggered=false;
    public float volumeThresh=0.07f;

    void Awake()
    {
        
    }
    void FixedUpdate()
    {
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
            wordTriggered=false;
        }
        else if (amount == 2)
        {
            Debug.Log("Neutral Condition met");
            wordTriggered=false;
            
        }
        else if (amount > 2)
        {
            Debug.Log("Win Condition met");
            wordTriggered=false;
        }

    }
}