using UnityEngine;

public class Seagulls : PooledItem
{
    private float _direction;
    private float _positionx;
    private float _positiony;

    private void Start()
    {
        const float _scaleMin = 0.1f;
        const float _scaleMax = 0.5f;
        float _seagullsScale = Random.Range(_scaleMin, _scaleMax);

        float _randomValue = 0.6f;
        float _randomVertical = Random.Range(_randomValue, -_randomValue);

        _direction = HandlerDirection();
        transform.localScale = new Vector2(_seagullsScale, _seagullsScale);

        _positionx =  _direction * _seagullsScale * Time.deltaTime;
        _positiony = _randomVertical * _seagullsScale * Time.deltaTime;
    }
    private void Update()
    {
        if (IsZone())
        {
            transform.position = new Vector2(transform.position.x + _positionx, transform.position.y + _positiony);
        }
        else
        {
            if (_isPooled) Pooled();
            else Regular();
        }
    }
    private bool IsZone() => transform.position.y > -1.4f && transform.position.y < 4.6f && transform.position.x > -4.2f && transform.position.x < 4.2f;
    private float HandlerDirection()
    {
        float directionLeft = -0.5f;
        float directionRight = 0.5f;
        return transform.position.x > 0 ? directionLeft : directionRight;
    }
    private void Regular() => Destroy(gameObject);
    private void Pooled() => ReturnToPool();
}
