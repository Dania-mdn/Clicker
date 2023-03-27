using UnityEngine;
using TMPro;

public class NewAchiw : MonoBehaviour
{
    public TextMeshProUGUI AchivName;
    private TextMeshProUGUI _reward;
    public float Prize;
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
