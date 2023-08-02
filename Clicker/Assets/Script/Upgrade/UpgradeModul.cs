using UnityEngine;

public class UpgradeModul: BazeUpdate
{
    [SerializeField] private ClickAndPassive _upgradeClick;
    [SerializeField] private ClickAndPassive _upgradePassive;
    public override void Start()
    {
        base.Start();
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
        if (_buttonSprite.color == _open)
        {
            ChangeValues(_upgradeClick);
            AddValues(_upgradeClick);
            ChangeValues1(_upgradePassive);
            AddValues(_upgradePassive);
        }
    }
    public void ChangeValues(ClickAndPassive objectUpgrade)
    {
        objectUpgrade.Upgrade.text = $"+ {objectUpgrade.ValueUpgrade} %";
        MonneyHandler.singleton.ClickIncome = MonneyHandler.singleton.ClickIncome + (objectUpgrade.DefaultValueUpgrade / 4);
    }
    public void ChangeValues1(ClickAndPassive objectUpgrade)
    {
        objectUpgrade.Upgrade.text = $"+ {objectUpgrade.ValueUpgrade} %";
        MonneyHandler.singleton.PassiveIncome = MonneyHandler.singleton.PassiveIncome + (objectUpgrade.DefaultValueUpgrade / 4);
    }
    public void AddValues(ClickAndPassive objectUpgrade)
    {
        objectUpgrade.ValueUpgrade = objectUpgrade.ValueUpgrade + objectUpgrade.DefaultValueUpgrade;
    }

    public override void Save()
    {
        base.Save();
        SaveSystem.Reservation SaveContain = _saveSystem.SaveContain;
        SaveContain.SaveClickIncom(IdModul, _upgradeClick.ValueUpgrade);
        SaveContain.SavePassIncom(IdModul, _upgradePassive.ValueUpgrade);
    }
    public override void Load()
    {
        base.Load();
        SaveSystem.Reservation SaveContain = _saveSystem.SaveContain;
        _upgradeClick.ValueUpgrade = SaveContain.LoadClickIncom(IdModul);
        _upgradePassive.ValueUpgrade = SaveContain.LoadlPassIncom(IdModul);
    }
}
