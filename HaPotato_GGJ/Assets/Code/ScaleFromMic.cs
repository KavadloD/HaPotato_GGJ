using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleFromMic : MonoBehaviour
{

    public AudioSource source;
    public Vector3 minSize;
    public Vector3 maxSize;

    public AudioLoudnessDetecton _loudnessDetecton;

    public float loudnessSensitivity = 100;
    public float threshold = 0.1f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float loudness = _loudnessDetecton.GetLoudnessFromMicrophone() *
                         loudnessSensitivity;
        if (loudness < threshold)
            loudness = 0;
        transform.localScale = Vector3.Lerp(minSize, maxSize, loudness);
        


    }
}
