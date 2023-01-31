using UnityEngine;

public class Seagulls : MonoBehaviour
{
    private float _scaleMin = 0.1f;
    private float _scaleMax = 0.5f;
    private float _seagullsScale;

    private float _randomValue = 0.6f;
    private float _randomVertical;

    private int _direction;
    private float _positionx;
    private float _positiony;
    private void Start()
    {
        _seagullsScale = Random.Range(_scaleMin, _scaleMax);
        _randomVertical = Random.Range(_randomValue, -_randomValue);
        _direction = HandlerDirection();
        transform.localScale = new Vector3(_seagullsScale, _seagullsScale, 1);

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
            Destroy(gameObject);
        }
    }
    private bool IsZone()
    {
        if (transform.position.y > -1.4f && transform.position.y < 4.6f && transform.position.x > -4.2f && transform.position.x < 4.2f)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    private int HandlerDirection()
    {
        if (transform.position.x > 0)
        {
            return  -1;
        }
        else
        {
            return  1;
        }
    }
}
