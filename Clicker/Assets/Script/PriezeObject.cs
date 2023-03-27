using UnityEngine;

public class PriezeObject : PooledItem
{
    [Range(5f, 20f)]
    [SerializeField] private float _spawnCooldown = 12;

    private float _cooldownTimer;

    private void Update()
    {
        if (Time.time > _cooldownTimer)
        {
            _cooldownTimer = Time.time + _spawnCooldown;
            Pooled();
        }
    }
    public void Pooled() => ReturnToPool();
}
