using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Chopper : MonoBehaviour
{
    private bool chopperGoingLeft;
    private bool chopperGoingRight;
    public bool chopperStop;
    
    private SpriteRenderer _spr;

    public IslandTrigger islandScript;
    // Start is called before the first frame update
    void Start()
    {
        chopperStop = false;
        chopperGoingLeft = true;
        chopperGoingRight = false;
        
        _spr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (chopperGoingRight && !chopperStop)
        {
            transform.position = Vector2.Lerp(transform.position, new Vector2(17f,1.7f), Time.deltaTime);
            
            if (transform.position.x >= 13f)
            {
                chopperGoingRight = false;
                chopperGoingLeft= true;

                _spr.flipX = false;
            }
        }

        if (chopperGoingLeft && !chopperStop)
        {
            transform.position = Vector2.Lerp(transform.position, new Vector2(-17f,1.7f), Time.deltaTime);

            if (transform.position.x <= -13f)
            {
                chopperGoingRight = true;
                chopperGoingLeft= false;

               _spr.flipX = true;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        islandScript.chopperOverlap = true;
    }
    
    void OnTriggerExit2D(Collider2D col)
    {
        islandScript.chopperOverlap = false;
    }
}