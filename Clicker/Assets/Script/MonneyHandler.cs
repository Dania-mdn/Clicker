using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System;

public class MonneyHandler : MonoBehaviour
{
    public static MonneyHandler singleton;
    public GameManager GameManager;
    public TextMeshProUGUI MonneyCount;
    public TextMeshProUGUI MoneyInSec;
    public float ClickIncome;
    public float PassiveIncome;
    public float MaxMonneyOfline;
    private float _maneyOffline;
    private float _maneyInSecond;
    public float tap_hour;
    public float second_hour;
    public float all_Time;
    private int coef_pass;
    private int coef_tap;
    private int coef_all;
    private float promeg;
    public Animation anim_Money;

    //public int[][] PriceShip;
    public int[] price_0;
    public int[] price_1;
    public int[] price_2;
    public int[] price_3;
    public int[] price_4;
    public int[] price_5;
    public int[] price_6;
    private void Awake()
    {
        singleton = this;
    }
    private void Start()
    {
        //for(int i = 0; i < 7; i++)
        //{
        //    PriceShip[i] = price_i;
        //}
        //деньги накопившиеся офлайн
        DateTime LastSaveTime = DateAndTime.GetDateTime(key: "lastSaveTime", DateTime.UtcNow);
        TimeSpan timePassed = DateTime.UtcNow - LastSaveTime;
        int secondPassed = (int)timePassed.TotalSeconds;
        _maneyOffline = (PassiveIncome + PlayerPrefs.GetFloat("Money_sec")) * secondPassed;
        if (_maneyOffline > MaxMonneyOfline)
        {
            PlayerPrefs.SetFloat("Maney_offline", MaxMonneyOfline);
        }
        else
        {
            PlayerPrefs.SetFloat("Maney_offline", _maneyOffline);
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
            ClickIncome = PlayerPrefs.GetFloat("tap_income");
            PassiveIncome = PlayerPrefs.GetFloat("pass_income");
        }
        if (PlayerPrefs.HasKey("Max_ofline"))
        {
            MaxMonneyOfline = PlayerPrefs.GetFloat("Max_ofline");
        }
        else
        {
            MaxMonneyOfline = 1000;
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
        //отображение денег
        if (PlayerPrefs.GetFloat("Money_box") < 1000)
        {
            MonneyCount.text = PlayerPrefs.GetFloat("Money_box").ToString("0");
        }
        else if (PlayerPrefs.GetFloat("Money_box") > 1000 && PlayerPrefs.GetFloat("Money_box") < 1000000)
        {
            MonneyCount.text = (PlayerPrefs.GetFloat("Money_box") / 1000).ToString("0.00") + "K";
        }
        else if (PlayerPrefs.GetFloat("Money_box") > 1000000)
        {
            MonneyCount.text = (PlayerPrefs.GetFloat("Money_box") / 1000000).ToString("0.00") + "M";
        }
        MoneyInSec.text = PlayerPrefs.GetFloat("Money_sec").ToString("0.0") + "/s";
        DateAndTime.SetDateTime("lastSaveTime", System.DateTime.UtcNow);

        //работа с заработанными деньгами
        _maneyInSecond = PlayerPrefs.GetFloat("Money_box") + ((PassiveIncome + PlayerPrefs.GetFloat("Money_sec")) * coef_pass * coef_all) * Time.deltaTime;
        PlayerPrefs.SetFloat("Money_box", _maneyInSecond);

        //работа с деньгами за тап
        if (GameManager._isPointerDown == true && GameManager.FuelProgressSlider.value > 0.001f)
        {
            if (PlayerPrefs.GetFloat("Money_sec") < ClickIncome * coef_tap * coef_all * 2)
            {
                PlayerPrefs.SetFloat("Money_sec", (PlayerPrefs.GetFloat("Money_sec") * 1.02f));
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
            MonneyCount.color = new Color(0.2622374f, 0.6698113f, 0.3052149f);
        }
        else
        {
            MonneyCount.color = new Color(0.3f, 0.3f, 0.3f);
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
    public void add_manney()
    {
        PlayerPrefs.SetFloat("Money_box", PlayerPrefs.GetFloat("Money_box") + 100000);
    }
}
