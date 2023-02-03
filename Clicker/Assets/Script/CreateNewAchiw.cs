using UnityEngine;
using TMPro;

public class CreateNewAchiw : MonoBehaviour
{
    private GameObject _clicket;
    public TextMeshProUGUI AchivName;
    public TextMeshProUGUI Reward;
    public float i;

    private void Start()
    {
        _clicket = GameObject.FindWithTag("MainClicket");
    }
    public void TakeReward()
    {
        _clicket.GetComponent<GameManager>().achivment(i);
        PlayerPrefs.SetInt("Achiwment", PlayerPrefs.GetInt("Achiwment") - 1);
        Destroy(this.gameObject);
    }
}
