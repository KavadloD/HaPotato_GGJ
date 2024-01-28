using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotatoTImer : MonoBehaviour
{
  
    public float targetTime = 60.0f;
    private float targetTimeChase;
    public GameObject kaboom;
    public GameObject kaboom2;
    public CurtainCall _CurtainCall;
    private void Start()
    {
        kaboom.SetActive(false);
        targetTimeChase = targetTime;
    }

    void Update()
    {

        targetTime -= Time.deltaTime/5;
        
        
        transform.localScale = new Vector3(targetTime/2,0.16f, 0);
        
        if (targetTime <= 0.0f)
        {
            targetTime = 0;
            kaboom.SetActive(true);
            kaboom2.SetActive(false);
            
        }
        else
        {
            kaboom.SetActive(false);
            kaboom2.SetActive(true);

        }
        
        if (targetTime <= -1f)
        {
            targetTime = 0;
            kaboom.SetActive(false);
            kaboom2.SetActive(false);
        }

        if (_CurtainCall.minigameSpawned == true)
        {
            targetTime = targetTimeChase;
            kaboom2.SetActive(true);
        }

    }
    
    
}
