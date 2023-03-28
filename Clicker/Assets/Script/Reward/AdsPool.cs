using UnityEngine;

public class AdsPool : MonoBehaviour
{
    [SerializeField] private GameObject[] _arreyReward;
    [Range(10, 60)]
    [SerializeField] private float _spawnCooldown;

    private float _cooldownTimer;
    private readonly Vector2 _startPosition = new Vector2(2.07f, -8);
    private bool shouldEnqueue = false;

    private void Update()
    {
        if (Time.time < _cooldownTimer) return;

        _cooldownTimer = Time.time + _spawnCooldown;

        shouldEnqueue = !shouldEnqueue;

        if(shouldEnqueue)
            TakeReward();
        else
            Enqueue(_arreyReward[Random.Range(0, 3)]);
    }
    private void Enqueue(GameObject gameObject)
    {
        gameObject.SetActive(true);
        gameObject.transform.position = _startPosition;
    }
    public void TakeReward() => EventManager.DoTakeReward();
}
