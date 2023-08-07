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
        SaveContain.AvailableShipNumber = PlayerPrefs.GetInt("AvailableShipNumber");
        SaveContain.ShipNumber = PlayerPrefs.GetInt("ShipNumber");
        SaveContain.MonneyCount = PlayerPrefs.GetFloat("MonneyCount");
        SaveContain.MaxMonneyOfline = PlayerPrefs.GetFloat("MaxMonneyOfline");
        SaveContain.Cistern = PlayerPrefs.GetFloat("Cistern");
        SaveContain.TimeBonusForClickIncome = PlayerPrefs.GetFloat("TimeBonusForClickIncome");
        SaveContain.TimeBonusforPassiveIncome = PlayerPrefs.GetFloat("TimeBonusforPassiveIncome");
        SaveContain.TimeBonusforAllIncome = PlayerPrefs.GetFloat("TimeBonusforAllIncome");
        SaveContain.DolfyCount = PlayerPrefs.GetInt("DolfyCount");

        for (int i = 0; i <= SaveContain.ShipNumber; i++)
        {
            for (int j = 0; j < 14; j++)
            {
                SaveContain.Upgrade[i].LevelUpgrade[j] = PlayerPrefs.GetInt("SaveContain" + i + "SaveContain.LevelUpgrade" + j);
                SaveContain.Upgrade[i].ClickIncom[j] = PlayerPrefs.GetInt("SaveContain" + i + "SaveContain.ClickIncom" + j);
                SaveContain.Upgrade[i].PassIncom[j] = PlayerPrefs.GetInt("SaveContain" + i + "SaveContain.PassIncom" + j);
                SaveContain.Upgrade[i].ProgressSlider[j] = PlayerPrefs.GetFloat("SaveContain" + i + "SaveContain.ProgressSlider" + j);
            }
        }
    }

    public void SaveField()
    {
        PlayerPrefs.SetInt("AvailableShipNumber", SaveContain.AvailableShipNumber);
        PlayerPrefs.SetInt("ShipNumber", SaveContain.ShipNumber);
        PlayerPrefs.SetFloat("MonneyCount", SaveContain.MonneyCount);
        PlayerPrefs.SetFloat("MaxMonneyOfline", SaveContain.MaxMonneyOfline);
        PlayerPrefs.SetFloat("Cistern", SaveContain.Cistern);
        PlayerPrefs.SetFloat("TimeBonusForClickIncome", SaveContain.TimeBonusForClickIncome);
        PlayerPrefs.SetFloat("TimeBonusforPassiveIncome", SaveContain.TimeBonusforPassiveIncome);
        PlayerPrefs.SetFloat("TimeBonusforAllIncome", SaveContain.TimeBonusforAllIncome);
        PlayerPrefs.SetInt("DolfyCount", SaveContain.DolfyCount);

        for(int i = 0; i <= SaveContain.ShipNumber; i++)
        {
            for (int j = 0; j < 14; j++)
            {
                PlayerPrefs.SetInt("SaveContain" + i + "SaveContain.LevelUpgrade" + j, SaveContain.Upgrade[i].LevelUpgrade[j]);
                PlayerPrefs.SetInt("SaveContain" + i + "SaveContain.ClickIncom" + j, SaveContain.Upgrade[i].ClickIncom[j]);
                PlayerPrefs.SetInt("SaveContain" + i + "SaveContain.PassIncom" + j, SaveContain.Upgrade[i].PassIncom[j]);
                PlayerPrefs.SetFloat("SaveContain" + i + "SaveContain.ProgressSlider" + j, SaveContain.Upgrade[i].ProgressSlider[j]);
            }
        }
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
