using UnityEngine;
using UnityEngine.UI;
using TMPro;

public abstract class Upgrade: MonoBehaviour
{
    public Image ButtonSprite;
    public TextMeshProUGUI PriceButton;
    public TextMeshProUGUI LevelUpgrade;
    public TextMeshProUGUI UpgradeClick;
    public TextMeshProUGUI UpgradePassive;
    public Slider ProgressSlider;
    public GameManager GameManager;
    private AudioSource _audioSource;
    private int[] _price;
    public int DefaultValueUpgradeClick;
    private int _valueUpgradeClick;
    public int DefaultValueUpgradePassiv;
    private int _ValueUpgradePassive;
    private int _numberShip;
    public int IdModul;
    private string _modul;
    public string[] stringmodul;
    private bool _available = false;
    //public string ttt;
    public virtual void Start()
    {
        //ttt = SaveAndLoad.Singleton.item.name;

        _audioSource = GetComponent<AudioSource>();
        PlayerPrefs.DeleteKey((IdModul / 10).ToString("0"));

        //добавление характеристик
        if (PlayerPrefs.HasKey("tap_income" + IdModul))
        {
            _valueUpgradeClick = PlayerPrefs.GetInt("tap_income" + IdModul);
            UpgradeClick.text = "+ " + _valueUpgradeClick.ToString("0") + "%";
        }
        else
        {
            _valueUpgradeClick = DefaultValueUpgradeClick;
            GameManager.tap_income = GameManager.tap_income + (_valueUpgradeClick * 0.01f);
            UpgradeClick.text = "+ " + _valueUpgradeClick.ToString("0") + "%";
        }

        if (PlayerPrefs.HasKey("pass_income" + IdModul))
        {
            _ValueUpgradePassive = PlayerPrefs.GetInt("pass_income" + IdModul);
            UpgradePassive.text = "+ " + _ValueUpgradePassive.ToString("0") + "%";
        }
        else
        {
            _ValueUpgradePassive = DefaultValueUpgradePassiv;
            GameManager.pass_income = GameManager.pass_income + (_ValueUpgradePassive * 0.01f);
            UpgradePassive.text = "+ " + _ValueUpgradePassive.ToString("0") + "%";
        }
    }
    public virtual void Update()
    {
        //добавление i
        if (PlayerPrefs.HasKey("i" + IdModul + PlayerPrefs.GetInt("num_ship")))
        {
            _numberShip = PlayerPrefs.GetInt("i" + IdModul + PlayerPrefs.GetInt("num_ship"));
        }
        else
        {
            PlayerPrefs.SetInt("i" + IdModul + PlayerPrefs.GetInt("num_ship"), 0);
            _numberShip = 0;
        }
        //присвоение цен и параметров в зависимости от выбранного корабля
        if (PlayerPrefs.HasKey("num_ship"))
        {
            if (PlayerPrefs.GetInt("num_ship") == 0)
            {
                _price = GameManager.price_0;
                _modul = stringmodul[0];
            }
            else if (PlayerPrefs.GetInt("num_ship") == 1)
            {
                _price = GameManager.price_1;
                _modul = stringmodul[1];
            }
            else if (PlayerPrefs.GetInt("num_ship") == 2)
            {
                _price = GameManager.price_2;
                _modul = stringmodul[2];
            }
            else if (PlayerPrefs.GetInt("num_ship") == 3)
            {
                _price = GameManager.price_3;
                _modul = stringmodul[3];
            }
            else if (PlayerPrefs.GetInt("num_ship") == 4)
            {
                _price = GameManager.price_4;
                _modul = stringmodul[4];
            }
            else if (PlayerPrefs.GetInt("num_ship") == 5)
            {
                _price = GameManager.price_5;
                _modul = stringmodul[5];
            }
            else if (PlayerPrefs.GetInt("num_ship") == 6)
            {
                _price = GameManager.price_6;
                _modul = stringmodul[6];
            }
        }
        else
        {
            _price = GameManager.price_0;
            _modul = stringmodul[0];
        }

        if (_numberShip < _price.Length)
        {
            if (_price[_numberShip] < PlayerPrefs.GetFloat("Money_box"))
            {
                ButtonSprite.color = new Color(0f, 1f, 0.168f);
                PriceButton.text = _price[_numberShip].ToString("0");
                if (_available == false)
                {
                    PlayerPrefs.SetInt((IdModul / 10).ToString("0"), PlayerPrefs.GetInt((IdModul / 10).ToString("0")) + 1);
                    _available = true;
                }
            }
            else
            {
                ButtonSprite.color = new Color(1f, 1f, 1f);
                PriceButton.text = _price[_numberShip].ToString("0");
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
            PriceButton.text = "MAX".ToString();
            UpgradeClick.text = "MAX".ToString();
            UpgradePassive.text = "MAX".ToString();
            if (_available == true)
            {
                PlayerPrefs.SetInt((IdModul / 10).ToString("0"), PlayerPrefs.GetInt((IdModul / 10).ToString("0")) - 1);
                _available = false;
            }
        }
        LevelUpgrade.text = "lvl " + PlayerPrefs.GetInt("i" + IdModul + PlayerPrefs.GetInt("num_ship")).ToString("0");
        if (PlayerPrefs.HasKey("slider" + IdModul + PlayerPrefs.GetInt("num_ship")))
        {
            ProgressSlider.value = PlayerPrefs.GetFloat("slider" + IdModul + PlayerPrefs.GetInt("num_ship"));
            if (ProgressSlider.value > 0.9)
            {
                ProgressSlider.value = 0;
            }
        }
        else
        {
            ProgressSlider.value = 0;
        }
    }
    public virtual void income()
    {
        //SaveAndLoad.Singleton.item.name = ttt;
        SaveAndLoad.Singleton.SaveField();
        if (_numberShip < _price.Length && _price[_numberShip] < PlayerPrefs.GetFloat("Money_box"))
        {
            _audioSource.Play();
            //забрать денег
            PlayerPrefs.SetFloat("Money_box", PlayerPrefs.GetFloat("Money_box") - _price[_numberShip]);
            //добавить характеристик

            //1
            _valueUpgradeClick = _valueUpgradeClick + DefaultValueUpgradeClick;
            GameManager.tap_income = GameManager.tap_income + (DefaultValueUpgradeClick * 0.01f);
            PlayerPrefs.SetInt("tap_income" + IdModul, _valueUpgradeClick);
            UpgradeClick.text = "+ " + _valueUpgradeClick.ToString("0") + "%";

            //1
            _ValueUpgradePassive = _ValueUpgradePassive + DefaultValueUpgradePassiv;
            GameManager.pass_income = GameManager.pass_income + (DefaultValueUpgradePassiv * 0.01f);
            PlayerPrefs.SetInt("pass_income" + IdModul, _ValueUpgradePassive);
            UpgradePassive.text = "+ " + _ValueUpgradePassive.ToString("0") + "%";

            //сохранить изменения
            PlayerPrefs.SetFloat("tap_income", GameManager.tap_income);
            PlayerPrefs.SetFloat("pass_income", GameManager.pass_income);
            //перейти на новый уровень цены
            _numberShip = _numberShip + 1;
            if (_modul != null && _numberShip % 5 == 0)
            {
                int number;
                number = _numberShip / 5;
                PlayerPrefs.SetFloat("i_" + _modul, 0);
                PlayerPrefs.SetInt(_modul, number);
            }
            PlayerPrefs.SetInt("i" + IdModul + PlayerPrefs.GetInt("num_ship"), PlayerPrefs.GetInt("i" + IdModul + PlayerPrefs.GetInt("num_ship")) + 1);
            ProgressSlider.value = ProgressSlider.value + 0.2f;
            PlayerPrefs.SetFloat("slider" + IdModul + PlayerPrefs.GetInt("num_ship"), ProgressSlider.value);
        }
        if (_numberShip >= _price.Length)
        {
            if (IdModul == 21 || IdModul == 22 || IdModul == 14)
            {
                PlayerPrefs.SetInt("Unloc " + IdModul, 1);
            }
        }
    }
}
