using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdsUnity : AdsBase, IUnityAdsListener
{
    private bool _AdIsReady = false;
    private bool _AnnoyingAdIsReady = false;

    private void Start()
    {
#if UNITY_ANDROID
        Advertisement.Initialize("3841443");
#else
        Advertisement.Initialize("3841442");
#endif

        Advertisement.AddListener(this);
    }

    public override bool IsReady()
    {
        return Advertisement.IsReady() || _AdIsReady;
    }

    public override bool IsReadyAnnoying()
    {
        return Advertisement.IsReady() || _AnnoyingAdIsReady;
    }

    public override void ShowAnnoyingAd(Action pSuccess, Action pFailed)
    {
        _Success = pSuccess;
        _Failed = pFailed;
        Advertisement.Show("video");

        _AnnoyingAdIsReady = false;
    }

    public override void ShowAd(Action pSuccess, Action pFailed)
    {
        _Success = pSuccess;
        _Failed = pFailed;
        Advertisement.Show("video");

        _AdIsReady = false;
    }

    public override void LoadAds()
    {

    }

    private void AdFinished(ShowResult pResult)
    {
        switch (pResult)
        {
            case ShowResult.Failed:
                _Failed();
                break;
            case ShowResult.Skipped:
            case ShowResult.Finished:
                _Success();
                break;
        }
    }

    public void OnUnityAdsReady(string placementId)
    {
        if (placementId == "video")
        {
            _AnnoyingAdIsReady = true;
        }
        else if(placementId == "rewardedVideo")
        {
            _AdIsReady = true;
        }
    }

    public void OnUnityAdsDidError(string message)
    {
        
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        AdFinished(showResult);
    }
}
