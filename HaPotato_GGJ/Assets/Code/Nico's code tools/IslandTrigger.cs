using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IslandTrigger : MonoBehaviour
{
    public int amount; // This could be any variable that changes over time
    private WordDetector _wordDetector;
    private bool wordTriggered;
    private float targetTime;
    private bool played;
    
    private GameObject chopperSprite;
    private GameObject helpSprite;

    private GameObject audioLayer;
        
    private AudioSource _audioSource;
    public AudioClip Crowd_Cheer;
    public AudioClip Crowd_Dissapoint;
    
    private GameObject parentObject;
    
    void Awake()
    {
        audioLayer = GameObject.FindGameObjectWithTag("GameController");
        
        _wordDetector = audioLayer.GetComponent<WordDetector>();
        _audioSource = GetComponent<AudioSource>();
        wordTriggered = false;
        targetTime = 5;
        amount = 2; 
        
        chopperSprite = this.transform.GetChild(0).gameObject; 
        helpSprite = this.transform.GetChild(1).gameObject;
        
        played = false; 
    }

    private void Start()
    {
        AudioLoudnessDetecton[] audioLoudness = FindObjectsOfType<AudioLoudnessDetecton>();
    }

    void FixedUpdate()
    {
        if (_wordDetector.IslandTrigger == true)
        {
            _wordDetector.IslandTrigger = false;
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

            wordTriggered=false;
            
            if (!played)
            {
                _audioSource.PlayOneShot(Crowd_Cheer);
                played = true;
            }
        }
    }
}
