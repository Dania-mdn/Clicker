using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Upgrade : MonoBehaviour
{
    public Image sprite;
    public TextMeshProUGUI price_button;
    public TextMeshProUGUI lvl;
    public TextMeshProUGUI tap_incom;
    public TextMeshProUGUI pass_incom;
    public Slider slider;
    public GameManager tap;
    AudioSource aud;
    private int[] price;
    public int t;
    int it;
    public int p;
    int ip;
    int i;
    public int ID;
    private string modul;
    public string[] stringmodul;
    bool is_dostup = false;
    private void Start()
    {
        aud = GetComponent<AudioSource>();
        PlayerPrefs.DeleteKey((ID / 10).ToString("0"));
        //добавление характеристик
        if (PlayerPrefs.HasKey("tap_income" + ID))
        {
            it = PlayerPrefs.GetInt("tap_income" + ID);
            tap_incom.text = "+ " + it.ToString("0") + "%";
        }
        else
        {
            it = t;
            tap.tap_income = tap.tap_income + (it * 0.01f);
            tap_incom.text = "+ " + it.ToString("0") + "%";
        }

        if (PlayerPrefs.HasKey("pass_income" + ID))
        {
            ip = PlayerPrefs.GetInt("pass_income" + ID);
            pass_incom.text = "+ " + ip.ToString("0") + "%";
        }
        else
        {
            ip = p;
            tap.pass_income = tap.pass_income + (ip * 0.01f);
            pass_incom.text = "+ " + ip.ToString("0") + "%";
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
                modul = stringmodul[0];
            }
            else if (PlayerPrefs.GetInt("num_ship") == 1)
            {
                price = tap.price_1;
                modul = stringmodul[1];
            }
            else if (PlayerPrefs.GetInt("num_ship") == 2)
            {
                price = tap.price_2;
                modul = stringmodul[2];
            }
            else if (PlayerPrefs.GetInt("num_ship") == 3)
            {
                price = tap.price_3;
                modul = stringmodul[3];
            }
            else if (PlayerPrefs.GetInt("num_ship") == 4)
            {
                price = tap.price_4;
                modul = stringmodul[4];
            }
            else if (PlayerPrefs.GetInt("num_ship") == 5)
            {
                price = tap.price_5;
                modul = stringmodul[5];
            }
            else if (PlayerPrefs.GetInt("num_ship") == 6)
            {
                price = tap.price_6;
                modul = stringmodul[6];
            }
        }
        else
        {
            price = tap.price_0;
            modul = stringmodul[0];
        }

        if (i < price.Length)
        {
            if (price[i] < PlayerPrefs.GetFloat("Money_box"))
            {
                sprite.color = new Color(0f, 1f, 0.168f);
                price_button.text = price[i].ToString("0");
                if(is_dostup == false)
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
            tap_incom.text = "MAX".ToString();
            pass_incom.text = "MAX".ToString();
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

            //1
            it = it + t;
            tap.tap_income = tap.tap_income + (t * 0.01f);
            PlayerPrefs.SetInt("tap_income" + ID, it);
            tap_incom.text = "+ " + it.ToString("0") + "%";

            //1
            ip = ip + p;
            tap.pass_income = tap.pass_income + (p * 0.01f);
            PlayerPrefs.SetInt("pass_income" + ID, ip);
            pass_incom.text = "+ " + ip.ToString("0") + "%";

            //сохранить изменения
            PlayerPrefs.SetFloat("tap_income", tap.tap_income);
            PlayerPrefs.SetFloat("pass_income", tap.pass_income);
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
            slider.value = slider.value + 0.2f;
            PlayerPrefs.SetFloat("slider" + ID + PlayerPrefs.GetInt("num_ship"), slider.value);
        }
        if (i >= price.Length)
        {
            if (ID == 21 || ID == 22 || ID == 14)
            {
                PlayerPrefs.SetInt("Unloc " + ID, 1);
            }
        }
    }
}
