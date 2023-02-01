using UnityEngine;

public class AnimationSpeed : MonoBehaviour
{
    private Animator _anim;
    private float _speed;
    private readonly float _defoltSpeed = 1.5f;
    private void Start()
    {
        _anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (PlayerPrefs.HasKey("speed"))
        {
            _speed = PlayerPrefs.GetFloat("speed");
        }
        else
        {
            _speed = _defoltSpeed;
        }
        if (PlayerPrefs.HasKey("tap"))
        {
            if(_anim.speed < _speed)
            {
                _anim.speed = _anim.speed + Time.deltaTime;
            }
        }
        else
        {
            if (_anim.speed > 1)
            {
                _anim.speed = _anim.speed - Time.deltaTime;
            }
        }
    }
}
