using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollUI : MonoBehaviour
{
    public RectTransform imageTransform;
    public float moveSpeed = 1f;

    public float maxYPos = 5f;
   
    private float startYPos;

    private bool movingUp = true;
    private bool panningLeft = true;

    private void Start()
    {
        startYPos = imageTransform.anchoredPosition.y;
    }

    private void Update()
    {
        // Move the image upwards
        if (movingUp)
        {
            imageTransform.anchoredPosition += Vector2.up * moveSpeed * Time.deltaTime;

            // Check if the image has reached the maxYPos
            // Check if the image has reached the maxYPos
            if (imageTransform.anchoredPosition.y >= maxYPos)
            {
                movingUp = false;
            }
        }
        else
        {
            // Move the image back to its starting Y-position
            imageTransform.anchoredPosition = new Vector2(imageTransform.anchoredPosition.x, startYPos);
            movingUp = true;
        }
    }
}