using UnityEngine;

public class Fish : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    private const float _lineOfWater = -2.22f;

    private float _directionHorizontal;
    private float _directionVertical;
    private float _boostSpeed;
    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteRenderer.color = new Color(1, 1, 1, Random.Range(0.25f, 0.85f));

        _directionVertical = Random.Range(0.2f, -0.2f);

        DirectionOfMov(Random.Range(1, 3));
    }
    private void Update()
    {
        if (IsZone())
        {
            Swimm(_boostSpeed, _directionHorizontal, _directionVertical);

            _boostSpeed = PlayerPrefs.HasKey("_isPointerDown") ? 0.04f : 0.01f;

            if (transform.position.y >= _lineOfWater)
                _directionVertical = -0.1f;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void DirectionOfMov(int random)
    {
        if (random == 1)
        {
            _directionHorizontal = 1;
        }
        else
        {
            _spriteRenderer.flipY = true;
            _directionHorizontal = -0.7f;
        }
        transform.right = new Vector2(_directionHorizontal, _directionVertical);
    }
    private bool IsZone() => transform.position.x < 4.2f && transform.position.x > -4.2f && transform.position.y < -2 && transform.position.y > -5.7f;
    private void Swimm(float boostSpeed, float directionHorizontal, float directionVertical)
    {
        float positionX = this.transform.position.x - boostSpeed + directionHorizontal * Time.deltaTime;
        float positionY = this.transform.position.y + directionVertical * Time.deltaTime;
        transform.position = new Vector3(positionX, positionY, transform.position.z);
    }
}
