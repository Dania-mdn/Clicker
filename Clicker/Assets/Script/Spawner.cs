using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private PooledItem _prefab;
    [SerializeField] private Transform _parent;

    [SerializeField] private int _spawnCount;

    [SerializeField] private float _spawnPositionMinX;
    [SerializeField] private float _spawnPositionMaxX;
    [SerializeField] private float _spawnPositionMinY;
    [SerializeField] private float _spawnPositionMaxY;

    [Header("Speed")]
    [SerializeField] private float _spawnCooldown;
    private float _cooldownTimer;

    private Pool<PooledItem> _prefabPool;
    private void Start()
    {
        _prefabPool = new Pool<PooledItem>(_prefab, _spawnCount, _parent);
    }
    void Update()
    {
        if (Time.time > _cooldownTimer)
        {
            if (PlayerPrefs.HasKey("_isPointerDown"))
                _cooldownTimer = Time.time + _spawnCooldown / 4;
            else
                _cooldownTimer = Time.time + _spawnCooldown;

            float positionX;
            if (_prefab.IsLeftBorder)
                positionX = _spawnPositionMinX;
            else if (_prefab.IsRightBorder)
                positionX = _spawnPositionMaxX;
            else
                positionX = Random.Range(0, 2) == 0 ? _spawnPositionMinX : _spawnPositionMaxX;

            float positionY = Random.Range(_spawnPositionMinY, _spawnPositionMaxY);
            _prefabPool.TryInstantiate(out var prefab, new Vector2(positionX, positionY), Quaternion.identity);
        }
    }
}