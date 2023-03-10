using UnityEngine;

public class ShipModuls : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer; 
    public Sprite[] SpriteArray;
    public int Lvl;
    public float _coef = 1;
    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        if (_coef < 1)
        {
            _coef = _coef + 0.01f;
            _spriteRenderer.sprite = SpriteArray[Lvl];
            ChangeColor(_coef);
        }
    }
    private void ChangeColor(float coef)
    {
        _spriteRenderer.color = new Color(coef, coef, coef);
    }
}
