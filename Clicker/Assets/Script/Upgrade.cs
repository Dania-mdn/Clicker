using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Upgrade: MonoBehaviour
{
    public Image ButtonSprite;
    public TextMeshProUGUI ButtonPrice;
    public TextMeshProUGUI LevelUpgrade;
    public TextMeshProUGUI UpgradeClick;
    public TextMeshProUGUI UpgradePassive;
    public Slider ProgressSlider;
    private AudioSource _audioSource;
    private int[] _price;
    public int DefaultValueUpgradeClick;
    private int _valueUpgradeClick;
    public int DefaultValueUpgradePassiv;
    private int _ValueUpgradePassive;
    private int _levelUpgrade;
    public int IdModul;
    //private string _modul;
    //public string[] stringmodul;
    private bool _available = false;
    public SaveSystem SaveSystem;
    public virtual void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        PlayerPrefs.DeleteKey((IdModul / 10).ToString("0"));

        //SaveSystem = SaveSystem.singleton;
        if (SaveSystem.SaveContain.LevelUpgrade[IdModul] != 0)
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
        //присвоение цен и параметров в зависимости от выбранного корабля
        //_modul = stringmodul[SaveSystem._shipNumber];
        if (SaveSystem.SaveContain._shipNumber == 0)
        {
            _price = MonneyHandler.singleton.price_0;
        }
        else if (SaveSystem.SaveContain._shipNumber == 1)
        {
            _price = MonneyHandler.singleton.price_1;
        }
        else if (SaveSystem.SaveContain._shipNumber == 2)
        {
            _price = MonneyHandler.singleton.price_2;
        }
        else if (SaveSystem.SaveContain._shipNumber == 3)
        {
            _price = MonneyHandler.singleton.price_3;
        }
        else if (SaveSystem.SaveContain._shipNumber == 4)
        {
            _price = MonneyHandler.singleton.price_4;
        }
        else if (SaveSystem.SaveContain._shipNumber == 5)
        {
            _price = MonneyHandler.singleton.price_5;
        }
        else if (SaveSystem.SaveContain._shipNumber == 6)
        {
            _price = MonneyHandler.singleton.price_6;
        }

        if (_levelUpgrade < _price.Length)
        {
            if (_price[_levelUpgrade] < PlayerPrefs.GetFloat("Money_box"))
            {
                ButtonSprite.color = new Color(0f, 1f, 0.168f);
                ButtonPrice.text = _price[_levelUpgrade].ToString("0");
                if (_available == false)
                {
                    PlayerPrefs.SetInt((IdModul / 10).ToString("0"), PlayerPrefs.GetInt((IdModul / 10).ToString("0")) + 1);
                    _available = true;
                }
            }
            else
            {
                ButtonSprite.color = new Color(1f, 1f, 1f);
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
            ButtonSprite.color = new Color(1f, 1f, 1f);
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
    }
    public void ClickButton()
    {
        if (_levelUpgrade < _price.Length && _price[_levelUpgrade] < PlayerPrefs.GetFloat("Money_box"))
        {
            _audioSource.Play();
            //забрать денег
            //GameManager.takeManey();
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
        }
        if (_levelUpgrade >= _price.Length)
        {
            if (IdModul == 1 || IdModul == 6 || IdModul == 7)
            {
                PlayerPrefs.SetInt("Unloc " + IdModul, 1);
            }
        }

        Save();
    }
    public void Load()
    {
        SaveSystem.Reservation SaveContain = SaveSystem.SaveContain;
        _valueUpgradeClick = SaveContain.ClickIncom[IdModul];
        _ValueUpgradePassive = SaveContain.PassIncom[IdModul];
        _levelUpgrade = SaveContain.LevelUpgrade[IdModul];
        ProgressSlider.value = SaveContain.ProgressSlider[IdModul];
    }
    public void Save()
    {
        SaveSystem.Reservation SaveContain = SaveSystem.SaveContain;
        SaveContain.ClickIncom[IdModul] = _valueUpgradeClick;
        SaveContain.PassIncom[IdModul] = _ValueUpgradePassive;
        SaveContain.LevelUpgrade[IdModul] = _levelUpgrade;
        SaveContain.ProgressSlider[IdModul] = ProgressSlider.value;
    }
}
