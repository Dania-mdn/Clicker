using UnityEngine;
using System.IO;

public class SaveSystem: MonoBehaviour
{
    [Header("Reservation")]
    public Reservation SaveContain;

    private void OnDisable()
    {
        //DateAndTime.SetDateTime("lastSaveTime", System.DateTime.UtcNow);
        SaveField();
    }
    private void Awake()
    {
        LoadField();
    }

    [System.Serializable]
    public class Reservation
    {
        private static int ShipCount = 7;
        public int AvailableShipNumber;
        public int ShipNumber;
        public Upgrade[] Upgrade = new Upgrade[ShipCount];

        public float MonneyCount;
        public float MaxMonneyOfline;
        public float Cistern;
        public float TimeBonusForClickIncome;
        public float TimeBonusforPassiveIncome;
        public float TimeBonusforAllIncome;

        public int DolfyCount;
        public void SaveLevelUpgrade(int IdModul, int Value) => Upgrade[ShipNumber].LevelUpgrade[IdModul] = Value;
        public void SaveClickIncom(int IdModul, int Value) => Upgrade[ShipNumber].ClickIncom[IdModul] = Value;
        public void SavePassIncom(int IdModul, int Value) => Upgrade[ShipNumber].PassIncom[IdModul] = Value;
        public void SaveProgressSlider(int IdModul, float Value) => Upgrade[ShipNumber].ProgressSlider[IdModul] = Value;
        public int LoadlLevelUpgrade(int IdModul) => Upgrade[ShipNumber].LevelUpgrade[IdModul];
        public int LoadClickIncom(int IdModul) => Upgrade[ShipNumber].ClickIncom[IdModul];
        public int LoadlPassIncom(int IdModul) => Upgrade[ShipNumber].PassIncom[IdModul];
        public float LoadlProgressSlider(int IdModul) => Upgrade[ShipNumber].ProgressSlider[IdModul];
        public void SaveShipNumber(int ShipNumber) 
        {
            this.ShipNumber = ShipNumber;
            AvailableShipNumber = AvailableShipNumber < ShipNumber ? ShipNumber : AvailableShipNumber;
        }
        public bool GetAvailable(int Update) => Upgrade[AvailableShipNumber].LevelUpgrade[Update] == 15;
    }
    public void LoadField()
    {

    }

    public void SaveField()
    {

    }
}

[System.Serializable]
public class Upgrade
{
    private static int _upgradeCount = 14;
    public int[] LevelUpgrade = new int[_upgradeCount];
    public int[] ClickIncom = new int[_upgradeCount];
    public int[] PassIncom = new int[_upgradeCount];
    public float[] ProgressSlider = new float[_upgradeCount];
}
