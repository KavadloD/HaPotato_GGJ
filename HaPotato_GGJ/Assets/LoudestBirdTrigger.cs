using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoudestBirdTrigger : MonoBehaviour
{
  public int amount = 2; // This could be any variable that changes over time
    public AudioLoudnessDetecton _wordDetector;
    private bool wordTriggered;
    public float volumeThresh;
    private bool played;
    private float targetTime;
    
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
        _wordDetector = audioLayer.GetComponent<AudioLoudnessDetecton>();
        
        _audioSource = GetComponent<AudioSource>();
        
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
            
            if (!played)
            {
                _audioSource.PlayOneShot(Crowd_Dissapoint);
                played = true;
            }
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
            
            if (!played)
            {
                _audioSource.PlayOneShot(Crowd_Cheer);
                played = true;
            }
        }
    }
}
