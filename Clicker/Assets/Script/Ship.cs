using UnityEngine;

public class Ship : MonoBehaviour
{
    [SerializeField] private ShipModuls[] _shipModuls = new ShipModuls[3];
    [SerializeField] private ParticleSystem _particleSystem;

    [HideInInspector] public SaveSystem SaveSystem;
    [HideInInspector] public int ShipNumber;
    private AudioSource AudioSource;
    public static Ship singleton;

    private void Start()
    {
        singleton = this;

        AudioSource = GetComponent<AudioSource>();

        InitializeStartSprite(SaveSystem, ShipNumber);
    }
    private void Update()
    {
        bool isPointerDown = Input.GetMouseButton(0);

        if (isPointerDown)
        {
            if(!_particleSystem.isPlaying)
            {
                AudioSource.Play();
                _particleSystem.Play();
            }
        }
        else
        {
            if(_particleSystem.isPlaying)
            {
                AudioSource.Stop();
                _particleSystem.Stop();
            }
        }
    }
    public void ChangedSprite(int idModul, int lvlUpgrade)
    {
        if (lvlUpgrade % 5 == 0 && idModul < _shipModuls.Length)
        {
            Modul(_shipModuls[idModul], lvlUpgrade);
        }
    }
    public void InitializeStartSprite(SaveSystem saveSystem, int shipNumber)
    {
        for(int i = 0; i < _shipModuls.Length; i++)
        {
            int j = saveSystem.SaveContain.Upgrade[shipNumber].LevelUpgrade[i];
            Modul(_shipModuls[i], j);
        }
    }
    public void Modul(ShipModuls objectModuls, int lvlUpgrade)
    {
        objectModuls.Lvl = lvlUpgrade / 5;
        objectModuls.SetColor();
    }
}
