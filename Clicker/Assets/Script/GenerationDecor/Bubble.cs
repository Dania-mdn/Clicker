using UnityEngine;

public class Bubble : PooledItem
{
    private SpriteRenderer _spriteRenderer;

    private const float _lineOfWater = -1.85f;
    private const int _swimm = 2;
    private const float _idl = 0.5f;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        float _randomtransparencyMinValue = 0.1f;
        float _randomtransparencyMaxValue = 0.5f;
        _spriteRenderer.color = new Color(1f, 1f, 1f, Random.Range(_randomtransparencyMinValue, _randomtransparencyMaxValue));

        float _randomScaleMinValue = 0.3f;
        float _randomScaleMaxValue = 0.6f;
        float random = Random.Range(_randomScaleMinValue, _randomScaleMaxValue);
        transform.localScale = new Vector3(random, random, 1);
    }
    private void Update()
    {
        bool isPointerDown = Input.GetMouseButton(0);
        if (IsZone())
        {
            if (isPointerDown) Swimm(_swimm);
            else Swimm(_idl);
        }
        else
        {
            if (_isPooled) Pooled();
            else Regular();
        }
    }
    public bool IsZone() => transform.position.y < _lineOfWater && transform.position.x > -4.2f;
    private void Swimm(float speed)
    {
        float _climbRandomMinValue = 0.1f;
        float _climbRandomMaxValue = 0.4f;
        float _climbRandom = Random.Range(_climbRandomMinValue, _climbRandomMaxValue);
        transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y + _climbRandom * Time.deltaTime);
    }
    private void Regular() => Destroy(gameObject);
    private void Pooled() => ReturnToPool();
}
