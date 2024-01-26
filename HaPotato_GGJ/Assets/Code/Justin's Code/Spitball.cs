using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor.Tilemaps;

public class Spitball : MonoBehaviour
{
  public int amount = 1; // This could be any variable that changes over time
    public AudioLoudnessDetecton _wordDetector;
    private bool wordTriggered=false;
    public float volumeThresh=0.07f;
    [SerializeField] GameObject ball;
    [SerializeField] GameObject teacher;
    [SerializeField] SpitballStatus gameStatus;
    [SerializeField] TMP_Text timerText;
    [SerializeField] GameObject win, lose;
    public float TimeTeacherBecomesHittable;
    private float startTime;
    private bool shot;
    private bool shotHasBeenChecked;
    private bool teacherTurned;
    private float StartTime;


    void Start(){
        shot = false;
        shotHasBeenChecked = false;
        startTime = Time.time;
    
        Vector2 v = new Vector2(400,0);
        ball.GetComponent<Rigidbody2D>().AddForce(v);
    }
    
    void Update(){
        if(gameStatus == SpitballStatus.Ingame){
    
            // Check if spitting
            if(shot && !shotHasBeenChecked){
                
                // Shoots the actual ball
                ball.SetActive(true);
                Vector2 v = new Vector2(400,0);
                ball.GetComponent<Rigidbody2D>().AddForce(v);

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
            if(Time.time > StartTime + 5){
                gameStatus = SpitballStatus.Lost;
            }
            timerText.text = string.Format("{0:N3}", Time.time - StartTime);
        }

        // Turn the teacher at the right time
        if(!teacherTurned){
            if(Time.time > StartTime + TimeTeacherBecomesHittable){
                teacher.transform.Rotate(180,0,180);
                teacherTurned = true;
            }
        }

        // Enable win/loss test sprites
        if(gameStatus == SpitballStatus.Won){
            win.SetActive(true);
        }
        if(gameStatus == SpitballStatus.Lost){
            lose.SetActive(true);
        }
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
            if(!shot){
                shot = true;
            }
        }
        
        
    }

    // The enum for gameStatus
    public enum SpitballStatus{Ingame, Lost, Won}
}
