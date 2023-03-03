using UnityEngine;
using System.IO;
using System.Collections.Generic;

public class SaveSystem: MonoBehaviour
{
    [Header("Reservation")]
    public Reservation SaveContain;
    private string path;

    private void OnDisable()
    {
        DateAndTime.SetDateTime("lastSaveTime", System.DateTime.UtcNow);
        SaveField();
    }
    private void Awake()
    {
#if UNITY_ANDROID && !UNITY_EDITOR
        path = Path.Combine(Application.persistentDataPath, "JSON.json");
#else
        path = Path.Combine(Application.dataPath + "JSON.json");
#endif
        
        //if(JsonUtility.FromJson<Reservation>(File.ReadAllText(path)) != null)  ??
        LoadField();
    }

    public void LoadField()
    {
        SaveContain = JsonUtility.FromJson<Reservation>(File.ReadAllText(path));
    }

    public void SaveField()
    {
#if UNITY_ANDROID && !UNITY_EDITOR
        if (pause) File.WriteAllText(path, JsonUtility.ToJson(item));
#endif
        File.WriteAllText(path, JsonUtility.ToJson(SaveContain));
    }

    [System.Serializable]
    public class Reservation
    {
        private static int ShipCount = 7;
        public int AvailableShipNumber;
        public int ShipNumber;
        public Upgrade[] json = new Upgrade[ShipCount];

        public float MonneyCount;
        public float ManeyInSecond;
        public float MaxMonneyOfline;
        public float Cistern;
        public float TimeBonusForClickIncome;
        public float TimeBonusforPassiveIncome;
        public float TimeBonusforAllIncome;

        public int DolfyCount;
        public void SaveLevelUpgrade(int IdModul, int Value) => json[ShipNumber].LevelUpgrade[IdModul] = Value;
        public void SaveClickIncom(int IdModul, int Value) => json[ShipNumber].ClickIncom[IdModul] = Value;
        public void SavePassIncom(int IdModul, int Value) => json[ShipNumber].PassIncom[IdModul] = Value;
        public void SaveProgressSlider(int IdModul, float Value) => json[ShipNumber].ProgressSlider[IdModul] = Value;
        public int LoadlLevelUpgrade(int IdModul) => json[ShipNumber].LevelUpgrade[IdModul];
        public int LoadClickIncom(int IdModul) => json[ShipNumber].ClickIncom[IdModul];
        public int LoadlPassIncom(int IdModul) => json[ShipNumber].PassIncom[IdModul];
        public float LoadlProgressSlider(int IdModul) => json[ShipNumber].ProgressSlider[IdModul];
        public void SaveShipNumber(int ShipNumber) 
        {
            this.ShipNumber = ShipNumber;
            AvailableShipNumber = AvailableShipNumber < ShipNumber ? ShipNumber : AvailableShipNumber;
        }
        public bool GetAvailable(int Update) => json[AvailableShipNumber].LevelUpgrade[Update] == 15;
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
}
