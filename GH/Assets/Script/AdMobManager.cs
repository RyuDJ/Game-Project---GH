using System;
using UnityEngine;
using GoogleMobileAds.Api;

public class AdMobManager : MonoBehaviour
{
    RewardBasedVideoAd ad;
    [SerializeField] string appId;
    [SerializeField] string unitId;
    [SerializeField] bool isTest;
    [SerializeField] string deviceId;

    public static int num = 0;

    void Start()
    {
        ad = RewardBasedVideoAd.Instance;

        //광고 요청이 성공적으로 로드되면 호출됩니다.
        ad.OnAdLoaded += OnAdLoaded;
        //광고 요청을 로드하지 못했을 때 호출됩니다.
        ad.OnAdFailedToLoad += OnAdFailedToLoad;
        //광고가 표시될 때 호출됩니다.
        ad.OnAdOpening += OnAdOpening;
        //광고가 재생되기 시작하면 호출됩니다.
        ad.OnAdStarted += OnAdStarted;
        //사용자가 비디오 시청을 통해 보상을 받을 때 호출됩니다.
        ad.OnAdRewarded += OnAdRewarded;
        //광고가 닫힐 때 호출됩니다.
        ad.OnAdClosed += OnAdClosed;
        //광고 클릭으로 인해 사용자가 애플리케이션을 종료한 경우 호출됩니다.
        ad.OnAdLeavingApplication += OnAdLeavingApplication;
    }

    void LoadAd()
    {
        AdRequest request = new AdRequest.Builder().Build();

        if (isTest)
        {
            if (deviceId.Length > 0)
                request = new AdRequest.Builder().AddTestDevice(AdRequest.TestDeviceSimulator).AddTestDevice(deviceId).Build();

            unitId = "ca-app-pub-3940256099942544/1033173712"; //테스트 유닛 ID
        }

        ad.LoadAd(request, unitId);
    }

    public void OnBtnViewAdClicked()
    {
        if (ad.IsLoaded())
        {
            Debug.Log("View Ad");
            ad.Show();
        }
        else
        {
            Debug.Log("Ad is Not Loaded");
            LoadAd();
        }
    }

    void OnAdLoaded(object sender, EventArgs args) { Debug.Log("OnAdLoaded"); }
    void OnAdFailedToLoad(object sender, AdFailedToLoadEventArgs e) { Debug.Log("OnAdFailedToLoad"); }
    void OnAdOpening(object sender, EventArgs e) { Debug.Log("OnAdOpening"); }
    void OnAdStarted(object sender, EventArgs e) { Debug.Log("OnAdStarted"); }
    void OnAdRewarded(object sender, Reward e) { Debug.Log("OnAdRewarded"); }
    void OnAdClosed(object sender, EventArgs e)
    {
        Debug.Log("OnAdClosed");
    }
    void OnAdLeavingApplication(object sender, EventArgs e) { Debug.Log("OnAdLeavingApplication"); }

    void Update()
    {
        if(!Button_Script.Hintpage)
        {
            if(num == 0)
            {
                LoadAd();
                num = 1;
            }
        }

        else
        {
            num = 0;
        }
    }
}

/*

using UnityEngine;
using UnityEngine.Advertisements;

public class AdMobManager : MonoBehaviour
{
    private const string android_game_id = "2770637";
    private const string ios_game_id = "2770638";

    private const string rewarded_video_id = "video";

    void Start()
    {
        Initialize();
    }

    private void Initialize()
    {
#if UNITY_ANDROID
        Advertisement.Initialize(android_game_id);
#elif UNITY_IOS
        Advertisement.Initialize(ios_game_id);
#endif
    }

    public void ShowRewardedAd()
    {
        if (Advertisement.IsReady(rewarded_video_id))
        {
            var options = new ShowOptions { resultCallback = HandleShowResult };

            Advertisement.Show(rewarded_video_id, options);
        }
    }

    private void HandleShowResult(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Finished:
                {
                    Debug.Log("The ad was successfully shown.");

                    break;
                }
            case ShowResult.Skipped:
                {
                    Debug.Log("The ad was skipped before reaching the end.");

                    // to do ...
                    // 광고가 스킵되었을 때 처리

                    break;
                }
            case ShowResult.Failed:
                {
                    Debug.LogError("The ad failed to be shown.");

                    // to do ...
                    // 광고 시청에 실패했을 때 처리

                    break;
                }
        }
    }
}*/