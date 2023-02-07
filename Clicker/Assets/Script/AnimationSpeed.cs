using UnityEngine;

public class AnimationSpeed : MonoBehaviour
{
    private Animator _anim;
    private float _speed = 1.5f;
    private void Start()
    {
        _anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (PlayerPrefs.HasKey("tap"))
        {
            if(_anim.speed < _speed)
                _anim.speed = _anim.speed + Time.deltaTime;
        }
        else
        {
            if (_anim.speed > 1)
                _anim.speed = _anim.speed - Time.deltaTime;
        }
    }
}
