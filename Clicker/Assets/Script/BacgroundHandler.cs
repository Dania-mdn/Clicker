using UnityEngine;

public class BacgroundHandler : PooledItem
{
    [SerializeField] private Sprite[] ArrayAbyssalSprite;
    [SerializeField] private Sprite[] ArrayOtherSprite;
    private SpriteRenderer SpriteRenderer;
    private const int _leftBorder = -6;
    private float _swimm;
    private float _idl;
    [SerializeField] private bool _abyssal;
    [SerializeField] private bool _isPooled;
    private void Start()
    {
        SpriteRenderer = GetComponent<SpriteRenderer>();
        if (_abyssal)
        {
            SpriteRenderer.sprite = ArrayAbyssalSprite[Random.Range(0, ArrayAbyssalSprite.Length)];
            _swimm = 0.75f;
            _idl = 0.3f;
        }
        else
        {
            SpriteRenderer.sprite = ArrayOtherSprite[Random.Range(0, ArrayOtherSprite.Length)];
            _swimm = 0.4f;
            _idl = 0.12f;
        }
    }
    private void Update()
    {
        bool isPointerDown = Input.GetMouseButton(0);
        if (this.transform.position.x > _leftBorder)
        {
            if (isPointerDown)
                OffsetBacground(_swimm);
            else
                OffsetBacground(_idl);
        }
        else
        {
            if (_isPooled) Pooled();
            else Regular();
        }
    }

    private void OffsetBacground(float offset)
    {
        transform.position = new Vector2(transform.position.x - offset * Time.deltaTime, transform.position.y);
    }
    private void Regular() => Destroy(gameObject);
    private void Pooled() => ReturnToPool();
}
