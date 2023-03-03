using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PointerHandler : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public ManagerButton ManagerButton;
    public ParticleSystem Cursor;
    public Slider FuelProgressSlider;
    public Transform TransformFuel;
    public bool _isPointerDown;
    private float _fuelScale;
    private const float _fuelScaleMax = 1.3f;
    private const float _fuelScaleMin = 1f;
    private Vector2 _inputPosition;
    private void Start()
    {
        _fuelScale = _fuelScaleMin;
    }
    void Update()
    {
        if (_isPointerDown == true)
        {
            _inputPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Cursor.transform.position = new Vector2(_inputPosition.x, _inputPosition.y);

            if (_fuelScale < _fuelScaleMax)
            {
                _fuelScale = _fuelScale + 0.1f * Time.deltaTime;
                ScaleFuel(_fuelScale);
            }

            if (FuelProgressSlider.value > 0)
            {
                FuelProgressSlider.value = FuelProgressSlider.value - 0.005f;
                if(!Cursor.isPlaying)
                    Cursor.Play();
            }
            else
            {
                Cursor.Stop();
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

            Cursor.Stop();
        }
    }
    public void OnPointerDown(PointerEventData pointerEventData)
    {
        ManagerButton.CloseAllButton();
        _isPointerDown = true;
        PlayerPrefs.SetInt("_isPointerDown", 1);
    }
    public void OnPointerUp(PointerEventData pointerEventData)
    {
        _isPointerDown = false;
        PlayerPrefs.DeleteKey("_isPointerDown");
    }
    private void ScaleFuel(float fuelScale) => TransformFuel.localScale = new Vector2(fuelScale, fuelScale);
    public void Delete_Save() => PlayerPrefs.DeleteAll();
}
