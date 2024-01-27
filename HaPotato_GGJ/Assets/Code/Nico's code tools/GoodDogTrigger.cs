using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodDogTrigger : MonoBehaviour
{
    public int amount; // This could be any variable that changes over time
    private WordDetector _wordDetector;
    private bool wordTriggered;
    private float targetTime;
    private bool played;
    
    private GameObject neutralSprite;
    private GameObject winSprite;
    private GameObject loseSprite;

    private GameObject audioLayer;
        
    private AudioSource _audioSource;
    public AudioClip Crowd_Cheer;
    public AudioClip Crowd_Dissapoint;
    
    void Awake()
    {
        audioLayer = GameObject.FindGameObjectWithTag("GameController");
        
        _wordDetector = audioLayer.GetComponent<WordDetector>();
        _audioSource = GetComponent<AudioSource>();
        wordTriggered = false;
        targetTime = 5;
        amount = 2; 
        
        
        
        neutralSprite = this.transform.GetChild(0).gameObject; 
        winSprite = this.transform.GetChild(1).gameObject;
        loseSprite = this.transform.GetChild(2).gameObject;
        played = false; 
    }

    private void Start()
    {
        AudioLoudnessDetecton[] audioLoudness = FindObjectsOfType<AudioLoudnessDetecton>();
       
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
        
        //Lose
        if (amount < 2)
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
        
        //Win
        else if (amount > 2)
        {
            //Debug.Log("Win Condition 5 met resetting");
            neutralSprite.SetActive(false);
            winSprite.SetActive(true);
            
            wordTriggered=false;
            
            if (!played)
            {
                _audioSource.PlayOneShot(Crowd_Cheer);
                played = true;
            }
        }

    }
}
