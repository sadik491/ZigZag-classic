using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class AdMobManager : MonoBehaviour
{
    public static AdMobManager instance;
    private string appID = "";

    private BannerView bannerView;
    private string bannerID = "ca-app-pub-3940256099942544/6300978111";

    private InterstitialAd fullScreenAd;
    private string fullScreenAdId = "ca-app-pub-3940256099942544/1033173712";

    private RewardedAd rewardedAd;
    private string rewardedAdId = "ca-app-pub-3940256099942544/5224354917";

    private void Awake() 
    {
        DontDestroyOnLoad(this.gameObject);

        if (instance == null)
        {
            instance = this;
        }
        else {
            Destroy(this);
        }
    
    }

    public void RequestBanner() 
    {
        bannerView = new BannerView(bannerID, AdSize.Banner, AdPosition.Top);

        AdRequest request = new AdRequest.Builder().Build();

        bannerView.LoadAd(request);
        bannerView.Show();
    }

    public void RequestFullScreenAd()
    {
        fullScreenAd = new InterstitialAd(fullScreenAdId);

        AdRequest request = new AdRequest.Builder().Build();

        fullScreenAd.LoadAd(request);
        //fullScreenAd.Show();
    }

    public void RequestRewardedAd()
    {
        rewardedAd = new RewardedAd(rewardedAdId);

        AdRequest request = new AdRequest.Builder().Build();

        rewardedAd.LoadAd(request);
        //rewardedAd.Show();
    }

    public void ShowInterstitialAd()
    {

        if (PlayerPrefs.HasKey("adAccount"))
        {
            if (PlayerPrefs.GetInt("adAccount") == 2)
            {
                if (fullScreenAd.IsLoaded())
                {
                    fullScreenAd.Show();
                    PlayerPrefs.SetInt("adAccount", 0);
                }
                else
                {
                    PlayerPrefs.SetInt("adAccount", 2);
                }
            }
            else
            {
                PlayerPrefs.SetInt("adAccount", PlayerPrefs.GetInt("adAccount") + 1);
            }
        }
        else
        {
            PlayerPrefs.SetInt("adAccount", 0);
        }
        Time.timeScale = 0;
    }

    public void ShowRewardedAd()
    {

        if (rewardedAd.IsLoaded())
        {
            rewardedAd.Show();
        }

    }
}
