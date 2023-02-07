using UnityEngine;
using System.IO;

public class SaveAndLoad: MonoBehaviour
{
    public static SaveAndLoad Singleton { get; private set; }

    public Reservation item;
    private string path;

    private void Start()
    {
        Singleton = this;

#if UNITY_ANDROID && !UNITY_EDITOR
        path = Path.Combine(Application.persistentDataPath, "JSON.json");
#else
        path = Path.Combine(Application.dataPath + "JSON.json");
#endif
        LoadField();
    }

    public void LoadField()
    {
        item = JsonUtility.FromJson<Reservation>(File.ReadAllText(path));
    }

    public void SaveField()
    {
#if UNITY_ANDROID && !UNITY_EDITOR
        if (pause) File.WriteAllText(path, JsonUtility.ToJson(item));
#endif
        File.WriteAllText(path, JsonUtility.ToJson(item));
    }

    [System.Serializable]
    public class Reservation {}
}
