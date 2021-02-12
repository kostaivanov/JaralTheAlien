using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using System;

public class AdMobManager : MonoBehaviour
{
    private string app_ID = "ca-app-pub-2055724611816187~7160190555";


    private string interstitial_Ad_ID = "ca-app-pub-3940256099942544/1033173712";
    private string rewardedVideo_Ad_ID = "ca-app-pub-3940256099942544/5224354917";

    internal InterstitialAd interstitial;
    private RewardedAd rewardedAd;

    public void RequestInterstitial()
    {

        // Initialize an InterstitialAd.
        this.interstitial = new InterstitialAd(interstitial_Ad_ID);

        AdRequest request = new AdRequest.Builder().Build();
        this.interstitial.LoadAd(request);
    }

    public void ShowInterstitialAd()
    {
        if (this.interstitial.IsLoaded())
        {
            this.interstitial.Show();
        }
    }

    public void RequestRewardBasedVideo()
    {
        this.rewardedAd = new RewardedAd(rewardedVideo_Ad_ID);
        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the rewarded ad with the request.
        this.rewardedAd.LoadAd(request);
    }

    public void ShowVideoRewardAd()
    {
        if (this.rewardedAd.IsLoaded())
        {
            this.rewardedAd.Show();
        }
    }
}
