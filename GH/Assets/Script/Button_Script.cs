/*합과 결 버튼에 대한 코딩이다*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.EventSystems;

public class Button_Script : MonoBehaviour
{
    public GameObject button_h;
    public GameObject button_g;
    public GameObject First_Timer;
    public static GameObject Image_Center, Player_Line_Up, Player_Line_Down, Player_Typing, Back, Player_Score01, Player_Score02,
        Player01, Player02, Player011, Player022, Player_Winner01, Player_Winner02, Player_WinCount01, Player_WinCount02, Stage,
        Stage_Type, Stage_Number, Skip, QuitPage, QuitGames, GoBackGame, Text, Text2, HintImage, Music, GameMusic, Achievement, LeaderBoard, Staring;
    public static int starting_number;

    float ChangeSpeed;
    public int Buttonclick = 0; // 버튼 클릭에 따라서 버튼이 하는 행동을 달리할 예정이다. 
    public static int NowButtonclick = 0;
    public static int Player = 1; //플레이어가 누군지에 따라 색이 바뀐다. Static을 쓴 이유는 합과 결의 버튼에 따라 Player가 다르게 표시되는 것을 방지하기 위해서이다.

    public static float timeCount = 0;
    public static int Move = 0;
    public static int step = 0; // 순서를 정함
    public static float InvisibleTime = 5; //시간

    public Sprite[] but;
    public Sprite[] GameImage;
    public Sprite[] main;
    public GameObject[] Position; //버튼 선택을 위함
    public Sprite[] allcard; //모든 카드들
    public GameObject PauseCanvas;

    public static int[] Choose = new int[3]; // 합을 위해 선택된 3가지를 고르도록 한다.
    public static int choose_card = 0; //합을 위해 선택된 카드의 수를 가지도록 하는 것.

    public static bool Timer_Check = false; //합과 결 버튼을 누르지 않은 상태
    public static bool Start_Timer = false; //합과 결 버튼을 누르지 않은 상태
    public static bool Stop_Timer = false; //합과 결 버튼을 누르지 않은 상태에서 누름

    public static bool Game_Start = false; //게임 시작을 보이는 상태
    public static bool Hap_next = false; // 합 다음의 일인가
    public static bool timer_stop = false; // 시간이 다 됐는가

    public static bool Invisible = false;
    public static bool LightStart = false;
    public static bool Winner = false;
    public static bool QuitGame = false;
    public static bool StopGame = false;
    public static bool AnswerG = false;
    public static bool TimeOver = false;
    public static bool SeeHintthis = false;
    public static bool Hintpage = false;
    public static int hintint = 0;
    public static int hintnumber = -1;
    public static float lethinttime = 0;

    float Times;

    public static float NowTime;
    public static float Timeattack;

    public static float Check_timer; // 합과 결 버튼을 누르지 않을 때 타이머

    public void TimerClick_H()
    {
        if (!Main_Scene.Start_Game_Button && !Main_Scene.Start_Game_Card && !QuitGame)
        {
            if (!Main_Scene.Player1Mode)
            {
                if (!Main_Scene.Finish_Game_Card && !Card.FadeOut)
                {
                    if (!Hap_next && NowButtonclick == 1)
                    {
                        if (!Game_Start && Start_Timer)
                        {
                            MusicSource.SFXCHOOSE = true;
                            MusicSource.SFX[0] = true;
                            MusicSource.SE_volume = 0.7f;
                            Stop_Timer = true;
                            Buttonclick = 1;
                        }
                    }

                    else
                    {
                        if (Hap_next && NowButtonclick == 231)
                        {
                            MusicSource.SFXCHOOSE = true;
                            MusicSource.SFX[0] = true;
                            MusicSource.SE_volume = 0.7f;
                            Card.Gyeoul = true;
                            step = 1;
                        }
                    }
                }
            }

            else
            {
                if (!Main_Scene.Finish_Game_Card && !Card.FadeOut)
                {
                    if (!Hap_next && NowButtonclick == 1)
                    {
                        MusicSource.SFXCHOOSE = true;
                        MusicSource.SFX[0] = true;
                        MusicSource.SE_volume = 0.7f;
                        Timer_Check = true;
                        Buttonclick = 1;
                    }

                    else
                    {
                        if (Hap_next && NowButtonclick == 231)
                        {
                            MusicSource.SFXCHOOSE = true;
                            MusicSource.SFX[0] = true;
                            MusicSource.SE_volume = 0.7f;
                            Card.Gyeoul = true;
                            step = 1;
                        }
                    }
                }
            }
        }
    }

    public void TimerClick_G()
    {
        if(!Main_Scene.Start_Game_Button && !Main_Scene.Start_Game_Card && !QuitGame)
        {
            if (!Main_Scene.Player1Mode)
            {
                if (!Main_Scene.Finish_Game_Card && !Card.FadeOut)
                {
                    if (!Hap_next && NowButtonclick == 1)
                    {
                        MusicSource.SFXCHOOSE = true;
                        MusicSource.SFX[0] = true;
                        MusicSource.SE_volume = 0.7f;
                        Card.Gyeoul = true;
                        Stop_Timer = true;
                        Buttonclick = 3;
                    }
                }
            }

            else
            {
                if (!Main_Scene.Finish_Game_Card && !Card.FadeOut)
                {
                    if (!Hap_next && NowButtonclick == 1)
                    {
                        MusicSource.SFXCHOOSE = true;
                        MusicSource.SFX[0] = true;
                        MusicSource.SE_volume = 0.7f;
                        Card.Gyeoul = true;
                        Timer_Check = true;
                        Buttonclick = 3;
                    }
                }
            }
        }
    }

    public void Skip_Button()
    {
        if (Hap_next && NowButtonclick == 231)
        {
            MusicSource.SFXCHOOSE = true;
            MusicSource.SFX[1] = true;
            MusicSource.SE_volume = 0.2f;
            NowButtonclick = 235;
            step = 0;
        }
    }

    public void StopthisPage()
    {
        if (!Main_Scene.Finish_Game_Card && !Card.FadeOut)
        {
            MusicSource.SFXCHOOSE = true;
            MusicSource.SFX[1] = true;
            MusicSource.SE_volume = 0.2f;

            Card.Fade.GetComponent<Image>().color = new Color(0, 0, 0, 0.8f);
            QuitPage.GetComponent<Image>().color = new Color(QuitPage.GetComponent<Image>().color.r, QuitPage.GetComponent<Image>().color.g, QuitPage.GetComponent<Image>().color.b, 1f);
            QuitGames.GetComponent<Image>().color = new Color(QuitGames.GetComponent<Image>().color.r, QuitGames.GetComponent<Image>().color.g, QuitGames.GetComponent<Image>().color.b, 1);
            GoBackGame.GetComponent<Image>().color = new Color(GoBackGame.GetComponent<Image>().color.r, GoBackGame.GetComponent<Image>().color.g, GoBackGame.GetComponent<Image>().color.b, 1);
            Card.Fade.GetComponent<RectTransform>().localPosition = new Vector3(0, 0, 0);
            QuitPage.GetComponent<RectTransform>().localPosition = new Vector3(0, 0, 0);
            QuitGames.GetComponent<RectTransform>().localPosition = new Vector3(0, -30, 0);
            GoBackGame.GetComponent<RectTransform>().localPosition = new Vector3(0, 30, 0);
            Music.GetComponent<RectTransform>().localPosition = new Vector3(128, -37, 0);

            if (Main_Scene.isMusicOn)
                Music.GetComponent<Image>().sprite = Main_Scene.main_but[76];

            else
                Music.GetComponent<Image>().sprite = Main_Scene.main_but[73];

            StopGame = true;
        }
    }

    public void ContinuethisPage()
    {
        MusicSource.SFXCHOOSE = true;
        MusicSource.SFX[1] = true;
        MusicSource.SE_volume = 0.2f;

        Card.Fade.GetComponent<Image>().color = new Color(0, 0, 0, 0);
        QuitPage.GetComponent<Image>().color = new Color(QuitPage.GetComponent<Image>().color.r, QuitPage.GetComponent<Image>().color.g, QuitPage.GetComponent<Image>().color.b, 1f);
        QuitGames.GetComponent<Image>().color = new Color(QuitGames.GetComponent<Image>().color.r, QuitGames.GetComponent<Image>().color.g, QuitGames.GetComponent<Image>().color.b, 1);
        GoBackGame.GetComponent<Image>().color = new Color(GoBackGame.GetComponent<Image>().color.r, GoBackGame.GetComponent<Image>().color.g, GoBackGame.GetComponent<Image>().color.b, 1);
        Card.Fade.GetComponent<RectTransform>().localPosition = new Vector3(15300, 0);
        QuitPage.GetComponent<RectTransform>().localPosition = new Vector3(400, 0, 0);
        QuitGames.GetComponent<RectTransform>().localPosition = new Vector3(400, -30, 0);
        GoBackGame.GetComponent<RectTransform>().localPosition = new Vector3(400, 30, 0);
        Music.GetComponent<RectTransform>().localPosition = new Vector3(15000, 0, 0);
        StopGame = false;
    }

    public void QuitthisGame()
    {
        if (Winner)
        {
            MusicSource.SFXCHOOSE = true;
            MusicSource.SFX[1] = true;
            MusicSource.SE_volume = 0.25f;
            step = 0;
            QuitGame = true;
        }

        else if (TimeOver)
        {
            MusicSource.SFXCHOOSE = true;
            MusicSource.SFX[0] = true;
            MusicSource.SE_volume = 0.25f;
            step = 0;
            QuitGame = true;
        }

        else
        {
            MusicSource.SFXCHOOSE = true;
            MusicSource.SFX[1] = true;
            MusicSource.SE_volume = 0.2f;
            Hintpage = false;
            Card.Fade.GetComponent<Image>().color = new Color(0, 0, 0, 0);
            Card.Fade.GetComponent<RectTransform>().localPosition = new Vector3(15300, 0);
            QuitPage.GetComponent<RectTransform>().localPosition = new Vector3(400, 0, 0);
            QuitGames.GetComponent<RectTransform>().localPosition = new Vector3(400, 30, 0);
            GoBackGame.GetComponent<RectTransform>().localPosition = new Vector3(400, -30, 0);
            Music.GetComponent<RectTransform>().localPosition = new Vector3(15000, 0, 0);
            Buttonclick = 0;
            Main_Scene.Start_Game_Button = false;
            Main_Scene.Start_Game_Card = false;
            Card.Lightmode = false;
            Main_Scene.Last_Stage = 1;
            StopGame = false;
            Card.Finish = true;
            TimeOver = false;
            QuitGame = true;
        }
    }

    //버튼 0번을 선택했을 때
    public void ClickButton()
    {
        bool isSame = false;
        string name = EventSystem.current.currentSelectedGameObject.name;

        int number = is_This(name);

        //버튼 클릭은 2번일 경우
        if (NowButtonclick == 2 && number < 16 && choose_card < 3 && step == 0)
        {
            //중복이 있는지 확인한다.
            
            for (int i = 0; i < choose_card; i++)
            {
                if (Choose[i] == number) //만약 같은 숫자가 하나라도 있었다면
                {
                    isSame = true; //같다는 표시를 하고
                    MusicSource.SFXCHOOSE = true;
                    MusicSource.SFX[choose_card+1] = true;
                    MusicSource.SE_volume = 0.4f;
                    break; //나간다
                }
            }

            if (!isSame) //참이 아닐 경우
            {
                Card.Position[number].GetComponent<Image>().color = new Color(0, 0, 0, 0.3f);
                Choose[choose_card] = number; //해당되는 배열에 숫자가 들어간다.
                choose_card++;
                MusicSource.SFXCHOOSE = true;
                MusicSource.SFX[choose_card + 1] = true;
                MusicSource.SE_volume = 0.4f;
            }
            //같을 경우엔 아무 일도 일어나지 않는다.
        }
    }

    public void HintButton()
    {
        if (!Main_Scene.Finish_Game_Card && !Card.FadeOut)
        {
            MusicSource.SFXCHOOSE = true;
            MusicSource.SFX[1] = true;
            MusicSource.SE_volume = 0.2f;
            Hintpage = true;
            Card.Fade.GetComponent<Image>().color = new Color(0, 0, 0, 0.95f);
            QuitPage.GetComponent<Image>().color = new Color(QuitPage.GetComponent<Image>().color.r, QuitPage.GetComponent<Image>().color.g, QuitPage.GetComponent<Image>().color.b, 1f);
            Card.Fade.GetComponent<RectTransform>().localPosition = new Vector3(0, 0, 0);
            Card.SeeHint.GetComponent<RectTransform>().localPosition = new Vector3(0, 20, 0);
            Card.Keepit.GetComponent<RectTransform>().localPosition = new Vector3(0, -40, 0);

            if (Main_Scene.Language == 1)
            {
                Text.GetComponent<RectTransform>().localPosition = new Vector3(0, 130, 0);
                Text2.GetComponent<RectTransform>().localPosition = new Vector3(0, -70, 0);
                Text.GetComponent<Text>().text = "다른 '합'을 찾기 어려우신가요?";
                Text2.GetComponent<Text>().text = "광고를 시청하시고 '또 다른 합'에 대한 힌트를 얻어보세요!\n\n\n\n\n\n\n\n\n\n[주의사항!]\n\n광고가 나올 때까지\n버튼을 2~3번 계속 눌러보세요.\n\n광고를 끝까지 봐야합니다!";
            }

            else if (Main_Scene.Language == 2)
            {
                Text.GetComponent<RectTransform>().localPosition = new Vector3(0, 130, 0);
                Text2.GetComponent<RectTransform>().localPosition = new Vector3(0, -70, 0);
                Text.GetComponent<Text>().text = "Is it HARD to find another 'Find'?";
                Text2.GetComponent<Text>().text = "Watch the ad and get some HINT about it!\n\n\n\n\n\n\n\n\n\n[Remember!]\n\nClick the button\nUntil ad comes out!\n\nAds must be watched\ntill the end.";
            }

            else if (Main_Scene.Language == 3)
            {
                Text.GetComponent<RectTransform>().localPosition = new Vector3(0, 150, 0);
                Text2.GetComponent<RectTransform>().localPosition = new Vector3(0, -50, 0);
                Text.GetComponent<Text>().text = "'合'を見つけるのが\n大変でございますか";
                Text2.GetComponent<Text>().text = "広告を見て\n'合'に対するヒントを\nもらうことができます！\n\n\n\n\n\n\n\n\n\n[注意!]\n\n広告が出るまで\nボタンを押し続けてください\n\n広告を必ず最後まで\n見てください!";
            }

            StopGame = true;
        }
    }

    public void KeepitButton()
    {
        MusicSource.SFXCHOOSE = true;
        MusicSource.SFX[1] = true;
        MusicSource.SE_volume = 0.2f;
        Hintpage = false;
        Card.Fade.GetComponent<RectTransform>().localPosition = new Vector3(15300, 0);
        Card.SeeHint.GetComponent<RectTransform>().localPosition = new Vector3(518, -144, 0);
        Card.Keepit.GetComponent<RectTransform>().localPosition = new Vector3(518, -144, 0);
        HintImage.GetComponent<RectTransform>().localPosition = new Vector3(518, -144);
        Text.GetComponent<RectTransform>().localPosition = new Vector3(407.5f, 228.97f, 0);
        Text2.GetComponent<RectTransform>().localPosition = new Vector3(407.5f, 228.97f, 0);
        StopGame = false;
        SeeHintthis = false;
        hintint = 0;
        hintnumber = -1;
    }

    public int is_This(string name)
    {
        int num = 0;

        for (int i = 0; i < 16; ++i)
        {
            if (name.Equals(Position[i].name)) //이름이 같다면
            {
                num = i;
                break;
            }
        }

        return num;
    }

    void Awake()
    {
        Screen.SetResolution(Screen.width, Screen.width * 16 / 9, false);
    }

    // Use this for initialization
    void Start()
    {
        but = new Sprite[52];
        GameImage = new Sprite[38];
        Position = new GameObject[16];
        allcard = new Sprite[170];
        main = new Sprite[128];
        but = Resources.LoadAll<Sprite>("Texture/Button");
        GameImage = Resources.LoadAll<Sprite>("Texture/Type");
        allcard = Resources.LoadAll<Sprite>("Texture/Cards"); //이미지를 부름
        main = Resources.LoadAll<Sprite>("Texture/Main");
        button_h = GameObject.Find("Button_H");
        button_g = GameObject.Find("Button_G");
        Back = GameObject.Find("Back");
        First_Timer = GameObject.Find("First Timer");
        Image_Center = GameObject.Find("Image_Center");
        Player_Line_Up = GameObject.Find("Player Line Up");
        Player_Line_Down = GameObject.Find("Player Line Down");
        Player_Typing = GameObject.Find("Player Typing");
        Player_Score01 = GameObject.Find("Player 01 Score");
        Player_Score02 = GameObject.Find("Player 02 Score");
        Player01 = GameObject.Find("Player 01");
        Player02 = GameObject.Find("Player 02");
        Player011 = GameObject.Find("Player 011");
        Player022 = GameObject.Find("Player 022");
        Player_Winner01 = GameObject.Find("Player 01 Winner");
        Player_Winner02 = GameObject.Find("Player 02 Winner");
        Player_WinCount01 = GameObject.Find("Player 01 WinCount");
        Player_WinCount02 = GameObject.Find("Player 02 WinCount");
        Stage = GameObject.Find("Stage");
        Stage_Type = GameObject.Find("Stage Typing");
        Stage_Number = GameObject.Find("Stage Number");
        Skip = GameObject.Find("Button_S");
        QuitPage = GameObject.Find("QuitPage");
        QuitGames = GameObject.Find("QuitGame");
        GoBackGame = GameObject.Find("GoBackGame");
        Text = GameObject.Find("HintText");
        Text2 = GameObject.Find("HintText2");
        HintImage = GameObject.Find("HintImage");
        Music = GameObject.Find("Music");
        GameMusic = GameObject.Find("MusicPlay");
        Staring = GameObject.Find("Staring");
        Achievement = GameObject.Find("Achievement");
        LeaderBoard = GameObject.Find("LeaderBoard");

        if (Main_Scene.Language == 1)
        {
            button_h.GetComponent<Image>().sprite = but[0];
            button_g.GetComponent<Image>().sprite = but[1];
            First_Timer.GetComponent<Image>().sprite = but[4];
            Image_Center.GetComponent<Image>().sprite = GameImage[4];
            QuitGames.GetComponent<Image>().sprite = but[27];
            GoBackGame.GetComponent<Image>().sprite = but[26];
            Stage_Type.GetComponent<Image>().sprite = main[60];
            Stage_Type.GetComponent<RectTransform>().sizeDelta = new Vector3(266, 71);
            Stage_Type.GetComponent<RectTransform>().localScale = new Vector3(0.6f, 0.6f);
            Stage_Number.GetComponent<RectTransform>().localPosition = new Vector3(67.2f, 510.2f, 0);
        }

        else if (Main_Scene.Language == 2)
        {
            button_h.GetComponent<Image>().sprite = but[32];
            button_g.GetComponent<Image>().sprite = but[33];
            First_Timer.GetComponent<Image>().sprite = but[4];
            Image_Center.GetComponent<Image>().sprite = GameImage[4];
            QuitGames.GetComponent<Image>().sprite = but[41];
            GoBackGame.GetComponent<Image>().sprite = but[40];
            Stage_Type.GetComponent<Image>().sprite = main[97];
            Stage_Type.GetComponent<RectTransform>().sizeDelta = new Vector3(215, 71);
            Stage_Type.GetComponent<RectTransform>().localScale = new Vector3(0.6f, 0.6f);
            Stage_Number.GetComponent<RectTransform>().localPosition = new Vector3(60, 510.2f, 0);
        }

        else if (Main_Scene.Language == 3)
        {
            button_h.GetComponent<Image>().sprite = but[42];
            button_g.GetComponent<Image>().sprite = but[43];
            First_Timer.GetComponent<Image>().sprite = but[4];
            Image_Center.GetComponent<Image>().sprite = GameImage[4];
            QuitGames.GetComponent<Image>().sprite = but[49];
            GoBackGame.GetComponent<Image>().sprite = but[48];
            Stage_Type.GetComponent<Image>().sprite = main[116];
            Stage_Type.GetComponent<RectTransform>().sizeDelta = new Vector3(269, 69);
            Stage_Type.GetComponent<RectTransform>().localScale = new Vector3(0.6f, 0.6f);
            Stage_Number.GetComponent<RectTransform>().localPosition = new Vector3(67.2f, 510.2f, 0);
        }

        Image_Center.GetComponent<Image>().color = new Color(Image_Center.GetComponent<Image>().color.r, Image_Center.GetComponent<Image>().color.g, Image_Center.GetComponent<Image>().color.b, 0);
        Player_Typing.GetComponent<Image>().color = new Color(Player_Typing.GetComponent<Image>().color.r, Player_Typing.GetComponent<Image>().color.g, Player_Typing.GetComponent<Image>().color.b, 0);
        Back.GetComponent<Image>().color = new Color(Back.GetComponent<Image>().color.r, Back.GetComponent<Image>().color.g, Back.GetComponent<Image>().color.b, 0);
        Player01.GetComponent<Image>().color = new Color(Player01.GetComponent<Image>().color.r, Player01.GetComponent<Image>().color.g, Player01.GetComponent<Image>().color.b, 0);
        Player02.GetComponent<Image>().color = new Color(Player02.GetComponent<Image>().color.r, Player02.GetComponent<Image>().color.g, Player02.GetComponent<Image>().color.b, 0);
        Player011.GetComponent<Image>().color = new Color(Player011.GetComponent<Image>().color.r, Player011.GetComponent<Image>().color.g, Player011.GetComponent<Image>().color.b, 0);
        Player022.GetComponent<Image>().color = new Color(Player022.GetComponent<Image>().color.r, Player022.GetComponent<Image>().color.g, Player022.GetComponent<Image>().color.b, 0);
        Player_Winner01.GetComponent<Image>().color = new Color(Player_Winner01.GetComponent<Image>().color.r, Player_Winner01.GetComponent<Image>().color.g, Player_Winner01.GetComponent<Image>().color.b, 0);
        Player_Winner02.GetComponent<Image>().color = new Color(Player_Winner02.GetComponent<Image>().color.r, Player_Winner02.GetComponent<Image>().color.g, Player_Winner02.GetComponent<Image>().color.b, 0);
        Player_WinCount01.GetComponent<Image>().color = new Color(Player_WinCount01.GetComponent<Image>().color.r, Player_WinCount01.GetComponent<Image>().color.g, Player_WinCount01.GetComponent<Image>().color.b, 0);
        Player_WinCount02.GetComponent<Image>().color = new Color(Player_WinCount02.GetComponent<Image>().color.r, Player_WinCount02.GetComponent<Image>().color.g, Player_WinCount02.GetComponent<Image>().color.b, 0);

        Image_Center.GetComponent<RectTransform>().localPosition = new Vector3(-400, -450, 0);
        Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(400, 45, 0);
        Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(-400, -45, 0);
        Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(15400, 0, 0);
        Player_Score01.GetComponent<RectTransform>().localPosition = new Vector3(-400, 201, 0);
        Player_Score02.GetComponent<RectTransform>().localPosition = new Vector3(400, 201, 0);
        Stage.GetComponent<RectTransform>().localPosition = new Vector3(0, 521.7f, 0);
        Stage_Type.GetComponent<RectTransform>().localPosition = new Vector3(-27, 510.2f, 0);

        Timeattack = Main_Scene.time;

        if (Player == 1)
        {
            Skip.GetComponent<Image>().sprite = but[19];
        }

        else
        {
            Skip.GetComponent<Image>().sprite = but[18];
        }


        for (int i = 0; i < 16; i++)
        {
            Position[i] = GameObject.Find("Position_Button_" + i);
            /* 게임 오브젝트인 Position 배열에 각각 밖에 설정해둔 Position_0에서 Position_8까지 넣는다.*/
        }

        if(Main_Scene.Player1Mode)
        {
            Player_WinCount01.GetComponent<RectTransform>().localPosition = new Vector3(-500, -500, 0);
            Player_WinCount02.GetComponent<RectTransform>().localPosition = new Vector3(-500, -500, 0);
            Player_Winner01.GetComponent<RectTransform>().localPosition = new Vector3(-500, -500, 0);
            Player_Winner02.GetComponent<RectTransform>().localPosition = new Vector3(-500, -500, 0);
        }
    }

    public void GoStaring()
    {
        Application.OpenURL("https://play.google.com/store/apps/details?id=com.ehdwo365.GH&hl=ko&ah=2Pp1SfISDrQgvUPgCM7cZSbwSsQ");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            StopthisPage();

        if (!Main_Scene.Player1Mode)
        {
            if (Main_Scene.Start_Game_Button) //등장하는 장면
            {
                if (step == 0)
                {
                    Number(Stage_Number, (Main_Scene.Player_2_WinCount + Main_Scene.Player_1_WinCount + 1));

                    if (Card.LastWinner == 0 || Card.LastWinner == 2)
                    {
                        Player = 1;

                        if (Main_Scene.Language == 1)
                        {
                            button_h.GetComponent<Image>().sprite = but[0];
                            button_g.GetComponent<Image>().sprite = but[1];
                        }

                        else if (Main_Scene.Language == 2)
                        {
                            button_h.GetComponent<Image>().sprite = but[32];
                            button_g.GetComponent<Image>().sprite = but[33];
                        }

                        else if (Main_Scene.Language == 3)
                        {
                            button_h.GetComponent<Image>().sprite = but[42];
                            button_g.GetComponent<Image>().sprite = but[43];
                        }

                        First_Timer.GetComponent<Image>().sprite = but[4];
                    }

                    else if (Card.LastWinner == 1)
                    {
                        Player = 2;

                        if (Main_Scene.Language == 1)
                        {
                            button_h.GetComponent<Image>().sprite = but[2];
                            button_g.GetComponent<Image>().sprite = but[3];
                        }

                        else if (Main_Scene.Language == 2)
                        {
                            button_h.GetComponent<Image>().sprite = but[34];
                            button_g.GetComponent<Image>().sprite = but[35];
                        }

                        else if (Main_Scene.Language == 3)
                        {
                            button_h.GetComponent<Image>().sprite = but[44];
                            button_g.GetComponent<Image>().sprite = but[45];
                        }

                        First_Timer.GetComponent<Image>().sprite = but[5];
                    }

                    Score();

                    if (Main_Scene.Selected_stage[0] == 0)
                    {
                        if (!StopGame)
                        {
                            First_Timer.GetComponent<RectTransform>().localPosition = new Vector3(First_Timer.GetComponent<RectTransform>().localPosition.x, First_Timer.GetComponent<RectTransform>().localPosition.y + 1f, First_Timer.transform.position.z);
                            button_h.GetComponent<RectTransform>().localPosition = new Vector3(button_h.GetComponent<RectTransform>().localPosition.x + 1f, button_h.GetComponent<RectTransform>().localPosition.y, button_h.transform.position.z);
                            button_g.GetComponent<RectTransform>().localPosition = new Vector3(button_g.GetComponent<RectTransform>().localPosition.x - 1f, button_g.GetComponent<RectTransform>().localPosition.y, button_g.transform.position.z);
                        }

                        else
                        {
                            First_Timer.GetComponent<RectTransform>().localPosition = new Vector3(First_Timer.GetComponent<RectTransform>().localPosition.x, First_Timer.GetComponent<RectTransform>().localPosition.y, First_Timer.transform.position.z);
                            button_h.GetComponent<RectTransform>().localPosition = new Vector3(button_h.GetComponent<RectTransform>().localPosition.x, button_h.GetComponent<RectTransform>().localPosition.y, button_h.transform.position.z);
                            button_g.GetComponent<RectTransform>().localPosition = new Vector3(button_g.GetComponent<RectTransform>().localPosition.x, button_g.GetComponent<RectTransform>().localPosition.y, button_g.transform.position.z);
                        }

                        if (First_Timer.GetComponent<RectTransform>().localPosition.y == -230)
                        {
                            step = -1;
                        }
                    }

                    else
                    {
                        step = -1;
                    }
                }

                if (step == -1)
                {
                    if (Player_Score01.GetComponent<RectTransform>().localPosition.x == -150)
                    {
                        if (!StopGame)
                        {
                            Player01.GetComponent<Image>().color = new Color(Player01.GetComponent<Image>().color.r, Player01.GetComponent<Image>().color.g, Player01.GetComponent<Image>().color.b, Player01.GetComponent<Image>().color.a + 0.005f);
                            Player02.GetComponent<Image>().color = new Color(Player02.GetComponent<Image>().color.r, Player02.GetComponent<Image>().color.g, Player02.GetComponent<Image>().color.b, Player02.GetComponent<Image>().color.a + 0.005f);
                            Player011.GetComponent<Image>().color = new Color(Player011.GetComponent<Image>().color.r, Player011.GetComponent<Image>().color.g, Player011.GetComponent<Image>().color.b, Player011.GetComponent<Image>().color.a + 0.005f);
                            Player022.GetComponent<Image>().color = new Color(Player022.GetComponent<Image>().color.r, Player022.GetComponent<Image>().color.g, Player022.GetComponent<Image>().color.b, Player022.GetComponent<Image>().color.a + 0.005f);
                            Player_Winner01.GetComponent<Image>().color = new Color(Player_Winner01.GetComponent<Image>().color.r, Player_Winner01.GetComponent<Image>().color.g, Player_Winner01.GetComponent<Image>().color.b, Player_Winner01.GetComponent<Image>().color.a + 0.005f);
                            Player_Winner02.GetComponent<Image>().color = new Color(Player_Winner02.GetComponent<Image>().color.r, Player_Winner02.GetComponent<Image>().color.g, Player_Winner02.GetComponent<Image>().color.b, Player_Winner02.GetComponent<Image>().color.a + 0.005f);
                            Player_WinCount01.GetComponent<Image>().color = new Color(Player_WinCount01.GetComponent<Image>().color.r, Player_WinCount01.GetComponent<Image>().color.g, Player_WinCount01.GetComponent<Image>().color.b, Player_WinCount01.GetComponent<Image>().color.a + 0.005f);
                            Player_WinCount02.GetComponent<Image>().color = new Color(Player_WinCount02.GetComponent<Image>().color.r, Player_WinCount02.GetComponent<Image>().color.g, Player_WinCount02.GetComponent<Image>().color.b, Player_WinCount02.GetComponent<Image>().color.a + 0.005f);
                        }

                        else
                        {
                            Player01.GetComponent<Image>().color = new Color(Player01.GetComponent<Image>().color.r, Player01.GetComponent<Image>().color.g, Player01.GetComponent<Image>().color.b, Player01.GetComponent<Image>().color.a);
                            Player02.GetComponent<Image>().color = new Color(Player02.GetComponent<Image>().color.r, Player02.GetComponent<Image>().color.g, Player02.GetComponent<Image>().color.b, Player02.GetComponent<Image>().color.a);
                            Player011.GetComponent<Image>().color = new Color(Player011.GetComponent<Image>().color.r, Player011.GetComponent<Image>().color.g, Player011.GetComponent<Image>().color.b, Player011.GetComponent<Image>().color.a);
                            Player022.GetComponent<Image>().color = new Color(Player022.GetComponent<Image>().color.r, Player022.GetComponent<Image>().color.g, Player022.GetComponent<Image>().color.b, Player022.GetComponent<Image>().color.a);
                            Player_Winner01.GetComponent<Image>().color = new Color(Player_Winner01.GetComponent<Image>().color.r, Player_Winner01.GetComponent<Image>().color.g, Player_Winner01.GetComponent<Image>().color.b, Player_Winner01.GetComponent<Image>().color.a);
                            Player_Winner02.GetComponent<Image>().color = new Color(Player_Winner02.GetComponent<Image>().color.r, Player_Winner02.GetComponent<Image>().color.g, Player_Winner02.GetComponent<Image>().color.b, Player_Winner02.GetComponent<Image>().color.a);
                            Player_WinCount01.GetComponent<Image>().color = new Color(Player_WinCount01.GetComponent<Image>().color.r, Player_WinCount01.GetComponent<Image>().color.g, Player_WinCount01.GetComponent<Image>().color.b, Player_WinCount01.GetComponent<Image>().color.a);
                            Player_WinCount02.GetComponent<Image>().color = new Color(Player_WinCount02.GetComponent<Image>().color.r, Player_WinCount02.GetComponent<Image>().color.g, Player_WinCount02.GetComponent<Image>().color.b, Player_WinCount02.GetComponent<Image>().color.a);
                        }

                        if (Player01.GetComponent<Image>().color.a > 1)
                            step = 1;
                    }

                    else
                    {
                        if (!StopGame)
                        {
                            Player_Score01.GetComponent<RectTransform>().localPosition = new Vector3(Player_Score01.GetComponent<RectTransform>().localPosition.x + 0.5f, 201, 0);
                            Player_Score02.GetComponent<RectTransform>().localPosition = new Vector3(Player_Score02.GetComponent<RectTransform>().localPosition.x - 0.5f, 201, 0);
                            Stage.GetComponent<RectTransform>().localPosition = new Vector3(0, Stage.GetComponent<RectTransform>().localPosition.y - 0.5f, 0);
                            Stage_Type.GetComponent<RectTransform>().localPosition = new Vector3(-27, Stage_Type.GetComponent<RectTransform>().localPosition.y - 0.5f, 0);

                            if (Main_Scene.Language == 2)
                                Stage_Number.GetComponent<RectTransform>().localPosition = new Vector3(60, Stage_Number.GetComponent<RectTransform>().localPosition.y - 0.5f, 0);

                            else
                                Stage_Number.GetComponent<RectTransform>().localPosition = new Vector3(80, Stage_Number.GetComponent<RectTransform>().localPosition.y - 0.5f, 0);
                        }

                        else
                        {
                            Player_Score01.GetComponent<RectTransform>().localPosition = new Vector3(Player_Score01.GetComponent<RectTransform>().localPosition.x, 201, 0);
                            Player_Score02.GetComponent<RectTransform>().localPosition = new Vector3(Player_Score02.GetComponent<RectTransform>().localPosition.x, 201, 0);
                            Stage.GetComponent<RectTransform>().localPosition = new Vector3(0, Stage.GetComponent<RectTransform>().localPosition.y, 0);
                            Stage_Type.GetComponent<RectTransform>().localPosition = new Vector3(Stage_Type.GetComponent<RectTransform>().localPosition.x, Stage_Type.GetComponent<RectTransform>().localPosition.y, 0);
                            Stage_Number.GetComponent<RectTransform>().localPosition = new Vector3(Stage_Number.GetComponent<RectTransform>().localPosition.x, Stage_Number.GetComponent<RectTransform>().localPosition.y, 0);
                        }
                    }
                }

                if (step == 1) //이미지 등장의 위치를 정함
                {
                    Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(400, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                    Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(-400, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                    Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(720, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);

                    step = 2;
                }

                if (step == 2) //등장하는 이미지
                {
                    Player_Line_Up.GetComponent<Image>().sprite = GameImage[4];
                    Player_Line_Down.GetComponent<Image>().sprite = GameImage[5];

                    TypeSaid(6);

                    if (!StopGame)
                    {
                        Back.GetComponent<Image>().color = new Color(Back.GetComponent<Image>().color.r, Back.GetComponent<Image>().color.g, Back.GetComponent<Image>().color.b, Back.GetComponent<Image>().color.a + 0.1f);
                        Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x - 5, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                        Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x + 5, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                        Player_Typing.GetComponent<Image>().color = new Color(Player_Typing.GetComponent<Image>().color.r, Player_Typing.GetComponent<Image>().color.g, Player_Typing.GetComponent<Image>().color.b, 1);
                        Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(Player_Typing.GetComponent<RectTransform>().localPosition.x - 9, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);
                    }

                    else
                    {
                        Back.GetComponent<Image>().color = new Color(Back.GetComponent<Image>().color.r, Back.GetComponent<Image>().color.g, Back.GetComponent<Image>().color.b, Back.GetComponent<Image>().color.a);
                        Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                        Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                        Player_Typing.GetComponent<Image>().color = new Color(Player_Typing.GetComponent<Image>().color.r, Player_Typing.GetComponent<Image>().color.g, Player_Typing.GetComponent<Image>().color.b, 1);
                        Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(Player_Typing.GetComponent<RectTransform>().localPosition.x, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);
                    }

                    if (Player_Line_Up.GetComponent<RectTransform>().localPosition.x == 0)
                    {
                        MusicSource.SFXCHOOSE = true;
                        MusicSource.SFX[5] = true;
                        MusicSource.SE_volume = 1f;
                        step = 3;
                    }
                }

                //늘어나는 문자(세팅 중..)
                if (step == 3)
                {
                    if (!StopGame)
                    {
                        Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x - 0.005f, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                        Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x + 0.005f, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                        Player_Typing.GetComponent<RectTransform>().transform.localScale = new Vector3(Player_Typing.GetComponent<RectTransform>().transform.localScale.x + 0.00005f, Player_Typing.GetComponent<RectTransform>().transform.localScale.y + 0.00005f, Player_Typing.GetComponent<RectTransform>().transform.localScale.z);
                    }

                    else
                    {
                        Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                        Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                        Player_Typing.GetComponent<RectTransform>().transform.localScale = new Vector3(Player_Typing.GetComponent<RectTransform>().transform.localScale.x, Player_Typing.GetComponent<RectTransform>().transform.localScale.y, Player_Typing.GetComponent<RectTransform>().transform.localScale.z);
                    }

                    if (Player_Typing.GetComponent<RectTransform>().transform.localScale.y > 0.57f)
                    {
                        if (Main_Scene.Selected_stage[0] == 0) //가림막 모드가 아니라면 4번 진행
                            step = 4;

                        else if (Main_Scene.Selected_stage[0] == 1) //가림막 모드면 8번 진행
                            step = 8;
                    }
                }

                //재위치
                if (step == 4)
                {

                    if (!StopGame)
                    {
                        Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x - 0.005f, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                        Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x + 0.005f, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                        Card.AnswerBack.GetComponent<Image>().color = new Color(Card.AnswerBack.GetComponent<Image>().color.r, Card.AnswerBack.GetComponent<Image>().color.g, Card.AnswerBack.GetComponent<Image>().color.b, Card.AnswerBack.GetComponent<Image>().color.a + 0.001f);
                    }

                    else
                    {
                        Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                        Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                        Card.AnswerBack.GetComponent<Image>().color = new Color(Card.AnswerBack.GetComponent<Image>().color.r, Card.AnswerBack.GetComponent<Image>().color.g, Card.AnswerBack.GetComponent<Image>().color.b, Card.AnswerBack.GetComponent<Image>().color.a);
                    }

                    if (Player_Typing.GetComponent<RectTransform>().localPosition.x == -720)
                    {
                        Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(720, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);

                        TypeSaid(9);
                        step = 5;
                    }

                    else
                    {
                        if (!StopGame)
                            Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(Player_Typing.GetComponent<RectTransform>().localPosition.x - 4.5f, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);

                        else
                            Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(Player_Typing.GetComponent<RectTransform>().localPosition.x, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);
                    }
                }

                //다시 나타나는 문자(게임 시작!)
                if (step == 5)
                {
                    if (!StopGame)
                    {
                        Card.AnswerBack.GetComponent<Image>().color = new Color(Card.AnswerBack.GetComponent<Image>().color.r, Card.AnswerBack.GetComponent<Image>().color.g, Card.AnswerBack.GetComponent<Image>().color.b, Card.AnswerBack.GetComponent<Image>().color.a + 0.001f);
                        Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x - 0.005f, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                        Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x + 0.005f, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                    }

                    else
                    {
                        Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                        Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                        Card.AnswerBack.GetComponent<Image>().color = new Color(Card.AnswerBack.GetComponent<Image>().color.r, Card.AnswerBack.GetComponent<Image>().color.g, Card.AnswerBack.GetComponent<Image>().color.b, Card.AnswerBack.GetComponent<Image>().color.a);
                    }

                    if (Player_Typing.GetComponent<RectTransform>().localPosition.x == 0)
                    {
                        MusicSource.SFXCHOOSE = true;
                        MusicSource.SFX[5] = true;
                        MusicSource.SE_volume = 1f;
                        MusicSource.SFXCHOOSE2 = true;
                        MusicSource.SFX2[0] = true;
                        MusicSource.SE2_volume = 1f;
                        step = 6;
                    }

                    else
                    {
                        if (Main_Scene.Selected_stage[1] == 1)
                        {
                            Card.Lightmode = true;
                            LightStart = true;
                        }

                        if (!StopGame)
                            Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(Player_Typing.GetComponent<RectTransform>().localPosition.x - 4.5f, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);

                        else
                            Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(Player_Typing.GetComponent<RectTransform>().localPosition.x, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);
                    }
                }

                //늘어나는 문자
                if (step == 6)
                {
                    if (!StopGame)
                    {
                        Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x - 0.005f, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                        Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x + 0.005f, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                        Player_Typing.GetComponent<RectTransform>().transform.localScale = new Vector3(Player_Typing.GetComponent<RectTransform>().transform.localScale.x + 0.00005f, Player_Typing.GetComponent<RectTransform>().transform.localScale.y + 0.00005f, Player_Typing.GetComponent<RectTransform>().transform.localScale.z);
                        Card.AnswerBack.GetComponent<Image>().color = new Color(Card.AnswerBack.GetComponent<Image>().color.r, Card.AnswerBack.GetComponent<Image>().color.g, Card.AnswerBack.GetComponent<Image>().color.b, Card.AnswerBack.GetComponent<Image>().color.a + 0.001f);
                    }

                    else
                    {
                        Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                        Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                        Player_Typing.GetComponent<RectTransform>().transform.localScale = new Vector3(Player_Typing.GetComponent<RectTransform>().transform.localScale.x, Player_Typing.GetComponent<RectTransform>().transform.localScale.y, Player_Typing.GetComponent<RectTransform>().transform.localScale.z);
                        Card.AnswerBack.GetComponent<Image>().color = new Color(Card.AnswerBack.GetComponent<Image>().color.r, Card.AnswerBack.GetComponent<Image>().color.g, Card.AnswerBack.GetComponent<Image>().color.b, Card.AnswerBack.GetComponent<Image>().color.a);

                    }

                    if (Player_Typing.GetComponent<RectTransform>().transform.localScale.y > 0.6f)
                    {
                        if((Main_Scene.Player_2_WinCount + Main_Scene.Player_1_WinCount + 1) == 1)
                        {
                            MusicSource.step = 0;
                            MusicSource.Looptime = 54.85f;
                            MusicSource.volume = 1f;
                        }

                        if ((Main_Scene.Selected_stage[0] == 1) && (!Challenge.Ch))
                        {
                            MusicSource.step = 0;
                            MusicSource.Looptime = 54.85f;
                            MusicSource.volume = 1f;
                        }

                        step = 7;
                    }
                }

                //재위치
                if (step == 7)
                {
                    if (Player_Typing.GetComponent<RectTransform>().localPosition.x == -720)
                    {
                        Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(400, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                        Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(-400, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                        Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(15400, 0, 0);

                        step = 0;
                        Main_Scene.Start_Game_Button = false;
                        Game_Start = true;
                        timer_stop = false;
                        LightStart = false;
                    }

                    else
                    {
                        if (!StopGame)
                        {
                            Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x - 5f, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                            Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x + 5f, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                            Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(Player_Typing.GetComponent<RectTransform>().localPosition.x - 9f, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);
                        }

                        else
                        {
                            Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                            Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                            Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(Player_Typing.GetComponent<RectTransform>().localPosition.x, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);
                        }
                    }
                }

                //재위치
                if (step == 8)
                {
                    if (Player_Typing.GetComponent<RectTransform>().localPosition.x == -720)
                    {
                        Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(400, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                        Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(-400, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                        Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(720, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);

                        TypeSaid(9);

                        button_h.GetComponent<Image>().sprite = but[4];
                        Check_timer = 1;
                        step = 9;

                    }

                    else
                    {
                        if (!StopGame)
                        {
                            Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x - 5f, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                            Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x + 5f, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                            Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(Player_Typing.GetComponent<RectTransform>().localPosition.x - 9f, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);
                        }

                        else
                        {
                            Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                            Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                            Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(Player_Typing.GetComponent<RectTransform>().localPosition.x, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);
                        }
                    }
                }

                if (step == 9)
                {
                    if (button_h.GetComponent<RectTransform>().localPosition.x == 0)
                    {
                        MusicSource.Clocking = true;
                        step = 10;
                    }

                    else
                    {
                        if (!StopGame)
                            button_h.GetComponent<RectTransform>().localPosition = new Vector3(button_h.GetComponent<RectTransform>().localPosition.x + 6, button_h.GetComponent<RectTransform>().localPosition.y, button_h.transform.position.z);

                        else
                            button_h.GetComponent<RectTransform>().localPosition = new Vector3(button_h.GetComponent<RectTransform>().localPosition.x, button_h.GetComponent<RectTransform>().localPosition.y, button_h.transform.position.z);
                    }
                }

                //시간재기
                if (step == 10)
                {
                    Check_timer -= Time.deltaTime / 750;
                    BecomeInvisible();

                    //타이머 종료 시 탈출
                    if (Check_timer < 0)
                    {
                        MusicSource.ClockingOff = true;
                        button_h.GetComponent<RectTransform>().localPosition = new Vector3(-240, button_h.GetComponent<RectTransform>().localPosition.y, button_h.GetComponent<RectTransform>().localPosition.z);
                        this.button_h.GetComponent<Image>().fillAmount = 1;
                        timer_stop = true;
                        starting_number = 0;
                        step = 11;
                    }
                }

                if (step == 11)
                {
                    if (Card.LastWinner == 0 || Card.LastWinner == 2)
                    {
                        Player = 1;

                        if (Main_Scene.Language == 1)
                        {
                            button_h.GetComponent<Image>().sprite = but[0];
                            button_g.GetComponent<Image>().sprite = but[1];
                        }

                        else if (Main_Scene.Language == 2)
                        {
                            button_h.GetComponent<Image>().sprite = but[32];
                            button_g.GetComponent<Image>().sprite = but[33];
                        }

                        else if (Main_Scene.Language == 3)
                        {
                            button_h.GetComponent<Image>().sprite = but[42];
                            button_g.GetComponent<Image>().sprite = but[43];
                        }

                        First_Timer.GetComponent<Image>().sprite = but[4];
                    }

                    else if (Card.LastWinner == 1)
                    {
                        Player = 2;

                        if (Main_Scene.Language == 1)
                        {
                            button_h.GetComponent<Image>().sprite = but[2];
                            button_g.GetComponent<Image>().sprite = but[3];
                        }

                        else if (Main_Scene.Language == 2)
                        {
                            button_h.GetComponent<Image>().sprite = but[34];
                            button_g.GetComponent<Image>().sprite = but[35];
                        }

                        else if (Main_Scene.Language == 3)
                        {
                            button_h.GetComponent<Image>().sprite = but[44];
                            button_g.GetComponent<Image>().sprite = but[45];
                        }

                        First_Timer.GetComponent<Image>().sprite = but[5];
                    }

                    Invisible = true;
                    step = 12;
                }

                if (step == 12)
                {
                    if (!StopGame)
                    {
                        First_Timer.GetComponent<RectTransform>().localPosition = new Vector3(First_Timer.GetComponent<RectTransform>().localPosition.x, First_Timer.GetComponent<RectTransform>().localPosition.y + 1f, First_Timer.transform.position.z);
                        button_h.GetComponent<RectTransform>().localPosition = new Vector3(button_h.GetComponent<RectTransform>().localPosition.x + 1f, button_h.GetComponent<RectTransform>().localPosition.y, button_h.transform.position.z);
                        button_g.GetComponent<RectTransform>().localPosition = new Vector3(button_g.GetComponent<RectTransform>().localPosition.x - 1f, button_g.GetComponent<RectTransform>().localPosition.y, button_g.transform.position.z);
                        Back.GetComponent<Image>().color = new Color(Back.GetComponent<Image>().color.r, Back.GetComponent<Image>().color.g, Back.GetComponent<Image>().color.b, Back.GetComponent<Image>().color.a + 0.01f);
                    }

                    else
                    {
                        First_Timer.GetComponent<RectTransform>().localPosition = new Vector3(First_Timer.GetComponent<RectTransform>().localPosition.x, First_Timer.GetComponent<RectTransform>().localPosition.y, First_Timer.transform.position.z);
                        button_h.GetComponent<RectTransform>().localPosition = new Vector3(button_h.GetComponent<RectTransform>().localPosition.x, button_h.GetComponent<RectTransform>().localPosition.y, button_h.transform.position.z);
                        button_g.GetComponent<RectTransform>().localPosition = new Vector3(button_g.GetComponent<RectTransform>().localPosition.x, button_g.GetComponent<RectTransform>().localPosition.y, button_g.transform.position.z);
                        Back.GetComponent<Image>().color = new Color(Back.GetComponent<Image>().color.r, Back.GetComponent<Image>().color.g, Back.GetComponent<Image>().color.b, Back.GetComponent<Image>().color.a);
                    }

                    if (First_Timer.GetComponent<RectTransform>().localPosition.y == -230)
                        step = 13;
                }

                if (step == 13)
                {
                    Player_Line_Up.GetComponent<Image>().sprite = GameImage[4];
                    Player_Line_Down.GetComponent<Image>().sprite = GameImage[5];

                    if (!StopGame)
                    {
                        Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x - 5, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                        Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x + 5, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                        Player_Typing.GetComponent<Image>().color = new Color(Player_Typing.GetComponent<Image>().color.r, Player_Typing.GetComponent<Image>().color.g, Player_Typing.GetComponent<Image>().color.b, 1);
                        Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(Player_Typing.GetComponent<RectTransform>().localPosition.x - 9, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);
                    }

                    else
                    {
                        Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                        Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                        Player_Typing.GetComponent<Image>().color = new Color(Player_Typing.GetComponent<Image>().color.r, Player_Typing.GetComponent<Image>().color.g, Player_Typing.GetComponent<Image>().color.b, 1);
                        Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(Player_Typing.GetComponent<RectTransform>().localPosition.x, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);
                    }

                    if (Main_Scene.Selected_stage[1] == 1)
                    {
                        Card.Lightmode = true;
                        LightStart = true;
                    }

                    if (Player_Line_Up.GetComponent<RectTransform>().localPosition.x == 0)
                    {
                        MusicSource.SFXCHOOSE = true;
                        MusicSource.SFX[5] = true;
                        MusicSource.SE_volume = 0.7f;
                        step = 6;
                    }
                }
            }

            if (!Card.Finish)
            {
                //0번. 합과 결 버튼 중 하나를 눌렀을 때
                if (Timer_Check)
                {
                    Card.HintFade = 0;
                    Card.Hint.GetComponent<RectTransform>().localPosition = new Vector3(518, -144);
                    Card.Hint.GetComponent<Image>().color = new Color(Card.Hint.GetComponent<Image>().color.r, Card.Hint.GetComponent<Image>().color.g, Card.Hint.GetComponent<Image>().color.b, 0);


                    //1번. 합을 맨 처음에 눌렀을 때
                    if (Buttonclick == 1)
                    {
                        if (step == 0)
                        {
                            if (!StopGame)
                            {
                                button_h.GetComponent<RectTransform>().localPosition = new Vector3(button_h.GetComponent<RectTransform>().localPosition.x + 20, button_h.GetComponent<RectTransform>().localPosition.y, button_h.transform.position.z);
                                button_g.GetComponent<RectTransform>().localPosition = new Vector3(button_g.GetComponent<RectTransform>().localPosition.x + 40, button_g.GetComponent<RectTransform>().localPosition.y, button_g.transform.position.z);
                                First_Timer.GetComponent<RectTransform>().localPosition = new Vector3(First_Timer.GetComponent<RectTransform>().localPosition.x, First_Timer.GetComponent<RectTransform>().localPosition.y - 40, First_Timer.transform.position.z);
                            }

                            else
                            {
                                button_h.GetComponent<RectTransform>().localPosition = new Vector3(button_h.GetComponent<RectTransform>().localPosition.x, button_h.GetComponent<RectTransform>().localPosition.y, button_h.transform.position.z);
                                button_g.GetComponent<RectTransform>().localPosition = new Vector3(button_g.GetComponent<RectTransform>().localPosition.x, button_g.GetComponent<RectTransform>().localPosition.y, button_g.transform.position.z);
                                First_Timer.GetComponent<RectTransform>().localPosition = new Vector3(First_Timer.GetComponent<RectTransform>().localPosition.x, First_Timer.GetComponent<RectTransform>().localPosition.y, First_Timer.transform.position.z);
                            }

                            if (GetComponent<RectTransform>().localPosition.x == 0)
                            {
                                NowButtonclick = 2;
                                step = 1;
                            }
                        }

                        if (step == 1)
                        {
                            this.ChangeSpeed = 50;

                            if (this.transform.eulerAngles.y > 90)
                            {
                                transform.Rotate(0, 260f, 0);
                                this.ChangeSpeed = 0;
                                timeCount = 10;
                                step = 0;
                                MusicSource.Clocking = true;
                                Buttonclick = 2;
                            }

                            else
                            {
                                transform.Rotate(0, this.ChangeSpeed, 0);
                                this.ChangeSpeed *= 0.1f;
                            }

                            if (Player == 1)
                            {
                                button_h.GetComponent<Image>().sprite = but[4];
                            }

                            else
                            {
                                button_h.GetComponent<Image>().sprite = but[5];
                            }
                        }
                    }

                    //2번. 합 버튼을 누르고 바로 시간을 센다. 이 때 합 3개를 누르게 한다.
                    if (Buttonclick == 2)
                    {
                        if (step == 0)
                        {
                            //15초 타이머
                            timeCount -= Time.deltaTime;
                            DecreaseTime_H();

                            //타이머 종료 시 3번으로 이동
                            if (timeCount < 0)
                            {
                                MusicSource.ClockingOff = true;
                                timer_stop = true;
                                choose_card = 0;
                                NowButtonclick = 0;
                                step = 0;
                                Buttonclick = 21;
                            }

                            //타이머가 종료되기 전에 3개를 선택하면 넘어가는 스크립트를 작성해야한다.
                            else
                            {
                                if (choose_card == 3) //모두 차게 된다면
                                {
                                    step = 1;
                                }
                            }
                        }

                        if (step == 1)
                        {
                            NowButtonclick = 0;
                            Card.Choosefinished = true; //합인지 확인한다.
                            MusicSource.ClockingOff = true;

                            for (int i = 0; i < 3; i++)
                                Card.Position[Choose[i]].GetComponent<Image>().color = new Color(0, 0, 0, 0);

                            if (Card.find) //합인지 확인이 끝났을 경우
                            {
                                step = 0;
                                Card.find = false; //합을 구하고 결과가 나옴
                                choose_card = 0; //

                                if (!Card.Haap)
                                    Buttonclick = 22;

                                else
                                {
                                    //4*4모드일 때 전체가지가 15개가 넘고, 찾은 개수가 딱 15개가 되었다면?
                                    if (Main_Scene.Selected_stage[2] == 1)
                                    {
                                        if (Card.Allnumber + Card.Hap > 15)
                                        {
                                            if (Card.Allnumber == 15)
                                            {
                                                Buttonclick = 24;
                                            }

                                            else
                                            {
                                                Buttonclick = 23;
                                            }
                                        }

                                        else
                                        {
                                            Buttonclick = 23;
                                        }
                                    }

                                    else
                                    {
                                        Buttonclick = 23;
                                    }
                                }
                            }
                        }
                    }

                    //합을 누르고 타이머가 종료되어버린 이미지 진행
                    if (Buttonclick == 21)
                    {
                        if (step == 0) //이미지 등장의 위치를 정함
                        {
                            Card.FailAnswer++;
                            Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(400, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                            Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(-400, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                            Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(720, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);

                            MusicSource.SFXCHOOSE = true;
                            MusicSource.SFX[5] = true;
                            MusicSource.SE_volume = 0.7f;
                            MusicSource.SFXCHOOSE2 = true;
                            MusicSource.SFX2[2] = true;
                            MusicSource.SE2_volume = 0.7f;
                            step = 1;
                        }

                        if (step == 1) //등장하는 이미지
                        {
                            if (Player == 1)
                            {
                                Player_Line_Up.GetComponent<Image>().sprite = GameImage[0];
                                Player_Line_Down.GetComponent<Image>().sprite = GameImage[1];
                            }

                            else
                            {
                                Player_Line_Up.GetComponent<Image>().sprite = GameImage[2];
                                Player_Line_Down.GetComponent<Image>().sprite = GameImage[3];
                            }

                            TypeSaid(15);

                            if (!StopGame)
                            {
                                Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x - 100, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                                Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x + 100, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                                Player_Typing.GetComponent<Image>().color = new Color(Player_Typing.GetComponent<Image>().color.r, Player_Typing.GetComponent<Image>().color.g, Player_Typing.GetComponent<Image>().color.b, 1);
                                Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(Player_Typing.GetComponent<RectTransform>().localPosition.x - 180, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);
                            }

                            else
                            {
                                Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                                Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                                Player_Typing.GetComponent<Image>().color = new Color(Player_Typing.GetComponent<Image>().color.r, Player_Typing.GetComponent<Image>().color.g, Player_Typing.GetComponent<Image>().color.b, 1);
                                Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(Player_Typing.GetComponent<RectTransform>().localPosition.x, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);
                            }

                            if (Player_Line_Up.GetComponent<RectTransform>().localPosition.x == 0)
                                step = 2;
                        }

                        //늘어나는 문자
                        if (step == 2)
                        {
                            if (!StopGame)
                            {
                                Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x - 0.4f, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                                Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x + 0.4f, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                                Player_Typing.GetComponent<RectTransform>().transform.localScale = new Vector3(Player_Typing.GetComponent<RectTransform>().transform.localScale.x + 0.002f, Player_Typing.GetComponent<RectTransform>().transform.localScale.y + 0.002f, Player_Typing.GetComponent<RectTransform>().transform.localScale.z);
                            }

                            else
                            {
                                Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                                Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                                Player_Typing.GetComponent<RectTransform>().transform.localScale = new Vector3(Player_Typing.GetComponent<RectTransform>().transform.localScale.x, Player_Typing.GetComponent<RectTransform>().transform.localScale.y, Player_Typing.GetComponent<RectTransform>().transform.localScale.z);
                            }

                            if (Player_Typing.GetComponent<RectTransform>().transform.localScale.y > 0.57f)
                                step = 3;
                        }

                        //사라진 뒤 재위치
                        if (step == 3)
                        {
                            if (Player_Typing.GetComponent<RectTransform>().localPosition.x == -720)
                            {
                                Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(400, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                                Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(-400, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                                Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(720, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);
                                MusicSource.SFXCHOOSE = true;
                                MusicSource.SFX[5] = true;
                                MusicSource.SE_volume = 0.7f;
                                step = 4;
                            }

                            else
                            {
                                if (!StopGame)
                                {
                                    Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x - 100, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                                    Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x + 100, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                                    Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(Player_Typing.GetComponent<RectTransform>().localPosition.x - 180, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);
                                }

                                else
                                {
                                    Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                                    Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                                    Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(Player_Typing.GetComponent<RectTransform>().localPosition.x, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);
                                }

                            }
                        }

                        if (step == 4) //등장하는 이미지(다음 차례!와 이미지들)
                        {
                            if (Player == 1)
                            {
                                Player_Line_Up.GetComponent<Image>().sprite = GameImage[2];
                                Player_Line_Down.GetComponent<Image>().sprite = GameImage[3];
                            }

                            else
                            {
                                Player_Line_Up.GetComponent<Image>().sprite = GameImage[0];
                                Player_Line_Down.GetComponent<Image>().sprite = GameImage[1];
                            }

                            TypeSaid(14);
                            

                            if (!StopGame)
                            {
                                Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x - 100, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                                Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x + 100, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                                Player_Typing.GetComponent<Image>().color = new Color(Player_Typing.GetComponent<Image>().color.r, Player_Typing.GetComponent<Image>().color.g, Player_Typing.GetComponent<Image>().color.b, 1);
                                Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(Player_Typing.GetComponent<RectTransform>().localPosition.x - 180, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);
                            }

                            else
                            {
                                Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                                Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                                Player_Typing.GetComponent<Image>().color = new Color(Player_Typing.GetComponent<Image>().color.r, Player_Typing.GetComponent<Image>().color.g, Player_Typing.GetComponent<Image>().color.b, 1);
                                Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(Player_Typing.GetComponent<RectTransform>().localPosition.x, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);
                            }

                            if (Player_Line_Up.GetComponent<RectTransform>().localPosition.x == 0)
                                step = 5;
                        }

                        //늘어나는 문자
                        if (step == 5)
                        {
                            if (!StopGame)
                            {
                                Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x - 0.2f, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                                Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x + 0.2f, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                                Player_Typing.GetComponent<RectTransform>().transform.localScale = new Vector3(Player_Typing.GetComponent<RectTransform>().transform.localScale.x + 0.002f, Player_Typing.GetComponent<RectTransform>().transform.localScale.y + 0.002f, Player_Typing.GetComponent<RectTransform>().transform.localScale.z);
                            }

                            else
                            {
                                Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                                Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                                Player_Typing.GetComponent<RectTransform>().transform.localScale = new Vector3(Player_Typing.GetComponent<RectTransform>().transform.localScale.x, Player_Typing.GetComponent<RectTransform>().transform.localScale.y, Player_Typing.GetComponent<RectTransform>().transform.localScale.z);

                            }

                            if (Player_Typing.GetComponent<RectTransform>().transform.localScale.y > 0.57f)
                                step = 6;
                        }

                        //사라진 뒤 재위치(문자)
                        if (step == 6)
                        {
                            if (!StopGame)
                            {
                                Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x - 0.2f, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                                Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x + 0.2f, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                            }

                            else
                            {
                                Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                                Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                            }

                            if (Player_Typing.GetComponent<RectTransform>().localPosition.x == -720)
                            {
                                Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(720, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);
                                step = 7;
                            }

                            else
                            {
                                if (!StopGame)
                                    Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(Player_Typing.GetComponent<RectTransform>().localPosition.x - 180, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);

                                else
                                    Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(Player_Typing.GetComponent<RectTransform>().localPosition.x, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);
                            }
                        }

                        if (step == 7) //등장하는 이미지(플레이어 등장)
                        {
                            if (Player == 1)
                                TypeSaid(8);

                            else
                                TypeSaid(7);

                            if (!StopGame)
                            {
                                Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x - 0.2f, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                                Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x + 0.2f, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                                Player_Typing.GetComponent<Image>().color = new Color(Player_Typing.GetComponent<Image>().color.r, Player_Typing.GetComponent<Image>().color.g, Player_Typing.GetComponent<Image>().color.b, 1);
                                Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(Player_Typing.GetComponent<RectTransform>().localPosition.x - 180, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);
                            }

                            else
                            {
                                Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                                Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                                Player_Typing.GetComponent<Image>().color = new Color(Player_Typing.GetComponent<Image>().color.r, Player_Typing.GetComponent<Image>().color.g, Player_Typing.GetComponent<Image>().color.b, 1);
                                Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(Player_Typing.GetComponent<RectTransform>().localPosition.x, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);
                            }

                            if (Player_Typing.GetComponent<RectTransform>().localPosition.x == 0)
                            {
                                Move = 0;
                                step = 8;
                            }
                        }

                        //바뀌는 버튼
                        if (step == 8)
                        {
                            if (!StopGame)
                            {
                                Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x - 0.2f, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                                Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x + 0.2f, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                                Player_Typing.GetComponent<RectTransform>().transform.localScale = new Vector3(Player_Typing.GetComponent<RectTransform>().transform.localScale.x + 0.002f, Player_Typing.GetComponent<RectTransform>().transform.localScale.y + 0.002f, Player_Typing.GetComponent<RectTransform>().transform.localScale.z);
                            }

                            else
                            {
                                Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                                Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                                Player_Typing.GetComponent<RectTransform>().transform.localScale = new Vector3(Player_Typing.GetComponent<RectTransform>().transform.localScale.x, Player_Typing.GetComponent<RectTransform>().transform.localScale.y, Player_Typing.GetComponent<RectTransform>().transform.localScale.z);
                            }

                            if (Move == 1)
                            {
                                if (button_h.GetComponent<RectTransform>().localPosition.x == -100)
                                {
                                    if (Player_Typing.GetComponent<RectTransform>().transform.localScale.y > 0.57f)
                                    {
                                        Move = 0;

                                        //플레이어 변경
                                        if (Player == 1)
                                            Player = 2;
                                        else
                                            Player = 1;

                                        if (Main_Scene.Selected_stage[0] == 1)
                                            Invisible = true;

                                        step = 9;
                                    }
                                }

                                else
                                {
                                    button_h.GetComponent<Image>().fillAmount = 1;

                                    if (!StopGame)
                                    {
                                        button_h.GetComponent<RectTransform>().localPosition = new Vector3(button_h.GetComponent<RectTransform>().localPosition.x - 20, button_h.GetComponent<RectTransform>().localPosition.y, button_h.transform.position.z);
                                        button_g.GetComponent<RectTransform>().localPosition = new Vector3(button_g.GetComponent<RectTransform>().localPosition.x - 40, button_g.GetComponent<RectTransform>().localPosition.y, button_g.transform.position.z);
                                        First_Timer.GetComponent<RectTransform>().localPosition = new Vector3(First_Timer.GetComponent<RectTransform>().localPosition.x, First_Timer.GetComponent<RectTransform>().localPosition.y + 40, First_Timer.transform.position.z);
                                    }

                                    else
                                    {
                                        button_h.GetComponent<RectTransform>().localPosition = new Vector3(button_h.GetComponent<RectTransform>().localPosition.x, button_h.GetComponent<RectTransform>().localPosition.y, button_h.transform.position.z);
                                        button_g.GetComponent<RectTransform>().localPosition = new Vector3(button_g.GetComponent<RectTransform>().localPosition.x, button_g.GetComponent<RectTransform>().localPosition.y, button_g.transform.position.z);
                                        First_Timer.GetComponent<RectTransform>().localPosition = new Vector3(First_Timer.GetComponent<RectTransform>().localPosition.x, First_Timer.GetComponent<RectTransform>().localPosition.y, First_Timer.transform.position.z);
                                    }
                                }
                            }

                            else
                            {
                                this.ChangeSpeed = 50;

                                if (this.transform.eulerAngles.y > 90)
                                {
                                    this.button_h.GetComponent<Image>().fillAmount = 1;
                                    transform.Rotate(0, 260f, 0);
                                    this.ChangeSpeed = 0;
                                    timeCount = 0.5f;
                                    Move = 1;
                                }

                                else
                                {
                                    transform.Rotate(0, this.ChangeSpeed, 0);
                                    this.ChangeSpeed *= 0.1f;
                                }

                                ButtonChange();
                            }
                        }

                        //사라진 뒤 재위치
                        if (step == 9)
                        {
                            if (Player_Typing.GetComponent<RectTransform>().localPosition.x == -720)
                            {
                                Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(400, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                                Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(-400, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                                Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(720, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);
                                step = 0;
                                Stop_Timer = false;
                                Timer_Check = false;
                                Card.find = false;
                                timer_stop = false;
                                Card.Choosefinished = false;
                                Buttonclick = 0;

                                if (Card.FailAnswer >= 5)
                                    Card.ShowHint = true;
                            }

                            else
                            {
                                if (!StopGame)
                                {
                                    Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x - 100, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                                    Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x + 100, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                                    Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(Player_Typing.GetComponent<RectTransform>().localPosition.x - 180, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);
                                }

                                else
                                {
                                    Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                                    Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                                    Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(Player_Typing.GetComponent<RectTransform>().localPosition.x, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);
                                }
                            }
                        }

                    }

                    //합을 눌러서 실패한 경우
                    if (Buttonclick == 22)
                    {
                        if (step == 0) //이미지 등장의 위치를 정함
                        {
                            Card.FailAnswer++;
                            Score();
                            Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(400, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                            Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(-400, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                            Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(720, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);

                            MusicSource.SFXCHOOSE = true;
                            MusicSource.SFX[5] = true;
                            MusicSource.SE_volume = 0.7f;
                            MusicSource.SFXCHOOSE2 = true;
                            MusicSource.SFX2[2] = true;
                            MusicSource.SE2_volume = 0.7f;
                            step = 1;
                        }

                        if (step == 1) //등장하는 이미지 [실패]
                        {
                            Player_Line_Up.GetComponent<Image>().sprite = GameImage[4];
                            Player_Line_Down.GetComponent<Image>().sprite = GameImage[5];

                            TypeSaid(11);

                            if (!StopGame)
                            {
                                Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x - 100, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                                Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x + 100, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                                Player_Typing.GetComponent<Image>().color = new Color(Player_Typing.GetComponent<Image>().color.r, Player_Typing.GetComponent<Image>().color.g, Player_Typing.GetComponent<Image>().color.b, 1);
                                Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(Player_Typing.GetComponent<RectTransform>().localPosition.x - 180, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);
                            }

                            else
                            {
                                Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                                Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                                Player_Typing.GetComponent<Image>().color = new Color(Player_Typing.GetComponent<Image>().color.r, Player_Typing.GetComponent<Image>().color.g, Player_Typing.GetComponent<Image>().color.b, 1);
                                Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(Player_Typing.GetComponent<RectTransform>().localPosition.x, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);
                            }

                            if (Player_Line_Up.GetComponent<RectTransform>().localPosition.x == 0)
                                step = 2;
                        }

                        //늘어나는 문자
                        if (step == 2)
                        {
                            if (!StopGame)
                            {
                                Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x - 0.4f, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                                Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x + 0.4f, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                                Player_Typing.GetComponent<RectTransform>().transform.localScale = new Vector3(Player_Typing.GetComponent<RectTransform>().transform.localScale.x + 0.002f, Player_Typing.GetComponent<RectTransform>().transform.localScale.y + 0.002f, Player_Typing.GetComponent<RectTransform>().transform.localScale.z);
                            }

                            else
                            {
                                Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                                Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                                Player_Typing.GetComponent<RectTransform>().transform.localScale = new Vector3(Player_Typing.GetComponent<RectTransform>().transform.localScale.x, Player_Typing.GetComponent<RectTransform>().transform.localScale.y, Player_Typing.GetComponent<RectTransform>().transform.localScale.z);
                            }

                            if (Player_Typing.GetComponent<RectTransform>().transform.localScale.y > 0.57f)
                                step = 3;
                        }

                        //사라진 뒤 재위치
                        if (step == 3)
                        {
                            if (Player_Typing.GetComponent<RectTransform>().localPosition.x == -720)
                            {
                                Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(400, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                                Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(-400, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                                Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(720, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);
                                MusicSource.SFXCHOOSE = true;
                                MusicSource.SFX[5] = true;
                                MusicSource.SE_volume = 0.7f;
                                step = 4;
                            }

                            else
                            {
                                if (!StopGame)
                                {
                                    Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x - 100, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                                    Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x + 100, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                                    Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(Player_Typing.GetComponent<RectTransform>().localPosition.x - 180, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);
                                }

                                else
                                {
                                    Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                                    Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                                    Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(Player_Typing.GetComponent<RectTransform>().localPosition.x, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);
                                }
                            }
                        }

                        if (step == 4) //등장하는 이미지(다음 차례!와 이미지들)
                        {
                            if (Player == 1)
                            {
                                Player_Line_Up.GetComponent<Image>().sprite = GameImage[2];
                                Player_Line_Down.GetComponent<Image>().sprite = GameImage[3];
                            }

                            else
                            {
                                Player_Line_Up.GetComponent<Image>().sprite = GameImage[0];
                                Player_Line_Down.GetComponent<Image>().sprite = GameImage[1];
                            }

                            TypeSaid(14);

                            if (!StopGame)
                            {
                                Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x - 100, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                                Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x + 100, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                                Player_Typing.GetComponent<Image>().color = new Color(Player_Typing.GetComponent<Image>().color.r, Player_Typing.GetComponent<Image>().color.g, Player_Typing.GetComponent<Image>().color.b, 1);
                                Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(Player_Typing.GetComponent<RectTransform>().localPosition.x - 180, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);
                            }

                            else
                            {
                                Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                                Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                                Player_Typing.GetComponent<Image>().color = new Color(Player_Typing.GetComponent<Image>().color.r, Player_Typing.GetComponent<Image>().color.g, Player_Typing.GetComponent<Image>().color.b, 1);
                                Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(Player_Typing.GetComponent<RectTransform>().localPosition.x, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);
                            }

                            if (Player_Line_Up.GetComponent<RectTransform>().localPosition.x == 0)
                                step = 5;
                        }

                        //늘어나는 문자
                        if (step == 5)
                        {
                            if (!StopGame)
                            {
                                Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x - 0.2f, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                                Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x + 0.2f, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                                Player_Typing.GetComponent<RectTransform>().transform.localScale = new Vector3(Player_Typing.GetComponent<RectTransform>().transform.localScale.x + 0.002f, Player_Typing.GetComponent<RectTransform>().transform.localScale.y + 0.002f, Player_Typing.GetComponent<RectTransform>().transform.localScale.z);
                            }

                            else
                            {
                                Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                                Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                                Player_Typing.GetComponent<RectTransform>().transform.localScale = new Vector3(Player_Typing.GetComponent<RectTransform>().transform.localScale.x, Player_Typing.GetComponent<RectTransform>().transform.localScale.y, Player_Typing.GetComponent<RectTransform>().transform.localScale.z);

                            }

                            if (Player_Typing.GetComponent<RectTransform>().transform.localScale.y > 0.57f)
                                step = 6;
                        }

                        //사라진 뒤 재위치(문자)
                        if (step == 6)
                        {
                            if (!StopGame)
                            {
                                Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x - 0.2f, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                                Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x + 0.2f, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                            }

                            else
                            {
                                Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                                Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                            }

                            if (Player_Typing.GetComponent<RectTransform>().localPosition.x == -720)
                            {
                                Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(720, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);
                                step = 7;
                            }

                            else
                            {
                                if (!StopGame)
                                    Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(Player_Typing.GetComponent<RectTransform>().localPosition.x - 180, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);

                                else
                                    Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(Player_Typing.GetComponent<RectTransform>().localPosition.x, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);
                            }
                        }

                        if (step == 7) //등장하는 이미지(플레이어 등장)
                        {
                            if (Player == 1)
                                TypeSaid(8);

                            else
                                TypeSaid(7);

                            if (!StopGame)
                            {
                                Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x - 0.2f, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                                Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x + 0.2f, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                                Player_Typing.GetComponent<Image>().color = new Color(Player_Typing.GetComponent<Image>().color.r, Player_Typing.GetComponent<Image>().color.g, Player_Typing.GetComponent<Image>().color.b, 1);
                                Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(Player_Typing.GetComponent<RectTransform>().localPosition.x - 180, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);
                            }

                            else
                            {
                                Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                                Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                                Player_Typing.GetComponent<Image>().color = new Color(Player_Typing.GetComponent<Image>().color.r, Player_Typing.GetComponent<Image>().color.g, Player_Typing.GetComponent<Image>().color.b, 1);
                                Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(Player_Typing.GetComponent<RectTransform>().localPosition.x, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);
                            }

                            if (Player_Typing.GetComponent<RectTransform>().localPosition.x == 0)
                            {
                                Move = 0;
                                step = 8;
                                Card.moving = 3;
                            }
                        }

                        //바뀌는 버튼
                        if (step == 8)
                        {
                            if (!StopGame)
                            {
                                Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x - 0.2f, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                                Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x + 0.2f, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                                Player_Typing.GetComponent<RectTransform>().transform.localScale = new Vector3(Player_Typing.GetComponent<RectTransform>().transform.localScale.x + 0.002f, Player_Typing.GetComponent<RectTransform>().transform.localScale.y + 0.002f, Player_Typing.GetComponent<RectTransform>().transform.localScale.z);
                            }

                            else
                            {
                                Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                                Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                                Player_Typing.GetComponent<RectTransform>().transform.localScale = new Vector3(Player_Typing.GetComponent<RectTransform>().transform.localScale.x, Player_Typing.GetComponent<RectTransform>().transform.localScale.y, Player_Typing.GetComponent<RectTransform>().transform.localScale.z);
                            }

                            if (Move == 1)
                            {
                                if (button_h.GetComponent<RectTransform>().localPosition.x == -100)
                                {
                                    if (Player_Typing.GetComponent<RectTransform>().transform.localScale.y > 0.57f)
                                    {
                                        Move = 0;

                                        //플레이어 변경
                                        if (Player == 1)
                                            Player = 2;
                                        else
                                            Player = 1;

                                        if (Main_Scene.Selected_stage[0] == 1)
                                            Invisible = true;

                                        step = 9;
                                    }
                                }

                                else
                                {
                                    button_h.GetComponent<Image>().fillAmount = 1;

                                    if (!StopGame)
                                    {
                                        button_h.GetComponent<RectTransform>().localPosition = new Vector3(button_h.GetComponent<RectTransform>().localPosition.x - 20, button_h.GetComponent<RectTransform>().localPosition.y, button_h.transform.position.z);
                                        button_g.GetComponent<RectTransform>().localPosition = new Vector3(button_g.GetComponent<RectTransform>().localPosition.x - 40, button_g.GetComponent<RectTransform>().localPosition.y, button_g.transform.position.z);
                                        First_Timer.GetComponent<RectTransform>().localPosition = new Vector3(First_Timer.GetComponent<RectTransform>().localPosition.x, First_Timer.GetComponent<RectTransform>().localPosition.y + 40, First_Timer.transform.position.z);
                                    }

                                    else
                                    {
                                        button_h.GetComponent<RectTransform>().localPosition = new Vector3(button_h.GetComponent<RectTransform>().localPosition.x, button_h.GetComponent<RectTransform>().localPosition.y, button_h.transform.position.z);
                                        button_g.GetComponent<RectTransform>().localPosition = new Vector3(button_g.GetComponent<RectTransform>().localPosition.x, button_g.GetComponent<RectTransform>().localPosition.y, button_g.transform.position.z);
                                        First_Timer.GetComponent<RectTransform>().localPosition = new Vector3(First_Timer.GetComponent<RectTransform>().localPosition.x, First_Timer.GetComponent<RectTransform>().localPosition.y, First_Timer.transform.position.z);
                                    }
                                }
                            }

                            else
                            {
                                this.ChangeSpeed = 50;

                                if (this.transform.eulerAngles.y > 90)
                                {
                                    this.button_h.GetComponent<Image>().fillAmount = 1;
                                    transform.Rotate(0, 260f, 0);
                                    this.ChangeSpeed = 0;
                                    timeCount = 0.5f;
                                    Move = 1;
                                }

                                else
                                {
                                    transform.Rotate(0, this.ChangeSpeed, 0);
                                    this.ChangeSpeed *= 0.1f;
                                }

                                ButtonChange();
                            }
                        }

                        //사라진 뒤 재위치
                        if (step == 9)
                        {
                            if (Player_Typing.GetComponent<RectTransform>().localPosition.x == -720)
                            {
                                Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(400, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                                Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(-400, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                                Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(720, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);
                                step = 0;
                                Stop_Timer = false;
                                Timer_Check = false;
                                Card.find = false;
                                timer_stop = false;
                                Card.Choosefinished = false;
                                Buttonclick = 0;

                                if (Card.FailAnswer >= 5)
                                    Card.ShowHint = true;
                            }

                            else
                            {

                                if (!StopGame)
                                {
                                    Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x - 100, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                                    Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x + 100, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                                    Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(Player_Typing.GetComponent<RectTransform>().localPosition.x - 180, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);
                                }

                                else
                                {
                                    Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                                    Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                                    Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(Player_Typing.GetComponent<RectTransform>().localPosition.x, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);
                                }
                            }
                        }
                    }

                    //합을 눌러서 맞은 경우
                    if (Buttonclick == 23)
                    {
                        if (step == 0) //이미지 등장의 위치를 정함
                        {
                            Card.FailAnswer = 0;
                            Score();
                            Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(400, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                            Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(-400, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                            Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(720, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);

                            MusicSource.SFXCHOOSE = true;
                            MusicSource.SFX[5] = true;
                            MusicSource.SE_volume = 0.7f;
                            MusicSource.SFXCHOOSE2 = true;
                            MusicSource.SFX2[1] = true;
                            MusicSource.SE2_volume = 0.5f;
                            step = 1;
                        }

                        if (step == 1) //등장하는 이미지 [성공]
                        {
                            Player_Line_Up.GetComponent<Image>().sprite = GameImage[4];
                            Player_Line_Down.GetComponent<Image>().sprite = GameImage[5];

                            TypeSaid(10);

                            if (!StopGame)
                            {
                                Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x - 100, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                                Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x + 100, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                                Player_Typing.GetComponent<Image>().color = new Color(Player_Typing.GetComponent<Image>().color.r, Player_Typing.GetComponent<Image>().color.g, Player_Typing.GetComponent<Image>().color.b, 1);
                                Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(Player_Typing.GetComponent<RectTransform>().localPosition.x - 180, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);
                            }

                            else
                            {
                                Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                                Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                                Player_Typing.GetComponent<Image>().color = new Color(Player_Typing.GetComponent<Image>().color.r, Player_Typing.GetComponent<Image>().color.g, Player_Typing.GetComponent<Image>().color.b, 1);
                                Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(Player_Typing.GetComponent<RectTransform>().localPosition.x, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);
                            }

                            if (Player_Line_Up.GetComponent<RectTransform>().localPosition.x == 0)
                                step = 2;
                        }

                        //늘어나는 문자
                        if (step == 2)
                        {
                            if (!StopGame)
                            {
                                Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x - 0.4f, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                                Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x + 0.4f, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                                Player_Typing.GetComponent<RectTransform>().transform.localScale = new Vector3(Player_Typing.GetComponent<RectTransform>().transform.localScale.x + 0.002f, Player_Typing.GetComponent<RectTransform>().transform.localScale.y + 0.002f, Player_Typing.GetComponent<RectTransform>().transform.localScale.z);
                            }

                            else
                            {
                                Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                                Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                                Player_Typing.GetComponent<RectTransform>().transform.localScale = new Vector3(Player_Typing.GetComponent<RectTransform>().transform.localScale.x, Player_Typing.GetComponent<RectTransform>().transform.localScale.y, Player_Typing.GetComponent<RectTransform>().transform.localScale.z);
                            }

                            if (Player_Typing.GetComponent<RectTransform>().transform.localScale.y > 0.57f)
                                step = 3;
                        }

                        //늘어나는 문자
                        if (step == 3)
                        {
                            if (!StopGame)
                            {
                                Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x - 0.2f, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                                Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x + 0.2f, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                                Player_Typing.GetComponent<RectTransform>().transform.localScale = new Vector3(Player_Typing.GetComponent<RectTransform>().transform.localScale.x + 0.002f, Player_Typing.GetComponent<RectTransform>().transform.localScale.y + 0.002f, Player_Typing.GetComponent<RectTransform>().transform.localScale.z);
                            }

                            else
                            {
                                Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                                Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                                Player_Typing.GetComponent<RectTransform>().transform.localScale = new Vector3(Player_Typing.GetComponent<RectTransform>().transform.localScale.x, Player_Typing.GetComponent<RectTransform>().transform.localScale.y, Player_Typing.GetComponent<RectTransform>().transform.localScale.z);
                            }

                            if (Player_Typing.GetComponent<RectTransform>().transform.localScale.y > 0.57f)
                                step = 4;
                        }

                        //사라진 뒤 재위치(문자만)
                        if (step == 4)
                        {
                            if (!StopGame)
                            {
                                Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x - 0.2f, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                                Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x + 0.2f, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                            }

                            else
                            {
                                Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                                Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                            }

                            if (Player_Typing.GetComponent<RectTransform>().localPosition.x == -720)
                            {
                                Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(720, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);
                                step = 5;
                            }

                            else
                            {
                                if (!StopGame)
                                    Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(Player_Typing.GetComponent<RectTransform>().localPosition.x - 180, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);

                                else
                                    Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(Player_Typing.GetComponent<RectTransform>().localPosition.x, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);
                            }
                        }

                        if (step == 5) //등장하는 이미지(한 번 더!)
                        {
                            TypeSaid(12);

                            if (!StopGame)
                            {
                                Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x - 0.2f, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                                Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x + 0.2f, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                                Player_Typing.GetComponent<Image>().color = new Color(Player_Typing.GetComponent<Image>().color.r, Player_Typing.GetComponent<Image>().color.g, Player_Typing.GetComponent<Image>().color.b, 1);
                                Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(Player_Typing.GetComponent<RectTransform>().localPosition.x - 180, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);
                            }

                            else
                            {
                                Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                                Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                                Player_Typing.GetComponent<Image>().color = new Color(Player_Typing.GetComponent<Image>().color.r, Player_Typing.GetComponent<Image>().color.g, Player_Typing.GetComponent<Image>().color.b, 1);
                                Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(Player_Typing.GetComponent<RectTransform>().localPosition.x, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);
                            }

                            if (Player_Typing.GetComponent<RectTransform>().localPosition.x == 0)
                            {
                                Move = 0;
                                step = 6;
                                Card.moving = 3;
                            }
                        }

                        //바뀌는 버튼
                        if (step == 6)
                        {
                            if (!StopGame)
                            {
                                Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x - 0.2f, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                                Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x + 0.2f, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                                Player_Typing.GetComponent<RectTransform>().transform.localScale = new Vector3(Player_Typing.GetComponent<RectTransform>().transform.localScale.x + 0.002f, Player_Typing.GetComponent<RectTransform>().transform.localScale.y + 0.002f, Player_Typing.GetComponent<RectTransform>().transform.localScale.z);
                            }

                            else
                            {
                                Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                                Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                                Player_Typing.GetComponent<RectTransform>().transform.localScale = new Vector3(Player_Typing.GetComponent<RectTransform>().transform.localScale.x, Player_Typing.GetComponent<RectTransform>().transform.localScale.y, Player_Typing.GetComponent<RectTransform>().transform.localScale.z);


                            }

                            if (Move == 0)
                            {
                                if (button_h.GetComponent<RectTransform>().localPosition.x == -80)
                                {
                                    Move = 1;
                                }

                                else
                                {
                                    button_h.GetComponent<Image>().fillAmount = 1;

                                    if (!StopGame)
                                    {
                                        button_h.GetComponent<RectTransform>().localPosition = new Vector3(button_h.GetComponent<RectTransform>().localPosition.x - 20, button_h.GetComponent<RectTransform>().localPosition.y, button_h.transform.position.z);
                                        button_g.GetComponent<RectTransform>().localPosition = new Vector3(button_g.GetComponent<RectTransform>().localPosition.x - 55, button_g.GetComponent<RectTransform>().localPosition.y, button_g.transform.position.z);
                                        Skip.GetComponent<RectTransform>().localPosition = new Vector3(Skip.GetComponent<RectTransform>().localPosition.x - 100, Skip.GetComponent<RectTransform>().localPosition.y, Skip.transform.position.z);
                                    }

                                    else
                                    {
                                        button_h.GetComponent<RectTransform>().localPosition = new Vector3(button_h.GetComponent<RectTransform>().localPosition.x, button_h.GetComponent<RectTransform>().localPosition.y, button_h.transform.position.z);
                                        button_g.GetComponent<RectTransform>().localPosition = new Vector3(button_g.GetComponent<RectTransform>().localPosition.x, button_g.GetComponent<RectTransform>().localPosition.y, button_g.transform.position.z);
                                        Skip.GetComponent<RectTransform>().localPosition = new Vector3(Skip.GetComponent<RectTransform>().localPosition.x, Skip.GetComponent<RectTransform>().localPosition.y, Skip.transform.position.z);
                                    }
                                }
                            }

                            else if (Move == 1)
                            {
                                this.ChangeSpeed = 50;

                                if (this.transform.eulerAngles.y > 90)
                                {
                                    transform.Rotate(0, 260f, 0);
                                    this.ChangeSpeed = 0;
                                    timeCount = 10;
                                    Move = 2;
                                }

                                else
                                {
                                    transform.Rotate(0, this.ChangeSpeed, 0);
                                    this.ChangeSpeed *= 0.1f;
                                }

                                if (Player == 1)
                                {
                                    if (Main_Scene.Language == 1)
                                    {
                                        button_h.GetComponent<Image>().sprite = but[1];
                                        button_g.GetComponent<Image>().sprite = but[4];
                                        Skip.GetComponent<Image>().sprite = but[19];
                                    }

                                    else if (Main_Scene.Language == 2)
                                    {
                                        button_h.GetComponent<Image>().sprite = but[33];
                                        button_g.GetComponent<Image>().sprite = but[4];
                                        Skip.GetComponent<Image>().sprite = but[36];
                                    }

                                    else if (Main_Scene.Language == 3)
                                    {
                                        button_h.GetComponent<Image>().sprite = but[43];
                                        button_g.GetComponent<Image>().sprite = but[4];
                                        Skip.GetComponent<Image>().sprite = but[46];
                                    }
                                }

                                else
                                {
                                    if (Main_Scene.Language == 1)
                                    {
                                        button_h.GetComponent<Image>().sprite = but[3];
                                        button_g.GetComponent<Image>().sprite = but[5];
                                        Skip.GetComponent<Image>().sprite = but[19];
                                    }

                                    else if (Main_Scene.Language == 2)
                                    {
                                        button_h.GetComponent<Image>().sprite = but[35];
                                        button_g.GetComponent<Image>().sprite = but[5];
                                        Skip.GetComponent<Image>().sprite = but[37];
                                    }

                                    else if (Main_Scene.Language == 3)
                                    {
                                        button_h.GetComponent<Image>().sprite = but[45];
                                        button_g.GetComponent<Image>().sprite = but[5];
                                        Skip.GetComponent<Image>().sprite = but[47];
                                    }
                                }
                            }

                            else
                            {
                                if (Player_Typing.GetComponent<RectTransform>().transform.localScale.y > 0.57f)
                                {
                                    Move = 0;
                                    step = 7;
                                }
                            }
                        }

                        //사라진 뒤 재위치
                        if (step == 7)
                        {
                            if (Player_Typing.GetComponent<RectTransform>().localPosition.x == -720)
                            {
                                Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(400, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                                Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(-400, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                                Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(720, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);
                                step = 0;
                                Card.find = false;
                                Card.Choosefinished = false;
                                timeCount = 5;
                                Hap_next = true;
                                NowButtonclick = 231;
                                Buttonclick = 231;
                                MusicSource.Clocking = true;
                            }

                            else
                            {
                                if (!StopGame)
                                {
                                    Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x - 100, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                                    Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x + 100, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                                    Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(Player_Typing.GetComponent<RectTransform>().localPosition.x - 180, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);
                                }

                                else
                                {
                                    Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                                    Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                                    Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(Player_Typing.GetComponent<RectTransform>().localPosition.x, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);
                                }
                            }
                        }
                    }

                    //4*4모드에서 합이 15개 이상 나왔을 때
                    if (Buttonclick == 24)
                    {
                        if (step == 0) //이미지 등장의 위치를 정함
                        {
                            Achieve();
                            Card.FailAnswer = 0;

                            if (Player == 1)
                                Main_Scene.Player_1_WinCount++;

                            else if (Player == 2)
                                Main_Scene.Player_2_WinCount++;

                            Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(400, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                            Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(-400, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                            Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(720, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);

                            MusicSource.SFXCHOOSE = true;
                            MusicSource.SFX[5] = true;
                            MusicSource.SE_volume = 0.7f;
                            step = 1;
                        }

                        if (step == 1) //등장하는 이미지 [성공]
                        {
                            Score();
                            Player_Line_Up.GetComponent<Image>().sprite = GameImage[4];
                            Player_Line_Down.GetComponent<Image>().sprite = GameImage[5];

                            TypeSaid(10);

                            if (!StopGame)
                            {
                                Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x - 100, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                                Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x + 100, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                                Player_Typing.GetComponent<Image>().color = new Color(Player_Typing.GetComponent<Image>().color.r, Player_Typing.GetComponent<Image>().color.g, Player_Typing.GetComponent<Image>().color.b, 1);
                                Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(Player_Typing.GetComponent<RectTransform>().localPosition.x - 180, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);
                                Skip.GetComponent<RectTransform>().localPosition = new Vector3(Skip.GetComponent<RectTransform>().localPosition.x, Skip.GetComponent<RectTransform>().localPosition.y - 100, Skip.transform.position.z);
                            }

                            else
                            {
                                Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                                Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                                Player_Typing.GetComponent<Image>().color = new Color(Player_Typing.GetComponent<Image>().color.r, Player_Typing.GetComponent<Image>().color.g, Player_Typing.GetComponent<Image>().color.b, 1);
                                Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(Player_Typing.GetComponent<RectTransform>().localPosition.x, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);
                                Skip.GetComponent<RectTransform>().localPosition = new Vector3(Skip.GetComponent<RectTransform>().localPosition.x, Skip.GetComponent<RectTransform>().localPosition.y, Skip.transform.position.z);
                            }

                            if (Player_Line_Up.GetComponent<RectTransform>().localPosition.x == 0)
                                step = 2;
                        }

                        //늘어나는 문자
                        if (step == 2)
                        {
                            if (!StopGame)
                            {
                                Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x - 0.1f, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                                Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x + 0.1f, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                                Player_Typing.GetComponent<RectTransform>().transform.localScale = new Vector3(Player_Typing.GetComponent<RectTransform>().transform.localScale.x + 0.002f, Player_Typing.GetComponent<RectTransform>().transform.localScale.y + 0.002f, Player_Typing.GetComponent<RectTransform>().transform.localScale.z);

                            }

                            else
                            {
                                Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                                Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                                Player_Typing.GetComponent<RectTransform>().transform.localScale = new Vector3(Player_Typing.GetComponent<RectTransform>().transform.localScale.x, Player_Typing.GetComponent<RectTransform>().transform.localScale.y, Player_Typing.GetComponent<RectTransform>().transform.localScale.z);

                            }

                            if (Player_Typing.GetComponent<RectTransform>().transform.localScale.y > 0.57f)
                                step = 3;
                        }

                        //사라진 뒤 재위치
                        if (step == 3)
                        {
                            if (!StopGame)
                            {
                                Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x - 0.1f, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                                Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x + 0.1f, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                            }

                            else
                            {
                                Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                                Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                            }

                            if (Player_Typing.GetComponent<RectTransform>().localPosition.x == -720)
                            {
                                Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(720, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);
                                Skip.GetComponent<RectTransform>().localPosition = new Vector3(400, -260, 0);
                                step = 4;
                            }

                            else
                            {
                                if (!StopGame)
                                    Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(Player_Typing.GetComponent<RectTransform>().localPosition.x - 180, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);

                                else
                                    Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(Player_Typing.GetComponent<RectTransform>().localPosition.x, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);
                            }
                        }

                        if (step == 4) //등장하는 이미지(게임 끝!)
                        {
                            TypeSaid(13);
                            Player_Typing.GetComponent<Image>().color = new Color(Player_Typing.GetComponent<Image>().color.r, Player_Typing.GetComponent<Image>().color.g, Player_Typing.GetComponent<Image>().color.b, 1);
                            Card.moving = 3;

                            if (Player_Typing.GetComponent<RectTransform>().localPosition.x == 0)
                            {
                                Move = 0;
                                MusicSource.SFXCHOOSE = true;
                                MusicSource.SFX[5] = true;
                                MusicSource.SE_volume = 0.7f;
                                step = 5;
                            }

                            else
                            {
                                if (!StopGame)
                                    Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(Player_Typing.GetComponent<RectTransform>().localPosition.x - 180, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);

                                else
                                    Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(Player_Typing.GetComponent<RectTransform>().localPosition.x, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);
                            }
                        }

                        //바뀌는 버튼
                        if (step == 5)
                        {
                            if (!StopGame)
                                Player_Typing.GetComponent<RectTransform>().transform.localScale = new Vector3(Player_Typing.GetComponent<RectTransform>().transform.localScale.x + 0.002f, Player_Typing.GetComponent<RectTransform>().transform.localScale.y + 0.002f, Player_Typing.GetComponent<RectTransform>().transform.localScale.z);

                            else
                                Player_Typing.GetComponent<RectTransform>().transform.localScale = new Vector3(Player_Typing.GetComponent<RectTransform>().transform.localScale.x, Player_Typing.GetComponent<RectTransform>().transform.localScale.y, Player_Typing.GetComponent<RectTransform>().transform.localScale.z);

                            if (Move == 1)
                            {
                                if (button_h.GetComponent<RectTransform>().localPosition.x == -100)
                                {
                                    if (Player_Typing.GetComponent<RectTransform>().transform.localScale.y > 0.57f)
                                    {
                                        Move = 0;
                                        step = 6;
                                    }
                                }

                                else
                                {
                                    button_h.GetComponent<Image>().fillAmount = 1;

                                    if (!StopGame)
                                    {
                                        button_h.GetComponent<RectTransform>().localPosition = new Vector3(button_h.GetComponent<RectTransform>().localPosition.x - 20, button_h.GetComponent<RectTransform>().localPosition.y, button_h.transform.position.z);
                                        button_g.GetComponent<RectTransform>().localPosition = new Vector3(button_g.GetComponent<RectTransform>().localPosition.x - 40, button_g.GetComponent<RectTransform>().localPosition.y, button_g.transform.position.z);
                                    }

                                    else
                                    {
                                        button_h.GetComponent<RectTransform>().localPosition = new Vector3(button_h.GetComponent<RectTransform>().localPosition.x, button_h.GetComponent<RectTransform>().localPosition.y, button_h.transform.position.z);
                                        button_g.GetComponent<RectTransform>().localPosition = new Vector3(button_g.GetComponent<RectTransform>().localPosition.x, button_g.GetComponent<RectTransform>().localPosition.y, button_g.transform.position.z);
                                    }
                                }
                            }

                            else
                            {
                                this.ChangeSpeed = 50;

                                if (this.transform.eulerAngles.y > 90)
                                {
                                    transform.Rotate(0, 260f, 0);
                                    this.ChangeSpeed = 0;
                                    timeCount = 0.5f;
                                    Move = 1;
                                }

                                else
                                {
                                    transform.Rotate(0, this.ChangeSpeed, 0);
                                    this.ChangeSpeed *= 0.1f;
                                }

                                if (Main_Scene.Language == 1)
                                {
                                    button_h.GetComponent<Image>().sprite = but[1];
                                    button_g.GetComponent<Image>().sprite = but[3];
                                }

                                else if (Main_Scene.Language == 2)
                                {
                                    button_h.GetComponent<Image>().sprite = but[33];
                                    button_g.GetComponent<Image>().sprite = but[35];
                                }

                                else if (Main_Scene.Language == 3)
                                {
                                    button_h.GetComponent<Image>().sprite = but[43];
                                    button_g.GetComponent<Image>().sprite = but[45];
                                }
                            }
                        }

                        //사라짐
                        if (step == 6)
                        {
                            if (Player_Typing.GetComponent<RectTransform>().localPosition.x == -720)
                            {
                                Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(400, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                                Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(-400, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                                Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(720, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);
                                step = 0;
                                Stop_Timer = false;
                                Timer_Check = false;
                                Card.find = false;
                                timer_stop = false;
                                Card.Choosefinished = false;
                                Hap_next = false;
                                Card.Gyeoul = false;
                                Buttonclick = 0;
                                Card.Finish = true;

                                if (Main_Scene.Last_Stage == 1)
                                {
                                    MusicSource.SFXCHOOSE = true;
                                    MusicSource.SFX[7] = true;
                                    MusicSource.SE_volume = 0.7f;
                                    MusicSource.volume = 0;
                                }
                            }

                            else
                            {
                                if (!StopGame)
                                {
                                    Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x - 100, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                                    Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x + 100, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                                    Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(Player_Typing.GetComponent<RectTransform>().localPosition.x - 180, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);

                                }

                                else
                                {
                                    Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                                    Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                                    Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(Player_Typing.GetComponent<RectTransform>().localPosition.x, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);

                                }
                            }
                        }

                    }

                    //합 이후에 결이 맞는지 확인한다.
                    if (Buttonclick == 231)
                    {
                        if (NowButtonclick == 235)
                            Buttonclick = 235;

                        else
                        {
                            if (step == 0)
                            {
                                Hap_next = true;
                                timeCount -= Time.deltaTime;
                                DecreaseTime_G();

                                //타이머 종료 시 3번으로 이동
                                if (timeCount < 0)
                                {
                                    MusicSource.ClockingOff = true;
                                    timer_stop = true;
                                    step = 0;
                                    NowButtonclick = 0;
                                    Buttonclick = 232;
                                    choose_card = 0;
                                }
                            }

                            if (step == 1)
                            {
                                MusicSource.ClockingOff = true;
                                Main_Scene.Score = true;
                                step = 2;
                            }

                            if (step == 3)
                            {
                                if (!Card.find) //결이 아닐 때
                                {
                                    NowButtonclick = 0;
                                    Buttonclick = 233;
                                    AnswerG = false;
                                    step = 0;
                                }

                                else //결일 때
                                {
                                    NowButtonclick = 0;
                                    Buttonclick = 234;
                                    AnswerG = false;
                                    step = 0;
                                }
                            }
                        }
                    }

                    //합 이후에 시간이 지나버림
                    if (Buttonclick == 232)
                    {
                        if (step == 0) //이미지 등장의 위치를 정함
                        {
                            Score();
                            Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(400, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                            Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(-400, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                            Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(720, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);

                            MusicSource.SFXCHOOSE = true;
                            MusicSource.SFX[5] = true;
                            MusicSource.SE_volume = 0.7f;
                            MusicSource.SFXCHOOSE2 = true;
                            MusicSource.SFX2[2] = true;
                            MusicSource.SE2_volume = 0.7f;
                            step = 1;
                        }

                        if (step == 1) //등장하는 이미지
                        {
                            if (Player == 1)
                            {
                                Player_Line_Up.GetComponent<Image>().sprite = GameImage[0];
                                Player_Line_Down.GetComponent<Image>().sprite = GameImage[1];
                            }

                            else
                            {
                                Player_Line_Up.GetComponent<Image>().sprite = GameImage[2];
                                Player_Line_Down.GetComponent<Image>().sprite = GameImage[3];
                            }

                            TypeSaid(15);

                            if (!StopGame)
                            {
                                Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x - 100, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                                Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x + 100, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                                Player_Typing.GetComponent<Image>().color = new Color(Player_Typing.GetComponent<Image>().color.r, Player_Typing.GetComponent<Image>().color.g, Player_Typing.GetComponent<Image>().color.b, 1);
                                Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(Player_Typing.GetComponent<RectTransform>().localPosition.x - 180, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);
                                Skip.GetComponent<RectTransform>().localPosition = new Vector3(Skip.GetComponent<RectTransform>().localPosition.x, Skip.GetComponent<RectTransform>().localPosition.y - 100, Skip.transform.position.z);
                            }

                            else
                            {
                                Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                                Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                                Player_Typing.GetComponent<Image>().color = new Color(Player_Typing.GetComponent<Image>().color.r, Player_Typing.GetComponent<Image>().color.g, Player_Typing.GetComponent<Image>().color.b, 1);
                                Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(Player_Typing.GetComponent<RectTransform>().localPosition.x, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);
                                Skip.GetComponent<RectTransform>().localPosition = new Vector3(Skip.GetComponent<RectTransform>().localPosition.x, Skip.GetComponent<RectTransform>().localPosition.y, Skip.transform.position.z);
                            }

                            if (Player_Line_Up.GetComponent<RectTransform>().localPosition.x == 0)
                                step = 2;
                        }

                        //늘어나는 문자
                        if (step == 2)
                        {
                            if (!StopGame)
                            {
                                Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x - 0.4f, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                                Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x + 0.4f, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                                Player_Typing.GetComponent<RectTransform>().transform.localScale = new Vector3(Player_Typing.GetComponent<RectTransform>().transform.localScale.x + 0.002f, Player_Typing.GetComponent<RectTransform>().transform.localScale.y + 0.002f, Player_Typing.GetComponent<RectTransform>().transform.localScale.z);
                            }

                            else
                            {
                                Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                                Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                                Player_Typing.GetComponent<RectTransform>().transform.localScale = new Vector3(Player_Typing.GetComponent<RectTransform>().transform.localScale.x, Player_Typing.GetComponent<RectTransform>().transform.localScale.y, Player_Typing.GetComponent<RectTransform>().transform.localScale.z);
                            }

                            if (Player_Typing.GetComponent<RectTransform>().transform.localScale.y > 0.57f)
                                step = 3;
                        }

                        //사라진 뒤 재위치
                        if (step == 3)
                        {
                            if (Player_Typing.GetComponent<RectTransform>().localPosition.x == -720)
                            {
                                Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(400, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                                Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(-400, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                                Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(720, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);
                                Skip.GetComponent<RectTransform>().localPosition = new Vector3(400, -260, 0);
                                MusicSource.SFXCHOOSE = true;
                                MusicSource.SFX[5] = true;
                                MusicSource.SE_volume = 0.7f;
                                step = 4;
                            }

                            else
                            {
                                if (!StopGame)
                                {
                                    Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x - 100, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                                    Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x + 100, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                                    Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(Player_Typing.GetComponent<RectTransform>().localPosition.x - 180, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);
                                }

                                else
                                {
                                    Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                                    Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                                    Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(Player_Typing.GetComponent<RectTransform>().localPosition.x, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);
                                }
                            }
                        }

                        if (step == 4) //등장하는 이미지(다음 차례!와 이미지들)
                        {
                            if (Player == 1)
                            {
                                Player_Line_Up.GetComponent<Image>().sprite = GameImage[2];
                                Player_Line_Down.GetComponent<Image>().sprite = GameImage[3];
                            }

                            else
                            {
                                Player_Line_Up.GetComponent<Image>().sprite = GameImage[0];
                                Player_Line_Down.GetComponent<Image>().sprite = GameImage[1];
                            }

                            TypeSaid(14);

                            if (!StopGame)
                            {
                                Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x - 100f, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                                Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x + 100f, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                                Player_Typing.GetComponent<Image>().color = new Color(Player_Typing.GetComponent<Image>().color.r, Player_Typing.GetComponent<Image>().color.g, Player_Typing.GetComponent<Image>().color.b, 1);
                                Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(Player_Typing.GetComponent<RectTransform>().localPosition.x - 180, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);
                            }

                            else
                            {
                                Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                                Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                                Player_Typing.GetComponent<Image>().color = new Color(Player_Typing.GetComponent<Image>().color.r, Player_Typing.GetComponent<Image>().color.g, Player_Typing.GetComponent<Image>().color.b, 1);
                                Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(Player_Typing.GetComponent<RectTransform>().localPosition.x, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);
                            }

                            if (Player_Line_Up.GetComponent<RectTransform>().localPosition.x == 0)
                                step = 5;
                        }

                        //늘어나는 문자
                        if (step == 5)
                        {
                            if (!StopGame)
                            {
                                Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x - 0.2f, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                                Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x + 0.2f, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                                Player_Typing.GetComponent<RectTransform>().transform.localScale = new Vector3(Player_Typing.GetComponent<RectTransform>().transform.localScale.x + 0.002f, Player_Typing.GetComponent<RectTransform>().transform.localScale.y + 0.002f, Player_Typing.GetComponent<RectTransform>().transform.localScale.z);

                            }

                            else
                            {
                                Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                                Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                                Player_Typing.GetComponent<RectTransform>().transform.localScale = new Vector3(Player_Typing.GetComponent<RectTransform>().transform.localScale.x, Player_Typing.GetComponent<RectTransform>().transform.localScale.y, Player_Typing.GetComponent<RectTransform>().transform.localScale.z);
                            }

                            if (Player_Typing.GetComponent<RectTransform>().transform.localScale.y > 0.57f)
                                step = 6;
                        }

                        //사라진 뒤 재위치(문자)
                        if (step == 6)
                        {
                            if (!StopGame)
                            {
                                Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x - 0.2f, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                                Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x + 0.2f, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                            }

                            else
                            {
                                Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                                Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                            }

                            if (Player_Typing.GetComponent<RectTransform>().localPosition.x == -720)
                            {
                                Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(720, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);
                                step = 7;
                            }

                            else
                            {
                                if (!StopGame)
                                    Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(Player_Typing.GetComponent<RectTransform>().localPosition.x - 180, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);

                                else
                                    Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(Player_Typing.GetComponent<RectTransform>().localPosition.x, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);
                            }
                        }

                        if (step == 7) //등장하는 이미지(플레이어 등장)
                        {
                            if (Player == 1)
                                TypeSaid(8);

                            else
                                TypeSaid(7);

                            if (!StopGame)
                            {
                                Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x - 0.2f, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                                Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x + 0.2f, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                                Player_Typing.GetComponent<Image>().color = new Color(Player_Typing.GetComponent<Image>().color.r, Player_Typing.GetComponent<Image>().color.g, Player_Typing.GetComponent<Image>().color.b, 1);
                                Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(Player_Typing.GetComponent<RectTransform>().localPosition.x - 180, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);
                            }

                            else
                            {
                                Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                                Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                                Player_Typing.GetComponent<Image>().color = new Color(Player_Typing.GetComponent<Image>().color.r, Player_Typing.GetComponent<Image>().color.g, Player_Typing.GetComponent<Image>().color.b, 1);
                                Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(Player_Typing.GetComponent<RectTransform>().localPosition.x, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);
                            }

                            if (Player_Typing.GetComponent<RectTransform>().localPosition.x == 0)
                            {
                                Move = 0;
                                step = 8;
                            }
                        }

                        //바뀌는 버튼
                        if (step == 8)
                        {
                            if (!StopGame)
                            {
                                Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x - 0.2f, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                                Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x + 0.2f, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                                Player_Typing.GetComponent<RectTransform>().transform.localScale = new Vector3(Player_Typing.GetComponent<RectTransform>().transform.localScale.x + 0.002f, Player_Typing.GetComponent<RectTransform>().transform.localScale.y + 0.002f, Player_Typing.GetComponent<RectTransform>().transform.localScale.z);
                            }

                            else
                            {
                                Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                                Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                                Player_Typing.GetComponent<RectTransform>().transform.localScale = new Vector3(Player_Typing.GetComponent<RectTransform>().transform.localScale.x, Player_Typing.GetComponent<RectTransform>().transform.localScale.y, Player_Typing.GetComponent<RectTransform>().transform.localScale.z);
                            }

                            if (Move == 1)
                            {
                                if (button_h.GetComponent<RectTransform>().localPosition.x == -100)
                                {
                                    if (Player_Typing.GetComponent<RectTransform>().transform.localScale.y > 0.57f)
                                    {
                                        Move = 0;

                                        //플레이어 변경
                                        if (Player == 1)
                                            Player = 2;
                                        else
                                            Player = 1;

                                        if (Main_Scene.Selected_stage[0] == 1)
                                            Invisible = true;

                                        step = 9;
                                    }
                                }

                                else
                                {
                                    button_g.GetComponent<Image>().fillAmount = 1;

                                    if (!StopGame)
                                    {
                                        button_h.GetComponent<RectTransform>().localPosition = new Vector3(button_h.GetComponent<RectTransform>().localPosition.x - 5, button_h.GetComponent<RectTransform>().localPosition.y, button_h.transform.position.z);
                                        button_g.GetComponent<RectTransform>().localPosition = new Vector3(button_g.GetComponent<RectTransform>().localPosition.x + 5, button_g.GetComponent<RectTransform>().localPosition.y, button_g.transform.position.z);
                                        First_Timer.GetComponent<RectTransform>().localPosition = new Vector3(First_Timer.GetComponent<RectTransform>().localPosition.x, First_Timer.GetComponent<RectTransform>().localPosition.y + 50, First_Timer.transform.position.z);
                                    }

                                    else
                                    {
                                        button_h.GetComponent<RectTransform>().localPosition = new Vector3(button_h.GetComponent<RectTransform>().localPosition.x, button_h.GetComponent<RectTransform>().localPosition.y, button_h.transform.position.z);
                                        button_g.GetComponent<RectTransform>().localPosition = new Vector3(button_g.GetComponent<RectTransform>().localPosition.x, button_g.GetComponent<RectTransform>().localPosition.y, button_g.transform.position.z);
                                        First_Timer.GetComponent<RectTransform>().localPosition = new Vector3(First_Timer.GetComponent<RectTransform>().localPosition.x, First_Timer.GetComponent<RectTransform>().localPosition.y, First_Timer.transform.position.z);
                                    }
                                }
                            }

                            else
                            {
                                this.ChangeSpeed = 50;

                                if (this.transform.eulerAngles.y > 90)
                                {
                                    transform.Rotate(0, 260f, 0);
                                    this.ChangeSpeed = 0;
                                    timeCount = 0.5f;
                                    Move = 1;
                                }

                                else
                                {
                                    transform.Rotate(0, this.ChangeSpeed, 0);
                                    this.ChangeSpeed *= 0.1f;
                                }

                                ButtonChange();
                            }
                        }

                        //사라짐
                        if (step == 9)
                        {
                            if (Player_Typing.GetComponent<RectTransform>().localPosition.x == -720)
                            {
                                Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(400, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                                Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(-400, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                                Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(720, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);
                                step = 0;
                                Stop_Timer = false;
                                Timer_Check = false;
                                Card.find = false;
                                timer_stop = false;
                                Card.Choosefinished = false;
                                Hap_next = false;
                                Card.Gyeoul = false;
                                Buttonclick = 0;
                            }

                            else
                            {
                                if (!StopGame)
                                {
                                    Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x - 100, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                                    Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x + 100, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                                    Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(Player_Typing.GetComponent<RectTransform>().localPosition.x - 180, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);
                                }

                                else
                                {
                                    Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                                    Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                                    Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(Player_Typing.GetComponent<RectTransform>().localPosition.x, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);
                                }
                            }
                        }
                    }

                    //합 이후에 결을 실패했을 때
                    if (Buttonclick == 233)
                    {
                        if (step == 0) //이미지 등장의 위치를 정함
                        {
                            Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(400, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                            Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(-400, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                            Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(720, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);

                            MusicSource.SFXCHOOSE = true;
                            MusicSource.SFX[5] = true;
                            MusicSource.SE_volume = 0.7f;
                            MusicSource.SFXCHOOSE2 = true;
                            MusicSource.SFX2[2] = true;
                            MusicSource.SE2_volume = 0.7f;
                            step = 1;
                        }

                        if (step == 1) //등장하는 이미지 [실패]
                        {
                            Score();
                            Player_Line_Up.GetComponent<Image>().sprite = GameImage[4];
                            Player_Line_Down.GetComponent<Image>().sprite = GameImage[5];

                            TypeSaid(11);

                            if (!StopGame)
                            {
                                Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x - 100, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                                Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x + 100, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                                Player_Typing.GetComponent<Image>().color = new Color(Player_Typing.GetComponent<Image>().color.r, Player_Typing.GetComponent<Image>().color.g, Player_Typing.GetComponent<Image>().color.b, 1);
                                Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(Player_Typing.GetComponent<RectTransform>().localPosition.x - 180, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);
                                Skip.GetComponent<RectTransform>().localPosition = new Vector3(Skip.GetComponent<RectTransform>().localPosition.x, Skip.GetComponent<RectTransform>().localPosition.y - 100, Skip.transform.position.z);
                            }

                            else
                            {
                                Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                                Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                                Player_Typing.GetComponent<Image>().color = new Color(Player_Typing.GetComponent<Image>().color.r, Player_Typing.GetComponent<Image>().color.g, Player_Typing.GetComponent<Image>().color.b, 1);
                                Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(Player_Typing.GetComponent<RectTransform>().localPosition.x, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);
                                Skip.GetComponent<RectTransform>().localPosition = new Vector3(Skip.GetComponent<RectTransform>().localPosition.x, Skip.GetComponent<RectTransform>().localPosition.y, Skip.transform.position.z);

                            }

                            if (Player_Line_Up.GetComponent<RectTransform>().localPosition.x == 0)
                                step = 2;
                        }

                        //늘어나는 문자
                        if (step == 2)
                        {
                            if (!StopGame)
                            {
                                Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x - 0.4f, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                                Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x + 0.4f, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                                Player_Typing.GetComponent<RectTransform>().transform.localScale = new Vector3(Player_Typing.GetComponent<RectTransform>().transform.localScale.x + 0.002f, Player_Typing.GetComponent<RectTransform>().transform.localScale.y + 0.002f, Player_Typing.GetComponent<RectTransform>().transform.localScale.z);
                            }

                            else
                            {
                                Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                                Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                                Player_Typing.GetComponent<RectTransform>().transform.localScale = new Vector3(Player_Typing.GetComponent<RectTransform>().transform.localScale.x, Player_Typing.GetComponent<RectTransform>().transform.localScale.y, Player_Typing.GetComponent<RectTransform>().transform.localScale.z);
                            }

                            if (Player_Typing.GetComponent<RectTransform>().transform.localScale.y > 0.57f)
                                step = 3;
                        }

                        //사라진 뒤 재위치
                        if (step == 3)
                        {
                            if (Player_Typing.GetComponent<RectTransform>().localPosition.x == -720)
                            {
                                Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(400, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                                Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(-400, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                                Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(720, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);
                                Skip.GetComponent<RectTransform>().localPosition = new Vector3(400, -260, 0);
                                MusicSource.SFXCHOOSE = true;
                                MusicSource.SFX[5] = true;
                                MusicSource.SE_volume = 0.7f;
                                step = 4;
                            }

                            else
                            {
                                if (!StopGame)
                                {
                                    Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x - 100, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                                    Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x + 100, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                                    Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(Player_Typing.GetComponent<RectTransform>().localPosition.x - 180, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);
                                }

                                else
                                {
                                    Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                                    Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                                    Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(Player_Typing.GetComponent<RectTransform>().localPosition.x, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);
                                }
                            }
                        }

                        if (step == 4) //등장하는 이미지(다음 차례!와 이미지들)
                        {
                            if (Player == 1)
                            {
                                Player_Line_Up.GetComponent<Image>().sprite = GameImage[2];
                                Player_Line_Down.GetComponent<Image>().sprite = GameImage[3];
                            }

                            else
                            {
                                Player_Line_Up.GetComponent<Image>().sprite = GameImage[0];
                                Player_Line_Down.GetComponent<Image>().sprite = GameImage[1];
                            }

                            TypeSaid(14);

                            if (!StopGame)
                            {
                                Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x - 100f, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                                Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x + 100f, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                                Player_Typing.GetComponent<Image>().color = new Color(Player_Typing.GetComponent<Image>().color.r, Player_Typing.GetComponent<Image>().color.g, Player_Typing.GetComponent<Image>().color.b, 1);
                                Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(Player_Typing.GetComponent<RectTransform>().localPosition.x - 180, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);
                            }

                            else
                            {
                                Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                                Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                                Player_Typing.GetComponent<Image>().color = new Color(Player_Typing.GetComponent<Image>().color.r, Player_Typing.GetComponent<Image>().color.g, Player_Typing.GetComponent<Image>().color.b, 1);
                                Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(Player_Typing.GetComponent<RectTransform>().localPosition.x, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);
                            }

                            if (Player_Line_Up.GetComponent<RectTransform>().localPosition.x == 0)
                                step = 5;
                        }

                        //늘어나는 문자
                        if (step == 5)
                        {
                            if (!StopGame)
                            {
                                Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x - 0.2f, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                                Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x + 0.2f, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                                Player_Typing.GetComponent<RectTransform>().transform.localScale = new Vector3(Player_Typing.GetComponent<RectTransform>().transform.localScale.x + 0.002f, Player_Typing.GetComponent<RectTransform>().transform.localScale.y + 0.002f, Player_Typing.GetComponent<RectTransform>().transform.localScale.z);
                            }

                            else
                            {
                                Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                                Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                                Player_Typing.GetComponent<RectTransform>().transform.localScale = new Vector3(Player_Typing.GetComponent<RectTransform>().transform.localScale.x, Player_Typing.GetComponent<RectTransform>().transform.localScale.y, Player_Typing.GetComponent<RectTransform>().transform.localScale.z);
                            }

                            if (Player_Typing.GetComponent<RectTransform>().transform.localScale.y > 0.57f)
                                step = 6;
                        }

                        //사라진 뒤 재위치(문자)
                        if (step == 6)
                        {
                            if (!StopGame)
                            {
                                Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x - 0.2f, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                                Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x + 0.2f, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                            }

                            else
                            {
                                Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                                Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                            }

                            if (Player_Typing.GetComponent<RectTransform>().localPosition.x == -720)
                            {
                                Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(720, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);
                                step = 7;
                            }

                            else
                            {
                                if (!StopGame)
                                {
                                    Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(Player_Typing.GetComponent<RectTransform>().localPosition.x - 180, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);
                                }

                                else
                                {
                                    Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(Player_Typing.GetComponent<RectTransform>().localPosition.x, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);
                                }
                            }
                        }

                        if (step == 7) //등장하는 이미지(플레이어 등장)
                        {
                            if (Player == 1)
                                TypeSaid(8);

                            else
                                TypeSaid(7);

                            if (!StopGame)
                            {
                                Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x - 0.2f, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                                Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x + 0.2f, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                                Player_Typing.GetComponent<Image>().color = new Color(Player_Typing.GetComponent<Image>().color.r, Player_Typing.GetComponent<Image>().color.g, Player_Typing.GetComponent<Image>().color.b, 1);
                                Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(Player_Typing.GetComponent<RectTransform>().localPosition.x - 180, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);
                            }

                            else
                            {
                                Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                                Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                                Player_Typing.GetComponent<Image>().color = new Color(Player_Typing.GetComponent<Image>().color.r, Player_Typing.GetComponent<Image>().color.g, Player_Typing.GetComponent<Image>().color.b, 1);
                                Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(Player_Typing.GetComponent<RectTransform>().localPosition.x, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);
                            }

                            if (Player_Typing.GetComponent<RectTransform>().localPosition.x == 0)
                            {
                                Move = 0;
                                step = 8;
                            }
                        }

                        //바뀌는 버튼
                        if (step == 8)
                        {
                            if (!StopGame)
                            {
                                Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x - 0.2f, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                                Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x + 0.2f, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                                Player_Typing.GetComponent<RectTransform>().transform.localScale = new Vector3(Player_Typing.GetComponent<RectTransform>().transform.localScale.x + 0.002f, Player_Typing.GetComponent<RectTransform>().transform.localScale.y + 0.002f, Player_Typing.GetComponent<RectTransform>().transform.localScale.z);
                            }

                            else
                            {
                                Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                                Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                                Player_Typing.GetComponent<RectTransform>().transform.localScale = new Vector3(Player_Typing.GetComponent<RectTransform>().transform.localScale.x, Player_Typing.GetComponent<RectTransform>().transform.localScale.y, Player_Typing.GetComponent<RectTransform>().transform.localScale.z);
                            }

                            if (Move == 1)
                            {
                                if (button_h.GetComponent<RectTransform>().localPosition.x == -100)
                                {
                                    if (Player_Typing.GetComponent<RectTransform>().transform.localScale.y > 0.57f)
                                    {
                                        Move = 0;

                                        //플레이어 변경
                                        if (Player == 1)
                                            Player = 2;
                                        else
                                            Player = 1;

                                        if (Main_Scene.Selected_stage[0] == 1)
                                            Invisible = true;

                                        step = 9;
                                    }
                                }

                                else
                                {
                                    button_g.GetComponent<Image>().fillAmount = 1;

                                    if (!StopGame)
                                    {
                                        button_h.GetComponent<RectTransform>().localPosition = new Vector3(button_h.GetComponent<RectTransform>().localPosition.x - 5, button_h.GetComponent<RectTransform>().localPosition.y, button_h.transform.position.z);
                                        button_g.GetComponent<RectTransform>().localPosition = new Vector3(button_g.GetComponent<RectTransform>().localPosition.x + 5, button_g.GetComponent<RectTransform>().localPosition.y, button_g.transform.position.z);
                                        First_Timer.GetComponent<RectTransform>().localPosition = new Vector3(First_Timer.GetComponent<RectTransform>().localPosition.x, First_Timer.GetComponent<RectTransform>().localPosition.y + 50, First_Timer.transform.position.z);
                                    }

                                    else
                                    {
                                        button_h.GetComponent<RectTransform>().localPosition = new Vector3(button_h.GetComponent<RectTransform>().localPosition.x, button_h.GetComponent<RectTransform>().localPosition.y, button_h.transform.position.z);
                                        button_g.GetComponent<RectTransform>().localPosition = new Vector3(button_g.GetComponent<RectTransform>().localPosition.x, button_g.GetComponent<RectTransform>().localPosition.y, button_g.transform.position.z);
                                        First_Timer.GetComponent<RectTransform>().localPosition = new Vector3(First_Timer.GetComponent<RectTransform>().localPosition.x, First_Timer.GetComponent<RectTransform>().localPosition.y, First_Timer.transform.position.z);
                                    }
                                }
                            }

                            else
                            {
                                this.ChangeSpeed = 50;

                                if (this.transform.eulerAngles.y > 90)
                                {
                                    transform.Rotate(0, 260f, 0);
                                    this.ChangeSpeed = 0;
                                    timeCount = 0.5f;
                                    Move = 1;
                                }

                                else
                                {
                                    transform.Rotate(0, this.ChangeSpeed, 0);
                                    this.ChangeSpeed *= 0.1f;
                                }

                                ButtonChange();
                            }
                        }

                        //사라짐
                        if (step == 9)
                        {
                            if (Player_Typing.GetComponent<RectTransform>().localPosition.x == -720)
                            {
                                Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(400, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                                Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(-400, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                                Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(720, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);
                                step = 0;
                                Stop_Timer = false;
                                Timer_Check = false;
                                Card.find = false;
                                timer_stop = false;
                                Card.Choosefinished = false;
                                Hap_next = false;
                                Card.Gyeoul = false;
                                Buttonclick = 0;
                            }

                            else
                            {
                                if (!StopGame)
                                {
                                    Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x - 100, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                                    Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x + 100, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                                    Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(Player_Typing.GetComponent<RectTransform>().localPosition.x - 180, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);
                                }

                                else
                                {
                                    Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                                    Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                                    Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(Player_Typing.GetComponent<RectTransform>().localPosition.x, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);
                                }
                            }
                        }

                    }

                    //합 이후에 결을 성공했을 때
                    if (Buttonclick == 234)
                    {
                        if (step == 0) //이미지 등장의 위치를 정함
                        {
                            Achieve();

                            Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(400, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                            Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(-400, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                            Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(720, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);

                            MusicSource.SFXCHOOSE = true;
                            MusicSource.SFX[5] = true;
                            MusicSource.SE_volume = 0.7f;
                            MusicSource.SFXCHOOSE2 = true;
                            MusicSource.SFX2[1] = true;
                            MusicSource.SE2_volume = 0.5f;
                            step = 1;
                        }

                        if (step == 1) //등장하는 이미지 [성공]
                        {
                            Score();
                            Player_Line_Up.GetComponent<Image>().sprite = GameImage[4];
                            Player_Line_Down.GetComponent<Image>().sprite = GameImage[5];

                            TypeSaid(10);

                            if (!StopGame)
                            {
                                Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x - 100, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                                Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x + 100, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                                Player_Typing.GetComponent<Image>().color = new Color(Player_Typing.GetComponent<Image>().color.r, Player_Typing.GetComponent<Image>().color.g, Player_Typing.GetComponent<Image>().color.b, 1);
                                Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(Player_Typing.GetComponent<RectTransform>().localPosition.x - 180, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);
                                Skip.GetComponent<RectTransform>().localPosition = new Vector3(Skip.GetComponent<RectTransform>().localPosition.x, Skip.GetComponent<RectTransform>().localPosition.y - 100, Skip.transform.position.z);
                            }

                            else
                            {
                                Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                                Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                                Player_Typing.GetComponent<Image>().color = new Color(Player_Typing.GetComponent<Image>().color.r, Player_Typing.GetComponent<Image>().color.g, Player_Typing.GetComponent<Image>().color.b, 1);
                                Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(Player_Typing.GetComponent<RectTransform>().localPosition.x, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);
                                Skip.GetComponent<RectTransform>().localPosition = new Vector3(Skip.GetComponent<RectTransform>().localPosition.x, Skip.GetComponent<RectTransform>().localPosition.y, Skip.transform.position.z);
                            }

                            if (Player_Line_Up.GetComponent<RectTransform>().localPosition.x == 0)
                                step = 2;
                        }

                        //늘어나는 문자
                        if (step == 2)
                        {
                            if (!StopGame)
                            {
                                Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x - 0.1f, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                                Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x + 0.1f, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                                Player_Typing.GetComponent<RectTransform>().transform.localScale = new Vector3(Player_Typing.GetComponent<RectTransform>().transform.localScale.x + 0.002f, Player_Typing.GetComponent<RectTransform>().transform.localScale.y + 0.002f, Player_Typing.GetComponent<RectTransform>().transform.localScale.z);

                            }

                            else
                            {
                                Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                                Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                                Player_Typing.GetComponent<RectTransform>().transform.localScale = new Vector3(Player_Typing.GetComponent<RectTransform>().transform.localScale.x, Player_Typing.GetComponent<RectTransform>().transform.localScale.y, Player_Typing.GetComponent<RectTransform>().transform.localScale.z);

                            }

                            if (Player_Typing.GetComponent<RectTransform>().transform.localScale.y > 0.57f)
                                step = 3;
                        }

                        //사라진 뒤 재위치
                        if (step == 3)
                        {
                            if (!StopGame)
                            {
                                Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x - 0.1f, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                                Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x + 0.1f, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                            }

                            else
                            {
                                Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                                Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                            }

                            if (Player_Typing.GetComponent<RectTransform>().localPosition.x == -720)
                            {
                                Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(720, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);
                                Skip.GetComponent<RectTransform>().localPosition = new Vector3(400, -260, 0);
                                MusicSource.SFXCHOOSE = true;
                                MusicSource.SFX[5] = true;
                                MusicSource.SE_volume = 0.7f;
                                step = 4;
                            }

                            else
                            {
                                if (!StopGame)
                                    Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(Player_Typing.GetComponent<RectTransform>().localPosition.x - 180, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);

                                else
                                    Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(Player_Typing.GetComponent<RectTransform>().localPosition.x, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);
                            }
                        }

                        if (step == 4) //등장하는 이미지(게임 끝!)
                        {
                            TypeSaid(13);
                            Player_Typing.GetComponent<Image>().color = new Color(Player_Typing.GetComponent<Image>().color.r, Player_Typing.GetComponent<Image>().color.g, Player_Typing.GetComponent<Image>().color.b, 1);

                            if (Player_Typing.GetComponent<RectTransform>().localPosition.x == 0)
                            {
                                Move = 0;
                                step = 5;
                            }

                            else
                            {
                                if (!StopGame)
                                    Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(Player_Typing.GetComponent<RectTransform>().localPosition.x - 180, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);

                                else
                                    Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(Player_Typing.GetComponent<RectTransform>().localPosition.x, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);
                            }
                        }

                        //바뀌는 버튼
                        if (step == 5)
                        {
                            if (!StopGame)
                                Player_Typing.GetComponent<RectTransform>().transform.localScale = new Vector3(Player_Typing.GetComponent<RectTransform>().transform.localScale.x + 0.002f, Player_Typing.GetComponent<RectTransform>().transform.localScale.y + 0.002f, Player_Typing.GetComponent<RectTransform>().transform.localScale.z);

                            else
                                Player_Typing.GetComponent<RectTransform>().transform.localScale = new Vector3(Player_Typing.GetComponent<RectTransform>().transform.localScale.x, Player_Typing.GetComponent<RectTransform>().transform.localScale.y, Player_Typing.GetComponent<RectTransform>().transform.localScale.z);

                            if (Move == 1)
                            {
                                if (button_h.GetComponent<RectTransform>().localPosition.x == -100)
                                {
                                    if (Player_Typing.GetComponent<RectTransform>().transform.localScale.y > 0.57f)
                                    {
                                        Move = 0;
                                        step = 6;
                                    }
                                }

                                else
                                {
                                    button_g.GetComponent<Image>().fillAmount = 1;

                                    if (!StopGame)
                                    {
                                        button_h.GetComponent<RectTransform>().localPosition = new Vector3(button_h.GetComponent<RectTransform>().localPosition.x - 5, button_h.GetComponent<RectTransform>().localPosition.y, button_h.transform.position.z);
                                        button_g.GetComponent<RectTransform>().localPosition = new Vector3(button_g.GetComponent<RectTransform>().localPosition.x + 5, button_g.GetComponent<RectTransform>().localPosition.y, button_g.transform.position.z);
                                    }

                                    else
                                    {
                                        button_h.GetComponent<RectTransform>().localPosition = new Vector3(button_h.GetComponent<RectTransform>().localPosition.x, button_h.GetComponent<RectTransform>().localPosition.y, button_h.transform.position.z);
                                        button_g.GetComponent<RectTransform>().localPosition = new Vector3(button_g.GetComponent<RectTransform>().localPosition.x, button_g.GetComponent<RectTransform>().localPosition.y, button_g.transform.position.z);
                                    }
                                }
                            }

                            else
                            {
                                this.ChangeSpeed = 50;

                                if (this.transform.eulerAngles.y > 90)
                                {
                                    transform.Rotate(0, 260f, 0);
                                    this.ChangeSpeed = 0;
                                    timeCount = 0.5f;
                                    Move = 1;
                                }

                                else
                                {
                                    transform.Rotate(0, this.ChangeSpeed, 0);
                                    this.ChangeSpeed *= 0.1f;
                                }

                                ButtonChange();
                            }

                        }

                        //사라짐
                        if (step == 6)
                        {
                            if (Player_Typing.GetComponent<RectTransform>().localPosition.x == -720)
                            {
                                Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(400, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                                Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(-400, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                                Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(720, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);
                                step = 0;
                                Stop_Timer = false;
                                Timer_Check = false;
                                Card.find = false;
                                timer_stop = false;
                                Card.Choosefinished = false;
                                Hap_next = false;
                                Card.Gyeoul = false;
                                Buttonclick = 0;
                                Card.Finish = true;
                            }

                            else
                            {
                                if (!StopGame)
                                {
                                    Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x - 100, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                                    Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x + 100, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                                    Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(Player_Typing.GetComponent<RectTransform>().localPosition.x - 180, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);

                                }

                                else
                                {
                                    Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                                    Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                                    Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(Player_Typing.GetComponent<RectTransform>().localPosition.x, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);

                                }
                            }
                        }

                    }

                    //합 이후에 결을 누르지 않고 바로 넘겼을 때
                    if (Buttonclick == 235)
                    {
                        MusicSource.ClockingOff = true;
                        NowButtonclick = 0;

                        if (step == 0) //이미지 등장의 위치를 정함
                        {
                            Score();
                            Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(400, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                            Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(-400, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                            Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(720, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);

                            MusicSource.SFXCHOOSE = true;
                            MusicSource.SFX[5] = true;
                            MusicSource.SE_volume = 0.7f;
                            step = 1;
                        }

                        if (step == 1) //등장하는 이미지(다음 차례!와 이미지들)
                        {
                            if (Player == 1)
                            {
                                Player_Line_Up.GetComponent<Image>().sprite = GameImage[2];
                                Player_Line_Down.GetComponent<Image>().sprite = GameImage[3];
                            }

                            else
                            {
                                Player_Line_Up.GetComponent<Image>().sprite = GameImage[0];
                                Player_Line_Down.GetComponent<Image>().sprite = GameImage[1];
                            }

                            TypeSaid(14);

                            if (Player_Line_Up.GetComponent<RectTransform>().localPosition.x == 0)
                                step = 2;

                            else
                            {
                                if (!StopGame)
                                {
                                    Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x - 100f, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                                    Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x + 100f, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                                    Player_Typing.GetComponent<Image>().color = new Color(Player_Typing.GetComponent<Image>().color.r, Player_Typing.GetComponent<Image>().color.g, Player_Typing.GetComponent<Image>().color.b, 1);
                                    Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(Player_Typing.GetComponent<RectTransform>().localPosition.x - 180, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);
                                    Skip.GetComponent<RectTransform>().localPosition = new Vector3(Skip.GetComponent<RectTransform>().localPosition.x, Skip.GetComponent<RectTransform>().localPosition.y - 100, Skip.transform.position.z);
                                }

                                else
                                {
                                    Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                                    Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                                    Player_Typing.GetComponent<Image>().color = new Color(Player_Typing.GetComponent<Image>().color.r, Player_Typing.GetComponent<Image>().color.g, Player_Typing.GetComponent<Image>().color.b, 1);
                                    Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(Player_Typing.GetComponent<RectTransform>().localPosition.x, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);
                                    Skip.GetComponent<RectTransform>().localPosition = new Vector3(Skip.GetComponent<RectTransform>().localPosition.x, Skip.GetComponent<RectTransform>().localPosition.y, Skip.transform.position.z);
                                }
                            }
                        }

                        //늘어나는 문자
                        if (step == 2)
                        {
                            if (!StopGame)
                            {
                                Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x - 0.2f, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                                Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x + 0.2f, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                                Player_Typing.GetComponent<RectTransform>().transform.localScale = new Vector3(Player_Typing.GetComponent<RectTransform>().transform.localScale.x + 0.002f, Player_Typing.GetComponent<RectTransform>().transform.localScale.y + 0.002f, Player_Typing.GetComponent<RectTransform>().transform.localScale.z);

                            }

                            else
                            {
                                Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                                Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                                Player_Typing.GetComponent<RectTransform>().transform.localScale = new Vector3(Player_Typing.GetComponent<RectTransform>().transform.localScale.x, Player_Typing.GetComponent<RectTransform>().transform.localScale.y, Player_Typing.GetComponent<RectTransform>().transform.localScale.z);

                            }

                            if (Player_Typing.GetComponent<RectTransform>().transform.localScale.y > 0.57f)
                                step = 3;
                        }

                        //사라진 뒤 재위치(문자)
                        if (step == 3)
                        {
                            if (!StopGame)
                            {
                                Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x - 0.2f, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                                Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x + 0.2f, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                            }

                            else
                            {
                                Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                                Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                            }

                            if (Player_Typing.GetComponent<RectTransform>().localPosition.x == -720)
                            {
                                Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(720, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);
                                Skip.GetComponent<RectTransform>().localPosition = new Vector3(400, -260, 0);
                                step = 4;
                            }

                            else
                            {
                                if (!StopGame)
                                    Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(Player_Typing.GetComponent<RectTransform>().localPosition.x - 180, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);

                                else
                                    Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(Player_Typing.GetComponent<RectTransform>().localPosition.x, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);
                            }
                        }

                        if (step == 4) //등장하는 이미지(플레이어 등장)
                        {
                            if (Player == 1)
                                TypeSaid(8);

                            else
                                TypeSaid(7);

                            if (!StopGame)
                            {
                                Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x - 0.2f, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                                Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x + 0.2f, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                                Player_Typing.GetComponent<Image>().color = new Color(Player_Typing.GetComponent<Image>().color.r, Player_Typing.GetComponent<Image>().color.g, Player_Typing.GetComponent<Image>().color.b, 1);
                                Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(Player_Typing.GetComponent<RectTransform>().localPosition.x - 180, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);
                            }

                            else
                            {
                                Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                                Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                                Player_Typing.GetComponent<Image>().color = new Color(Player_Typing.GetComponent<Image>().color.r, Player_Typing.GetComponent<Image>().color.g, Player_Typing.GetComponent<Image>().color.b, 1);
                                Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(Player_Typing.GetComponent<RectTransform>().localPosition.x, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);
                            }

                            if (Player_Typing.GetComponent<RectTransform>().localPosition.x == 0)
                            {
                                Move = 0;
                                step = 5;
                            }
                        }

                        //바뀌는 버튼
                        if (step == 5)
                        {
                            if (!StopGame)
                            {
                                Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x - 0.2f, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                                Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x + 0.2f, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                                Player_Typing.GetComponent<RectTransform>().transform.localScale = new Vector3(Player_Typing.GetComponent<RectTransform>().transform.localScale.x + 0.002f, Player_Typing.GetComponent<RectTransform>().transform.localScale.y + 0.002f, Player_Typing.GetComponent<RectTransform>().transform.localScale.z);

                            }

                            else
                            {
                                Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                                Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                                Player_Typing.GetComponent<RectTransform>().transform.localScale = new Vector3(Player_Typing.GetComponent<RectTransform>().transform.localScale.x, Player_Typing.GetComponent<RectTransform>().transform.localScale.y, Player_Typing.GetComponent<RectTransform>().transform.localScale.z);

                            }

                            if (Move == 1)
                            {
                                if (button_h.GetComponent<RectTransform>().localPosition.x == -100)
                                {
                                    if (Player_Typing.GetComponent<RectTransform>().transform.localScale.y > 0.57f)
                                    {
                                        Move = 0;

                                        //플레이어 변경
                                        if (Player == 1)
                                            Player = 2;
                                        else
                                            Player = 1;

                                        if (Main_Scene.Selected_stage[0] == 1)
                                            Invisible = true;

                                        step = 6;
                                    }
                                }

                                else
                                {
                                    button_g.GetComponent<Image>().fillAmount = 1;

                                    if (!StopGame)
                                    {
                                        button_h.GetComponent<RectTransform>().localPosition = new Vector3(button_h.GetComponent<RectTransform>().localPosition.x - 5, button_h.GetComponent<RectTransform>().localPosition.y, button_h.transform.position.z);
                                        button_g.GetComponent<RectTransform>().localPosition = new Vector3(button_g.GetComponent<RectTransform>().localPosition.x + 5, button_g.GetComponent<RectTransform>().localPosition.y, button_g.transform.position.z);
                                        First_Timer.GetComponent<RectTransform>().localPosition = new Vector3(First_Timer.GetComponent<RectTransform>().localPosition.x, First_Timer.GetComponent<RectTransform>().localPosition.y + 50, First_Timer.transform.position.z);
                                    }

                                    else
                                    {
                                        button_h.GetComponent<RectTransform>().localPosition = new Vector3(button_h.GetComponent<RectTransform>().localPosition.x, button_h.GetComponent<RectTransform>().localPosition.y, button_h.transform.position.z);
                                        button_g.GetComponent<RectTransform>().localPosition = new Vector3(button_g.GetComponent<RectTransform>().localPosition.x, button_g.GetComponent<RectTransform>().localPosition.y, button_g.transform.position.z);
                                        First_Timer.GetComponent<RectTransform>().localPosition = new Vector3(First_Timer.GetComponent<RectTransform>().localPosition.x, First_Timer.GetComponent<RectTransform>().localPosition.y, First_Timer.transform.position.z);
                                    }

                                }
                            }

                            else
                            {
                                this.ChangeSpeed = 50;

                                if (this.transform.eulerAngles.y > 90)
                                {
                                    transform.Rotate(0, 260f, 0);
                                    this.ChangeSpeed = 0;
                                    timeCount = 0.5f;
                                    Move = 1;
                                }

                                else
                                {
                                    transform.Rotate(0, this.ChangeSpeed, 0);
                                    this.ChangeSpeed *= 0.1f;
                                }

                                ButtonChange();
                            }
                        }

                        //사라짐
                        if (step == 6)
                        {
                            if (Player_Typing.GetComponent<RectTransform>().localPosition.x == -720)
                            {
                                Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(400, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                                Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(-400, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                                Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(720, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);
                                step = 0;
                                Stop_Timer = false;
                                Timer_Check = false;
                                Card.find = false;
                                timer_stop = false;
                                Card.Choosefinished = false;
                                Hap_next = false;
                                Card.Gyeoul = false;
                                Buttonclick = 0;
                            }

                            else
                            {
                                if (!StopGame)
                                {
                                    Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x - 100, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                                    Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x + 100, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                                    Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(Player_Typing.GetComponent<RectTransform>().localPosition.x - 180, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);
                                }

                                else
                                {
                                    Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                                    Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                                    Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(Player_Typing.GetComponent<RectTransform>().localPosition.x, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);
                                }
                            }
                        }
                    }

                    //3번. 결을 눌렀을 때
                    if (Buttonclick == 3)
                    {
                        if (step == 0)
                        {
                            if (!StopGame)
                            {
                                button_h.GetComponent<RectTransform>().localPosition = new Vector3(button_h.GetComponent<RectTransform>().localPosition.x - 40, button_h.GetComponent<RectTransform>().localPosition.y, button_h.transform.position.z);
                                button_g.GetComponent<RectTransform>().localPosition = new Vector3(button_g.GetComponent<RectTransform>().localPosition.x - 20, button_g.GetComponent<RectTransform>().localPosition.y, button_g.transform.position.z);
                                First_Timer.GetComponent<RectTransform>().localPosition = new Vector3(First_Timer.GetComponent<RectTransform>().localPosition.x, First_Timer.GetComponent<RectTransform>().localPosition.y - 40, First_Timer.transform.position.z);
                            }

                            else
                            {
                                button_h.GetComponent<RectTransform>().localPosition = new Vector3(button_h.GetComponent<RectTransform>().localPosition.x, button_h.GetComponent<RectTransform>().localPosition.y, button_h.transform.position.z);
                                button_g.GetComponent<RectTransform>().localPosition = new Vector3(button_g.GetComponent<RectTransform>().localPosition.x, button_g.GetComponent<RectTransform>().localPosition.y, button_g.transform.position.z);
                                First_Timer.GetComponent<RectTransform>().localPosition = new Vector3(First_Timer.GetComponent<RectTransform>().localPosition.x, First_Timer.GetComponent<RectTransform>().localPosition.y, First_Timer.transform.position.z);
                            }

                            if (button_g.GetComponent<RectTransform>().localPosition.x == 0)
                            {
                                step = 1;
                            }
                        }

                        if (step == 1)
                        {
                            Main_Scene.Score = true;
                            step = 2;
                        }

                        if (step == 2)
                        {
                            if (AnswerG)
                                step = 3;
                        }

                        if (step == 3)
                        {
                            if (!Card.find) //결이 아닐 때
                            {
                                NowButtonclick = 0;
                                Buttonclick = 31;
                                AnswerG = false;
                                step = 0;
                            }

                            else //결일 때
                            {
                                NowButtonclick = 0;
                                Buttonclick = 32;
                                AnswerG = false;
                                step = 0;
                            }
                        }
                    }

                    //결을 실패했을 때
                    if (Buttonclick == 31)
                    {
                        if (step == 0) //이미지 등장의 위치를 정함
                        {
                            Card.FailAnswer++;
                            Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(400, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                            Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(-400, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                            Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(720, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);

                            MusicSource.SFXCHOOSE = true;
                            MusicSource.SFX[5] = true;
                            MusicSource.SE_volume = 0.7f;
                            MusicSource.SFXCHOOSE2 = true;
                            MusicSource.SFX2[2] = true;
                            MusicSource.SE2_volume = 0.7f;
                            step = 1;
                        }

                        if (step == 1) //등장하는 이미지 [실패]
                        {
                            Score();
                            Player_Line_Up.GetComponent<Image>().sprite = GameImage[4];
                            Player_Line_Down.GetComponent<Image>().sprite = GameImage[5];

                            TypeSaid(11);

                            if (!StopGame)
                            {
                                Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x - 100, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                                Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x + 100, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                                Player_Typing.GetComponent<Image>().color = new Color(Player_Typing.GetComponent<Image>().color.r, Player_Typing.GetComponent<Image>().color.g, Player_Typing.GetComponent<Image>().color.b, 1);
                                Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(Player_Typing.GetComponent<RectTransform>().localPosition.x - 180, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);
                            }

                            else
                            {
                                Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                                Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                                Player_Typing.GetComponent<Image>().color = new Color(Player_Typing.GetComponent<Image>().color.r, Player_Typing.GetComponent<Image>().color.g, Player_Typing.GetComponent<Image>().color.b, 1);
                                Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(Player_Typing.GetComponent<RectTransform>().localPosition.x, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);
                            }

                            if (Player_Line_Up.GetComponent<RectTransform>().localPosition.x == 0)
                                step = 2;
                        }

                        //늘어나는 문자
                        if (step == 2)
                        {
                            if (!StopGame)
                            {
                                Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x - 0.4f, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                                Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x + 0.4f, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                                Player_Typing.GetComponent<RectTransform>().transform.localScale = new Vector3(Player_Typing.GetComponent<RectTransform>().transform.localScale.x + 0.002f, Player_Typing.GetComponent<RectTransform>().transform.localScale.y + 0.002f, Player_Typing.GetComponent<RectTransform>().transform.localScale.z);
                            }

                            else
                            {
                                Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                                Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                                Player_Typing.GetComponent<RectTransform>().transform.localScale = new Vector3(Player_Typing.GetComponent<RectTransform>().transform.localScale.x, Player_Typing.GetComponent<RectTransform>().transform.localScale.y, Player_Typing.GetComponent<RectTransform>().transform.localScale.z);

                            }

                            if (Player_Typing.GetComponent<RectTransform>().transform.localScale.y > 0.57f)
                                step = 3;
                        }

                        //사라진 뒤 재위치
                        if (step == 3)
                        {
                            if (Player_Typing.GetComponent<RectTransform>().localPosition.x == -720)
                            {
                                Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(400, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                                Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(-400, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                                Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(720, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);
                                MusicSource.SFXCHOOSE = true;
                                MusicSource.SFX[5] = true;
                                MusicSource.SE_volume = 0.7f;
                                step = 4;
                            }

                            else
                            {
                                if (!StopGame)
                                {
                                    Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x - 100, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                                    Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x + 100, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                                    Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(Player_Typing.GetComponent<RectTransform>().localPosition.x - 180, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);
                                }

                                else
                                {
                                    Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                                    Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                                    Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(Player_Typing.GetComponent<RectTransform>().localPosition.x, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);
                                }
                            }
                        }

                        if (step == 4) //등장하는 이미지(다음 차례!와 이미지들)
                        {
                            if (Player == 1)
                            {
                                Player_Line_Up.GetComponent<Image>().sprite = GameImage[2];
                                Player_Line_Down.GetComponent<Image>().sprite = GameImage[3];
                            }

                            else
                            {
                                Player_Line_Up.GetComponent<Image>().sprite = GameImage[0];
                                Player_Line_Down.GetComponent<Image>().sprite = GameImage[1];
                            }

                            TypeSaid(14);

                            if (!StopGame)
                            {
                                Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x - 100f, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                                Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x + 100f, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                                Player_Typing.GetComponent<Image>().color = new Color(Player_Typing.GetComponent<Image>().color.r, Player_Typing.GetComponent<Image>().color.g, Player_Typing.GetComponent<Image>().color.b, 1);
                                Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(Player_Typing.GetComponent<RectTransform>().localPosition.x - 180, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);
                            }

                            else
                            {
                                Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                                Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                                Player_Typing.GetComponent<Image>().color = new Color(Player_Typing.GetComponent<Image>().color.r, Player_Typing.GetComponent<Image>().color.g, Player_Typing.GetComponent<Image>().color.b, 1);
                                Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(Player_Typing.GetComponent<RectTransform>().localPosition.x, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);
                            }

                            if (Player_Line_Up.GetComponent<RectTransform>().localPosition.x == 0)
                                step = 5;
                        }

                        //늘어나는 문자
                        if (step == 5)
                        {
                            if (!StopGame)
                            {
                                Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x - 0.2f, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                                Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x + 0.2f, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                                Player_Typing.GetComponent<RectTransform>().transform.localScale = new Vector3(Player_Typing.GetComponent<RectTransform>().transform.localScale.x + 0.002f, Player_Typing.GetComponent<RectTransform>().transform.localScale.y + 0.002f, Player_Typing.GetComponent<RectTransform>().transform.localScale.z);
                            }

                            else
                            {
                                Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                                Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                                Player_Typing.GetComponent<RectTransform>().transform.localScale = new Vector3(Player_Typing.GetComponent<RectTransform>().transform.localScale.x, Player_Typing.GetComponent<RectTransform>().transform.localScale.y, Player_Typing.GetComponent<RectTransform>().transform.localScale.z);

                            }

                            if (Player_Typing.GetComponent<RectTransform>().transform.localScale.y > 0.57f)
                                step = 6;
                        }

                        //사라진 뒤 재위치(문자)
                        if (step == 6)
                        {
                            if (!StopGame)
                            {
                                Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x - 0.2f, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                                Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x + 0.2f, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                            }

                            else
                            {
                                Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                                Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                            }

                            if (Player_Typing.GetComponent<RectTransform>().localPosition.x == -720)
                            {
                                Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(720, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);
                                step = 7;
                            }

                            else
                            {
                                if (!StopGame)
                                    Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(Player_Typing.GetComponent<RectTransform>().localPosition.x - 180, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);

                                else
                                    Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(Player_Typing.GetComponent<RectTransform>().localPosition.x, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);

                            }
                        }

                        if (step == 7) //등장하는 이미지(플레이어 등장)
                        {
                            if (Player == 1)
                                TypeSaid(8);

                            else
                                TypeSaid(7);

                            if (!StopGame)
                            {
                                Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x - 0.2f, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                                Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x + 0.2f, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                                Player_Typing.GetComponent<Image>().color = new Color(Player_Typing.GetComponent<Image>().color.r, Player_Typing.GetComponent<Image>().color.g, Player_Typing.GetComponent<Image>().color.b, 1);
                                Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(Player_Typing.GetComponent<RectTransform>().localPosition.x - 180, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);
                            }

                            else
                            {
                                Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                                Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                                Player_Typing.GetComponent<Image>().color = new Color(Player_Typing.GetComponent<Image>().color.r, Player_Typing.GetComponent<Image>().color.g, Player_Typing.GetComponent<Image>().color.b, 1);
                                Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(Player_Typing.GetComponent<RectTransform>().localPosition.x, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);
                            }

                            if (Player_Typing.GetComponent<RectTransform>().localPosition.x == 0)
                            {
                                Move = 0;
                                step = 8;
                            }
                        }

                        //바뀌는 버튼
                        if (step == 8)
                        {
                            if (!StopGame)
                            {
                                Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x - 0.2f, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                                Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x + 0.2f, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                                Player_Typing.GetComponent<RectTransform>().transform.localScale = new Vector3(Player_Typing.GetComponent<RectTransform>().transform.localScale.x + 0.002f, Player_Typing.GetComponent<RectTransform>().transform.localScale.y + 0.002f, Player_Typing.GetComponent<RectTransform>().transform.localScale.z);
                            }

                            else
                            {
                                Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                                Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                                Player_Typing.GetComponent<RectTransform>().transform.localScale = new Vector3(Player_Typing.GetComponent<RectTransform>().transform.localScale.x, Player_Typing.GetComponent<RectTransform>().transform.localScale.y, Player_Typing.GetComponent<RectTransform>().transform.localScale.z);
                            }

                            if (Move == 1)
                            {
                                if (button_h.GetComponent<RectTransform>().localPosition.x == -100)
                                {
                                    if (Player_Typing.GetComponent<RectTransform>().transform.localScale.y > 0.57f)
                                    {
                                        Move = 0;

                                        //플레이어 변경
                                        if (Player == 1)
                                            Player = 2;
                                        else
                                            Player = 1;

                                        if (Main_Scene.Selected_stage[0] == 1)
                                            Invisible = true;

                                        step = 9;
                                    }
                                }

                                else
                                {
                                    button_h.GetComponent<Image>().fillAmount = 1;

                                    if (!StopGame)
                                    {
                                        button_h.GetComponent<RectTransform>().localPosition = new Vector3(button_h.GetComponent<RectTransform>().localPosition.x + 40, button_h.GetComponent<RectTransform>().localPosition.y, button_h.transform.position.z);
                                        button_g.GetComponent<RectTransform>().localPosition = new Vector3(button_g.GetComponent<RectTransform>().localPosition.x + 20, button_g.GetComponent<RectTransform>().localPosition.y, button_g.transform.position.z);
                                        First_Timer.GetComponent<RectTransform>().localPosition = new Vector3(First_Timer.GetComponent<RectTransform>().localPosition.x, First_Timer.GetComponent<RectTransform>().localPosition.y + 40, First_Timer.transform.position.z);
                                    }

                                    else
                                    {
                                        button_h.GetComponent<RectTransform>().localPosition = new Vector3(button_h.GetComponent<RectTransform>().localPosition.x, button_h.GetComponent<RectTransform>().localPosition.y, button_h.transform.position.z);
                                        button_g.GetComponent<RectTransform>().localPosition = new Vector3(button_g.GetComponent<RectTransform>().localPosition.x, button_g.GetComponent<RectTransform>().localPosition.y, button_g.transform.position.z);
                                        First_Timer.GetComponent<RectTransform>().localPosition = new Vector3(First_Timer.GetComponent<RectTransform>().localPosition.x, First_Timer.GetComponent<RectTransform>().localPosition.y, First_Timer.transform.position.z);
                                    }
                                }
                            }

                            else
                            {
                                this.ChangeSpeed = 50;

                                if (this.transform.eulerAngles.y > 90)
                                {
                                    this.button_h.GetComponent<Image>().fillAmount = 1;
                                    transform.Rotate(0, 260f, 0);
                                    this.ChangeSpeed = 0;
                                    timeCount = 0.5f;
                                    Move = 1;
                                }

                                else
                                {
                                    transform.Rotate(0, this.ChangeSpeed, 0);
                                    this.ChangeSpeed *= 0.1f;
                                }

                                ButtonChange();
                            }
                        }

                        //사라진 뒤 재위치
                        if (step == 9)
                        {
                            if (Player_Typing.GetComponent<RectTransform>().localPosition.x == -720)
                            {
                                Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(400, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                                Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(-400, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                                Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(720, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);
                                step = 0;
                                Card.Gyeoul = false;
                                Stop_Timer = false;
                                Timer_Check = false;
                                Card.find = false;
                                timer_stop = false;
                                Buttonclick = 0;

                                if (Card.FailAnswer >= 5)
                                    Card.ShowHint = true;
                            }

                            else
                            {
                                if (!StopGame)
                                {
                                    Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x - 100, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                                    Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x + 100, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                                    Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(Player_Typing.GetComponent<RectTransform>().localPosition.x - 180, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);
                                }

                                else
                                {
                                    Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                                    Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                                    Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(Player_Typing.GetComponent<RectTransform>().localPosition.x, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);
                                }
                            }
                        }

                    }

                    //결을 성공했을 때
                    if (Buttonclick == 32)
                    {
                        if (step == 0) //이미지 등장의 위치를 정함
                        {
                            Achieve();

                            Card.FailAnswer = 0;
                            Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(400, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                            Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(-400, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                            Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(720, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);
                            MusicSource.SFXCHOOSE = true;
                            MusicSource.SFX[5] = true;
                            MusicSource.SE_volume = 0.7f;
                            MusicSource.SFXCHOOSE2 = true;
                            MusicSource.SFX2[1] = true;
                            MusicSource.SE2_volume = 0.5f;

                            step = 1;
                        }

                        if (step == 1) //등장하는 이미지 [성공]
                        {
                            Score();
                            Player_Line_Up.GetComponent<Image>().sprite = GameImage[4];
                            Player_Line_Down.GetComponent<Image>().sprite = GameImage[5];

                            TypeSaid(10);

                            if (!StopGame)
                            {
                                Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x - 100, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                                Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x + 100, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                                Player_Typing.GetComponent<Image>().color = new Color(Player_Typing.GetComponent<Image>().color.r, Player_Typing.GetComponent<Image>().color.g, Player_Typing.GetComponent<Image>().color.b, 1);
                                Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(Player_Typing.GetComponent<RectTransform>().localPosition.x - 180, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);
                            }

                            else
                            {
                                Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                                Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                                Player_Typing.GetComponent<Image>().color = new Color(Player_Typing.GetComponent<Image>().color.r, Player_Typing.GetComponent<Image>().color.g, Player_Typing.GetComponent<Image>().color.b, 1);
                                Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(Player_Typing.GetComponent<RectTransform>().localPosition.x, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);
                            }

                            if (Player_Line_Up.GetComponent<RectTransform>().localPosition.x == 0)
                                step = 2;
                        }

                        //늘어나는 문자
                        if (step == 2)
                        {
                            if (!StopGame)
                            {
                                Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x - 0.1f, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                                Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x + 0.1f, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                                Player_Typing.GetComponent<RectTransform>().transform.localScale = new Vector3(Player_Typing.GetComponent<RectTransform>().transform.localScale.x + 0.002f, Player_Typing.GetComponent<RectTransform>().transform.localScale.y + 0.002f, Player_Typing.GetComponent<RectTransform>().transform.localScale.z);
                            }

                            else
                            {
                                Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                                Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                                Player_Typing.GetComponent<RectTransform>().transform.localScale = new Vector3(Player_Typing.GetComponent<RectTransform>().transform.localScale.x, Player_Typing.GetComponent<RectTransform>().transform.localScale.y, Player_Typing.GetComponent<RectTransform>().transform.localScale.z);
                            }

                            if (Player_Typing.GetComponent<RectTransform>().transform.localScale.y > 0.57f)
                                step = 3;
                        }

                        //사라진 뒤 재위치
                        if (step == 3)
                        {
                            if (!StopGame)
                            {
                                Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x - 0.1f, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                                Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x + 0.1f, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                            }

                            else
                            {
                                Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                                Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                            }

                            if (Player_Typing.GetComponent<RectTransform>().localPosition.x == -720)
                            {
                                Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(720, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);
                                MusicSource.SFXCHOOSE = true;
                                MusicSource.SFX[5] = true;
                                MusicSource.SE_volume = 0.7f;
                                step = 4;
                            }

                            else
                            {
                                if (!StopGame)
                                    Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(Player_Typing.GetComponent<RectTransform>().localPosition.x - 180, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);

                                else
                                    Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(Player_Typing.GetComponent<RectTransform>().localPosition.x, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);
                            }
                        }

                        if (step == 4) //등장하는 이미지(게임 끝!)
                        {
                            TypeSaid(13);
                            Player_Typing.GetComponent<Image>().color = new Color(Player_Typing.GetComponent<Image>().color.r, Player_Typing.GetComponent<Image>().color.g, Player_Typing.GetComponent<Image>().color.b, 1);

                            if (Player_Typing.GetComponent<RectTransform>().localPosition.x == 0)
                            {
                                Move = 0;
                                step = 5;
                            }

                            else
                            {
                                if (!StopGame)
                                    Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(Player_Typing.GetComponent<RectTransform>().localPosition.x - 180, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);

                                else
                                    Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(Player_Typing.GetComponent<RectTransform>().localPosition.x, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);
                            }
                        }

                        //바뀌는 버튼
                        if (step == 5)
                        {
                            if (!StopGame)
                                Player_Typing.GetComponent<RectTransform>().transform.localScale = new Vector3(Player_Typing.GetComponent<RectTransform>().transform.localScale.x + 0.002f, Player_Typing.GetComponent<RectTransform>().transform.localScale.y + 0.002f, Player_Typing.GetComponent<RectTransform>().transform.localScale.z);

                            else
                                Player_Typing.GetComponent<RectTransform>().transform.localScale = new Vector3(Player_Typing.GetComponent<RectTransform>().transform.localScale.x, Player_Typing.GetComponent<RectTransform>().transform.localScale.y, Player_Typing.GetComponent<RectTransform>().transform.localScale.z);

                            if (Move == 1)
                            {
                                if (button_h.GetComponent<RectTransform>().localPosition.x == -100)
                                {
                                    if (Player_Typing.GetComponent<RectTransform>().transform.localScale.y > 0.57f)
                                    {
                                        Move = 0;
                                        step = 6;
                                    }
                                }

                                else
                                {
                                    button_g.GetComponent<Image>().fillAmount = 1;

                                    if (!StopGame)
                                    {
                                        button_h.GetComponent<RectTransform>().localPosition = new Vector3(button_h.GetComponent<RectTransform>().localPosition.x + 40, button_h.GetComponent<RectTransform>().localPosition.y, button_h.transform.position.z);
                                        button_g.GetComponent<RectTransform>().localPosition = new Vector3(button_g.GetComponent<RectTransform>().localPosition.x + 20, button_g.GetComponent<RectTransform>().localPosition.y, button_g.transform.position.z);
                                    }

                                    else
                                    {
                                        button_h.GetComponent<RectTransform>().localPosition = new Vector3(button_h.GetComponent<RectTransform>().localPosition.x, button_h.GetComponent<RectTransform>().localPosition.y, button_h.transform.position.z);
                                        button_g.GetComponent<RectTransform>().localPosition = new Vector3(button_g.GetComponent<RectTransform>().localPosition.x, button_g.GetComponent<RectTransform>().localPosition.y, button_g.transform.position.z);
                                    }
                                }
                            }

                            else
                            {
                                this.ChangeSpeed = 50;

                                if (this.transform.eulerAngles.y > 90)
                                {
                                    transform.Rotate(0, 260f, 0);
                                    this.ChangeSpeed = 0;
                                    timeCount = 0.5f;
                                    Move = 1;
                                }

                                else
                                {
                                    transform.Rotate(0, this.ChangeSpeed, 0);
                                    this.ChangeSpeed *= 0.1f;
                                }

                                ButtonChange();
                            }
                        }

                        //사라짐
                        if (step == 6)
                        {
                            if (Player_Typing.GetComponent<RectTransform>().localPosition.x == -720)
                            {
                                Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(400, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                                Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(-400, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                                Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(720, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);
                                step = 0;
                                Stop_Timer = false;
                                Timer_Check = false;
                                Card.find = false;
                                timer_stop = false;
                                Card.Choosefinished = false;
                                Hap_next = false;
                                Card.Gyeoul = false;
                                Buttonclick = 0;
                                Card.Finish = true;
                            }

                            else
                            {
                                if (!StopGame)
                                {
                                    Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x - 100, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                                    Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x + 100, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                                    Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(Player_Typing.GetComponent<RectTransform>().localPosition.x - 180, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);
                                }

                                else
                                {
                                    Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                                    Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                                    Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(Player_Typing.GetComponent<RectTransform>().localPosition.x, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);
                                }
                            }
                        }

                    }

                }

                //0번. 합과 결 버튼을 누르지 않았을 때
                else
                {
                    NowButtonclick = 1;

                    if (!Game_Start)
                    {
                        if (Start_Timer)
                        {
                            for (int i = 0; i < 16; i++)
                                Card.Position[i].GetComponent<Image>().color = new Color(0, 0, 0, 0);

                            if (!timer_stop)
                            {
                                Check_timer -= Time.deltaTime / 10f;
                                DecreaseTimer2();

                                //타이머 종료 시 탈출
                                if (Check_timer < 0)
                                {
                                    this.First_Timer.GetComponent<Image>().fillAmount = 1;
                                    Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(0, 0, 0);
                                    step = 0;
                                    timer_stop = true;
                                }

                                //타이머가 종료되기 전에 버튼이 눌려지면
                                if (Stop_Timer)
                                {
                                    NowButtonclick = 0;
                                    Check_timer = 50;
                                    this.First_Timer.GetComponent<Image>().fillAmount = 1;
                                    step = 0;
                                    Timer_Check = true;
                                }
                            }

                            else
                            {
                                if (step == 0) //이미지 등장의 위치를 정함
                                {
                                    Card.FailAnswer++;
                                    Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(400, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                                    Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(-400, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                                    Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(720, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);

                                    MusicSource.SFXCHOOSE = true;
                                    MusicSource.SFX[6] = true;
                                    MusicSource.SE_volume = 0.7f;
                                    step = 1;
                                }

                                if (step == 1) //등장하는 이미지
                                {
                                    if (Player == 2)
                                    {
                                        Player_Line_Up.GetComponent<Image>().sprite = GameImage[0];
                                        Player_Line_Down.GetComponent<Image>().sprite = GameImage[1];
                                        TypeSaid(7);
                                    }

                                    else
                                    {
                                        Player_Line_Up.GetComponent<Image>().sprite = GameImage[2];
                                        Player_Line_Down.GetComponent<Image>().sprite = GameImage[3];
                                        TypeSaid(8);
                                    }

                                    if (!StopGame)
                                    {
                                        Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x - 2.5f, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                                        Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x + 2.5f, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                                        Player_Typing.GetComponent<Image>().color = new Color(Player_Typing.GetComponent<Image>().color.r, Player_Typing.GetComponent<Image>().color.g, Player_Typing.GetComponent<Image>().color.b, 1);
                                        Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(Player_Typing.GetComponent<RectTransform>().localPosition.x - 4.5f, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);
                                    }

                                    else
                                    {
                                        Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                                        Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                                        Player_Typing.GetComponent<Image>().color = new Color(Player_Typing.GetComponent<Image>().color.r, Player_Typing.GetComponent<Image>().color.g, Player_Typing.GetComponent<Image>().color.b, 1);
                                        Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(Player_Typing.GetComponent<RectTransform>().localPosition.x, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);
                                    }

                                    if (Player_Line_Up.GetComponent<RectTransform>().localPosition.x == 0)
                                    {
                                        step = 2;
                                    }
                                }

                                //바뀌는 버튼
                                if (step == 2)
                                {
                                    if (!StopGame)
                                    {
                                        Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x - 0.005f, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                                        Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x + 0.005f, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                                    }

                                    else
                                    {
                                        Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                                        Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                                    }

                                    Check_timer = 50;
                                    this.ChangeSpeed = 50;

                                    if (Move == 0)
                                    {
                                        ButtonChange();

                                        if (Main_Scene.Selected_stage[0] == 1)
                                            Invisible = true;

                                        Move = 1;
                                    }

                                    else
                                    {
                                        if (this.First_Timer.transform.eulerAngles.y > 90)
                                        {
                                            First_Timer.transform.Rotate(0, 260f, 0);
                                            if (Player == 1) { Player = 2; }
                                            else { Player = 1; }
                                            Check_timer = 50;
                                            step = 3;
                                        }

                                        else
                                        {
                                            First_Timer.transform.Rotate(0, this.ChangeSpeed, 0);
                                            this.ChangeSpeed *= 0.1f;
                                        }
                                    }
                                }

                                //늘어나는 문자
                                if (step == 3)
                                {
                                    if (!StopGame)
                                    {
                                        Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x - 0.005f, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                                        Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x + 0.005f, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                                        Player_Typing.GetComponent<RectTransform>().transform.localScale = new Vector3(Player_Typing.GetComponent<RectTransform>().transform.localScale.x + 0.00005f, Player_Typing.GetComponent<RectTransform>().transform.localScale.y + 0.00005f, Player_Typing.GetComponent<RectTransform>().transform.localScale.z);

                                    }

                                    else
                                    {
                                        Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                                        Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                                        Player_Typing.GetComponent<RectTransform>().transform.localScale = new Vector3(Player_Typing.GetComponent<RectTransform>().transform.localScale.x, Player_Typing.GetComponent<RectTransform>().transform.localScale.y, Player_Typing.GetComponent<RectTransform>().transform.localScale.z);

                                    }

                                    if (Player_Typing.GetComponent<RectTransform>().transform.localScale.y > 0.57f)
                                        step = 4;
                                }

                                //재위치
                                if (step == 4)
                                {
                                    if (Player_Typing.GetComponent<RectTransform>().localPosition.x == -720)
                                    {
                                        Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(400, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                                        Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(-400, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                                        Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(15400, 0, 0);
                                        Move = 0;
                                        timer_stop = false;

                                        if (Card.FailAnswer >= 5)
                                            Card.ShowHint = true;
                                    }

                                    else
                                    {
                                        if (!StopGame)
                                        {
                                            Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x - 2.5f, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                                            Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x + 2.5f, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                                            Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(Player_Typing.GetComponent<RectTransform>().localPosition.x - 4.5f, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);
                                        }

                                        else
                                        {
                                            Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                                            Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                                            Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(Player_Typing.GetComponent<RectTransform>().localPosition.x, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);
                                        }
                                    }
                                }
                            }
                        }
                    }

                    else
                    {
                        if (step == 0) //이미지 등장의 위치를 정함
                        {
                            Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(400, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                            Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(-400, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                            Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(720, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);

                            if (Card.LastWinner == 2 || Card.LastWinner == 0)
                            {
                                Player_Line_Up.GetComponent<Image>().sprite = GameImage[0];
                                Player_Line_Down.GetComponent<Image>().sprite = GameImage[1];
                                TypeSaid(7);
                            }

                            else if (Card.LastWinner == 1)
                            {
                                Player_Line_Up.GetComponent<Image>().sprite = GameImage[2];
                                Player_Line_Down.GetComponent<Image>().sprite = GameImage[3];
                                TypeSaid(8);
                            }

                            MusicSource.SFXCHOOSE = true;
                            MusicSource.SFX[5] = true;
                            MusicSource.SE_volume = 0.7f;
                            step = 1;
                        }

                        if (step == 1) //등장하는 이미지
                        {
                            if (!StopGame)
                            {
                                Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x - 2.5f, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                                Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x + 2.5f, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                                Player_Typing.GetComponent<Image>().color = new Color(Player_Typing.GetComponent<Image>().color.r, Player_Typing.GetComponent<Image>().color.g, Player_Typing.GetComponent<Image>().color.b, 1);
                                Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(Player_Typing.GetComponent<RectTransform>().localPosition.x - 4.5f, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);
                            }

                            else
                            {
                                Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                                Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                                Player_Typing.GetComponent<Image>().color = new Color(Player_Typing.GetComponent<Image>().color.r, Player_Typing.GetComponent<Image>().color.g, Player_Typing.GetComponent<Image>().color.b, 1);
                                Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(Player_Typing.GetComponent<RectTransform>().localPosition.x, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);
                            }

                            if (Player_Line_Up.GetComponent<RectTransform>().localPosition.x == 0)
                                step = 2;
                        }

                        //늘어나는 문자
                        if (step == 2)
                        {
                            if (!StopGame)
                            {
                                Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x - 0.005f, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                                Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x + 0.005f, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                                Player_Typing.GetComponent<RectTransform>().transform.localScale = new Vector3(Player_Typing.GetComponent<RectTransform>().transform.localScale.x + 0.00005f, Player_Typing.GetComponent<RectTransform>().transform.localScale.y + 0.00005f, Player_Typing.GetComponent<RectTransform>().transform.localScale.z);
                            }

                            else
                            {
                                Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                                Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                                Player_Typing.GetComponent<RectTransform>().transform.localScale = new Vector3(Player_Typing.GetComponent<RectTransform>().transform.localScale.x, Player_Typing.GetComponent<RectTransform>().transform.localScale.y, Player_Typing.GetComponent<RectTransform>().transform.localScale.z);
                            }

                            if (Player_Typing.GetComponent<RectTransform>().transform.localScale.y > 0.58f)
                                step = 3;
                        }

                        //재위치
                        if (step == 3)
                        {
                            if (Player_Typing.GetComponent<RectTransform>().localPosition.x == -720)
                            {
                                Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(400, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                                Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(-400, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                                Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(15400, 0, 0);
                                Move = 0;
                                Check_timer = 50;
                                Game_Start = false;
                                Start_Timer = true;
                                NowButtonclick = 1;
                                step = 0;
                            }

                            else
                            {
                                if (!StopGame)
                                {
                                    Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x - 2.5f, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                                    Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x + 2.5f, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                                    Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(Player_Typing.GetComponent<RectTransform>().localPosition.x - 4.5f, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);
                                }

                                else
                                {
                                    Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                                    Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                                    Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(Player_Typing.GetComponent<RectTransform>().localPosition.x, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);
                                }
                            }
                        }
                    }
                }
            }

            else
            {
                Buttonclick = -1;
                NowButtonclick = 0;
                Player = 1;
                timeCount = 0;
                Move = 0;
                choose_card = 0; //합을 위해 선택된 카드의 수를 가지도록 하는 것.
            }

            if (Winner) //등장하는 장면
            {
                if (!QuitGame)
                {
                    if (step == 0) //이미지 등장의 위치를 정함
                    {
                        Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(400, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                        Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(-400, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                        Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(720, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);
                        MusicSource.SFXCHOOSE = true;
                        MusicSource.SFX[7] = true;
                        MusicSource.SE_volume = 1f;
                        MusicSource.volume = 0;

                        step = 1;
                    }

                    if (step == 1) //등장하는 이미지
                    {
                        Player_Line_Up.GetComponent<Image>().sprite = GameImage[4];
                        Player_Line_Down.GetComponent<Image>().sprite = GameImage[5];
                        TypeSaid(16);

                        if (!StopGame)
                        {
                            Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x - 5f, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                            Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x + 5f, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                            Player_Typing.GetComponent<Image>().color = new Color(Player_Typing.GetComponent<Image>().color.r, Player_Typing.GetComponent<Image>().color.g, Player_Typing.GetComponent<Image>().color.b, 1);
                            Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(Player_Typing.GetComponent<RectTransform>().localPosition.x - 9f, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);
                        }

                        else
                        {
                            Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                            Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                            Player_Typing.GetComponent<Image>().color = new Color(Player_Typing.GetComponent<Image>().color.r, Player_Typing.GetComponent<Image>().color.g, Player_Typing.GetComponent<Image>().color.b, 1);
                            Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(Player_Typing.GetComponent<RectTransform>().localPosition.x, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);
                        }

                        if (Player_Line_Up.GetComponent<RectTransform>().localPosition.x == 0)
                            step = 2;
                    }

                    //늘어나는 문자(우승!)
                    if (step == 2)
                    {
                        if (!StopGame)
                        {
                            Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x - 0.005f, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                            Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x + 0.005f, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                            Player_Typing.GetComponent<RectTransform>().transform.localScale = new Vector3(Player_Typing.GetComponent<RectTransform>().transform.localScale.x + 0.00005f, Player_Typing.GetComponent<RectTransform>().transform.localScale.y + 0.00005f, Player_Typing.GetComponent<RectTransform>().transform.localScale.z);
                        }

                        else
                        {
                            Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                            Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                            Player_Typing.GetComponent<RectTransform>().transform.localScale = new Vector3(Player_Typing.GetComponent<RectTransform>().transform.localScale.x, Player_Typing.GetComponent<RectTransform>().transform.localScale.y, Player_Typing.GetComponent<RectTransform>().transform.localScale.z);
                        }

                        if (Player_Typing.GetComponent<RectTransform>().transform.localScale.y > 0.58f)
                            step = 3;
                    }

                    //재위치
                    if (step == 3)
                    {
                        if (Player_Typing.GetComponent<RectTransform>().localPosition.x == -720)
                        {
                            if (Main_Scene.Player_1_WinCount > Main_Scene.Player_2_WinCount)
                            {
                                Player_Line_Up.GetComponent<Image>().sprite = GameImage[0];
                                Player_Line_Down.GetComponent<Image>().sprite = GameImage[1];
                                TypeSaid(7);
                            }

                            else if (Main_Scene.Player_1_WinCount == Main_Scene.Player_2_WinCount)
                            {
                                if (Main_Scene.Player_1_Score > Main_Scene.Player_2_Score)
                                {
                                    Player_Line_Up.GetComponent<Image>().sprite = GameImage[0];
                                    Player_Line_Down.GetComponent<Image>().sprite = GameImage[1];
                                    TypeSaid(7);
                                }

                                else if(Main_Scene.Player_1_Score < Main_Scene.Player_2_Score)
                                {
                                    Player_Line_Up.GetComponent<Image>().sprite = GameImage[2];
                                    Player_Line_Down.GetComponent<Image>().sprite = GameImage[3];
                                    TypeSaid(8);
                                }

                            }

                            else if (Main_Scene.Player_1_WinCount < Main_Scene.Player_2_WinCount)
                            {
                                Player_Line_Up.GetComponent<Image>().sprite = GameImage[2];
                                Player_Line_Down.GetComponent<Image>().sprite = GameImage[3];
                                TypeSaid(8);
                            }

                            Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(400, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                            Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(-400, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                            Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(720, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);
                            step = 4;
                        }

                        else
                        {
                            if (!StopGame)
                            {
                                Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x - 2.5f, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                                Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x + 2.5f, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                                Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(Player_Typing.GetComponent<RectTransform>().localPosition.x - 4.5f, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);
                            }

                            else
                            {
                                Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                                Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                                Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(Player_Typing.GetComponent<RectTransform>().localPosition.x, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);
                            }
                        }
                    }

                    if (step == 4) //등장하는 이미지
                    {
                        if (!StopGame)
                        {
                            Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x - 2.5f, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                            Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x + 2.5f, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                            Player_Typing.GetComponent<Image>().color = new Color(Player_Typing.GetComponent<Image>().color.r, Player_Typing.GetComponent<Image>().color.g, Player_Typing.GetComponent<Image>().color.b, 1);
                            Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(Player_Typing.GetComponent<RectTransform>().localPosition.x - 4.5f, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);
                        }

                        else
                        {
                            Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                            Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                            Player_Typing.GetComponent<Image>().color = new Color(Player_Typing.GetComponent<Image>().color.r, Player_Typing.GetComponent<Image>().color.g, Player_Typing.GetComponent<Image>().color.b, 1);
                            Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(Player_Typing.GetComponent<RectTransform>().localPosition.x, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);
                        }

                        if (Player_Line_Up.GetComponent<RectTransform>().localPosition.x == 0)
                            step = 5;
                    }

                    //늘어나는 문자
                    if (step == 5)
                    {
                        if (!StopGame)
                        {
                            Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x - 0.005f, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                            Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x + 0.005f, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                            Player_Typing.GetComponent<RectTransform>().transform.localScale = new Vector3(Player_Typing.GetComponent<RectTransform>().transform.localScale.x + 0.00003f, Player_Typing.GetComponent<RectTransform>().transform.localScale.y + 0.00003f, Player_Typing.GetComponent<RectTransform>().transform.localScale.z);
                        }

                        else
                        {
                            Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                            Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                            Player_Typing.GetComponent<RectTransform>().transform.localScale = new Vector3(Player_Typing.GetComponent<RectTransform>().transform.localScale.x, Player_Typing.GetComponent<RectTransform>().transform.localScale.y, Player_Typing.GetComponent<RectTransform>().transform.localScale.z);
                        }

                        if (Player_Typing.GetComponent<RectTransform>().transform.localScale.y > 0.58f)
                            step = 6;
                    }

                    if (step == 6)
                    {
                        Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                        Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                        Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(Player_Typing.GetComponent<RectTransform>().localPosition.x, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);
                        Text.GetComponent<RectTransform>().localPosition = new Vector3(0, 110, 0);
                        Text2.GetComponent<RectTransform>().localPosition = new Vector3(0, -100, 0);
                        Card.Fade.GetComponent<Image>().color = new Color(0, 0, 0, 0.9f);
                        Card.Fade.GetComponent<RectTransform>().localPosition = new Vector3(0, 0, 0);

                        if (Main_Scene.Language == 1)
                        {
                            QuitGames.GetComponent<Image>().sprite = but[27];
                            Text.GetComponent<Text>().text = "수고하셨습니다!";
                            Text2.GetComponent<Text>().text = "충분히 멋진 경기였어요!\n두 분 모두 수고하셨어요!\n\n\n나가기버튼을 누르면\n메인화면으로 이동합니다.";
                        }

                        else if (Main_Scene.Language == 2)
                        {
                            QuitGames.GetComponent<Image>().sprite = but[41];
                            Text.GetComponent<Text>().text = "Nice Match!";
                            Text2.GetComponent<Text>().text = "That was a great match!\nI hope you both like it.\n\n\nPress the 'Out' and\nGo to the Title.";
                        }

                        else if (Main_Scene.Language == 3)
                        {
                            QuitGames.GetComponent<Image>().sprite = but[49];
                            Text.GetComponent<Text>().text = "お疲れ様!";
                            Text2.GetComponent<Text>().text = "とても素晴らしい試合でした!\nお疲れ様です!\n\n\n出るボタンを押すと\nタイトル画面に移動します";
                        }

                        QuitGames.GetComponent<RectTransform>().localPosition = new Vector3(0, -100, 0);
                        QuitGames.GetComponent<RectTransform>().localScale = new Vector3(0.5f, 0.5f, 0);

                        Achievement.GetComponent<RectTransform>().localPosition = new Vector3(-80, -200, 0);
                        Staring.GetComponent<RectTransform>().localPosition = new Vector3(0, -200, 0);
                        LeaderBoard.GetComponent<RectTransform>().localPosition = new Vector3(80, -200, 0);
                    }
                }

                else
                {
                    Achievement.GetComponent<RectTransform>().localPosition = new Vector3(15000, 0, 0);
                    Staring.GetComponent<RectTransform>().localPosition = new Vector3(15000, 0, 0);
                    LeaderBoard.GetComponent<RectTransform>().localPosition = new Vector3(15000, 0, 0);

                    Text.GetComponent<RectTransform>().localPosition = new Vector3(0, 1500, 0);
                    Text2.GetComponent<RectTransform>().localPosition = new Vector3(0, 1500, 0);
                    Winner = false;
                    QuitGame = false;
                    Card.step = 1;
                }
            }
        }

        else
        {
            if (Main_Scene.TimeAttack)
            {
                //세팅문구가 완료된 이후에 시간을 세기 시작한다.
                if (!Main_Scene.Start_Game_Button && !Main_Scene.Start_Game_Card)
                {
                    if (!Main_Scene.Finish_Game_Card && !Card.FadeOut) //끝나지 않는 한 계속 시간이 줄어든다.
                        Timeattack -= Time.deltaTime / 60;

                    Timenumber(Player01, Timeattack / 60);
                    Timenumber(Player02, (Timeattack % 60) / 10);
                    Timenumber(Player022, (Timeattack % 60) % 10);

                    if (Timeattack < 0)
                    {
                        TypeSaid(15);
                        Achive.AC[0] = 1;
                        Main_Scene.TimeAttack = false;
                        StopGame = true;
                        TimeOver = true;
                    }
                }

                else
                {
                    Timeattack = Main_Scene.time;
                    NowTime = Timeattack;
                    //Player01은 분, Player011는 초의 십의자리, Player022은 초의 일의 자리이다.
                    Timenumber(Player01, Timeattack / 60);
                    Timenumber(Player02, (Timeattack % 60) / 10);
                    Timenumber(Player022, (Timeattack % 60) % 10);
                }
            }

            else
            {
                if (!Main_Scene.Start_Game_Button && !Main_Scene.Start_Game_Card)
                {
                    if (!Main_Scene.Finish_Game_Card && !Card.FadeOut)
                        Timeattack += Time.deltaTime / 60;
                }

                else
                {
                    Timeattack = Achive.NotTimeattack;

                }
            }

            if (Main_Scene.Start_Game_Button) //등장하는 장면
            {
                if (step == 0)
                {
                    if (Main_Scene.TimeAttack)
                    {
                        Back.GetComponent<RectTransform>().localPosition = new Vector3(70, 201, 0);
                        Player_Score01.GetComponent<RectTransform>().localPosition = new Vector3(-30, 201, 0);
                        Player01.GetComponent<RectTransform>().localPosition = new Vector3(-75, 201, 0);
                        Player02.GetComponent<RectTransform>().localPosition = new Vector3(-20, 201, 0);
                        Player011.GetComponent<RectTransform>().localPosition = new Vector3(-47.5f, 201, 0);
                        Player022.GetComponent<RectTransform>().localPosition = new Vector3(15, 201, 0);
                        Player011.GetComponent<Image>().sprite = but[23];
                        Player011.GetComponent<RectTransform>().sizeDelta = new Vector3(29, 66);
                        Player011.GetComponent<RectTransform>().localScale = new Vector3(0.5f, 0.5f);
                        Player_Score01.GetComponent<Image>().color = new Color(Player_Score01.GetComponent<Image>().color.r, Player_Score01.GetComponent<Image>().color.g, Player_Score01.GetComponent<Image>().color.b, 0);
                    }

                    Back.GetComponent<Image>().color = new Color(Player_Score01.GetComponent<Image>().color.r, Player_Score01.GetComponent<Image>().color.g, Player_Score01.GetComponent<Image>().color.b, 0);

                    ButtonOnePlayer();

                    Number(Stage_Number, (Main_Scene.Player_1_WinCount + 1));

                    if (Main_Scene.Selected_stage[0] == 0)
                    {
                        if (!StopGame)
                        {
                            button_h.GetComponent<RectTransform>().localPosition = new Vector3(button_h.GetComponent<RectTransform>().localPosition.x + 1f, button_h.GetComponent<RectTransform>().localPosition.y, button_h.transform.position.z);
                            button_g.GetComponent<RectTransform>().localPosition = new Vector3(button_g.GetComponent<RectTransform>().localPosition.x - 1f, button_g.GetComponent<RectTransform>().localPosition.y, button_g.transform.position.z);
                        }

                        else
                        {
                            button_h.GetComponent<RectTransform>().localPosition = new Vector3(button_h.GetComponent<RectTransform>().localPosition.x, button_h.GetComponent<RectTransform>().localPosition.y, button_h.transform.position.z);
                            button_g.GetComponent<RectTransform>().localPosition = new Vector3(button_g.GetComponent<RectTransform>().localPosition.x, button_g.GetComponent<RectTransform>().localPosition.y, button_g.transform.position.z);
                        }

                        if (button_h.GetComponent<RectTransform>().localPosition.x == -100)
                        {
                            step = -1;
                        }
                    }

                    else
                    {
                        step = -1;
                    }
                }

                if (step == -1)
                {
                    if (Stage.GetComponent<RectTransform>().localPosition.y <= 271.7)
                    {
                        if (Main_Scene.TimeAttack)
                        {
                            if (!StopGame)
                            {
                                Player01.GetComponent<Image>().color = new Color(Player01.GetComponent<Image>().color.r, Player01.GetComponent<Image>().color.g, Player01.GetComponent<Image>().color.b, Player01.GetComponent<Image>().color.a + 0.005f);
                                Player02.GetComponent<Image>().color = new Color(Player02.GetComponent<Image>().color.r, Player02.GetComponent<Image>().color.g, Player02.GetComponent<Image>().color.b, Player02.GetComponent<Image>().color.a + 0.005f);
                                Player011.GetComponent<Image>().color = new Color(Player011.GetComponent<Image>().color.r, Player011.GetComponent<Image>().color.g, Player011.GetComponent<Image>().color.b, Player011.GetComponent<Image>().color.a + 0.005f);
                                Player022.GetComponent<Image>().color = new Color(Player022.GetComponent<Image>().color.r, Player022.GetComponent<Image>().color.g, Player022.GetComponent<Image>().color.b, Player022.GetComponent<Image>().color.a + 0.005f);
                                Player_Score01.GetComponent<Image>().color = new Color(Player_Score01.GetComponent<Image>().color.r, Player_Score01.GetComponent<Image>().color.g, Player_Score01.GetComponent<Image>().color.b, Player_Score01.GetComponent<Image>().color.a + 0.005f);
                            }

                            else
                            {
                                Player01.GetComponent<Image>().color = new Color(Player01.GetComponent<Image>().color.r, Player01.GetComponent<Image>().color.g, Player01.GetComponent<Image>().color.b, Player01.GetComponent<Image>().color.a);
                                Player02.GetComponent<Image>().color = new Color(Player02.GetComponent<Image>().color.r, Player02.GetComponent<Image>().color.g, Player02.GetComponent<Image>().color.b, Player02.GetComponent<Image>().color.a);
                                Player011.GetComponent<Image>().color = new Color(Player011.GetComponent<Image>().color.r, Player011.GetComponent<Image>().color.g, Player011.GetComponent<Image>().color.b, Player011.GetComponent<Image>().color.a);
                                Player022.GetComponent<Image>().color = new Color(Player022.GetComponent<Image>().color.r, Player022.GetComponent<Image>().color.g, Player022.GetComponent<Image>().color.b, Player022.GetComponent<Image>().color.a);
                                Player_Score01.GetComponent<Image>().color = new Color(Player_Score01.GetComponent<Image>().color.r, Player_Score01.GetComponent<Image>().color.g, Player_Score01.GetComponent<Image>().color.b, Player_Score01.GetComponent<Image>().color.a);
                            }

                            if(Player01.GetComponent<Image>().color.a >= 1)
                                step = 1;
                        }

                        else
                            step = 1;
                    }

                    else
                    {
                        if (!StopGame)
                        {
                            Stage.GetComponent<RectTransform>().localPosition = new Vector3(0, Stage.GetComponent<RectTransform>().localPosition.y - 0.5f, 0);
                            Stage_Type.GetComponent<RectTransform>().localPosition = new Vector3(-27, Stage_Type.GetComponent<RectTransform>().localPosition.y - 0.5f, 0);
                            if (Main_Scene.Language == 2)
                                Stage_Number.GetComponent<RectTransform>().localPosition = new Vector3(60, Stage_Number.GetComponent<RectTransform>().localPosition.y - 0.5f, 0);

                            else
                                Stage_Number.GetComponent<RectTransform>().localPosition = new Vector3(80, Stage_Number.GetComponent<RectTransform>().localPosition.y - 0.5f, 0);
                        }

                        else
                        {
                            Stage.GetComponent<RectTransform>().localPosition = new Vector3(0, Stage.GetComponent<RectTransform>().localPosition.y, 0);
                            Stage_Type.GetComponent<RectTransform>().localPosition = new Vector3(Stage_Type.GetComponent<RectTransform>().localPosition.x, Stage_Type.GetComponent<RectTransform>().localPosition.y, 0);
                            Stage_Number.GetComponent<RectTransform>().localPosition = new Vector3(Stage_Number.GetComponent<RectTransform>().localPosition.x, Stage_Number.GetComponent<RectTransform>().localPosition.y, 0);
                        }
                    }
                }

                if (step == 1) //이미지 등장의 위치를 정함
                {
                    Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(400, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                    Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(-400, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                    Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(720, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);

                    MusicSource.SFXCHOOSE = true;
                    MusicSource.SFX[5] = true;
                    MusicSource.SE_volume = 1f;
                    step = 2;
                }

                if (step == 2) //등장하는 이미지
                {
                    Player_Line_Up.GetComponent<Image>().sprite = GameImage[4];
                    Player_Line_Down.GetComponent<Image>().sprite = GameImage[5];
                    TypeSaid(6);

                    if (!StopGame)
                    {
                        Back.GetComponent<Image>().color = new Color(Back.GetComponent<Image>().color.r, Back.GetComponent<Image>().color.g, Back.GetComponent<Image>().color.b, Back.GetComponent<Image>().color.a + 0.1f);
                        Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x - 5, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                        Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x + 5, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                        Player_Typing.GetComponent<Image>().color = new Color(Player_Typing.GetComponent<Image>().color.r, Player_Typing.GetComponent<Image>().color.g, Player_Typing.GetComponent<Image>().color.b, 1);
                        Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(Player_Typing.GetComponent<RectTransform>().localPosition.x - 9, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);
                    }

                    else
                    {
                        Back.GetComponent<Image>().color = new Color(Back.GetComponent<Image>().color.r, Back.GetComponent<Image>().color.g, Back.GetComponent<Image>().color.b, Back.GetComponent<Image>().color.a);
                        Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                        Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                        Player_Typing.GetComponent<Image>().color = new Color(Player_Typing.GetComponent<Image>().color.r, Player_Typing.GetComponent<Image>().color.g, Player_Typing.GetComponent<Image>().color.b, 1);
                        Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(Player_Typing.GetComponent<RectTransform>().localPosition.x, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);
                    }

                    if (Player_Line_Up.GetComponent<RectTransform>().localPosition.x == 0)
                        step = 3;
                }

                //늘어나는 문자(세팅 중..)
                if (step == 3)
                {
                    if (!StopGame)
                    {
                        Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x - 0.005f, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                        Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x + 0.005f, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                        Player_Typing.GetComponent<RectTransform>().transform.localScale = new Vector3(Player_Typing.GetComponent<RectTransform>().transform.localScale.x + 0.00005f, Player_Typing.GetComponent<RectTransform>().transform.localScale.y + 0.00005f, Player_Typing.GetComponent<RectTransform>().transform.localScale.z);
                    }

                    else
                    {
                        Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                        Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                        Player_Typing.GetComponent<RectTransform>().transform.localScale = new Vector3(Player_Typing.GetComponent<RectTransform>().transform.localScale.x, Player_Typing.GetComponent<RectTransform>().transform.localScale.y, Player_Typing.GetComponent<RectTransform>().transform.localScale.z);
                    }

                    if (Player_Typing.GetComponent<RectTransform>().transform.localScale.y > 0.57f)
                    {
                        if (Main_Scene.Selected_stage[0] == 0) //가림막 모드가 아니라면 4번 진행
                            step = 4;

                        else if (Main_Scene.Selected_stage[0] == 1) //가림막 모드면 8번 진행
                            step = 8;
                    }
                }

                //재위치
                if (step == 4)
                {

                    if (!StopGame)
                    {
                        Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x - 0.005f, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                        Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x + 0.005f, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                        Card.AnswerBack.GetComponent<Image>().color = new Color(Card.AnswerBack.GetComponent<Image>().color.r, Card.AnswerBack.GetComponent<Image>().color.g, Card.AnswerBack.GetComponent<Image>().color.b, Card.AnswerBack.GetComponent<Image>().color.a + 0.001f);
                    }

                    else
                    {
                        Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                        Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                        Card.AnswerBack.GetComponent<Image>().color = new Color(Card.AnswerBack.GetComponent<Image>().color.r, Card.AnswerBack.GetComponent<Image>().color.g, Card.AnswerBack.GetComponent<Image>().color.b, Card.AnswerBack.GetComponent<Image>().color.a);
                    }

                    if (Player_Typing.GetComponent<RectTransform>().localPosition.x == -720)
                    {
                        Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(720, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);
                        TypeSaid(9);
                        step = 5;
                    }

                    else
                    {
                        if (!StopGame)
                            Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(Player_Typing.GetComponent<RectTransform>().localPosition.x - 4.5f, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);

                        else
                            Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(Player_Typing.GetComponent<RectTransform>().localPosition.x, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);
                    }
                }

                //다시 나타나는 문자(게임 시작!)
                if (step == 5)
                {
                    if (!StopGame)
                    {
                        Card.AnswerBack.GetComponent<Image>().color = new Color(Card.AnswerBack.GetComponent<Image>().color.r, Card.AnswerBack.GetComponent<Image>().color.g, Card.AnswerBack.GetComponent<Image>().color.b, Card.AnswerBack.GetComponent<Image>().color.a + 0.001f);
                        Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x - 0.005f, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                        Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x + 0.005f, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                    }

                    else
                    {
                        Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                        Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                        Card.AnswerBack.GetComponent<Image>().color = new Color(Card.AnswerBack.GetComponent<Image>().color.r, Card.AnswerBack.GetComponent<Image>().color.g, Card.AnswerBack.GetComponent<Image>().color.b, Card.AnswerBack.GetComponent<Image>().color.a);
                    }

                    if (Player_Typing.GetComponent<RectTransform>().localPosition.x == 0)
                    {
                        MusicSource.SFXCHOOSE = true;
                        MusicSource.SFX[5] = true;
                        MusicSource.SE_volume = 1f;
                        MusicSource.SFXCHOOSE2 = true;
                        MusicSource.SFX2[0] = true;
                        MusicSource.SE2_volume = 1f;
                        step = 6;
                    }

                    else
                    {
                        if (Main_Scene.Selected_stage[1] == 1)
                        {
                            Card.Lightmode = true;
                            LightStart = true;
                        }

                        if (!StopGame)
                            Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(Player_Typing.GetComponent<RectTransform>().localPosition.x - 4.5f, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);

                        else
                            Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(Player_Typing.GetComponent<RectTransform>().localPosition.x, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);
                    }
                }

                //늘어나는 문자
                if (step == 6)
                {
                    if (!StopGame)
                    {
                        Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x - 0.005f, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                        Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x + 0.005f, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                        Player_Typing.GetComponent<RectTransform>().transform.localScale = new Vector3(Player_Typing.GetComponent<RectTransform>().transform.localScale.x + 0.00005f, Player_Typing.GetComponent<RectTransform>().transform.localScale.y + 0.00005f, Player_Typing.GetComponent<RectTransform>().transform.localScale.z);
                        Card.AnswerBack.GetComponent<Image>().color = new Color(Card.AnswerBack.GetComponent<Image>().color.r, Card.AnswerBack.GetComponent<Image>().color.g, Card.AnswerBack.GetComponent<Image>().color.b, Card.AnswerBack.GetComponent<Image>().color.a + 0.001f);
                    }

                    else
                    {
                        Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                        Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                        Player_Typing.GetComponent<RectTransform>().transform.localScale = new Vector3(Player_Typing.GetComponent<RectTransform>().transform.localScale.x, Player_Typing.GetComponent<RectTransform>().transform.localScale.y, Player_Typing.GetComponent<RectTransform>().transform.localScale.z);
                        Card.AnswerBack.GetComponent<Image>().color = new Color(Card.AnswerBack.GetComponent<Image>().color.r, Card.AnswerBack.GetComponent<Image>().color.g, Card.AnswerBack.GetComponent<Image>().color.b, Card.AnswerBack.GetComponent<Image>().color.a);

                    }

                    if (Player_Typing.GetComponent<RectTransform>().transform.localScale.y > 0.6f)
                        step = 7;
                }

                //재위치
                if (step == 7)
                {
                    if (Player_Typing.GetComponent<RectTransform>().localPosition.x == -720)
                    {
                        Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(400, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                        Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(-400, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                        Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(15400, 0, 0);

                        step = 0;
                        Main_Scene.Start_Game_Button = false;
                        Game_Start = true;
                        timer_stop = false;
                        LightStart = false;

                        if ((Main_Scene.Player_2_WinCount + Main_Scene.Player_1_WinCount + 1) == 1)
                        {
                            MusicSource.step = 0;
                            MusicSource.Looptime = 54.85f;
                            MusicSource.volume = 1f;
                        }

                        if ((Main_Scene.Selected_stage[0] == 1) && (!Challenge.Ch))
                        {
                            MusicSource.step = 0;
                            MusicSource.Looptime = 54.85f;
                            MusicSource.volume = 1f;
                        }
                    }

                    else
                    {
                        if (!StopGame)
                        {
                            Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x - 5f, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                            Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x + 5f, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                            Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(Player_Typing.GetComponent<RectTransform>().localPosition.x - 9f, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);
                        }

                        else
                        {
                            Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                            Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                            Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(Player_Typing.GetComponent<RectTransform>().localPosition.x, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);
                        }
                    }
                }

                //재위치
                if (step == 8)
                {
                    if (Player_Typing.GetComponent<RectTransform>().localPosition.x == -720)
                    {
                        Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(400, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                        Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(-400, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                        Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(720, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);
                        button_h.GetComponent<Image>().sprite = but[4];
                        TypeSaid(9);
                        Check_timer = 1;
                        step = 9;

                    }

                    else
                    {
                        if (!StopGame)
                        {
                            Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x - 5f, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                            Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x + 5f, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                            Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(Player_Typing.GetComponent<RectTransform>().localPosition.x - 9f, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);
                        }

                        else
                        {
                            Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                            Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                            Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(Player_Typing.GetComponent<RectTransform>().localPosition.x, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);
                        }
                    }
                }

                if (step == 9)
                {
                    if (button_h.GetComponent<RectTransform>().localPosition.x == 0)
                    {
                        MusicSource.Clocking = true;
                        step = 10;
                    }

                    else
                    {
                        if (!StopGame)
                            button_h.GetComponent<RectTransform>().localPosition = new Vector3(button_h.GetComponent<RectTransform>().localPosition.x + 6, button_h.GetComponent<RectTransform>().localPosition.y, button_h.transform.position.z);

                        else
                            button_h.GetComponent<RectTransform>().localPosition = new Vector3(button_h.GetComponent<RectTransform>().localPosition.x, button_h.GetComponent<RectTransform>().localPosition.y, button_h.transform.position.z);
                    }
                }

                //시간재기
                if (step == 10)
                {
                    Check_timer -= Time.deltaTime / 750;
                    BecomeInvisible();

                    //타이머 종료 시 탈출
                    if (Check_timer < 0)
                    {
                        MusicSource.ClockingOff = true;
                        button_h.GetComponent<RectTransform>().localPosition = new Vector3(-240, button_h.GetComponent<RectTransform>().localPosition.y, button_h.GetComponent<RectTransform>().localPosition.z);
                        this.button_h.GetComponent<Image>().fillAmount = 1;
                        timer_stop = true;
                        starting_number = 0;
                        step = 11;
                    }
                }

                if (step == 11)
                {
                    Player = 1;
                    ButtonOnePlayer();

                    Invisible = true;
                    step = 12;
                }

                if (step == 12)
                {
                    if (!StopGame)
                    {
                        button_h.GetComponent<RectTransform>().localPosition = new Vector3(button_h.GetComponent<RectTransform>().localPosition.x + 1f, button_h.GetComponent<RectTransform>().localPosition.y, button_h.transform.position.z);
                        button_g.GetComponent<RectTransform>().localPosition = new Vector3(button_g.GetComponent<RectTransform>().localPosition.x - 1f, button_g.GetComponent<RectTransform>().localPosition.y, button_g.transform.position.z);
                        Back.GetComponent<Image>().color = new Color(Back.GetComponent<Image>().color.r, Back.GetComponent<Image>().color.g, Back.GetComponent<Image>().color.b, Back.GetComponent<Image>().color.a + 0.01f);
                    }

                    else
                    {
                        button_h.GetComponent<RectTransform>().localPosition = new Vector3(button_h.GetComponent<RectTransform>().localPosition.x, button_h.GetComponent<RectTransform>().localPosition.y, button_h.transform.position.z);
                        button_g.GetComponent<RectTransform>().localPosition = new Vector3(button_g.GetComponent<RectTransform>().localPosition.x, button_g.GetComponent<RectTransform>().localPosition.y, button_g.transform.position.z);
                        Back.GetComponent<Image>().color = new Color(Back.GetComponent<Image>().color.r, Back.GetComponent<Image>().color.g, Back.GetComponent<Image>().color.b, Back.GetComponent<Image>().color.a);
                    }

                    if (button_h.GetComponent<RectTransform>().localPosition.x == -100)
                        step = 13;
                }

                if (step == 13)
                {
                    Player_Line_Up.GetComponent<Image>().sprite = GameImage[4];
                    Player_Line_Down.GetComponent<Image>().sprite = GameImage[5];

                    if (!StopGame)
                    {
                        Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x - 5, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                        Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x + 5, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                        Player_Typing.GetComponent<Image>().color = new Color(Player_Typing.GetComponent<Image>().color.r, Player_Typing.GetComponent<Image>().color.g, Player_Typing.GetComponent<Image>().color.b, 1);
                        Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(Player_Typing.GetComponent<RectTransform>().localPosition.x - 9, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);
                    }

                    else
                    {
                        Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                        Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                        Player_Typing.GetComponent<Image>().color = new Color(Player_Typing.GetComponent<Image>().color.r, Player_Typing.GetComponent<Image>().color.g, Player_Typing.GetComponent<Image>().color.b, 1);
                        Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(Player_Typing.GetComponent<RectTransform>().localPosition.x, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);
                    }

                    if (Main_Scene.Selected_stage[1] == 1)
                    {
                        Card.Lightmode = true;
                        LightStart = true;
                    }

                    if (Player_Line_Up.GetComponent<RectTransform>().localPosition.x == 0)
                    {
                        MusicSource.SFXCHOOSE = true;
                        MusicSource.SFX[5] = true;
                        MusicSource.SE_volume = 1f;
                        step = 6;
                    }
                }
            }

            if (!Card.Finish)
            {
                //0번. 합과 결 버튼 중 하나를 눌렀을 때
                if (Timer_Check)
                {
                    Card.HintFade = 0;
                    Card.Hint.GetComponent<RectTransform>().localPosition = new Vector3(518, -144);
                    Card.Hint.GetComponent<Image>().color = new Color(Card.Hint.GetComponent<Image>().color.r, Card.Hint.GetComponent<Image>().color.g, Card.Hint.GetComponent<Image>().color.b, 0);
                    lethinttime = 0;

                    //1번. 합을 맨 처음에 눌렀을 때
                    if (Buttonclick == 1)
                    {
                        if (step == 0)
                        {
                            if (!StopGame)
                            {
                                button_g.GetComponent<Image>().color = new Color(button_g.GetComponent<Image>().color.r, button_g.GetComponent<Image>().color.g, button_g.GetComponent<Image>().color.b, button_g.GetComponent<Image>().color.a - 0.15f);
                            }

                            else
                            {
                                button_g.GetComponent<Image>().color = new Color(button_g.GetComponent<Image>().color.r, button_g.GetComponent<Image>().color.g, button_g.GetComponent<Image>().color.b, button_g.GetComponent<Image>().color.a);
                            }

                            if (button_g.GetComponent<Image>().color.a <= 0.3f)
                            {
                                NowButtonclick = 2;
                                step = 1;
                            }
                        }

                        if (step == 1)
                        {
                            this.ChangeSpeed = 50;

                            if (this.transform.eulerAngles.y > 90)
                            {
                                transform.Rotate(0, 260f, 0);
                                this.ChangeSpeed = 0;
                                timeCount = 10;
                                step = 0;
                                MusicSource.Clocking = true;
                                Buttonclick = 2;
                            }

                            else
                            {
                                transform.Rotate(0, this.ChangeSpeed, 0);
                                this.ChangeSpeed *= 0.1f;
                            }

                            if (Player == 1)
                            {
                                button_h.GetComponent<Image>().sprite = but[4];
                            }

                            else
                            {
                                button_h.GetComponent<Image>().sprite = but[5];
                            }
                        }
                    }

                    //2번. 합 버튼을 누르고 바로 시간을 센다. 이 때 합 3개를 누르게 한다.
                    if (Buttonclick == 2)
                    {
                        if (step == 0)
                        {
                            //15초 타이머
                            timeCount -= Time.deltaTime;
                            DecreaseTime_H();

                            //타이머 종료 시 3번으로 이동
                            if (timeCount < 0)
                            {
                                MusicSource.ClockingOff = true;
                                timer_stop = true;
                                choose_card = 0;
                                NowButtonclick = 0;
                                step = 0;
                                Buttonclick = 21;
                            }

                            //타이머가 종료되기 전에 3개를 선택하면 넘어가는 스크립트를 작성해야한다.
                            else
                            {
                                if (choose_card == 3) //모두 차게 된다면
                                {
                                    step = 1;
                                }
                            }
                        }

                        if (step == 1)
                        {
                            NowButtonclick = 0;
                            Card.Choosefinished = true; //합인지 확인한다.
                            MusicSource.ClockingOff = true;

                            for (int i = 0; i < 3; i++)
                                Card.Position[Choose[i]].GetComponent<Image>().color = new Color(0, 0, 0, 0);

                            if (Card.find) //합인지 확인이 끝났을 경우
                            {
                                step = 0;
                                Card.find = false; //합을 구하고 결과가 나옴
                                choose_card = 0; //

                                if (!Card.Haap)
                                    Buttonclick = 22;

                                else
                                {
                                    //4*4모드일 때 전체가지가 15개가 넘고, 찾은 개수가 딱 15개가 되었다면?
                                    if (Main_Scene.Selected_stage[2] == 1)
                                    {
                                        if(Challenge.Challengemode[7] == 0)
                                        {
                                            if (Card.Allnumber + Card.Hap > 15)
                                            {
                                                if (Card.Allnumber == 15)
                                                {
                                                    Buttonclick = 24;
                                                }

                                                else
                                                {
                                                    Buttonclick = 23;
                                                }
                                            }

                                            else
                                            {
                                                Buttonclick = 23;
                                            }
                                        }

                                        else
                                        {
                                            if (Card.Allnumber + Card.Hap > 20)
                                            {
                                                if (Card.Allnumber == 20)
                                                {
                                                    Buttonclick = 24;
                                                }

                                                else
                                                {
                                                    Buttonclick = 23;
                                                }
                                            }

                                            else
                                            {
                                                Buttonclick = 23;
                                            }
                                        }
                                    }

                                    else
                                    {
                                        Buttonclick = 23;
                                    }
                                }
                            }
                        }
                    }

                    //합을 누르고 타이머가 종료되어버린 이미지 진행
                    if (Buttonclick == 21)
                    {
                        if (step == 0) //이미지 등장의 위치를 정함
                        {
                            Card.FailAnswer++;
                            Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(400, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                            Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(-400, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                            Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(720, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);

                            MusicSource.SFXCHOOSE = true;
                            MusicSource.SFX[5] = true;
                            MusicSource.SE_volume = 0.7f;
                            MusicSource.SFXCHOOSE2 = true;
                            MusicSource.SFX2[2] = true;
                            MusicSource.SE2_volume = 0.7f;
                            step = 1;
                        }

                        if (step == 1) //등장하는 이미지
                        {
                            Player_Line_Up.GetComponent<Image>().sprite = GameImage[0];
                            Player_Line_Down.GetComponent<Image>().sprite = GameImage[1];

                            TypeSaid(15);

                            if (!StopGame)
                            {
                                Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x - 100, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                                Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x + 100, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                                Player_Typing.GetComponent<Image>().color = new Color(Player_Typing.GetComponent<Image>().color.r, Player_Typing.GetComponent<Image>().color.g, Player_Typing.GetComponent<Image>().color.b, 1);
                                Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(Player_Typing.GetComponent<RectTransform>().localPosition.x - 180, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);
                            }

                            else
                            {
                                Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                                Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                                Player_Typing.GetComponent<Image>().color = new Color(Player_Typing.GetComponent<Image>().color.r, Player_Typing.GetComponent<Image>().color.g, Player_Typing.GetComponent<Image>().color.b, 1);
                                Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(Player_Typing.GetComponent<RectTransform>().localPosition.x, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);
                            }

                            if (Player_Line_Up.GetComponent<RectTransform>().localPosition.x == 0)
                                step = 2;
                        }

                        //늘어나는 문자
                        if (step == 2)
                        {
                            if (!StopGame)
                            {
                                Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x - 0.4f, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                                Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x + 0.4f, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                                Player_Typing.GetComponent<RectTransform>().transform.localScale = new Vector3(Player_Typing.GetComponent<RectTransform>().transform.localScale.x + 0.002f, Player_Typing.GetComponent<RectTransform>().transform.localScale.y + 0.002f, Player_Typing.GetComponent<RectTransform>().transform.localScale.z);
                            }

                            else
                            {
                                Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                                Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                                Player_Typing.GetComponent<RectTransform>().transform.localScale = new Vector3(Player_Typing.GetComponent<RectTransform>().transform.localScale.x, Player_Typing.GetComponent<RectTransform>().transform.localScale.y, Player_Typing.GetComponent<RectTransform>().transform.localScale.z);
                            }

                            if (Player_Typing.GetComponent<RectTransform>().transform.localScale.y > 0.57f)
                            {
                                step = 3;
                                ButtonOnePlayer();
                            }
                        }

                        //사라진 뒤 재위치
                        if (step == 3)
                        {
                            button_h.GetComponent<Image>().fillAmount = 1;

                            if (Player_Typing.GetComponent<RectTransform>().localPosition.x == -720)
                            {
                                Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(400, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                                Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(-400, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                                Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(720, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);
                                button_g.GetComponent<Image>().color = new Color(button_g.GetComponent<Image>().color.r, button_g.GetComponent<Image>().color.g, button_g.GetComponent<Image>().color.b, 1);
                                step = 0;
                                Stop_Timer = false;
                                Timer_Check = false;
                                Card.find = false;
                                timer_stop = false;
                                Buttonclick = 0;
                                if (Main_Scene.Selected_stage[0] == 1)
                                    Invisible = true;

                                if (Card.FailAnswer >= 5)
                                    Card.ShowHint = true;
                            }

                            else
                            {
                                if (!StopGame)
                                {
                                    button_g.GetComponent<Image>().color = new Color(button_g.GetComponent<Image>().color.r, button_g.GetComponent<Image>().color.g, button_g.GetComponent<Image>().color.b, button_g.GetComponent<Image>().color.a + 0.15f);
                                    Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x - 100, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                                    Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x + 100, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                                    Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(Player_Typing.GetComponent<RectTransform>().localPosition.x - 180, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);
                                }

                                else
                                {
                                    button_g.GetComponent<Image>().color = new Color(button_g.GetComponent<Image>().color.r, button_g.GetComponent<Image>().color.g, button_g.GetComponent<Image>().color.b, button_g.GetComponent<Image>().color.a + 0.15f);
                                    Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                                    Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                                    Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(Player_Typing.GetComponent<RectTransform>().localPosition.x, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);
                                }

                            }
                        }
                    }

                    //합을 눌러서 실패한 경우
                    if (Buttonclick == 22)
                    {
                        if (step == 0) //이미지 등장의 위치를 정함
                        {
                            Card.FailAnswer++;
                            if (Main_Scene.TimeAttack)
                            {
                                Timeattack -= 5;
                                Timenumber(Player01, Timeattack / 60);
                                Timenumber(Player02, (Timeattack % 60) / 10);
                                Timenumber(Player022, (Timeattack % 60) % 10);

                                if (Timeattack < 0)
                                {
                                    TimeOver = true;
                                }
                            }

                            Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(400, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                            Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(-400, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                            Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(720, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);

                            MusicSource.SFXCHOOSE = true;
                            MusicSource.SFX[5] = true;
                            MusicSource.SE_volume = 0.7f;
                            MusicSource.SFXCHOOSE2 = true;
                            MusicSource.SFX2[2] = true;
                            MusicSource.SE2_volume = 0.7f;
                            step = 1;
                        }

                        if (step == 1) //등장하는 이미지 [실패]
                        {
                            Player_Line_Up.GetComponent<Image>().sprite = GameImage[4];
                            Player_Line_Down.GetComponent<Image>().sprite = GameImage[5];

                            TypeSaid(11);


                            if (!StopGame)
                            {
                                Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x - 100, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                                Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x + 100, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                                Player_Typing.GetComponent<Image>().color = new Color(Player_Typing.GetComponent<Image>().color.r, Player_Typing.GetComponent<Image>().color.g, Player_Typing.GetComponent<Image>().color.b, 1);
                                Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(Player_Typing.GetComponent<RectTransform>().localPosition.x - 180, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);
                            }

                            else
                            {
                                Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                                Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                                Player_Typing.GetComponent<Image>().color = new Color(Player_Typing.GetComponent<Image>().color.r, Player_Typing.GetComponent<Image>().color.g, Player_Typing.GetComponent<Image>().color.b, 1);
                                Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(Player_Typing.GetComponent<RectTransform>().localPosition.x, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);
                            }

                            if (Player_Line_Up.GetComponent<RectTransform>().localPosition.x == 0)
                                step = 2;
                        }

                        //늘어나는 문자
                        if (step == 2)
                        {
                            if (!StopGame)
                            {
                                Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x - 0.4f, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                                Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x + 0.4f, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                                Player_Typing.GetComponent<RectTransform>().transform.localScale = new Vector3(Player_Typing.GetComponent<RectTransform>().transform.localScale.x + 0.002f, Player_Typing.GetComponent<RectTransform>().transform.localScale.y + 0.002f, Player_Typing.GetComponent<RectTransform>().transform.localScale.z);
                            }

                            else
                            {
                                Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                                Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                                Player_Typing.GetComponent<RectTransform>().transform.localScale = new Vector3(Player_Typing.GetComponent<RectTransform>().transform.localScale.x, Player_Typing.GetComponent<RectTransform>().transform.localScale.y, Player_Typing.GetComponent<RectTransform>().transform.localScale.z);
                            }

                            if (Player_Typing.GetComponent<RectTransform>().transform.localScale.y > 0.57f)
                            {
                                step = 3;
                                ButtonOnePlayer();
                                Card.moving = 3;
                            }
                        }

                        //사라진 뒤 재위치
                        if (step == 3)
                        {
                            button_h.GetComponent<Image>().fillAmount = 1;

                            if (Player_Typing.GetComponent<RectTransform>().localPosition.x == -720)
                            {
                                Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(400, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                                Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(-400, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                                Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(720, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);
                                button_g.GetComponent<Image>().color = new Color(button_g.GetComponent<Image>().color.r, button_g.GetComponent<Image>().color.g, button_g.GetComponent<Image>().color.b, 1);
                                step = 0;
                                Stop_Timer = false;
                                Timer_Check = false;
                                Card.find = false;
                                timer_stop = false;
                                Buttonclick = 0;

                                if (Main_Scene.Selected_stage[0] == 1)
                                    Invisible = true;

                                if (Card.FailAnswer >= 5)
                                    Card.ShowHint = true;
                            }

                            else
                            {
                                if (!StopGame)
                                {
                                    button_g.GetComponent<Image>().color = new Color(button_g.GetComponent<Image>().color.r, button_g.GetComponent<Image>().color.g, button_g.GetComponent<Image>().color.b, button_g.GetComponent<Image>().color.a + 0.15f);
                                    Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x - 100, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                                    Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x + 100, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                                    Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(Player_Typing.GetComponent<RectTransform>().localPosition.x - 180, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);
                                }

                                else
                                {
                                    button_g.GetComponent<Image>().color = new Color(button_g.GetComponent<Image>().color.r, button_g.GetComponent<Image>().color.g, button_g.GetComponent<Image>().color.b, button_g.GetComponent<Image>().color.a + 0.15f);
                                    Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                                    Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                                    Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(Player_Typing.GetComponent<RectTransform>().localPosition.x, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);
                                }

                            }
                        }
                    }

                    //합을 눌러서 맞은 경우
                    if (Buttonclick == 23)
                    {
                        if (step == 0) //이미지 등장의 위치를 정함
                        {
                            Card.FailAnswer = 0;
                            Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(400, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                            Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(-400, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                            Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(720, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);

                            MusicSource.SFXCHOOSE = true;
                            MusicSource.SFX[5] = true;
                            MusicSource.SE_volume = 0.7f;
                            MusicSource.SFXCHOOSE2 = true;
                            MusicSource.SFX2[1] = true;
                            MusicSource.SE2_volume = 0.5f;
                            step = 1;
                        }

                        if (step == 1) //등장하는 이미지 [성공]
                        {
                            Player_Line_Up.GetComponent<Image>().sprite = GameImage[4];
                            Player_Line_Down.GetComponent<Image>().sprite = GameImage[5];

                            TypeSaid(10);


                            if (!StopGame)
                            {
                                Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x - 100, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                                Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x + 100, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                                Player_Typing.GetComponent<Image>().color = new Color(Player_Typing.GetComponent<Image>().color.r, Player_Typing.GetComponent<Image>().color.g, Player_Typing.GetComponent<Image>().color.b, 1);
                                Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(Player_Typing.GetComponent<RectTransform>().localPosition.x - 180, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);
                            }

                            else
                            {
                                Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                                Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                                Player_Typing.GetComponent<Image>().color = new Color(Player_Typing.GetComponent<Image>().color.r, Player_Typing.GetComponent<Image>().color.g, Player_Typing.GetComponent<Image>().color.b, 1);
                                Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(Player_Typing.GetComponent<RectTransform>().localPosition.x, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);
                            }

                            if (Player_Line_Up.GetComponent<RectTransform>().localPosition.x == 0)
                                step = 2;
                        }

                        //늘어나는 문자
                        if (step == 2)
                        {
                            if (!StopGame)
                            {
                                Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x - 0.4f, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                                Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x + 0.4f, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                                Player_Typing.GetComponent<RectTransform>().transform.localScale = new Vector3(Player_Typing.GetComponent<RectTransform>().transform.localScale.x + 0.002f, Player_Typing.GetComponent<RectTransform>().transform.localScale.y + 0.002f, Player_Typing.GetComponent<RectTransform>().transform.localScale.z);
                            }

                            else
                            {
                                Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                                Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                                Player_Typing.GetComponent<RectTransform>().transform.localScale = new Vector3(Player_Typing.GetComponent<RectTransform>().transform.localScale.x, Player_Typing.GetComponent<RectTransform>().transform.localScale.y, Player_Typing.GetComponent<RectTransform>().transform.localScale.z);
                            }

                            if (Player_Typing.GetComponent<RectTransform>().transform.localScale.y > 0.57f)
                            {
                                step = 3;
                                ButtonOnePlayer();
                                Card.moving = 3;
                            }
                        }

                        //사라진 뒤 재위치
                        if (step == 3)
                        {
                            button_h.GetComponent<Image>().fillAmount = 1;

                            if (Player_Typing.GetComponent<RectTransform>().localPosition.x == -720)
                            {
                                Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(400, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                                Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(-400, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                                Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(720, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);
                                button_g.GetComponent<Image>().color = new Color(button_g.GetComponent<Image>().color.r, button_g.GetComponent<Image>().color.g, button_g.GetComponent<Image>().color.b, 1);
                                step = 0;
                                Stop_Timer = false;
                                Timer_Check = false;
                                Card.find = false;
                                timer_stop = false;
                                Buttonclick = 0;
                                if (Main_Scene.Selected_stage[0] == 1)
                                    Invisible = true;
                            }

                            else
                            {
                                if (!StopGame)
                                {
                                    button_g.GetComponent<Image>().color = new Color(button_g.GetComponent<Image>().color.r, button_g.GetComponent<Image>().color.g, button_g.GetComponent<Image>().color.b, button_g.GetComponent<Image>().color.a + 0.15f);
                                    Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x - 100, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                                    Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x + 100, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                                    Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(Player_Typing.GetComponent<RectTransform>().localPosition.x - 180, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);
                                }

                                else
                                {
                                    button_g.GetComponent<Image>().color = new Color(button_g.GetComponent<Image>().color.r, button_g.GetComponent<Image>().color.g, button_g.GetComponent<Image>().color.b, button_g.GetComponent<Image>().color.a + 0.15f);
                                    Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                                    Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                                    Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(Player_Typing.GetComponent<RectTransform>().localPosition.x, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);
                                }

                            }
                        }
                    }

                    //4*4모드에서 합이 15개 이상 나왔을 때
                    if (Buttonclick == 24)
                    {
                        if (step == 0) //이미지 등장의 위치를 정함
                        {
                            Card.FailAnswer = 0;
                            Main_Scene.Player_1_WinCount++;
                            Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(400, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                            Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(-400, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                            Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(720, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);


                            if (Timeattack < 1)
                            {
                                TimeOver = true;
                            }

                            else
                            {
                                Achieve();
                                Achive.Start_Ranking = true;
                            }

                            MusicSource.SFXCHOOSE = true;
                            MusicSource.SFX[5] = true;
                            MusicSource.SE_volume = 0.7f;
                            MusicSource.SFXCHOOSE2 = true;
                            MusicSource.SFX2[1] = true;
                            MusicSource.SE2_volume = 0.5f;
                            step = 1;
                            Card.moving = 3;
                        }

                        if (step == 1) //등장하는 이미지 [성공]
                        {
                            Player_Line_Up.GetComponent<Image>().sprite = GameImage[4];
                            Player_Line_Down.GetComponent<Image>().sprite = GameImage[5];

                            TypeSaid(10);

                            if (!StopGame)
                            {
                                Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x - 100, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                                Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x + 100, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                                Player_Typing.GetComponent<Image>().color = new Color(Player_Typing.GetComponent<Image>().color.r, Player_Typing.GetComponent<Image>().color.g, Player_Typing.GetComponent<Image>().color.b, 1);
                                Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(Player_Typing.GetComponent<RectTransform>().localPosition.x - 180, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);
                                Skip.GetComponent<RectTransform>().localPosition = new Vector3(Skip.GetComponent<RectTransform>().localPosition.x, Skip.GetComponent<RectTransform>().localPosition.y - 100, Skip.transform.position.z);
                            }

                            else
                            {
                                Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                                Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                                Player_Typing.GetComponent<Image>().color = new Color(Player_Typing.GetComponent<Image>().color.r, Player_Typing.GetComponent<Image>().color.g, Player_Typing.GetComponent<Image>().color.b, 1);
                                Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(Player_Typing.GetComponent<RectTransform>().localPosition.x, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);
                                Skip.GetComponent<RectTransform>().localPosition = new Vector3(Skip.GetComponent<RectTransform>().localPosition.x, Skip.GetComponent<RectTransform>().localPosition.y, Skip.transform.position.z);
                            }

                            if (Player_Line_Up.GetComponent<RectTransform>().localPosition.x == 0)
                                step = 2;
                        }

                        //늘어나는 문자
                        if (step == 2)
                        {
                            if (!StopGame)
                            {
                                Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x - 0.1f, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                                Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x + 0.1f, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                                Player_Typing.GetComponent<RectTransform>().transform.localScale = new Vector3(Player_Typing.GetComponent<RectTransform>().transform.localScale.x + 0.002f, Player_Typing.GetComponent<RectTransform>().transform.localScale.y + 0.002f, Player_Typing.GetComponent<RectTransform>().transform.localScale.z);

                            }

                            else
                            {
                                Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                                Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                                Player_Typing.GetComponent<RectTransform>().transform.localScale = new Vector3(Player_Typing.GetComponent<RectTransform>().transform.localScale.x, Player_Typing.GetComponent<RectTransform>().transform.localScale.y, Player_Typing.GetComponent<RectTransform>().transform.localScale.z);

                            }

                            if (Player_Typing.GetComponent<RectTransform>().transform.localScale.y > 0.57f)
                            {
                                step = 3;
                            }
                        }

                        //사라진 뒤 재위치
                        if (step == 3)
                        {
                            if (!StopGame)
                            {
                                button_h.GetComponent<Image>().color = new Color(button_h.GetComponent<Image>().color.r, button_h.GetComponent<Image>().color.g, button_h.GetComponent<Image>().color.b, button_h.GetComponent<Image>().color.a + 0.15f);

                                if(Main_Scene.Last_Stage == 1)
                                {
                                    Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x - 0.1f, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                                    Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x + 0.1f, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                                }
                            }

                            else
                            {
                                button_h.GetComponent<Image>().color = new Color(button_h.GetComponent<Image>().color.r, button_h.GetComponent<Image>().color.g, button_h.GetComponent<Image>().color.b, button_h.GetComponent<Image>().color.a);
                                if (Main_Scene.Last_Stage == 1)
                                {
                                    Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x - 0.1f, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                                    Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x + 0.1f, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                                }
                            }

                            if (Player_Typing.GetComponent<RectTransform>().localPosition.x == -720)
                            {
                                if (Main_Scene.Last_Stage == 1)
                                {
                                    Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(720, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);
                                    step = 4;
                                }

                                else
                                {
                                    step = 6;
                                }
                            }

                            else
                            {
                                if (!StopGame)
                                {
                                    Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(Player_Typing.GetComponent<RectTransform>().localPosition.x - 180, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);

                                    if (Main_Scene.Last_Stage > 1)
                                    {
                                        Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x - 100, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                                        Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x + 100, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                                    }
                                }

                                else
                                {
                                    Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(Player_Typing.GetComponent<RectTransform>().localPosition.x, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);
                                    if (Main_Scene.Last_Stage > 1)
                                    {
                                        Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                                        Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                                    }
                                }
                            }
                        }

                        if (step == 4) //등장하는 이미지(게임 끝!)
                        {
                            button_h.GetComponent<Image>().color = new Color(button_h.GetComponent<Image>().color.r, button_h.GetComponent<Image>().color.g, button_h.GetComponent<Image>().color.b, button_h.GetComponent<Image>().color.a);
                            TypeSaid(13);
                            Player_Typing.GetComponent<Image>().color = new Color(Player_Typing.GetComponent<Image>().color.r, Player_Typing.GetComponent<Image>().color.g, Player_Typing.GetComponent<Image>().color.b, 1);

                            if (Player_Typing.GetComponent<RectTransform>().localPosition.x == 0)
                            {
                                Move = 0;
                                step = 5;
                            }

                            else
                            {
                                if (!StopGame)
                                    Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(Player_Typing.GetComponent<RectTransform>().localPosition.x - 180, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);

                                else
                                    Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(Player_Typing.GetComponent<RectTransform>().localPosition.x, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);
                            }
                        }

                        //바뀌는 버튼
                        if (step == 5)
                        {
                            if (!StopGame)
                                Player_Typing.GetComponent<RectTransform>().transform.localScale = new Vector3(Player_Typing.GetComponent<RectTransform>().transform.localScale.x + 0.002f, Player_Typing.GetComponent<RectTransform>().transform.localScale.y + 0.002f, Player_Typing.GetComponent<RectTransform>().transform.localScale.z);

                            else
                                Player_Typing.GetComponent<RectTransform>().transform.localScale = new Vector3(Player_Typing.GetComponent<RectTransform>().transform.localScale.x, Player_Typing.GetComponent<RectTransform>().transform.localScale.y, Player_Typing.GetComponent<RectTransform>().transform.localScale.z);

                            if (Move == 1)
                            {
                                if (Player_Typing.GetComponent<RectTransform>().transform.localScale.y > 0.57f)
                                {
                                    Move = 0;
                                    step = 6;
                                    button_g.GetComponent<Image>().fillAmount = 1;

                                }
                            }

                            else
                            {
                                this.ChangeSpeed = 50;

                                if (this.transform.eulerAngles.y > 90)
                                {
                                    transform.Rotate(0, 260f, 0);
                                    this.ChangeSpeed = 0;
                                    timeCount = 0.5f;
                                    Move = 1;
                                }

                                else
                                {
                                    transform.Rotate(0, this.ChangeSpeed, 0);
                                    this.ChangeSpeed *= 0.1f;
                                }

                                if (Main_Scene.Language == 1)
                                {
                                    button_h.GetComponent<Image>().sprite = but[1];
                                    button_g.GetComponent<Image>().sprite = but[1];
                                }

                                else if (Main_Scene.Language == 2)
                                {
                                    button_h.GetComponent<Image>().sprite = but[33];
                                    button_g.GetComponent<Image>().sprite = but[33];
                                }

                                else if (Main_Scene.Language == 3)
                                {
                                    button_h.GetComponent<Image>().sprite = but[43];
                                    button_g.GetComponent<Image>().sprite = but[43];
                                }
                            }
                        }

                        if (step == 6)
                        {
                            Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                            Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                            Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(Player_Typing.GetComponent<RectTransform>().localPosition.x, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);

                            if (Main_Scene.Language == 1)
                            {
                                Text.GetComponent<Text>().text = "성공했어요!";
                                Text2.GetComponent<Text>().text = "축하합니다!\n다음에 또 도전해주세요!\n\n\n나가기버튼을 누르면\n메인화면으로 이동합니다.";
                            }

                            else if (Main_Scene.Language == 2)
                            {
                                QuitGames.GetComponent<Image>().sprite = but[41];
                                Text.GetComponent<Text>().text = "Good Job!";
                                Text2.GetComponent<Text>().text = "Congratulations!\nLet's do another game,\nShall we?\n\nPress the 'Out' and\nGo to the Title.";
                            }

                            else if (Main_Scene.Language == 3)
                            {
                                QuitGames.GetComponent<Image>().sprite = but[49];
                                Text.GetComponent<Text>().text = "お疲れ様!";
                                Text2.GetComponent<Text>().text = "おめでとうございます!\n次にまた\n挑戦してくださいませ!\n\n出るボタンを押すと\nタイトル画面に移動します";
                            }

                            step = 0;
                            Stop_Timer = false;
                            Timer_Check = false;
                            Card.find = false;
                            timer_stop = false;
                            Card.Choosefinished = false;
                            Hap_next = false;
                            Card.Gyeoul = false;
                            Buttonclick = 0;
                            Card.Finish = true;

                            if (Main_Scene.Last_Stage == 1)
                            {
                                MusicSource.SFXCHOOSE = true;
                                MusicSource.SFX[7] = true;
                                MusicSource.SE_volume = 0.7f;
                                MusicSource.volume = 0;
                            }
                        }

                    }

                    //3번. 결을 눌렀을 때
                    if (Buttonclick == 3)
                    {
                        if (step == 0)
                        {
                            if (!StopGame)
                            {
                                button_h.GetComponent<Image>().color = new Color(button_h.GetComponent<Image>().color.r, button_h.GetComponent<Image>().color.g, button_h.GetComponent<Image>().color.b, button_h.GetComponent<Image>().color.a - 0.15f);
                            }

                            else
                            {
                                button_h.GetComponent<Image>().color = new Color(button_h.GetComponent<Image>().color.r, button_h.GetComponent<Image>().color.g, button_h.GetComponent<Image>().color.b, button_h.GetComponent<Image>().color.a - 0.15f);
                            }

                            if (button_h.GetComponent<Image>().color.a <= 0.3f)
                            {
                                step = 1;
                            }
                        }

                        if (step == 1)
                        {
                            Main_Scene.Score = true;
                            step = 2;
                        }

                        if (step == 2)
                        {
                            if (AnswerG)
                                step = 3;
                        }

                        if (step == 3)
                        {
                            if (!Card.find) //결이 아닐 때
                            {
                                if (Main_Scene.TimeAttack && Timeattack < 5)
                                {
                                    Timeattack -= 5;
                                    Timenumber(Player01, Timeattack / 60);
                                    Timenumber(Player02, (Timeattack % 60) / 10);
                                    Timenumber(Player022, (Timeattack % 60) % 10);
                                    TimeOver = true;
                                }

                                else
                                    Buttonclick = 31;

                                NowButtonclick = 0;
                                AnswerG = false;
                                step = 0;
                            }

                            else //결일 때
                            {
                                NowButtonclick = 0;
                                Buttonclick = 32;
                                AnswerG = false;
                                step = 0;
                            }
                        }
                    }

                    //결을 실패했을 때
                    if (Buttonclick == 31)
                    {
                        if (step == 0) //이미지 등장의 위치를 정함
                        {
                            Card.FailAnswer++;

                            if (Main_Scene.TimeAttack)
                            {
                                Timeattack -= 5;
                                Timenumber(Player01, Timeattack / 60);
                                Timenumber(Player02, (Timeattack % 60) / 10);
                                Timenumber(Player022, (Timeattack % 60) % 10);

                                if (Timeattack < 0)
                                {
                                    TimeOver = true;
                                }
                            }

                            Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(400, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                            Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(-400, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                            Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(720, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);

                            MusicSource.SFXCHOOSE = true;
                            MusicSource.SFX[5] = true;
                            MusicSource.SE_volume = 0.7f;
                            MusicSource.SFXCHOOSE2 = true;
                            MusicSource.SFX2[2] = true;
                            MusicSource.SE2_volume = 0.7f;
                            step = 1;
                        }

                        if (step == 1) //등장하는 이미지 [실패]
                        {
                            Player_Line_Up.GetComponent<Image>().sprite = GameImage[4];
                            Player_Line_Down.GetComponent<Image>().sprite = GameImage[5];

                            TypeSaid(11);

                            if (!StopGame)
                            {
                                Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x - 100, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                                Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x + 100, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                                Player_Typing.GetComponent<Image>().color = new Color(Player_Typing.GetComponent<Image>().color.r, Player_Typing.GetComponent<Image>().color.g, Player_Typing.GetComponent<Image>().color.b, 1);
                                Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(Player_Typing.GetComponent<RectTransform>().localPosition.x - 180, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);
                            }

                            else
                            {
                                Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                                Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                                Player_Typing.GetComponent<Image>().color = new Color(Player_Typing.GetComponent<Image>().color.r, Player_Typing.GetComponent<Image>().color.g, Player_Typing.GetComponent<Image>().color.b, 1);
                                Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(Player_Typing.GetComponent<RectTransform>().localPosition.x, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);
                            }

                            if (Player_Line_Up.GetComponent<RectTransform>().localPosition.x == 0)
                                step = 2;
                        }

                        //늘어나는 문자
                        if (step == 2)
                        {
                            if (!StopGame)
                            {
                                Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x - 0.4f, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                                Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x + 0.4f, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                                Player_Typing.GetComponent<RectTransform>().transform.localScale = new Vector3(Player_Typing.GetComponent<RectTransform>().transform.localScale.x + 0.002f, Player_Typing.GetComponent<RectTransform>().transform.localScale.y + 0.002f, Player_Typing.GetComponent<RectTransform>().transform.localScale.z);
                            }

                            else
                            {
                                Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                                Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                                Player_Typing.GetComponent<RectTransform>().transform.localScale = new Vector3(Player_Typing.GetComponent<RectTransform>().transform.localScale.x, Player_Typing.GetComponent<RectTransform>().transform.localScale.y, Player_Typing.GetComponent<RectTransform>().transform.localScale.z);

                            }

                            if (Player_Typing.GetComponent<RectTransform>().transform.localScale.y > 0.57f)
                                step = 3;
                        }

                        //사라진 뒤 재위치
                        if (step == 3)
                        {
                            if (Player_Typing.GetComponent<RectTransform>().localPosition.x == -720)
                            {
                                button_h.GetComponent<Image>().color = new Color(button_h.GetComponent<Image>().color.r, button_h.GetComponent<Image>().color.g, button_h.GetComponent<Image>().color.b, 1);
                                Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(400, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                                Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(-400, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                                Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(720, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);
                                step = 0;
                                Card.Gyeoul = false;
                                Stop_Timer = false;
                                Timer_Check = false;
                                Card.find = false;
                                timer_stop = false;
                                Buttonclick = 0;
                                if (Main_Scene.Selected_stage[0] == 1)
                                    Invisible = true;

                                if (Card.FailAnswer >= 5)
                                    Card.ShowHint = true;
                            }

                            else
                            {
                                if (!StopGame)
                                {
                                    button_h.GetComponent<Image>().color = new Color(button_h.GetComponent<Image>().color.r, button_h.GetComponent<Image>().color.g, button_h.GetComponent<Image>().color.b, button_h.GetComponent<Image>().color.a + 0.15f);
                                    Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x - 100, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                                    Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x + 100, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                                    Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(Player_Typing.GetComponent<RectTransform>().localPosition.x - 180, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);
                                }

                                else
                                {
                                    button_h.GetComponent<Image>().color = new Color(button_h.GetComponent<Image>().color.r, button_h.GetComponent<Image>().color.g, button_h.GetComponent<Image>().color.b, button_h.GetComponent<Image>().color.a);
                                    Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                                    Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                                    Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(Player_Typing.GetComponent<RectTransform>().localPosition.x, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);
                                }
                            }
                        }
                    }

                    //결을 성공했을 때
                    if (Buttonclick == 32)
                    {
                        if (step == 0) //이미지 등장의 위치를 정함
                        {
                            Achieve();
                            Achive.Start_Ranking = true;

                            Card.FailAnswer = 0;
                            Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(400, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                            Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(-400, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                            Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(720, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);

                            MusicSource.SFXCHOOSE = true;
                            MusicSource.SFX[5] = true;
                            MusicSource.SE_volume = 0.7f;
                            MusicSource.SFXCHOOSE2 = true;
                            MusicSource.SFX2[1] = true;
                            MusicSource.SE2_volume = 0.5f;
                            step = 1;
                        }

                        if (step == 1) //등장하는 이미지 [성공]
                        {
                            Player_Line_Up.GetComponent<Image>().sprite = GameImage[4];
                            Player_Line_Down.GetComponent<Image>().sprite = GameImage[5];

                            TypeSaid(10);

                            if (!StopGame)
                            {
                                Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x - 100, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                                Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x + 100, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                                Player_Typing.GetComponent<Image>().color = new Color(Player_Typing.GetComponent<Image>().color.r, Player_Typing.GetComponent<Image>().color.g, Player_Typing.GetComponent<Image>().color.b, 1);
                                Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(Player_Typing.GetComponent<RectTransform>().localPosition.x - 180, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);
                            }

                            else
                            {
                                Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                                Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                                Player_Typing.GetComponent<Image>().color = new Color(Player_Typing.GetComponent<Image>().color.r, Player_Typing.GetComponent<Image>().color.g, Player_Typing.GetComponent<Image>().color.b, 1);
                                Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(Player_Typing.GetComponent<RectTransform>().localPosition.x, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);
                            }

                            if (Player_Line_Up.GetComponent<RectTransform>().localPosition.x == 0)
                                step = 2;
                        }

                        //늘어나는 문자
                        if (step == 2)
                        {
                            if (!StopGame)
                            {
                                Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x - 0.1f, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                                Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x + 0.1f, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                                Player_Typing.GetComponent<RectTransform>().transform.localScale = new Vector3(Player_Typing.GetComponent<RectTransform>().transform.localScale.x + 0.002f, Player_Typing.GetComponent<RectTransform>().transform.localScale.y + 0.002f, Player_Typing.GetComponent<RectTransform>().transform.localScale.z);
                            }

                            else
                            {
                                Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                                Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                                Player_Typing.GetComponent<RectTransform>().transform.localScale = new Vector3(Player_Typing.GetComponent<RectTransform>().transform.localScale.x, Player_Typing.GetComponent<RectTransform>().transform.localScale.y, Player_Typing.GetComponent<RectTransform>().transform.localScale.z);
                            }

                            if (Player_Typing.GetComponent<RectTransform>().transform.localScale.y > 0.57f)
                                step = 3;
                        }

                        //사라진 뒤 재위치
                        if (step == 3)
                        {
                            if (!StopGame)
                            {
                                button_h.GetComponent<Image>().color = new Color(button_h.GetComponent<Image>().color.r, button_h.GetComponent<Image>().color.g, button_h.GetComponent<Image>().color.b, button_h.GetComponent<Image>().color.a + 0.15f);

                                if (Main_Scene.Last_Stage == 1)
                                {
                                    Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x - 0.1f, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                                    Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x + 0.1f, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                                }
                            }

                            else
                            {
                                button_h.GetComponent<Image>().color = new Color(button_h.GetComponent<Image>().color.r, button_h.GetComponent<Image>().color.g, button_h.GetComponent<Image>().color.b, button_h.GetComponent<Image>().color.a);
                                if (Main_Scene.Last_Stage == 1)
                                {
                                    Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x - 0.1f, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                                    Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x + 0.1f, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                                }
                            }

                            if (Player_Typing.GetComponent<RectTransform>().localPosition.x == -720)
                            {
                                if (Main_Scene.Last_Stage == 1)
                                {
                                    Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(720, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);
                                    step = 4;
                                }

                                else
                                {
                                    step = 5;
                                }
                            }

                            else
                            {
                                if (!StopGame)
                                {
                                    Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(Player_Typing.GetComponent<RectTransform>().localPosition.x - 180, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);

                                    if (Main_Scene.Last_Stage > 1)
                                    {
                                        Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x - 100, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                                        Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x + 100, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                                    }
                                }

                                else
                                {
                                    Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(Player_Typing.GetComponent<RectTransform>().localPosition.x, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);
                                    if (Main_Scene.Last_Stage > 1)
                                    {
                                        Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                                        Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                                    }
                                }
                            }
                        }

                        if (step == 4) //등장하는 이미지(게임 끝!)
                        {
                            button_h.GetComponent<Image>().color = new Color(button_h.GetComponent<Image>().color.r, button_h.GetComponent<Image>().color.g, button_h.GetComponent<Image>().color.b, button_h.GetComponent<Image>().color.a);
                            TypeSaid(13);
                            Player_Typing.GetComponent<Image>().color = new Color(Player_Typing.GetComponent<Image>().color.r, Player_Typing.GetComponent<Image>().color.g, Player_Typing.GetComponent<Image>().color.b, 1);

                            if (Player_Typing.GetComponent<RectTransform>().localPosition.x == 0)
                            {
                                Move = 0;
                                step = 5;
                            }

                            else
                            {
                                if (!StopGame)
                                    Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(Player_Typing.GetComponent<RectTransform>().localPosition.x - 180, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);

                                else
                                    Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(Player_Typing.GetComponent<RectTransform>().localPosition.x, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);
                            }
                        }

                        //바뀌는 버튼
                        if (step == 5)
                        {
                            if (!StopGame)
                                Player_Typing.GetComponent<RectTransform>().transform.localScale = new Vector3(Player_Typing.GetComponent<RectTransform>().transform.localScale.x + 0.002f, Player_Typing.GetComponent<RectTransform>().transform.localScale.y + 0.002f, Player_Typing.GetComponent<RectTransform>().transform.localScale.z);

                            else
                                Player_Typing.GetComponent<RectTransform>().transform.localScale = new Vector3(Player_Typing.GetComponent<RectTransform>().transform.localScale.x, Player_Typing.GetComponent<RectTransform>().transform.localScale.y, Player_Typing.GetComponent<RectTransform>().transform.localScale.z);

                            if (Move == 1)
                            {
                                if (Player_Typing.GetComponent<RectTransform>().transform.localScale.y > 0.57f)
                                {
                                    Move = 0;
                                    step = 6;
                                    button_g.GetComponent<Image>().fillAmount = 1;

                                }
                            }

                            else
                            {
                                this.ChangeSpeed = 50;

                                if (this.transform.eulerAngles.y > 90)
                                {
                                    transform.Rotate(0, 260f, 0);
                                    this.ChangeSpeed = 0;
                                    timeCount = 0.5f;
                                    Move = 1;
                                }

                                else
                                {
                                    transform.Rotate(0, this.ChangeSpeed, 0);
                                    this.ChangeSpeed *= 0.1f;
                                }

                                if (Main_Scene.Language == 1)
                                {
                                    button_h.GetComponent<Image>().sprite = but[1];
                                    button_g.GetComponent<Image>().sprite = but[1];
                                }

                                else if (Main_Scene.Language == 2)
                                {
                                    button_h.GetComponent<Image>().sprite = but[33];
                                    button_g.GetComponent<Image>().sprite = but[33];
                                }

                                else if (Main_Scene.Language == 3)
                                {
                                    button_h.GetComponent<Image>().sprite = but[43];
                                    button_g.GetComponent<Image>().sprite = but[43];
                                }
                            }
                        }

                        //사라짐
                        if (step == 6)
                        {
                            Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                            Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                            Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(Player_Typing.GetComponent<RectTransform>().localPosition.x, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);

                            if (Main_Scene.Language == 1)
                            {
                                Text.GetComponent<Text>().text = "성공했어요!";
                                Text2.GetComponent<Text>().text = "축하합니다!\n다음에 또 도전해주세요!\n\n\n나가기버튼을 누르면\n메인화면으로 이동합니다.";
                            }

                            else if (Main_Scene.Language == 2)
                            {
                                QuitGames.GetComponent<Image>().sprite = but[41];
                                Text.GetComponent<Text>().text = "Good Job!";
                                Text2.GetComponent<Text>().text = "Congratulations!\nLet's do another game,\nShall we?\n\nPress the 'Out' and\nGo to the Title.";
                            }

                            else if (Main_Scene.Language == 3)
                            {
                                QuitGames.GetComponent<Image>().sprite = but[49];
                                Text.GetComponent<Text>().text = "お疲れ様!";
                                Text2.GetComponent<Text>().text = "おめでとうございます!\n次にまた\n挑戦してくださいませ!\n\n出るボタンを押すと\nタイトル画面に移動します";
                            }

                            step = 0;
                            Stop_Timer = false;
                            Timer_Check = false;
                            Card.find = false;
                            timer_stop = false;
                            Card.Choosefinished = false;
                            Hap_next = false;
                            Card.Gyeoul = false;
                            Buttonclick = 0;
                            Card.Finish = true;

                            if(Main_Scene.Last_Stage == 1)
                            {
                                MusicSource.SFXCHOOSE = true;
                                MusicSource.SFX[7] = true;
                                MusicSource.SE_volume = 0.7f;
                                MusicSource.volume = 0;
                            }
                        }
                    }

                }

                //0번. 합과 결 버튼을 누르지 않았을 때
                else
                {
                    NowButtonclick = 1;

                    for (int i = 0; i < 16; i++)
                        Card.Position[i].GetComponent<Image>().color = new Color(0, 0, 0, 0);

                    if(Main_Scene.Selected_stage[0] == 1 && !Main_Scene.Start_Game_Button)
                    {
                        InvisibleTime -= Time.deltaTime/60;

                        if (InvisibleTime < 0)
                            Invisible = true;
                    }

                    if(!Main_Scene.Start_Game_Button)
                        lethinttime += Time.deltaTime/60;
                }
            }

            else
            {
                Buttonclick = -1;
                NowButtonclick = 0;
                Player = 1;
                timeCount = 0;
                Move = 0;
                choose_card = 0; //합을 위해 선택된 카드의 수를 가지도록 하는 것.
            }

            if (Winner) //등장하는 장면
            {
                if (!QuitGame)
                {
                    Card.Fade.GetComponent<Image>().color = new Color(0, 0, 0, 0.9f);
                    Card.Fade.GetComponent<RectTransform>().localPosition = new Vector3(0, 0, 0);

                    if (Main_Scene.Language == 1)
                    {
                        QuitGames.GetComponent<Image>().sprite = but[27];
                    }

                    else if (Main_Scene.Language == 2)
                    {
                        QuitGames.GetComponent<Image>().sprite = but[41];
                    }

                    else if (Main_Scene.Language == 3)
                    {
                        QuitGames.GetComponent<Image>().sprite = but[49];
                    }

                    QuitGames.GetComponent<RectTransform>().localPosition = new Vector3(0, -100, 0);
                    QuitGames.GetComponent<RectTransform>().localScale = new Vector3(0.5f, 0.5f, 0);
                    Text.GetComponent<RectTransform>().localPosition = new Vector3(0, 110, 0);
                    Text2.GetComponent<RectTransform>().localPosition = new Vector3(0, -100, 0);
                    Achievement.GetComponent<RectTransform>().localPosition = new Vector3(-80, -200, 0);
                    Staring.GetComponent<RectTransform>().localPosition = new Vector3(0, -200, 0);
                    LeaderBoard.GetComponent<RectTransform>().localPosition = new Vector3(80, -200, 0);
                }

                else
                {
                    Achievement.GetComponent<RectTransform>().localPosition = new Vector3(15300, 0, 0);
                    Staring.GetComponent<RectTransform>().localPosition = new Vector3(15300, 0, 0);
                    LeaderBoard.GetComponent<RectTransform>().localPosition = new Vector3(15300, 0, 0);
                    Text.GetComponent<RectTransform>().localPosition = new Vector3(0, 1500, 0);
                    Text2.GetComponent<RectTransform>().localPosition = new Vector3(0, 1500, 0);
                    step = 0;
                    Winner = false;
                    QuitGame = false;
                    Card.step = 1;
                    StopGame = false;
                }
            }

            if(TimeOver)
            {
                if (step == 0) //이미지 등장의 위치를 정함
                {
                    Achive.AC[0] = 1; //우왕 실패했당!
                    
                    Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(400, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                    Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(-400, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                    Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(720, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);

                    MusicSource.SFXCHOOSE = true;
                    MusicSource.SFX[8] = true;
                    MusicSource.SE_volume = 1.2f;
                    MusicSource.volume = 0;
                    step = 1;
                }

                if (step == 1) //등장하는 이미지 [시간초과!]
                {
                    Player_Line_Up.GetComponent<Image>().sprite = GameImage[4];
                    Player_Line_Down.GetComponent<Image>().sprite = GameImage[5];

                    TypeSaid(15);
                    Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x - 100, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                    Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x + 100, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                    Player_Typing.GetComponent<Image>().color = new Color(Player_Typing.GetComponent<Image>().color.r, Player_Typing.GetComponent<Image>().color.g, Player_Typing.GetComponent<Image>().color.b, 1);
                    Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(Player_Typing.GetComponent<RectTransform>().localPosition.x - 180, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);

                    if (Player_Line_Up.GetComponent<RectTransform>().localPosition.x == 0)
                        step = 2;
                }

                //늘어나는 문자
                if (step == 2)
                {
                    Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x - 0.1f, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                    Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x + 0.1f, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                    Player_Typing.GetComponent<RectTransform>().transform.localScale = new Vector3(Player_Typing.GetComponent<RectTransform>().transform.localScale.x + 0.002f, Player_Typing.GetComponent<RectTransform>().transform.localScale.y + 0.002f, Player_Typing.GetComponent<RectTransform>().transform.localScale.z);

                    if (Player_Typing.GetComponent<RectTransform>().transform.localScale.y > 0.57f)
                        step = 3;
                }

                //사라진 뒤 재위치
                if (step == 3)
                {
                    Player_Line_Up.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Up.GetComponent<RectTransform>().localPosition.x, Player_Line_Up.GetComponent<RectTransform>().localPosition.y, Player_Line_Up.transform.position.z);
                    Player_Line_Down.GetComponent<RectTransform>().localPosition = new Vector3(Player_Line_Down.GetComponent<RectTransform>().localPosition.x, Player_Line_Down.GetComponent<RectTransform>().localPosition.y, Player_Line_Down.transform.position.z);
                    Player_Typing.GetComponent<RectTransform>().localPosition = new Vector3(Player_Typing.GetComponent<RectTransform>().localPosition.x, Player_Typing.GetComponent<RectTransform>().localPosition.y, Player_Typing.transform.position.z);

                    if (Main_Scene.Language == 1)
                    {
                        Text.GetComponent<Text>().text = "아쉽게 실패해버리고 말았네요...";
                        Text2.GetComponent<Text>().text = "하지만 낙심하지 마세요!\n다음에는 해낼 수 있을 거예요!\n\n\n나가기버튼을 누르면\n메인화면으로 이동합니다.";
                    }

                    else if (Main_Scene.Language == 2)
                    {
                        Text.GetComponent<Text>().text = "Oh, I'm sorry about that...";
                        Text2.GetComponent<Text>().text = "But don't worry!\nYou'll succeed it next time!\n\n\nPress the 'Out' and\nGo to Main Scene.";
                    }

                    else if (Main_Scene.Language == 3)
                    {
                        Text.GetComponent<Text>().text = "残念です…";
                        Text2.GetComponent<Text>().text = "でも大丈夫!\n次はきっと成功することが\nできますから!\n\n出るボタンを押すと\nタイトル画面に移動します";
                    }

                    Stop_Timer = false;
                    Timer_Check = false;
                    Card.find = false;
                    timer_stop = false;
                    Card.Choosefinished = false;
                    Hap_next = false;
                    Card.Gyeoul = false;
                    Buttonclick = 0;
                    Card.Finish = true;
                    TimeOver = false;
                }
            }
        }

        if (SeeHintthis)
        {
            if(hintint == 0)
            {
                hintnumber = Hint();
                hintint = 1;
            }

            if(hintint == 1)
            {
                if (hintnumber >= 0)
                {
                    if (Main_Scene.Language == 1)
                    {
                        Text.GetComponent<RectTransform>().localPosition = new Vector3(0, 130);
                        Text.GetComponent<Text>().text = "또 다른 '합'에 대한\n힌트 발견!";
                        HintImage.GetComponent<RectTransform>().localPosition = new Vector3(0, 50);
                        HintImage.GetComponent<Image>().sprite = Card.spr[Card.Num[hintnumber]];
                        Text2.GetComponent<RectTransform>().localPosition = new Vector3(0, -190, 0);
                        Text2.GetComponent<Text>().text = "이 버튼과 관련된\n합이 존재합니다!\n\n도움이 되길 바랄게요!";
                        Card.SeeHint.GetComponent<RectTransform>().localPosition = new Vector3(518, -144, 0);
                        Card.Keepit.GetComponent<RectTransform>().localPosition = new Vector3(0, -150, 0);
                    }

                    else if (Main_Scene.Language == 2)
                    {
                        Text.GetComponent<RectTransform>().localPosition = new Vector3(0, 150);
                        Text.GetComponent<Text>().text = "We found the hint about another 'Find!'";
                        HintImage.GetComponent<RectTransform>().localPosition = new Vector3(0, 50);
                        HintImage.GetComponent<Image>().sprite = Card.spr[Card.Num[hintnumber]];
                        Text2.GetComponent<RectTransform>().localPosition = new Vector3(0, -190, 0);
                        Text2.GetComponent<Text>().text = "This Card must relate with another 'Find!'\n\nI hope it was helpful!";
                        Card.SeeHint.GetComponent<RectTransform>().localPosition = new Vector3(518, -144, 0);
                        Card.Keepit.GetComponent<RectTransform>().localPosition = new Vector3(0, -150, 0);
                    }

                    else if (Main_Scene.Language == 3)
                    {
                        Text.GetComponent<RectTransform>().localPosition = new Vector3(0, 150);
                        Text.GetComponent<Text>().text = "新たなる'合'の\nヒントを\n見つけました!";
                        HintImage.GetComponent<RectTransform>().localPosition = new Vector3(0, 50);
                        HintImage.GetComponent<Image>().sprite = Card.spr[Card.Num[hintnumber]];
                        Text2.GetComponent<RectTransform>().localPosition = new Vector3(0, -190, 0);
                        Text2.GetComponent<Text>().text = "このカードに対する\n'合'があります!\n\n役に立ったら嬉しいです!";
                        Card.SeeHint.GetComponent<RectTransform>().localPosition = new Vector3(518, -144, 0);
                        Card.Keepit.GetComponent<RectTransform>().localPosition = new Vector3(0, -150, 0);
                    }
                }

                if (hintnumber < 0)
                {
                    if (Main_Scene.Language == 1)
                    {
                        Text.GetComponent<Text>().text = "'또 다른 합'에 대한\n힌트 발견?!";
                        Text2.GetComponent<Text>().text = "더 이상 '합'이\n존재하지 않습니다!\n\n빨리 결을 눌러요!";
                        Card.SeeHint.GetComponent<RectTransform>().localPosition = new Vector3(518, -144, 0);
                    }

                    else if (Main_Scene.Language == 2)
                    {
                        Text.GetComponent<Text>().text = "We found the hint about another 'Find?!'";
                        Text2.GetComponent<Text>().text = "There is no 'Find' left on this stage!\nPress the 'Set' Quickly!";
                        Card.SeeHint.GetComponent<RectTransform>().localPosition = new Vector3(518, -144, 0);
                    }

                    else if (Main_Scene.Language == 3)
                    {
                        Text.GetComponent<Text>().text = "新たなる'合'の\nヒントを見っけ?!";
                        Text2.GetComponent<Text>().text = "もう'合'はいないです…\n早く'決'を押してください!";
                        Card.SeeHint.GetComponent<RectTransform>().localPosition = new Vector3(518, -144, 0);
                    }
                }

                hintint = 2;

                Card.FailAnswer = 0;
            }

            if (hintint == 2)
            {
                hintint = 0;
                SeeHintthis = false;
                lethinttime = 0;
                Hintpage = false;
            }
        }
    }

    public void DecreaseTime_H() // 시간이 지남에 따라서 이미지가 점점 사라진다.
    {
        if(choose_card < 3)
        {
            this.button_h.GetComponent<Image>().fillAmount -= Time.deltaTime / 10f;
        }
    }

    public void DecreaseTime_G() // 시간이 지남에 따라서 이미지가 점점 사라진다.
    {
        if (choose_card < 3)
        {
            this.button_g.GetComponent<Image>().fillAmount -= Time.deltaTime / 5f;
        }
    }

    public void DecreaseTimer() // 시간이 지남에 따라서 이미지가 점점 사라진다.
    {
        if(Buttonclick == 0)
        {
            this.First_Timer.GetComponent<Image>().fillAmount -= Time.deltaTime / 100f;
        }
    }

    public void DecreaseTimer2() // 시간이 지남에 따라서 이미지가 점점 사라진다.
    {
        if (Buttonclick == 0)
        {
            this.First_Timer.GetComponent<Image>().fillAmount -= Time.deltaTime / 500f;
        }
    }

    public void BecomeInvisible() // 시간이 지남에 따라서 이미지가 점점 사라진다.
    {
        if (Buttonclick == 0)
        {
            this.button_h.GetComponent<Image>().fillAmount -= Time.deltaTime / 750f;
        }
    }

    public void Number(GameObject A, int num)
    {
        if(num == 0)
        {
            A.GetComponent<Image>().sprite = but[15];
            A.GetComponent<RectTransform>().sizeDelta = new Vector3(75, 102);
        }

        else if (num == 1)
        {
            A.GetComponent<Image>().sprite = but[6];
            A.GetComponent<RectTransform>().sizeDelta = new Vector3(47, 100);
        }

        else if (num == 2)
        {
            A.GetComponent<Image>().sprite = but[7];
            A.GetComponent<RectTransform>().sizeDelta = new Vector3(69, 101);
        }

        else if (num == 3)
        {
            A.GetComponent<Image>().sprite = but[8];
            A.GetComponent<RectTransform>().sizeDelta = new Vector3(71, 101);
        }

        else if (num == 4)
        {
            A.GetComponent<Image>().sprite = but[9];
            A.GetComponent<RectTransform>().sizeDelta = new Vector3(73, 100);
        }

        else if (num == 5)
        {
            A.GetComponent<Image>().sprite = but[10];
            A.GetComponent<RectTransform>().sizeDelta = new Vector3(70, 101);
        }

        else if (num == 6)
        {
            A.GetComponent<Image>().sprite = but[11];
            A.GetComponent<RectTransform>().sizeDelta = new Vector3(71, 102);
        }

        else if (num == 7)
        {
            A.GetComponent<Image>().sprite = but[12];
            A.GetComponent<RectTransform>().sizeDelta = new Vector3(67, 100);
        }

        else if (num == 8)
        {
            A.GetComponent<Image>().sprite = but[13];
            A.GetComponent<RectTransform>().sizeDelta = new Vector3(73, 102);
        }

        else if (num == 9)
        {
            A.GetComponent<Image>().sprite = but[14];
            A.GetComponent<RectTransform>().sizeDelta = new Vector3(71, 102);
        }
    }

    public void Timenumber(GameObject A, float num)
    {
        if (num >= 0 && num < 1)
        {
            A.GetComponent<Image>().sprite = but[15];
            A.GetComponent<RectTransform>().sizeDelta = new Vector3(75, 102);
        }

        else if (num >= 1 && num < 2)
        {
            A.GetComponent<Image>().sprite = but[6];
            A.GetComponent<RectTransform>().sizeDelta = new Vector3(47, 100);
        }

        else if (num >= 2 && num < 3)
        {
            A.GetComponent<Image>().sprite = but[7];
            A.GetComponent<RectTransform>().sizeDelta = new Vector3(69, 101);
        }

        else if (num >= 3 && num < 4)
        {
            A.GetComponent<Image>().sprite = but[8];
            A.GetComponent<RectTransform>().sizeDelta = new Vector3(71, 101);
        }

        else if (num >= 4 && num < 5)
        {
            A.GetComponent<Image>().sprite = but[9];
            A.GetComponent<RectTransform>().sizeDelta = new Vector3(73, 100);
        }

        else if (num >= 5 && num < 6)
        {
            A.GetComponent<Image>().sprite = but[10];
            A.GetComponent<RectTransform>().sizeDelta = new Vector3(70, 101);
        }

        else if (num >= 6 && num < 7)
        {
            A.GetComponent<Image>().sprite = but[11];
            A.GetComponent<RectTransform>().sizeDelta = new Vector3(71, 102);
        }

        else if (num >= 7 && num < 8)
        {
            A.GetComponent<Image>().sprite = but[12];
            A.GetComponent<RectTransform>().sizeDelta = new Vector3(67, 100);
        }

        else if (num >= 8 && num < 9)
        {
            A.GetComponent<Image>().sprite = but[13];
            A.GetComponent<RectTransform>().sizeDelta = new Vector3(73, 102);
        }

        else if (num >= 9 && num < 10)
        {
            A.GetComponent<Image>().sprite = but[14];
            A.GetComponent<RectTransform>().sizeDelta = new Vector3(71, 102);
        }

        else if (num >= 10)
        {
            A.GetComponent<Image>().sprite = but[31];
            A.GetComponent<RectTransform>().sizeDelta = new Vector3(82, 100);
        }
    }

    public void Score()
    {
        Number(Player011, Main_Scene.Player_1_Score / 10);
        Number(Player01, Main_Scene.Player_1_Score % 10);
        Number(Player022, Main_Scene.Player_2_Score / 10);
        Number(Player02, Main_Scene.Player_2_Score % 10);
        Number(Player_WinCount01, Main_Scene.Player_1_WinCount % 10);
        Number(Player_WinCount02, Main_Scene.Player_2_WinCount % 10);
    }

    public int Hint()
    {
        int hintpoint = -1;

        //4*4모드가 아닐 때
        if (Main_Scene.Selected_stage[2] == 0)
        {
            for (int x = 0; x < 7; x++)
            {
                for (int y = x + 1; y < 8; y++)
                {
                    for (int z = y + 1; z < 9; z++) 
                    {
                        int H = 0;
                        int Already = 0;
                        //3개를 골라 확인한다.
                        for (int n = 0; n < 3; n++)
                        {
                            //모양이 같거나 아예 다른 지 확인한다.
                            bool Con1 = Card.Style[x, n] == Card.Style[y, n];
                            bool Con2 = Card.Style[y, n] == Card.Style[z, n];
                            bool Con3 = Card.Style[z, n] == Card.Style[x, n];

                            if (Con1 == Con2 & Con2 == Con3 & Con1 == Con3)
                            {
                                H++; //이는 합이다.
                            }

                            else // 해당 리스트에서 합이 아니면 합이 아니므로 빠져나간다.
                            {
                                break;
                            }
                        }

                        if (H == 3) // 합이라면 H의 값이 3이 나와야한다.
                        {
                            for(int i = 0; i < Card.Allnumber; i++)
                            {
                                bool Con1 = Card.AlChoose[i, 0] == x;
                                bool Con2 = Card.AlChoose[i, 1] == y;
                                bool Con3 = Card.AlChoose[i, 2] == z;

                                if (Con1 & Con2 & Con3 & true)
                                {
                                    Already++;
                                    break;
                                }
                            }

                            if (Already == 0)
                            {
                                hintpoint = UnityEngine.Random.Range(0, 3); //x, y, z중 하나를 고르게 한다.

                                if (hintpoint == 0)
                                    return x;

                                else if (hintpoint == 1)
                                    return y;

                                else if (hintpoint == 2)
                                    return z;
                                break;
                            }
                        }
                    }
                }
            }
        }
        
        //4*4모드일 때
        else if (Main_Scene.Selected_stage[2] == 1)
        {
            for (int x = 0; x < 16; x++)
            {
                for (int y = x + 1; y < 15; y++)
                {
                    for (int z = y + 1; z < 14; z++)
                    {
                        int H = 0;
                        int Already = 0;
                        //3개를 골라 확인한다.
                        for (int n = 0; n < 3; n++)
                        {
                            //모양이 같거나 아예 다른 지 확인한다.
                            bool Con1 = Card.Style[x, n] == Card.Style[y, n];
                            bool Con2 = Card.Style[y, n] == Card.Style[z, n];
                            bool Con3 = Card.Style[z, n] == Card.Style[x, n];

                            if (Con1 == Con2 & Con2 == Con3 & Con1 == Con3)
                            {
                                H++; //이는 합이다.
                            }

                            else // 해당 리스트에서 합이 아니면 합이 아니므로 빠져나간다.
                            {
                                break;
                            }
                        }

                        if (H == 3) // 합이라면 H의 값이 3이 나와야한다.
                        {
                            for (int i = 0; i < Card.Allnumber; i++)
                            {
                                bool Con1 = Card.AlChoose[i, 0] == x;
                                bool Con2 = Card.AlChoose[i, 1] == y;
                                bool Con3 = Card.AlChoose[i, 2] == z;

                                if (Con1 & Con2 & Con3 & true)
                                {
                                    Already++;
                                    break;
                                }
                            }

                            if (Already == 0)
                            {
                                hintpoint = UnityEngine.Random.Range(0, 3); //x, y, z중 하나를 고르게 한다.

                                if (hintpoint == 0)
                                    return x;

                                else if (hintpoint == 1)
                                    return y;

                                else if (hintpoint == 2)
                                    return z;
                                break;
                            }
                        }
                    }
                }
            }
        }

        return -1;
    }

    public void Achieve()
    {
        if (Challenge.Ch)
        {
            //업적 2번째. 만약 한 번도 얻지 못했다면 얻을 수 있게 설정된다.
            Achive.AC[1]++;

            //업적 6번째. 5초 이내에 남은 상태에서 클리어를 한다.
            if (Main_Scene.TimeAttack && Button_Script.Timeattack < 5)
                Achive.AC[6]++;

            if (Challenge.Challengemode[0] == 1)
            {
                if (!Button_Script.TimeOver && !Button_Script.QuitGame)
                {
                    Achive.AC[39]++;
                    PlayerPrefs.SetInt("Complete0", 1);
                }
            }

            else if (Challenge.Challengemode[1] == 1)
            {
                if (!Button_Script.TimeOver && !Button_Script.QuitGame)
                {
                    Achive.AC[40]++;
                    PlayerPrefs.SetInt("Complete1", 1);
                }
            }

            else if (Challenge.Challengemode[2] == 1)
            {
                if (!Button_Script.TimeOver && !Button_Script.QuitGame)
                {
                    Achive.AC[41]++;
                    PlayerPrefs.SetInt("Complete2", 1);
                }
            }

            else if (Challenge.Challengemode[3] == 1)
            {
                if (!Button_Script.TimeOver && !Button_Script.QuitGame)
                {
                    Achive.AC[42]++;
                    PlayerPrefs.SetInt("Complete3", 1);
                }
            }

            else if (Challenge.Challengemode[4] == 1)
            {
                if (!Button_Script.TimeOver && !Button_Script.QuitGame)
                {
                    Achive.AC[43]++;
                    PlayerPrefs.SetInt("Complete4", 1);
                }
            }

            else if (Challenge.Challengemode[5] == 1)
            {
                if (!Button_Script.TimeOver && !Button_Script.QuitGame)
                {
                    Achive.AC[44]++;
                    PlayerPrefs.SetInt("Complete5", 1);
                }
            }

            else if (Challenge.Challengemode[6] == 1)
            {
                if (!Button_Script.TimeOver && !Button_Script.QuitGame)
                {
                    Achive.AC[45]++;
                    PlayerPrefs.SetInt("Complete6", 1);
                }
            }

            else if (Challenge.Challengemode[7] == 1)
            {
                if (!Button_Script.TimeOver && !Button_Script.QuitGame)
                {
                    Achive.AC[46]++;
                    PlayerPrefs.SetInt("Complete7", 1);
                }
            }

            else if (Challenge.Challengemode[8] == 1)
            {
                if (!Button_Script.TimeOver && !Button_Script.QuitGame && Main_Scene.Last_Stage == 1)
                {
                    Achive.AC[47]++;
                    PlayerPrefs.SetInt("Complete8", 1);
                }
            }

            PlayerPrefs.Save();

        }

        else
        {
            //2인모드일 때
            if (!Main_Scene.Player1Mode)
            {
                //둘이서 함께 성공
                Achive.AC[35]++;

                //마지막 합이 나올 때까지 0:0이었다
                if ((Main_Scene.Player_1_Score == 4 && Main_Scene.Player_2_Score == 0) || (Main_Scene.Player_1_Score == 0 && Main_Scene.Player_2_Score == 4) || (Main_Scene.Player_1_Score == 1 && Main_Scene.Player_2_Score == 3) || (Main_Scene.Player_1_Score == 3 && Main_Scene.Player_2_Score == 1))
                    Achive.AC[36]++;

                //5스테이지의 마지노선에 돌입
                if (Main_Scene.Player_1_WinCount + Main_Scene.Player_2_WinCount + 1 == 6)
                    Achive.AC[37]++;

                //한 플레이어가 다른 플레이어보다 많이 이겨서 조기종료된다.
                if ((Main_Scene.Player_1_WinCount + Main_Scene.Player_2_WinCount + Main_Scene.Last_Stage - 1 >= 3) && (Main_Scene.Player_1_WinCount > ((Main_Scene.Player_1_WinCount + Main_Scene.Player_2_WinCount + Main_Scene.Last_Stage - 1) / 2) || Main_Scene.Player_2_WinCount > ((Main_Scene.Player_1_WinCount + Main_Scene.Player_2_WinCount + Main_Scene.Last_Stage - 1) / 2)))
                    Achive.AC[38]++;
            }

            //1인모드일 때
            else
            {
                if (Timeattack < 0 && TimeOver)
                {
                    //아무 일도 일어나지 않는다.
                }

                else
                {
                    if (Main_Scene.TimeAttack)
                    {
                        //업적 2번째. 만약 한 번도 얻지 못했다면 얻을 수 있게 설정된다.
                        Achive.AC[1]++;

                        //업적 3번째. 한 판을 2분 이내에 클리어를 해야한다.
                        if (NowTime - Timeattack <= 120)
                            Achive.AC[2]++;

                        //업적 4번째. 1분 이내에 클리어를 해야한다.
                        if (Main_Scene.Firsttime - Timeattack <= 60)
                            Achive.AC[3]++;

                        //업적 5번째. 3개 이상의 스테이지여야한다. 즉, 3개가 마지노선이라는 것. 그리고 4분 이내야한다.
                        if (Main_Scene.Player_1_WinCount + 1 == 4 && Main_Scene.Firsttime - Timeattack <= 240)
                        {
                            Achive.AC[4]++;

                            //단, 힌트를 보지 않아야지 이것도 얻을 수 있다.
                            if (Main_Scene.hintcount == 0)
                                Achive.AC[5]++;
                        }

                        //업적 6번째. 5초 이내에 남은 상태에서 클리어를 한다.
                        if (!TimeOver && Timeattack < 5)
                            Achive.AC[6]++;

                        //업적 50번째. 힌트를 한번이라도 봤을 때
                        if (Main_Scene.hintcount > 0)
                            Achive.AC[49]++;

                        //합성모드일 때
                        if (Main_Scene.Selected_stage[3] == 1)
                        {
                            if (Main_Scene.Selected_stage[0] == 1 && Main_Scene.Selected_stage[1] == 1)
                            {
                                //모든 모드를 합침
                                if (Main_Scene.Selected_stage[2] == 1)
                                {
                                    //업적 32번째. 만약 한 번도 얻지 못했다면 얻을 수 있게 설정된다.
                                    Achive.AC[31]++;

                                    //업적 33번째. 3분 이내에 클리어를 해야한다.
                                    if (NowTime - Timeattack <= 180)
                                        Achive.AC[32]++;

                                    //업적 34번째. 3개 이상의 스테이지여야한다. 즉, 3개가 마지노선이라는 것. 7분 이내여야한다.
                                    if (Main_Scene.Player_1_WinCount + 1 == 4 && Main_Scene.Firsttime - Timeattack <= 420)
                                    {
                                        Achive.AC[33]++;

                                        //업적 35번째. 단, 힌트를 보지 않아야지 이것도 얻을 수 있다.
                                        if (Main_Scene.hintcount == 0)
                                            Achive.AC[34]++;
                                    }
                                }

                                //가림막 + 전등모드
                                else
                                {
                                    //업적 20번째. 만약 한 번도 얻지 못했다면 얻을 수 있게 설정된다.
                                    Achive.AC[19]++;

                                    //업적 21번째. 2분 30초 이내에 클리어를 해야한다.
                                    if (NowTime - Timeattack <= 150)
                                        Achive.AC[20]++;

                                    //업적 22번째. 3개 이상의 스테이지여야한다. 즉, 3개가 마지노선이라는 것. 5분 40초 이내여야한다.
                                    if (Main_Scene.Player_1_WinCount + 1 == 4 && Main_Scene.Firsttime - Timeattack <= 340)
                                    {
                                        Achive.AC[21]++;

                                        //업적 23번째. 단, 힌트를 보지 않아야지 이것도 얻을 수 있다.
                                        if (Main_Scene.hintcount == 0)
                                            Achive.AC[22]++;
                                    }
                                }
                            }

                            else
                            {
                                //가림막 + 4*4모드
                                if (Main_Scene.Selected_stage[0] == 1 && Main_Scene.Selected_stage[2] == 1)
                                {
                                    //업적 24번째. 만약 한 번도 얻지 못했다면 얻을 수 있게 설정된다.
                                    Achive.AC[23]++;

                                    //업적 25번째. 2분 40초이내에 클리어를 해야한다.
                                    if (NowTime - Timeattack <= 160)
                                        Achive.AC[24]++;

                                    //업적 26번째. 3개 이상의 스테이지여야한다. 즉, 3개가 마지노선이라는 것. 6분 이내야야한다.
                                    if (Main_Scene.Player_1_WinCount + 1 == 4 && Main_Scene.Firsttime - Timeattack <= 360)
                                    {
                                        Achive.AC[25]++;

                                        //업적 27번째. 단, 힌트를 보지 않아야지 이것도 얻을 수 있다.
                                        if (Main_Scene.hintcount == 0)
                                            Achive.AC[26]++;
                                    }
                                }

                                //전등 + 4*4모드
                                else if (Main_Scene.Selected_stage[1] == 1 && Main_Scene.Selected_stage[2] == 1)
                                {
                                    //업적 28번째. 만약 한 번도 얻지 못했다면 얻을 수 있게 설정된다.
                                    Achive.AC[27]++;

                                    //업적 29번째. 2분 30초 이내에 클리어를 해야한다.
                                    if (NowTime - Timeattack <= 150)
                                        Achive.AC[28]++;

                                    //업적 30번째. 3개 이상의 스테이지여야한다. 즉, 3개가 마지노선이라는 것. 5분 20 초 이내여야한다.
                                    if (Main_Scene.Player_1_WinCount + 1 == 4 && Main_Scene.Firsttime - Timeattack <= 320)
                                    {
                                        Achive.AC[29]++;

                                        //업적 31번째. 단, 힌트를 보지 않아야지 이것도 얻을 수 있다.
                                        if (Main_Scene.hintcount == 0)
                                            Achive.AC[30]++;
                                    }
                                }
                            }

                        }

                        //합성모드가 아닐 때 (개별)
                        else
                        {
                            //가림막모드일 때
                            if (Main_Scene.Selected_stage[0] == 1)
                            {
                                //업적 8번째. 만약 한 번도 얻지 못했다면 얻을 수 있게 설정된다.
                                Achive.AC[7]++;

                                //업적 9번째. 2분 10초 이내에 클리어를 해야한다.
                                if (NowTime - Timeattack <= 130)
                                    Achive.AC[8]++;

                                //업적 10번째. 3개 이상의 스테이지여야한다. 즉, 3개가 마지노선이라는 것. 4분 이내여야한다.
                                if (Main_Scene.Player_1_WinCount + 1 == 4 && Main_Scene.Firsttime - Timeattack <= 240)
                                {
                                    Achive.AC[9]++;

                                    //업적 11번째. 단, 힌트를 보지 않아야지 이것도 얻을 수 있다.
                                    if (Main_Scene.hintcount == 0)
                                        Achive.AC[10]++;
                                }
                            }

                            //전등모드일 때
                            else if (Main_Scene.Selected_stage[1] == 1)
                            {
                                //업적 12번째. 만약 한 번도 얻지 못했다면 얻을 수 있게 설정된다.
                                Achive.AC[11]++;

                                //업적 13번째. 2분 이내에 클리어를 해야한다.
                                if (NowTime - Timeattack <= 120)
                                    Achive.AC[12]++;

                                //업적 14번째. 3개 이상의 스테이지여야한다. 즉, 3개가 마지노선이라는 것. 4분 이내여야한다.
                                if (Main_Scene.Player_1_WinCount + 1 == 4 && Main_Scene.Firsttime - Timeattack <= 240)
                                {
                                    Achive.AC[13]++;

                                    //업적 15번째. 단, 힌트를 보지 않아야지 이것도 얻을 수 있다.
                                    if (Main_Scene.hintcount == 0)
                                        Achive.AC[14]++;
                                }
                            }

                            //4*4모드일 때
                            else if (Main_Scene.Selected_stage[2] == 1)
                            {
                                //업적 16번째. 만약 한 번도 얻지 못했다면 얻을 수 있게 설정된다.
                                Achive.AC[15]++;

                                //업적 17번째. 2분 20초 이내에 클리어를 해야한다.
                                if (NowTime - Timeattack <= 140)
                                    Achive.AC[16]++;

                                //업적 18번째. 3개 이상의 스테이지여야한다. 즉, 3개가 마지노선이라는 것. 5분 이내여야한다.
                                if (Main_Scene.Player_1_WinCount + 1 == 4 && Main_Scene.Firsttime - Timeattack <= 300)
                                {
                                    Achive.AC[17]++;

                                    //업적 19번째. 단, 힌트를 보지 않아야지 이것도 얻을 수 있다.
                                    if (Main_Scene.hintcount == 0)
                                        Achive.AC[18]++;
                                }
                            }
                        }
                    }

                    else
                    {
                        Debug.Log(Timeattack);
                        //업적 2번째. 만약 한 번도 얻지 못했다면 얻을 수 있게 설정된다.
                        Achive.AC[1]++;

                        //업적 3번째. 한 판을 2분 이내에 클리어를 해야한다.
                        if (Timeattack <= 120)
                            Achive.AC[2]++;

                        //업적 4번째. 1분 이내에 클리어를 해야한다.
                        if (Timeattack <= 60)
                            Achive.AC[3]++;

                        //업적 5번째. 3개 이상의 스테이지여야한다. 즉, 3개가 마지노선이라는 것. 그리고 4분 이내야한다.
                        if (Main_Scene.Player_1_WinCount + 1 == 4 && Timeattack <= 240)
                        {
                            Achive.AC[4]++;

                            //단, 힌트를 보지 않아야지 이것도 얻을 수 있다.
                            if (Main_Scene.hintcount == 0)
                                Achive.AC[5]++;
                        }

                        //업적 6번째. 5초 이내에 남은 상태에서 클리어를 한다.
                        if (!TimeOver && Timeattack < 5)
                            Achive.AC[6]++;

                        //업적 50번째. 힌트를 한번이라도 봤을 때
                        if (Main_Scene.hintcount > 0)
                            Achive.AC[49]++;

                        //합성모드일 때
                        if (Main_Scene.Selected_stage[3] == 1)
                        {
                            if (Main_Scene.Selected_stage[0] == 1 && Main_Scene.Selected_stage[1] == 1)
                            {
                                //모든 모드를 합침
                                if (Main_Scene.Selected_stage[2] == 1)
                                {
                                    //업적 32번째. 만약 한 번도 얻지 못했다면 얻을 수 있게 설정된다.
                                    Achive.AC[31]++;

                                    //업적 33번째. 3분 이내에 클리어를 해야한다.
                                    if (Timeattack <= 180)
                                        Achive.AC[32]++;

                                    //업적 34번째. 3개 이상의 스테이지여야한다. 즉, 3개가 마지노선이라는 것. 7분 이내여야한다.
                                    if (Main_Scene.Player_1_WinCount + 1 == 4 && Timeattack <= 420)
                                    {
                                        Achive.AC[33]++;

                                        //업적 35번째. 단, 힌트를 보지 않아야지 이것도 얻을 수 있다.
                                        if (Main_Scene.hintcount == 0)
                                            Achive.AC[34]++;
                                    }
                                }

                                //가림막 + 전등모드
                                else
                                {
                                    //업적 20번째. 만약 한 번도 얻지 못했다면 얻을 수 있게 설정된다.
                                    Achive.AC[19]++;

                                    //업적 21번째. 2분 30초 이내에 클리어를 해야한다.
                                    if (Timeattack <= 150)
                                        Achive.AC[20]++;

                                    //업적 22번째. 3개 이상의 스테이지여야한다. 즉, 3개가 마지노선이라는 것. 5분 40초 이내여야한다.
                                    if (Main_Scene.Player_1_WinCount + 1 == 4 && Timeattack <= 340)
                                    {
                                        Achive.AC[21]++;

                                        //업적 23번째. 단, 힌트를 보지 않아야지 이것도 얻을 수 있다.
                                        if (Main_Scene.hintcount == 0)
                                            Achive.AC[22]++;
                                    }
                                }
                            }

                            else
                            {
                                //가림막 + 4*4모드
                                if (Main_Scene.Selected_stage[0] == 1 && Main_Scene.Selected_stage[2] == 1)
                                {
                                    //업적 24번째. 만약 한 번도 얻지 못했다면 얻을 수 있게 설정된다.
                                    Achive.AC[23]++;

                                    //업적 25번째. 2분 40초이내에 클리어를 해야한다.
                                    if (Timeattack <= 160)
                                        Achive.AC[24]++;

                                    //업적 26번째. 3개 이상의 스테이지여야한다. 즉, 3개가 마지노선이라는 것. 6분 이내야야한다.
                                    if (Main_Scene.Player_1_WinCount + 1 == 4 && Timeattack <= 360)
                                    {
                                        Achive.AC[25]++;

                                        //업적 27번째. 단, 힌트를 보지 않아야지 이것도 얻을 수 있다.
                                        if (Main_Scene.hintcount == 0)
                                            Achive.AC[26]++;
                                    }
                                }

                                //전등 + 4*4모드
                                else if (Main_Scene.Selected_stage[1] == 1 && Main_Scene.Selected_stage[2] == 1)
                                {
                                    //업적 28번째. 만약 한 번도 얻지 못했다면 얻을 수 있게 설정된다.
                                    Achive.AC[27]++;

                                    //업적 29번째. 2분 30초 이내에 클리어를 해야한다.
                                    if (Timeattack <= 150)
                                        Achive.AC[28]++;

                                    //업적 30번째. 3개 이상의 스테이지여야한다. 즉, 3개가 마지노선이라는 것. 5분 20 초 이내여야한다.
                                    if (Main_Scene.Player_1_WinCount + 1 == 4 && Timeattack <= 320)
                                    {
                                        Achive.AC[29]++;

                                        //업적 31번째. 단, 힌트를 보지 않아야지 이것도 얻을 수 있다.
                                        if (Main_Scene.hintcount == 0)
                                            Achive.AC[30]++;
                                    }
                                }
                            }

                        }

                        //합성모드가 아닐 때 (개별)
                        else
                        {
                            //가림막모드일 때
                            if (Main_Scene.Selected_stage[0] == 1)
                            {
                                //업적 8번째. 만약 한 번도 얻지 못했다면 얻을 수 있게 설정된다.
                                Achive.AC[7]++;

                                //업적 9번째. 2분 10초 이내에 클리어를 해야한다.
                                if (Timeattack <= 130)
                                    Achive.AC[8]++;

                                //업적 10번째. 3개 이상의 스테이지여야한다. 즉, 3개가 마지노선이라는 것. 4분 이내여야한다.
                                if (Main_Scene.Player_1_WinCount + 1 == 4 && Timeattack <= 240)
                                {
                                    Achive.AC[9]++;

                                    //업적 11번째. 단, 힌트를 보지 않아야지 이것도 얻을 수 있다.
                                    if (Main_Scene.hintcount == 0)
                                        Achive.AC[10]++;
                                }
                            }

                            //전등모드일 때
                            else if (Main_Scene.Selected_stage[1] == 1)
                            {
                                //업적 12번째. 만약 한 번도 얻지 못했다면 얻을 수 있게 설정된다.
                                Achive.AC[11]++;

                                //업적 13번째. 2분 이내에 클리어를 해야한다.
                                if (Timeattack <= 120)
                                    Achive.AC[12]++;

                                //업적 14번째. 3개 이상의 스테이지여야한다. 즉, 3개가 마지노선이라는 것. 4분 이내여야한다.
                                if (Main_Scene.Player_1_WinCount + 1 == 4 && Timeattack <= 240)
                                {
                                    Achive.AC[13]++;

                                    //업적 15번째. 단, 힌트를 보지 않아야지 이것도 얻을 수 있다.
                                    if (Main_Scene.hintcount == 0)
                                        Achive.AC[14]++;
                                }
                            }

                            //4*4모드일 때
                            else if (Main_Scene.Selected_stage[2] == 1)
                            {
                                //업적 16번째. 만약 한 번도 얻지 못했다면 얻을 수 있게 설정된다.
                                Achive.AC[15]++;

                                //업적 17번째. 2분 20초 이내에 클리어를 해야한다.
                                if (Timeattack <= 140)
                                    Achive.AC[16]++;

                                //업적 18번째. 3개 이상의 스테이지여야한다. 즉, 3개가 마지노선이라는 것. 5분 이내여야한다.
                                if (Main_Scene.Player_1_WinCount + 1 == 4 && Timeattack <= 300)
                                {
                                    Achive.AC[17]++;

                                    //업적 19번째. 단, 힌트를 보지 않아야지 이것도 얻을 수 있다.
                                    if (Main_Scene.hintcount == 0)
                                        Achive.AC[18]++;
                                }
                            }
                        }
                    }
                }
            }
        }
    }

    void TypeSaid(int Typenumber)
    {
        Player_Typing.GetComponent<RectTransform>().transform.localScale = new Vector3(0.5f, 0.5f);

        if (Main_Scene.Language == 1)
        {
            Player_Typing.GetComponent<Image>().sprite = GameImage[Typenumber];

            if (Typenumber == 6)
                Player_Typing.GetComponent<RectTransform>().sizeDelta = new Vector3(438, 109);

            else if (Typenumber == 7)
                Player_Typing.GetComponent<RectTransform>().sizeDelta = new Vector3(533, 93);

            else if (Typenumber == 8)
                Player_Typing.GetComponent<RectTransform>().sizeDelta = new Vector3(551, 97);

            else if (Typenumber == 9)
                Player_Typing.GetComponent<RectTransform>().sizeDelta = new Vector3(481, 112);

            else if (Typenumber == 10)
                Player_Typing.GetComponent<RectTransform>().sizeDelta = new Vector3(245, 114);

            else if (Typenumber == 11)
                Player_Typing.GetComponent<RectTransform>().sizeDelta = new Vector3(319, 112);

            else if (Typenumber == 12)
                Player_Typing.GetComponent<RectTransform>().sizeDelta = new Vector3(410, 112);

            else if (Typenumber == 13)
                Player_Typing.GetComponent<RectTransform>().sizeDelta = new Vector3(378, 111);

            else if (Typenumber == 14)
                Player_Typing.GetComponent<RectTransform>().sizeDelta = new Vector3(478, 112);

            else if (Typenumber == 15)
                Player_Typing.GetComponent<RectTransform>().sizeDelta = new Vector3(526, 112);

            else if (Typenumber == 16)
                Player_Typing.GetComponent<RectTransform>().sizeDelta = new Vector3(245, 112);

            else if (Typenumber == 17)
                Player_Typing.GetComponent<RectTransform>().sizeDelta = new Vector3(213, 112);
        }

        else if (Main_Scene.Language == 2)
        {
            Player_Typing.GetComponent<Image>().sprite = GameImage[Typenumber+10];

            if (Typenumber == 6)
            {
                Player_Typing.GetComponent<Image>().sprite = GameImage[18];
                Player_Typing.GetComponent<RectTransform>().sizeDelta = new Vector3(442, 111);
            }

            else if (Typenumber == 7)
            {
                Player_Typing.GetComponent<Image>().sprite = GameImage[7];
                Player_Typing.GetComponent<RectTransform>().sizeDelta = new Vector3(533, 93);
            }

            else if (Typenumber == 8)
            {
                Player_Typing.GetComponent<Image>().sprite = GameImage[8];
                Player_Typing.GetComponent<RectTransform>().sizeDelta = new Vector3(551, 97);
            }

            else if (Typenumber == 9)
                Player_Typing.GetComponent<RectTransform>().sizeDelta = new Vector3(316, 107);

            else if (Typenumber == 10)
                Player_Typing.GetComponent<RectTransform>().sizeDelta = new Vector3(251, 101);

            else if (Typenumber == 11)
                Player_Typing.GetComponent<RectTransform>().sizeDelta = new Vector3(266, 102);

            else if (Typenumber == 12)
                Player_Typing.GetComponent<RectTransform>().sizeDelta = new Vector3(516, 101);

            else if (Typenumber == 13)
                Player_Typing.GetComponent<RectTransform>().sizeDelta = new Vector3(385, 100);

            else if (Typenumber == 14)
                Player_Typing.GetComponent<RectTransform>().sizeDelta = new Vector3(546, 102);

            else if (Typenumber == 15)
                Player_Typing.GetComponent<RectTransform>().sizeDelta = new Vector3(686*0.9f, 97*0.9f);

            else if (Typenumber == 16)
                Player_Typing.GetComponent<RectTransform>().sizeDelta = new Vector3(438, 106);

            else if (Typenumber == 17)
                Player_Typing.GetComponent<RectTransform>().sizeDelta = new Vector3(256, 100);
        }

        else if (Main_Scene.Language == 3)
        {
            Player_Typing.GetComponent<Image>().sprite = GameImage[Typenumber + 20];

            if (Typenumber == 6)
            {
                Player_Typing.GetComponent<Image>().sprite = GameImage[28];
                Player_Typing.GetComponent<RectTransform>().sizeDelta = new Vector3(407, 110);
            }

            else if (Typenumber == 7)
            {
                Player_Typing.GetComponent<Image>().sprite = GameImage[7];
                Player_Typing.GetComponent<RectTransform>().sizeDelta = new Vector3(533, 93);
            }

            else if (Typenumber == 8)
            {
                Player_Typing.GetComponent<Image>().sprite = GameImage[8];
                Player_Typing.GetComponent<RectTransform>().sizeDelta = new Vector3(551, 97);
            }

            else if (Typenumber == 9)
                Player_Typing.GetComponent<RectTransform>().sizeDelta = new Vector3(442, 106);

            else if (Typenumber == 10)
                Player_Typing.GetComponent<RectTransform>().sizeDelta = new Vector3(248, 107);

            else if (Typenumber == 11)
                Player_Typing.GetComponent<RectTransform>().sizeDelta = new Vector3(409, 108);

            else if (Typenumber == 12)
                Player_Typing.GetComponent<RectTransform>().sizeDelta = new Vector3(461, 110);

            else if (Typenumber == 13)
                Player_Typing.GetComponent<RectTransform>().sizeDelta = new Vector3(346, 108);

            else if (Typenumber == 14)
                Player_Typing.GetComponent<RectTransform>().sizeDelta = new Vector3(517, 111);

            else if (Typenumber == 15)
                Player_Typing.GetComponent<RectTransform>().sizeDelta = new Vector3(450, 109);

            else if (Typenumber == 16)
                Player_Typing.GetComponent<RectTransform>().sizeDelta = new Vector3(251, 110);

            else if (Typenumber == 17)
                Player_Typing.GetComponent<RectTransform>().sizeDelta = new Vector3(206, 110);
        }


    }

    void ButtonChange()
    {
        if (!Card.find)
        {
            if (Player == 1)
            {
                if (Main_Scene.Language == 1)
                {
                    button_h.GetComponent<Image>().sprite = but[2];
                    button_g.GetComponent<Image>().sprite = but[3];
                }

                else if (Main_Scene.Language == 2)
                {
                    button_h.GetComponent<Image>().sprite = but[34];
                    button_g.GetComponent<Image>().sprite = but[35];
                }

                else if (Main_Scene.Language == 3)
                {
                    button_h.GetComponent<Image>().sprite = but[44];
                    button_g.GetComponent<Image>().sprite = but[45];
                }

                First_Timer.GetComponent<Image>().sprite = but[5];
            }

            else
            {
                if (Main_Scene.Language == 1)
                {
                    button_h.GetComponent<Image>().sprite = but[0];
                    button_g.GetComponent<Image>().sprite = but[1];
                }

                else if (Main_Scene.Language == 2)
                {
                    button_h.GetComponent<Image>().sprite = but[32];
                    button_g.GetComponent<Image>().sprite = but[33];
                }

                else if (Main_Scene.Language == 3)
                {
                    button_h.GetComponent<Image>().sprite = but[42];
                    button_g.GetComponent<Image>().sprite = but[43];
                }

                First_Timer.GetComponent<Image>().sprite = but[4];
            }
        }

        else
        {
            if (Main_Scene.Language == 1)
            {
                button_h.GetComponent<Image>().sprite = but[1];
                button_g.GetComponent<Image>().sprite = but[3];
            }

            else if (Main_Scene.Language == 2)
            {
                button_h.GetComponent<Image>().sprite = but[33];
                button_g.GetComponent<Image>().sprite = but[35];
            }

            else if (Main_Scene.Language == 3)
            {
                button_h.GetComponent<Image>().sprite = but[43];
                button_g.GetComponent<Image>().sprite = but[45];
            }
        }
    }

    void ButtonOnePlayer()
    {
        if (Main_Scene.Language == 1)
        {
            button_h.GetComponent<Image>().sprite = but[0];
            button_g.GetComponent<Image>().sprite = but[1];
        }

        else if (Main_Scene.Language == 2)
        {
            button_h.GetComponent<Image>().sprite = but[32];
            button_g.GetComponent<Image>().sprite = but[33];
        }

        else if (Main_Scene.Language == 3)
        {
            button_h.GetComponent<Image>().sprite = but[42];
            button_g.GetComponent<Image>().sprite = but[43];
        }
    }
}
