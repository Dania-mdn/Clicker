using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PointerHandler : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [Header("Referenses")]
    public Slider FuelProgressSlider;
    [SerializeField] private ManagerButton _managerButton;
    [SerializeField] private ParticleSystem _cursor;
    [SerializeField] Transform _transformFuel;

    [Header("other Object")]
    [HideInInspector] public bool IsPointerDown;
    private Vector2 _inputMousePosition;
    private float _fuelScale;
    private const float _fuelScaleMax = 1.3f;
    private const float _fuelScaleMin = 1f;
    private void Start()
    {
        _fuelScale = _fuelScaleMin;
    }
    void Update()
    {
        if (IsPointerDown == true)
        {
            _inputMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            _cursor.transform.position = new Vector2(_inputMousePosition.x, _inputMousePosition.y);

            if (_fuelScale < _fuelScaleMax)
            {
                _fuelScale = _fuelScale + 0.1f * Time.deltaTime;
                ScaleFuel(_fuelScale);
            }

            if (FuelProgressSlider.value > 0)
            {
                FuelProgressSlider.value = FuelProgressSlider.value - 0.005f;
                if(!_cursor.isPlaying)
                    _cursor.Play();
            }
            else
            {
                _cursor.Stop();
            }
        }
        else
        {
            if (_fuelScale > _fuelScaleMin)
            {
                _fuelScale = _fuelScale - 0.4f * Time.deltaTime;
                ScaleFuel(_fuelScale);
            }

            FuelProgressSlider.value = FuelProgressSlider.value + 0.01f;

            _cursor.Stop();
        }
    }
    public void OnPointerDown(PointerEventData pointerEventData)
    {
        _managerButton.CloseAllButton();
        IsPointerDown = true;
    }
    public void OnPointerUp(PointerEventData pointerEventData)
    {
        IsPointerDown = false;
    }
    private void ScaleFuel(float fuelScale) => _transformFuel.localScale = new Vector2(fuelScale, fuelScale);
    public void Delete_Save() => PlayerPrefs.DeleteAll();
}
