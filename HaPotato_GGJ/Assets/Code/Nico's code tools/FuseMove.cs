using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.UIElements;

public class FuseMove : MonoBehaviour
{
    public PotatoTImer _Potato;
    public Vector2 point1;
    public Vector2 point2;
    public bool isTimerToggeled;
   // public Vector3 currentPosition;
    void Update()
    {

       // _Potato.targetTime -= Time.deltaTime/5;
        
        
        //transform.position = new Vector3(_Potato.targetTime,0.16f, 0);

        if (_Potato.targetTime<=5f)
        {
            isTimerToggeled = true;
        }
        
        
        if (isTimerToggeled)
        {
            transform.position = Vector2.MoveTowards(transform.position, point2, Time.deltaTime*3);
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, point1, Time.deltaTime*3);
        }

    }
}
