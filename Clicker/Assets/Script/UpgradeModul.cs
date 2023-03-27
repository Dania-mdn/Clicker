using UnityEngine;

public class UpgradeModul: BazeUpdate
{
    [SerializeField] private ClickAndPassive _upgradeClick;
    [SerializeField] private ClickAndPassive _upgradePassive;
    public override void Start()
    {
        base.Start();

        ChangeValues(_upgradeClick);
        ChangeValues(_upgradePassive); 
    }
    public override void ClozeButton(string Pricetext, bool isMaxUpgrade)
    {
        base.ClozeButton(Pricetext, isMaxUpgrade);
        if(isMaxUpgrade)
        {
            _upgradeClick.Upgrade.text = "MAX".ToString();
            _upgradePassive.Upgrade.text = "MAX".ToString();
        }
    }
    public override void ClickButton()
    {
        base.ClickButton();
        ChangeValues(_upgradeClick);
        AddValues(_upgradeClick);
        ChangeValues(_upgradePassive);
        AddValues(_upgradePassive);
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
        SaveContain.SaveClickIncom(IdModul, _upgradeClick.ValueUpgrade);
        SaveContain.SavePassIncom(IdModul, _upgradePassive.ValueUpgrade);
    }
    public override void Load()
    {
        base.Load();
        SaveSystem.Reservation SaveContain = SaveSystem.SaveContain;
        _upgradeClick.ValueUpgrade = SaveContain.LoadClickIncom(IdModul);
        _upgradePassive.ValueUpgrade = SaveContain.LoadlPassIncom(IdModul);
    }
}
