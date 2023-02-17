using TMPro;

public class Upgrade: BazeUpdate
{
    private int _valueUpgradeClick;
    private int _ValueUpgradePassive;
    public TextMeshProUGUI UpgradeClick;
    public TextMeshProUGUI UpgradePassive;
    public override void Start()
    {
        base.Start();
        MonneyHandler.singleton.ClickIncome = MonneyHandler.singleton.ClickIncome + (_valueUpgradeClick * 0.01f);
        UpgradeClick.text = $"+ {_valueUpgradeClick} %";

        MonneyHandler.singleton.PassiveIncome = MonneyHandler.singleton.PassiveIncome + (_ValueUpgradePassive * 0.01f);
        UpgradePassive.text = $"+ {_ValueUpgradePassive} %";
    }
    public override void ClozeButton(string Pricetext, bool isMaxUpgrade)
    {
        base.ClozeButton(Pricetext, isMaxUpgrade);
        if(isMaxUpgrade)
        {
            UpgradeClick.text = "MAX".ToString();
            UpgradePassive.text = "MAX".ToString();
        }
    }
    public override void ClickButton()
    {
        base.ClickButton();
        //1
        _valueUpgradeClick = _valueUpgradeClick + DefaultValueUpgradeClick;
        MonneyHandler.singleton.ClickIncome = MonneyHandler.singleton.ClickIncome + (DefaultValueUpgradeClick * 0.01f);
        UpgradeClick.text = "+ " + _valueUpgradeClick.ToString("0") + "%";

        //1
        _ValueUpgradePassive = _ValueUpgradePassive + DefaultValueUpgradePassiv;
        MonneyHandler.singleton.PassiveIncome = MonneyHandler.singleton.PassiveIncome + (DefaultValueUpgradePassiv * 0.01f);
        UpgradePassive.text = "+ " + _ValueUpgradePassive.ToString("0") + "%";
    }
    public override void Save()
    {
        base.Save();
        SaveSystem.Reservation SaveContain = SaveSystem.SaveContain;
        SaveContain.SaveClickIncom(IdModul, _valueUpgradeClick);
        SaveContain.SavePassIncom(IdModul, _ValueUpgradePassive);
    }
    public override void Load()
    {
        base.Load();
        SaveSystem.Reservation SaveContain = SaveSystem.SaveContain;
        _valueUpgradeClick = SaveContain.LoadClickIncom(IdModul);
        _ValueUpgradePassive = SaveContain.LoadlPassIncom(IdModul);
    }
    enum Modul { Engine, Deckhouse, Ñarcass }
}
