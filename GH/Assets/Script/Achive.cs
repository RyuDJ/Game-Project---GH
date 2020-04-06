using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using System;
using UnityEngine.SocialPlatforms;

public class Achive : MonoBehaviour {
    
    public static int[] AC = new int[51];
    public static bool Start_Achieve = false;
    public static bool Start_Ranking = false;
    public static float Time = 0;
    public static float NotTimeattack = 0;
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
    public static string[] Leadername =
    {
        Achievement.leaderboard, Achievement.leaderboard_2, Achievement.leaderboard_3, Achievement.leaderboard_4, Achievement.leaderboard_5,
        Achievement.leaderboard_6, Achievement.leaderboard_7, Achievement.leaderboard_8, Achievement.leaderboard_9, Achievement.leaderboard_10,
        Achievement.leaderboard_11, Achievement.leaderboard_12, Achievement.leaderboard_13, Achievement.leaderboard_14
    };

    // Use this for initialization
    void Start()
    {
        /*
#if UNITY_ANDROID
        PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder().EnableSavedGames().Build();
        PlayGamesPlatform.InitializeInstance(config);
        PlayGamesPlatform.DebugLogEnabled = true;
        PlayGamesPlatform.Activate();
        Social.localUser.Authenticate (ProcessAuthentication);

#elif UNITY_IOS
        GameCenterPlatform.ShowDefaultAchievementCompletionBanner(true);

#endif */
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
        if (Social.localUser.authenticated == true)
            Social.ReportProgress(Ach, 100f, (bool success) => {
        });
    }

    public void UploadLeaderBoard(float time, string Ach)
    {
        if (Social.localUser.authenticated == true)
            Social.ReportScore((long)time, Ach, (bool success) => {
        });
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

        else
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

        else
            Social.ShowLeaderboardUI();
    }

    void Update()
    {
        if(Start_Achieve)
        {
            for (int i = 0; i < 51; i++)
            {
                if (AC[i] >= 1)
                {
                    UnlockAchievement(Achname[i]);
                    Debug.Log("AC[" + i + "] = " + AC[i]);
                    AC[i] = 0;
                }
            }

            Start_Achieve = false;
        }

        if(Start_Ranking)
        {
            LeaderBoard();
        }
    }

    public void LeaderBoard()
    {
        if (Main_Scene.Player1Mode)
        {
            if (Main_Scene.TimeAttack)
                Time = Button_Script.NowTime - Button_Script.Timeattack;

            else
                Time = Button_Script.Timeattack;
        }

        Debug.Log("3 : " + Time);

        Time *= 1000;

        //챌린지 모드일 때
        if (Challenge.Ch)
        {
            if (Challenge.Challengemode[1] == 1)
                UploadLeaderBoard(Time, Leadername[8]);

            else if (Challenge.Challengemode[2] == 1)
                UploadLeaderBoard(Time, Leadername[9]);

            else if (Challenge.Challengemode[5] == 1)
                UploadLeaderBoard(Time, Leadername[10]);

            else if (Challenge.Challengemode[6] == 1)
                UploadLeaderBoard(Time, Leadername[11]);

            else if (Challenge.Challengemode[7] == 1)
                UploadLeaderBoard(Time, Leadername[12]);

            else if (Challenge.Challengemode[8] == 1 && Main_Scene.Last_Stage == 1)
            {
                Time = 720 - Button_Script.Timeattack;
                Time *= 1000;
                UploadLeaderBoard(Time, Leadername[13]);
            }
        }

        //보통 모드일 때
        else
        {
            //합성모드일 때
            if (Main_Scene.Selected_stage[3] == 1)
            {
                if (Main_Scene.Selected_stage[0] == 1 && Main_Scene.Selected_stage[1] == 1)
                {
                    //모든 모드를 합침
                    if (Main_Scene.Selected_stage[2] == 1)
                        UploadLeaderBoard(Time, Leadername[7]);

                    //가림막 + 전등모드
                    else
                        UploadLeaderBoard(Time, Leadername[4]);
                }

                else
                {
                    //가림막 + 4*4모드
                    if (Main_Scene.Selected_stage[0] == 1 && Main_Scene.Selected_stage[2] == 1)
                        UploadLeaderBoard(Time, Leadername[5]);

                    //전등 + 4*4모드
                    else if (Main_Scene.Selected_stage[1] == 1 && Main_Scene.Selected_stage[2] == 1)
                        UploadLeaderBoard(Time, Leadername[6]);
                }

            }

            //합성모드가 아닐 때 (개별)
            else
            {
                //가림막모드일 때
                if (Main_Scene.Selected_stage[0] == 1)
                    UploadLeaderBoard(Time, Leadername[1]);

                //전등모드일 때
                else if (Main_Scene.Selected_stage[1] == 1)
                    UploadLeaderBoard(Time, Leadername[2]);

                //4*4모드일 때
                else if (Main_Scene.Selected_stage[2] == 1)
                    UploadLeaderBoard(Time, Leadername[3]);

                //일반모드일 때
                else
                    UploadLeaderBoard(Time, Leadername[0]);
            }
        }

        Start_Ranking = false;
    }
}
