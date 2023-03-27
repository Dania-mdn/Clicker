using UnityEngine;

public class AnimationSpeed : MonoBehaviour
{
    private const int Speed = 2;
    private float _currentSpeed = 1;
    private Animator _anim;

    private void Start()
    {
        _anim = GetComponent<Animator>();
    }

    private void Update()
    {
        bool isPointerDown = Input.GetMouseButton(0);

        if (isPointerDown && _currentSpeed < Speed)
        {
            _currentSpeed += Time.deltaTime;
        }
        else if (!isPointerDown && _currentSpeed > 1)
        {
            _currentSpeed -= Time.deltaTime;
        }

        _anim.speed = Mathf.Clamp(_currentSpeed, 1, Speed);
    }
}
