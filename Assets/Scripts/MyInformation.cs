using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using GoogleMobileAds.Api;

public class MyInformation : MonoBehaviour
{
    public RankingManager rankingManager;
    public TextMeshProUGUI textMeshProUGUI;
    private int score;
    private string myname;
    public TextMeshProUGUI form;

    void Start()
    {
         loadInterstitialAd();
        myname = PlayerPrefs.GetString("Name", "NoName");
        Debug.Log(myname);
        score = PlayerPrefs.GetInt("HighScore", 0);
        if(myname == "NoName")
        {
        form.text = "名前を入れてね";
        }
        else
        {
        form.text = myname;
        }
    
    }

    public void SendScore()
    {
        if (textMeshProUGUI.text == string.Empty)
        {
            // nullではなく空文字列を設定
            rankingManager.AddScore(myname, score);
        }
        else
        {
            rankingManager.AddScore(textMeshProUGUI.text, score);
        }

        PlayerPrefs.SetString("Name", textMeshProUGUI.text);
        showInterstitialAd();
    }

    private InterstitialAd interstitial;

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
                  Debug.LogError($"Interstitial ad failed to load: {loadAdError.GetMessage()}");
                  if (interstitial != null)
                  {
                      interstitial.Destroy();
                  }
                  return;
              }
              if (ad == null)
              {
                  Debug.LogError("Interstitial ad failed to load.");
                  return;
              }
              ad.OnAdFullScreenContentClosed += HandleOnAdClosed;
              ad.OnAdFullScreenContentFailed += (AdError error) =>
              {
                  HandleOnAdClosed();
              };
              interstitial = ad;
          });
    }
    
    private void HandleOnAdClosed()
    {
        if (interstitial != null)
        {
            interstitial.Destroy();
        }
        loadInterstitialAd();
        rankingManager.GetRanking();
    }

    public void showInterstitialAd()
    {
        if (interstitial != null && interstitial.CanShowAd())
        {
            interstitial.Show();
        }
        else
        {
            Debug.Log("Interstitial Ad not loaded");
        }
    }
}
