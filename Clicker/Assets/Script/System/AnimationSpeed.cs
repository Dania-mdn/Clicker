using UnityEngine;

public class AnimationSpeed : MonoBehaviour
{
    private const int _maxSpeed = 2;
    private const int _defaultSpeed = 1;
    private float _currentSpeed = _defaultSpeed;
    private Animator _anim;

    private void Start()
    {
        _anim = GetComponent<Animator>();
    }

    private void Update()
    {
        bool isPointerDown = Input.GetMouseButton(0);

        UpdateSpeed(isPointerDown, 1);
        UpdateSpeed(!isPointerDown, -1);

        _anim.speed = Mathf.Clamp(_currentSpeed, 1, _maxSpeed);
    }
    private void UpdateSpeed(bool shouldUpdate, int direction)
    {
        if (shouldUpdate && _currentSpeed < _maxSpeed)
        {
            _currentSpeed += Time.deltaTime * direction;
        }
        else if (!shouldUpdate && _currentSpeed > _maxSpeed)
        {
            _currentSpeed -= Time.deltaTime * direction;
        }
    }
}
