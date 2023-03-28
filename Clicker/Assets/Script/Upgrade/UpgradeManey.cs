using UnityEngine;
using TMPro;

public class UpgradeManey: BazeUpdate
{
    [Header("Controllers")]
    [Range(500, 5000)]
    [SerializeField] private int _addToMaxMoneyOffline = 1000;
    [Header("Other Objects")]
    [SerializeField] private TextMeshProUGUI _textMaxMoneyOffline;
    private float _maxMoneyOffline;

    public override void Start()
    {
        base.Start();
        _textMaxMoneyOffline.text = $"+ {_maxMoneyOffline} ";
    }
    public override void ClozeButton(string Pricetext, bool isMaxUpgrade)
    {
        base.ClozeButton(Pricetext, isMaxUpgrade);
        if (isMaxUpgrade) _textMaxMoneyOffline.text = "MAX".ToString();
    }
    public override void ClickButton()
    {
        base.ClickButton();
        if (_buttonSprite.color == _open)
        {
            _maxMoneyOffline = _maxMoneyOffline + _addToMaxMoneyOffline;
            _textMaxMoneyOffline.text = "+ " + _maxMoneyOffline.ToString("0") + "%";
            MonneyHandler.singleton.MaxMonneyOfline = _maxMoneyOffline;
        }
    }
    public override void Save()
    {
        base.Save();
        SaveSystem.Reservation SaveContain = _saveSystem.SaveContain;
        SaveContain.MaxMonneyOfline = _maxMoneyOffline;
    }
    public override void Load()
    {
        base.Load();
        SaveSystem.Reservation SaveContain = _saveSystem.SaveContain;
        _maxMoneyOffline = SaveContain.MaxMonneyOfline;
    }
}
