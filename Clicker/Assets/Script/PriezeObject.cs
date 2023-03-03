using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PriezeObject : PooledItem
{
    private float _spawnCooldown = 12;
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
