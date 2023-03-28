using System.Collections;
using UnityEngine;

public class RewardMuveUp : MonoBehaviour
{
    private Vector2 _endPosition;
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
        _endPosition = new Vector2(transform.position.x, 2.83f);
        StartCoroutine(MuveUp(_endPosition));
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
