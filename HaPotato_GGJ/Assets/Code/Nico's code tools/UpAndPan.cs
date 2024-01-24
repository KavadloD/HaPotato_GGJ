using UnityEngine;

public class UpAndPan : MonoBehaviour
{
    public RectTransform imageTransform;
    public float moveSpeed = 1f;
    public float panSpeed = 1f;
    public float maxYPos = 5f;
    public float startXPosRange = 2f;
    private float startYPos;

    private bool movingUp = true;
    private bool panningLeft = true;
    public bool panningOn=true;
    private void Start()
    {
        startYPos = imageTransform.anchoredPosition.y;
    }

    private void Update()
    {
        imageTransform.anchoredPosition += Vector2.up * moveSpeed * Time.deltaTime;

        // Check if the image has reached the maxYPos
        if (imageTransform.anchoredPosition.y >= maxYPos)
        {
            movingUp = false;
            imageTransform.anchoredPosition = new Vector2(imageTransform.anchoredPosition.x, startYPos);
        }

        if (panningOn == true)
        {
       

        float newXPos = Mathf.PingPong(Time.time * panSpeed, startXPosRange * 2) - startXPosRange;
        imageTransform.anchoredPosition = new Vector2(newXPos, imageTransform.anchoredPosition.y);
      
        // Check if the image has reached the startXPos
        if (newXPos <= -startXPosRange)
        {
            panningLeft = false;
        }
        else if (newXPos >= startXPosRange)
        {
            panningLeft = true;
        }
         }
        // Check if the image has reached the maxYPos and reset its position
        if (!movingUp && imageTransform.anchoredPosition.y <= startYPos)
        {
            movingUp = true;
            imageTransform.anchoredPosition = new Vector2(imageTransform.anchoredPosition.x, startYPos);
        }
    }
}