using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cake : MonoBehaviour
{
  public int amount = 2; // This could be any variable that changes over time
    public AudioLoudnessDetecton _wordDetector;
    private bool wordTriggered=false;
    public float volumeThresh=0.07f;
    
    void FixedUpdate()
    {
        if (_wordDetector.volume >= volumeThresh)
        {
            _wordDetector.CakeTriggerer = false;
            wordTriggered = true;
        }
        if (wordTriggered == true)
        {
            amount++;
        }
        
        if (amount==1)
        {
            Debug.Log("Lose Condition met");
            wordTriggered=false;
        }
        else if (amount == 2)
        {
            Debug.Log("Neutral Condition met");
            wordTriggered=false;
            
        }
        else if (amount ==3)
        {
            Debug.Log("Win Condition met");
            wordTriggered=false;
        }
        else if (amount >=3)
        {
            amount = 2;//base level
            Debug.Log("Condition 5 met resetting");
            wordTriggered=false;
        }
        
        
    }
}
