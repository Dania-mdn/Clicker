using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AchiwmentHandler : MonoBehaviour
{
    [SerializeField] private GameObject _achiwmentInstatiateObject;
    [SerializeField] private string[] _achievementDescriptions;

    private int[] _achievementValues;
    private List<Dictionary<string, int>> _intermediateAchievementList = new List<Dictionary<string, int>>();
    private bool _isAvailable = false;

    private void OnEnable()
    {
        EventManager.SetNewAchive += AchivHandler;
        EventManager.SetBuy += UpdateAvailabl;
    }
    private void OnDisable()
    {
        EventManager.SetNewAchive -= AchivHandler;
        EventManager.SetBuy -= UpdateAvailabl;
    }
    private void Start()
    {
        _achievementValues = new int[_achievementDescriptions.Length];
    }
    private void Update()
    {
        if (!_isAvailable) return;

        for (int i = 0; i < _intermediateAchievementList.Count; i++)
            EventManager.DoNewAvalable(EventManager.UpgradeName.Achiw);

        _isAvailable = false;
    }
    private void AchivHandler(int numberAchiv)
    {
        _achievementValues[numberAchiv] = _achievementValues[numberAchiv] + 1;

        switch (numberAchiv)
        {
            case (int)EventManager.AchiveName.Ship:
                {
                    AddToListNewAchiwment(numberAchiv);
                    break;
                }
            case (int)EventManager.AchiveName.Dolfi:
                {
                    if (_achievementValues[numberAchiv] % 3 == 0)
                    {
                        AddToListNewAchiwment(numberAchiv);
                    }
                    break;
                }
            case (int)EventManager.AchiveName.AdsPassiwX2:
                {
                    AddToListNewAchiwment(numberAchiv);
                    break;
                }
            case (int)EventManager.AchiveName.AdsClickX2:
                {
                    AddToListNewAchiwment(numberAchiv);
                    break;
                }
            case (int)EventManager.AchiveName.AdsGift:
                {
                    AddToListNewAchiwment(numberAchiv);
                    break;
                }
            case (int)EventManager.AchiveName.AdsAllX10:
                {
                    AddToListNewAchiwment(numberAchiv);
                    break;
                }
            case (int)EventManager.AchiveName.Gift:
                {
                    AddToListNewAchiwment(numberAchiv);
                    break;
                }
        }
    }

    private void AddToListNewAchiwment(int numberAchiv)
    {
        Dictionary<string, int> dictionary = new Dictionary<string, int>();
        dictionary.Add(_achievementDescriptions[numberAchiv], _achievementValues[numberAchiv]);
        _intermediateAchievementList.Add(dictionary);
        EventManager.DoNewAvalable(EventManager.UpgradeName.Achiw);
    }

    public void ActiveAchiv()
    {
        GameObject newAchiw;
        newAchiw = Instantiate(_achiwmentInstatiateObject, Vector2.zero, Quaternion.identity, transform.parent.parent);
        var NewAchiw = newAchiw?.GetComponent<NewAchiw>();
        var firstPair = _intermediateAchievementList.FirstOrDefault();
        NewAchiw.AchivName.text = $"{firstPair.FirstOrDefault().Key}, {firstPair.FirstOrDefault().Value}".ToString();
        _intermediateAchievementList.Remove(_intermediateAchievementList.First());
    }
    private void UpdateAvailabl() => _isAvailable = true;
}
