using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
//using GoogleMobileAds.Api;

public class Optiuns : MonoBehaviour
{
    //private BannerView bannerView;

    public AudioMixerGroup Mixer;
    public Toggle Music;
    public Toggle Sound;
    
    void Start()
    {
        //MobileAds.Initialize(InitStatus => { });
        //баннер
        //this.ReqestBanner();

        if (PlayerPrefs.HasKey("musika"))
        {
            Mixer.audioMixer.SetFloat("music", PlayerPrefs.GetInt("musika"));
            if (PlayerPrefs.GetInt("musika") == 0)
            {
                Music.isOn = false;
            }
            else
            {
                Music.isOn = true;
            }
        }
        if (PlayerPrefs.HasKey("zvuki"))
        {
            Mixer.audioMixer.SetFloat("sound", PlayerPrefs.GetInt("zvuki"));
            if (PlayerPrefs.GetInt("zvuki") == 0)
            {
                Sound.isOn = false;
            }
            else
            {
                Sound.isOn = true;
            }
        }
        else
        {
            if (Sound.isOn == true)
            {
                Mixer.audioMixer.SetFloat("sound", -80);
            }
            else
            {
                Mixer.audioMixer.SetFloat("sound", 0);
            }
        }
    }
    public void MusicEnable()
    {
        if (PlayerPrefs.GetInt("musika") == -80)
        {
            PlayerPrefs.SetInt("musika", 0);
            Mixer.audioMixer.SetFloat("music", PlayerPrefs.GetInt("musika"));
        }
        else
        {
            PlayerPrefs.SetInt("musika", -80);
            Mixer.audioMixer.SetFloat("music", PlayerPrefs.GetInt("musika"));
        }
    }
    public void SounfEnable()
    {
        if (PlayerPrefs.GetInt("zvuki") == -80)
        {
            PlayerPrefs.SetInt("zvuki", 0);
            Mixer.audioMixer.SetFloat("sound", PlayerPrefs.GetInt("zvuki"));
        }
        else
        {
            PlayerPrefs.SetInt("zvuki", -80);
            Mixer.audioMixer.SetFloat("sound", PlayerPrefs.GetInt("zvuki"));
        }
    }

    public void Instagramm()
    {
        Application.OpenURL("https://www.instagram.com/gamesdmurdok/?hl=ru");
    }

    //private void ReqestBanner()
    //{
    //    //настоящий ca-app-pub-9999092264265801/8715796832
    //    //тест ca-app-pub-3940256099942544/5224354917
    //    string BannerID = "ca-app-pub-9999092264265801/8715796832";
    //    this.bannerView = new BannerView(BannerID, AdSize.Banner, AdPosition.Top);
    //    AdRequest adRequest = new AdRequest.Builder().Build();
    //    this.bannerView.LoadAd(adRequest);
    //    bannerView.Show();
    //    // Called when an ad request has successfully loaded.
    //    this.bannerView.OnAdLoaded += this.HandleOnAdLoaded;
    //    // Called when an ad request failed to load.
    //    this.bannerView.OnAdFailedToLoad += this.HandleOnAdFailedToLoad;
    //    // Called when an ad is clicked.
    //    this.bannerView.OnAdOpening += this.HandleOnAdOpened;
    //}
    //public void HandleOnAdLoaded(object sender, EventArgs args)
    //{
    //    MonoBehaviour.print("HandleAdLoaded event received");
    //}
    //public void HandleOnAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    //{
    //    MonoBehaviour.print("HandleFailedToReceiveAd event received with message: "
    //                        + args.LoadAdError.GetMessage());
    //}

    //public void HandleOnAdOpened(object sender, EventArgs args)
    //{
    //    MonoBehaviour.print("HandleAdOpened event received");
    //}
}
