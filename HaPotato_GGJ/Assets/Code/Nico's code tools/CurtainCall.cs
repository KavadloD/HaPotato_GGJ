using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class CurtainCall : MonoBehaviour
{
    #region Inital spots

    // Define the public Vector2 variables for the two points
    public Vector2 point1;
    public Vector2 point2;
    #endregion
    
    #region Curtain controller
    
    private bool isWordToggled = false; 
    public WordDetector _WordDetector;

    #endregion
    
    #region MiniGameControllers

    public GameObject[] miniGames;
    public bool miniGameCounter;
    private float targetTime=5.5f;
    
    public bool minigameSpawned;
    private GameObject currentMinigame;

    #endregion

    #region UI Text
    
    public Text discripText;
    public Text uiText;

    [SerializeField] private float duration = 1f;

    private Vector3 initialScale;
    private Vector3 targetScale;

    #endregion
    
    public bool playerOne;
    public bool playerTrigger=false;
    private int lastRolledNum;
    
    public string playerOneString;
    public string playerTwoString;
    private string miniGameDiscrip;
    
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
        if (_WordDetector.miniGameTrigger1==false)
        {
            UpdateUIText(null);//removes it from the menu
            UpdateIDis(null);//removes it from the menu
        }
        else
        {
            //UpdateUIText(playerOneString);
        }
        //print(targetTime);
        
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
            if (targetTime < 8.5f&& targetTime >4.5)
            {
                UpdateUIText(null); //removes it from the Mini Game Screen
                UpdateIDis(null); //removes it from the Mini Game Screen
               
            }

            if (targetTime >= 4)
            {
                playerTrigger = false;//checks if the player is flipping 
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
            
            
            if (targetTime<=3 && playerTrigger==false)
            {
                if (playerOne)
                {
                    Debug.Log("Made it here P2");
                    playerOne = false;
                    UpdateUIText(playerTwoString);
                    playerTrigger = true;
                }
                else if (!playerOne)
                {
                    Debug.Log("Made it here P1");
                    playerOne = true;
                    UpdateUIText(playerOneString);
                    playerTrigger = true;
                }

            }

            if (targetTime <= -4)
            {
                
           
                minigameSpawned = false; 
                Destroy(currentMinigame); 
            }
            //print("got flag 4");
        }
    }

    public void SpawnMiniGame()
    {
        played = false;
        minigameSpawned = true;
        targetTime = 9.5f; // the mini game time
        
        int randomIndex = Random.Range(0, miniGames.Length); // Grabs a random game from the list

        int randomAddon = Random.Range(1, miniGames.Length);

        if (lastRolledNum == randomIndex)
        {
            GameObject instantiatedMiniGame =
                Instantiate(miniGames[randomIndex+randomAddon-1], new Vector3(0, 0, 0),
                    Quaternion.identity); //Spawns in the scene as a game Object     
        }
        else
        {
            GameObject instantiatedMiniGame =
                Instantiate(miniGames[randomIndex], new Vector3(0, 0, 0),
                    Quaternion.identity); //Spawns in the scene as a game Object
        }

        if (randomIndex < miniGames.Length)
        {
            randomIndex = miniGames.Length;
        }
        
        lastRolledNum = randomIndex;
        //FindGameIds();
    }
    
    void UpdateUIText(string newText)
    {
        // Update the text property of the UI Text component
        uiText.text = newText;
    }
    void UpdateIDis(string newText2)
    {  
        // Update the text property of the UI Text component
        discripText.text = newText2;
    }

    void FindGameIds()
    {
        currentMinigame = GameObject.FindGameObjectWithTag("MinigameParent");
        MiniGameWordStorage minigameID = currentMinigame.GetComponent<MiniGameWordStorage>();
        miniGameDiscrip = minigameID.myString;
        UpdateIDis(minigameID.myString);

    }
    
    IEnumerator ScaleOverTime()
    {
        float t = 0;
        while (t <= 1)
        {
            t += Time.deltaTime / duration;
            uiText.transform.localScale = Vector3.Lerp(initialScale, targetScale, t);
            yield return null;
        }
    }
}
