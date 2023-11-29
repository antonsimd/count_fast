using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds;
using GoogleMobileAds.Api;
using System;

public class BannerAd : MonoBehaviour
{
    void Start() {
        // Initialize the Google Mobile Ads SDK.
        MobileAds.Initialize((InitializationStatus initStatus) => { });
        LoadAd();
    }

    // These ad units are configured to always serve test ads.
#if UNITY_ANDROID
  private string _adUnitId = "ca-app-pub-3940256099942544/6300978111";
#elif UNITY_IPHONE
  private string _adUnitId = "ca-app-pub-3940256099942544/2934735716";
#else
  private string _adUnitId = "unused";
#endif

    BannerView _bannerView;

  /// <summary>
  /// Creates a 320x50 banner view at top of the screen.
  /// </summary>
    void CreateBannerView() {
        // Create a 320x50 banner at top of the screen
        _bannerView = new BannerView(_adUnitId, AdSize.Banner, AdPosition.Bottom);
    }

    void LoadAd() {
        // create an instance of a banner view first.
        if(_bannerView == null) {
            CreateBannerView();
        }

        // create our request used to load the ad.
        var adRequest = new AdRequest();

        _bannerView.LoadAd(adRequest);
    }
}
