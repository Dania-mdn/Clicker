using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using GoogleMobileAds.Api;

public class RewardHendlerInTime : RewardHendler
{
    public TextMeshProUGUI TimerReward;
    public Sprite DefaultImage;
    public Sprite ActiwTimerImage;
    private Image _image;
    private bool _isOn = false;
    void Start()
    {
        _image = GetComponent<Image>();
        animation = GetComponent<Animation>();
    }

    void Update()
    {
        if (AdsManager.RewardedAd.IsLoaded() && _ChangeStageOfButton == false)
        {
            ReadyForUseButton();
            _ChangeStageOfButton = true;
        }

        foreach (var rewardContain in MonneyHandler.singleton.RewardContain)
        {
            if (rewardContain.RewardName == RewardName)
            {
                if (rewardContain.TimeForReward > 0)
                {
                    ShowTime(rewardContain.TimeForReward, TimerReward);
                    if (_isOn)
                    {
                        _image.sprite = ActiwTimerImage;
                        TimerReward.enabled = true;
                        _isOn = false;
                    }
                }
                else
                {
                    if(_isOn == false)
                    {
                        _image.sprite = DefaultImage;
                        TimerReward.enabled = false;
                        animation.Play();
                        _isOn = true;
                    }
                }
            }
        }
    }

    private void ShowTime(float i, TextMeshProUGUI text)
    {
        if (Mathf.Floor(i / 3600) >= 1)
            text.text = (Mathf.Floor(i / 3600)) + ":" + (Mathf.Floor((i - ((Mathf.FloorToInt(i / 3600)) * 3600)) / 60)) + ":" + (i % 60).ToString("00");
        else
            text.text = (Mathf.Floor(i / 3600)) + ":" + (Mathf.Floor(i / 60)) + ":" + (i % 60).ToString("00");
    }
}
