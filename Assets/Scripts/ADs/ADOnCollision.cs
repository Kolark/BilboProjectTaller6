 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using UnityEngine.UI;
using GoogleMobileAds.Api;
public class ADOnCollision : MonoBehaviour
{

    string App_ID = "ca-app-pub-8309191909587214~7610171797";

    string Interstitial_ID = "ca-app-pub-3940256099942544/1033173712";

    private InterstitialAd interstitial;

    void Start()
    {
        MobileAds.Initialize(App_ID);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        RequestInterstitial();
    }

    public void RequestInterstitial()
    {

        this.interstitial = new InterstitialAd(Interstitial_ID);

        // Called when an ad request has successfully loaded.
        this.interstitial.OnAdLoaded += HandleOnAdLoaded;
        // Called when an ad request failed to load.
        this.interstitial.OnAdFailedToLoad += HandleOnAdFailedToLoad;
        // Called when an ad is shown.
        this.interstitial.OnAdOpening += HandleOnAdOpened;
        // Called when the ad is closed.
        this.interstitial.OnAdClosed += HandleOnAdClosed;
        // Called when the ad click caused the user to leave the application.
        this.interstitial.OnAdLeavingApplication += HandleOnAdLeavingApplication;

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



    //Events and Delegates
    public void HandleOnAdLoaded(object sender, EventArgs args)
    {
        ShowInterstitialAd();
    }

    public void HandleOnAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
       
    }

    public void HandleOnAdOpened(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdOpened event received");
    }

    public void HandleOnAdClosed(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdClosed event received");
    }

    public void HandleOnAdLeavingApplication(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdLeavingApplication event received");
    }
}
