using System.Collections;
using UnityEngine;

public class ShipModuls : MonoBehaviour
{
    [SerializeField] private Sprite[] _spriteArray = new Sprite[4];
    [HideInInspector] public int Lvl;

    private SpriteRenderer _spriteRenderer;
    private Color _starColor = new Color(0, 0, 0);
    private Color _endColor = new Color(1, 1, 1);
    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }
    public void SetColor()
    {
        StartCoroutine(ColorTransitionCoroutine());
    }
    IEnumerator ColorTransitionCoroutine()
    {
        _spriteRenderer.sprite = _spriteArray[Lvl];
        float duration = 3;
        float elapsedTime = 0;

        while (elapsedTime < duration)
        {
            _spriteRenderer.color = Color.Lerp(_starColor, _endColor, (elapsedTime / duration));
            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }
}
