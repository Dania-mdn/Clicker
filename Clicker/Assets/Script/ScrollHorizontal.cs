using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScrollHorizontal : MonoBehaviour
{
    [Header("Controllers")]
    [Range(1, 50)]
    public int PanCount;
    [Range(0, 500)]
    public int PanOffset;
    [Range(0f, 20f)]
    public float SnapSpeed;
    [Range(0f, 10f)]
    public float ScaleOffset;
    [Range(1f, 20f)]
    public float ScaleSpeed;

    [Header("Other Objects")]
    public SaveSystem SaveSystem;
    public GameObject[] PanPrefab;
    public int[] PriceShip;
    public GameObject[] Ship;
    public ScrollRect ScrollRect;
    public ManagerButton ManagerButton;
    public TextMeshProUGUI PriceShipText;
    public Image SpriteColor;
    public Color _clos;
    public Color _open;
    public Toggle ToggleEngine;
    public Toggle ToggleConstruction;
    public Toggle ToggleCrev;
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
        InitializeShip(SaveSystem.SaveContain.ShipNumber);

        _contentRect = GetComponent<RectTransform>();
        _instPans = new GameObject[PanCount];
        _pansPos = new Vector2[PanCount];
        _pansScale = new Vector2[PanCount];

        for (int i = 0; i < PanCount; i++)
        {
            _instPans[i] = Instantiate(PanPrefab[i], /*!*/transform, false/*!*/);

            if (i == 0) continue;
            _instPans[i].transform.localPosition = new Vector2(_instPans[i - 1].transform.localPosition.x + PanPrefab[i].GetComponent<RectTransform>().sizeDelta.x + PanOffset, _instPans[i].transform.localPosition.y);
            _pansPos[i] = -_instPans[i].transform.localPosition;
        }
        OpenAvailableShip();
    }
    private void Update()
    {
        ToggleEngine.isOn = SaveSystem.SaveContain.GetAvailable(((int)Modul.Engine)) ? true : false;
        ToggleConstruction.isOn = SaveSystem.SaveContain.GetAvailable(((int)Modul.Deckhouse)) ? true : false;
        ToggleCrev.isOn = SaveSystem.SaveContain.GetAvailable(((int)Modul.Ñarcass)) ? true : false;

        if (_contentRect.anchoredPosition.x >= _pansPos[0].x && !_isScrolling || _contentRect.anchoredPosition.x <= _pansPos[_pansPos.Length - 1].x && !_isScrolling)
            ScrollRect.inertia = false;

        float nearestPos = float.MaxValue;
        //PlayerPrefs.SetFloat("Gift", PriceShip[i] / 30);

        for (int i = 0; i < PanCount; i++)
        {
            float distance = Mathf.Abs(_contentRect.anchoredPosition.x - _pansPos[i].x);
            if (distance < nearestPos)
            {
                nearestPos = distance;
                _selectedPan = i;
                if (PriceShip[i] != 0)
                {
                    PriceShipText.text = PriceShip[i].ToString("0");
                    if (PriceShip[i] <= MonneyHandler.singleton.MonneyCount)
                    {
                        if (ToggleEngine.isOn && ToggleConstruction.isOn && ToggleCrev.isOn)
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
                    if (PlayerPrefs.GetInt("Lanqaqe") == 2)
                        PriceShipText.text = "êóïëåíèé";
                    else if (PlayerPrefs.GetInt("Lanqaqe") == 1)
                        PriceShipText.text = "êóïëåí";
                    else if (PlayerPrefs.GetInt("Lanqaqe") == 0)
                        PriceShipText.text = "bought";
                }
            }
            PanScale(i, distance);
        }
        PanCenter();
    }
    public void PanScale(int i, float distance)
    {
        float scale = Mathf.Clamp(1 / (distance / PanOffset) * ScaleOffset, 0.5f, 1f);
        _pansScale[i].x = Mathf.SmoothStep(_instPans[i].transform.localScale.x, scale + 0.3f, ScaleSpeed * Time.deltaTime);
        _pansScale[i].y = Mathf.SmoothStep(_instPans[i].transform.localScale.y, scale + 0.3f, ScaleSpeed * Time.deltaTime);
        _instPans[i].transform.localScale = _pansScale[i];
    }
    public void PanCenter()
    {
        float scrollVelocity = Mathf.Abs(ScrollRect.velocity.x);
        if (scrollVelocity < 600 && !_isScrolling) ScrollRect.inertia = false;
        if (_isScrolling || scrollVelocity > 600) return;
        _contentVector.x = Mathf.SmoothStep(_contentRect.anchoredPosition.x, _pansPos[_selectedPan].x, SnapSpeed * Time.deltaTime);
        _contentRect.anchoredPosition = _contentVector;
    }
    public void BuyShip()
    {
        if(SpriteColor.color == _open)
        {
            ManagerButton.CloseAllButton();
            PlayerPrefs.SetInt("Ship_Trigger", 1);
            MonneyHandler.singleton.TakeManey(PriceShip[_selectedPan]);
            SaveSystem.SaveContain.SaveShipNumber(_selectedPan);
            OpenAvailableShip();
            Destroy(_shipScene);
            InitializeShip(_selectedPan);
            //ship
            EventManager.DoBuy();
            EventManager.DoNewAchive(EventManager.AchiveName.Ship);
        }
    }
    public void InitializeShip(int shipNumber)
    {
        _shipScene = Instantiate(Ship[shipNumber], _startPositionShip, Quaternion.identity);
        Ship ship = _shipScene.GetComponent<Ship>();
        ship.SaveSystem = SaveSystem;
        ship.ShipNumber = shipNumber;
    }
    public void OpenAvailableShip()
    {
        for (int i = 0; i <= SaveSystem.SaveContain.AvailableShipNumber; i++)
        {
            Image[] img = _instPans[i].GetComponentsInChildren<Image>();
            foreach(var element in img)
                element.color = new Color(1, 1, 1);

            PriceShip[i] = 0;
        }
    }
    public void Scrolling(bool scroll)
    {
        _isScrolling = scroll;
        if (scroll) ScrollRect.inertia = true;
    }
    enum Modul { Engine, Deckhouse, Ñarcass }
}
