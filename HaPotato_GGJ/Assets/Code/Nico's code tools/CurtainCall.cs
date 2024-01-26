using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurtainCall : MonoBehaviour
{
    // Define the public Vector2 variables for the two points
    public Vector2 point1;
    public Vector2 point2;
    private bool isWordToggled = false;
    public WordDetector _WordDetector;
    public GameObject[] miniGames;
    public int miniGameCounter=0;
    private float targetTime=5.5f;
    public bool minigameSpawned = false;
    private GameObject instantiatedMiniGame;
    
    void Update()
    {
        targetTime -= Time.deltaTime;
        if (isWordToggled)
        {
            transform.position = Vector2.Lerp(transform.position, point2, Time.deltaTime);
        }
        else
        {
            transform.position = Vector2.Lerp(transform.position, point1, Time.deltaTime);
        }

        // Check if the Menu open words are said
        if (_WordDetector.menuOpening==true)
        {
            isWordToggled = true; //Curtains Open
        }
        else if (_WordDetector.menuOpening==false)
        {
            isWordToggled = false;//Curtains Close
        
        }

        if (_WordDetector.miniGameTrigger1==true)
        {
           
            StartMinigame();
            if (targetTime <= 0.0f)
            {
                isWordToggled = false;// Lowers the Curtains when the timer hits zero
            
            } 
        }
        
        
        
        
    }

    public void StartMinigame()
    {
        if (minigameSpawned == false)
        {
            
            SpawnMiniGame();
        }

        if (targetTime <= -4f) 
        { 
             //Destroy(instantiatedMiniGame); 
             minigameSpawned = false; 
        }
    }

    public void SpawnMiniGame() 
    {   
        minigameSpawned = true;
        targetTime = 5.5f;// the mini game time
        int randomIndex = Random.Range(0, miniGames.Length);// Grabs a random game from the list
        GameObject instantiatedMiniGame = Instantiate(miniGames[randomIndex], new Vector3(0, 0, 0), Quaternion.identity); //Spawns in the scene as a game Object
       
        
        
    }
}
