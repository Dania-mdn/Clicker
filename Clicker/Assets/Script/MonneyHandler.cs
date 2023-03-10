using System;
using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class MonneyHandler : MonoBehaviour
{
    public static MonneyHandler singleton;
    public Animation MoneyAnimation;
    public SaveSystem SaveSystem;
    public PointerHandler PointerHandler;
    public float ClickIncome;
    public float PassiveIncome;
    public TextMeshProUGUI TextMonneyCount;
    public TextMeshProUGUI TextMoneyInSecond;
    public Action[] TakeRewardArrey;
    public float MonneyCount { get; private set; }
    public float MaxMonneyOfline;
    public int PrizeMonney;
    private float _maneyInSecond = 0.1f;
    public float MonneyOffline;
    private float _intermediateValue;
    Color _defoltMonneyColor = new Color(0.3f, 0.3f, 0.3f);
    private Color _addMonneyColor = new Color(0.2622374f, 0.6698113f, 0.3052149f);
    public RewardContain[] RewardContain = new RewardContain[3];
    public RewardContain DoubleForClik;
    public RewardContain DoubleForPassiwe;
    public RewardContain AllInkomeX10;

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
        TakeRewardArrey = new Action[] { TakeMonneyOffline, TakedoubleMonneyOffline, TakedoubleForClik, TakedoubleForPassiwe, TakeAllInkomeX10, TakeGift, TakerewardGift };

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

        MonneyOffline = GetManneyOffline();
        if (MonneyOffline > MaxMonneyOfline)
        {
            MonneyOffline = MaxMonneyOfline;
        }

        RewardContain[0] = new RewardContain(AdsManager.RewardName.doubleForClik);
        RewardContain[1] = new RewardContain(AdsManager.RewardName.doubleForPassiwe);
        RewardContain[2] = new RewardContain(AdsManager.RewardName.AllInkomeX10);
    }
    private void Update()
    {
        MonneyCount = MonneyCount + PassiveIncome + _maneyInSecond * RewardContain[1]._rewardCoeficient * RewardContain[2]._rewardCoeficient;
        ViewMonney();

        if (PointerHandler._isPointerDown == true && PointerHandler.FuelProgressSlider.value > 0)
        {
            if (_maneyInSecond < ClickIncome * RewardContain[0]._rewardCoeficient * 2)
                _maneyInSecond = _maneyInSecond * 1.02f;
        }
        else
        {
            _maneyInSecond = ClickIncome;
        }

        if (_intermediateValue > 0)
        {
            MoneyAnimation.Play();
            _intermediateValue = _intermediateValue - MonneyCount / 4;
            TextMonneyCount.color = _addMonneyColor;
        }
        else
        {
            TextMonneyCount.color = _defoltMonneyColor;
        }

        Timer(RewardContain[0]);
        Timer(RewardContain[1]);
        Timer(RewardContain[2], 10);

    }
    private void ViewMonney()
    {
        if (MonneyCount < 1000)
            TextMonneyCount.text = MonneyCount.ToString("0");
        else if (MonneyCount > 1000 && MonneyCount < 1000000)
            TextMonneyCount.text = (MonneyCount / 1000).ToString("0.00") + "K";
        else if (MonneyCount > 1000000)
            TextMonneyCount.text = (MonneyCount / 1000000).ToString("0.00") + "M";

        TextMoneyInSecond.text = _maneyInSecond.ToString("0.0") + "/s";
    }

    private void Timer(RewardContain RewardContain, int CoefValue = 2)
    {
        if (RewardContain.TimeForReward > 0)
        {
            RewardContain.TimeForReward = RewardContain.TimeForReward - Time.deltaTime;
            RewardContain._rewardCoeficient = CoefValue;
        }
        else
        {
            RewardContain._rewardCoeficient = 1;
        }
    }
    public void TakeManey(int value)
    {
        MonneyCount = MonneyCount - value;
    }
    private float GetManneyOffline()
    {
        DateTime LastSaveTime = DateAndTime.GetDateTime(key: "lastSaveTime", DateTime.UtcNow);
        TimeSpan timePassed = DateTime.UtcNow - LastSaveTime;
        int secondPassed = (int)timePassed.TotalSeconds;
        return MonneyOffline = (PassiveIncome + PlayerPrefs.GetFloat("Money_sec")) * secondPassed;
    }
    public void Load()
    {
        SaveSystem.Reservation SaveContain = SaveSystem.SaveContain;
        MonneyCount = SaveContain.MonneyCount;
        _maneyInSecond = SaveContain.ManeyInSecond;
        MaxMonneyOfline = SaveContain.MaxMonneyOfline;
    }
    public void Save()
    {
        SaveSystem.Reservation SaveContain = SaveSystem.SaveContain;
        SaveContain.MonneyCount = MonneyCount;
        SaveContain.ManeyInSecond = _maneyInSecond;
        SaveContain.MaxMonneyOfline = MaxMonneyOfline;
    }
    public void TakeMonneyOffline() => MonneyCount = MonneyCount + MonneyOffline;
    public void TakedoubleMonneyOffline() => MonneyCount = MonneyCount + MonneyOffline * 2;
    public void TakedoubleForClik() => RewardContain[0].TimeForReward = RewardContain[0].TimeForReward + 3600;
    public void TakedoubleForPassiwe() => RewardContain[1].TimeForReward = RewardContain[1].TimeForReward + 3600;
    public void TakeAllInkomeX10() => RewardContain[2].TimeForReward = RewardContain[2].TimeForReward + 10;
    public void TakeGift() => MonneyCount = MonneyCount + PrizeMonney;
    public void TakerewardGift() => MonneyCount = MonneyCount + PrizeMonney * 2;


    public void AddMonney() => MonneyCount = MonneyCount + 100000;
}
public class RewardContain
{
    public AdsManager.RewardName RewardName;
    public float TimeForReward;
    public int _rewardCoeficient;

    public RewardContain(AdsManager.RewardName RewardName)
    {
        this.RewardName = RewardName;
    }
}
