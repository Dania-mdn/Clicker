using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class AvailableUpgrades : MonoBehaviour
{
    public GameObject[] Available;
    private Dictionary<GameObject, TextMeshProUGUI> _dictionaryAvailable = new Dictionary<GameObject, TextMeshProUGUI>();

    private void Start()
    {
        for (int i = 0; i < Available.Length; i++)
        {
            TextMeshProUGUI availableValue = Available[i].GetComponentInChildren(typeof(TextMeshProUGUI)) as TextMeshProUGUI;
            _dictionaryAvailable.Add(Available[i], availableValue);
        }
    }

    private void Update()
    {
        ChangeAvailavle(Available[0], PlayerPrefs.GetInt("Achiwment"));
        ChangeAvailavle(Available[1], PlayerPrefs.GetInt("0"));
        ChangeAvailavle(Available[2], PlayerPrefs.GetInt("1"));
        ChangeAvailavle(Available[3], PlayerPrefs.GetInt("2"));
        ChangeAvailavle(Available[4], PlayerPrefs.GetInt("3"));
    }
    private void ChangeAvailavle(GameObject Available, int i)
    {
        if (i == 0)
        {
            Available.SetActive(false);
        }
        else
        {
            Available.SetActive(true);
            _dictionaryAvailable[Available].text = i.ToString("0");
        }
    }
}
