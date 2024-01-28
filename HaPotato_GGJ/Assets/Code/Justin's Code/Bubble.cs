using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bubble : MonoBehaviour
{
  public int amount = 0; // This could be any variable that changes over time
  public int amountNeeded = 10;
    public AudioLoudnessDetecton _wordDetector;
    private bool wordTriggered;
    public float volumeThresh;
    private bool played;
    private float targetTime;
    
    [SerializeField] GameObject bubble;
    [SerializeField] SpriteRenderer blower;
    [SerializeField] Sprite loseSprite;
    private GameObject audioLayer;
    private AudioSource _audioSource;
    public AudioClip Crowd_Cheer;
    public AudioClip Crowd_Dissapoint;
    public float startTime;
    public float endTime = 5;

    public Text uiText;
    public string myString = "Hello, Unity!";
    private wincon wincnd;
    

    void Awake()
    {
        audioLayer = GameObject.FindGameObjectWithTag("GameController");
        _wordDetector = audioLayer.GetComponent<AudioLoudnessDetecton>();
        
        _audioSource = GetComponent<AudioSource>();
        
        targetTime = 5;
        
    }

    void Start(){
        startTime = Time.time;
        wincnd = wincon.ingame;
    }
    

    void FixedUpdate()
    {
        if(wincnd == wincon.ingame)
            if(Time.time - startTime < endTime){
                print(_wordDetector.volume);
                if (_wordDetector.volume >= volumeThresh)
                {
                    _wordDetector.MurderTrigger = false;
                    wordTriggered = true;   
                }
                if (wordTriggered == true)
                {
                    amount++;
                    bubble.transform.localScale = new Vector3(bubble.transform.localScale.x+0.3f,bubble.transform.localScale.y+0.3f,bubble.transform.localScale.z+0.3f);
                    wordTriggered = false;
                }
                if(amount >= amountNeeded){
                    wincnd = wincon.win;
                    Debug.Log("Win!");
                }
            }
            else{
                wincnd = wincon.lose;
                blower.sprite = loseSprite;
                bubble.gameObject.SetActive(false);
                Debug.Log("Lose!");
            }


    }
    
    private enum wincon{ingame,win,lose}

}
