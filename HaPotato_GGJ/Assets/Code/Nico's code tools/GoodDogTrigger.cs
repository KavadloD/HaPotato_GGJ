using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodDogTrigger : MonoBehaviour
{
    public int amount = 0; // This could be any variable that changes over time
    public WordDetector _wordDetector;
    private bool wordTriggered=false;
    
    void FixedUpdate()
    {
        if (_wordDetector.GDogTrigger == true)
        {
            _wordDetector.GDogTrigger = false;
            wordTriggered = true;
        }
        if (wordTriggered == true)
        {
            amount++;
        }
        
        if (amount==1)
        {
            Debug.Log("Condition 1 met");
            wordTriggered=false;
        }
        else if (amount == 2)
        {
            Debug.Log("Condition 2 met");
            wordTriggered=false;
        }
        else if (amount ==3)
        {
            Debug.Log("Condition 3 met");
            wordTriggered=false;
        }
        else if (amount ==4)
        {
            Debug.Log("Condition 4 met");
            wordTriggered=false;
        }
        else if (amount <4)
        {
            amount = 0;
            Debug.Log("Condition 5 met resetting");
            wordTriggered=false;
        }
        
        
    }
}
