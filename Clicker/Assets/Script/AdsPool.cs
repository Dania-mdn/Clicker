using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdsPool : MonoBehaviour
{
    [SerializeField] private GameObject[] _arreyReward;
    [Range(10, 60)]
    [SerializeField] private float _spawnCooldown;
    private float _cooldownTimer;
    private readonly Vector2 _startPosition = new Vector2(2.07f, -8);
    private Queue<GameObject> _queue = new Queue<GameObject>();
    private int queueCount;

    private void Update()
    {
        if (Time.time < _cooldownTimer) return;
        _cooldownTimer = Time.time + _spawnCooldown;

        if (queueCount < 3)
        {
            Enqueue(_arreyReward[queueCount]);
            queueCount++;
        }
        else
        {
            queueCount = 0;
        }

        if (_queue.Count > 2) Dequeue();
    }
    private void Enqueue(GameObject gameObject)
    {
        _queue.Enqueue(gameObject);
        gameObject.SetActive(true);
        gameObject.transform.position = _startPosition;
        gameObject.GetComponent<Muvement>().QueueCount = queueCount;
    }
    public void Dequeue()
    {
        var queue = _queue.Dequeue();
        queue.SetActive(false);
    }
}
