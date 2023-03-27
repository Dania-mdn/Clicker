using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RewardHendlerInTime : RewardHendler
{
    [SerializeField] private TextMeshProUGUI _timerRewardActiv;
    [SerializeField] private Sprite _actiwTimerImage;

    private Image _image;
    private Sprite _defaultImage;
    private bool _isRewardActiv = false;
    void Start()
    {
        _image = GetComponent<Image>();
        _defaultImage = _image.sprite;
        _animation = GetComponent<Animation>();
    }

    void Update()
    {
        if (_adsManager.RewardedAd.IsLoaded() && _ChangeStageOfButton == false)
        {
            ReadyForUseButton();
            _ChangeStageOfButton = true;
        }

        foreach (var rewardContain in MonneyHandler.singleton.RewardContain)
        {
            if (rewardContain.RewardName == _rewardName)
            {
                if (rewardContain.TimeForReward > 0)
                {
                    ShowTime(rewardContain.TimeForReward, _timerRewardActiv);
                    if (_isRewardActiv)
                    {
                        _image.sprite = _actiwTimerImage;
                        _timerRewardActiv.enabled = true;
                        _isRewardActiv = false;
                    }
                }
                else
                {
                    if(_isRewardActiv == false)
                    {
                        _image.sprite = _defaultImage;
                        _timerRewardActiv.enabled = false;
                        _animation.Play();
                        _isRewardActiv = true;
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
