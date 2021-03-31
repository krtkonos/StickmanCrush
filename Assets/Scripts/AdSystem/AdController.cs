using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public enum AdType
{
    Unity = 0,
    AdMob = 1,
}

public class AdController : MonoBehaviour
{
    [SerializeField] private AdsUnity _UnityAds = null;
    //[SerializeField] private AdsAdMob _AdMob = null;
    
	public bool IsReady => _CurrentAdNetwork.IsReady();
	public bool IsReadyAnnoying => _CurrentAdNetwork.IsReadyAnnoying();

    private AdsBase         _CurrentAdNetwork = null;
    private int             _CurrentAdIndex = 0;
    private static Array    _AdNetworks = Enum.GetValues(typeof(AdType));

    public void Init()
    {
        _CurrentAdNetwork = _UnityAds;

        LoadAds();
    }

    public void ShowAnnoyingAd(Action pSuccess, Action pFailed)
    {
        if (_UnityAds.IsReadyAnnoying())
        {
            _UnityAds.ShowAnnoyingAd(pSuccess, pFailed);
        }
        else
        {
            //PrepareNextAdNetwork();
            //_AdMob.ShowAnnoyingAd(pSuccess, pFailed);
        }

        //PrepareNextAdNetwork();
    }

    public void ShowAd(Action pSuccess, Action pFailed)
	{
	    if (_UnityAds.IsReady())
	    {
	        _UnityAds.ShowAd(pSuccess, pFailed);
        }
	    else
	    {
            //PrepareNextAdNetwork();
	        //_AdMob.ShowAd(pSuccess, pFailed);
        }

	    //PrepareNextAdNetwork();
	}

    private void PrepareNextAdNetwork()
    {
        _CurrentAdIndex++;

        if (_AdNetworks.Length - 1 < _CurrentAdIndex)
        {
            _CurrentAdIndex = 0;
        }

        AdType result = AdType.Unity;

        result = (AdType)_AdNetworks.GetValue(_CurrentAdIndex);

        switch (result)
        {
            case AdType.Unity:
                _CurrentAdNetwork = _UnityAds;
                break;
            case AdType.AdMob:
                //_CurrentAdNetwork = _AdMob;
                break;
        }
    }

    private void LoadAds()
    {
        _UnityAds.LoadAds();
        //_AdMob.LoadAds();
    }
}
