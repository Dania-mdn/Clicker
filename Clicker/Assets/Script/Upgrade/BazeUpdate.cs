using UnityEngine;
using UnityEngine.UI;
using TMPro;
public abstract class BazeUpdate : MonoBehaviour
{
    [SerializeField] protected SaveSystem _saveSystem;
    [SerializeField] protected Image _buttonSprite;
    [SerializeField] private TextMeshProUGUI _buttonPriceText;
    [SerializeField] private TextMeshProUGUI _levelUpgradeText;
    [SerializeField] private Slider _progressSlider;
    [SerializeField] protected int IdModul;
    [SerializeField] private EventManager.UpgradeName _upgradeName;

    protected readonly Color _open = new Color(0f, 1f, 0.168f);
    protected readonly Color _close = new Color(1, 1, 1);
    private AudioSource _audioSource;
    private int[] _priceForUpgrade;
    private bool _isAvalable = true;
    protected int _levelUpgrade;
    private void OnEnable()
    {
        EventManager.SetBuy += SetAvalable;
        EventManager.Value += Load;
    }
    private void OnDisable()
    {
        EventManager.SetBuy -= SetAvalable;
        EventManager.Value -= Load;
        Save();
    }
    public virtual void Start()
    {
        _audioSource = GetComponent<AudioSource>();

    }
    public void SetAvalable()
    {
        _isAvalable = true;
    }
    public void Update()
    {
        _priceForUpgrade = MonneyHandler.singleton.PriceUpgrade[_saveSystem.SaveContain.ShipNumber];

        _levelUpgradeText.text = "lvl " + _levelUpgrade.ToString("0");

        if (_progressSlider.value > 0.9)
        {
            _progressSlider.value = 0;
        }

        if (!_isAvalable) return;

        if (_levelUpgrade < _priceForUpgrade.Length)
        {
            if (_priceForUpgrade[_levelUpgrade] < MonneyHandler.singleton.MonneyCount)
            {
                OpenButton(_priceForUpgrade[_levelUpgrade]);
                _isAvalable = false;
            }
            else
            {
                ClozeButton(_priceForUpgrade[_levelUpgrade].ToString("0"), false);
            }
        }
        else
        {
            ClozeButton("MAX", true);
        }
    }
    public virtual void OpenButton(int Pricetext)
    {
        _buttonSprite.color = _open;
        _buttonPriceText.text = Pricetext.ToString("0");
        EventManager.DoNewAvalable(_upgradeName);
    }
    public virtual void ClozeButton(string Pricetext, bool isMaxUpgrade)
    {
        _buttonSprite.color = _close;
        _buttonPriceText.text = Pricetext;
    }
    public virtual void ClickButton()
    {
        if (_buttonSprite.color == _open)
        {
            _audioSource.Play();

            MonneyHandler.singleton.TakeManey(_priceForUpgrade[_levelUpgrade]);

            _levelUpgrade = _levelUpgrade + 1;
            _progressSlider.value = _progressSlider.value + 0.2f;

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
        SaveSystem.Reservation SaveContain = _saveSystem.SaveContain;
        SaveContain.SaveLevelUpgrade(IdModul, _levelUpgrade);
        SaveContain.SaveProgressSlider(IdModul, _progressSlider.value);
    }
    public virtual void Load()
    {
        SaveSystem.Reservation SaveContain = _saveSystem.SaveContain;
        _levelUpgrade = SaveContain.LoadlLevelUpgrade(IdModul);
        _progressSlider.value = SaveContain.LoadlProgressSlider(IdModul);
        _buttonPriceText.text = _priceForUpgrade[_levelUpgrade].ToString("0");
    }
}
