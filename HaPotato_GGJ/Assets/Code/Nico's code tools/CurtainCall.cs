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
    public bool miniGameCounter;
    private float targetTime=5.5f;

    private bool minigameSpawned;
    private GameObject currentMinigame;

    public DestroyMinigame destroyTrigger;
    
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

            if (targetTime <= 1.0f)
            {
                //Making this false lowers the curtain
                isWordToggled = false;

                if (targetTime <= -1f)
                {
                    currentMinigame = GameObject.FindGameObjectWithTag("MinigameParent");
                    Destroy(currentMinigame);
                    minigameSpawned = false;
                }
            } 
        }
    }

    public void SpawnMiniGame()
    {
        minigameSpawned = true;
        targetTime = 6.5f; // the mini game time
        int randomIndex = Random.Range(0, miniGames.Length); // Grabs a random game from the list
        GameObject instantiatedMiniGame =
            Instantiate(miniGames[randomIndex], new Vector3(0, 0, 0),
                Quaternion.identity); //Spawns in the scene as a game Object
    }
}
