using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using GoogleMobileAds.Common;
using System;
using UnityEngine;
using GoogleMobileAds.Api;

public class ads : MonoBehaviour
{
    public Ads_Manager ads_manager;
    public Animation anim;

    private void Start()
    {
        if (anim != null)
        {
            anim.enabled = false;
        }
    }
    private void Update()
    {
        if (PlayerPrefs.HasKey("Reward"))
        {
            if (anim != null)
            {
                anim.enabled = true;
            }
        }
        else
        { 
            if (anim != null)
            {
                anim.enabled = false;
            }
        }
    }
}
