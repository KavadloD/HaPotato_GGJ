using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Chopper : MonoBehaviour
{
    private bool chopperGoingLeft;
    private bool chopperGoingRight;

    private SpriteRenderer _spr;
    // Start is called before the first frame update
    void Start()
    {
        chopperGoingLeft = true;
        chopperGoingRight = false;
        
        _spr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (chopperGoingRight)
        {
            transform.position = Vector2.Lerp(transform.position, new Vector2(17f,1.7f), Time.deltaTime);
            
            if (transform.position.x >= 13f)
            {
                chopperGoingRight = false;
                chopperGoingLeft= true;

                _spr.flipX = false;
            }
        }

        if (chopperGoingLeft)
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

    void OnTriggerEnter2D()
    {
        
    }
}