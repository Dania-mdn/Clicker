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
    private int i;
    public int ID;
    private string modul;
    public string[] stringmodul;
    private bool is_dostup = false;
    public virtual void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        PlayerPrefs.DeleteKey((ID / 10).ToString("0"));

        //добавление характеристик
        if (PlayerPrefs.HasKey("tap_income" + ID))
        {
            _valueUpgradeClick = PlayerPrefs.GetInt("tap_income" + ID);
            UpgradeClick.text = "+ " + _valueUpgradeClick.ToString("0") + "%";
        }
        else
        {
            _valueUpgradeClick = DefaultValueUpgradeClick;
            GameManager.tap_income = GameManager.tap_income + (_valueUpgradeClick * 0.01f);
            UpgradeClick.text = "+ " + _valueUpgradeClick.ToString("0") + "%";
        }

        if (PlayerPrefs.HasKey("pass_income" + ID))
        {
            _ValueUpgradePassive = PlayerPrefs.GetInt("pass_income" + ID);
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
        if (PlayerPrefs.HasKey("i" + ID + PlayerPrefs.GetInt("num_ship")))
        {
            i = PlayerPrefs.GetInt("i" + ID + PlayerPrefs.GetInt("num_ship"));
        }
        else
        {
            PlayerPrefs.SetInt("i" + ID + PlayerPrefs.GetInt("num_ship"), 0);
            i = 0;
        }
        //присвоение цен и параметров в зависимости от выбранного корабля
        if (PlayerPrefs.HasKey("num_ship"))
        {
            if (PlayerPrefs.GetInt("num_ship") == 0)
            {
                _price = GameManager.price_0;
                modul = stringmodul[0];
            }
            else if (PlayerPrefs.GetInt("num_ship") == 1)
            {
                _price = GameManager.price_1;
                modul = stringmodul[1];
            }
            else if (PlayerPrefs.GetInt("num_ship") == 2)
            {
                _price = GameManager.price_2;
                modul = stringmodul[2];
            }
            else if (PlayerPrefs.GetInt("num_ship") == 3)
            {
                _price = GameManager.price_3;
                modul = stringmodul[3];
            }
            else if (PlayerPrefs.GetInt("num_ship") == 4)
            {
                _price = GameManager.price_4;
                modul = stringmodul[4];
            }
            else if (PlayerPrefs.GetInt("num_ship") == 5)
            {
                _price = GameManager.price_5;
                modul = stringmodul[5];
            }
            else if (PlayerPrefs.GetInt("num_ship") == 6)
            {
                _price = GameManager.price_6;
                modul = stringmodul[6];
            }
        }
        else
        {
            _price = GameManager.price_0;
            modul = stringmodul[0];
        }

        if (i < _price.Length)
        {
            if (_price[i] < PlayerPrefs.GetFloat("Money_box"))
            {
                ButtonSprite.color = new Color(0f, 1f, 0.168f);
                PriceButton.text = _price[i].ToString("0");
                if (is_dostup == false)
                {
                    PlayerPrefs.SetInt((ID / 10).ToString("0"), PlayerPrefs.GetInt((ID / 10).ToString("0")) + 1);
                    is_dostup = true;
                }
            }
            else
            {
                ButtonSprite.color = new Color(1f, 1f, 1f);
                PriceButton.text = _price[i].ToString("0");
                if (is_dostup == true)
                {
                    PlayerPrefs.SetInt((ID / 10).ToString("0"), PlayerPrefs.GetInt((ID / 10).ToString("0")) - 1);
                    is_dostup = false;
                }
            }
        }
        else
        {
            ButtonSprite.color = new Color(1f, 1f, 1f);
            PriceButton.text = "MAX".ToString();
            UpgradeClick.text = "MAX".ToString();
            UpgradePassive.text = "MAX".ToString();
            if (is_dostup == true)
            {
                PlayerPrefs.SetInt((ID / 10).ToString("0"), PlayerPrefs.GetInt((ID / 10).ToString("0")) - 1);
                is_dostup = false;
            }
        }
        LevelUpgrade.text = "lvl " + PlayerPrefs.GetInt("i" + ID + PlayerPrefs.GetInt("num_ship")).ToString("0");
        if (PlayerPrefs.HasKey("slider" + ID + PlayerPrefs.GetInt("num_ship")))
        {
            ProgressSlider.value = PlayerPrefs.GetFloat("slider" + ID + PlayerPrefs.GetInt("num_ship"));
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
        if (i < _price.Length && _price[i] < PlayerPrefs.GetFloat("Money_box"))
        {
            _audioSource.Play();
            //забрать денег
            PlayerPrefs.SetFloat("Money_box", PlayerPrefs.GetFloat("Money_box") - _price[i]);
            //добавить характеристик

            //1
            _valueUpgradeClick = _valueUpgradeClick + DefaultValueUpgradeClick;
            GameManager.tap_income = GameManager.tap_income + (DefaultValueUpgradeClick * 0.01f);
            PlayerPrefs.SetInt("tap_income" + ID, _valueUpgradeClick);
            UpgradeClick.text = "+ " + _valueUpgradeClick.ToString("0") + "%";

            //1
            _ValueUpgradePassive = _ValueUpgradePassive + DefaultValueUpgradePassiv;
            GameManager.pass_income = GameManager.pass_income + (DefaultValueUpgradePassiv * 0.01f);
            PlayerPrefs.SetInt("pass_income" + ID, _ValueUpgradePassive);
            UpgradePassive.text = "+ " + _ValueUpgradePassive.ToString("0") + "%";

            //сохранить изменения
            PlayerPrefs.SetFloat("tap_income", GameManager.tap_income);
            PlayerPrefs.SetFloat("pass_income", GameManager.pass_income);
            //перейти на новый уровень цены
            i = i + 1;
            if (modul != null && i % 5 == 0)
            {
                int number;
                number = i / 5;
                PlayerPrefs.SetFloat("i_" + modul, 0);
                PlayerPrefs.SetInt(modul, number);
            }
            PlayerPrefs.SetInt("i" + ID + PlayerPrefs.GetInt("num_ship"), PlayerPrefs.GetInt("i" + ID + PlayerPrefs.GetInt("num_ship")) + 1);
            ProgressSlider.value = ProgressSlider.value + 0.2f;
            PlayerPrefs.SetFloat("slider" + ID + PlayerPrefs.GetInt("num_ship"), ProgressSlider.value);
        }
        if (i >= _price.Length)
        {
            if (ID == 21 || ID == 22 || ID == 14)
            {
                PlayerPrefs.SetInt("Unloc " + ID, 1);
            }
        }
    }
}
