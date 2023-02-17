using System;
using UnityEngine;
using TMPro;

public class MonneyHandler : MonoBehaviour
{
    public static MonneyHandler singleton;
    public Animation MoneyAnimation;
    public SaveSystem SaveSystem;
    public GameManager GameManager;
    public float ClickIncome;
    public float PassiveIncome;
    public TextMeshProUGUI TextMonneyCount;
    public TextMeshProUGUI TextMoneyInSecond;
    public float MonneyCount { get; private set; }
    private float _maneyInSecond = 0.1f;
    private float _maxMonneyOfline = 1000;
    private float _maneyOffline;
    private int _coefPassiv;
    private int _coefClick;
    private int _coefAll;
    private float _intermediateValue;

    public int[] price0;
    public int[] price1;
    public int[] price2;
    public int[] price3;
    public int[] price4;
    public int[] price5;
    public int[] price6;
    public int[][] PriceUpgrade;
    private void Awake()
    {
        singleton = this;
    }
    private void Start()
    {
        PriceUpgrade = new int[7][];
        PriceUpgrade[0] = price0;
        PriceUpgrade[1] = price1;
        PriceUpgrade[2] = price2;
        PriceUpgrade[3] = price3;
        PriceUpgrade[4] = price4;
        PriceUpgrade[5] = price5;
        PriceUpgrade[6] = price6;

        if (SaveSystem.SaveContain.MonneyCount != 0)
            Load();
        else
            Save();

        _maneyOffline = GetManneyOffline();
        if (_maneyOffline > _maxMonneyOfline)
        {
            _maneyOffline = _maxMonneyOfline;
        }
    }
    private void Update()
    {
        MonneyCount = MonneyCount + PassiveIncome + _maneyInSecond * _coefPassiv * _coefAll;

        if (MonneyCount < 1000)
            TextMonneyCount.text = MonneyCount.ToString("0");
        else if (MonneyCount > 1000 && MonneyCount < 1000000)
            TextMonneyCount.text = (MonneyCount / 1000).ToString("0.00") + "K";
        else if (MonneyCount > 1000000)
            TextMonneyCount.text = (MonneyCount / 1000000).ToString("0.00") + "M";

        if (GameManager._isPointerDown == true && GameManager.FuelProgressSlider.value > 0)
        {
            if (_maneyInSecond < ClickIncome * _coefClick * _coefAll * 2)
                _maneyInSecond = _maneyInSecond * 1.02f;
        }
        else
        {
            _maneyInSecond = ClickIncome;
        }

        TextMoneyInSecond.text = _maneyInSecond.ToString("0.0") + "/s";

        if (_intermediateValue > 0)
        {
            MoneyAnimation.Play();
            _intermediateValue = _intermediateValue - MonneyCount / 4;
            TextMonneyCount.color = new Color(0.2622374f, 0.6698113f, 0.3052149f);
        }
        else
        {
            TextMonneyCount.color = new Color(0.3f, 0.3f, 0.3f);
        }
    }
    public void TakeManey(int value)
    {
        MonneyCount = MonneyCount - value;
    }
    public void bank_x2()
    {
        _intermediateValue = _intermediateValue + _maneyOffline * 2;
    }
    public void bank_x1()
    {
        _intermediateValue = _intermediateValue + _maneyOffline;
    }
    public void gift()
    {
        _intermediateValue = _intermediateValue + PlayerPrefs.GetFloat("Gift") * 2;
    }
    public void gift_free()
    {
        _intermediateValue = _intermediateValue + (PlayerPrefs.GetFloat("Gift"));
    }
    public void achivment(float i)
    {
        _intermediateValue = _intermediateValue + i;
    }
    public void Load()
    {
        SaveSystem.Reservation SaveContain = SaveSystem.SaveContain;
        MonneyCount = SaveContain.MonneyCount;
        _maneyInSecond = SaveContain.ManeyInSecond;
        _maxMonneyOfline = SaveContain.MaxMonneyOfline;
    }
    public void Save()
    {
        SaveSystem.Reservation SaveContain = SaveSystem.SaveContain;
        SaveContain.MonneyCount = MonneyCount;
        SaveContain.ManeyInSecond = _maneyInSecond;
        SaveContain.MaxMonneyOfline = _maxMonneyOfline;
    }
    private float GetManneyOffline()
    {
        DateTime LastSaveTime = DateAndTime.GetDateTime(key: "lastSaveTime", DateTime.UtcNow);
        TimeSpan timePassed = DateTime.UtcNow - LastSaveTime;
        int secondPassed = (int)timePassed.TotalSeconds;
        return _maneyOffline = (PassiveIncome + PlayerPrefs.GetFloat("Money_sec")) * secondPassed;
    }
    public void AddMonney() => MonneyCount = MonneyCount + 100000;
}
