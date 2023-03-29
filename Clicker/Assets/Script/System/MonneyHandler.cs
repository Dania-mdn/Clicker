using System;
using UnityEngine;
using TMPro;
using System.Collections;

public class MonneyHandler : MonoBehaviour
{
    [SerializeField] private Animation _moneyAnimation;
    [SerializeField] private SaveSystem _saveSystem;
    [SerializeField] private PointerHandler _pointerHandler;
    [SerializeField] private TextMeshProUGUI _MonneyCountText;
    [SerializeField] private TextMeshProUGUI _MoneyInSecondText;
    [Header("Color of Monney")]
    [SerializeField] private Color _defoltMonneyColor;
    [SerializeField] private Color _addMonneyColor;
    [SerializeField] private Price _price;

    [HideInInspector] public float ClickIncome;
    [HideInInspector] public float PassiveIncome;
    [HideInInspector] public float MaxMonneyOfline;
    [HideInInspector] public int PrizeMonney;
    [HideInInspector] public float MonneyOffline;

    public float MonneyCount { get; private set; }
    public static MonneyHandler singleton;
    public Action[] TakeRewardArrey;
    public RewardContain[] RewardContain = new RewardContain[3];
    public int[][] PriceUpgrade;

    private float _maneyInSecond = 0.1f;
    private float _intermediateValue;

    private void Awake()
    {
        singleton = this;
    }
    private void Start()
    {
        TakeRewardArrey = new Action[] { TakeMonneyOffline, TakedoubleMonneyOffline, TakedoubleForClik, TakedoubleForPassiwe, TakeAllInkomeX10, TakeGift, TakerewardGift };

        PriceUpgrade = new int[7][];
        PriceUpgrade[0] = _price.price0;
        PriceUpgrade[1] = _price.price1;
        PriceUpgrade[2] = _price.price2;
        PriceUpgrade[3] = _price.price3;
        PriceUpgrade[4] = _price.price4;
        PriceUpgrade[5] = _price.price5;
        PriceUpgrade[6] = _price.price6;

        if (_saveSystem.SaveContain.MonneyCount != 0)
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

        if (_pointerHandler.IsPointerDown == true && _pointerHandler.FuelProgressSlider.value > 0)
        {
            if (_maneyInSecond < ClickIncome * RewardContain[0]._rewardCoeficient * 2)
                _maneyInSecond = _maneyInSecond * 1.02f;
        }
        else
        {
            _maneyInSecond = ClickIncome;
        }

        Timer(RewardContain[0]);
        Timer(RewardContain[1]);
        Timer(RewardContain[2], 10);

    }
    private void ViewMonney()
    {
        if (MonneyCount < 1000)
            _MonneyCountText.text = MonneyCount.ToString("0");
        else if (MonneyCount > 1000 && MonneyCount < 1000000)
            _MonneyCountText.text = (MonneyCount / 1000).ToString("0.00") + "K";
        else if (MonneyCount > 1000000)
            _MonneyCountText.text = (MonneyCount / 1000000).ToString("0.00") + "M";

        _MoneyInSecondText.text = _maneyInSecond.ToString("0.0") + "/s";
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
        SaveSystem.Reservation SaveContain = _saveSystem.SaveContain;
        MonneyCount = SaveContain.MonneyCount;
        _maneyInSecond = SaveContain.ManeyInSecond;
        MaxMonneyOfline = SaveContain.MaxMonneyOfline;
    }
    public void Save()
    {
        SaveSystem.Reservation SaveContain = _saveSystem.SaveContain;
        SaveContain.MonneyCount = MonneyCount;
        SaveContain.ManeyInSecond = _maneyInSecond;
        SaveContain.MaxMonneyOfline = MaxMonneyOfline;
    }
    public void TakeMonneyOffline()
    {
        MonneyCount = MonneyCount + MonneyOffline; 
        StartCoroutine(ColorTransitionCoroutine());
        _moneyAnimation.Play();
    }
    public void TakedoubleMonneyOffline()
    {
        MonneyCount = MonneyCount + MonneyOffline * 2; 
        StartCoroutine(ColorTransitionCoroutine());
        _moneyAnimation.Play();
    }
    public void TakedoubleForClik() => RewardContain[0].TimeForReward = RewardContain[0].TimeForReward + 3600;
    public void TakedoubleForPassiwe() => RewardContain[1].TimeForReward = RewardContain[1].TimeForReward + 3600;
    public void TakeAllInkomeX10() => RewardContain[2].TimeForReward = RewardContain[2].TimeForReward + 10;
    public void TakeGift()
    {
        MonneyCount = MonneyCount + PrizeMonney;
        StartCoroutine(ColorTransitionCoroutine());
        _moneyAnimation.Play();
    }
    public void TakerewardGift()
    {
        MonneyCount = MonneyCount + PrizeMonney * 2;
        StartCoroutine(ColorTransitionCoroutine());
        _moneyAnimation.Play();
    }

    IEnumerator ColorTransitionCoroutine()
    {
        _MonneyCountText.color = _defoltMonneyColor;
        float duration = 2;
        float elapsedTime = 0;

        while (elapsedTime < duration)
        {
            _MonneyCountText.color = _addMonneyColor;
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        _MonneyCountText.color = _defoltMonneyColor;
    }
    public void AddMonney() => MonneyCount = MonneyCount + 100000;
}
public class RewardContain
{
    public AdsManager.RewardName RewardName;
    public float TimeForReward;
    public int _rewardCoeficient;

    public RewardContain(AdsManager.RewardName RewardName) => this.RewardName = RewardName;
}
[System.Serializable]
public class Price
{
    public int[][] PriceUpgrade;
    public int[] price0;
    public int[] price1;
    public int[] price2;
    public int[] price3;
    public int[] price4;
    public int[] price5;
    public int[] price6;
}
