using UnityEngine;
using UnityEngine.UI;
using TMPro;
public abstract class BazeUpdate : MonoBehaviour
{
    public SaveSystem SaveSystem;
    public Image ButtonSprite;
    public TextMeshProUGUI ButtonPrice;
    public TextMeshProUGUI LevelUpgrade;
    public Slider ProgressSlider;
    public int DefaultValueUpgradeClick;
    public int DefaultValueUpgradePassiv;
    public int IdModul;
    private readonly Color _open = new Color(0f, 1f, 0.168f);
    private readonly Color _close = new Color(1, 1, 1);
    private AudioSource _audioSource;
    private int[] _price;
    private int _shipNumber;
    protected int _levelUpgrade;
    private bool _available = false;
    public virtual void Start()
    {
        _audioSource = GetComponent<AudioSource>();

        if (SaveSystem.SaveContain.LoadlLevelUpgrade(IdModul) != 0)
            Load();
        else
            Save();
    }
    public void Update()
    {
        _price = MonneyHandler.singleton.PriceUpgrade[SaveSystem.SaveContain.ShipNumber];

        LevelUpgrade.text = "lvl " + _levelUpgrade.ToString("0"); //??

        if (ProgressSlider.value > 0.9)
        {
            ProgressSlider.value = 0;
        }

        if (_levelUpgrade < _price.Length)
        {
            if (_price[_levelUpgrade] < MonneyHandler.singleton.MonneyCount)
            {
                OpenButton(_price[_levelUpgrade].ToString("0"));
                if (_available == false)
                {
                    PlayerPrefs.SetInt((IdModul / 10).ToString("0"), PlayerPrefs.GetInt((IdModul / 10).ToString("0")) + 1);
                    _available = true;
                }
            }
            else
            {
                ClozeButton(_price[_levelUpgrade].ToString("0"), false);
                if (_available == true)
                {
                    PlayerPrefs.SetInt((IdModul / 10).ToString("0"), PlayerPrefs.GetInt((IdModul / 10).ToString("0")) - 1);
                    _available = false;
                }
            }
        }
        else
        {
            ClozeButton("MAX".ToString(), true);
            if (_available == true)
            {
                PlayerPrefs.SetInt((IdModul / 10).ToString("0"), PlayerPrefs.GetInt((IdModul / 10).ToString("0")) - 1);
                _available = false;
            }
        }

        if (_shipNumber != SaveSystem.SaveContain.ShipNumber)
        {
            Load();
            UpgradeImgeModule();
        }
    }
    public virtual void OpenButton(string Pricetext)
    {
        ButtonSprite.color = _open;
        ButtonPrice.text = Pricetext;
    }
    public virtual void ClozeButton(string Pricetext, bool isMaxUpgrade)
    {
        ButtonSprite.color = _close;
        ButtonPrice.text = Pricetext;
    }
    public virtual void ClickButton()
    {
        if (ButtonSprite.color == _open)
        {
            _audioSource.Play();

            MonneyHandler.singleton.TakeManey(_price[_levelUpgrade]);

            _levelUpgrade = _levelUpgrade + 1;
            ProgressSlider.value = ProgressSlider.value + 0.2f;

            Save();
            UpgradeImgeModule();
        }
    }
    public void UpgradeImgeModule()
    {
        PlayerPrefs.SetInt("Unloc " + IdModul, 1);
        Ship.singleton.ChangedSprite(IdModul, _levelUpgrade);
    }
    public virtual void Save()
    {
        SaveSystem.Reservation SaveContain = SaveSystem.SaveContain;
        SaveContain.SaveLevelUpgrade(IdModul, _levelUpgrade);
        SaveContain.SaveProgressSlider(IdModul, ProgressSlider.value);
    }
    public virtual void Load()
    {
        SaveSystem.Reservation SaveContain = SaveSystem.SaveContain;
        _levelUpgrade = SaveContain.LoadlLevelUpgrade(IdModul);
        ProgressSlider.value = SaveContain.LoadlProgressSlider(IdModul);
        _shipNumber = SaveContain.ShipNumber;
    }
}
