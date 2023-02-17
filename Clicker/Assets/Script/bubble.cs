using UnityEngine;

public class Bubble : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;

    private const float _lineOfWater = -1.85f;
    private const int _swimm = 2;
    private const float _idl = 0.5f;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteRenderer.color = new Color(1f, 1f, 1f, Random.Range(0.1f, 0.5f));

        float random = Random.Range(0.3f, 0.6f);
        transform.localScale = new Vector3(random, random, 1);
    }
    private void Update()
    {
        if (transform.position.y < _lineOfWater)
        {
            if (PlayerPrefs.HasKey("_isPointerDown")) Swimm(_swimm);
            else Swimm(_idl);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Swimm(float state)
    {
        float _climb = Random.Range(0.2f, 0.4f);
        transform.position = new Vector2(transform.position.x - state * Time.deltaTime, transform.position.y + _climb * Time.deltaTime);
    }
}
