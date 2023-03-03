using UnityEngine;

public class Ship : MonoBehaviour
{
    public static Ship singleton; 
    public SaveSystem SaveSystem;
    public int ShipNumber;
    public ShipModuls[] ShipModuls = new ShipModuls[3];
    public ParticleSystem ParticleSystem;
    private AudioSource AudioSource;


    private void Start()
    {
        singleton = this;

        AudioSource = GetComponent<AudioSource>();

        InitializeStartSprite(SaveSystem, ShipNumber);
    }
    private void Update()
    {
        if (PlayerPrefs.HasKey("_isPointerDown"))
        {
            if(!AudioSource.isPlaying)
            {
                AudioSource.Play();
                ParticleSystem.Play();
            }
        }
        else
        {
            if(AudioSource.isPlaying)
            {
                AudioSource.Stop();
                ParticleSystem.Stop();
            }
        }
    }
    public void ChangedSprite(int idModul, int lvlUpgrade)
    {
        if (lvlUpgrade % 5 == 0 && idModul < ShipModuls.Length)
        {
            Modul(ShipModuls[idModul], lvlUpgrade);
        }
    }
    public void InitializeStartSprite(SaveSystem saveSystem, int shipNumber)
    {
        for(int i = 0; i < ShipModuls.Length; i++)
        {
            int j = saveSystem.SaveContain.json[shipNumber].LevelUpgrade[i];
            Modul(ShipModuls[i], j);
        }
    }
    public void Modul(ShipModuls objectModuls, int lvlUpgrade)
    {
        objectModuls.Lvl = lvlUpgrade / 5;
        objectModuls._coef = 0;
    }
}
