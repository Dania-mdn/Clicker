using UnityEngine;
using TMPro;

public class NewAchiw : MonoBehaviour
{
    public TextMeshProUGUI AchivName;
    public TextMeshProUGUI Reward;
    public float i;
    private void Start()
    {
        Reward.text = i.ToString("0");
    }
    public void TakeReward()
    {
        MonneyHandler.singleton.achivment(i);
        EventManager.DoBuy();
        Destroy(this.gameObject);
    }
}
