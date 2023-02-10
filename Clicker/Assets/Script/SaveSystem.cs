using UnityEngine;
using System.IO;

public class SaveSystem: MonoBehaviour
{
    [Header("Reservation")]
    public Reservation SaveContain;
    private string path;


    private void OnDisable()
    {
        SaveField();
    }
    private void Awake()
    {
#if UNITY_ANDROID && !UNITY_EDITOR
        path = Path.Combine(Application.persistentDataPath, "JSON.json");
#else
        path = Path.Combine(Application.dataPath + "JSON.json");
#endif
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
        private static int _upgradeCount = 14;
        public int[] ClickIncom = new int[_upgradeCount];
        public int[] PassIncom = new int[_upgradeCount];
        public int[] LevelUpgrade = new int[_upgradeCount];
        public float[] ProgressSlider = new float[_upgradeCount];

        public int _shipNumber = 1;
    }
}
