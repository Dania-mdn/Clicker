public class Upgrade: BazeUpdate
{
    public ClickAndPassive UpgradeClick;
    public ClickAndPassive UpgradePassive;
    public override void Start()
    {
        base.Start();

        ChangeValues(UpgradeClick);
        ChangeValues(UpgradePassive); 
    }
    public override void ClozeButton(string Pricetext, bool isMaxUpgrade)
    {
        base.ClozeButton(Pricetext, isMaxUpgrade);
        if(isMaxUpgrade)
        {
            UpgradeClick.Upgrade.text = "MAX".ToString();
            UpgradePassive.Upgrade.text = "MAX".ToString();
        }
    }
    public override void ClickButton()
    {
        base.ClickButton();
        ChangeValues(UpgradeClick);
        AddValues(UpgradeClick);
        ChangeValues(UpgradePassive);
        AddValues(UpgradePassive);
    }
    public void ChangeValues(ClickAndPassive objectUpgrade)
    {
        objectUpgrade.Upgrade.text = $"+ {objectUpgrade.ValueUpgrade} %";
        MonneyHandler.singleton.ClickIncome = MonneyHandler.singleton.ClickIncome + objectUpgrade.ValueUpgrade;
    }
    public void AddValues(ClickAndPassive objectUpgrade)
    {
        objectUpgrade.ValueUpgrade = objectUpgrade.ValueUpgrade + objectUpgrade.DefaultValueUpgrade;
    }

    public override void Save()
    {
        base.Save();
        SaveSystem.Reservation SaveContain = SaveSystem.SaveContain;
        SaveContain.SaveClickIncom(IdModul, UpgradeClick.ValueUpgrade);
        SaveContain.SavePassIncom(IdModul, UpgradePassive.ValueUpgrade);
    }
    public override void Load()
    {
        base.Load();
        SaveSystem.Reservation SaveContain = SaveSystem.SaveContain;
        UpgradeClick.ValueUpgrade = SaveContain.LoadClickIncom(IdModul);
        UpgradePassive.ValueUpgrade = SaveContain.LoadlPassIncom(IdModul);
    }
}
