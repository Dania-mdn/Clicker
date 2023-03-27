using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Muvement : MonoBehaviour
{
    private Vector2 position;
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
        position = new Vector2(transform.position.x, 2.83f);
        StartCoroutine(MuveUp(position));
    }
    private void TakeReward()
    {
        gameObject.SetActive(false);
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
