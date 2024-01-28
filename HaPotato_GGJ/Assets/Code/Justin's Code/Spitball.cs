using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor.Tilemaps;
using UnityEditor;

public class Spitball : MonoBehaviour
{
  public int amount = 1; // This could be any variable that changes over time
    public AudioLoudnessDetecton _wordDetector;
    private bool wordTriggered=false;
    [SerializeField] SpitballStatus gameStatus;
    [SerializeField] Sprite winSprite,loseSprite,turnSprite;
    [SerializeField] SpriteRenderer bg;
    public float TimeTeacherBecomesHittable;
    private float startTime;
    private bool shot;
    private bool shotHasBeenChecked;
    private bool teacherTurned;
    private float StartTime;

    private AudioSource _audioSource;
    private GameObject audioLayer;

    public float volumeThresh;
    public float loseTime;


    void Start(){
        shot = false;
        shotHasBeenChecked = false;
        startTime = Time.time;
    
        wordTriggered = false;
        audioLayer = GameObject.FindGameObjectWithTag("GameController");
        _wordDetector = audioLayer.GetComponent<AudioLoudnessDetecton>();
        
        _audioSource = GetComponent<AudioSource>();
        gameStatus = SpitballStatus.Ingame;
        startTime = Time.time;
    }

    void FixedUpdate(){
        print(_wordDetector.volume);
        //Checks threshold and switches to lose state if detects greater noise
        if (_wordDetector.volume >= volumeThresh)
        {
            _wordDetector.MurderTrigger = false;
            wordTriggered = true;
        }
        if (wordTriggered == true)
        {
            shot = true;
        }
    }
    
    void Update(){
        if(gameStatus == SpitballStatus.Ingame){
    
            // Check if spitting
            if(shot && !shotHasBeenChecked){

                // Check if valid timing
                if(teacherTurned){
                    gameStatus = SpitballStatus.Won;
                }
                else{
                    gameStatus = SpitballStatus.Lost;
                }
                shotHasBeenChecked = true;
            }

            // Check for timer loss and update time
            if(Time.time > StartTime + loseTime){
                gameStatus = SpitballStatus.Lost;
            }
        }

        // Turn the teacher at the right time
        if(!teacherTurned){
            if(Time.time > StartTime + TimeTeacherBecomesHittable){
                teacherTurned = true;
                bg.sprite = turnSprite;
            }
        }

        // Enable win/loss sprites
        if(gameStatus == SpitballStatus.Won){
            bg.sprite = winSprite;
        }
        if(gameStatus == SpitballStatus.Lost){
            bg.sprite = loseSprite;
        }
    }


    // The enum for gameStatus
    public enum SpitballStatus{Ingame, Lost, Won}
}
