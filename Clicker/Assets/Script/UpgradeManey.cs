using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpgradeManey: BazeUpdate
{
    public int DefaultMaxMoneyOffline = 1000;
    public TextMeshProUGUI TextMaxMoneyOffline;
    private float _maxMoneyOffline;

    public override void Start()
    {
        base.Start();
        TextMaxMoneyOffline.text = $"+ {_maxMoneyOffline} ";
    }
    public override void ClozeButton(string Pricetext, bool isMaxUpgrade)
    {
        base.ClozeButton(Pricetext, isMaxUpgrade);
        if (isMaxUpgrade) TextMaxMoneyOffline.text = "MAX".ToString();
    }
    public override void ClickButton()
    {
        base.ClickButton();
        //
        _maxMoneyOffline = _maxMoneyOffline + DefaultMaxMoneyOffline;
        TextMaxMoneyOffline.text = "+ " + _maxMoneyOffline.ToString("0") + "%";
        MonneyHandler.singleton.MaxMonneyOfline = _maxMoneyOffline;
    }
    public override void Save()
    {
        base.Save();
        SaveSystem.Reservation SaveContain = SaveSystem.SaveContain;
        SaveContain.MaxMonneyOfline = _maxMoneyOffline;
    }
    public override void Load()
    {
        base.Load();
        SaveSystem.Reservation SaveContain = SaveSystem.SaveContain;
        _maxMoneyOffline = SaveContain.MaxMonneyOfline;
    }
}
