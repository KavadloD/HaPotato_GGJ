using UnityEngine;

public class UpAndPan : MonoBehaviour
{
    public Transform imageTransform;
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
        startYPos = imageTransform.position.y;
    }

    private void Update()
    {
        imageTransform.position += Vector3.up * moveSpeed * Time.deltaTime;

        // Check if the image has reached the maxYPos
        if (imageTransform.position.y >= maxYPos)
        {
            movingUp = false;
            imageTransform.position = new Vector3(imageTransform.position.x, startYPos, imageTransform.position.z);
        }

        if (panningOn == true)
        {
       

            float newXPos = Mathf.PingPong(Time.time * panSpeed, startXPosRange * 2) - startXPosRange;
            imageTransform.position = new Vector3(newXPos, imageTransform.position.y, imageTransform.position.z);
      
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
        if (!movingUp && imageTransform.position.y <= startYPos)
        {
            movingUp = true;
            imageTransform.position = new Vector3(imageTransform.position.x, startYPos, imageTransform.position.z);
        }
    }
}