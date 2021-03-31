using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AdsBase : MonoBehaviour
{
    protected Action _Success;
    protected Action _Failed;

    public abstract void ShowAnnoyingAd(Action pSuccess, Action pFailed);
    public abstract void ShowAd(Action pSuccess, Action pFailed);
    public abstract bool IsReady();
    public abstract bool IsReadyAnnoying();
    public abstract void LoadAds();
}
