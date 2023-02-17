using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Upgrade: MonoBehaviour
{
    public SaveSystem SaveSystem;
    public Image ButtonSprite;
    public TextMeshProUGUI ButtonPrice;
    public TextMeshProUGUI LevelUpgrade;
    public TextMeshProUGUI UpgradeClick;
    public TextMeshProUGUI UpgradePassive;
    public Slider ProgressSlider;
    public int DefaultValueUpgradeClick;
    public int DefaultValueUpgradePassiv;
    public int IdModul;
    private Color _open = new Color(0f, 1f, 0.168f);
    private Color _close = new Color(1, 1, 1);
    private AudioSource _audioSource;
    private int[] _price;
    private int _valueUpgradeClick;
    private int _shipNumber;
    private int _ValueUpgradePassive;
    private int _levelUpgrade;
    private bool _available = false;
    public virtual void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        PlayerPrefs.DeleteKey((IdModul / 10).ToString("0"));

        if (SaveSystem.SaveContain.LoadlLevelUpgrade(IdModul) != 0)
            Load();
        else
            Save();

        //добавление характеристик
        MonneyHandler.singleton.ClickIncome = MonneyHandler.singleton.ClickIncome + (_valueUpgradeClick * 0.01f);
        UpgradeClick.text = $"+ {_valueUpgradeClick} %";

        MonneyHandler.singleton.PassiveIncome = MonneyHandler.singleton.PassiveIncome + (_ValueUpgradePassive * 0.01f);
        UpgradePassive.text = $"+ {_ValueUpgradePassive} %";
    }
    public void Update()
    {
        _price = MonneyHandler.singleton.PriceUpgrade[SaveSystem.SaveContain.ShipNumber];

        if (_levelUpgrade < _price.Length)
        {
            if (_price[_levelUpgrade] < MonneyHandler.singleton.MonneyCount)
            {
                ButtonSprite.color = _open;
                ButtonPrice.text = _price[_levelUpgrade].ToString("0");
                if (_available == false)
                {
                    PlayerPrefs.SetInt((IdModul / 10).ToString("0"), PlayerPrefs.GetInt((IdModul / 10).ToString("0")) + 1);
                    _available = true;
                }
            }
            else
            {
                ButtonSprite.color = _close;
                ButtonPrice.text = _price[_levelUpgrade].ToString("0");
                if (_available == true)
                {
                    PlayerPrefs.SetInt((IdModul / 10).ToString("0"), PlayerPrefs.GetInt((IdModul / 10).ToString("0")) - 1);
                    _available = false;
                }
            }
        }
        else
        {
            ButtonSprite.color = _close;
            ButtonPrice.text = "MAX".ToString();
            UpgradeClick.text = "MAX".ToString();
            UpgradePassive.text = "MAX".ToString();
            if (_available == true)
            {
                PlayerPrefs.SetInt((IdModul / 10).ToString("0"), PlayerPrefs.GetInt((IdModul / 10).ToString("0")) - 1);
                _available = false;
            }
        }
        LevelUpgrade.text = "lvl " + _levelUpgrade.ToString("0");
        if (ProgressSlider.value > 0.9)
        {
            ProgressSlider.value = 0;
        }

        if (_shipNumber != SaveSystem.SaveContain.ShipNumber)
        {
            Load();
            UpgradeImgeModule();
        }
    }
    public void ClickButton()
    {
        if(ButtonSprite.color == _open)
        {
            _audioSource.Play();
            //забрать денег
            MonneyHandler.singleton.TakeManey(_price[_levelUpgrade]);
            //добавить характеристик

            //1
            _valueUpgradeClick = _valueUpgradeClick + DefaultValueUpgradeClick;
            MonneyHandler.singleton.ClickIncome = MonneyHandler.singleton.ClickIncome + (DefaultValueUpgradeClick * 0.01f);
            UpgradeClick.text = "+ " + _valueUpgradeClick.ToString("0") + "%";

            //1
            _ValueUpgradePassive = _ValueUpgradePassive + DefaultValueUpgradePassiv;
            MonneyHandler.singleton.PassiveIncome = MonneyHandler.singleton.PassiveIncome + (DefaultValueUpgradePassiv * 0.01f);
            UpgradePassive.text = "+ " + _ValueUpgradePassive.ToString("0") + "%";

            //перейти на новый уровень цены
            _levelUpgrade = _levelUpgrade + 1;
            ProgressSlider.value = ProgressSlider.value + 0.2f;

            UpgradeImgeModule();
            Save();
        }
    }
    public void UpgradeImgeModule()
    {
        if (IdModul == ((int)Modul.Engine) || IdModul == ((int)Modul.Deckhouse) || IdModul == ((int)Modul.Сarcass))
        {
            PlayerPrefs.SetInt("Unloc " + IdModul, 1);
            Ship.singleton.ChangedSprite(IdModul, _levelUpgrade);
        }
    }
    public void Save()
    {
        SaveSystem.Reservation SaveContain = SaveSystem.SaveContain;
        SaveContain.SaveLevelUpgrade(IdModul, _levelUpgrade);
        SaveContain.SaveClickIncom(IdModul, _valueUpgradeClick);
        SaveContain.SavePassIncom(IdModul, _ValueUpgradePassive);
        SaveContain.SaveProgressSlider(IdModul, ProgressSlider.value);
    }
    public void Load()
    {
        SaveSystem.Reservation SaveContain = SaveSystem.SaveContain;
        _levelUpgrade = SaveContain.LoadlLevelUpgrade(IdModul);
        _valueUpgradeClick = SaveContain.LoadClickIncom(IdModul);
        _ValueUpgradePassive = SaveContain.LoadlPassIncom(IdModul);
        ProgressSlider.value = SaveContain.LoadlProgressSlider(IdModul);
        _shipNumber = SaveContain.ShipNumber;
    }
    enum Modul { Engine, Deckhouse, Сarcass }
}
