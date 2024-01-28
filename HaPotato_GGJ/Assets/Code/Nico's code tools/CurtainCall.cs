using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class CurtainCall : MonoBehaviour
{
    // Define the public Vector2 variables for the two points
    public Vector2 point1;
    public Vector2 point2;
    private bool isWordToggled = false;
    public WordDetector _WordDetector;
    public GameObject[] miniGames;
    public bool miniGameCounter;
    private float targetTime=5.5f;

    private bool minigameSpawned;
    private GameObject currentMinigame;
    public Text discripText;
    
    public bool playerOne;
    
    public Text uiText;
    public string playerOneString;
    public string playerTwoString;
    public string miniGameDiscrip;
    private AudioSource _audioSource;
    //public AudioClip BetweenTheme;

    private bool played;

    private void Awake()
    {
        playerOne = true;
        _audioSource = GetComponent<AudioSource>();
        
        UpdateUIText(playerOneString);
    }

    void Update()
    {
        targetTime -= Time.deltaTime;
        
        print(targetTime);
        
        if (isWordToggled)
        {
            transform.position = Vector2.Lerp(transform.position, point2, Time.deltaTime);
        }
        else
        {
            transform.position = Vector2.Lerp(transform.position, point1, Time.deltaTime);
        }

        // Check if the space bar is pressed or released
        if (_WordDetector.menuOpening==true)
        {
            isWordToggled = true;
        }
        else if (_WordDetector.menuOpening==false)
        {
            isWordToggled = false;
        }

        if (_WordDetector.miniGameTrigger1 == true) 
        {

            if (minigameSpawned == false)
            {
                SpawnMiniGame();
            }

            if (targetTime <= 4.0f)
            {
                //Making this false lowers the curtain
                isWordToggled = false;
                
                currentMinigame = GameObject.FindGameObjectWithTag("MinigameParent");
                //print("got flag 1");
            } 
            
            if (targetTime <= 3f)
            {
                if (minigameSpawned)
                {
                    currentMinigame.GetComponent<AudioSource>().Stop();
                }
                else
                {
                    print("");
                }

                if (!played)
                {
                    _audioSource.Play();
                    played = true;
                }
            }
            
            
            if (targetTime <= -3f)
            {
                if (playerOne)
                {
                    playerOne = false;
                    UpdateUIText(playerTwoString);
                }
                else if (!playerOne)
                {
                    playerOne = true;
                    UpdateUIText(playerOneString);
                }
                
                minigameSpawned = false;
                Destroy(currentMinigame);
                //print("got flag 4");
            }
        }
    }

    public void SpawnMiniGame()
    {
        played = false;
        minigameSpawned = true;
        targetTime = 9.5f; // the mini game time
        int randomIndex = Random.Range(0, miniGames.Length); // Grabs a random game from the list
        GameObject instantiatedMiniGame =
            Instantiate(miniGames[randomIndex], new Vector3(0, 0, 0),
                Quaternion.identity); //Spawns in the scene as a game Object
        FindGameIds();
    }
   
    void UpdateUIText(string newText)
    {
        // Update the text property of the UI Text component
        uiText.text = newText;
    }
    void UpdateUIDis(string newText2)
    {
        // Update the text property of the UI Text component
        discripText.text = newText2;
    }

    void FindGameIds()
    {
        currentMinigame = GameObject.FindGameObjectWithTag("MinigameParent");
        MiniGameWordStorage minigameID = currentMinigame.GetComponent<MiniGameWordStorage>();
        miniGameDiscrip = minigameID.myString;
        UpdateUIDis(minigameID.myString);
       
    }
}
