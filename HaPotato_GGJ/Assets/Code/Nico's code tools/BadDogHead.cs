using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadDogHead : MonoBehaviour
{
    // Start is called before the first frame update
    private int bdogAmt; // This could be any variable that changes over time
    public BadDogTriggers _BadDog;
    private Vector3 startPosition;
    void Start()
    {
        startPosition = transform.position;
    }

    void FixedUpdate()
    {
        bdogAmt = _BadDog.amount;
        float newY = startPosition.y - (bdogAmt * 0.4f); // Adjust this line to control how much the object moves down per unit of X
        Vector3 newPosition = new Vector3(transform.position.x, newY, transform.position.z);
        transform.position = newPosition;
    }
}
