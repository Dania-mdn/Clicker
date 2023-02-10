using UnityEngine;
using TMPro;

public class CreateNewAchiw : MonoBehaviour
{
    public TextMeshProUGUI AchivName;
    public TextMeshProUGUI Reward;
    public float i;

    public void TakeReward()
    {
        MonneyHandler.singleton.achivment(i);
        PlayerPrefs.SetInt("Achiwment", PlayerPrefs.GetInt("Achiwment") - 1);
        Destroy(this.gameObject);
    }
}
