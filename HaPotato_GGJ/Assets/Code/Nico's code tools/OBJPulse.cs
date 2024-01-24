using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OBJPulse : MonoBehaviour
{
    public float maxScale = 2f;
    public float minScale = 0.5f;
    public float speed = 1f;

    private bool isGrowing = true;

    private void Update()
    {
        // Calculate the new scale based on the current time and speed
        float newScale = Mathf.Lerp(minScale, maxScale, Mathf.PingPong(Time.time * speed, 1f));

        // Apply the new scale to the object
        transform.localScale = new Vector3(newScale, newScale, newScale);

        // Check if the object has reached the maximum or minimum scale
        if (newScale >= maxScale || newScale <= minScale)
        {
            // Reverse the scaling direction
            isGrowing = !isGrowing;
        }
    }
}
