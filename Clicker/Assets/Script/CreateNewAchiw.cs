using UnityEngine;
using TMPro;

public class CreateNewAchiw : MonoBehaviour
{
    private GameObject Clicket;
    public TextMeshProUGUI AchivName;
    public TextMeshProUGUI Reward;
    public float i;

    private void Start()
    {
        Clicket = GameObject.Find("MainClicket");
    }
    public void TakeReward()
    {
        Clicket.GetComponent<GameManager>().achivment(i);
        PlayerPrefs.SetInt("Achiwment", PlayerPrefs.GetInt("Achiwment") - 1);
        Destroy(this.gameObject);
    }
}
