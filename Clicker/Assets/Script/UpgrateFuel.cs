using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpgrateFuel: BazeUpdate
{
    [Header("Controllers")]
    [Range(1, 5)]
    [SerializeField] private int _addToMaxValue = 1;
    [Header("Other Objects")]
    [SerializeField] private Slider _slider;
    [SerializeField] private TextMeshProUGUI _text—istern;
    private float _maxValue = 3;

    public override void Start()
    {
        base.Start();
        _text—istern.text = $"+ {_maxValue} ";
        _slider.maxValue = _maxValue;
    }
    public override void ClozeButton(string Pricetext, bool isMaxUpgrade)
    {
        base.ClozeButton(Pricetext, isMaxUpgrade);
        if (isMaxUpgrade) _text—istern.text = "MAX".ToString();
    }
    public override void ClickButton()
    {
        base.ClickButton();
        _maxValue = _maxValue + _addToMaxValue;
        _text—istern.text = "+ " + _maxValue.ToString("0") + "%";
        _slider.maxValue = _maxValue;
        MonneyHandler.singleton.MaxMonneyOfline = _maxValue;
    }
    public override void Save()
    {
        base.Save();
        SaveSystem.Reservation SaveContain = SaveSystem.SaveContain;
        SaveContain.Cistern = _maxValue;
    }
    public override void Load()
    {
        base.Load();
        SaveSystem.Reservation SaveContain = SaveSystem.SaveContain;
        _maxValue = SaveContain.Cistern;
    }
}
