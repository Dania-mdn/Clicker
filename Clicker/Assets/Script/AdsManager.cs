using UnityEngine;
using TMPro;
using System;
using GoogleMobileAds.Api;
using UnityEngine.UI;

public class AdsManager : MonoBehaviour
{
    private BannerView _bannerView;
    public RewardedAd RewardedAd;
    //íàñòîÿùèé ca-app-pub-9999092264265801/7556372806
    //òåñò ca-app-pub-3940256099942544/5224354917
    private const string _êewardedUnitID = "ca-app-pub-3940256099942544/5224354917";
    private int _numberRevard;

    private AudioSource _audio;
    void Awake()
    {
        MobileAds.Initialize(InitStatus => { });
        RewardedAd = new RewardedAd(_êewardedUnitID);
        RewardedAd.OnAdClosed += HandleRewardedAdClosed;
        AdRequest Request = new AdRequest.Builder().Build();
        RewardedAd.LoadAd(Request);
        RewardedAd.OnUserEarnedReward += HandleUserEarnedReward;
        ReqestBanner();

        _audio = GetComponent<AudioSource>();
    }
    public void PlayAudio() => _audio.Play();
    private void ReqestBanner()
    {
        //íàñòîÿùèé ca-app-pub-9999092264265801/8715796832
        //òåñò ca-app-pub-3940256099942544/5224354917
        string BannerID = "ca-app-pub-3940256099942544/5224354917";
        this._bannerView = new BannerView(BannerID, AdSize.Banner, AdPosition.Top);
        AdRequest adRequest = new AdRequest.Builder().Build();
        this._bannerView.LoadAd(adRequest);
        _bannerView.Show();
        // Called when an ad request has successfully loaded.
        this._bannerView.OnAdLoaded += this.HandleOnAdLoaded;
        // Called when an ad request failed to load.
        this._bannerView.OnAdFailedToLoad += this.HandleOnAdFailedToLoad;
        // Called when an ad is clicked.
        this._bannerView.OnAdOpening += this.HandleOnAdOpened;
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
    private void HandleRewardedAdClosed(object sender, EventArgs e)
    {
        AdRequest Request = new AdRequest.Builder().Build();
        this.RewardedAd.LoadAd(Request);
    }
    public void HandleUserEarnedReward(object sender, Reward args) => MonneyHandler.singleton.TakeRewardArrey[_numberRevard]?.Invoke();
    public void ActivReward(RewardName RewardName)
    {
        RewardedAd.Show();
        _numberRevard = (int)RewardName;
    }
    public enum RewardName
    {
        MonneyOffline,
        doubleMonneyOffline,
        doubleForClik,
        doubleForPassiwe,
        AllInkomeX10,
        gift,
        rewardGift
    }
}
