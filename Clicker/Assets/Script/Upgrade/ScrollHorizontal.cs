using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScrollHorizontal : MonoBehaviour
{
    [Header("Controllers")]
    [Range(1, 50)]
    [SerializeField] private int _panCount;
    [Range(0, 500)]
    [SerializeField] private int _panOffset;
    [Range(0f, 20f)]
    [SerializeField] private float _snapSpeed;
    [Range(0f, 10f)]
    [SerializeField] private float _scaleOffset;
    [Range(1f, 20f)]
    [SerializeField] private float _scaleSpeed;

    [Header("Other Objects")]
    [SerializeField] private SaveSystem _saveSystem;
    [SerializeField] private GameObject[] _panPrefab;
    [SerializeField] private int[] _priceShip;
    [SerializeField] private GameObject[] _ship;
    [SerializeField] private ScrollRect _scrollRect;
    [SerializeField] private ManagerButton _managerButton;
    [SerializeField] private GameObject _buyButton;
    [SerializeField] private Color _clos;
    [SerializeField] private Color _open;
    [SerializeField] private Toggle _toggleEngine;
    [SerializeField] private Toggle _toggleConstruction;
    [SerializeField] private Toggle _toggleCrev;
    [SerializeField] private GameObject _alradyBuyButton;

    private TextMeshProUGUI _buyButtonText;
    private Image SpriteColor;
    private Vector2 _startPositionShip = new Vector2(0.43f, -0.98f);
    private GameObject[] _instPans;
    private Vector2[] _pansPos;
    private Vector2[] _pansScale;
    private GameObject _shipScene;
    private RectTransform _contentRect;
    private Vector2 _contentVector;
    private int _selectedPan;
    private bool _isScrolling;

    private void Start()
    {
        InitializeShip(_saveSystem.SaveContain.ShipNumber);

        SpriteColor = _buyButton.GetComponent<Image>();

        _contentRect = GetComponent<RectTransform>();
        _instPans = new GameObject[_panCount];
        _pansPos = new Vector2[_panCount];
        _pansScale = new Vector2[_panCount];

        for (int i = 0; i < _panCount; i++)
        {
            _instPans[i] = Instantiate(_panPrefab[i], transform, false);

            if (i == 0) continue;
            _instPans[i].transform.localPosition = new Vector2(_instPans[i - 1].transform.localPosition.x + _panPrefab[i].GetComponent<RectTransform>().sizeDelta.x + _panOffset, _instPans[i].transform.localPosition.y);
            _pansPos[i] = -_instPans[i].transform.localPosition;
        }
        OpenAvailableShip();

        _buyButtonText = _buyButton.GetComponentInChildren<TextMeshProUGUI>();
    }
    private void Update()
    {
        _toggleEngine.isOn = _saveSystem.SaveContain.GetAvailable(((int)Modul.Engine)) ? true : false;
        _toggleConstruction.isOn = _saveSystem.SaveContain.GetAvailable(((int)Modul.Deckhouse)) ? true : false;
        _toggleCrev.isOn = _saveSystem.SaveContain.GetAvailable(((int)Modul.Ñarcass)) ? true : false;

        if (_contentRect.anchoredPosition.x >= _pansPos[0].x && !_isScrolling || _contentRect.anchoredPosition.x <= _pansPos[_pansPos.Length - 1].x && !_isScrolling)
            _scrollRect.inertia = false;

        float nearestPos = float.MaxValue;

        for (int i = 0; i < _panCount; i++)
        {
            float distance = Mathf.Abs(_contentRect.anchoredPosition.x - _pansPos[i].x);
            if (distance < nearestPos)
            {
                nearestPos = distance;
                _selectedPan = i;
                if (_priceShip[i] != 0)
                {
                    _alradyBuyButton.SetActive(false);
                    _buyButton.SetActive(true);
                    _buyButtonText.text = _priceShip[i].ToString("0");
                    if (_priceShip[i] <= MonneyHandler.singleton.MonneyCount)
                    {
                        if (_toggleEngine.isOn && _toggleConstruction.isOn && _toggleCrev.isOn)
                            SpriteColor.color = _open;
                        else
                            SpriteColor.color = _clos;
                    }
                    else
                    {
                        SpriteColor.color = _clos;
                    }
                }
                else
                {
                    SpriteColor.color = _open;
                    _alradyBuyButton.SetActive(true);
                    _buyButton.SetActive(false);
                }
            }
            PanScale(i, distance);
        }
        PanCenter();
    }
    public void PanScale(int i, float distance)
    {
        float scale = Mathf.Clamp(1 / (distance / _panOffset) * _scaleOffset, 0.5f, 1f);
        _pansScale[i].x = Mathf.SmoothStep(_instPans[i].transform.localScale.x, scale + 0.3f, _scaleSpeed * Time.deltaTime);
        _pansScale[i].y = Mathf.SmoothStep(_instPans[i].transform.localScale.y, scale + 0.3f, _scaleSpeed * Time.deltaTime);
        _instPans[i].transform.localScale = _pansScale[i];
    }
    public void PanCenter()
    {
        float scrollVelocity = Mathf.Abs(_scrollRect.velocity.x);
        if (scrollVelocity < 600 && !_isScrolling) _scrollRect.inertia = false;
        if (_isScrolling || scrollVelocity > 600) return;
        _contentVector.x = Mathf.SmoothStep(_contentRect.anchoredPosition.x, _pansPos[_selectedPan].x, _snapSpeed * Time.deltaTime);
        _contentRect.anchoredPosition = _contentVector;
    }
    public void BuyShip()
    {
        if(SpriteColor.color == _open)
        {
            _managerButton.CloseAllButton();
            MonneyHandler.singleton.TakeManey(_priceShip[_selectedPan]);
            _saveSystem.SaveContain.SaveShipNumber(_selectedPan);
            OpenAvailableShip();
            Destroy(_shipScene);
            InitializeShip(_selectedPan);
            EventManager.DoBuy();
            EventManager.DoNewAchive(EventManager.AchiveName.Ship);
        }
    }
    public void InitializeShip(int shipNumber)
    {
        _shipScene = Instantiate(_ship[shipNumber], _startPositionShip, Quaternion.identity);
        Ship ship = _shipScene.GetComponent<Ship>();
        ship.SaveSystem = _saveSystem;
        ship.ShipNumber = shipNumber;
    }
    public void OpenAvailableShip()
    {
        for (int i = 0; i <= _saveSystem.SaveContain.AvailableShipNumber; i++)
        {
            Image[] img = _instPans[i].GetComponentsInChildren<Image>();
            foreach(var element in img)
                element.color = new Color(1, 1, 1);

            _priceShip[i] = 0;
        }
        MonneyHandler.singleton.PrizeMonney = _priceShip[_saveSystem.SaveContain.AvailableShipNumber + 1] / 30;
    }
    public void Scrolling(bool scroll)
    {
        _isScrolling = scroll;
        if (scroll) _scrollRect.inertia = true;
    }
    enum Modul { Engine, Deckhouse, Ñarcass }
}
