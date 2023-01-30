using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GameManager : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public ParticleSystem cursor;
    public TextMeshProUGUI Money_box;
    public TextMeshProUGUI Money_sec;
    bool tap;
    public float tap_income;
    public float pass_income;
    public Slider slider;
    public float Max_ofline;
    float Maney_offline;
    float Maney_in_second;
    public float second_hour;
    public float tap_hour;
    public float all_Time;
    int coef_pass;
    int coef_tap;
    int coef_all;
    float promeg;
    public GameObject Fuel;
    float i_fuel;
    public Animation anim_Money;
    bool isparticle;
    public Manager_button MB;

    public int[] price_0;
    public int[] price_1;
    public int[] price_2;
    public int[] price_3;
    public int[] price_4;
    public int[] price_5;
    public int[] price_6;
    private void Start()
    {
        i_fuel = 1;
        //деньги накопившиеся офлайн
        DateTime LastSaveTime = Utils.GetDateTime(key: "lastSaveTime", DateTime.UtcNow);
        TimeSpan timePassed = DateTime.UtcNow - LastSaveTime;
        int secondPassed = (int)timePassed.TotalSeconds;
        Maney_offline = (pass_income + PlayerPrefs.GetFloat("Money_sec")) * secondPassed;
        if (Maney_offline > Max_ofline)
        {
            PlayerPrefs.SetFloat("Maney_offline", Max_ofline);
        }
        else
        {
            PlayerPrefs.SetFloat("Maney_offline", Maney_offline);
        }

        if (second_hour >= 0)
        {
            PlayerPrefs.SetFloat("second_hour", PlayerPrefs.GetFloat("second_hour") - secondPassed);
        }

        //щетчик для активного прироста Х2
        if (tap_hour >= 0)
        {
            PlayerPrefs.SetFloat("tap_hour", PlayerPrefs.GetFloat("tap_hour") - secondPassed);
        }


        //присвоение сохранений
        if (PlayerPrefs.HasKey("tap_income"))
        {
            tap_income = PlayerPrefs.GetFloat("tap_income");
            pass_income = PlayerPrefs.GetFloat("pass_income");
        }
        if (PlayerPrefs.HasKey("Max_ofline"))
        {
            Max_ofline = PlayerPrefs.GetFloat("Max_ofline");
        }
        else
        {
            Max_ofline = 1000;
        }
        if (PlayerPrefs.HasKey("Tap_maxValue"))
        {
            slider.maxValue = PlayerPrefs.GetFloat("Tap_maxValue");
        }
        else
        {
            slider.maxValue = 1;
        }

        if (PlayerPrefs.HasKey("second_hour"))
        {
            second_hour = PlayerPrefs.GetFloat("second_hour");
        }
        if (PlayerPrefs.HasKey("tap_hour"))
        {
            tap_hour = PlayerPrefs.GetFloat("tap_hour");
        }
        if (PlayerPrefs.HasKey("all_Time"))
        {
            tap_hour = PlayerPrefs.GetFloat("all_Time");
        }
    }
    void Update()
    {
        //работа с бензином
        Fuel.transform.localScale = new Vector3(i_fuel, i_fuel, Fuel.transform.localScale.z);

        //отображение денег
        if (PlayerPrefs.GetFloat("Money_box") < 1000)
        {
            Money_box.text = PlayerPrefs.GetFloat("Money_box").ToString("0");
        }
        else if(PlayerPrefs.GetFloat("Money_box") > 1000 && PlayerPrefs.GetFloat("Money_box") < 1000000)
        {
            Money_box.text = (PlayerPrefs.GetFloat("Money_box") / 1000).ToString("0.00") + "K";
        }
        else if (PlayerPrefs.GetFloat("Money_box") > 1000000)
        {
            Money_box.text = (PlayerPrefs.GetFloat("Money_box") / 1000000).ToString("0.00") + "M";
        }
        Money_sec.text = PlayerPrefs.GetFloat("Money_sec").ToString("0.0") + "/s";
        Utils.SetDateTime("lastSaveTime", System.DateTime.UtcNow);

        //работа с заработанными деньгами
        Maney_in_second = PlayerPrefs.GetFloat("Money_box") + ((pass_income + PlayerPrefs.GetFloat("Money_sec")) * coef_pass * coef_all) * Time.deltaTime;
        PlayerPrefs.SetFloat("Money_box", Maney_in_second);

        //работа с деньгами за тап
        if (tap == true && slider.value > 0.001f)
        {
            if (PlayerPrefs.GetFloat("Money_sec") < tap_income * coef_tap * coef_all * 2)
            {
                PlayerPrefs.SetFloat("Money_sec", (PlayerPrefs.GetFloat("Money_sec") * 1.02f));
            }
            slider.value = slider.value - 0.005f;

            //работа с курсором
            if(isparticle == true)
            {
                if (tap == true && slider.value > 0.1f)
                {
                    cursor.Play();
                    isparticle = false;
                }
                else
                {
                    cursor.Stop();
                }
            }
            cursor.transform.position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, cursor.transform.position.z);

            //бензин
            if (i_fuel < 1.3f)
            {
                i_fuel = i_fuel + 0.1f * Time.deltaTime;
            }
        }
        else
        {
            slider.value = slider.value + 0.01f;
            PlayerPrefs.SetFloat("Money_sec", tap_income * coef_tap * coef_all);

            //курсор
            cursor.Stop();
            isparticle = true;

            //бензин
            if (i_fuel > 1)
            {
                i_fuel = i_fuel - 0.4f * Time.deltaTime;
            }
        }

        //щетчик для пасивного прироста Х2
        if (second_hour >= 0)
        {
            PlayerPrefs.SetFloat("second_hour", second_hour);
            second_hour = second_hour - Time.deltaTime;
            coef_pass = 2;
        }
        else
        {
            PlayerPrefs.DeleteKey("second_hour");
            coef_pass = 1;
        }

        //щетчик для активного прироста Х2
        if (tap_hour >= 0)
        {
            PlayerPrefs.SetFloat("tap_hour", tap_hour);
            tap_hour = tap_hour - Time.deltaTime;
            coef_tap = 2;
        }
        else
        {
            PlayerPrefs.DeleteKey("tap_hour");
            coef_tap = 1;
        }

        //щетчик для всего прироста Х10
        if (all_Time >= 0)
        {
            PlayerPrefs.SetFloat("all_Time", all_Time);
            all_Time = all_Time - Time.deltaTime;
            coef_all = 10;
        }
        else
        {
            PlayerPrefs.DeleteKey("all_Time");
            coef_all = 1;
        }

        //пополнялка кэша
        if (promeg > 0)
        {
            anim_Money.Play();
            promeg = promeg - ((PlayerPrefs.GetFloat("Money_box") / 4) * Time.deltaTime);
            PlayerPrefs.SetFloat("Money_box", PlayerPrefs.GetFloat("Money_box") + ((PlayerPrefs.GetFloat("Money_box") / 4) * Time.deltaTime));
            Money_box.color = new Color(0.2622374f, 0.6698113f, 0.3052149f);
        }
        else
        {
            Money_box.color = new Color(0.3f, 0.3f, 0.3f);
        }
    }
    public void bank_x2()
    {
        promeg = promeg + PlayerPrefs.GetFloat("Maney_offline") * 2;
    }
    public void bank_x1()
    {
        promeg = promeg + PlayerPrefs.GetFloat("Maney_offline");
    }
    public void gift()
    {
        promeg = promeg + PlayerPrefs.GetFloat("Gift") * 2;
    }
    public void gift_free()
    {
        promeg = promeg + (PlayerPrefs.GetFloat("Gift"));
    }
    public void achivment(float i)
    {
        promeg = promeg + i;
    }
    public void OnPointerDown(PointerEventData pointerEventData)
    {
        MB.clous_all();
        tap = true;
        PlayerPrefs.SetInt("tap", 1);
    }
    public void OnPointerUp(PointerEventData pointerEventData)
    {
        tap = false;
        PlayerPrefs.DeleteKey("tap");
    }
    public void Delete_Save()
    {
        PlayerPrefs.DeleteAll();
    }
    public void add_manney()
    {
        PlayerPrefs.SetFloat("Money_box", PlayerPrefs.GetFloat("Money_box") + 100000);
    }
}
