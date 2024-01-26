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

        if (_WordDetector.miniGameTrigger1==true)
        {
           
            StartMinigame();
            if (targetTime <= 0.0f)
            {
                isWordToggled = false;
            } 
        }
        
        
        
        
    }

    public void StartMinigame()
    {
        if (miniGameCounter == 0)
        { 
            targetTime = 5.5f;
            int randomIndex = Random.Range(0, miniGames.Length);
            Instantiate(miniGames[randomIndex], new Vector3(0, 0, 0), Quaternion.identity);
            isWordToggled = true;
            miniGameCounter++; 
        }
     
        
    }
    
}
