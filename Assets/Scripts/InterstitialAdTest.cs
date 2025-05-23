using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using UnityEngine.SceneManagement;
public class InterstitialAdTest : MonoBehaviour
{   
  private InterstitialAd interstitial;
  public bool On_Off = false;
  public void loadInterstitialAd()
  {
#if UNITY_ANDROID
    string adUnitId = RemoteConfigManager.Instance.key_ad_interstitial;
#elif UNITY_IPHONE
    string adUnitId = "ca-app-pub-3940256099942544/4411468910";
#else
    string adUnitId = "unexpected_platform";
#endif
    InterstitialAd.Load(adUnitId, new AdRequest(),
      (InterstitialAd ad, LoadAdError loadAdError) =>
      {
        if (loadAdError != null)
        {
          // Interstitial ad failed to load with error
          interstitial.Destroy();
          return;
        }
        else if (ad == null)
        {
          return;
        }
        ad.OnAdFullScreenContentClosed += () => {
          HandleOnAdClosed();
        };
        ad.OnAdFullScreenContentFailed += (AdError error) =>
        {
          HandleOnAdClosed();
        };
        interstitial = ad;
      });
  }
  private void HandleOnAdClosed()
  {
    this.interstitial.Destroy();
    this.loadInterstitialAd();
  }
  public void showInterstitialAd()
  {
    if (interstitial != null && interstitial.CanShowAd())
    {
      interstitial.Show();
    } else
    {
      Debug.Log("Interstitial Ad not load");
    }
  }
}
