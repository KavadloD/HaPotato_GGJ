using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.UI;

public class GoodDogTrigger : MonoBehaviour
{
    public int amount; // This could be any variable that changes over time
    public WordDetector _wordDetector;
    private bool wordTriggered;
    private float targetTime;
    
    private GameObject neutralSprite;
    private GameObject winSprite;
    private GameObject loseSprite;

    void Awake()
    {
        wordTriggered = false;
        targetTime = 5;
        amount = 2; 
        neutralSprite = this.transform.GetChild(0).gameObject; 
        winSprite = this.transform.GetChild(1).gameObject;
        loseSprite = this.transform.GetChild(2).gameObject;
    }
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
        
        if (amount < 2)
        {
            //Debug.Log("Lose Condition Met");
            neutralSprite.SetActive(false);
            loseSprite.SetActive(true);
            wordTriggered=false;
        }
        
        else if (amount == 2)
        {
            //Debug.Log("Neutral Condition met");
            
            neutralSprite.SetActive(true);
            
            wordTriggered=false;
            targetTime -= Time.deltaTime;

            //Basic Timer
            if (targetTime <= 0.0f && amount == 2)
            {
                amount--;
            }
        }
        
        else if (amount > 2)
        {
            //Debug.Log("Win Condition 5 met resetting");
            neutralSprite.SetActive(false);
            winSprite.SetActive(true);
            
            wordTriggered=false;
        }

    }
}
