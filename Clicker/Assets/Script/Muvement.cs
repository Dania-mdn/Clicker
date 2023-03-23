using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Muvement : MonoBehaviour
{
    public int QueueCount;
    private Vector2[] position = new Vector2[3];
    private void OnEnable()
    {
        EventManager.TakeReward += TakeReward;
    }
    private void OnDisable()
    {
        EventManager.TakeReward -= TakeReward;
    }
    private void Start()
    {
        position[0] = new Vector2(transform.position.x, 2.83f);
        position[1] = new Vector2(transform.position.x, 1.78f);
        position[2] = new Vector2(transform.position.x, 0.63f);
        StartCoroutine(MuveUp(position[QueueCount]));
    }
    private void TakeReward()
    {
        if (QueueCount > 0)
            QueueCount--;
        else
            Destroy(gameObject);
        StartCoroutine(MuveUp(position[QueueCount]));
    }
    IEnumerator MuveUp(Vector2 endPosition)
    {
        Vector2 startPos = this.transform.position;

        float duration = 3;
        float elapsedTime = 0.0f;

        while (elapsedTime < duration)
        {
            transform.position = Vector2.Lerp(startPos, endPosition, (elapsedTime / duration));
            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }
}
