using UnityEngine;
using TMPro;

public class NewAchiw : MonoBehaviour
{
    public TextMeshProUGUI AchivName;
    public float Prize;
    private TextMeshProUGUI _reward;
    private void Start()
    {
        _reward.text = Prize.ToString("0");
    }
    public void TakeReward()
    {
        MonneyHandler.singleton.TakeGift();
        EventManager.DoBuy();
        Destroy(this.gameObject);
    }
}
