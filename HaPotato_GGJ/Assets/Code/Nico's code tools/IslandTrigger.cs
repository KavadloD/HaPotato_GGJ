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
    
    private float helpTimer;
    
    private GameObject chopperSprite;
    private GameObject helpSprite;
    private GameObject exclaimationSprite;

    private GameObject audioLayer;
        
    private AudioSource _audioSource;
    public AudioClip Crowd_Cheer;
    public AudioClip Crowd_Dissapoint;
    
    private GameObject parentObject;

    public bool chopperOverlap;

    public Chopper chopperScr;
    
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
        exclaimationSprite = this.transform.GetChild(2).gameObject;
        exclaimationSprite.SetActive(false);
        
        played = false; 
    }

    private void Start()
    {
        AudioLoudnessDetecton[] audioLoudness = FindObjectsOfType<AudioLoudnessDetecton>();
        
        _audioSource = GetComponent<AudioSource>();
        _wordDetector = audioLayer.GetComponent<WordDetector>();
    }

    void FixedUpdate()
    {
        
        if (_wordDetector.IslandTrigger == true)
        {
            _wordDetector.IslandTrigger = false;
            wordTriggered = true;
            print("test 1");
        }

        if (wordTriggered)
        {
            helpSprite.SetActive(true);
        }
        
        if (wordTriggered == true && chopperOverlap)
        {
            amount++;
            chopperScr.chopperStop = true;
            exclaimationSprite.SetActive(true);
            print("test 2");
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
