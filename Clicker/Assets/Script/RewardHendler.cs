using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using GoogleMobileAds.Api;

public class RewardHendler : MonoBehaviour
{
    public SaveSystem SaveSystem;
    public AdsManager AdsManager;
    public AdsManager.RewardName RewardName;

    protected new Animation animation;

    public Image RewardPanelButton;
    protected Color _readyForUseColor = new Color(0f, 1f, 0.168f);
    protected bool _ChangeStageOfButton = false;

    void Start()
    {
        animation = GetComponent<Animation>();
    }

    void Update()
    {
        if (AdsManager.RewardedAd.IsLoaded() && _ChangeStageOfButton == false)
        {
            ReadyForUseButton();
            _ChangeStageOfButton = true;
        }
    }
    protected void ReadyForUseButton() => RewardPanelButton.color = _readyForUseColor;
    public void ActivReward()
    {
        if (RewardPanelButton.color != _readyForUseColor) return;
        AdsManager.ActivReward(RewardName);
    }
}

//public void Load()
//{
//    SaveSystem.Reservation SaveContain = SaveSystem.SaveContain;
//    TimeBonusForClickIncome = SaveContain.TimeBonusForClickIncome;
//    TimeBonusforPassiveIncome = SaveContain.TimeBonusforPassiveIncome;
//    TimeBonusforAllIncome = SaveContain.TimeBonusforAllIncome;
//}
//public void Save()
//{
//    SaveSystem.Reservation SaveContain = SaveSystem.SaveContain;
//    SaveContain.TimeBonusForClickIncome = TimeBonusForClickIncome;
//    SaveContain.TimeBonusforPassiveIncome = TimeBonusforPassiveIncome;
//    SaveContain.TimeBonusforAllIncome = TimeBonusforAllIncome;
//}
