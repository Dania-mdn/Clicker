using UnityEngine;

public class Fish : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;

    private float _speed;

    private float i;
    private float y;
    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteRenderer.color = new Color(1, 1, 1, Random.Range(0.25f, 0.85f));

        _speed = Random.Range(0.3f, 0.5f);

        y = Random.Range(0.2f, -0.2f);
        if (this.transform.position.x > 0)
        {
            if (PlayerPrefs.HasKey("action"))
            {
                int a = Random.Range(1, 3);
                if(a == 1)
                {
                    _spriteRenderer.flipX = true;
                    i = 0.7f;
                    transform.right = new Vector2(i, y);
                }
                else
                {
                    _spriteRenderer.flipX = false;
                    i = -0.7f;
                    transform.right = new Vector2(-i, -y);
                }
            }
            else
            {
                _spriteRenderer.flipX = false;
                i = -0.7f;
                transform.right = new Vector2(-i, -y);
            }
        }
        else
        {
            _spriteRenderer.flipX = true;
            i = 0.7f;
            transform.right = new Vector2(i, y);
        }
    }
    private void Update()
    {
        if (transform.position.y < -2.2f && transform.position.y > -5.7f && transform.position.x > -4.2f && transform.position.x < 4.2f)
        {
            if (PlayerPrefs.HasKey("action"))
            {
                Swimm(0.04f, i, y, _speed);
            }
            else
            {
                Swimm(0.01f, i, y, _speed);
            }
        }
        else if(transform.position.y >= -2.2f)
        {
            y = -0.5f;
            if (PlayerPrefs.HasKey("action"))
            {
                if (_spriteRenderer.flipX == true)
                {
                    transform.right = new Vector2(i, y);
                    Swimm(0.04f, i, y);
                }
                else
                {
                    transform.right = new Vector2(-i, -y);
                    Swimm(0.04f, i, y);
                }
            }
            else
            {
                if (_spriteRenderer.flipX == true)
                {
                    transform.right = new Vector2(i, y);
                    Swimm(0.01f, i, y);
                }
                else
                {
                    transform.right = new Vector2(-i, -y);
                    Swimm(0.01f, i, y);
                }
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Swimm(float s, float i, float y, float speed = 1)
    {
        transform.position = new Vector3(transform.position.x - s + i * speed * Time.deltaTime, transform.position.y + y * speed * Time.deltaTime, transform.position.z);
    }
}
