using UnityEngine;

public class Bubble : PooledItem
{
    private SpriteRenderer _spriteRenderer;

    private const float _lineOfWater = -1.85f;
    private const int _swimm = 2;
    private const float _idl = 0.5f;
    [SerializeField] private bool _isPooled;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteRenderer.color = new Color(1f, 1f, 1f, Random.Range(0.1f, 0.5f));

        float random = Random.Range(0.3f, 0.6f);
        transform.localScale = new Vector3(random, random, 1);
    }
    private void Update()
    {
        if (IsZone())
        {
            if (PlayerPrefs.HasKey("_isPointerDown")) Swimm(_swimm);
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
        float _climb = Random.Range(0.1f, 0.4f);
        transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y + _climb * Time.deltaTime);
    }
    private void Regular() => Destroy(gameObject);
    private void Pooled() => ReturnToPool();
}
