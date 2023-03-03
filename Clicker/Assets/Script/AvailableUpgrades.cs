using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class AvailableUpgrades : MonoBehaviour
{
    public GameObject[] Available;
    private Dictionary<GameObject, TextMeshProUGUI> _dictionaryAvailable = new Dictionary<GameObject, TextMeshProUGUI>();
    private int[] _upgradeName;

    private void OnEnable()
    {
        EventManager.SetNewAvalable += SetNewAvalable;
        EventManager.SetBuy += BuyEvent;
    }
    private void OnDisable()
    {
        EventManager.SetNewAvalable -= SetNewAvalable;
        EventManager.SetBuy -= BuyEvent;
    }
    private void Start()
    {
        for (int i = 0; i < Available.Length; i++)
        {
            TextMeshProUGUI availableValue = Available[i].GetComponentInChildren(typeof(TextMeshProUGUI)) as TextMeshProUGUI;
            _dictionaryAvailable.Add(Available[i], availableValue);
        }
        _upgradeName = new int[Available.Length];
    }
    private void SetNewAvalable(int availableNumber)
    {
        _upgradeName[availableNumber] = _upgradeName[availableNumber] + 1;
        ChangeAvailable(Available[availableNumber], _upgradeName[availableNumber]);
    }
    public void BuyEvent()
    {
        for (int i = 0; i < _upgradeName.Length; i++)
        {
            _upgradeName[i] = 0; 
            ChangeAvailable(Available[i], _upgradeName[i]);
        }
    }
    private void ChangeAvailable(GameObject Available, int i)
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
