using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.SocialPlatforms;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChallengeSetting : MonoBehaviour
{
    public static bool isGoogle;

    void Start()
    {
        // Recommended for debugging
        PlayGamesPlatform.DebugLogEnabled = true;

        // Activate the Google Play Games platform
        PlayGamesPlatform.Activate();
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

    public void ShowAchievementUI()
    {
        if (PlayGamesPlatform.Instance.IsAuthenticated() == true)
        {
            Social.ShowAchievementsUI();
        }

        else
        {
        }
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
    }
}

