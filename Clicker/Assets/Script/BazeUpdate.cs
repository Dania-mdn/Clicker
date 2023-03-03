using UnityEngine;
using UnityEngine.UI;
using TMPro;
public abstract class BazeUpdate : MonoBehaviour
{
    public SaveSystem SaveSystem;
    public Image ButtonSprite;
    public TextMeshProUGUI ButtonPrice;
    public TextMeshProUGUI LevelUpgrade;
    public Slider ProgressSlider;
    public int IdModul;
    [SerializeField] private EventManager.UpgradeName _upgradeName;
    private readonly Color _open = new Color(0f, 1f, 0.168f);
    private readonly Color _close = new Color(1, 1, 1);
    private AudioSource _audioSource;
    private int[] _price;
    private bool _isAvalable = true;
    protected int _levelUpgrade;
    private void OnEnable()
    {
        EventManager.SetBuy += SetAvalable;
    }
    private void OnDisable()
    {
        EventManager.SetBuy -= SetAvalable;
    }
    public virtual void Start()
    {
        _audioSource = GetComponent<AudioSource>();

        if (SaveSystem.SaveContain.LoadlLevelUpgrade(IdModul) != 0)
            Load();
        else
            Save();
    }
    public void SetAvalable()
    {
        _isAvalable = true;
    }
    public void Update()
    {
        _price = MonneyHandler.singleton.PriceUpgrade[SaveSystem.SaveContain.ShipNumber];

        LevelUpgrade.text = "lvl " + _levelUpgrade.ToString("0"); //??

        if (ProgressSlider.value > 0.9)
        {
            ProgressSlider.value = 0;
        }

        if (!_isAvalable) return;

        if (_levelUpgrade < _price.Length)
        {
            if (_price[_levelUpgrade] < MonneyHandler.singleton.MonneyCount)
            {
                OpenButton(_price[_levelUpgrade]);
                _isAvalable = false;
            }
            else
            {
                ClozeButton(_price[_levelUpgrade].ToString("0"), false);
            }
        }
        else
        {
            ClozeButton("MAX", true);
        }
    }
    public virtual void OpenButton(int Pricetext)
    {
        ButtonSprite.color = _open;
        ButtonPrice.text = Pricetext.ToString("0");
        EventManager.DoNewAvalable(_upgradeName);
    }
    public virtual void ClozeButton(string Pricetext, bool isMaxUpgrade)
    {
        ButtonSprite.color = _close;
        ButtonPrice.text = Pricetext;
    }
    public virtual void ClickButton()
    {
        if (ButtonSprite.color == _open)
        {
            _audioSource.Play();

            MonneyHandler.singleton.TakeManey(_price[_levelUpgrade]);

            _levelUpgrade = _levelUpgrade + 1;
            ProgressSlider.value = ProgressSlider.value + 0.2f;

            Save();
            UpgradeImgeModule();
            EventManager.DoBuy();
        }
    }
    public void UpgradeImgeModule()
    {
        Ship.singleton.ChangedSprite(IdModul, _levelUpgrade);
    }
    public virtual void Save()
    {
        SaveSystem.Reservation SaveContain = SaveSystem.SaveContain;
        SaveContain.SaveLevelUpgrade(IdModul, _levelUpgrade);
        SaveContain.SaveProgressSlider(IdModul, ProgressSlider.value);
    }
    public virtual void Load()
    {
        SaveSystem.Reservation SaveContain = SaveSystem.SaveContain;
        _levelUpgrade = SaveContain.LoadlLevelUpgrade(IdModul);
        ProgressSlider.value = SaveContain.LoadlProgressSlider(IdModul);
        //_shipNumber = SaveContain.ShipNumber;
    }
}
