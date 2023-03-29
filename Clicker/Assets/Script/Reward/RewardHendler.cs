using UnityEngine;
using UnityEngine.UI;

public class RewardHendler : MonoBehaviour
{
    [SerializeField] protected AdsManager _adsManager;
    [SerializeField] private Image _rewardPanelButton;
    [SerializeField] protected AdsManager.RewardName _rewardName;

    protected Animation _animation;
    protected Color _readyForUseColor = new Color(0f, 1f, 0.168f);
    protected bool _ChangeStageOfButton = false;

    void Start()
    {
        _animation = GetComponent<Animation>();
    }

    void Update()
    {
        if (_adsManager.RewardedAd.IsLoaded() && _ChangeStageOfButton == false)
        {
            ReadyForUseButton();
            _ChangeStageOfButton = true;
        }
    }
    protected void ReadyForUseButton() => _rewardPanelButton.color = _readyForUseColor;
    public void ActivReward()
    {
        if (_rewardPanelButton.color != _readyForUseColor) return;
        _adsManager.ActivReward(_rewardName);
    }
}
