using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Upgrate_bak : MonoBehaviour
{
    public Image sprite;
    public TextMeshProUGUI price_button;
    public TextMeshProUGUI lvl;
    public TextMeshProUGUI cistern;
    public Slider slider;
    public Slider maxValue_slider;
    public GameManager tap;
    AudioSource aud;
    private int[] price;
    public int b;
    private int ib;
    int i;
    public int ID;
    bool is_dostup = false;
    private void Start()
    {
        aud = GetComponent<AudioSource>();
        PlayerPrefs.DeleteKey((ID / 10).ToString("0"));
        //добавление характеристик
        if (PlayerPrefs.HasKey("Tap_maxValue"))
        {
            ib = PlayerPrefs.GetInt("Tap_maxValue");
            PlayerPrefs.SetFloat("Tap_maxValue", maxValue_slider.maxValue + (ib * 0.01f));
            cistern.text = "+ " + ib.ToString("0") + "%";
        }
        else
        {
            ib = b;
            maxValue_slider.maxValue = maxValue_slider.maxValue + (ib * 0.01f);
            cistern.text = "+ " + ib.ToString("0") + "%";
        }
    }
    private void Update()
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
                price = tap.price_0;
            }
            else if (PlayerPrefs.GetInt("num_ship") == 1)
            {
                price = tap.price_1;
            }
            else if (PlayerPrefs.GetInt("num_ship") == 2)
            {
                price = tap.price_2;
            }
            else if (PlayerPrefs.GetInt("num_ship") == 3)
            {
                price = tap.price_3;
            }
            else if (PlayerPrefs.GetInt("num_ship") == 4)
            {
                price = tap.price_4;
            }
            else if (PlayerPrefs.GetInt("num_ship") == 5)
            {
                price = tap.price_5;
            }
            else if (PlayerPrefs.GetInt("num_ship") == 6)
            {
                price = tap.price_6;
            }
        }
        else
        {
            price = tap.price_0;
        }

        if (i < price.Length)
        {
            if (price[i] < PlayerPrefs.GetFloat("Money_box"))
            {
                sprite.color = new Color(0f, 1f, 0.168f);
                price_button.text = price[i].ToString("0");
                cistern.text = "+" + b.ToString("0") + "%";
                if (is_dostup == false)
                {
                    PlayerPrefs.SetInt((ID / 10).ToString("0"), PlayerPrefs.GetInt((ID / 10).ToString("0")) + 1);
                    is_dostup = true;
                }
            }
            else
            {
                sprite.color = new Color(1f, 1f, 1f);
                price_button.text = price[i].ToString("0");
                if (is_dostup == true)
                {
                    PlayerPrefs.SetInt((ID / 10).ToString("0"), PlayerPrefs.GetInt((ID / 10).ToString("0")) - 1);
                    is_dostup = false;
                }
            }
        }
        else
        {
            sprite.color = new Color(1f, 1f, 1f);
            price_button.text = "MAX".ToString();
            cistern.text = "MAX".ToString();
            if (is_dostup == true)
            {
                PlayerPrefs.SetInt((ID / 10).ToString("0"), PlayerPrefs.GetInt((ID / 10).ToString("0")) - 1);
                is_dostup = false;
            }
        }
        lvl.text = "lvl " + PlayerPrefs.GetInt("i" + ID + PlayerPrefs.GetInt("num_ship")).ToString("0");
        if (PlayerPrefs.HasKey("slider" + ID + PlayerPrefs.GetInt("num_ship")))
        {
            slider.value = PlayerPrefs.GetFloat("slider" + ID + PlayerPrefs.GetInt("num_ship"));
            if (slider.value > 0.9)
            {
                slider.value = 0;
            }
        }
        else
        {
            slider.value = 0;
        }
    }
    public void income()
    {
        if (i < price.Length && price[i] < PlayerPrefs.GetFloat("Money_box"))
        {
            aud.Play();
            //забрать денег
            PlayerPrefs.SetFloat("Money_box", PlayerPrefs.GetFloat("Money_box") - price[i]);

            //добавить характеристик
            maxValue_slider.maxValue = maxValue_slider.maxValue - (0.01f * ib);
            ib = ib + b;
            maxValue_slider.maxValue = maxValue_slider.maxValue + (0.01f * ib);
            PlayerPrefs.SetFloat("maxValue", ib);
            cistern.text = "+ " + ib.ToString("0") + "%";

            //сохранить изменения
            PlayerPrefs.SetFloat("Tap_maxValue", maxValue_slider.maxValue);
            //перейти на новый уровень цены
            i = i + 1;
            PlayerPrefs.SetInt("i" + ID + PlayerPrefs.GetInt("num_ship"), PlayerPrefs.GetInt("i" + ID + PlayerPrefs.GetInt("num_ship")) + 1);
            slider.value = slider.value + 0.2f;
            PlayerPrefs.SetFloat("slider" + ID + PlayerPrefs.GetInt("num_ship"), slider.value);
        }
    }
}
