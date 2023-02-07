using UnityEngine;

public class BacgroundHandler : MonoBehaviour
{
    private const int _leftBorder = -6;
    private float _swimm;
    private float _idl;
    [SerializeField] private bool _deep;
    private void Start()
    {
        if (_deep)
        {
            _swimm = 0.75f;
            _idl = 0.3f;
        }
        else
        {
            _swimm = 0.4f;
            _idl = 0.12f;
        }
    }
    private void Update()
    {
        if (this.transform.position.x > _leftBorder)
        {
            if (PlayerPrefs.HasKey("tap"))
                OffsetBacground(_swimm);
            else
                OffsetBacground(_idl);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OffsetBacground(float offset)
    {
        transform.position = new Vector2(transform.position.x - offset * Time.deltaTime, transform.position.y);
    }
}
