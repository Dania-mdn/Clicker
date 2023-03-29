using UnityEngine;

public class BacgroundHandler : PooledItem
{
    [SerializeField] private Sprite[] _abyssalSprite;
    [SerializeField] private Sprite[] _otherSprite;
    [SerializeField] private bool _abyssal;

    private SpriteRenderer SpriteRenderer;
    private const int _leftBorder = -6;
    private const float _abyssalSwimm = 0.75f;
    private const float _otherobjectSwimm = 0.4f;
    private const float _abyssalIdl = 0.3f;
    private const float _otherobjectIdl = 0.12f;

    private void Start()
    {
        SpriteRenderer = GetComponent<SpriteRenderer>();

        if (_abyssal)
        {
            SpriteRenderer.sprite = _abyssalSprite[Random.Range(0, _abyssalSprite.Length)];
        }
        else
        {
            SpriteRenderer.sprite = _otherSprite[Random.Range(0, _otherSprite.Length)];
        }
    }
    private void Update()
    {
        bool isPointerDown = Input.GetMouseButton(0);

        if (this.transform.position.x > _leftBorder)
        {
            float _swimm = _abyssal ? _abyssalSwimm : _otherobjectSwimm;
            float _idl = _abyssal ? _abyssalIdl : _otherobjectIdl;
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
