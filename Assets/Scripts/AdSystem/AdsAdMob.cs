using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*using GoogleMobileAds.Api;

public class AdsAdMob : AdsBase
{
    private InterstitialAd      _Interstitial;
    private RewardedAd          _RewardBasedVideo;

    private bool _Rewarded = false;

    private void Start()
    {
#if UNITY_ANDROID
        MobileAds.Initialize("ca-app-pub-4275218001334391~1959684787");
#elif UNITY_IOS
        MobileAds.Initialize("ca-app-pub-4275218001334391~1616548783");
#endif

        MobileAds.SetiOSAppPauseOnBackground(true);
    }

    public override void ShowAnnoyingAd(Action pSuccess, Action pFailed)
    {
        if (!IsReadyAnnoying())
        {
            pFailed?.Invoke();
            return;
        }

        _Success = pSuccess;
        _Failed = pFailed;

        _Interstitial.Show();
    }

    public override void ShowAd(Action pSuccess, Action pFailed)
    {
        if (!IsReady())
        {
            pFailed?.Invoke();
            return;
        }

        _Rewarded = false;
        _Success = pSuccess;
        _Failed = pFailed;

        _RewardBasedVideo.Show();
    }

    public override void LoadAds()
    {
        RequestInterstitial();
        RequestRewardBasedVideo();
    }

    public override bool IsReady()
    {
        return _RewardBasedVideo != null && _RewardBasedVideo.IsLoaded();
    }

    public override bool IsReadyAnnoying()
    {
        return _Interstitial != null && _Interstitial.IsLoaded();
    }

    private void RequestRewardBasedVideo()
    {
#if UNITY_ANDROID
        string adUnitId = "ca-app-pub-4275218001334391/6637296392";
#elif UNITY_IOS
            string adUnitId = "ca-app-pub-4275218001334391/9578799289";
#else
            string adUnitId = "unexpected_platform";
#endif

        // Create an empty ad request.
        _RewardBasedVideo = new RewardedAd(adUnitId);

        _RewardBasedVideo.OnUserEarnedReward += HandleRewardBasedVideoRewarded;
        // Called when the ad is closed.
        _RewardBasedVideo.OnAdClosed += HandleRewardBasedVideoClosed;
        AdRequest request = new AdRequest.Builder().TagForChildDirectedTreatment(false).Build();
        // Load the rewarded video ad with the request.
        _RewardBasedVideo.LoadAd(request);
    }

    private void RequestInterstitial()
    {
        if (_Interstitial != null)
        {
            return;
        }

#if UNITY_ANDROID
        string adUnitId = "ca-app-pub-4275218001334391/9829053055";
#elif UNITY_IOS
        string adUnitId = "ca-app-pub-4275218001334391/7645742848";
#else
        string adUnitId = "unexpected_platform";
#endif

        // Initialize an InterstitialAd.
        _Interstitial = new InterstitialAd(adUnitId);

        // Called when an ad request has successfully loaded.
        //_Interstitial.OnAdLoaded += HandleOnAdLoaded;
        // Called when an ad request failed to load.
        _Interstitial.OnAdFailedToLoad += HandleOnAdFailedToLoad;
        // Called when an ad is shown.
        //_Interstitial.OnAdOpening += HandleOnAdOpened;
        // Called when the ad is closed.
        _Interstitial.OnAdClosed += HandleOnAdClosed;
        // Called when the ad click caused the user to leave the application.
        _Interstitial.OnAdLeavingApplication += HandleOnAdLeavingApplication;


        AdRequest request = new AdRequest.Builder().TagForChildDirectedTreatment(false).Build();
        // Load the interstitial with the request.
        _Interstitial.LoadAd(request);
    }

    private void HandleOnAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {

    }

    private void HandleOnAdClosed(object sender, EventArgs args)
    {
        _Interstitial.Destroy();
        _Interstitial = null;
        RequestInterstitial();

        _Success?.Invoke();
    }

    private void HandleOnAdLeavingApplication(object sender, EventArgs args)
    {
        _Failed?.Invoke();
    }

    private void HandleRewardBasedVideoFailedToLoad(AdErrorEventArgs pArgs)
    {

    }

    private void HandleRewardBasedVideoRewarded(object sender, Reward args)
    {
        _Success?.Invoke();
        _Rewarded = true;
        RequestRewardBasedVideo();
    }

    private void HandleRewardBasedVideoClosed(object sender, EventArgs args)
    {
        if (!_Rewarded)
        {
            _Failed?.Invoke();
            RequestRewardBasedVideo();
        }
    }

    private void HandleRewardBasedVideoLeftApplication(object sender, EventArgs args)
    {
        _Failed?.Invoke();
    }
}*/
