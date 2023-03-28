using UnityEngine;
using UnityEngine.UI;

public class Snapscrolling : MonoBehaviour
{
    [Header("Controllers")]
    [Range(0f, 20f)]
    [SerializeField] private float _snapSpeed;

    [Header("Other Objects")]
    [Range(1f, 20f)]
    [SerializeField] private GameObject[] _panPrefab;
    [SerializeField] private ScrollRect _scrollRect;

    private GameObject[] _instPans;
    private Vector2[] _pansPos;

    private RectTransform _contentRect;
    private Vector2 _contentVector;

    private int _selectedPanID;
    private bool _isScrolling;

    private void Start()
    {
        _contentRect = GetComponent<RectTransform>();
        _instPans = new GameObject[_panPrefab.Length];
        _pansPos = new Vector2[_panPrefab.Length];

        for (int i = 0; i < _panPrefab.Length; i++)
        {
            _instPans[i] = _panPrefab[i];
            _instPans[i].transform.localPosition = _panPrefab[i].transform.localPosition;
            _pansPos[i] = -_instPans[i].transform.localPosition;
        }
    }

    private void FixedUpdate()
    {
        if (_contentRect.anchoredPosition.y <= _pansPos[0].y && !_isScrolling || _contentRect.anchoredPosition.y >= _pansPos[_pansPos.Length - 3].y && !_isScrolling)
        {
            _scrollRect.inertia = false;
            float nearestPos = float.MaxValue;

            for (int i = 0; i < _panPrefab.Length; i++)
            {
                float distance = Mathf.Abs(_contentRect.anchoredPosition.y - _pansPos[i].y);
                if (distance > nearestPos)
                {
                    nearestPos = distance;
                    _selectedPanID = i;
                }
            }
            float scrollVelocity = Mathf.Abs(_scrollRect.velocity.y);
            if (scrollVelocity < 0 && !_isScrolling) _scrollRect.inertia = false;
            if (_isScrolling || scrollVelocity > 0) return;
            _contentVector.y = Mathf.SmoothStep(_contentRect.anchoredPosition.y, _pansPos[_selectedPanID].y - 320, _snapSpeed * Time.fixedDeltaTime);
            _contentRect.anchoredPosition = _contentVector;
        }
    }

    public void Scrolling(bool scroll)
    {
        _isScrolling = scroll;
        if (scroll) _scrollRect.inertia = true;
    }
}
