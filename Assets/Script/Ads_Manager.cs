using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;
using GoogleMobileAds.Common;
using System;
using GoogleMobileAds.Api;
using UnityEngine.UI;

public class Ads_Manager : MonoBehaviour
{
    float second_hour_1 = 6;
    float second_hour_2 = 7;
    float second_hour_3 = 8;
    float second_hour_4 = 9;
    public Image b1;
    public Image b2;
    public Image b3;
    public Image b4;
    public Image b5;
    public GameObject dabl_bank;
    public TextMeshProUGUI Money_offline;
    public TextMeshProUGUI Money_Gift;
    public TextMeshProUGUI Gift;
    public Animation dabl_pass;
    public Animation dabl_tap;
    public Animation gift;
    public Animation gift_free;
    public Animation X_10;
    public TextMeshProUGUI Time_Pass;
    public TextMeshProUGUI Time_Tap;
    public TextMeshProUGUI Time_All;
    public GameManager GameManager;

    //картинки для кнопок
    public Sprite[] sprite;
    public Image imj_pass;
    public Image imj_tap;
    public Image imj_all;

    bool isoffline;

    private int i;
    public GameObject pas;
    public GameObject tap;
    public GameObject transform_X_10;
    public GameObject transform_Gift_Free;
    public GameObject transform_Gift;
    private float second;
    public float second_on_Min;
    public float second_on_Max;
    public float second_off;
    private float second_off1;
    private float second_off2;
    private float second_off3;
    private int pos_ads;
    private bool ads1;
    private bool ads2;
    private bool ads3;
    private int ii;
    GameObject gg;
    AudioSource Audio;
    public int ads_dan = 0;
    public Ads_Manager ads_manager;
    public RewardedAd rewardedAd;
    //настоящий ca-app-pub-9999092264265801/7556372806
    //тест ca-app-pub-3940256099942544/5224354917
    private const string RewardedUnitID = "ca-app-pub-9999092264265801/7556372806";
    void Start()
    {

        i = 30;
        Audio = GetComponent<AudioSource>();
        isoffline = false;
        Money_Gift.text = (PlayerPrefs.GetFloat("Gift") * 2).ToString("0");
        Gift.text = PlayerPrefs.GetFloat("Gift").ToString("0");
        dabl_pass.Play();
        this.rewardedAd = new RewardedAd(RewardedUnitID);
        this.rewardedAd.OnAdClosed += HandleRewardedAdClosed;
        this.rewardedAd.OnUserEarnedReward += HandleUserEarnedReward;

        AdRequest Request = new AdRequest.Builder().Build();
        this.rewardedAd.LoadAd(Request);
    }
    public void aud_Play()
    {
        Audio.Play();
    }
    public void obnowa()
    {
        Money_Gift.text = (PlayerPrefs.GetFloat("Gift") * 2).ToString("0");
        Gift.text = PlayerPrefs.GetFloat("Gift").ToString("0");
    }
    private void Update()
    {
        //готовность кнопок
        if (rewardedAd.IsLoaded())
        {
            PlayerPrefs.SetInt("Reward", 1);
            b1.color = new Color(0f, 1f, 0.168f);
            b2.color = new Color(0f, 1f, 0.168f);
            b3.color = new Color(0f, 1f, 0.168f);
            b4.color = new Color(0f, 1f, 0.168f);
            b5.color = new Color(0f, 1f, 0.168f);
        }
        else
        {
            PlayerPrefs.DeleteKey("Reward");
            b1.color = new Color(1f, 1f, 1f);
            b2.color = new Color(1f, 1f, 1f);
            b3.color = new Color(1f, 1f, 1f);
            b4.color = new Color(1f, 1f, 1f);
            b5.color = new Color(1f, 1f, 1f);
        }
        //запуск удвоителя денег за офлайн
        if (PlayerPrefs.HasKey("Maney_offline") && isoffline == false && PlayerPrefs.GetFloat("Maney_offline") > 70)
        {
            dabl_bank.SetActive(true);
            Money_offline.text = "+" + PlayerPrefs.GetFloat("Maney_offline").ToString("0");
            isoffline = true;
        }
        //работа с картинками
        if (GameManager.second_hour >= 0)
        {
            imj_pass.sprite = sprite[1];
        }
        else
        {
            imj_pass.sprite = sprite[0];
        }
        if (GameManager.tap_hour >= 0)
        {
            imj_tap.sprite = sprite[3];
        }
        else
        {
            imj_tap.sprite = sprite[2];
        }
        if (GameManager.all_Time >= 0)
        {
            imj_all.sprite = sprite[5];
        }
        else
        {
            imj_all.sprite = sprite[4];
        }

        if(second >= 0)
        {
            second = second - Time.deltaTime;
        }
        else
        {
            second = UnityEngine.Random.Range(second_on_Min, second_on_Max);
            i = UnityEngine.Random.Range(0, 3);
            if (i != ii)
            {
                ii = i;
                if (i == 0)
                {
                    second_off1 = second_off;
                    transform_X_10.SetActive(true);
                }
                else if (i == 1)
                {
                    second_off2 = second_off;
                    transform_Gift_Free.SetActive(true);
                }
                else if (i == 2)
                {
                    second_off3 = second_off;
                    transform_Gift.SetActive(true);
                }
                pos_ads = pos_ads + 1;
            }
        }

        ///
        if (second_off1 < 0)
        {
            if (PlayerPrefs.HasKey("all_Time") == false)
            {
                transform_X_10.SetActive(false);
                if (ads1 == false)
                {
                    pos_ads = pos_ads - 1;
                    ads1 = true;
                }
            }
        }
        else if(second_off1 > 0)
        {
            ads1 = false;
            second_off1 = second_off1 - Time.deltaTime;
        }

        if (second_off2 < 0)
        {
            transform_Gift_Free.SetActive(false);
            if (ads2 == false)
            {
                pos_ads = pos_ads - 1;
                ads2 = true;
            }
        }
        else if (second_off2 > 0)
        {
            ads2 = false;
            second_off2 = second_off2 - Time.deltaTime;
        }

        if (second_off3 < 0)
        {
            transform_Gift.SetActive(false);
            if (ads3 == false)
            {
                pos_ads = pos_ads - 1;
                ads3 = true;
            }
        }
        else if (second_off3 > 0)
        {
            ads3 = false;
            second_off3 = second_off3 - Time.deltaTime;
        }

        /////
        if(transform_X_10.activeSelf == true)
        {
            if (pos_ads == 1)
            {
                if (transform_X_10.transform.position.y < pas.transform.position.y - 0.2)
                {
                    transform_X_10.transform.position = new Vector3(transform_X_10.transform.position.x, transform_X_10.transform.position.y + 5 * Time.deltaTime, transform_X_10.transform.position.z);
                }
            }
            if (pos_ads == 2)
            {
                if (transform_X_10.transform.position.y < tap.transform.position.y - 0.2)
                {
                    transform_X_10.transform.position = new Vector3(transform_X_10.transform.position.x, transform_X_10.transform.position.y + 5 * Time.deltaTime, transform_X_10.transform.position.z);
                }
            }
        }
        else
        {
            transform_X_10.transform.position = new Vector3(transform_X_10.transform.position.x, -6.5f, transform_X_10.transform.position.z);
        }
        if (transform_Gift_Free.activeSelf == true)
        {
            if (pos_ads == 1)
            {
                if (transform_Gift_Free.transform.position.y < pas.transform.position.y - 0.2)
                {
                    transform_Gift_Free.transform.position = new Vector3(transform_Gift_Free.transform.position.x, transform_Gift_Free.transform.position.y + 5 * Time.deltaTime, transform_Gift_Free.transform.position.z);
                }
            }
            if (pos_ads == 2)
            {
                if (transform_Gift_Free.transform.position.y < tap.transform.position.y - 0.2)
                {
                    transform_Gift_Free.transform.position = new Vector3(transform_Gift_Free.transform.position.x, transform_Gift_Free.transform.position.y + 5 * Time.deltaTime, transform_Gift_Free.transform.position.z);
                }
            }
        }
        else
        {
            transform_Gift_Free.transform.position = new Vector3(transform_Gift_Free.transform.position.x, -6.5f, transform_Gift_Free.transform.position.z);
        }
        if (transform_Gift.activeSelf == true)
        {
            if (pos_ads == 1)
            {
                if (transform_Gift.transform.position.y < pas.transform.position.y - 0.2)
                {
                    transform_Gift.transform.position = new Vector3(transform_Gift.transform.position.x, transform_Gift.transform.position.y + 5 * Time.deltaTime, transform_Gift.transform.position.z);
                }
            }
            if (pos_ads == 2)
            {
                if (transform_Gift.transform.position.y < tap.transform.position.y - 0.2)
                {
                    transform_Gift.transform.position = new Vector3(transform_Gift.transform.position.x, transform_Gift.transform.position.y + 5 * Time.deltaTime, transform_Gift.transform.position.z);
                }
            }
        }
        else
        {
            transform_Gift.transform.position = new Vector3(transform_Gift.transform.position.x, -6.5f, transform_Gift.transform.position.z);
        }
        //////////////////

        //щетчик для пасивного прироста Х2
        if (second_hour_1 >= 0)
        {
            second_hour_1 = second_hour_1 - Time.deltaTime;
        }
        else
        {
            if(PlayerPrefs.HasKey("second_hour") == false)
            {
                dabl_pass.Play();
            }
            second_hour_1 = 6;
        }
        
        //щетчик для активного прироста Х2
        if (second_hour_2 >= 0)
        {
            second_hour_2 = second_hour_2 - Time.deltaTime;
        }
        else
        {
            if (PlayerPrefs.HasKey("tap_hour") == false)
            {
                dabl_tap.Play();
            }
            second_hour_2 = 8;
        }

        //щетчик для подарок
        if (second_hour_3 >= 0)
        {
            second_hour_3 = second_hour_3 - Time.deltaTime;
        }
        else
        {
            if (PlayerPrefs.HasKey("all_Time") == false)
            {
                gift.Play();
            }
            second_hour_3 = 6;
        }

        //щетчик для всего дохода Х10
        if (second_hour_4 >= 0)
        {
            second_hour_4 = second_hour_4 - Time.deltaTime;
        }
        else
        {
            X_10.Play();
            second_hour_4 = 8;
        }

        //щетчик оставшегося времени для пасивного дохода
        if (PlayerPrefs.HasKey("second_hour"))
        {
            time(PlayerPrefs.GetFloat("second_hour"), Time_Pass);
            Time_Pass.enabled = true;
        }
        else
        {
            Time_Pass.enabled = false;
        }
        //щетчик оставшегося времени для дохода за тап
        if (PlayerPrefs.HasKey("tap_hour"))
        {
            time(PlayerPrefs.GetFloat("tap_hour"), Time_Tap);
            Time_Tap.enabled = true;
        }
        else
        {
            Time_Tap.enabled = false;
        }
        //щетчик оставшегося времени для дохода за все
        if (PlayerPrefs.HasKey("all_Time"))
        {
            time(PlayerPrefs.GetFloat("all_Time"), Time_All);
            Time_All.enabled = true;
        }
        else
        {
            Time_All.enabled = false;
        }
    }
    //отображение времени
    private void time(float i, TextMeshProUGUI text)
    {
        if (Mathf.Floor(i / 3600) >= 1)
        {
            text.text = (Mathf.Floor(i / 3600)) + ":" + (Mathf.Floor((i - ((Mathf.FloorToInt(i / 3600)) * 3600)) / 60)) + ":" + (i % 60).ToString("00");
        }
        else
        {
            text.text = (Mathf.Floor(i / 3600)) + ":" + (Mathf.Floor(i / 60)) + ":" + (i % 60).ToString("00");
        }
    }
    public void ShowAd()
    {
        if (this.rewardedAd.IsLoaded())
        {
            this.rewardedAd.Show();
        }
    }
    public void HandleUserEarnedReward(object sender, Reward args)
    {
        if (ads_dan == 1)
        {
            GameManager.bank_x2();
            ads_dan = 0;
            gg.SetActive(false);
        }
        if (ads_dan == 2)
        {
            PlayerPrefs.SetInt("adss_pass", 1);
            GameManager.second_hour = GameManager.second_hour + 3600;
            gg.SetActive(false);
            ads_dan = 0;
        }
        if (ads_dan == 3)
        {
            PlayerPrefs.SetInt("adss_tap", 1);
            GameManager.tap_hour = GameManager.tap_hour + 3600;
            gg.SetActive(false);
            ads_dan = 0;
        }
        if (ads_dan == 4)
        {
            PlayerPrefs.SetInt("adss_Gift", 1);
            GameManager.gift();
            gg.SetActive(false);
            ads_dan = 0;
        }
        if (ads_dan == 5)
        {
            PlayerPrefs.SetInt("adss_x10", 1);
            GameManager.all_Time = 10;
            gg.SetActive(false);
            ads_dan = 0;
        }
    }
    private void HandleRewardedAdClosed(object sender, EventArgs e)
    {
        AdRequest Request = new AdRequest.Builder().Build();
        this.rewardedAd.LoadAd(Request);
    }
    public void bank_x2(GameObject g)
    {
        ShowAd();
        ads_dan = 1;
        gg = g;
    }
    public void adss_pass(GameObject g)
    {
        ShowAd();
        ads_dan = 2;
        gg = g;
    }
    public void adss_tap(GameObject g)
    {
        ShowAd();
        ads_dan = 3;
        gg = g;
    }
    public void adss_Gift(GameObject g)
    {
        ShowAd();
        ads_dan = 4;
        gg = g;
    }
    public void adss_X10(GameObject g)
    {
        ShowAd();
        ads_dan = 5;
        gg = g;
    }
    public void GGift(GameObject g)
    {
        aud_Play();
        PlayerPrefs.SetInt("Gift1", 1);
        GameManager.gift_free();
        g.SetActive(false);
    }
}
