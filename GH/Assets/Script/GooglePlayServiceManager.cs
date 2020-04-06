using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.SocialPlatforms;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GooglePlayServiceManager : MonoBehaviour
{
    public static int[] AC = new int[51];
    public static bool Start_Achieve = false;
    public static string[] Achname =
    {
        Achievement.achievement,
        Achievement.achievement_2,
        Achievement.achievement_3,
        Achievement.achievement_4,
        Achievement.achievement_5,
        Achievement.achievement_6,
        Achievement.achievement_7,
        Achievement.achievement_8,
        Achievement.achievement_9,
        Achievement.achievement_10,
        Achievement.achievement_11,
        Achievement.achievement_12,
        Achievement.achievement_13,
        Achievement.achievement_14,
        Achievement.achievement_15,
        Achievement.achievement_16,
        Achievement.achievement_17,
        Achievement.achievement_18,
        Achievement.achievement_19,
        Achievement.achievement_20,
        Achievement.achievement_21,
        Achievement.achievement_22,
        Achievement.achievement_23,
        Achievement.achievement_24,
        Achievement.achievement_25,
        Achievement.achievement_26,
        Achievement.achievement_27,
        Achievement.achievement_28,
        Achievement.achievement_29,
        Achievement.achievement_30,
        Achievement.achievement_31,
        Achievement.achievement_32,
        Achievement.achievement_33,
        Achievement.achievement_34,
        Achievement.achievement_35,
        Achievement.achievement_36,
        Achievement.achievement_37,
        Achievement.achievement_38,
        Achievement.achievement_39,
        Achievement.achievement_40,
        Achievement.achievement_41,
        Achievement.achievement_42,
        Achievement.achievement_43,
        Achievement.achievement_44,
        Achievement.achievement_45,
        Achievement.achievement_46,
        Achievement.achievement_47,
        Achievement.achievement_48,
        Achievement.achievement_49,
        Achievement.achievement_50,
        Achievement.achievement_51,
    };

    public static bool isGoogle;
    
    void Start()
    {
        // Recommended for debugging
        PlayGamesPlatform.DebugLogEnabled = true;

        // Activate the Google Play Games platform
        PlayGamesPlatform.Activate();
        Social.localUser.Authenticate(ProcessAuthentication);

        GameStart();
    }

    public void GameStart()
    {
        if (PlayGamesPlatform.Instance.IsAuthenticated() == false)
        {
            Social.localUser.Authenticate((bool success) =>
            {
                if (success)
                {
                    Main_Scene.Googleplay.GetComponent<Image>().sprite = Main_Scene.main_but[71];
                    UnlockAchievement(Achname[50]);
                    Debug.Log("Login Sucess");
                }
                else
                {
                    Main_Scene.Googleplay.GetComponent<Image>().sprite = Main_Scene.main_but[70];
                    Debug.Log("Login failed");
                }
            });
        }
    }

    /// <summary>
    /// Make Login and manage the succes or failure
    /// </summary>
    public void LogIn()
    {
        if (PlayGamesPlatform.Instance.IsAuthenticated() == false)
        {
            Social.localUser.Authenticate((bool success) =>
            {
                if (success)
                {
                    Main_Scene.Googleplay.GetComponent<Image>().sprite = Main_Scene.main_but[71];
                    UnlockAchievement(Achname[50]);
                    Debug.Log("Login Sucess");
                }
                else
                {
                    Main_Scene.Googleplay.GetComponent<Image>().sprite = Main_Scene.main_but[70];
                    Debug.Log("Login failed");
                }
            });
        }

        else
        {
            Main_Scene.Googleplay.GetComponent<Image>().sprite = Main_Scene.main_but[70];
            ((PlayGamesPlatform)Social.Active).SignOut();
        }
    }

    void ProcessAuthentication(bool success)
    {
        if (success)
        {
            Debug.Log("Authenticated, checking achievements");

            // Request loaded achievements, and register a callback for processing them
            Social.LoadAchievements(ProcessLoadedAchievements);
        }
        else
            Debug.Log("Failed to authenticate");
    }

    void ProcessLoadedAchievements(IAchievement[] achievements)
    {
        if (achievements.Length == 0)
            Debug.Log("Error: no achievements found");
        else
            Debug.Log("Got " + achievements.Length + " achievements");
    }

    public void UnlockAchievement(string Ach)
    {
#if UNITY_ANDROID
            Social.ReportProgress(Ach, 100f, (bool success) => {
            });
#elif UNITY_IOS
            Social.ReportProgress("Score_100", 100f, null);
#endif
    }

    public void ShowAchievementUI()
    {
        // Sign In 이 되어있지 않은 상태라면
        // Sign In 후 업적 UI 표시 요청할 것
        if (Social.localUser.authenticated == false)
        {
            Social.localUser.Authenticate((bool success) =>
            {
                if (success)
                {
                    // Sign In 성공
                    // 바로 업적 UI 표시 요청
                    Social.ShowAchievementsUI();
                    return;
                }
                else
                {
                    // Sign In 실패 처리
                    return;
                }
            });
        }

        Social.ShowAchievementsUI();
    }

    public void ShowLeaderBoardUI()
    {
        // Sign In 이 되어있지 않은 상태라면
        // Sign In 후 업적 UI 표시 요청할 것
        if (Social.localUser.authenticated == false)
        {
            Social.localUser.Authenticate((bool success) =>
            {
                if (success)
                {
                    // Sign In 성공
                    // 바로 업적 UI 표시 요청
                    Social.ShowLeaderboardUI();
                    return;
                }
                else
                {
                    // Sign In 실패 처리
                    return;
                }
            });
        }

        Social.ShowLeaderboardUI();
    }

    void Update()
    {
        if (PlayGamesPlatform.Instance.IsAuthenticated() == true)
            isGoogle = true;

        else
            isGoogle = false;

        UnlockAchievement(Achname[50]);
    }
}

