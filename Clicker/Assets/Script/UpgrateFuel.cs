using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpgrateFuel: BazeUpdate
{
    public Slider MaxValueSlider;
    public int Defaul—istern = 1;
    public TextMeshProUGUI Text—istern;
    private float _cistern = 3;

    public override void Start()
    {
        base.Start();
        Text—istern.text = $"+ {_cistern} ";
        MaxValueSlider.maxValue = _cistern;
    }
    public override void ClozeButton(string Pricetext, bool isMaxUpgrade)
    {
        base.ClozeButton(Pricetext, isMaxUpgrade);
        if (isMaxUpgrade) Text—istern.text = "MAX".ToString();
    }
    public override void ClickButton()
    {
        base.ClickButton();
        _cistern = _cistern + Defaul—istern;
        Text—istern.text = "+ " + _cistern.ToString("0") + "%";
        MaxValueSlider.maxValue = _cistern;
        MonneyHandler.singleton.MaxMonneyOfline = _cistern;
    }
    public override void Save()
    {
        base.Save();
        SaveSystem.Reservation SaveContain = SaveSystem.SaveContain;
        SaveContain.Cistern = _cistern;
    }
    public override void Load()
    {
        base.Load();
        SaveSystem.Reservation SaveContain = SaveSystem.SaveContain;
        _cistern = SaveContain.Cistern;
    }
}
