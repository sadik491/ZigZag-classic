﻿using System.Collections;
using UnityEngine;
using UnityEngine.Advertisements;

public class UnityAdManager : MonoBehaviour
{
    string gameId = "3909745";
    public static UnityAdManager instance;

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);

        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    void Start()
    {
        Advertisement.Initialize(gameId);
        StartCoroutine(ShowBannerWhenReady());
        Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);

    }


    public void ShowRewardedVideoAd()
    {

        if (Advertisement.IsReady("rewardedVideo"))
        {
            Advertisement.Show("rewardedVideo");
        }

    }

    public void ShowVideoAd()
    {
        
        if (PlayerPrefs.HasKey("adAccount"))
        {
            if (PlayerPrefs.GetInt ("adAccount") == 2)
            {
                if (Advertisement.IsReady("video"))
                {
                    Advertisement.Show("video");
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

    IEnumerator ShowBannerWhenReady()
    {
        while (!Advertisement.IsReady("bannerPlacement"))
        {
            yield return new WaitForSeconds(0.1f);
        }
        Advertisement.Banner.Show("bannerPlacement");
    }
}
