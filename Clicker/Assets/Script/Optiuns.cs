using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using GoogleMobileAds.Api;

public class Optiuns : MonoBehaviour
{
    private BannerView bannerView;

    bool music = false;
    bool sound = false;
    public AudioMixerGroup mixer;
    public Toggle Music;
    public Toggle Sound;
    
    void Start()
    {
        MobileAds.Initialize(InitStatus => { });
        //баннер
        this.ReqestBanner();

        if (PlayerPrefs.HasKey("musika"))
        {
            if (PlayerPrefs.GetInt("musika") == 0)
            {
                Music.isOn = false;
                mixer.audioMixer.SetFloat("musika", 0);
                music = false;
            }
            else
            {
                Music.isOn = true;
                mixer.audioMixer.SetFloat("musika", -80);
                music = true;
            }
        }
        else
        {
            if (Music.isOn == true)
            {
                mixer.audioMixer.SetFloat("musika", -80);
            }
            else
            {
                mixer.audioMixer.SetFloat("musika", 0);
            }
        }
        if (PlayerPrefs.HasKey("zvuki"))
        {
            if (PlayerPrefs.GetInt("zvuki") == 0)
            {
                Sound.isOn = false;
                mixer.audioMixer.SetFloat("zvuki", 0);
                sound = false;
            }
            else
            {
                Sound.isOn = true;
                mixer.audioMixer.SetFloat("zvuki", -80);
                sound = true;
            }
        }
        else
        {
            if (Sound.isOn == true)
            {
                mixer.audioMixer.SetFloat("zvuki", -80);
            }
            else
            {
                mixer.audioMixer.SetFloat("zvuki", 0);
            }
        }
    }
    public void music_off()
    {
        if (music)
        {
            mixer.audioMixer.SetFloat("musika", 0);
            music = false;
            PlayerPrefs.SetInt("musika", 0);
        }
        else
        {
            mixer.audioMixer.SetFloat("musika", -80);
            music = true;
            PlayerPrefs.SetInt("musika", -80);
        }
    }
    public void sounf_off()
    {
        if (sound)
        {
            mixer.audioMixer.SetFloat("zvuki", 0);
            sound = false;
            PlayerPrefs.SetInt("zvuki", 0);
        }
        else
        {
            mixer.audioMixer.SetFloat("zvuki", -80);
            sound = true;
            PlayerPrefs.SetInt("zvuki", -80);
        }
    }
    public void instagramm()
    {
        Application.OpenURL("https://www.instagram.com/gamesdmurdok/?hl=ru");
    }

    private void ReqestBanner()
    {
        //настоящий ca-app-pub-9999092264265801/8715796832
        //тест ca-app-pub-3940256099942544/5224354917
        string BannerID = "ca-app-pub-9999092264265801/8715796832";
        this.bannerView = new BannerView(BannerID, AdSize.Banner, AdPosition.Top);
        AdRequest adRequest = new AdRequest.Builder().Build();
        this.bannerView.LoadAd(adRequest);
        bannerView.Show();
        // Called when an ad request has successfully loaded.
        this.bannerView.OnAdLoaded += this.HandleOnAdLoaded;
        // Called when an ad request failed to load.
        this.bannerView.OnAdFailedToLoad += this.HandleOnAdFailedToLoad;
        // Called when an ad is clicked.
        this.bannerView.OnAdOpening += this.HandleOnAdOpened;
    }
    public void HandleOnAdLoaded(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdLoaded event received");
    }
    public void HandleOnAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        MonoBehaviour.print("HandleFailedToReceiveAd event received with message: "
                            + args.LoadAdError.GetMessage());
    }

    public void HandleOnAdOpened(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdOpened event received");
    }
}
