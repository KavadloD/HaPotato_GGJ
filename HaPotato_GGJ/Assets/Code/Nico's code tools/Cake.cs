using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cake : MonoBehaviour
{
    public int amount; // This could be any variable that changes over time
    public AudioLoudnessDetecton _wordDetector;
    private bool wordTriggered=false;
    public float volumeThresh=0.07f;
    private GameObject audioLayer;
    private bool played;

    
    private GameObject neutralSprite;
    private GameObject winSprite;
    private GameObject loseSprite;

    private float targetTime;
    //private GameObject audioLayer;
        
    public AudioSource _audioSource;
    public AudioClip Crowd_Cheer;
    public AudioClip Crowd_Dissapoint;
    
    private void Awake()
    {
        audioLayer = GameObject.FindGameObjectWithTag("GameController");
        _wordDetector = audioLayer.GetComponent<AudioLoudnessDetecton>(); 
        _audioSource = GetComponent<AudioSource>();
        wordTriggered = false;
        targetTime = 5;
        amount = 2; 
      
      
      
        neutralSprite = this.transform.GetChild(0).gameObject; 
        winSprite = this.transform.GetChild(1).gameObject;
        loseSprite = this.transform.GetChild(2).gameObject;
      
      
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
            amount++;
        }
        
        //Lose
        if (amount<2)
        {
            //Debug.Log("Lose Condition Met");
            neutralSprite.SetActive(false);
            loseSprite.SetActive(true);
            wordTriggered=false;
            
            if (!played)
            {
                _audioSource.PlayOneShot(Crowd_Dissapoint);
                played = true;
            }
        }
        //Neutral
        else if (amount == 2)
        {
            
            neutralSprite.SetActive(true);
            
            Debug.Log("Neutral Condition met");
            
            wordTriggered=false;
            targetTime -= Time.deltaTime;
            //Basic Timer
            if (targetTime <= 0.0f && amount == 2)
            {
                amount--;
            }
            
        } 
        
        //Win
        else if (amount >2)
        {
            //amount = 2;//base level
           // Debug.Log("Condition 5 met resetting");
           
            wordTriggered=false;
            neutralSprite.SetActive(false);
            winSprite.SetActive(true);
              
            if (!played)
            {
                _audioSource.PlayOneShot(Crowd_Cheer);
                played = true;
            }
            
        }
        
        
    }
}
