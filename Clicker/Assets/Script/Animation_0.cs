using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation_0 : MonoBehaviour
{
    Animator anim;
    float speed;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (PlayerPrefs.HasKey("speed"))
        {
            speed = PlayerPrefs.GetFloat("speed");
        }
        else
        {
            speed = 1.5f;
        }
        if (PlayerPrefs.HasKey("tap"))
        {
            PlayerPrefs.SetInt("action", 0);
            if(anim.speed < speed)
            {
                anim.speed = anim.speed + Time.deltaTime;
            }
        }
        else
        {
            PlayerPrefs.DeleteKey("action");
            if (anim.speed > 1)
            {
                anim.speed = anim.speed - Time.deltaTime;
            }
        }
    }
}
