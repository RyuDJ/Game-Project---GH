using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Challenge : MonoBehaviour {

    public static GameObject Fade, Challenges, WhatisChallengeMode, Introduce, Goback, Startit, Next, Back,
        TitleText, IntroduceText, IMG, Complete, Googleplay, Music, Achieve, Leader, Setting, Staring, Lang;
    public static int step = 0, step2 = 0, step3 = 0, Textit = 0;
    public static bool FadeIn = true;
    public static bool FadeOut = false;
    public static bool Startplayit = false;
    public static bool Ch = false;
    public static int Now = 0;
    public static int[] Challengemode = new int[9];
    public Sprite[] GameImage = new Sprite[9];
    public Sprite[] main_but;

    public static bool SettingOn = false;

    public void PlaceSetting()
    {
        MusicSource.SFXCHOOSE = true;
        MusicSource.SFX[1] = true;
        MusicSource.SE_volume = 0.25f;

        if (!SettingOn && !FadeIn && !FadeOut)
        {
            On();
        }

        else
        {
            Out();
        }
    }

    void On()
    {
        Fade.GetComponent<RectTransform>().localPosition = new Vector3(0, 0, 0);
        Fade.GetComponent<Image>().color = new Color(1, 1, 1, 0.8f);

        if (GooglePlayServiceManager.isGoogle)
            Googleplay.GetComponent<Image>().sprite = main_but[71];

        else
            Googleplay.GetComponent<Image>().sprite = main_but[70];

        Achieve.GetComponent<Image>().sprite = main_but[72];
        Leader.GetComponent<Image>().sprite = main_but[77];

        if (Main_Scene.isMusicOn)
            Music.GetComponent<Image>().sprite = main_but[76];

        else
            Music.GetComponent<Image>().sprite = main_but[73];

        Setting.GetComponent<Image>().sprite = main_but[75];

        Set_Lang();

        Googleplay.GetComponent<RectTransform>().localPosition = new Vector3(0, 150, 0);
        Achieve.GetComponent<RectTransform>().localPosition = new Vector3(-100, 0, 0);
        Leader.GetComponent<RectTransform>().localPosition = new Vector3(100, 0, 0);
        Music.GetComponent<RectTransform>().localPosition = new Vector3(0, -150, 0);
        Staring.GetComponent<RectTransform>().localPosition = new Vector3(-125, -255, 0);
        Lang.GetComponent<RectTransform>().localPosition = new Vector3(0, -255, 0);

        Googleplay.GetComponent<RectTransform>().sizeDelta = new Vector3(512, 512, 0);
        Achieve.GetComponent<RectTransform>().sizeDelta = new Vector3(512, 512, 0);
        Leader.GetComponent<RectTransform>().sizeDelta = new Vector3(512, 512, 0);
        Music.GetComponent<RectTransform>().sizeDelta = new Vector3(512, 512, 0);
        Lang.GetComponent<RectTransform>().sizeDelta = new Vector3(512, 512, 0);

        Googleplay.GetComponent<RectTransform>().localScale = new Vector3(0.3f, 0.3f, 0);
        Achieve.GetComponent<RectTransform>().localScale = new Vector3(0.3f, 0.3f, 0);
        Leader.GetComponent<RectTransform>().localScale = new Vector3(0.3f, 0.3f, 0);
        Music.GetComponent<RectTransform>().localScale = new Vector3(0.3f, 0.3f, 0);
        SettingOn = true;
    }

    void Out()
    {
        Fade.GetComponent<RectTransform>().localPosition = new Vector3(15300, 0, 0);
        Fade.GetComponent<Image>().color = new Color(0, 0, 0, 0);

        Googleplay.GetComponent<RectTransform>().localPosition = new Vector3(15300, 0, 0);
        Achieve.GetComponent<RectTransform>().localPosition = new Vector3(15300, 0, 0);
        Leader.GetComponent<RectTransform>().localPosition = new Vector3(15300, 0, 0);
        Music.GetComponent<RectTransform>().localPosition = new Vector3(15300, 0, 0);
        Staring.GetComponent<RectTransform>().localPosition = new Vector3(15300, 0, 0);
        Lang.GetComponent<RectTransform>().localPosition = new Vector3(15300, 0, 0);

        Setting.GetComponent<Image>().sprite = main_but[74];
        SettingOn = false;
    }

    void Set_Lang()
    {
        if (Main_Scene.Language == 1)
            Lang.GetComponent<Image>().sprite = main_but[122];

        else if (Main_Scene.Language == 2)
            Lang.GetComponent<Image>().sprite = main_but[123];

        else if (Main_Scene.Language == 3)
            Lang.GetComponent<Image>().sprite = main_but[124];
    }

    public void ChangeLang()
    {
        Main_Scene.Language++;

        if (Main_Scene.Language > 3)
            Main_Scene.Language = 1;

        Set_Lang();
    }

    public void GoStaring()
    {
        Application.OpenURL("https://play.google.com/store/apps/details?id=com.ehdwo365.GH&hl=ko&ah=2Pp1SfISDrQgvUPgCM7cZSbwSsQ");
    }

    public void Nextit()
    {
        if(step == 7)
        {
            MusicSource.SFXCHOOSE = true;
            MusicSource.SFX[0] = true;
            MusicSource.SE_volume = 0.6f;
            step = 8;
        }
    }

    public void Backit()
    {
        if(step == 7)
        {
            MusicSource.SFXCHOOSE = true;
            MusicSource.SFX[0] = true;
            MusicSource.SE_volume = 0.6f;
            step = 11;
        }
    }

    public void StartPlay()
    {
        if(Textit != 0)
        {
            MusicSource.SFXCHOOSE = true;
            MusicSource.SFX[0] = true;
            MusicSource.SE_volume = 0.6f;
            Ch = true;
            TextOfPlaySetting(Textit);
            Startplayit = true;
            FadeOut = true;
        }
    }

    public void Quitit()
    {
        MusicSource.SFXCHOOSE = true;
        MusicSource.SFX[1] = true;
        MusicSource.SE_volume = 0.25f;
        FadeOut = true;
    }

    void Awake()
    {
        Screen.SetResolution(Screen.width, Screen.width * 16 / 9, false);
    }

    // Use this for initialization
    void Start ()
    {
        main_but = new Sprite[128];
        main_but = Resources.LoadAll<Sprite>("Texture/Main"); //이미지를 부름

        GameImage = Resources.LoadAll<Sprite>("Texture/Challenge");

        Fade = GameObject.Find("Fade");
        Challenges = GameObject.Find("Challenge");
        WhatisChallengeMode = GameObject.Find("WhatisChallengeMode");
        Introduce = GameObject.Find("Introduce");
        Goback = GameObject.Find("Goback");
        Startit = GameObject.Find("Startit");
        Next = GameObject.Find("Next");
        Back = GameObject.Find("Back");
        TitleText = GameObject.Find("TitleText");
        IntroduceText = GameObject.Find("IntroduceText");
        IMG = GameObject.Find("Image2");
        Complete = GameObject.Find("Complete");
        Googleplay = GameObject.Find("Google Play");
        Achieve = GameObject.Find("Achievement");
        Leader = GameObject.Find("LeaderBoard");
        Music = GameObject.Find("Music");
        Setting = GameObject.Find("Setting");
        Staring = GameObject.Find("Staring");
        Lang = GameObject.Find("Lang");

        Fade.GetComponent<Image>().color = new Color(0, 0, 0, 1);

        Fade.GetComponent<RectTransform>().localPosition = new Vector3(0, 0, 0);
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Quitit();

        if (FadeIn)
        {
            if (step == 0)
            {
                Fade.GetComponent<RectTransform>().localPosition = new Vector3(0, 0, 0);
                Fade.GetComponent<Image>().color = new Color(0, 0, 0, 1);
                step = 1;
            }

            if (step == 1)
            {
                if (Fade.GetComponent<Image>().color.a <= 0)
                    step = 2;

                else
                    Fade.GetComponent<Image>().color = new Color(Fade.GetComponent<Image>().color.r, Fade.GetComponent<Image>().color.g, Fade.GetComponent<Image>().color.b, Fade.GetComponent<Image>().color.a - 0.03f);
            }

            if (step == 2)
            {
                Fade.GetComponent<RectTransform>().localPosition = new Vector3(500, 500, 0);
                FadeIn = false;
                step = 0;
            }
        }

        else
        {
            if(step == 0)
            {
                MusicSource.step = 0;
                MusicSource.Looptime = 16.062f;
                MusicSource.volume = 0.9f;
                Challenges.GetComponent<RectTransform>().localPosition = new Vector3(0, 230, 0);
                Challenges.GetComponent<Image>().color = new Color(Challenges.GetComponent<Image>().color.r, Challenges.GetComponent<Image>().color.g, Challenges.GetComponent<Image>().color.b, 0);
                Setting.GetComponent<RectTransform>().localPosition = new Vector3(125, -255);
                Setting.GetComponent<RectTransform>().sizeDelta = new Vector3(512, 512);
                Setting.GetComponent<RectTransform>().localScale = new Vector3(0.15f, 0.15f);
                Setting.GetComponent<Image>().sprite = main_but[74];
                Setting.GetComponent<Image>().color = new Color(Setting.GetComponent<Image>().color.r, Setting.GetComponent<Image>().color.g, Setting.GetComponent<Image>().color.b, 0);
                step = 1;
            }

            if(step == 1)
            {
                if (Challenges.GetComponent<Image>().color.a > 1)
                    step = 2;

                else
                    Challenges.GetComponent<Image>().color = new Color(Challenges.GetComponent<Image>().color.r, Challenges.GetComponent<Image>().color.g, Challenges.GetComponent<Image>().color.b, Challenges.GetComponent<Image>().color.a + 0.05f);
            }

            if(step == 2)
            {
                WhatisChallengeMode.GetComponent<RectTransform>().localPosition = new Vector3(-600, 130, 0);
                Introduce.GetComponent<RectTransform>().localPosition = new Vector3(600, -150, 0);
                Goback.GetComponent<RectTransform>().localPosition = new Vector3(-680, -255, 0);
                Startit.GetComponent<RectTransform>().localPosition = new Vector3(643, -255, 0);
                IMG.GetComponent<RectTransform>().localPosition = new Vector3(600, 0, 0);
                IMG.GetComponent<Image>().sprite = GameImage[9];
                step = 3;
            }

            if(step == 3)
            {
                if (WhatisChallengeMode.GetComponent<RectTransform>().localPosition.x == 0)
                    step = 4;
                
                else
                {
                    WhatisChallengeMode.GetComponent<RectTransform>().localPosition = new Vector3(WhatisChallengeMode.GetComponent<RectTransform>().localPosition.x + 50, 130, 0);
                    Introduce.GetComponent<RectTransform>().localPosition = new Vector3(Introduce.GetComponent<RectTransform>().localPosition.x - 50, -150, 0);
                    Goback.GetComponent<RectTransform>().localPosition = new Vector3(Goback.GetComponent<RectTransform>().localPosition.x + 50, -255, 0);
                    Startit.GetComponent<RectTransform>().localPosition = new Vector3(Startit.GetComponent<RectTransform>().localPosition.x - 50, -255, 0);
                    IMG.GetComponent<RectTransform>().localPosition = new Vector3(IMG.GetComponent<RectTransform>().localPosition.x - 50, 0, 0);
                    Setting.GetComponent<Image>().color = new Color(Setting.GetComponent<Image>().color.r, Setting.GetComponent<Image>().color.g, Setting.GetComponent<Image>().color.b, Setting.GetComponent<Image>().color.a + 0.1f);
                    Startit.GetComponent<Image>().color = new Color(Startit.GetComponent<Image>().color.r, Startit.GetComponent<Image>().color.g, Startit.GetComponent<Image>().color.b, 0.3f);
                }
            }

            if(step == 4)
            {
                Back.GetComponent<RectTransform>().localPosition = new Vector3(-130, 130, 0);
                Next.GetComponent<RectTransform>().localPosition = new Vector3(130, 130, 0);

                Back.GetComponent<Image>().color = new Color(Back.GetComponent<Image>().color.r, Back.GetComponent<Image>().color.g, Back.GetComponent<Image>().color.b, 0);
                Next.GetComponent<Image>().color = new Color(Next.GetComponent<Image>().color.r, Next.GetComponent<Image>().color.g, Next.GetComponent<Image>().color.b, 0);

                step = 5;
            }

            if(step == 5)
            {
                if(Back.GetComponent<Image>().color.a > 1)
                {
                    step = 6;
                }

                else
                {
                    Back.GetComponent<Image>().color = new Color(Back.GetComponent<Image>().color.r, Back.GetComponent<Image>().color.g, Back.GetComponent<Image>().color.b, Back.GetComponent<Image>().color.a + 0.05f);
                    Next.GetComponent<Image>().color = new Color(Next.GetComponent<Image>().color.r, Next.GetComponent<Image>().color.g, Next.GetComponent<Image>().color.b, Next.GetComponent<Image>().color.a + 0.05f);
                    Challenges.GetComponent<Image>().color = new Color(Challenges.GetComponent<Image>().color.r, Challenges.GetComponent<Image>().color.g, Challenges.GetComponent<Image>().color.b, Challenges.GetComponent<Image>().color.a + 0.05f);
                }
            }

            if(step == 6)
            {
                TitleText.GetComponent<RectTransform>().localPosition = new Vector3(0, 130, 0);
                IntroduceText.GetComponent<RectTransform>().localPosition = new Vector3(0, -150, 0);

                if (Main_Scene.Language == 1)
                {
                    TitleText.GetComponent<Text>().text = "챌린지 모드에 대해서";
                    IntroduceText.GetComponent<Text>().text = "챌린지 모드에 어서오세요!\n\n이 곳은 기존모드들을\n응용하여 어렵게 만든 것들을\n한 데 모아둔 곳입니다.\n도전해서 업적을 달성해보세요!";
                }

                else if (Main_Scene.Language == 2)
                {
                    TitleText.GetComponent<Text>().text = "Challenge Mode?";
                    IntroduceText.GetComponent<Text>().text = "Welcome!\n\nThis is the special place where we twisted the existing modes.\n\nDo challenge!\n And Success them!";
                }

                else if (Main_Scene.Language == 3)
                {
                    TitleText.GetComponent<Text>().text = "チャレンジについて";
                    IntroduceText.GetComponent<Text>().text = "ようこそ! チャレンジモードへ!\n\nここはあるモード達をまた更に応用したり変更したりした特別な空間でございますぞ!\n\n挑戦して自分の能力を試してみてね!";
                }
                
                step = 7;
            }

            //세팅
            if(step == 7)
            {
                if (Main_Scene.Language == 1)
                {
                    TitleText.GetComponent<Text>().text = "챌린지 모드에 대해서";
                    IntroduceText.GetComponent<Text>().text = "챌린지 모드에 어서오세요!\n\n이 곳은 기존모드들을\n응용하여 어렵게 만든 것들을\n한 데 모아둔 곳입니다.\n도전해서 업적을 달성해보세요!";
                }

                else if (Main_Scene.Language == 2)
                {
                    TitleText.GetComponent<Text>().text = "Challenge Mode?";
                    IntroduceText.GetComponent<Text>().text = "Welcome!\n\nHere is the special place where we twisted the existing modes.\n\nDo challenge! And Success them!";
                }

                else if (Main_Scene.Language == 3)
                {
                    TitleText.GetComponent<Text>().text = "チャレンジについて";
                    IntroduceText.GetComponent<Text>().text = "ようこそ! チャレンジモードへ!\n\nここはあるモード達をまた更に応用したり変更したりした特別な空間でございますぞ!\n\n挑戦して自分の能力を試してみてね!";
                }

                TextMessage(Textit);
                TextInroduce(Textit);
                CompleteImg(Textit);
            }

            if(step == 8)
            {
                if (TitleText.GetComponent<RectTransform>().localPosition.x < -250f)
                {
                    Startit.GetComponent<Image>().color = new Color(Startit.GetComponent<Image>().color.r, Startit.GetComponent<Image>().color.g, Startit.GetComponent<Image>().color.b, 1f);
                    step = 9;
                    Textit++;

                    if (Textit > 9)
                        Textit = 1;
                }

                else
                {
                    Complete.GetComponent<RectTransform>().localPosition = new Vector3(500, 500, 0);
                    TitleText.GetComponent<RectTransform>().localPosition = new Vector3(TitleText.GetComponent<RectTransform>().localPosition.x - 10, 130, 0);
                    IMG.GetComponent<RectTransform>().localPosition = new Vector3(IMG.GetComponent<RectTransform>().localPosition.x - 10, 0, 0);
                }
            }

            if(step == 9)
            {
                TitleText.GetComponent<RectTransform>().localPosition = new Vector3(250, 130, 0);
                IMG.GetComponent<RectTransform>().localPosition = new Vector3(250, 0, 0);
                step = 10;
            }

            if(step == 10)
            {
                if (TitleText.GetComponent<RectTransform>().localPosition.x <= 0)
                    step = 7;

                else
                {
                    TitleText.GetComponent<RectTransform>().localPosition = new Vector3(TitleText.GetComponent<RectTransform>().localPosition.x - 10, 130, 0);
                    IMG.GetComponent<RectTransform>().localPosition = new Vector3(IMG.GetComponent<RectTransform>().localPosition.x - 10, 0, 0);
                }
            }

            if (step == 11)
            {
                Startit.GetComponent<Image>().color = new Color(Startit.GetComponent<Image>().color.r, Startit.GetComponent<Image>().color.g, Startit.GetComponent<Image>().color.b, 1f);

                if (TitleText.GetComponent<RectTransform>().localPosition.x > 250f)
                {
                    step = 12;
                    Textit--;

                    if (Textit < 1)
                        Textit = 9;
                }

                else
                {
                    Complete.GetComponent<RectTransform>().localPosition = new Vector3(500, 500, 0);
                    TitleText.GetComponent<RectTransform>().localPosition = new Vector3(TitleText.GetComponent<RectTransform>().localPosition.x + 10, 130, 0);
                    IMG.GetComponent<RectTransform>().localPosition = new Vector3(IMG.GetComponent<RectTransform>().localPosition.x + 10, 0, 0);
                }
            }

            if (step == 12)
            {
                TitleText.GetComponent<RectTransform>().localPosition = new Vector3(-250, 130, 0);
                IMG.GetComponent<RectTransform>().localPosition = new Vector3(-250, 0, 0);
                step = 13;
            }

            if (step == 13)
            {
                if (TitleText.GetComponent<RectTransform>().localPosition.x >= 0)
                    step = 7;

                else
                {
                    TitleText.GetComponent<RectTransform>().localPosition = new Vector3(TitleText.GetComponent<RectTransform>().localPosition.x + 10, 130, 0);
                    IMG.GetComponent<RectTransform>().localPosition = new Vector3(IMG.GetComponent<RectTransform>().localPosition.x + 10, 0, 0);
                }
            }
        }

        if (FadeOut)
        {
            if (step2 == 0)
            {
                Fade.GetComponent<RectTransform>().localPosition = new Vector3(0, 0, 0);
                Fade.GetComponent<Image>().color = new Color(0, 0, 0, 0);
                step2 = 1;
            }

            if (step2 == 1)
            {
                if (Fade.GetComponent<Image>().color.a > 1)
                    step2 = 2;

                else
                {
                    Setting.GetComponent<Image>().color = new Color(Setting.GetComponent<Image>().color.r, Setting.GetComponent<Image>().color.g, Setting.GetComponent<Image>().color.b, Setting.GetComponent<Image>().color.a - 0.03f);
                    Fade.GetComponent<Image>().color = new Color(Fade.GetComponent<Image>().color.r, Fade.GetComponent<Image>().color.g, Fade.GetComponent<Image>().color.b, Fade.GetComponent<Image>().color.a + 0.03f);
                    MusicSource.volume -= 0.03f;
                }
            }

            if (step2 == 2)
            {
                step = 0;
                step2 = 3;
                step3 = 0;
                FadeOut = false;
                FadeIn = false;

                Textit = 0;

                Fade.GetComponent<RectTransform>().localPosition = new Vector3(0, 0, 0);
                Challenges.GetComponent<RectTransform>().localPosition = new Vector3(500, 500, 0);
                WhatisChallengeMode.GetComponent<RectTransform>().localPosition = new Vector3(500, 500, 0);
                Introduce.GetComponent<RectTransform>().localPosition = new Vector3(500, 500, 0);
                Goback.GetComponent<RectTransform>().localPosition = new Vector3(500, 500, 0);
                Startit.GetComponent<RectTransform>().localPosition = new Vector3(500, 500, 0);
                Back.GetComponent<RectTransform>().localPosition = new Vector3(500, 500, 0);
                Next.GetComponent<RectTransform>().localPosition = new Vector3(500, 500, 0);
                Challenges.GetComponent<RectTransform>().localPosition = new Vector3(500, 500, 0);
                IMG.GetComponent<RectTransform>().localPosition = new Vector3(500, 500, 0);
                Complete.GetComponent<RectTransform>().localPosition = new Vector3(500, 500, 0);
                IMG.GetComponent<Image>().color = new Color(IMG.GetComponent<Image>().color.r, IMG.GetComponent<Image>().color.g, IMG.GetComponent<Image>().color.b, 1);
            }

            if (step2 == 3)
            {
                step2 = 0;
                FadeIn = true;

                if (!Startplayit)
                    SceneManager.LoadScene("Main Scene");

                else
                    SceneManager.LoadScene("Game Scene");
            }
        }

        else
        {
            if (step3 == 0)
            {
                if (IMG.GetComponent<Image>().color.a < 0.5f)
                    step3 = 1;

                else
                    IMG.GetComponent<Image>().color = new Color(IMG.GetComponent<Image>().color.r, IMG.GetComponent<Image>().color.g, IMG.GetComponent<Image>().color.b, IMG.GetComponent<Image>().color.a - 0.001f);
            }

            if (step3 == 1)
            {
                if (IMG.GetComponent<Image>().color.a > 1)
                    step3 = 0;

                else
                    IMG.GetComponent<Image>().color = new Color(IMG.GetComponent<Image>().color.r, IMG.GetComponent<Image>().color.g, IMG.GetComponent<Image>().color.b, IMG.GetComponent<Image>().color.a + 0.001f);
            }
        }

        if (Main_Scene.Language == 1)
        {
            Challenges.GetComponent<Image>().sprite = main_but[69];
            Goback.GetComponent<Image>().sprite = main_but[12];
            Startit.GetComponent<Image>().sprite = main_but[13];
        }

        else if (Main_Scene.Language == 2)
        {
            Challenges.GetComponent<Image>().sprite = main_but[125];
            Goback.GetComponent<Image>().sprite = main_but[95];
            Startit.GetComponent<Image>().sprite = main_but[96];

        }

        else if (Main_Scene.Language == 3)
        {
            Challenges.GetComponent<Image>().sprite = main_but[126];
            Goback.GetComponent<Image>().sprite = main_but[114];
            Startit.GetComponent<Image>().sprite = main_but[115];
        }
    }

    void TextMessage(int Textit)
    {
        if (Main_Scene.Language == 1)
        {
            if (Textit == 1)
                TitleText.GetComponent<Text>().text = "시간이 촉박해";

            if (Textit == 2)
                TitleText.GetComponent<Text>().text = "단순함의 극치";

            if (Textit == 3)
                TitleText.GetComponent<Text>().text = "기억력 게임";

            if (Textit == 4)
                TitleText.GetComponent<Text>().text = "그만 좀 뒤집어";

            if (Textit == 5)
                TitleText.GetComponent<Text>().text = "지진이 일어났나봐";

            if (Textit == 6)
                TitleText.GetComponent<Text>().text = "암전";

            if (Textit == 7)
                TitleText.GetComponent<Text>().text = "무대 위에서";

            if (Textit == 8)
                TitleText.GetComponent<Text>().text = "더 찾고 싶었단 말이야";

            if (Textit == 9)
                TitleText.GetComponent<Text>().text = "도전! 올라운드";
        }

        else if (Main_Scene.Language == 2)
        {
            if (Textit == 1)
                TitleText.GetComponent<Text>().text = "I'm Busy!";

            if (Textit == 2)
                TitleText.GetComponent<Text>().text = "Simple is Best";

            if (Textit == 3)
                TitleText.GetComponent<Text>().text = "Memory Game";

            if (Textit == 4)
                TitleText.GetComponent<Text>().text = "Stop Changing it!";

            if (Textit == 5)
                TitleText.GetComponent<Text>().text = "EARTHQUAKE";

            if (Textit == 6)
                TitleText.GetComponent<Text>().text = "The Switch";

            if (Textit == 7)
                TitleText.GetComponent<Text>().text = "On the Stage";

            if (Textit == 8)
                TitleText.GetComponent<Text>().text = "I want more!";

            if (Textit == 9)
                TitleText.GetComponent<Text>().text = "All Round";
        }

        else if (Main_Scene.Language == 3)
        {
            if (Textit == 1)
                TitleText.GetComponent<Text>().text = "時間がヤバすぎ";

            if (Textit == 2)
                TitleText.GetComponent<Text>().text = "単純なカード";

            if (Textit == 3)
                TitleText.GetComponent<Text>().text = "記憶力ゲーム";

            if (Textit == 4)
                TitleText.GetComponent<Text>().text = "いい加減にしてよ";

            if (Textit == 5)
                TitleText.GetComponent<Text>().text = "地震の中で";

            if (Textit == 6)
                TitleText.GetComponent<Text>().text = "暗転";

            if (Textit == 7)
                TitleText.GetComponent<Text>().text = "舞台の上で";

            if (Textit == 8)
                TitleText.GetComponent<Text>().text = "もっと探したかった";

            if (Textit == 9)
                TitleText.GetComponent<Text>().text = "挑戦！オールラウンド";
        }
    }

    void TextInroduce(int Textit)
    {
        IMG.GetComponent<Image>().sprite = GameImage[Textit];

        if (Main_Scene.Language == 1)
        {
            if (Textit == 1)
                IntroduceText.GetComponent<Text>().text = "1분은 너무 많다고요?\n그런 당신을 위해서 시간제한을\n30초로 줄였습니다!\n\n30초 안에 일반모드에서\n'결'을 외치는 것을 성공해보세요!";

            if (Textit == 2)
                IntroduceText.GetComponent<Text>().text = "이토록 단순한 카드배치가\n있을 수 있을까요?\n합을 찾는 즐거움을 느껴보세요!\n\n40초 안에 일반모드에서\n'결'을 외치는 것을 성공해보세요!";

            if (Textit == 3)
                IntroduceText.GetComponent<Text>().text = "카드들이 더 많이 가려집니다!\n초반에 최대한 외워서 들어가지 않으면\n포기를 하게 되어버린다구요!\n\n1분 10초 안에 가림막모드에서\n'결'을 외치는 것을 성공해보세요!";

            if (Textit == 4)
                IntroduceText.GetComponent<Text>().text = "5초마다 가림막이 바뀌는 걸\n기다리는 게 지루하신가요?\n그렇다면 계속 바뀌는 건 어떠신가요?\n\n50초 안에 가림막모드에서\n'결'을 외치는 것을 성공해보세요!";

            if (Textit == 5)
                IntroduceText.GetComponent<Text>().text = "지진이라도 일어난 걸까요?\n전등이 더 빨리 움직입니다!\n카드를 제대로 볼 수 있을까요?\n\n1분 안에 전등모드에서\n'결'을 외치는 것을 성공해보세요!";

            if (Textit == 6)
                IntroduceText.GetComponent<Text>().text = "움직이는 전등이 야속하신 여러분을 위해서\n다른 전등으로 한 번 바꿔보았습니다!\n만족스러우셨으면 좋겠네요!\n\n1분 15초 안에 전등모드에서\n'결'을 외치는 것을 성공해보세요!";

            if (Textit == 7)
                IntroduceText.GetComponent<Text>().text = "무대조명으로 플레이해보세요!\n움직이는 조명 아래에서 합을 찾아보세요!\n그래도 조명담당을 때리진 마세요!\n\n1분 15초 안에 전등모드에서\n'결'을 외치는 것을 성공해보세요!";

            if (Textit == 8)
                IntroduceText.GetComponent<Text>().text = "4×4모드에서 합의 개수를\n15개로 제한을 둬서 미안해요!\n그래서 제한을 20개로 늘려보았어요!\n\n2분 안에 4×4모드를\n'클리어'해보세요!";

            if (Textit == 9)
                IntroduceText.GetComponent<Text>().text = "기존의 모드들이 총 출동합니다!\n\n12분 안에 8 스테이지\n모두를 클리어해보세요!\n시간배분을 잘하셔야합니다!\n(10분 이상의 분은 X로 표시됩니다)";
        }

        else if (Main_Scene.Language == 2)
        {
            if (Textit == 1)
                IntroduceText.GetComponent<Text>().text = "Is there too much time to succeed in this game even a minute?\nIf so, How about 30 seconds?\n\nMake Succeed in 30 seconds!";

            if (Textit == 2)
                IntroduceText.GetComponent<Text>().text = "What the simplest card are they!\nPlease enjoy finding 'Find!'\n\nMake Succeed in 40 seconds!";

            if (Textit == 3)
                IntroduceText.GetComponent<Text>().text = "More cards are hidden!\nIf you don't memorize as much as you can in the beginning, I'm sure that you'll give up soon!\n\nMake Succeed in 70 seconds!";

            if (Textit == 4)
                IntroduceText.GetComponent<Text>().text = "It's too bored to wait for the card's state changing, isn't it?\nSo, Let's changing it faster, Shall we?\n\nMake Succeed in 50 seconds!";

            if (Textit == 5)
                IntroduceText.GetComponent<Text>().text = "OMG! EARTHQUAKE?!\nThe Light moves faster than usual!\nDon't be dazzled!\n\nMake Succeed in 60 seconds!";

            if (Textit == 6)
                IntroduceText.GetComponent<Text>().text = "I'm sure someone doesn't \nlike that standard light,\nSo I decieded to change the light!\nI hope you like it!\n\nMake Succeed in 75 seconds!";

            if (Textit == 7)
                IntroduceText.GetComponent<Text>().text = "Play with stage lighting!\n\nFind the 'Find' in the moving light!\nBut don't blame it...\n\nMake Succeed in 75 seconds!";

            if (Textit == 8)
                IntroduceText.GetComponent<Text>().text = "Sorry to limit the number of\n'Find' to 15 in 4×4 mode..\nSo, I tried increasing\nthe limit to 20!\n\nMake Succeed in 120 seconds!";

            if (Textit == 9)
                IntroduceText.GetComponent<Text>().text = "All modes come out in succession!\n\n Make Succeed All 8 stage\nin 12 minutes!\n\n(Minutes of the X is more than 10)";
        }

        else if (Main_Scene.Language == 3)
        {
            if (Textit == 1)
                IntroduceText.GetComponent<Text>().text = "１分は充分すぎますか?\nそんなあなたのために\n時間を30秒に減らしました\n\n30秒以内に成功してください!";

            if (Textit == 2)
                IntroduceText.GetComponent<Text>().text = "とても単純なカード達なんですね!\n\n合を探す楽しみを感じてください!\n\n40秒以内に成功してください!";

            if (Textit == 3)
                IntroduceText.GetComponent<Text>().text = "カードがもっと隠されます!\n序盤にできるだけのカードを覚えなければ\n直ぐ諦めちゃいますよ?\n\n70秒以内に成功してください!";

            if (Textit == 4)
                IntroduceText.GetComponent<Text>().text = "隠しモードのカードの形が変わるのを\n待つのが退屈ですか?\nだったらもっと早くカードを変えましょう!\n\n50秒以内に成功してください!";

            if (Textit == 5)
                IntroduceText.GetComponent<Text>().text = "地震でも起きたのでしょうか?\nライトがもっと早く動きます!\nちゃんとカードを見るのができるかな?\n\n1分以内に成功してください!";

            if (Textit == 6)
                IntroduceText.GetComponent<Text>().text = "電灯が動くのが気に入らない人達のために\n他の電灯で代わりましょう!\n満足したら嬉しいです!\n\n75秒以内に成功してください!";

            if (Textit == 7)
                IntroduceText.GetComponent<Text>().text = "舞台照明はどうですか?\nライトの中で合を探しましょう!\nでも照明担当を憎まないでください…\n\n75秒以内に成功してください!";

            if (Textit == 8)
                IntroduceText.GetComponent<Text>().text = "4×4モードの合の数を\n15個に制限しておいてごめんなさい…\nだから制限を20個に増やしてみました!\n\n2分以内に成功してください!";

            if (Textit == 9)
                IntroduceText.GetComponent<Text>().text = "全てのモードが現れます!\n\n12分以内に全8のステージを\n成功してください!\n(十分以上はXで書きます)";
        }
    }

    void CompleteImg(int Textit)
    {
        if (PlayerPrefs.GetInt("Complete"+(Textit-1)) == 1)
        {
            Complete.GetComponent<RectTransform>().localPosition = new Vector3(50, 50, 0);
        }

        else
        {
            Complete.GetComponent<RectTransform>().localPosition = new Vector3(500, 500, 0);
        }
    }

    void TextOfPlaySetting(int Textit)
    {
        if (Textit == 1) //30초 플레이
        {
            Main_Scene.Player1Mode = true; //1인모드 실행
            Main_Scene.TimeAttack = true; //타임어택모드 실행
            Main_Scene.time = 30; //30초로 제한
            Main_Scene.Last_Stage = 1;

            bool isSame = false;

            //선택되지 않은 나머지에서 중복이 되지 않게 선택한다.
            for (int i = Main_Scene.card_number; i < 4; i++)
            {
                while (true) // 중복되는 지 확인이 될 때까지 하므로 while을 써서 반복한다.
                {
                    Main_Scene.Selected_card[i] = Random.Range(0, 8); // 0에서 7 중에서 1개를 골라 해당 배열에 넣는다.
                    isSame = false; // 기본은 false값으로 주어진다.

                    for (int j = 0; j < i; j++) // 중복을 확인합니다.
                    {
                        if (Main_Scene.Selected_card[j] == Main_Scene.Selected_card[i])
                        {
                            isSame = true; // 중복일 경우 해당 명제는 참으로 계산된다.
                            break; // 중복일 경우엔 다시 for(j)문을 확인할 필요가 없기 때문에 탈출한다.
                        }

                        //만약 true 값이 나오지 않았다면 이대로 유지될 것이다.
                    }

                    if (!isSame)
                    {
                        break; // 만약에 isSame = 1이 아니라면(false) 중복이 없단 의미이므로 탈출한다.
                    }
                }
            }

            //선택되지 않은 나머지에서 중복이 되지 않게 선택한다.
            for (int i = Main_Scene.card_color; i < 3; i++)
            {
                while (true) // 중복되는 지 확인이 될 때까지 하므로 while을 써서 반복한다.
                {
                    Main_Scene.Selected_card_color[i] = Random.Range(0, 7); // 0에서 6 중에서 1개를 골라 해당 배열에 넣는다.
                    isSame = false; // 기본은 false값으로 주어진다.

                    for (int j = 0; j < i; j++) // 중복을 확인합니다.
                    {
                        if (Main_Scene.Selected_card_color[j] == Main_Scene.Selected_card_color[i])
                        {
                            isSame = true; // 중복일 경우 해당 명제는 참으로 계산된다.
                            break; // 중복일 경우엔 다시 for(j)문을 확인할 필요가 없기 때문에 탈출한다.
                        }

                        //만약 true 값이 나오지 않았다면 이대로 유지될 것이다.
                    }

                    if (!isSame)
                    {
                        break; // 만약에 isSame = 1이 아니라면(false) 중복이 없단 의미이므로 탈출한다.
                    }
                }
            }
        }

        if (Textit == 2) //단순함 플레이
        {
            Main_Scene.Player1Mode = true; //1인모드 실행
            Main_Scene.TimeAttack = true; //타임어택모드 실행
            Main_Scene.time = 40; //40초로 제한
            Main_Scene.Last_Stage = 1;

            bool isSame = false;

            //선택되지 않은 나머지에서 중복이 되지 않게 선택한다.
            for (int i = Main_Scene.card_number; i < 4; i++)
            {
                Main_Scene.Selected_card[i] = 0;
            }

            //선택되지 않은 나머지에서 중복이 되지 않게 선택한다.
            for (int i = Main_Scene.card_color; i < 3; i++)
            {
                while (true) // 중복되는 지 확인이 될 때까지 하므로 while을 써서 반복한다.
                {
                    Main_Scene.Selected_card_color[i] = Random.Range(0, 7); // 0에서 6 중에서 1개를 골라 해당 배열에 넣는다.
                    isSame = false; // 기본은 false값으로 주어진다.

                    for (int j = 0; j < i; j++) // 중복을 확인합니다.
                    {
                        if (Main_Scene.Selected_card_color[j] == Main_Scene.Selected_card_color[i])
                        {
                            isSame = true; // 중복일 경우 해당 명제는 참으로 계산된다.
                            break; // 중복일 경우엔 다시 for(j)문을 확인할 필요가 없기 때문에 탈출한다.
                        }

                        //만약 true 값이 나오지 않았다면 이대로 유지될 것이다.
                    }

                    if (!isSame)
                    {
                        break; // 만약에 isSame = 1이 아니라면(false) 중복이 없단 의미이므로 탈출한다.
                    }
                }
            }
        }

        if (Textit == 3) //가림막 플레이
        {
            Main_Scene.Player1Mode = true; //1인모드 실행
            Main_Scene.TimeAttack = true; //타임어택모드 실행
            Main_Scene.time = 70; //1분 10초로 제한
            Main_Scene.Last_Stage = 1;

            bool isSame = false;

            //선택되지 않은 나머지에서 중복이 되지 않게 선택한다.
            for (int i = Main_Scene.card_number; i < 4; i++)
            {
                while (true) // 중복되는 지 확인이 될 때까지 하므로 while을 써서 반복한다.
                {
                    Main_Scene.Selected_card[i] = Random.Range(0, 8); // 0에서 7 중에서 1개를 골라 해당 배열에 넣는다.
                    isSame = false; // 기본은 false값으로 주어진다.

                    for (int j = 0; j < i; j++) // 중복을 확인합니다.
                    {
                        if (Main_Scene.Selected_card[j] == Main_Scene.Selected_card[i])
                        {
                            isSame = true; // 중복일 경우 해당 명제는 참으로 계산된다.
                            break; // 중복일 경우엔 다시 for(j)문을 확인할 필요가 없기 때문에 탈출한다.
                        }

                        //만약 true 값이 나오지 않았다면 이대로 유지될 것이다.
                    }

                    if (!isSame)
                    {
                        break; // 만약에 isSame = 1이 아니라면(false) 중복이 없단 의미이므로 탈출한다.
                    }
                }
            }

            //선택되지 않은 나머지에서 중복이 되지 않게 선택한다.
            for (int i = Main_Scene.card_color; i < 3; i++)
            {
                while (true) // 중복되는 지 확인이 될 때까지 하므로 while을 써서 반복한다.
                {
                    Main_Scene.Selected_card_color[i] = Random.Range(0, 7); // 0에서 6 중에서 1개를 골라 해당 배열에 넣는다.
                    isSame = false; // 기본은 false값으로 주어진다.

                    for (int j = 0; j < i; j++) // 중복을 확인합니다.
                    {
                        if (Main_Scene.Selected_card_color[j] == Main_Scene.Selected_card_color[i])
                        {
                            isSame = true; // 중복일 경우 해당 명제는 참으로 계산된다.
                            break; // 중복일 경우엔 다시 for(j)문을 확인할 필요가 없기 때문에 탈출한다.
                        }

                        //만약 true 값이 나오지 않았다면 이대로 유지될 것이다.
                    }

                    if (!isSame)
                    {
                        break; // 만약에 isSame = 1이 아니라면(false) 중복이 없단 의미이므로 탈출한다.
                    }
                }
            }

            //가림막모드만 켬
            for(int i = 0; i < 5; i++)
            {
                if(i == 0)
                    Main_Scene.Selected_stage[i] = 1;

                else
                    Main_Scene.Selected_stage[i] = 0;
            }
        }

        if (Textit == 4) //가림막 플레이
        {
            Main_Scene.Player1Mode = true; //1인모드 실행
            Main_Scene.TimeAttack = true; //타임어택모드 실행
            Main_Scene.time = 50; //50초로 제한
            Main_Scene.Last_Stage = 1;

            bool isSame = false;

            //선택되지 않은 나머지에서 중복이 되지 않게 선택한다.
            for (int i = Main_Scene.card_number; i < 4; i++)
            {
                while (true) // 중복되는 지 확인이 될 때까지 하므로 while을 써서 반복한다.
                {
                    Main_Scene.Selected_card[i] = Random.Range(0, 8); // 0에서 7 중에서 1개를 골라 해당 배열에 넣는다.
                    isSame = false; // 기본은 false값으로 주어진다.

                    for (int j = 0; j < i; j++) // 중복을 확인합니다.
                    {
                        if (Main_Scene.Selected_card[j] == Main_Scene.Selected_card[i])
                        {
                            isSame = true; // 중복일 경우 해당 명제는 참으로 계산된다.
                            break; // 중복일 경우엔 다시 for(j)문을 확인할 필요가 없기 때문에 탈출한다.
                        }

                        //만약 true 값이 나오지 않았다면 이대로 유지될 것이다.
                    }

                    if (!isSame)
                    {
                        break; // 만약에 isSame = 1이 아니라면(false) 중복이 없단 의미이므로 탈출한다.
                    }
                }
            }

            //선택되지 않은 나머지에서 중복이 되지 않게 선택한다.
            for (int i = Main_Scene.card_color; i < 3; i++)
            {
                while (true) // 중복되는 지 확인이 될 때까지 하므로 while을 써서 반복한다.
                {
                    Main_Scene.Selected_card_color[i] = Random.Range(0, 7); // 0에서 6 중에서 1개를 골라 해당 배열에 넣는다.
                    isSame = false; // 기본은 false값으로 주어진다.

                    for (int j = 0; j < i; j++) // 중복을 확인합니다.
                    {
                        if (Main_Scene.Selected_card_color[j] == Main_Scene.Selected_card_color[i])
                        {
                            isSame = true; // 중복일 경우 해당 명제는 참으로 계산된다.
                            break; // 중복일 경우엔 다시 for(j)문을 확인할 필요가 없기 때문에 탈출한다.
                        }

                        //만약 true 값이 나오지 않았다면 이대로 유지될 것이다.
                    }

                    if (!isSame)
                    {
                        break; // 만약에 isSame = 1이 아니라면(false) 중복이 없단 의미이므로 탈출한다.
                    }
                }
            }

            //가림막모드만 켬
            for (int i = 0; i < 5; i++)
            {
                if (i == 0)
                    Main_Scene.Selected_stage[i] = 1;

                else
                    Main_Scene.Selected_stage[i] = 0;
            }
        }

        if (Textit == 5) //전등 플레이
        {
            Main_Scene.Player1Mode = true; //1인모드 실행
            Main_Scene.TimeAttack = true; //타임어택모드 실행
            Main_Scene.time = 60; //1분 제한
            Main_Scene.Last_Stage = 1;

            bool isSame = false;

            //선택되지 않은 나머지에서 중복이 되지 않게 선택한다.
            for (int i = Main_Scene.card_number; i < 4; i++)
            {
                while (true) // 중복되는 지 확인이 될 때까지 하므로 while을 써서 반복한다.
                {
                    Main_Scene.Selected_card[i] = Random.Range(0, 8); // 0에서 7 중에서 1개를 골라 해당 배열에 넣는다.
                    isSame = false; // 기본은 false값으로 주어진다.

                    for (int j = 0; j < i; j++) // 중복을 확인합니다.
                    {
                        if (Main_Scene.Selected_card[j] == Main_Scene.Selected_card[i])
                        {
                            isSame = true; // 중복일 경우 해당 명제는 참으로 계산된다.
                            break; // 중복일 경우엔 다시 for(j)문을 확인할 필요가 없기 때문에 탈출한다.
                        }

                        //만약 true 값이 나오지 않았다면 이대로 유지될 것이다.
                    }

                    if (!isSame)
                    {
                        break; // 만약에 isSame = 1이 아니라면(false) 중복이 없단 의미이므로 탈출한다.
                    }
                }
            }

            //선택되지 않은 나머지에서 중복이 되지 않게 선택한다.
            for (int i = Main_Scene.card_color; i < 3; i++)
            {
                while (true) // 중복되는 지 확인이 될 때까지 하므로 while을 써서 반복한다.
                {
                    Main_Scene.Selected_card_color[i] = Random.Range(0, 7); // 0에서 6 중에서 1개를 골라 해당 배열에 넣는다.
                    isSame = false; // 기본은 false값으로 주어진다.

                    for (int j = 0; j < i; j++) // 중복을 확인합니다.
                    {
                        if (Main_Scene.Selected_card_color[j] == Main_Scene.Selected_card_color[i])
                        {
                            isSame = true; // 중복일 경우 해당 명제는 참으로 계산된다.
                            break; // 중복일 경우엔 다시 for(j)문을 확인할 필요가 없기 때문에 탈출한다.
                        }

                        //만약 true 값이 나오지 않았다면 이대로 유지될 것이다.
                    }

                    if (!isSame)
                    {
                        break; // 만약에 isSame = 1이 아니라면(false) 중복이 없단 의미이므로 탈출한다.
                    }
                }
            }

            //전등모드가 켬
            for (int i = 0; i < 5; i++)
            {
                if (i == 1)
                    Main_Scene.Selected_stage[i] = 1;

                else
                    Main_Scene.Selected_stage[i] = 0;
            }
        }

        if (Textit == 6) //암전 플레이
        {
            Main_Scene.Player1Mode = true; //1인모드 실행
            Main_Scene.TimeAttack = true; //타임어택모드 실행
            Main_Scene.time = 75; //1분 15초로 제한
            Main_Scene.Last_Stage = 1;

            bool isSame = false;

            //선택되지 않은 나머지에서 중복이 되지 않게 선택한다.
            for (int i = Main_Scene.card_number; i < 4; i++)
            {
                while (true) // 중복되는 지 확인이 될 때까지 하므로 while을 써서 반복한다.
                {
                    Main_Scene.Selected_card[i] = Random.Range(0, 8); // 0에서 7 중에서 1개를 골라 해당 배열에 넣는다.
                    isSame = false; // 기본은 false값으로 주어진다.

                    for (int j = 0; j < i; j++) // 중복을 확인합니다.
                    {
                        if (Main_Scene.Selected_card[j] == Main_Scene.Selected_card[i])
                        {
                            isSame = true; // 중복일 경우 해당 명제는 참으로 계산된다.
                            break; // 중복일 경우엔 다시 for(j)문을 확인할 필요가 없기 때문에 탈출한다.
                        }

                        //만약 true 값이 나오지 않았다면 이대로 유지될 것이다.
                    }

                    if (!isSame)
                    {
                        break; // 만약에 isSame = 1이 아니라면(false) 중복이 없단 의미이므로 탈출한다.
                    }
                }
            }

            //선택되지 않은 나머지에서 중복이 되지 않게 선택한다.
            for (int i = Main_Scene.card_color; i < 3; i++)
            {
                while (true) // 중복되는 지 확인이 될 때까지 하므로 while을 써서 반복한다.
                {
                    Main_Scene.Selected_card_color[i] = Random.Range(0, 7); // 0에서 6 중에서 1개를 골라 해당 배열에 넣는다.
                    isSame = false; // 기본은 false값으로 주어진다.

                    for (int j = 0; j < i; j++) // 중복을 확인합니다.
                    {
                        if (Main_Scene.Selected_card_color[j] == Main_Scene.Selected_card_color[i])
                        {
                            isSame = true; // 중복일 경우 해당 명제는 참으로 계산된다.
                            break; // 중복일 경우엔 다시 for(j)문을 확인할 필요가 없기 때문에 탈출한다.
                        }

                        //만약 true 값이 나오지 않았다면 이대로 유지될 것이다.
                    }

                    if (!isSame)
                    {
                        break; // 만약에 isSame = 1이 아니라면(false) 중복이 없단 의미이므로 탈출한다.
                    }
                }
            }

            //전등모드가 켬
            for (int i = 0; i < 5; i++)
            {
                if (i == 1)
                    Main_Scene.Selected_stage[i] = 1;

                else
                    Main_Scene.Selected_stage[i] = 0;
            }
        }

        if (Textit == 7) //무대조명
        {
            Main_Scene.Player1Mode = true; //1인모드 실행
            Main_Scene.TimeAttack = true; //타임어택모드 실행
            Main_Scene.time = 75; //1분 15초로 제한
            Main_Scene.Last_Stage = 1;

            bool isSame = false;

            //선택되지 않은 나머지에서 중복이 되지 않게 선택한다.
            for (int i = Main_Scene.card_number; i < 4; i++)
            {
                while (true) // 중복되는 지 확인이 될 때까지 하므로 while을 써서 반복한다.
                {
                    Main_Scene.Selected_card[i] = Random.Range(0, 8); // 0에서 7 중에서 1개를 골라 해당 배열에 넣는다.
                    isSame = false; // 기본은 false값으로 주어진다.

                    for (int j = 0; j < i; j++) // 중복을 확인합니다.
                    {
                        if (Main_Scene.Selected_card[j] == Main_Scene.Selected_card[i])
                        {
                            isSame = true; // 중복일 경우 해당 명제는 참으로 계산된다.
                            break; // 중복일 경우엔 다시 for(j)문을 확인할 필요가 없기 때문에 탈출한다.
                        }

                        //만약 true 값이 나오지 않았다면 이대로 유지될 것이다.
                    }

                    if (!isSame)
                    {
                        break; // 만약에 isSame = 1이 아니라면(false) 중복이 없단 의미이므로 탈출한다.
                    }
                }
            }

            //선택되지 않은 나머지에서 중복이 되지 않게 선택한다.
            for (int i = Main_Scene.card_color; i < 3; i++)
            {
                while (true) // 중복되는 지 확인이 될 때까지 하므로 while을 써서 반복한다.
                {
                    Main_Scene.Selected_card_color[i] = Random.Range(0, 7); // 0에서 6 중에서 1개를 골라 해당 배열에 넣는다.
                    isSame = false; // 기본은 false값으로 주어진다.

                    for (int j = 0; j < i; j++) // 중복을 확인합니다.
                    {
                        if (Main_Scene.Selected_card_color[j] == Main_Scene.Selected_card_color[i])
                        {
                            isSame = true; // 중복일 경우 해당 명제는 참으로 계산된다.
                            break; // 중복일 경우엔 다시 for(j)문을 확인할 필요가 없기 때문에 탈출한다.
                        }

                        //만약 true 값이 나오지 않았다면 이대로 유지될 것이다.
                    }

                    if (!isSame)
                    {
                        break; // 만약에 isSame = 1이 아니라면(false) 중복이 없단 의미이므로 탈출한다.
                    }
                }
            }

            //전등모드가 켬
            for (int i = 0; i < 5; i++)
            {
                if (i == 1)
                    Main_Scene.Selected_stage[i] = 1;

                else
                    Main_Scene.Selected_stage[i] = 0;
            }
        }

        if (Textit == 8) //플러스모드
        {
            Main_Scene.Player1Mode = true; //1인모드 실행
            Main_Scene.TimeAttack = true; //타임어택모드 실행
            Main_Scene.time = 120; //2분으로 제한
            Main_Scene.Last_Stage = 1;

            bool isSame = false;

            //선택되지 않은 나머지에서 중복이 되지 않게 선택한다.
            for (int i = Main_Scene.card_number; i < 4; i++)
            {
                while (true) // 중복되는 지 확인이 될 때까지 하므로 while을 써서 반복한다.
                {
                    Main_Scene.Selected_card[i] = Random.Range(0, 8); // 0에서 7 중에서 1개를 골라 해당 배열에 넣는다.
                    isSame = false; // 기본은 false값으로 주어진다.

                    for (int j = 0; j < i; j++) // 중복을 확인합니다.
                    {
                        if (Main_Scene.Selected_card[j] == Main_Scene.Selected_card[i])
                        {
                            isSame = true; // 중복일 경우 해당 명제는 참으로 계산된다.
                            break; // 중복일 경우엔 다시 for(j)문을 확인할 필요가 없기 때문에 탈출한다.
                        }

                        //만약 true 값이 나오지 않았다면 이대로 유지될 것이다.
                    }

                    if (!isSame)
                    {
                        break; // 만약에 isSame = 1이 아니라면(false) 중복이 없단 의미이므로 탈출한다.
                    }
                }
            }

            //선택되지 않은 나머지에서 중복이 되지 않게 선택한다.
            for (int i = Main_Scene.card_color; i < 3; i++)
            {
                while (true) // 중복되는 지 확인이 될 때까지 하므로 while을 써서 반복한다.
                {
                    Main_Scene.Selected_card_color[i] = Random.Range(0, 7); // 0에서 6 중에서 1개를 골라 해당 배열에 넣는다.
                    isSame = false; // 기본은 false값으로 주어진다.

                    for (int j = 0; j < i; j++) // 중복을 확인합니다.
                    {
                        if (Main_Scene.Selected_card_color[j] == Main_Scene.Selected_card_color[i])
                        {
                            isSame = true; // 중복일 경우 해당 명제는 참으로 계산된다.
                            break; // 중복일 경우엔 다시 for(j)문을 확인할 필요가 없기 때문에 탈출한다.
                        }

                        //만약 true 값이 나오지 않았다면 이대로 유지될 것이다.
                    }

                    if (!isSame)
                    {
                        break; // 만약에 isSame = 1이 아니라면(false) 중복이 없단 의미이므로 탈출한다.
                    }
                }
            }

            //4x4모드가 켬
            for (int i = 0; i < 5; i++)
            {
                if (i == 2)
                    Main_Scene.Selected_stage[i] = 1;

                else
                    Main_Scene.Selected_stage[i] = 0;
            }
        }

        if (Textit == 9) //올라운드
        {
            Main_Scene.Player1Mode = true; //1인모드 실행
            Main_Scene.TimeAttack = true; //타임어택모드 실행
            Main_Scene.time = 720; //12분으로 제한
            Main_Scene.Last_Stage = 8;

            bool isSame = false;

            //선택되지 않은 나머지에서 중복이 되지 않게 선택한다.
            for (int i = Main_Scene.card_number; i < 4; i++)
            {
                while (true) // 중복되는 지 확인이 될 때까지 하므로 while을 써서 반복한다.
                {
                    Main_Scene.Selected_card[i] = Random.Range(0, 8); // 0에서 7 중에서 1개를 골라 해당 배열에 넣는다.
                    isSame = false; // 기본은 false값으로 주어진다.

                    for (int j = 0; j < i; j++) // 중복을 확인합니다.
                    {
                        if (Main_Scene.Selected_card[j] == Main_Scene.Selected_card[i])
                        {
                            isSame = true; // 중복일 경우 해당 명제는 참으로 계산된다.
                            break; // 중복일 경우엔 다시 for(j)문을 확인할 필요가 없기 때문에 탈출한다.
                        }

                        //만약 true 값이 나오지 않았다면 이대로 유지될 것이다.
                    }

                    if (!isSame)
                    {
                        break; // 만약에 isSame = 1이 아니라면(false) 중복이 없단 의미이므로 탈출한다.
                    }
                }
            }

            //선택되지 않은 나머지에서 중복이 되지 않게 선택한다.
            for (int i = Main_Scene.card_color; i < 3; i++)
            {
                while (true) // 중복되는 지 확인이 될 때까지 하므로 while을 써서 반복한다.
                {
                    Main_Scene.Selected_card_color[i] = Random.Range(0, 7); // 0에서 6 중에서 1개를 골라 해당 배열에 넣는다.
                    isSame = false; // 기본은 false값으로 주어진다.

                    for (int j = 0; j < i; j++) // 중복을 확인합니다.
                    {
                        if (Main_Scene.Selected_card_color[j] == Main_Scene.Selected_card_color[i])
                        {
                            isSame = true; // 중복일 경우 해당 명제는 참으로 계산된다.
                            break; // 중복일 경우엔 다시 for(j)문을 확인할 필요가 없기 때문에 탈출한다.
                        }

                        //만약 true 값이 나오지 않았다면 이대로 유지될 것이다.
                    }

                    if (!isSame)
                    {
                        break; // 만약에 isSame = 1이 아니라면(false) 중복이 없단 의미이므로 탈출한다.
                    }
                }
            }

            //일반모드부터 시작함
            for (int i = 0; i < 5; i++)
            {
                Main_Scene.Selected_stage[i] = 0;
            }
        }

        for (int i = 0; i < 9; i++)
        {
            if (i == Textit-1)
                Challengemode[i] = 1;

            else
                Challengemode[i] = 0;
        }
    }
}
