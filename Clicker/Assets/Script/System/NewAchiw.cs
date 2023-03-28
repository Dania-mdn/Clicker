using UnityEngine;
using TMPro;

public class NewAchiw : MonoBehaviour
{
    [HideInInspector] public TextMeshProUGUI AchivName;
    [SerializeField] private TextMeshProUGUI _reward;
    private void Start()
    {
        _reward.text = MonneyHandler.singleton.PrizeMonney.ToString("0");
    }
    public void TakeReward()
    {
        MonneyHandler.singleton.TakeGift();
        EventManager.DoBuy();
        Destroy(this.gameObject);
    }
}
