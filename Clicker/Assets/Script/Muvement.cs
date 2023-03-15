using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Muvement : MonoBehaviour
{
    public int QueueCount;
    private float positionFitst = 2.83f;
    private float positionTwo = 1.78f;
    private float positionThre = 0.63f;
    void Update()
    {
        if(QueueCount == 0)
        {
            if (transform.position.y < positionFitst)
                transform.position = new Vector2(transform.position.x, transform.position.y + 0.1f);
        }
        else if (QueueCount == 1)
        {
            if (transform.position.y < positionTwo)
                transform.position = new Vector2(transform.position.x, transform.position.y + 0.1f);
        }
        else if (QueueCount == 2)
        {
            if (transform.position.y < positionThre)
                transform.position = new Vector2(transform.position.x, transform.position.y + 0.1f);
        }
    }
}
