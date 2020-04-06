using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Tutorial : MonoBehaviour
{
    public static int step = 0, step2 = 0, step3 = 0, step4 = 0;
    public static GameObject Fade, Title, Scroll, Text, Next, H, G, Player, Light, Stop, QuitPage, QuitGame, GoBackGame, Fade2, Music;
    public static GameObject[] Card = new GameObject[9];
    public static int Text_moving = 0;

    public Sprite[] GameImage, GameImage2, but;
    public Sprite[] Type;
    public Sprite[] Main;
    public static int h = 0;
    int Lightning = 0;

    public void NextGoing()
    {
        MusicSource.SFXCHOOSE = true;
        MusicSource.SFX[0] = true;
        MusicSource.SE_volume = 0.6f;
        Text_moving++;
    }

    public void Stopit()
    {
        if(step < 47)
        {
            Adstart = true;
            MusicSource.SFXCHOOSE = true;
            MusicSource.SFX[1] = true;
            MusicSource.SE_volume = 0.25f;
            Stopthis = true;
        }
    }

    public void Moveit()
    {
        Adstart = false;
        MusicSource.SFXCHOOSE = true;
        MusicSource.SFX[1] = true;
        MusicSource.SE_volume = 0.25f;

        Fade.GetComponent<RectTransform>().localPosition = new Vector3(15110, 0, 0);
        Fade.GetComponent<Image>().color = new Color(Fade.GetComponent<Image>().color.r, Fade.GetComponent<Image>().color.g, Fade.GetComponent<Image>().color.b, 0f);
        QuitPage.GetComponent<Image>().color = new Color(QuitPage.GetComponent<Image>().color.r, QuitPage.GetComponent<Image>().color.g, QuitPage.GetComponent<Image>().color.b, 0);
        QuitGame.GetComponent<Image>().color = new Color(QuitGame.GetComponent<Image>().color.r, QuitGame.GetComponent<Image>().color.g, QuitGame.GetComponent<Image>().color.b, 0);
        GoBackGame.GetComponent<Image>().color = new Color(GoBackGame.GetComponent<Image>().color.r, GoBackGame.GetComponent<Image>().color.g, GoBackGame.GetComponent<Image>().color.b, 0);
        Music.GetComponent<RectTransform>().localPosition = new Vector3(15000, 0, 0);

        if (Stopthis)
            Stopthis = false;
    }

    public void Quitit()
    {
        MusicSource.SFXCHOOSE = true;
        MusicSource.SFX[1] = true;
        MusicSource.SE_volume = 0.25f;
        FadeOut = true;
    }

    public static bool Lightmode = false;
    public static bool LightStart = false;
    public static bool Stopthis = false;
    public static float speed = 3;
    public static bool FadeOut = false;
    public static bool Adstart = false;
    public bool FadeIn = true;

    void Awake()
    {
        Screen.SetResolution(Screen.width, Screen.width * 16 / 9, false);
    }

    // Use this for initialization
    void Start () {
        GameImage = new Sprite[170];
        GameImage2 = new Sprite[10];
        Type = new Sprite[37];
        Main = new Sprite[128];
        but = new Sprite[51];
        GameImage = Resources.LoadAll<Sprite>("Texture/Cards");
        Type = Resources.LoadAll<Sprite>("Texture/Type");
        Main = Resources.LoadAll<Sprite>("Texture/Main");
        GameImage2 = Resources.LoadAll<Sprite>("Texture/Challenge");
        but = Resources.LoadAll<Sprite>("Texture/Button");

        Fade = GameObject.Find("Fade");
        Fade2 = GameObject.Find("Fade2");
        Title = GameObject.Find("Title");
        Scroll = GameObject.Find("Scroll");
        Text = GameObject.Find("Text");
        Next = GameObject.Find("Next");
        H = GameObject.Find("Hap");
        G = GameObject.Find("Gyo");
        Player = GameObject.Find("Player");
        Light = GameObject.Find("Light");
        Stop = GameObject.Find("Stop");
        QuitPage = GameObject.Find("QuitPage");
        QuitGame = GameObject.Find("QuitGame");
        GoBackGame = GameObject.Find("GoBackGame");
        Music = GameObject.Find("Music");

        for (int i = 0; i < 9; i++)
            Card[i] = GameObject.Find("Card" + (i + 1));

        Fade.GetComponent<RectTransform>().localPosition = new Vector3(15150, 0, 0);
        Light.GetComponent<Image>().color = new Color(Light.GetComponent<Image>().color.r, Light.GetComponent<Image>().color.g, Light.GetComponent<Image>().color.b, 0f);
        Scroll.GetComponent<RectTransform>().localPosition = new Vector3(0, -217, 0);

        Fade.GetComponent<Image>().color = new Color(0, 0, 0, 1);
        Scroll.GetComponent<Image>().color = new Color(Scroll.GetComponent<Image>().color.r, Scroll.GetComponent<Image>().color.g, Scroll.GetComponent<Image>().color.b, 0f);
        Stop.GetComponent<Image>().color = new Color(Stop.GetComponent<Image>().color.r, Stop.GetComponent<Image>().color.g, Stop.GetComponent<Image>().color.b, 0f);
        Next.GetComponent<Image>().color = new Color(Next.GetComponent<Image>().color.r, Next.GetComponent<Image>().color.g, Next.GetComponent<Image>().color.b, 0f);
        Title.GetComponent<Image>().color = new Color(Title.GetComponent<Image>().color.r, Title.GetComponent<Image>().color.g, Title.GetComponent<Image>().color.b, 0);
        QuitPage.GetComponent<Image>().color = new Color(QuitPage.GetComponent<Image>().color.r, QuitPage.GetComponent<Image>().color.g, QuitPage.GetComponent<Image>().color.b, 0f);
        QuitGame.GetComponent<Image>().color = new Color(QuitGame.GetComponent<Image>().color.r, QuitGame.GetComponent<Image>().color.g, QuitGame.GetComponent<Image>().color.b, 0f);
        GoBackGame.GetComponent<Image>().color = new Color(GoBackGame.GetComponent<Image>().color.r, GoBackGame.GetComponent<Image>().color.g, GoBackGame.GetComponent<Image>().color.b, 0);

        if (Main_Scene.Language == 1)
        {
            Title.GetComponent<Image>().sprite = Main[0];
            Title.GetComponent<RectTransform>().sizeDelta = new Vector3(393, 135);
            H.GetComponent<Image>().sprite = but[0];
            G.GetComponent<Image>().sprite = but[1];
        }

        else if (Main_Scene.Language == 2)
        {
            Title.GetComponent<Image>().sprite = Main[84];
            Title.GetComponent<RectTransform>().sizeDelta = new Vector3(321, 161);
            Title.GetComponent<RectTransform>().localScale = new Vector3(1.2f, 1.2f);
            H.GetComponent<Image>().sprite = but[32];
            G.GetComponent<Image>().sprite = but[33];
        }

        else if (Main_Scene.Language == 3)
        {
            Title.GetComponent<Image>().sprite = Main[103];
            Title.GetComponent<RectTransform>().sizeDelta = new Vector3(390, 138);
            H.GetComponent<Image>().sprite = but[42];
            G.GetComponent<Image>().sprite = but[43];
        }

        for (int i = 0; i < 9; i++)
            Card[i].GetComponent<Image>().color = new Color(Card[i].GetComponent<Image>().color.r, Card[i].GetComponent<Image>().color.g, Card[i].GetComponent<Image>().color.b, 0);
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Lightmode)
        {
            Light.GetComponent<RectTransform>().localPosition = new Vector3(0, 330);

            if (LightStart)
            {
                if (h != 5)
                {
                    if (step2 == 0)
                    {
                        Light.GetComponent<Image>().color = new Color(Light.GetComponent<Image>().color.r, Light.GetComponent<Image>().color.g, Light.GetComponent<Image>().color.b, Light.GetComponent<Image>().color.a + 0.1f - (Lightning / 10) * 2);

                        if (Light.GetComponent<Image>().color.a > 1)
                            step2 = 1;
                    }

                    if (step2 == 1)
                    {
                        Light.GetComponent<Image>().color = new Color(Light.GetComponent<Image>().color.r, Light.GetComponent<Image>().color.g, Light.GetComponent<Image>().color.b, Light.GetComponent<Image>().color.a - 0.1f - (Lightning / 10) * 2);

                        if (Light.GetComponent<Image>().color.a < 0)
                            step2 = 0;
                    }

                    h++;
                }

                else
                    LightStart = false;

            }

            else
            {
                Light.GetComponent<Image>().color = new Color(Light.GetComponent<Image>().color.r, Light.GetComponent<Image>().color.g, Light.GetComponent<Image>().color.b, 0.95f);

                if (step2 == 0) //왼으로 움직임
                {
                    if (Light.GetComponent<RectTransform>().transform.eulerAngles.z < 110 && Light.GetComponent<RectTransform>().transform.eulerAngles.z > 0)
                    {
                        Light.GetComponent<RectTransform>().transform.rotation = Quaternion.Euler(0, 0, Light.GetComponent<RectTransform>().transform.eulerAngles.z + speed);

                        if (Light.GetComponent<RectTransform>().transform.eulerAngles.z >= 17)
                        {
                            speed *= 0.94f;
                        }

                        if (speed < 0.03)
                        {
                            step2 = 2;
                            speed = 3;
                        }
                    }

                    else
                    {
                        Light.GetComponent<RectTransform>().transform.rotation = Quaternion.Euler(0, 0, Light.GetComponent<RectTransform>().transform.eulerAngles.z + speed);
                    }
                }

                if (step2 == 1) //오른쪽으로 움직임
                {
                    if (Light.GetComponent<RectTransform>().transform.eulerAngles.z < 360 && Light.GetComponent<RectTransform>().transform.eulerAngles.z >= 250)
                    {
                            Light.GetComponent<RectTransform>().transform.rotation = Quaternion.Euler(0, 0, Light.GetComponent<RectTransform>().transform.eulerAngles.z - speed);

                        if (Light.GetComponent<RectTransform>().transform.eulerAngles.z <= 340)
                        {
                            speed *= 0.94f;
                        }

                        if (speed < 0.03)
                        {
                            step2 = 3;
                            speed = 3;
                        }
                    }

                    else
                    {
                            Light.GetComponent<RectTransform>().transform.rotation = Quaternion.Euler(0, 0, Light.GetComponent<RectTransform>().transform.eulerAngles.z - speed);
                    }
                }

                if (step2 == 2)
                {
                    if (360 > Light.GetComponent<RectTransform>().transform.eulerAngles.z && 220 < Light.GetComponent<RectTransform>().transform.eulerAngles.z)
                    {
                        speed = 2;
                        step2 = 1;
                    }

                    else
                    {
                            Light.GetComponent<RectTransform>().transform.rotation = Quaternion.Euler(0, 0, Light.GetComponent<RectTransform>().transform.eulerAngles.z - speed);
                    }
                }

                if (step2 == 3)
                {
                    if (80 > Light.GetComponent<RectTransform>().transform.eulerAngles.z && 0 < Light.GetComponent<RectTransform>().transform.eulerAngles.z)
                    {
                        speed = 2;
                        step2 = 0;
                    }

                    else
                    {
                            Light.GetComponent<RectTransform>().transform.rotation = Quaternion.Euler(0, 0, Light.GetComponent<RectTransform>().transform.eulerAngles.z + speed);
                    }
                }
            }
        }

        if(Stopthis)
        {
            Fade.GetComponent<RectTransform>().localPosition = new Vector3(0, 0, 0);
            Fade.GetComponent<Image>().color = new Color(Fade.GetComponent<Image>().color.r, Fade.GetComponent<Image>().color.g, Fade.GetComponent<Image>().color.b, 0.7f);
            QuitPage.GetComponent<Image>().color = new Color(QuitPage.GetComponent<Image>().color.r, QuitPage.GetComponent<Image>().color.g, QuitPage.GetComponent<Image>().color.b, 1);
            QuitGame.GetComponent<Image>().color = new Color(QuitGame.GetComponent<Image>().color.r, QuitGame.GetComponent<Image>().color.g, QuitGame.GetComponent<Image>().color.b, 1);
            GoBackGame.GetComponent<Image>().color = new Color(GoBackGame.GetComponent<Image>().color.r, GoBackGame.GetComponent<Image>().color.g, GoBackGame.GetComponent<Image>().color.b, 1);
            Music.GetComponent<RectTransform>().localPosition = new Vector3(135, -40, 0);

            if (Main_Scene.Language == 1)
            {
                QuitGame.GetComponent<Image>().sprite = but[27];
                GoBackGame.GetComponent<Image>().sprite = but[26];
            }

            else if (Main_Scene.Language == 2)
            {
                QuitGame.GetComponent<Image>().sprite = but[41];
                GoBackGame.GetComponent<Image>().sprite = but[40];
            }

            else if (Main_Scene.Language == 3)
            {
                QuitGame.GetComponent<Image>().sprite = but[49];
                GoBackGame.GetComponent<Image>().sprite = but[48];
            }

            if (Main_Scene.isMusicOn)
                Music.GetComponent<Image>().sprite = Main_Scene.main_but[76];

            else
                Music.GetComponent<Image>().sprite = Main_Scene.main_but[73];
        }

        if (FadeIn)
        {
            if (step4 == 0)
            {
                Fade2.GetComponent<RectTransform>().localPosition = new Vector3(0, 0, 0);
                Fade2.GetComponent<Image>().color = new Color(0, 0, 0, 1);
                step4 = 1;
            }

            if (step4 == 1)
            {
                if (Fade2.GetComponent<Image>().color.a <= 0)
                    step4 = 2;

                else
                    Fade2.GetComponent<Image>().color = new Color(Fade2.GetComponent<Image>().color.r, Fade2.GetComponent<Image>().color.g, Fade2.GetComponent<Image>().color.b, Fade2.GetComponent<Image>().color.a - 0.01f);
            }

            if (step4 == 2)
            {
                MusicSource.step = 0;
                MusicSource.Looptime = 198.6f;
                MusicSource.volume = 1f;
                step = 1;
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
            Stopit();

        if (step == 1)
        {
            FadeIn = false;
            step4 = 0;
            Fade2.GetComponent<RectTransform>().localPosition = new Vector3(11120, 0, 0);
            Fade.GetComponent<RectTransform>().localPosition = new Vector3(11120, 0, 0);

            if (!Stopthis)
            {
                Title.GetComponent<Image>().color = new Color(Title.GetComponent<Image>().color.r, Title.GetComponent<Image>().color.g, Title.GetComponent<Image>().color.b, Title.GetComponent<Image>().color.a + 0.03f);
                Title.GetComponent<RectTransform>().localScale = new Vector3(Title.GetComponent<RectTransform>().localScale.x - 0.01f, Title.GetComponent<RectTransform>().localScale.y - 0.01f, 0);
            }

            else
            {
                Title.GetComponent<Image>().color = new Color(Title.GetComponent<Image>().color.r, Title.GetComponent<Image>().color.g, Title.GetComponent<Image>().color.b, Title.GetComponent<Image>().color.a);
                Title.GetComponent<RectTransform>().localScale = new Vector3(Title.GetComponent<RectTransform>().localScale.x, Title.GetComponent<RectTransform>().localScale.y, 0);
            }


            if (Title.GetComponent<Image>().color.a > 1)
                step = 2;
        }

        if (step == 2)
        {
            if (!Stopthis)
            {
                Scroll.GetComponent<Image>().color = new Color(Scroll.GetComponent<Image>().color.r, Scroll.GetComponent<Image>().color.g, Scroll.GetComponent<Image>().color.b, Scroll.GetComponent<Image>().color.a + 0.05f);
                Stop.GetComponent<Image>().color = new Color(Stop.GetComponent<Image>().color.r, Stop.GetComponent<Image>().color.g, Stop.GetComponent<Image>().color.b, Stop.GetComponent<Image>().color.a + 0.05f);
                Next.GetComponent<Image>().color = new Color(Next.GetComponent<Image>().color.r, Next.GetComponent<Image>().color.g, Next.GetComponent<Image>().color.b, Next.GetComponent<Image>().color.a + 0.05f);
            }

            else
            {
                Scroll.GetComponent<Image>().color = new Color(Scroll.GetComponent<Image>().color.r, Scroll.GetComponent<Image>().color.g, Scroll.GetComponent<Image>().color.b, Scroll.GetComponent<Image>().color.a);
                Stop.GetComponent<Image>().color = new Color(Stop.GetComponent<Image>().color.r, Stop.GetComponent<Image>().color.g, Stop.GetComponent<Image>().color.b, Stop.GetComponent<Image>().color.a);
                Next.GetComponent<Image>().color = new Color(Next.GetComponent<Image>().color.r, Next.GetComponent<Image>().color.g, Next.GetComponent<Image>().color.b, Next.GetComponent<Image>().color.a);
            }


            if (Scroll.GetComponent<Image>().color.a > 1f)
            {
                step = 3;
            }
        }

        if (step == 3)
        {
            if (Main_Scene.Language == 1)
            {
                if (Text_moving == 0)
                    Text.GetComponent<Text>().text = "'결! 합!'게임에 오신 여러분들 환영합니다!";

                if (Text_moving == 1)
                    Text.GetComponent<Text>().text = "이것은 게임을 처음 하시는 분들을 위한 게임 설명서입니다.";

                if (Text_moving == 2)
                    Text.GetComponent<Text>().text = "참고로, 위 설명서는 '2인모드'를 기준으로 작성되었음을 미리 밝힙니다.";

                if (Text_moving == 3)
                    Text.GetComponent<Text>().text = "그럼 시작해볼까요!";
            }

            else if (Main_Scene.Language == 2)
            {
                if (Text_moving == 0)
                    Text.GetComponent<Text>().text = "Howdy! Welcome to 'Find or Set' Game!";

                if (Text_moving == 1)
                    Text.GetComponent<Text>().text = "This is a game tutorial for beginners,";

                if (Text_moving == 2)
                    Text.GetComponent<Text>().text = "and it is based on '2 Players Mode.'";

                if (Text_moving == 3)
                    Text.GetComponent<Text>().text = "Now, Let's START it!";
            }

            else if (Main_Scene.Language == 3)
            {
                if (Text_moving == 0)
                    Text.GetComponent<Text>().text = "'決! 発!'ゲームへようこそ!";

                if (Text_moving == 1)
                    Text.GetComponent<Text>().text = "これはゲームを始める人達のためのゲーム説明書でございます.";

                if (Text_moving == 2)
                    Text.GetComponent<Text>().text = "ちなみに「二人でプレイ」するのを基準にして説明します.";

                if (Text_moving == 3)
                    Text.GetComponent<Text>().text = "では，始めましょうか!";
            }

            if (Text_moving == 4)
            {
                step = 4;
                Text_moving = 0;
            }
        }

        if (step == 4)
        {
            if (!Stopthis)
                Title.GetComponent<Image>().color = new Color(Title.GetComponent<Image>().color.r, Title.GetComponent<Image>().color.g, Title.GetComponent<Image>().color.b, Title.GetComponent<Image>().color.a - 0.06f);

            else
                Title.GetComponent<Image>().color = new Color(Title.GetComponent<Image>().color.r, Title.GetComponent<Image>().color.g, Title.GetComponent<Image>().color.b, Title.GetComponent<Image>().color.a);

            if (Title.GetComponent<Image>().color.a < 0)
                step = 5;
        }

        if (step == 5)
        {
            if (H.GetComponent<RectTransform>().localPosition.x == -100)
            {
                if (!Stopthis)
                {
                    for (int i = 0; i < 9; i++)
                        Card[i].GetComponent<Image>().color = new Color(Card[i].GetComponent<Image>().color.r, Card[i].GetComponent<Image>().color.g, Card[i].GetComponent<Image>().color.b, Card[i].GetComponent<Image>().color.a + 0.1f);
                }

                else
                {
                    for (int i = 0; i < 9; i++)
                        Card[i].GetComponent<Image>().color = new Color(Card[i].GetComponent<Image>().color.r, Card[i].GetComponent<Image>().color.g, Card[i].GetComponent<Image>().color.b, Card[i].GetComponent<Image>().color.a);
                }

                if (Card[8].GetComponent<Image>().color.a > 1)
                {
                    Text_moving = 0;
                    step = 6;
                }
            }

            else
            {
                if (!Stopthis)
                {
                    H.GetComponent<RectTransform>().localPosition = new Vector3(H.GetComponent<RectTransform>().localPosition.x + 10, 210, 0);
                    G.GetComponent<RectTransform>().localPosition = new Vector3(G.GetComponent<RectTransform>().localPosition.x - 10, 210, 0);
                }

                else
                {
                    H.GetComponent<RectTransform>().localPosition = new Vector3(H.GetComponent<RectTransform>().localPosition.x, 210, 0);
                    G.GetComponent<RectTransform>().localPosition = new Vector3(G.GetComponent<RectTransform>().localPosition.x, 210, 0);
                }
            }
        }

        if (step == 6)
        {
            if (Main_Scene.Language == 1)
            {
                if (Text_moving == 0)
                    Text.GetComponent<Text>().text = "이 게임은 '합'과 '결'을 선언할 수 있는 버튼과";

                if (Text_moving == 1)
                    Text.GetComponent<Text>().text = "9장의 카드들을 기본으로 두고 하는 게임입니다.";

                if (Text_moving == 2)
                    Text.GetComponent<Text>().text = "여러분은 이 카드들 중에서 3장을 골라 합의 여부를 판단하고";

                if (Text_moving == 3)
                    Text.GetComponent<Text>().text = "때에 따라선 결의 여부 또한 판단을 해야 합니다.";

                if (Text_moving == 4)
                    Text.GetComponent<Text>().text = "먼저, 합에 대해서 알아 보도록 합시다.";
            }

            else if (Main_Scene.Language == 2)
            {
                if (Text_moving == 0)
                    Text.GetComponent<Text>().text = "This game has a buttons which name are 'Find' and 'Set,'";

                if (Text_moving == 1)
                    Text.GetComponent<Text>().text = "and 9 of different cards.";

                if (Text_moving == 2)
                    Text.GetComponent<Text>().text = "In the game, You have to choose three of these cards to declare 'Find' to get a point.";

                if (Text_moving == 3)
                    Text.GetComponent<Text>().text = "But you also have to think about 'Set' Timing to finish the game.";

                if (Text_moving == 4)
                    Text.GetComponent<Text>().text = "Now, What is 'Find' in this game?";
            }

            else if (Main_Scene.Language == 3)
            {
                if (Text_moving == 0)
                    Text.GetComponent<Text>().text = "このゲームは「発」と「決」を宣言するボタンと";

                if (Text_moving == 1)
                    Text.GetComponent<Text>().text = "全9個のカード達でやるパズルゲームでございます.";

                if (Text_moving == 2)
                    Text.GetComponent<Text>().text = "皆さんはこのカード達の中から三枚を選び「発」を判断して, ";

                if (Text_moving == 3)
                    Text.GetComponent<Text>().text = "「発」を宣言したり，「決」を宣言したりします.";

                if (Text_moving == 4)
                    Text.GetComponent<Text>().text = "まず，「発」は一体何なのでしょうか?";
            }

            if (Text_moving == 5)
            {
                step = 7;
            }
        }

        if (step == 7)
        {
            if (H.GetComponent<RectTransform>().localPosition.x == 0)
            {
                Text_moving = 0;
                step = 8;
            }

            else
            {
                if (!Stopthis)
                {
                    H.GetComponent<RectTransform>().localPosition = new Vector3(H.GetComponent<RectTransform>().localPosition.x + 5f, 210, 0);
                    G.GetComponent<RectTransform>().localPosition = new Vector3(G.GetComponent<RectTransform>().localPosition.x + 15, 210, 0);
                }

                else
                {
                    H.GetComponent<RectTransform>().localPosition = new Vector3(H.GetComponent<RectTransform>().localPosition.x, 210, 0);
                    G.GetComponent<RectTransform>().localPosition = new Vector3(G.GetComponent<RectTransform>().localPosition.x, 210, 0);
                }
            }
        }

        if (step == 8)
        {
            if (Main_Scene.Language == 1)
            {
                if (Text_moving == 0)
                    Text.GetComponent<Text>().text = "각각의 카드들엔 3가지 속성이 있습니다.";

                if (Text_moving == 1)
                    Text.GetComponent<Text>().text = "모양, 모양의 색, 바탕의 색이 그것이죠.";

                if (Text_moving == 2)
                    Text.GetComponent<Text>().text = "이 3가지 속성들은 합을 판단하는 기준이 됩니다.";
            }

            else if (Main_Scene.Language == 2)
            {
                if (Text_moving == 0)
                    Text.GetComponent<Text>().text = "Each card has three attributes.";

                if (Text_moving == 1)
                    Text.GetComponent<Text>().text = "The Shape, The Color of the Shape, The Color of the Background.";

                if (Text_moving == 2)
                    Text.GetComponent<Text>().text = "These three attributes are the basis for determining the 'Find' in this game.";
            }

            else if (Main_Scene.Language == 3)
            {
                if (Text_moving == 0)
                    Text.GetComponent<Text>().text = "それぞれのカードには3つの属性があります.";

                if (Text_moving == 1)
                    Text.GetComponent<Text>().text = "それは模様，模様の色，背景の色です.";

                if (Text_moving == 2)
                    Text.GetComponent<Text>().text = "この3つの属性は「発」を判断する基準になります.";
            }

            if (Text_moving == 3)
            {
                step = 9;
            }
        }

        if (step == 9)
        {
            if (Card[0].GetComponent<RectTransform>().localPosition.x == 700)
            {
                for (int i = 0; i < 3; i++)
                    for (int j = 0; j < 3; j++)
                        Card[i * 3 + j].GetComponent<RectTransform>().localPosition = new Vector3(-700 + 100 * j, Card[i * 3 + j].GetComponent<RectTransform>().localPosition.y, 0);

                step = 10;
            }

            else
            {
                if (!Stopthis)
                {
                    for (int i = 0; i < 9; i++)
                        Card[i].GetComponent<RectTransform>().localPosition = new Vector3(Card[i].GetComponent<RectTransform>().localPosition.x + 10, Card[i].GetComponent<RectTransform>().localPosition.y, 0);
                }

                else
                {
                    for (int i = 0; i < 9; i++)
                        Card[i].GetComponent<RectTransform>().localPosition = new Vector3(Card[i].GetComponent<RectTransform>().localPosition.x, Card[i].GetComponent<RectTransform>().localPosition.y, 0);
                }
            }
        }

        if (step == 10)
        {
            if (Card[3].GetComponent<RectTransform>().localPosition.x == -100)
            {
                for (int i = 0; i < 6; i++)
                    Card[3 + i].GetComponent<RectTransform>().localPosition = new Vector3(Card[i + 3].GetComponent<RectTransform>().localPosition.x, Card[i + 3].GetComponent<RectTransform>().localPosition.y, 0);

                Text_moving = 0;
                step = 11;
            }

            else
            {
                Card[3].GetComponent<Image>().sprite = GameImage[0];
                Card[4].GetComponent<Image>().sprite = GameImage[7];
                Card[5].GetComponent<Image>().sprite = GameImage[14];
                Card[6].GetComponent<Image>().sprite = GameImage[36];
                Card[7].GetComponent<Image>().sprite = GameImage[72];
                Card[8].GetComponent<Image>().sprite = GameImage[108];

                if (!Stopthis)
                {
                    for (int i = 0; i < 3; i++)
                        Card[3 + i].GetComponent<RectTransform>().localPosition = new Vector3(Card[i + 3].GetComponent<RectTransform>().localPosition.x + 10, 80, 0);

                    for (int i = 0; i < 3; i++)
                        Card[6 + i].GetComponent<RectTransform>().localPosition = new Vector3(Card[i + 6].GetComponent<RectTransform>().localPosition.x + 10, -30, 0);
                }

                else
                {
                    for (int i = 0; i < 3; i++)
                        Card[3 + i].GetComponent<RectTransform>().localPosition = new Vector3(Card[i + 3].GetComponent<RectTransform>().localPosition.x, 80, 0);

                    for (int i = 0; i < 3; i++)
                        Card[6 + i].GetComponent<RectTransform>().localPosition = new Vector3(Card[i + 6].GetComponent<RectTransform>().localPosition.x, -30, 0);
                }
            }
        }

        if (step == 11)
        {
            if (Main_Scene.Language == 1)
            {
                if (Text_moving == 0)
                    Text.GetComponent<Text>().text = "먼저, 카드의 모양입니다.";

                if (Text_moving == 1)
                    Text.GetComponent<Text>().text = "9장의 카드들은 기본적으로 3개의 모양을 가지고 있습니다.";

                if (Text_moving == 2)
                    Text.GetComponent<Text>().text = "선택한 카드 3장이 합이기 위해선, 카드 3장의 모양이 모두 같거나, 모두 달라야합니다.";

                if (Text_moving == 3)
                    Text.GetComponent<Text>().text = "그 예로, 윗 줄의 3장의 카드는 모두 모양이 '원'으로 같고,";

                if (Text_moving == 4)
                    Text.GetComponent<Text>().text = "아래 줄의 3장의 카드는 모두 모양이 다르기 때문에";

                if (Text_moving == 5)
                    Text.GetComponent<Text>().text = "카드 3장이 '합'이 되기 위한 '모양의 속성'을 만족한다고 볼 수 있습니다.";

                if (Text_moving == 6)
                    Text.GetComponent<Text>().text = "하지만 '모양의 속성'이 만족된다고 해서 이 카드 3장이 '합'이라고 할 순 없습니다.";

                if (Text_moving == 7)
                    Text.GetComponent<Text>().text = "이는 다른 속성들 또한 '합'의 조건을 만족해야 하기 때문입니다.";

                if (Text_moving == 8)
                    Text.GetComponent<Text>().text = "계속해서 다음 속성에 대해서도 알아볼까요?";
            }

            else if (Main_Scene.Language == 2)
            {
                if (Text_moving == 0)
                    Text.GetComponent<Text>().text = "First, The Shape.";

                if (Text_moving == 1)
                    Text.GetComponent<Text>().text = "Each Stage, those cards have one of the three shapes.";

                if (Text_moving == 2)
                    Text.GetComponent<Text>().text = "The three of cards that you selected to be 'Find,' all must be the same shape or all must be different.";

                if (Text_moving == 3)
                    Text.GetComponent<Text>().text = "For example, upside line of three cards have all the same shape,";

                if (Text_moving == 4)
                    Text.GetComponent<Text>().text = "the other line's cards are all different.";

                if (Text_moving == 5)
                    Text.GetComponent<Text>().text = "So, Each line of cards satisfies the 'Shape attribute' to become 'Find.'";

                if (Text_moving == 6)
                    Text.GetComponent<Text>().text = "But it doesn't mean that those cards are really 'Find.'";

                if (Text_moving == 7)
                    Text.GetComponent<Text>().text = "Because other attributes also have to be satisfied.";

                if (Text_moving == 8)
                    Text.GetComponent<Text>().text = "Let's take a look another attribute.";
            }

            else if (Main_Scene.Language == 3)
            {
                if (Text_moving == 0)
                    Text.GetComponent<Text>().text = "まず，カードの模様です.";

                if (Text_moving == 1)
                    Text.GetComponent<Text>().text = "九枚のカード達は基本的に三つの模様の中で一つを持ちます.";

                if (Text_moving == 2)
                    Text.GetComponent<Text>().text = "あなたが選んだ三つのカードが「発」になれるためには，そのカード達の模様が全部同じとか，全部違うじゃなければ\nなりません.";

                if (Text_moving == 3)
                    Text.GetComponent<Text>().text = "その例で，上の三つのカード達の模様が全部同じで，";

                if (Text_moving == 4)
                    Text.GetComponent<Text>().text = "下の三つのカード達の模様が全部違うので";

                if (Text_moving == 5)
                    Text.GetComponent<Text>().text = "そのカード達は「発」になれるための「模様の属性」を満足したと言えます.";

                if (Text_moving == 6)
                    Text.GetComponent<Text>().text = "しかし，模様だけでそのカード達が「発」だとは言えません.";

                if (Text_moving == 7)
                    Text.GetComponent<Text>().text = "他の属性も満足しなければならないからです.";

                if (Text_moving == 8)
                    Text.GetComponent<Text>().text = "続きの属性を見ましょう.";
            }

            if (Text_moving == 9)
                step = 12;
        }

        if (step == 12)
        {
            if (Card[3].GetComponent<RectTransform>().localPosition.x == 700)
            {
                for (int i = 0; i < 3; i++)
                    for (int j = 0; j < 3; j++)
                        Card[i * 3 + j].GetComponent<RectTransform>().localPosition = new Vector3(-700 + 100 * j, Card[i * 3 + j].GetComponent<RectTransform>().localPosition.y, 0);

                step = 13;
            }

            else
            {
                if (!Stopthis)
                {
                    for (int i = 0; i < 3; i++)
                        Card[3 + i].GetComponent<RectTransform>().localPosition = new Vector3(Card[i + 3].GetComponent<RectTransform>().localPosition.x + 10, 80, 0);

                    for (int i = 0; i < 3; i++)
                        Card[6 + i].GetComponent<RectTransform>().localPosition = new Vector3(Card[i + 6].GetComponent<RectTransform>().localPosition.x + 10, -30, 0);
                }

                else
                {
                    for (int i = 0; i < 3; i++)
                        Card[3 + i].GetComponent<RectTransform>().localPosition = new Vector3(Card[i + 3].GetComponent<RectTransform>().localPosition.x, 80, 0);

                    for (int i = 0; i < 3; i++)
                        Card[6 + i].GetComponent<RectTransform>().localPosition = new Vector3(Card[i + 6].GetComponent<RectTransform>().localPosition.x, -30, 0);
                }
            }
        }

        if (step == 13)
        {
            if (Card[3].GetComponent<RectTransform>().localPosition.x == -100)
            {
                for (int i = 0; i < 6; i++)
                    Card[3 + i].GetComponent<RectTransform>().localPosition = new Vector3(Card[i + 3].GetComponent<RectTransform>().localPosition.x, Card[i + 3].GetComponent<RectTransform>().localPosition.y, 0);

                Text_moving = 0;
                step = 14;
            }

            else
            {
                Card[3].GetComponent<Image>().sprite = GameImage[50];
                Card[4].GetComponent<Image>().sprite = GameImage[64];
                Card[5].GetComponent<Image>().sprite = GameImage[99];
                Card[6].GetComponent<Image>().sprite = GameImage[60];
                Card[7].GetComponent<Image>().sprite = GameImage[9];
                Card[8].GetComponent<Image>().sprite = GameImage[27];

                if (!Stopthis)
                {
                    for (int i = 0; i < 3; i++)
                        Card[3 + i].GetComponent<RectTransform>().localPosition = new Vector3(Card[i + 3].GetComponent<RectTransform>().localPosition.x + 10, 80, 0);

                    for (int i = 0; i < 3; i++)
                        Card[6 + i].GetComponent<RectTransform>().localPosition = new Vector3(Card[i + 6].GetComponent<RectTransform>().localPosition.x + 10, -30, 0);
                }

                else
                {
                    for (int i = 0; i < 3; i++)
                        Card[3 + i].GetComponent<RectTransform>().localPosition = new Vector3(Card[i + 3].GetComponent<RectTransform>().localPosition.x, 80, 0);

                    for (int i = 0; i < 3; i++)
                        Card[6 + i].GetComponent<RectTransform>().localPosition = new Vector3(Card[i + 6].GetComponent<RectTransform>().localPosition.x, -30, 0);
                }
            }
        }

        if (step == 14)
        {
            if (Main_Scene.Language == 1)
            {
                if (Text_moving == 0)
                    Text.GetComponent<Text>().text = "다음으로, 카드 안의 모양의 색입니다.";

                if (Text_moving == 1)
                    Text.GetComponent<Text>().text = "9장의 카드들은 기본적으로 3개의 모양의 색을 가지고 있습니다.";

                if (Text_moving == 2)
                    Text.GetComponent<Text>().text = "선택한 카드 3장이 합이기 위해선, 카드 3장의 모양의 색이 모두 같거나, 모두 달라야합니다.";

                if (Text_moving == 3)
                    Text.GetComponent<Text>().text = "그 예로, 윗 줄의 3장의 카드는 모두 모양의 색이 '주황색'으로 같고,";

                if (Text_moving == 4)
                    Text.GetComponent<Text>().text = "아래 줄의 3장의 카드는 모두 모양의 색이 다르기 때문에";

                if (Text_moving == 5)
                    Text.GetComponent<Text>().text = "카드 3장이 '합'이 되기 위한 '모양색의 속성'을 만족한다고 볼 수 있습니다.";

                if (Text_moving == 6)
                    Text.GetComponent<Text>().text = "하지만 '모양의 색의 속성'또한 마찬가지로";

                if (Text_moving == 7)
                    Text.GetComponent<Text>().text = "해당 속성만 만족한다고해서 이 카드 3장이 '합'이라고 할 순 없습니다.";

                if (Text_moving == 8)
                    Text.GetComponent<Text>().text = "이는 앞서 설명한 '모양'을 포함한 다른 속성들 또한 '합'의 조건을 만족해야 하기 때문입니다.";

                if (Text_moving == 9)
                    Text.GetComponent<Text>().text = "계속해서 다음 속성에 대해서도 알아볼까요?";
            }

            else if (Main_Scene.Language == 2)
            {
                if (Text_moving == 0)
                    Text.GetComponent<Text>().text = "Next, The Color of the Shape.";

                if (Text_moving == 1)
                    Text.GetComponent<Text>().text = "Each Stage, those cards have one of the three colors of the shape.";

                if (Text_moving == 2)
                    Text.GetComponent<Text>().text = "The three of cards that you selected to be 'Find,' all color of the shape must be the same, or all must be different.";

                if (Text_moving == 3)
                    Text.GetComponent<Text>().text = "For example, upside line of three cards have all the same color of the shape,";

                if (Text_moving == 4)
                    Text.GetComponent<Text>().text = "the other line's cards are all different.";

                if (Text_moving == 5)
                    Text.GetComponent<Text>().text = "So, Each line of cards satisfies the 'Color of the Shape attribute' to become 'Find.'";

                if (Text_moving == 6)
                    Text.GetComponent<Text>().text = "But like a 'Shape attribute,'";

                if (Text_moving == 7)
                    Text.GetComponent<Text>().text = "It doesn't mean that those cards are really 'Find.'";

                if (Text_moving == 8)
                    Text.GetComponent<Text>().text = "Because you have to check the other attributes.";

                if (Text_moving == 9)
                    Text.GetComponent<Text>().text = "Let's take a look another attribute.";
            }

            else if (Main_Scene.Language == 3)
            {
                if (Text_moving == 0)
                    Text.GetComponent<Text>().text = "続いて，カードの模様の色です";

                if (Text_moving == 1)
                    Text.GetComponent<Text>().text = "九枚のカード達は基本的に三つの模様の色の中で一つを持ちます.";

                if (Text_moving == 2)
                    Text.GetComponent<Text>().text = "あなたが選んだ三つのカードが「発」になれるためには，そのカード達の模様の色が全部同じとか，全部違うじゃなければなりません.";

                if (Text_moving == 3)
                    Text.GetComponent<Text>().text = "その例で，上の三つのカード達の模様の色が全部同じで，";

                if (Text_moving == 4)
                    Text.GetComponent<Text>().text = "下の三つのカード達の模様の色が全部違うので";

                if (Text_moving == 5)
                    Text.GetComponent<Text>().text = "そのカード達は「発」になれるための「模様の色の属性」を満足したと言えます";

                if (Text_moving == 6)
                    Text.GetComponent<Text>().text = "だが，「模様の属性」と同じく";

                if (Text_moving == 7)
                    Text.GetComponent<Text>().text = "模様の色だけでそのカード達が「発」だとは言えません.";

                if (Text_moving == 8)
                    Text.GetComponent<Text>().text = "他の属性も満足しなければならないからです.";

                if (Text_moving == 9)
                    Text.GetComponent<Text>().text = "続きの属性を見ましょう.";
            }

            if (Text_moving == 10)
                step = 15;
        }

        if (step == 15)
        {
            if (Card[3].GetComponent<RectTransform>().localPosition.x == 700)
            {
                for (int i = 0; i < 3; i++)
                    for (int j = 0; j < 3; j++)
                        Card[i * 3 + j].GetComponent<RectTransform>().localPosition = new Vector3(-700 + 100 * j, Card[i * 3 + j].GetComponent<RectTransform>().localPosition.y, 0);

                step = 16;
            }

            else
            {
                if (!Stopthis)
                {
                    for (int i = 0; i < 3; i++)
                        Card[3 + i].GetComponent<RectTransform>().localPosition = new Vector3(Card[i + 3].GetComponent<RectTransform>().localPosition.x + 10, 80, 0);

                    for (int i = 0; i < 3; i++)
                        Card[6 + i].GetComponent<RectTransform>().localPosition = new Vector3(Card[i + 6].GetComponent<RectTransform>().localPosition.x + 10, -30, 0);
                }

                else
                {
                    for (int i = 0; i < 3; i++)
                        Card[3 + i].GetComponent<RectTransform>().localPosition = new Vector3(Card[i + 3].GetComponent<RectTransform>().localPosition.x, 80, 0);

                    for (int i = 0; i < 3; i++)
                        Card[6 + i].GetComponent<RectTransform>().localPosition = new Vector3(Card[i + 6].GetComponent<RectTransform>().localPosition.x, -30, 0);
                }
            }
        }

        if (step == 16)
        {
            if (Card[3].GetComponent<RectTransform>().localPosition.x == -100)
            {
                for (int i = 0; i < 6; i++)
                    Card[3 + i].GetComponent<RectTransform>().localPosition = new Vector3(Card[i + 3].GetComponent<RectTransform>().localPosition.x, Card[i + 3].GetComponent<RectTransform>().localPosition.y, 0);

                Text_moving = 0;
                step = 17;
            }

            else
            {
                Card[3].GetComponent<Image>().sprite = GameImage[13];
                Card[4].GetComponent<Image>().sprite = GameImage[31];
                Card[5].GetComponent<Image>().sprite = GameImage[49];
                Card[6].GetComponent<Image>().sprite = GameImage[142];
                Card[7].GetComponent<Image>().sprite = GameImage[156];
                Card[8].GetComponent<Image>().sprite = GameImage[107];

                if (!Stopthis)
                {
                    for (int i = 0; i < 3; i++)
                        Card[3 + i].GetComponent<RectTransform>().localPosition = new Vector3(Card[i + 3].GetComponent<RectTransform>().localPosition.x + 10, 80, 0);

                    for (int i = 0; i < 3; i++)
                        Card[6 + i].GetComponent<RectTransform>().localPosition = new Vector3(Card[i + 6].GetComponent<RectTransform>().localPosition.x + 10, -30, 0);
                }

                else
                {
                    for (int i = 0; i < 3; i++)
                        Card[3 + i].GetComponent<RectTransform>().localPosition = new Vector3(Card[i + 3].GetComponent<RectTransform>().localPosition.x, 80, 0);

                    for (int i = 0; i < 3; i++)
                        Card[6 + i].GetComponent<RectTransform>().localPosition = new Vector3(Card[i + 6].GetComponent<RectTransform>().localPosition.x, -30, 0);
                }
            }
        }

        if (step == 17)
        {

            if (Main_Scene.Language == 1)
            {
                if (Text_moving == 0)
                    Text.GetComponent<Text>().text = "마지막으로, 카드의 바탕색입니다.";

                if (Text_moving == 1)
                    Text.GetComponent<Text>().text = "9장의 카드들은 흰색, 검은색, 하얀색의 3가지 바탕색을 가지고 있습니다.";

                if (Text_moving == 2)
                    Text.GetComponent<Text>().text = "선택한 카드 3장이 합이기 위해선, 카드 3장의 바탕색 또한 모두 같거나, 모두 달라야합니다.";

                if (Text_moving == 3)
                    Text.GetComponent<Text>().text = "그 예로, 윗 줄의 3장의 카드는 모두 바탕색이 검은색으로 같고,";

                if (Text_moving == 4)
                    Text.GetComponent<Text>().text = "아래 줄의 3장의 카드는 모두 바탕색이 다르기 때문에";

                if (Text_moving == 5)
                    Text.GetComponent<Text>().text = "카드 3장이 '합'이 되기 위한 '바탕색의 속성'을 만족한다고 볼 수 있습니다.";

                if (Text_moving == 6)
                    Text.GetComponent<Text>().text = "하지만 '바탕색의 속성' 또한 마찬가지로";

                if (Text_moving == 7)
                    Text.GetComponent<Text>().text = "해당 속성만 만족한다고 해서 이 카드 3장이 '합'이라고 할 순 없습니다.";

                if (Text_moving == 8)
                    Text.GetComponent<Text>().text = "이는 앞서 설명한 '모양'과 '모양의 색'을 포함한 다른 속성들도";

                if (Text_moving == 9)
                    Text.GetComponent<Text>().text = " '합'의 조건을 만족해야 하기 때문입니다.";
            }

            else if (Main_Scene.Language == 2)
            {
                if (Text_moving == 0)
                    Text.GetComponent<Text>().text = "Finally, The Color of the Background.";

                if (Text_moving == 1)
                    Text.GetComponent<Text>().text = "Each Stage, those cards have one of the three colors of the background. ";

                if (Text_moving == 2)
                    Text.GetComponent<Text>().text = "The three of cards that you selected to be 'Find,' color of the background must be all the same or different.";

                if (Text_moving == 3)
                    Text.GetComponent<Text>().text = "For example, upside line of three cards have all the same color of the background,";

                if (Text_moving == 4)
                    Text.GetComponent<Text>().text = "the other line's cards are all different.";

                if (Text_moving == 5)
                    Text.GetComponent<Text>().text = "So, Each line of cards satisfies the 'Color of the Background attribute' to become 'Find.'";

                if (Text_moving == 6)
                    Text.GetComponent<Text>().text = "But like the others,";

                if (Text_moving == 7)
                    Text.GetComponent<Text>().text = "It doesn't mean that those cards are really 'Find.'";

                if (Text_moving == 8)
                    Text.GetComponent<Text>().text = "Because you have to check the 'Shape' and ";

                if (Text_moving == 9)
                    Text.GetComponent<Text>().text = "'Color of the Shape attribute' are satisfied too.";
            }

            else if (Main_Scene.Language == 3)
            {
                if (Text_moving == 0)
                    Text.GetComponent<Text>().text = "まず，カードの背景の色です.";

                if (Text_moving == 1)
                    Text.GetComponent<Text>().text = "九枚のカード達は三つの背景の色の中で一つを持ちます.";

                if (Text_moving == 2)
                    Text.GetComponent<Text>().text = "あなたが選んだ三つのカードが「発」になれるためには，そのカード達の背景の色が全部同じとか，全部違うじゃなければなりません.";

                if (Text_moving == 3)
                    Text.GetComponent<Text>().text = "その例で，上の三つのカード達の背景の色が全部同じで，";

                if (Text_moving == 4)
                    Text.GetComponent<Text>().text = "下の三つのカード達の背景の色は全部違うので";

                if (Text_moving == 5)
                    Text.GetComponent<Text>().text = "そのカード達は「発」になれるための「背景の色の属性」を満足したと言えます.";

                if (Text_moving == 6)
                    Text.GetComponent<Text>().text = "でも，「背景の色の属性」も同じ，";

                if (Text_moving == 7)
                    Text.GetComponent<Text>().text = "背景の色だけでそのカード達が「発」だとは言えません.";

                if (Text_moving == 8)
                    Text.GetComponent<Text>().text = "それは，前に説明した「模様の属性」と「模様の色の属性」も";

                if (Text_moving == 9)
                    Text.GetComponent<Text>().text = "満足しなければならないからです.";
            }

            if (Text_moving == 10)
                step = 18;
        }

        if (step == 18)
        {
            if (Card[3].GetComponent<RectTransform>().localPosition.x == 700)
            {
                for (int i = 0; i < 3; i++)
                    for (int j = 0; j < 3; j++)
                        Card[i * 3 + j].GetComponent<RectTransform>().localPosition = new Vector3(-700 + 100 * j, 110 - 90 * i, 0);

                step = 19;
            }

            else
            {
                if (!Stopthis)
                {
                    for (int i = 0; i < 3; i++)
                        Card[3 + i].GetComponent<RectTransform>().localPosition = new Vector3(Card[i + 3].GetComponent<RectTransform>().localPosition.x + 10, 80, 0);

                    for (int i = 0; i < 3; i++)
                        Card[6 + i].GetComponent<RectTransform>().localPosition = new Vector3(Card[i + 6].GetComponent<RectTransform>().localPosition.x + 10, -30, 0);
                }

                else
                {
                    for (int i = 0; i < 3; i++)
                        Card[3 + i].GetComponent<RectTransform>().localPosition = new Vector3(Card[i + 3].GetComponent<RectTransform>().localPosition.x, 80, 0);

                    for (int i = 0; i < 3; i++)
                        Card[6 + i].GetComponent<RectTransform>().localPosition = new Vector3(Card[i + 6].GetComponent<RectTransform>().localPosition.x, -30, 0);
                }
            }
        }

        if (step == 19)
        {
            if (Card[3].GetComponent<RectTransform>().localPosition.x == -100)
            {
                for (int i = 0; i < 9; i++)
                    Card[i].GetComponent<RectTransform>().localPosition = new Vector3(Card[i].GetComponent<RectTransform>().localPosition.x, Card[i].GetComponent<RectTransform>().localPosition.y, 0);

                Text_moving = 0;
                step = 20;
            }

            else
            {
                Card[0].GetComponent<Image>().sprite = GameImage[0];
                Card[1].GetComponent<Image>().sprite = GameImage[7];
                Card[2].GetComponent<Image>().sprite = GameImage[33];
                Card[3].GetComponent<Image>().sprite = GameImage[14];
                Card[4].GetComponent<Image>().sprite = GameImage[30];
                Card[5].GetComponent<Image>().sprite = GameImage[24];
                Card[6].GetComponent<Image>().sprite = GameImage[54];
                Card[7].GetComponent<Image>().sprite = GameImage[59];
                Card[8].GetComponent<Image>().sprite = GameImage[42];

                if (!Stopthis)
                {
                    for (int i = 0; i < 9; i++)
                        Card[i].GetComponent<RectTransform>().localPosition = new Vector3(Card[i].GetComponent<RectTransform>().localPosition.x + 10, Card[i].GetComponent<RectTransform>().localPosition.y, 0);
                }

                else
                {
                    for (int i = 0; i < 9; i++)
                        Card[i].GetComponent<RectTransform>().localPosition = new Vector3(Card[i].GetComponent<RectTransform>().localPosition.x, Card[i].GetComponent<RectTransform>().localPosition.y, 0);
                }
            }
        }

        if (step == 20)
        {
            if (Main_Scene.Language == 1)
            {
                if (Text_moving == 0)
                    Text.GetComponent<Text>().text = "이상으로 카드들이 가진 3가지의 속성에 대해 알아보았습니다.";

                if (Text_moving == 1)
                    Text.GetComponent<Text>().text = "요약한다면, 카드들의 성질인 '모양', '모양의 색', '바탕색'이 각각 모두 같거나,";

                if (Text_moving == 2)
                    Text.GetComponent<Text>().text = "모두 다른 것을 모두 만족한 카드 3장을 일컬어서";
            }

            else if (Main_Scene.Language == 2)
            {
                if (Text_moving == 0)
                    Text.GetComponent<Text>().text = "Now, We learned about Three attributes that each card has it.";

                if (Text_moving == 1)
                    Text.GetComponent<Text>().text = "In short, You have to check those attributes the cards that you selected three of them,";

                if (Text_moving == 2)
                    Text.GetComponent<Text>().text = "and each attribute are all the same or different,";
            }

            else if (Main_Scene.Language == 3)
            {
                if (Text_moving == 0)
                    Text.GetComponent<Text>().text = "以上でカードが持っている三つの属性のことを勉強してみました.";

                if (Text_moving == 1)
                    Text.GetComponent<Text>().text = "要略すると，あなたが選んだカード達の三つの属性がそれぞれ全部同じか，";

                if (Text_moving == 2)
                    Text.GetComponent<Text>().text = "全部違うかの「発の条件」を満足したなら";
            }

            if (Text_moving == 3)
                step = 21;
        }

        if (step == 21)
        {
            if (Card[8].GetComponent<Image>().color.a <= 0.15f)
            {
                for (int i = 0; i < 9; i++)
                    Card[i].GetComponent<Image>().color = new Color(Card[i].GetComponent<Image>().color.r, Card[i].GetComponent<Image>().color.g, Card[i].GetComponent<Image>().color.b, Card[i].GetComponent<Image>().color.a);

                Title.GetComponent<RectTransform>().localPosition = new Vector3(700, 219);
                Title.GetComponent<Image>().color = new Color(Title.GetComponent<Image>().color.r, Title.GetComponent<Image>().color.g, Title.GetComponent<Image>().color.b, 1);
                Text_moving = 0;
                step = 22;
            }

            else
            {
                if (!Stopthis)
                {
                    for (int i = 0; i < 9; i++)
                        if (i != 0 && i != 1 && i != 3)
                            Card[i].GetComponent<Image>().color = new Color(Card[i].GetComponent<Image>().color.r, Card[i].GetComponent<Image>().color.g, Card[i].GetComponent<Image>().color.b, Card[i].GetComponent<Image>().color.a - 0.01f);
                }

                else
                {
                    for (int i = 0; i < 9; i++)
                        if (i != 0 && i != 1 && i != 3)
                            Card[i].GetComponent<Image>().color = new Color(Card[i].GetComponent<Image>().color.r, Card[i].GetComponent<Image>().color.g, Card[i].GetComponent<Image>().color.b, Card[i].GetComponent<Image>().color.a);
                }
            }
        }

        if (step == 22)
        {
            if (Player.GetComponent<RectTransform>().localPosition.x == 0)
            {
                for (int i = 0; i < 9; i++)
                    Card[i].GetComponent<Image>().color = new Color(Card[i].GetComponent<Image>().color.r, Card[i].GetComponent<Image>().color.g, Card[i].GetComponent<Image>().color.b, Card[i].GetComponent<Image>().color.a);

                Text_moving = 0;
                step = 23;
            }

            else
            {
                if (Main_Scene.Language == 1)
                {
                    Title.GetComponent<RectTransform>().sizeDelta = new Vector3(245, 114);
                    Title.GetComponent<RectTransform>().localScale = new Vector3(0.5f, 0.5f);
                    Title.GetComponent<Image>().sprite = Type[10];
                }

                else if (Main_Scene.Language == 2)
                {
                    Title.GetComponent<RectTransform>().sizeDelta = new Vector3(251, 101);
                    Title.GetComponent<RectTransform>().localScale = new Vector3(0.5f, 0.5f);
                    Title.GetComponent<Image>().sprite = Type[20];
                }

                else if (Main_Scene.Language == 3)
                {
                    Title.GetComponent<RectTransform>().sizeDelta = new Vector3(248, 107);
                    Title.GetComponent<RectTransform>().localScale = new Vector3(0.5f, 0.5f);
                    Title.GetComponent<Image>().sprite = Type[30];
                }

                if (!Stopthis)
                {
                    Title.GetComponent<RectTransform>().localPosition = new Vector3(Title.GetComponent<RectTransform>().localPosition.x - 50, Title.GetComponent<RectTransform>().localPosition.y, 0);
                    Player.GetComponent<RectTransform>().localPosition = new Vector3(Player.GetComponent<RectTransform>().localPosition.x - 50, Player.GetComponent<RectTransform>().localPosition.y, 0);
                }

                else
                {
                    Title.GetComponent<RectTransform>().localPosition = new Vector3(Title.GetComponent<RectTransform>().localPosition.x, Title.GetComponent<RectTransform>().localPosition.y, 0);
                    Player.GetComponent<RectTransform>().localPosition = new Vector3(Player.GetComponent<RectTransform>().localPosition.x, Player.GetComponent<RectTransform>().localPosition.y, 0);
                }
            }
        }

        if (step == 23)
        {
            if (Main_Scene.Language == 1)
            {
                if (Text_moving == 0)
                    Text.GetComponent<Text>().text = "'합'이라고 합니다.";

                if (Text_moving == 1)
                    Text.GetComponent<Text>().text = "또 한 번 예시를 들자면,\n위의 3개의 선택된 카드들은";

                if (Text_moving == 2)
                    Text.GetComponent<Text>().text = "모양이 모두 같고, 모양의 색이 모두 같고, 바탕색이 모두 달라";

                if (Text_moving == 3)
                    Text.GetComponent<Text>().text = "각각의 성질에 따른 '합의 속성'을 모두 충족하였기 때문에";

                if (Text_moving == 4)
                    Text.GetComponent<Text>().text = "'합'이라고 볼 수 있습니다.";

                if (Text_moving == 5)
                    Text.GetComponent<Text>().text = "'합'을 성공할 때마다 여러분은 1점을 얻게 되지만,";

                if (Text_moving == 6)
                    Text.GetComponent<Text>().text = "'합'이 아니거나 답이 '중복'일 경우엔 -1점을 얻게 됩니다.";

                if (Text_moving == 7)
                    Text.GetComponent<Text>().text = "때문에 여러분은, 합을 선언할 때 신중하게 선언을 해야할 것입니다.";

                if (Text_moving == 8)
                    Text.GetComponent<Text>().text = "하지만 합을 선언할 때 너무 시간을 지체하면 다른 사람에게 기회가 넘어가버리므로";

                if (Text_moving == 9)
                    Text.GetComponent<Text>().text = "둘이서 플레이할 땐 자신에게 주어진 시간을 확인하면서 플레이를 해야합니다.";
            }

            else if (Main_Scene.Language == 2)
            {
                if (Text_moving == 0)
                    Text.GetComponent<Text>().text = "Those cards call 'Find.'";

                if (Text_moving == 1)
                    Text.GetComponent<Text>().text = "May I explain one more time?";

                if (Text_moving == 2)
                    Text.GetComponent<Text>().text = "Those three cards that I selected have all the same 'Shape,' and 'Color of the Shape,'";

                if (Text_moving == 3)
                    Text.GetComponent<Text>().text = "and all of 'Color of the Background' are different.";

                if (Text_moving == 4)
                    Text.GetComponent<Text>().text = "So we can call those cards are satisfied with really 'Find.' ";

                if (Text_moving == 5)
                    Text.GetComponent<Text>().text = "When you succeed to find 'Find,' you've got one point.";

                if (Text_moving == 6)
                    Text.GetComponent<Text>().text = "When it's not, or it already declared, you've got minus one point.";

                if (Text_moving == 7)
                    Text.GetComponent<Text>().text = "That means You have to be clear when you declare 'Find.'";

                if (Text_moving == 8)
                    Text.GetComponent<Text>().text = "But if you're too late to declare it, your chance will pass to someone else.";

                if (Text_moving == 9)
                    Text.GetComponent<Text>().text = "Please check your time when you are playing.";
            }

            else if (Main_Scene.Language == 3)
            {
                if (Text_moving == 0)
                    Text.GetComponent<Text>().text = "そのカード達を「発」だと言えます．";

                if (Text_moving == 1)
                    Text.GetComponent<Text>().text = "まださらに例をすれば，今私が選んだこの三つのカード達は";

                if (Text_moving == 2)
                    Text.GetComponent<Text>().text = "模様が全部同じで，模様の色も全部同じだが，背景の色は全部違います.";

                if (Text_moving == 3)
                    Text.GetComponent<Text>().text = "それぞれの性質による「発の条件」を満足したので";

                if (Text_moving == 4)
                    Text.GetComponent<Text>().text = "「発」だということができます.";

                if (Text_moving == 5)
                    Text.GetComponent<Text>().text = "「発」を成功すれば一点を貰いますが";

                if (Text_moving == 6)
                    Text.GetComponent<Text>().text = "失敗したとか，重複したなら一点を失います.";

                if (Text_moving == 7)
                    Text.GetComponent<Text>().text = "なので皆さんは，「発」を宣言する時，もっと慎重にしなきゃいけません.";

                if (Text_moving == 8)
                    Text.GetComponent<Text>().text = "だからって「発」を宣言する時間がかかり過ぎたら，ターンを他のプレイヤーに渡しますので";

                if (Text_moving == 9)
                    Text.GetComponent<Text>().text = "今自分の時間を確認するのも大事です.";
            }

            if (Text_moving == 10)
                step = 24;
        }

        if (step == 24)
        {
            if (Card[8].GetComponent<Image>().color.a > 1)
            {
                for (int i = 0; i < 9; i++)
                    Card[i].GetComponent<Image>().color = new Color(Card[i].GetComponent<Image>().color.r, Card[i].GetComponent<Image>().color.g, Card[i].GetComponent<Image>().color.b, 1);

                Title.GetComponent<RectTransform>().localPosition = new Vector3(700, Title.GetComponent<RectTransform>().localPosition.y, 0);
                Player.GetComponent<RectTransform>().localPosition = new Vector3(700, Player.GetComponent<RectTransform>().localPosition.y, 0);
                step = 25;
            }

            else
            {
                if (!Stopthis)
                {
                    for (int i = 0; i < 9; i++)
                        Card[i].GetComponent<Image>().color = new Color(Card[i].GetComponent<Image>().color.r, Card[i].GetComponent<Image>().color.g, Card[i].GetComponent<Image>().color.b, Card[i].GetComponent<Image>().color.a + 0.07f);

                    Title.GetComponent<RectTransform>().localPosition = new Vector3(Title.GetComponent<RectTransform>().localPosition.x - 50, Title.GetComponent<RectTransform>().localPosition.y, 0);
                    Player.GetComponent<RectTransform>().localPosition = new Vector3(Player.GetComponent<RectTransform>().localPosition.x - 50, Player.GetComponent<RectTransform>().localPosition.y, 0);

                }

                else
                {
                    for (int i = 0; i < 9; i++)
                        Card[i].GetComponent<Image>().color = new Color(Card[i].GetComponent<Image>().color.r, Card[i].GetComponent<Image>().color.g, Card[i].GetComponent<Image>().color.b, Card[i].GetComponent<Image>().color.a);

                    Title.GetComponent<RectTransform>().localPosition = new Vector3(Title.GetComponent<RectTransform>().localPosition.x, Title.GetComponent<RectTransform>().localPosition.y, 0);
                    Player.GetComponent<RectTransform>().localPosition = new Vector3(Player.GetComponent<RectTransform>().localPosition.x, Player.GetComponent<RectTransform>().localPosition.y, 0);

                }
            }
        }

        if (step == 25)
        {
                if (Main_Scene.Language == 1)
                    Text.GetComponent<Text>().text = "각 게임마다 '합'은 다양하게 있습니다.";

                else if (Main_Scene.Language == 2)
                    Text.GetComponent<Text>().text = "Each stage, There is many 'Find' that you have to find.";

                else if (Main_Scene.Language == 3)
                    Text.GetComponent<Text>().text = "各ステージにある「発」は多様にあります.";

            step = 26;
        }

        if (step == 26)
        {
            if (step2 == 0)
            {
                if (Card[5].GetComponent<Image>().color.a <= 0.15f)
                {
                    for (int i = 0; i < 9; i++)
                        Card[i].GetComponent<Image>().color = new Color(Card[i].GetComponent<Image>().color.r, Card[i].GetComponent<Image>().color.g, Card[i].GetComponent<Image>().color.b, Card[i].GetComponent<Image>().color.a);

                    Title.GetComponent<RectTransform>().localPosition = new Vector3(700, 219);
                    Title.GetComponent<Image>().color = new Color(Title.GetComponent<Image>().color.r, Title.GetComponent<Image>().color.g, Title.GetComponent<Image>().color.b, 1);
                    step2 = 1;
                }

                else
                {
                    if (!Stopthis)
                    {
                        for (int i = 0; i < 9; i++)
                            if (i != 6 && i != 7 && i != 8)
                                Card[i].GetComponent<Image>().color = new Color(Card[i].GetComponent<Image>().color.r, Card[i].GetComponent<Image>().color.g, Card[i].GetComponent<Image>().color.b, Card[i].GetComponent<Image>().color.a - 0.03f);

                    }

                    else
                    {
                        for (int i = 0; i < 9; i++)
                            if (i != 6 && i != 7 && i != 8)
                                Card[i].GetComponent<Image>().color = new Color(Card[i].GetComponent<Image>().color.r, Card[i].GetComponent<Image>().color.g, Card[i].GetComponent<Image>().color.b, Card[i].GetComponent<Image>().color.a);

                    }
                }
            }

            if (step2 == 1)
            {
                if (Player.GetComponent<RectTransform>().localPosition.x == 0)
                {
                    for (int i = 0; i < 9; i++)
                        Card[i].GetComponent<Image>().color = new Color(Card[i].GetComponent<Image>().color.r, Card[i].GetComponent<Image>().color.g, Card[i].GetComponent<Image>().color.b, Card[i].GetComponent<Image>().color.a);

                    Text_moving = 0;
                    step2 = 2;
                }

                else
                {
                    Title.GetComponent<RectTransform>().localPosition = new Vector3(Title.GetComponent<RectTransform>().localPosition.x - 12.5f, Title.GetComponent<RectTransform>().localPosition.y, 0);
                    Player.GetComponent<RectTransform>().localPosition = new Vector3(Player.GetComponent<RectTransform>().localPosition.x - 12.5f, Player.GetComponent<RectTransform>().localPosition.y, 0);
                }
            }

            if (step2 == 2)
            {
                if (Player.GetComponent<RectTransform>().localPosition.x <= -1f)
                {
                    for (int i = 0; i < 9; i++)
                        Card[i].GetComponent<Image>().color = new Color(Card[i].GetComponent<Image>().color.r, Card[i].GetComponent<Image>().color.g, Card[i].GetComponent<Image>().color.b, Card[i].GetComponent<Image>().color.a);

                    Text_moving = 0;
                    step2 = 3;
                }

                else
                {
                    Player.GetComponent<RectTransform>().localPosition = new Vector3(Player.GetComponent<RectTransform>().localPosition.x - 0.01f, Player.GetComponent<RectTransform>().localPosition.y, 0);
                }
            }

            if (step2 == 3)
            {
                if (Card[5].GetComponent<Image>().color.a > 1)
                {
                    for (int i = 0; i < 9; i++)
                        Card[i].GetComponent<Image>().color = new Color(Card[i].GetComponent<Image>().color.r, Card[i].GetComponent<Image>().color.g, Card[i].GetComponent<Image>().color.b, 1);

                    Title.GetComponent<RectTransform>().localPosition = new Vector3(700, Title.GetComponent<RectTransform>().localPosition.y, 0);
                    Player.GetComponent<RectTransform>().localPosition = new Vector3(700, Player.GetComponent<RectTransform>().localPosition.y, 0);
                    step2 = 4;
                }

                else
                {
                    for (int i = 0; i < 9; i++)
                        Card[i].GetComponent<Image>().color = new Color(Card[i].GetComponent<Image>().color.r, Card[i].GetComponent<Image>().color.g, Card[i].GetComponent<Image>().color.b, Card[i].GetComponent<Image>().color.a + 0.03f);

                    Title.GetComponent<RectTransform>().localPosition = new Vector3(Title.GetComponent<RectTransform>().localPosition.x - 12.5f, Title.GetComponent<RectTransform>().localPosition.y, 0);
                    Player.GetComponent<RectTransform>().localPosition = new Vector3(Player.GetComponent<RectTransform>().localPosition.x - 12.5f, Player.GetComponent<RectTransform>().localPosition.y, 0);
                }
            }

            if (step2 == 4)
            {
                if (Card[8].GetComponent<Image>().color.a <= 0.15f)
                {
                    for (int i = 0; i < 9; i++)
                        Card[i].GetComponent<Image>().color = new Color(Card[i].GetComponent<Image>().color.r, Card[i].GetComponent<Image>().color.g, Card[i].GetComponent<Image>().color.b, Card[i].GetComponent<Image>().color.a);

                    Title.GetComponent<RectTransform>().localPosition = new Vector3(700, 219);
                    Title.GetComponent<Image>().color = new Color(Title.GetComponent<Image>().color.r, Title.GetComponent<Image>().color.g, Title.GetComponent<Image>().color.b, 1);
                    step2 = 5;
                }

                else
                {
                    for (int i = 0; i < 9; i++)
                        if (i != 1 && i != 4 && i != 6)
                            Card[i].GetComponent<Image>().color = new Color(Card[i].GetComponent<Image>().color.r, Card[i].GetComponent<Image>().color.g, Card[i].GetComponent<Image>().color.b, Card[i].GetComponent<Image>().color.a - 0.03f);
                }
            }

            if (step2 == 5)
            {
                if (Player.GetComponent<RectTransform>().localPosition.x == 0)
                {
                    for (int i = 0; i < 9; i++)
                        Card[i].GetComponent<Image>().color = new Color(Card[i].GetComponent<Image>().color.r, Card[i].GetComponent<Image>().color.g, Card[i].GetComponent<Image>().color.b, Card[i].GetComponent<Image>().color.a);

                    Text_moving = 0;
                    step2 = 6;
                }

                else
                {
                    Title.GetComponent<RectTransform>().localPosition = new Vector3(Title.GetComponent<RectTransform>().localPosition.x - 12.5f, Title.GetComponent<RectTransform>().localPosition.y, 0);
                    Player.GetComponent<RectTransform>().localPosition = new Vector3(Player.GetComponent<RectTransform>().localPosition.x - 12.5f, Player.GetComponent<RectTransform>().localPosition.y, 0);
                }
            }

            if (step2 == 6)
            {
                if (Player.GetComponent<RectTransform>().localPosition.x <= -1f)
                {
                    for (int i = 0; i < 9; i++)
                        Card[i].GetComponent<Image>().color = new Color(Card[i].GetComponent<Image>().color.r, Card[i].GetComponent<Image>().color.g, Card[i].GetComponent<Image>().color.b, Card[i].GetComponent<Image>().color.a);

                    Text_moving = 0;
                    step2 = 7;
                }

                else
                {
                    Player.GetComponent<RectTransform>().localPosition = new Vector3(Player.GetComponent<RectTransform>().localPosition.x - 0.01f, Player.GetComponent<RectTransform>().localPosition.y, 0);
                }
            }

            if (step2 == 7)
            {
                if (Card[8].GetComponent<Image>().color.a > 1)
                {
                    for (int i = 0; i < 9; i++)
                        Card[i].GetComponent<Image>().color = new Color(Card[i].GetComponent<Image>().color.r, Card[i].GetComponent<Image>().color.g, Card[i].GetComponent<Image>().color.b, 1);

                    Title.GetComponent<RectTransform>().localPosition = new Vector3(700, Title.GetComponent<RectTransform>().localPosition.y, 0);
                    Player.GetComponent<RectTransform>().localPosition = new Vector3(700, Player.GetComponent<RectTransform>().localPosition.y, 0);
                    step2 = 8;
                }

                else
                {
                    for (int i = 0; i < 9; i++)
                        Card[i].GetComponent<Image>().color = new Color(Card[i].GetComponent<Image>().color.r, Card[i].GetComponent<Image>().color.g, Card[i].GetComponent<Image>().color.b, Card[i].GetComponent<Image>().color.a + 0.03f);

                    Title.GetComponent<RectTransform>().localPosition = new Vector3(Title.GetComponent<RectTransform>().localPosition.x - 12.5f, Title.GetComponent<RectTransform>().localPosition.y, 0);
                    Player.GetComponent<RectTransform>().localPosition = new Vector3(Player.GetComponent<RectTransform>().localPosition.x - 12.5f, Player.GetComponent<RectTransform>().localPosition.y, 0);
                }
            }

            if (step2 == 8)
            {
                if (Card[8].GetComponent<Image>().color.a <= 0.15f)
                {
                    for (int i = 0; i < 9; i++)
                        Card[i].GetComponent<Image>().color = new Color(Card[i].GetComponent<Image>().color.r, Card[i].GetComponent<Image>().color.g, Card[i].GetComponent<Image>().color.b, Card[i].GetComponent<Image>().color.a);

                    Title.GetComponent<RectTransform>().localPosition = new Vector3(700, 219);
                    Title.GetComponent<Image>().color = new Color(Title.GetComponent<Image>().color.r, Title.GetComponent<Image>().color.g, Title.GetComponent<Image>().color.b, 1);
                    step2 = 9;
                }

                else
                {
                    for (int i = 0; i < 9; i++)
                        if (i != 3 && i != 5 && i != 6)
                            Card[i].GetComponent<Image>().color = new Color(Card[i].GetComponent<Image>().color.r, Card[i].GetComponent<Image>().color.g, Card[i].GetComponent<Image>().color.b, Card[i].GetComponent<Image>().color.a - 0.03f);
                }
            }

            if (step2 == 9)
            {
                if (Player.GetComponent<RectTransform>().localPosition.x == 0)
                {
                    for (int i = 0; i < 9; i++)
                        Card[i].GetComponent<Image>().color = new Color(Card[i].GetComponent<Image>().color.r, Card[i].GetComponent<Image>().color.g, Card[i].GetComponent<Image>().color.b, Card[i].GetComponent<Image>().color.a);

                    Text_moving = 0;
                    step2 = 10;
                }

                else
                {
                    Title.GetComponent<RectTransform>().localPosition = new Vector3(Title.GetComponent<RectTransform>().localPosition.x - 12.5f, Title.GetComponent<RectTransform>().localPosition.y, 0);
                    Player.GetComponent<RectTransform>().localPosition = new Vector3(Player.GetComponent<RectTransform>().localPosition.x - 12.5f, Player.GetComponent<RectTransform>().localPosition.y, 0);
                }
            }

            if (step2 == 10)
            {
                if (Player.GetComponent<RectTransform>().localPosition.x <= -1f)
                {
                    for (int i = 0; i < 9; i++)
                        Card[i].GetComponent<Image>().color = new Color(Card[i].GetComponent<Image>().color.r, Card[i].GetComponent<Image>().color.g, Card[i].GetComponent<Image>().color.b, Card[i].GetComponent<Image>().color.a);

                    Text_moving = 0;
                    step2 = 11;
                }

                else
                {
                    Player.GetComponent<RectTransform>().localPosition = new Vector3(Player.GetComponent<RectTransform>().localPosition.x - 0.01f, Player.GetComponent<RectTransform>().localPosition.y, 0);
                }
            }

            if (step2 == 11)
            {
                if (Card[8].GetComponent<Image>().color.a > 1)
                {
                    for (int i = 0; i < 9; i++)
                        Card[i].GetComponent<Image>().color = new Color(Card[i].GetComponent<Image>().color.r, Card[i].GetComponent<Image>().color.g, Card[i].GetComponent<Image>().color.b, 1);

                    Title.GetComponent<RectTransform>().localPosition = new Vector3(700, Title.GetComponent<RectTransform>().localPosition.y, 0);
                    Player.GetComponent<RectTransform>().localPosition = new Vector3(700, Player.GetComponent<RectTransform>().localPosition.y, 0);
                    step2 = 12;
                }

                else
                {
                    for (int i = 0; i < 9; i++)
                        Card[i].GetComponent<Image>().color = new Color(Card[i].GetComponent<Image>().color.r, Card[i].GetComponent<Image>().color.g, Card[i].GetComponent<Image>().color.b, Card[i].GetComponent<Image>().color.a + 0.03f);

                    Title.GetComponent<RectTransform>().localPosition = new Vector3(Title.GetComponent<RectTransform>().localPosition.x - 12.5f, Title.GetComponent<RectTransform>().localPosition.y, 0);
                    Player.GetComponent<RectTransform>().localPosition = new Vector3(Player.GetComponent<RectTransform>().localPosition.x - 12.5f, Player.GetComponent<RectTransform>().localPosition.y, 0);
                }
            }

            if (step2 == 12)
            {
                if (Card[8].GetComponent<Image>().color.a <= 0.15f)
                {
                    for (int i = 0; i < 9; i++)
                        Card[i].GetComponent<Image>().color = new Color(Card[i].GetComponent<Image>().color.r, Card[i].GetComponent<Image>().color.g, Card[i].GetComponent<Image>().color.b, Card[i].GetComponent<Image>().color.a);

                    Title.GetComponent<RectTransform>().localPosition = new Vector3(700, 219);
                    Title.GetComponent<Image>().color = new Color(Title.GetComponent<Image>().color.r, Title.GetComponent<Image>().color.g, Title.GetComponent<Image>().color.b, 1);
                    step2 = 13;
                }

                else
                {
                    for (int i = 0; i < 9; i++)
                        if (i != 0 && i != 4 && i != 7)
                            Card[i].GetComponent<Image>().color = new Color(Card[i].GetComponent<Image>().color.r, Card[i].GetComponent<Image>().color.g, Card[i].GetComponent<Image>().color.b, Card[i].GetComponent<Image>().color.a - 0.03f);
                }
            }

            if (step2 == 13)
            {
                if (Player.GetComponent<RectTransform>().localPosition.x == 0)
                {
                    for (int i = 0; i < 9; i++)
                        Card[i].GetComponent<Image>().color = new Color(Card[i].GetComponent<Image>().color.r, Card[i].GetComponent<Image>().color.g, Card[i].GetComponent<Image>().color.b, Card[i].GetComponent<Image>().color.a);

                    Text_moving = 0;
                    step2 = 14;
                }

                else
                {
                    Title.GetComponent<RectTransform>().localPosition = new Vector3(Title.GetComponent<RectTransform>().localPosition.x - 12.5f, Title.GetComponent<RectTransform>().localPosition.y, 0);
                    Player.GetComponent<RectTransform>().localPosition = new Vector3(Player.GetComponent<RectTransform>().localPosition.x - 12.5f, Player.GetComponent<RectTransform>().localPosition.y, 0);
                }
            }

            if (step2 == 14)
            {
                if (Player.GetComponent<RectTransform>().localPosition.x <= -1f)
                {
                    for (int i = 0; i < 9; i++)
                        Card[i].GetComponent<Image>().color = new Color(Card[i].GetComponent<Image>().color.r, Card[i].GetComponent<Image>().color.g, Card[i].GetComponent<Image>().color.b, Card[i].GetComponent<Image>().color.a);

                    Text_moving = 0;
                    step2 = 15;
                }

                else
                {
                    Player.GetComponent<RectTransform>().localPosition = new Vector3(Player.GetComponent<RectTransform>().localPosition.x - 0.01f, Player.GetComponent<RectTransform>().localPosition.y, 0);
                }
            }

            if (step2 == 15)
            {
                if (Card[8].GetComponent<Image>().color.a > 1)
                {
                    for (int i = 0; i < 9; i++)
                        Card[i].GetComponent<Image>().color = new Color(Card[i].GetComponent<Image>().color.r, Card[i].GetComponent<Image>().color.g, Card[i].GetComponent<Image>().color.b, 1);

                    Title.GetComponent<RectTransform>().localPosition = new Vector3(700, Title.GetComponent<RectTransform>().localPosition.y, 0);
                    Player.GetComponent<RectTransform>().localPosition = new Vector3(700, Player.GetComponent<RectTransform>().localPosition.y, 0);
                    step2 = 0;
                    step = 27;
                }

                else
                {
                    for (int i = 0; i < 9; i++)
                        Card[i].GetComponent<Image>().color = new Color(Card[i].GetComponent<Image>().color.r, Card[i].GetComponent<Image>().color.g, Card[i].GetComponent<Image>().color.b, Card[i].GetComponent<Image>().color.a + 0.03f);

                    Title.GetComponent<RectTransform>().localPosition = new Vector3(Title.GetComponent<RectTransform>().localPosition.x - 12.5f, Title.GetComponent<RectTransform>().localPosition.y, 0);
                    Player.GetComponent<RectTransform>().localPosition = new Vector3(Player.GetComponent<RectTransform>().localPosition.x - 12.5f, Player.GetComponent<RectTransform>().localPosition.y, 0);
                }
            }
        }

        if (step == 27)
        {
            if (Main_Scene.Language == 1)
            {
                if (Text_moving == 0)
                    Text.GetComponent<Text>().text = "그리고 합의 개수나 카드의 배치, 모습은 매번 플레이할 때마다 달라집니다.";

                if (Text_moving == 1)
                    Text.GetComponent<Text>().text = "여러분이 주어진 카드들 중에서 '합'을 찾는 동안,";

                if (Text_moving == 2)
                    Text.GetComponent<Text>().text = "해당 카드들이 가진 합의 경우의 수는 점점 줄어들게 됩니다.";

                if (Text_moving == 3)
                    Text.GetComponent<Text>().text = "그리고 더 이상 '합'의 경우가 없는 때가 찾아옵니다.";

                if (Text_moving == 4)
                    Text.GetComponent<Text>().text = "이럴 때 여러분은,";
            }

            else if (Main_Scene.Language == 2)
            {
                if (Text_moving == 0)
                    Text.GetComponent<Text>().text = "Also, Feature of cards and number of 'Find,' are always different.";

                if (Text_moving == 1)
                    Text.GetComponent<Text>().text = "While you declare the 'Find,'";

                if (Text_moving == 2)
                    Text.GetComponent<Text>().text = "the number of 'Find' will decrease.";

                if (Text_moving == 3)
                    Text.GetComponent<Text>().text = "Eventually, There is a time that no 'Find' you can find.";

                if (Text_moving == 4)
                    Text.GetComponent<Text>().text = "This time, you have to declare:";
            }

            else if (Main_Scene.Language == 3)
            {
                if (Text_moving == 0)
                    Text.GetComponent<Text>().text = "そして「発」の数とか形は毎回プレイするたびに違います.";

                if (Text_moving == 1)
                    Text.GetComponent<Text>().text = "皆さんは設定されたカード達の中から「発」を探せるたびに";

                if (Text_moving == 2)
                    Text.GetComponent<Text>().text = "残された「発」の数はますます減ることになります.";

                if (Text_moving == 3)
                    Text.GetComponent<Text>().text = "そして，もう残された「発」がいない時が来ます.";

                if (Text_moving == 4)
                    Text.GetComponent<Text>().text = "こういう時，皆さんは";
            }

            if (Text_moving == 5)
            {
                G.GetComponent<RectTransform>().localPosition = new Vector3(700, G.GetComponent<RectTransform>().localPosition.y, 0);
                Title.GetComponent<RectTransform>().localPosition = new Vector3(700, 40, 0);
                Player.GetComponent<RectTransform>().localPosition = new Vector3(700, 40, 0);
                step = 28;
            }
        }

        if (step == 28)
        {
            if (G.GetComponent<RectTransform>().localPosition.x == 0)
            {
                Text_moving = 0;
                step = 29;
            }

            else
            {
                if (!Stopthis)
                {
                    H.GetComponent<RectTransform>().localPosition = new Vector3(H.GetComponent<RectTransform>().localPosition.x - 12.5f, H.GetComponent<RectTransform>().localPosition.y, 0);
                    G.GetComponent<RectTransform>().localPosition = new Vector3(G.GetComponent<RectTransform>().localPosition.x - 12.5f, G.GetComponent<RectTransform>().localPosition.y, 0);

                }

                else
                {
                    H.GetComponent<RectTransform>().localPosition = new Vector3(H.GetComponent<RectTransform>().localPosition.x, H.GetComponent<RectTransform>().localPosition.y, 0);
                    G.GetComponent<RectTransform>().localPosition = new Vector3(G.GetComponent<RectTransform>().localPosition.x, G.GetComponent<RectTransform>().localPosition.y, 0);

                }
            }
        }

        if (step == 29)
        {
            if (Main_Scene.Language == 1)
            {
                if (Text_moving == 0)
                    Text.GetComponent<Text>().text = "'결'을 선언할 수 있습니다.";

                if (Text_moving == 1)
                    Text.GetComponent<Text>().text = "'결'이란, 앞서 설명한 대로, 더 이상 '합'의 경우가 없을 때를 의미합니다.";

                if (Text_moving == 2)
                    Text.GetComponent<Text>().text = "만약 '결'을 실패하면 -1점을 얻게 되지만";
            }

            else if (Main_Scene.Language == 2)
            {
                if (Text_moving == 0)
                    Text.GetComponent<Text>().text = "This time, you have to declare: The 'Set.'";

                if (Text_moving == 1)
                    Text.GetComponent<Text>().text = "'Set' means,  Like I already said, 'No 'Find' to find in this stage.'";

                if (Text_moving == 2)
                    Text.GetComponent<Text>().text = "If you fail to declare 'Set,' you've got minus one point.";
            }

            else if (Main_Scene.Language == 3)
            {
                if (Text_moving == 0)
                    Text.GetComponent<Text>().text = "「決」を宣言することができます.";

                if (Text_moving == 1)
                    Text.GetComponent<Text>().text = "「決」は，言った通り，残された「発」がない場合を言います.";

                if (Text_moving == 2)
                    Text.GetComponent<Text>().text = "もし「決」を失敗したら一点を失われてしましますが，";
            }

            if (Text_moving == 3)
            {
                step = 30;
            }
        }

        if (step == 30)
        {
            if (Title.GetComponent<RectTransform>().localPosition.x == 0)
            {
                Text_moving = 0;
                step = 31;
            }

            else
            {
                Title.GetComponent<RectTransform>().sizeDelta = new Vector3(245, 114);
                

                if (!Stopthis)
                {
                    Title.GetComponent<RectTransform>().localPosition = new Vector3(Title.GetComponent<RectTransform>().localPosition.x - 12.5f, Title.GetComponent<RectTransform>().localPosition.y, 0);
                    Player.GetComponent<RectTransform>().localPosition = new Vector3(Player.GetComponent<RectTransform>().localPosition.x - 12.5f, Player.GetComponent<RectTransform>().localPosition.y, 0);
                }

                else
                {
                    Title.GetComponent<RectTransform>().localPosition = new Vector3(Title.GetComponent<RectTransform>().localPosition.x, Title.GetComponent<RectTransform>().localPosition.y, 0);
                    Player.GetComponent<RectTransform>().localPosition = new Vector3(Player.GetComponent<RectTransform>().localPosition.x, Player.GetComponent<RectTransform>().localPosition.y, 0);
                }
            }
        }

        if (step == 31)
        {
            if (Main_Scene.Language == 1)
            {
                if (Text_moving == 0)
                    Text.GetComponent<Text>().text = "'결'을 성공하면 3점을 얻으며 게임이 종료됩니다.";

                if (Text_moving == 1)
                    Text.GetComponent<Text>().text = "여러분은 합을 성공한 이후에 바로 결을 선택할 기회가 주어집니다.";

                if (Text_moving == 2)
                    Text.GetComponent<Text>().text = "따라서 합일 수 있는 모든 경우의 수를 그려가면서 게임을 진행해야할 것입니다.";

                if (Text_moving == 3)
                    Text.GetComponent<Text>().text = "여기까지 '결! 합!'에 대한 기본적인 설명이었습니다.";

                if (Text_moving == 4)
                    Text.GetComponent<Text>().text = "계속해서 이 게임이 가진 특수한 모드들에 대해서 설명하겠습니다.";
            }

            else if (Main_Scene.Language == 2)
            {
                if (Text_moving == 0)
                    Text.GetComponent<Text>().text = "But When you succeed at it, You'll get three points, and the game will be over.";

                if (Text_moving == 1)
                    Text.GetComponent<Text>().text = "You can declare 'Set' right after when succeed to declare 'Find.'";

                if (Text_moving == 2)
                    Text.GetComponent<Text>().text = "Which means You have to check there is no Find left to find.";

                if (Text_moving == 3)
                    Text.GetComponent<Text>().text = "That was the necessary explanation of 'Find or Set.'";

                if (Text_moving == 4)
                    Text.GetComponent<Text>().text = "Now let me introduce what game modes we have.";
            }

            else if (Main_Scene.Language == 3)
            {
                if (Text_moving == 0)
                    Text.GetComponent<Text>().text = "成功すれば三点を貰い、ゲームが終了します.";

                if (Text_moving == 1)
                    Text.GetComponent<Text>().text = "皆さんは「発」を成功した後，直ぐ「決」を宣言する機会が与えられます.";

                if (Text_moving == 2)
                    Text.GetComponent<Text>().text = "だから「決」の可能性も考えながらプレイしてください.";

                if (Text_moving == 3)
                    Text.GetComponent<Text>().text = "ここまでが「決! 発!」の基本的の\nルール説明でした.";

                if (Text_moving == 4)
                    Text.GetComponent<Text>().text = "続いてはこのゲームの特別なモードを紹介します.";
            }

            if (Text_moving == 5)
                step = 32;
        }

        if (step == 32)
        {
            if (Card[0].GetComponent<RectTransform>().localPosition.x == 700)
            {
                for (int i = 0; i < 2; i++)
                    for (int j = 0; j < 3; j++)
                        Card[i * 3 + j].GetComponent<RectTransform>().localPosition = new Vector3(-700 + 100 * j, 110 - 90 * i, 0);

                for (int i = 0; i < 4; i++)
                    Card[i].GetComponent<Image>().sprite = Main[44 + i];
                Card[4].GetComponent<Image>().sprite = Main[49];
                Card[5].GetComponent<Image>().sprite = Main[48];

                step = 33;
            }

            else
            {
                if (!Stopthis)
                {
                    G.GetComponent<RectTransform>().localPosition = new Vector3(G.GetComponent<RectTransform>().localPosition.x + 20, G.GetComponent<RectTransform>().localPosition.y, 0);
                    Player.GetComponent<RectTransform>().localPosition = new Vector3(Player.GetComponent<RectTransform>().localPosition.x - 50, Player.GetComponent<RectTransform>().localPosition.y, 0);
                    Title.GetComponent<RectTransform>().localPosition = new Vector3(Title.GetComponent<RectTransform>().localPosition.x - 50, Title.GetComponent<RectTransform>().localPosition.y, 0);

                    for (int i = 0; i < 9; i++)
                        Card[i].GetComponent<RectTransform>().localPosition = new Vector3(Card[i].GetComponent<RectTransform>().localPosition.x + 20, Card[i].GetComponent<RectTransform>().localPosition.y, 0);
                }

                else
                {
                    G.GetComponent<RectTransform>().localPosition = new Vector3(G.GetComponent<RectTransform>().localPosition.x, G.GetComponent<RectTransform>().localPosition.y, 0);
                    Player.GetComponent<RectTransform>().localPosition = new Vector3(Player.GetComponent<RectTransform>().localPosition.x, Player.GetComponent<RectTransform>().localPosition.y, 0);
                    Title.GetComponent<RectTransform>().localPosition = new Vector3(Title.GetComponent<RectTransform>().localPosition.x, Title.GetComponent<RectTransform>().localPosition.y, 0);

                    for (int i = 0; i < 9; i++)
                        Card[i].GetComponent<RectTransform>().localPosition = new Vector3(Card[i].GetComponent<RectTransform>().localPosition.x, Card[i].GetComponent<RectTransform>().localPosition.y, 0);
                }
            }
        }

        if (step == 33)
        {
            if (Card[0].GetComponent<RectTransform>().localPosition.x == -100)
            {
                Text_moving = 0;
                step2 = 0;
                step = 34;
            }

            else
            {
                if (!Stopthis)
                {
                    for (int i = 0; i < 6; i++)
                        Card[i].GetComponent<RectTransform>().localPosition = new Vector3(Card[i].GetComponent<RectTransform>().localPosition.x + 20, Card[i].GetComponent<RectTransform>().localPosition.y, 0);

                }

                else
                {
                    for (int i = 0; i < 6; i++)
                        Card[i].GetComponent<RectTransform>().localPosition = new Vector3(Card[i].GetComponent<RectTransform>().localPosition.x, Card[i].GetComponent<RectTransform>().localPosition.y, 0);

                }
            }
        }

        if (step == 34)
        {
            if (Main_Scene.Language == 1)
            {
                if (Text_moving == 0)
                    Text.GetComponent<Text>().text = "이 게임은 총 3가지의 특수한 모드들이 존재합니다.";
            }

            else if (Main_Scene.Language == 2)
            {
                if (Text_moving == 0)
                    Text.GetComponent<Text>().text = "This game has' normal mode,' and three more special modes.";
            }

            else if (Main_Scene.Language == 3)
            {
                if (Text_moving == 0)
                    Text.GetComponent<Text>().text = "このゲームは全三つの特別なモードがあります.";
            }

            if (Text_moving == 1)
            {
                Text_moving = 0;
                step2 = 0;
                step = 35;
            }
        }

        if (step == 35)
        {
            if (step2 == 0)
            {
                if (Card[0].GetComponent<Image>().color.a <= 0.15f)
                {
                    Card[0].GetComponent<Image>().color = new Color(Card[0].GetComponent<Image>().color.r, Card[0].GetComponent<Image>().color.g, Card[0].GetComponent<Image>().color.b, Card[0].GetComponent<Image>().color.a);
                    step2 = 1;
                }

                else
                {
                    Card[0].GetComponent<Image>().sprite = Main[50];

                    if (!Stopthis)
                        Card[0].GetComponent<Image>().color = new Color(Card[0].GetComponent<Image>().color.r, Card[0].GetComponent<Image>().color.g, Card[0].GetComponent<Image>().color.b, Card[0].GetComponent<Image>().color.a - 0.005f);

                    else
                        Card[0].GetComponent<Image>().color = new Color(Card[0].GetComponent<Image>().color.r, Card[0].GetComponent<Image>().color.g, Card[0].GetComponent<Image>().color.b, Card[0].GetComponent<Image>().color.a);
                }
            }

            if (step2 == 1)
            {
                if (Card[0].GetComponent<Image>().color.a >= 1f)
                {
                    Card[0].GetComponent<Image>().color = new Color(Card[0].GetComponent<Image>().color.r, Card[0].GetComponent<Image>().color.g, Card[0].GetComponent<Image>().color.b, Card[0].GetComponent<Image>().color.a);

                    if (Text_moving >= 4)
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            int num = Random.Range(0, 3);

                            if (num == 0)
                            {
                                Card[i + 1].GetComponent<Image>().sprite = GameImage[168];
                            }

                            else
                            {
                                if (i < 3)
                                    Card[i + 1].GetComponent<Image>().sprite = Main[45 + i];

                                else if (i == 3)
                                    Card[4].GetComponent<Image>().sprite = Main[49];

                                else if (i == 4)
                                    Card[5].GetComponent<Image>().sprite = Main[48];
                            }
                        }
                    }
                    step2 = 0;
                }

                else
                {
                    if (!Stopthis)
                        Card[0].GetComponent<Image>().color = new Color(Card[0].GetComponent<Image>().color.r, Card[0].GetComponent<Image>().color.g, Card[0].GetComponent<Image>().color.b, Card[0].GetComponent<Image>().color.a + 0.005f);

                    else
                        Card[0].GetComponent<Image>().color = new Color(Card[0].GetComponent<Image>().color.r, Card[0].GetComponent<Image>().color.g, Card[0].GetComponent<Image>().color.b, Card[0].GetComponent<Image>().color.a);
                }
            }

            if (Main_Scene.Language == 1)
            {
                if (Text_moving == 0)
                    Text.GetComponent<Text>().text = "먼저, '가림막'모드는 카드들의 일부를 가려 게임 진행에 어려움을 줍니다.";

                if (Text_moving == 1)
                    Text.GetComponent<Text>().text = "위 모드는 게임이 시작되기 전에 모든 카드들을 미리 보여줍니다.";

                if (Text_moving == 2)
                    Text.GetComponent<Text>().text = "그리고 일정 시간이 지나면 일부의 카드들을 가린 후 게임을 시작합니다.";

                if (Text_moving == 3)
                    Text.GetComponent<Text>().text = "따라서 위 모드를 플레이할 땐 어떤 카드가 있었는지 떠올려야 할 것입니다.";

                if (Text_moving == 4)
                    Text.GetComponent<Text>().text = "이후 '합'과 '결'을 선언하거나 시간초과되어 플레이어가 전환되거나";

                if (Text_moving == 5)
                    Text.GetComponent<Text>().text = "일정한 시간이 지나면, 카드들의 가림막 여부가 재배치됩니다.";
            }

            else if (Main_Scene.Language == 2)
            {
                if (Text_moving == 0)
                    Text.GetComponent<Text>().text = "The 'Hide Mode' will hide some of the cards in each stage.";

                if (Text_moving == 1)
                    Text.GetComponent<Text>().text = "This mode will show all the cards before the game begin.";

                if (Text_moving == 2)
                    Text.GetComponent<Text>().text = "And When it starts, some of the cards will be blocked.";

                if (Text_moving == 3)
                    Text.GetComponent<Text>().text = "So you have to remember which cards were they.";

                if (Text_moving == 4)
                    Text.GetComponent<Text>().text = "When the player is changing or after a certain amount of time,";

                if (Text_moving == 5)
                    Text.GetComponent<Text>().text = "cards will be relocated of blocking or revealing.";
            }

            else if (Main_Scene.Language == 3)
            {
                if (Text_moving == 0)
                    Text.GetComponent<Text>().text = "まず，「隠しモード」はカードを隠し，ゲームをするモードです.";

                if (Text_moving == 1)
                    Text.GetComponent<Text>().text = "このモードはゲームが始める前にあらかじめ全てのカードを見せます.";

                if (Text_moving == 2)
                    Text.GetComponent<Text>().text = "そして，一定時間が過ぎたら，あるカード達を隠しゲームを始めます.";

                if (Text_moving == 3)
                    Text.GetComponent<Text>().text = "なのでこのモードをプレイするためにはどんなカードがどこにあったのか思いださなきゃならないのです.";

                if (Text_moving == 4)
                    Text.GetComponent<Text>().text = "もしプレイヤ―が変わったり、一定時間が過ぎたら";

                if (Text_moving == 5)
                    Text.GetComponent<Text>().text = "カード達を隠すかどうかを再配置します.";
            }

            if (Text_moving == 6)
            {
                for (int i = 0; i < 6; i++)
                {
                    Card[i].GetComponent<Image>().sprite = Main[44 + i];
                    Card[i].GetComponent<Image>().color = new Color(Card[i].GetComponent<Image>().color.r, Card[i].GetComponent<Image>().color.g, Card[i].GetComponent<Image>().color.b, 1);
                }

                Card[4].GetComponent<Image>().sprite = Main[49];
                Card[5].GetComponent<Image>().sprite = Main[48];

                Lightmode = true;
                LightStart = true;
                Text_moving = 0;
                step = 36;
            }
        }

        if (step == 36)
        {
            if (step3 == 0)
            {
                if (Card[1].GetComponent<Image>().color.a <= 0.15f)
                {
                    Card[1].GetComponent<Image>().color = new Color(Card[1].GetComponent<Image>().color.r, Card[1].GetComponent<Image>().color.g, Card[1].GetComponent<Image>().color.b, Card[1].GetComponent<Image>().color.a);
                    step3 = 1;
                }

                else
                {
                    Card[1].GetComponent<Image>().sprite = Main[51];
                    if (!Stopthis)
                        Card[1].GetComponent<Image>().color = new Color(Card[1].GetComponent<Image>().color.r, Card[1].GetComponent<Image>().color.g, Card[1].GetComponent<Image>().color.b, Card[1].GetComponent<Image>().color.a - 0.005f);

                    else
                        Card[1].GetComponent<Image>().color = new Color(Card[1].GetComponent<Image>().color.r, Card[1].GetComponent<Image>().color.g, Card[1].GetComponent<Image>().color.b, Card[1].GetComponent<Image>().color.a);
                }
            }

            if (step3 == 1)
            {
                if (Card[1].GetComponent<Image>().color.a >= 1f)
                {
                    Card[1].GetComponent<Image>().color = new Color(Card[1].GetComponent<Image>().color.r, Card[1].GetComponent<Image>().color.g, Card[1].GetComponent<Image>().color.b, Card[1].GetComponent<Image>().color.a);

                    step3 = 0;
                }

                else
                {
                    if (!Stopthis)
                        Card[1].GetComponent<Image>().color = new Color(Card[1].GetComponent<Image>().color.r, Card[1].GetComponent<Image>().color.g, Card[1].GetComponent<Image>().color.b, Card[1].GetComponent<Image>().color.a + 0.005f);

                    else
                        Card[1].GetComponent<Image>().color = new Color(Card[1].GetComponent<Image>().color.r, Card[1].GetComponent<Image>().color.g, Card[1].GetComponent<Image>().color.b, Card[1].GetComponent<Image>().color.a);
                }
            }

            if (Main_Scene.Language == 1)
            {
                if (Text_moving == 0)
                    Text.GetComponent<Text>().text = "'전등 모드'는 게임이 시작됨과 동시에 전등이 켜져 좌우로 움직입니다.";

                if (Text_moving == 1)
                    Text.GetComponent<Text>().text = "전등이 계속해서 움직이기 때문에 시야가 가려 방해가 되고,";

                if (Text_moving == 2)
                    Text.GetComponent<Text>().text = "여러분들의 집중력을 흐트려놓을 것입니다.";

                if (Text_moving == 3)
                    Text.GetComponent<Text>().text = "따라서 '전등 모드'를 플레이할 땐 '가림막'과 같이 평소보다 더 많은 집중력이 요구됩니다.";
            }

            else if (Main_Scene.Language == 2)
            {
                if (Text_moving == 0)
                    Text.GetComponent<Text>().text = "The 'Light Mode' will give you lighting to show the cards.";

                if (Text_moving == 1)
                    Text.GetComponent<Text>().text = "The light will move around, that makes you can't see some of the cards.";

                if (Text_moving == 2)
                    Text.GetComponent<Text>().text = "Also, Your concentration will be cloud.";

                if (Text_moving == 3)
                    Text.GetComponent<Text>().text = "So You have to focus more than usual.";
            }

            else if (Main_Scene.Language == 3)
            {
                if (Text_moving == 0)
                    Text.GetComponent<Text>().text = "「ライトモード」はゲームの始まりと同時に電灯が入り，左右に動きます.";

                if (Text_moving == 1)
                    Text.GetComponent<Text>().text = "電灯がずっと動きますのでゲームの邪魔になれるとか";

                if (Text_moving == 2)
                    Text.GetComponent<Text>().text = "皆さんの集中力を壊せるとかします.";

                if (Text_moving == 3)
                    Text.GetComponent<Text>().text = "だから，このモードをプレイする時にはもっと集中力を上げてください.";
            }

            if (Text_moving == 4)
            {
                for (int i = 0; i < 6; i++)
                {
                    Card[i].GetComponent<Image>().sprite = Main[44 + i];
                    Card[i].GetComponent<Image>().color = new Color(Card[i].GetComponent<Image>().color.r, Card[i].GetComponent<Image>().color.g, Card[i].GetComponent<Image>().color.b, 1);
                }

                Card[4].GetComponent<Image>().sprite = Main[49];
                Card[5].GetComponent<Image>().sprite = Main[48];

                Lightmode = false;
                LightStart = false;
                Light.GetComponent<Image>().color = new Color(Light.GetComponent<Image>().color.r, Light.GetComponent<Image>().color.g, Light.GetComponent<Image>().color.b, 0f);
                Text_moving = 0;
                step2 = 0;
                step = 37;
            }
        }

        if (step == 37)
        {
            if (step2 == 0)
            {
                if (Card[2].GetComponent<Image>().color.a <= 0.15f)
                {
                    Card[2].GetComponent<Image>().color = new Color(Card[2].GetComponent<Image>().color.r, Card[2].GetComponent<Image>().color.g, Card[2].GetComponent<Image>().color.b, Card[2].GetComponent<Image>().color.a);
                    step2 = 1;
                }

                else
                {
                    Card[2].GetComponent<Image>().sprite = Main[52];
                    if (!Stopthis)
                        Card[2].GetComponent<Image>().color = new Color(Card[2].GetComponent<Image>().color.r, Card[2].GetComponent<Image>().color.g, Card[2].GetComponent<Image>().color.b, Card[2].GetComponent<Image>().color.a - 0.005f);

                    else
                        Card[2].GetComponent<Image>().color = new Color(Card[2].GetComponent<Image>().color.r, Card[2].GetComponent<Image>().color.g, Card[2].GetComponent<Image>().color.b, Card[2].GetComponent<Image>().color.a);
                }
            }

            if (step2 == 1)
            {
                if (Card[2].GetComponent<Image>().color.a >= 1f)
                {
                    Card[2].GetComponent<Image>().color = new Color(Card[2].GetComponent<Image>().color.r, Card[2].GetComponent<Image>().color.g, Card[2].GetComponent<Image>().color.b, Card[2].GetComponent<Image>().color.a);

                    step2 = 0;
                }

                else
                {
                    if (!Stopthis)
                        Card[2].GetComponent<Image>().color = new Color(Card[2].GetComponent<Image>().color.r, Card[2].GetComponent<Image>().color.g, Card[2].GetComponent<Image>().color.b, Card[2].GetComponent<Image>().color.a + 0.005f);

                    else
                        Card[2].GetComponent<Image>().color = new Color(Card[2].GetComponent<Image>().color.r, Card[2].GetComponent<Image>().color.g, Card[2].GetComponent<Image>().color.b, Card[2].GetComponent<Image>().color.a);
                }
            }

            if (Main_Scene.Language == 1)
            {
                if (Text_moving == 0)
                    Text.GetComponent<Text>().text = "'4x4모드'는 기존의 9개를 넘어 16개로 '결! 합!'을 하는 모드입니다.";

                if (Text_moving == 1)
                    Text.GetComponent<Text>().text = "3개의 모양으로는 9개의 카드들을 배치하는 데 경우의 수가 줄어들기 때문에";

                if (Text_moving == 2)
                    Text.GetComponent<Text>().text = "4x4모드는 4개의 모양으로 진행됩니다.";

                if (Text_moving == 3)
                    Text.GetComponent<Text>().text = "이 때문에 하나의 스테이지 당 가질 수 있는 '합'의 경우의 수는 무궁무진합니다.";

                if (Text_moving == 4)
                    Text.GetComponent<Text>().text = "따라서 모든 '합'을 찾을 때까지의 시간을 고려하여 15개로 개수가 제한 됩니다.";

                if (Text_moving == 5)
                    Text.GetComponent<Text>().text = "즉, 15개째의 합까지 찾으면 승부는 자동으로 종료됩니다.";

                if (Text_moving == 6)
                    Text.GetComponent<Text>().text = "그러나 만에 하나 합의 개수가 15개보다 적을 경우엔";

                if (Text_moving == 7)
                    Text.GetComponent<Text>().text = "'결'을 선언할 때까지 승부가 진행됩니다.";
            }

            else if (Main_Scene.Language == 2)
            {
                if (Text_moving == 0)
                    Text.GetComponent<Text>().text = "The '4×4 Mode' will give you seven cards more than usual.";

                if (Text_moving == 1)
                    Text.GetComponent<Text>().text = "In this mode, there are four 'Card Shape.'";

                if (Text_moving == 2)
                    Text.GetComponent<Text>().text = "And that makes you can find more 'Find' than usual.";

                if (Text_moving == 3)
                    Text.GetComponent<Text>().text = "That means you can see numerous 'Find' that You can't just imagine it.";

                if (Text_moving == 4)
                    Text.GetComponent<Text>().text = "So, Consider of time to be 'Set,' you can declare only 15 'Find' in each mode.";

                if (Text_moving == 5)
                    Text.GetComponent<Text>().text = "In short, When you find 15th 'Find,' the game will be over immediately.";

                if (Text_moving == 6)
                    Text.GetComponent<Text>().text = "But if there's less than 15,";

                if (Text_moving == 7)
                    Text.GetComponent<Text>().text = "The game doesn't over until you declare 'Set.'";
            }

            else if (Main_Scene.Language == 3)
            {
                if (Text_moving == 0)
                    Text.GetComponent<Text>().text = "「4x4モード」は全16個のカードでプレイします.";

                if (Text_moving == 1)
                    Text.GetComponent<Text>().text = "三つの模様ではこのモードでカード達を配置するのが少し困りますので";

                if (Text_moving == 2)
                    Text.GetComponent<Text>().text = "全四つの模様でプレイします.";

                if (Text_moving == 3)
                    Text.GetComponent<Text>().text = "なのでこのモードで見つける「発」の数は本当に沢山あります.";

                if (Text_moving == 4)
                    Text.GetComponent<Text>().text = "だから「決」を決める時間を考え，「発」を見つける数は15個で制限します.";

                if (Text_moving == 5)
                    Text.GetComponent<Text>().text = "すなわち，15めの「発」を見つけた同時にゲームは終了します.";

                if (Text_moving == 6)
                    Text.GetComponent<Text>().text = "だが，万が一，「発」の数が15個より少ないなら";

                if (Text_moving == 7)
                    Text.GetComponent<Text>().text = "「決」を宣言するまで勝負は続きます.";
            }

            if (Text_moving == 8)
            {
                for (int i = 0; i < 6; i++)
                {
                    Card[i].GetComponent<Image>().sprite = Main[44 + i];
                    Card[i].GetComponent<Image>().color = new Color(Card[i].GetComponent<Image>().color.r, Card[i].GetComponent<Image>().color.g, Card[i].GetComponent<Image>().color.b, 1);
                }

                Card[4].GetComponent<Image>().sprite = Main[49];
                Card[5].GetComponent<Image>().sprite = Main[48];

                Text_moving = 0;
                step = 38;
            }
        }

        if (step == 38)
        {
            if (step2 == 0)
            {
                if (Card[3].GetComponent<Image>().color.a <= 0.15f)
                {
                    Card[3].GetComponent<Image>().color = new Color(Card[3].GetComponent<Image>().color.r, Card[3].GetComponent<Image>().color.g, Card[3].GetComponent<Image>().color.b, Card[3].GetComponent<Image>().color.a);
                    step2 = 1;
                }

                else
                {
                    Card[3].GetComponent<Image>().sprite = Main[53];

                    if (!Stopthis)
                        Card[3].GetComponent<Image>().color = new Color(Card[3].GetComponent<Image>().color.r, Card[3].GetComponent<Image>().color.g, Card[3].GetComponent<Image>().color.b, Card[3].GetComponent<Image>().color.a - 0.005f);

                    else
                        Card[3].GetComponent<Image>().color = new Color(Card[3].GetComponent<Image>().color.r, Card[3].GetComponent<Image>().color.g, Card[3].GetComponent<Image>().color.b, Card[3].GetComponent<Image>().color.a);
                }
            }

            if (step2 == 1)
            {
                if (Card[3].GetComponent<Image>().color.a >= 1f)
                {
                    Card[3].GetComponent<Image>().color = new Color(Card[3].GetComponent<Image>().color.r, Card[3].GetComponent<Image>().color.g, Card[3].GetComponent<Image>().color.b, Card[3].GetComponent<Image>().color.a);

                    step2 = 0;
                }

                else
                {
                    if (!Stopthis)
                        Card[3].GetComponent<Image>().color = new Color(Card[3].GetComponent<Image>().color.r, Card[3].GetComponent<Image>().color.g, Card[3].GetComponent<Image>().color.b, Card[3].GetComponent<Image>().color.a + 0.005f);

                    else
                        Card[3].GetComponent<Image>().color = new Color(Card[3].GetComponent<Image>().color.r, Card[3].GetComponent<Image>().color.g, Card[3].GetComponent<Image>().color.b, Card[3].GetComponent<Image>().color.a);
                }
            }

            if (Main_Scene.Language == 1)
            {
                if (Text_moving == 0)
                    Text.GetComponent<Text>().text = "'합성'모드는 앞서 설명한 3개와 일반모드 중에 몇 개를 선택하여 동시에 플레이할 수 있습니다.";

                if (Text_moving == 1)
                    Text.GetComponent<Text>().text = "'가림막+전등', '가림막+4x4', '전등+4x4'...";

                if (Text_moving == 2)
                    Text.GetComponent<Text>().text = "심지어 3개를 모두 합쳐서 진행할 수도 있습니다.";

                if (Text_moving == 3)
                    Text.GetComponent<Text>().text = "이러한 합성은 여러분들의 플레이를 어렵게 만들 수 있습니다.";
            }

            else if (Main_Scene.Language == 2)
            {
                if (Text_moving == 0)
                    Text.GetComponent<Text>().text = "The 'Mix Mode' will give you to choose some of those modes and mix it.";

                if (Text_moving == 1)
                    Text.GetComponent<Text>().text = "Like, 'Hide + Light,' Or 'Hide + 4×4,' or 'Light + 4×4'...";

                if (Text_moving == 2)
                    Text.GetComponent<Text>().text = "Even all of the modes can be mixed.";

                if (Text_moving == 3)
                    Text.GetComponent<Text>().text = "These mixing will makes your play more difficult than ever.";
            }

            else if (Main_Scene.Language == 3)
            {
                if (Text_moving == 0)
                    Text.GetComponent<Text>().text = "「合成モード」は今まで説明した四つのモードから何個を選ぶことができます.";

                if (Text_moving == 1)
                    Text.GetComponent<Text>().text = "'隠し+ライト', '隠し+4x4', '電灯+4x4'...";

                if (Text_moving == 2)
                    Text.GetComponent<Text>().text = "そして，全てのモードを合成してプレイすることもできます.";

                if (Text_moving == 3)
                    Text.GetComponent<Text>().text = "この合成は皆さんのプレイを困難にすることができます.";
            }

            if (Text_moving == 4)
            {
                for (int i = 0; i < 6; i++)
                {
                    Card[i].GetComponent<Image>().sprite = Main[44 + i];
                    Card[i].GetComponent<Image>().color = new Color(Card[i].GetComponent<Image>().color.r, Card[i].GetComponent<Image>().color.g, Card[i].GetComponent<Image>().color.b, 1);
                }

                Card[4].GetComponent<Image>().sprite = Main[49];
                Card[5].GetComponent<Image>().sprite = Main[48];

                Text_moving = 0;
                step = 39;
            }
        }

        if (step == 39)
        {
            if (step2 == 0)
            {
                if (Card[4].GetComponent<Image>().color.a <= 0.15f)
                {
                    Card[4].GetComponent<Image>().color = new Color(Card[4].GetComponent<Image>().color.r, Card[4].GetComponent<Image>().color.g, Card[4].GetComponent<Image>().color.b, Card[4].GetComponent<Image>().color.a);
                    step2 = 1;
                }

                else
                {
                    Card[4].GetComponent<Image>().sprite = Main[55];

                    if (!Stopthis)
                        Card[4].GetComponent<Image>().color = new Color(Card[4].GetComponent<Image>().color.r, Card[4].GetComponent<Image>().color.g, Card[4].GetComponent<Image>().color.b, Card[4].GetComponent<Image>().color.a - 0.005f);

                    else
                        Card[4].GetComponent<Image>().color = new Color(Card[4].GetComponent<Image>().color.r, Card[4].GetComponent<Image>().color.g, Card[4].GetComponent<Image>().color.b, Card[4].GetComponent<Image>().color.a);
                }
            }

            if (step2 == 1)
            {
                if (Card[4].GetComponent<Image>().color.a >= 1f)
                {
                    Card[4].GetComponent<Image>().color = new Color(Card[4].GetComponent<Image>().color.r, Card[4].GetComponent<Image>().color.g, Card[4].GetComponent<Image>().color.b, Card[4].GetComponent<Image>().color.a);

                    step2 = 0;
                }

                else
                {
                    if (!Stopthis)
                        Card[4].GetComponent<Image>().color = new Color(Card[4].GetComponent<Image>().color.r, Card[4].GetComponent<Image>().color.g, Card[4].GetComponent<Image>().color.b, Card[4].GetComponent<Image>().color.a + 0.005f);

                    else
                        Card[4].GetComponent<Image>().color = new Color(Card[4].GetComponent<Image>().color.r, Card[4].GetComponent<Image>().color.g, Card[4].GetComponent<Image>().color.b, Card[4].GetComponent<Image>().color.a);
                }
            }

            if (Main_Scene.Language == 1)
            {
                if (Text_moving == 0)
                    Text.GetComponent<Text>().text = "'랜덤모드'는 앞서 설명한 모든 모드들 중 하나를 랜덤으로 선정합니다.";

                if (Text_moving == 1)
                    Text.GetComponent<Text>().text = "합성모드의 모든 경우까지 포함을 하고 있으므로";

                if (Text_moving == 2)
                    Text.GetComponent<Text>().text = "운이 안 좋다면 3개의 특수모드를 모두 합한 것을 플레이하게 될 수 있습니다.";
            }

            else if (Main_Scene.Language == 2)
            {
                if (Text_moving == 0)
                    Text.GetComponent<Text>().text = "The 'Random Mode' will choose one of the 'Mix Mode.'";

                if (Text_moving == 1)
                    Text.GetComponent<Text>().text = "If you're not lucky enough,";

                if (Text_moving == 2)
                    Text.GetComponent<Text>().text = "maybe you can play 'ALL SPECIAL MODES THAT MIXED.' ";
            }

            else if (Main_Scene.Language == 3)
            {
                if (Text_moving == 0)
                    Text.GetComponent<Text>().text = "「ランダムモード」は全ての「合成」の可能性の中でランダムに一つを選びます.";

                if (Text_moving == 1)
                    Text.GetComponent<Text>().text = "運が悪いなら三つの特別なモードが合成された";

                if (Text_moving == 2)
                    Text.GetComponent<Text>().text = "難しいモードをプレイする場合もあります.";
            }

            if (Text_moving == 3)
            {
                for (int i = 0; i < 6; i++)
                {
                    Card[i].GetComponent<Image>().sprite = Main[44 + i];
                    Card[i].GetComponent<Image>().color = new Color(Card[i].GetComponent<Image>().color.r, Card[i].GetComponent<Image>().color.g, Card[i].GetComponent<Image>().color.b, 1);
                }

                Card[4].GetComponent<Image>().sprite = Main[49];
                Card[5].GetComponent<Image>().sprite = Main[48];

                Text_moving = 0;
                step = 40;
            }
        }

        if (step == 40)
        {
            if (step2 == 0)
            {
                if (Card[5].GetComponent<Image>().color.a <= 0.15f)
                {
                    Card[5].GetComponent<Image>().color = new Color(Card[5].GetComponent<Image>().color.r, Card[5].GetComponent<Image>().color.g, Card[5].GetComponent<Image>().color.b, Card[5].GetComponent<Image>().color.a);
                    step2 = 1;
                }

                else
                {
                    Card[5].GetComponent<Image>().sprite = Main[54];

                    if (!Stopthis)
                        Card[5].GetComponent<Image>().color = new Color(Card[5].GetComponent<Image>().color.r, Card[5].GetComponent<Image>().color.g, Card[5].GetComponent<Image>().color.b, Card[5].GetComponent<Image>().color.a - 0.005f);

                    else
                        Card[5].GetComponent<Image>().color = new Color(Card[5].GetComponent<Image>().color.r, Card[5].GetComponent<Image>().color.g, Card[5].GetComponent<Image>().color.b, Card[5].GetComponent<Image>().color.a);
                }
            }

            if (step2 == 1)
            {
                if (Card[5].GetComponent<Image>().color.a >= 1f)
                {
                    Card[5].GetComponent<Image>().color = new Color(Card[5].GetComponent<Image>().color.r, Card[5].GetComponent<Image>().color.g, Card[5].GetComponent<Image>().color.b, Card[5].GetComponent<Image>().color.a);

                    step2 = 0;
                }

                else
                {
                    if (!Stopthis)
                        Card[5].GetComponent<Image>().color = new Color(Card[5].GetComponent<Image>().color.r, Card[5].GetComponent<Image>().color.g, Card[5].GetComponent<Image>().color.b, Card[5].GetComponent<Image>().color.a + 0.005f);

                    else
                        Card[5].GetComponent<Image>().color = new Color(Card[5].GetComponent<Image>().color.r, Card[5].GetComponent<Image>().color.g, Card[5].GetComponent<Image>().color.b, Card[5].GetComponent<Image>().color.a);
                }
            }

            if (Main_Scene.Language == 1)
            {
                if (Text_moving == 0)
                    Text.GetComponent<Text>().text = "마지막으로 '타임어택모드'는 1인연습모드에서만 플레이가 가능합니다.";

                if (Text_moving == 1)
                    Text.GetComponent<Text>().text = "위 모드는 제한된 시간 내에 선택한 스테이지와 모드들을 모두 클리어해야합니다.";

                if (Text_moving == 2)
                    Text.GetComponent<Text>().text = "이는 여러분이 '결! 합!'모드를 플레이하는 능력을 향상시켜줌과 동시에";

                if (Text_moving == 3)
                    Text.GetComponent<Text>().text = "여러분의 플레이 능력을 가늠할 수 있을 것입니다.";

                if (Text_moving == 4)
                    Text.GetComponent<Text>().text = "여기까지가 이 게임이 가진 응용모드들입니다.";

                if (Text_moving == 5)
                    Text.GetComponent<Text>().text = "하지만 여기가 끝이 아닙니다.";
            }

            else if (Main_Scene.Language == 2)
            {
                if (Text_moving == 0)
                    Text.GetComponent<Text>().text = "The 'Timeattack Mode' can play only in 'One Play Mode.'";

                if (Text_moving == 1)
                    Text.GetComponent<Text>().text = "In this mode, you can set times that you have to finish all the stages.";

                if (Text_moving == 2)
                    Text.GetComponent<Text>().text = "It will help you measure your ability to play 'Find or Set'";

                if (Text_moving == 3)
                    Text.GetComponent<Text>().text = " and also improve it.";

                if (Text_moving == 4)
                    Text.GetComponent<Text>().text = "So those are the special mode that we got,";

                if (Text_moving == 5)
                    Text.GetComponent<Text>().text = "But not the end.";
            }

            else if (Main_Scene.Language == 3)
            {
                if (Text_moving == 0)
                    Text.GetComponent<Text>().text = "「タイムアタックモード」は「一人で」プレイするたびに現れます.";

                if (Text_moving == 1)
                    Text.GetComponent<Text>().text = "このモードは時間を制限し，設定した全てのステージを全部クリアするモードでございます.";

                if (Text_moving == 2)
                    Text.GetComponent<Text>().text = "これは皆さんのゲーム能力を向上し";

                if (Text_moving == 3)
                    Text.GetComponent<Text>().text = "自分の立場も分かることができます.";

                if (Text_moving == 4)
                    Text.GetComponent<Text>().text = "ここまでがこのゲームが持っている特別なモードでした.";

                if (Text_moving == 5)
                    Text.GetComponent<Text>().text = "でもまだまだあります!";
            }

            if (Text_moving == 6)
            {
                for (int i = 0; i < 6; i++)
                {
                    Card[i].GetComponent<Image>().sprite = Main[44 + i];
                    Card[i].GetComponent<Image>().color = new Color(Card[i].GetComponent<Image>().color.r, Card[i].GetComponent<Image>().color.g, Card[i].GetComponent<Image>().color.b, 1);
                }

                Card[4].GetComponent<Image>().sprite = Main[49];
                Card[5].GetComponent<Image>().sprite = Main[48];

                Text_moving = 0;
                step = 41;
            }
        }

        if(step == 41)
        {
            if (Card[0].GetComponent<RectTransform>().localPosition.x == 700)
            {
                Card[1].GetComponent<RectTransform>().localPosition = new Vector3(-400, 50, 0);
                Card[1].GetComponent<Image>().sprite = GameImage2[9];
                Card[1].GetComponent<RectTransform>().sizeDelta = new Vector3(512, 512);
                Card[1].GetComponent<RectTransform>().localScale = new Vector3(0.5f, 0.5f);

                step = 42;
            }

            else
            {
                if (!Stopthis)
                {
                    for (int i = 0; i < 6; i++)
                        Card[i].GetComponent<RectTransform>().localPosition = new Vector3(Card[i].GetComponent<RectTransform>().localPosition.x + 20, Card[i].GetComponent<RectTransform>().localPosition.y, 0);

                }

                else
                {
                    for (int i = 0; i < 6; i++)
                        Card[i].GetComponent<RectTransform>().localPosition = new Vector3(Card[i].GetComponent<RectTransform>().localPosition.x, Card[i].GetComponent<RectTransform>().localPosition.y, 0);

                }
            }
        }

        if (step == 42)
        {
            if (Card[1].GetComponent<RectTransform>().localPosition.x == 0)
            {
                step = 43;
            }

            else
            {
                if (!Stopthis)
                    Card[1].GetComponent<RectTransform>().localPosition = new Vector3(Card[1].GetComponent<RectTransform>().localPosition.x + 20, Card[1].GetComponent<RectTransform>().localPosition.y, 0);

                else
                    Card[1].GetComponent<RectTransform>().localPosition = new Vector3(Card[1].GetComponent<RectTransform>().localPosition.x, Card[1].GetComponent<RectTransform>().localPosition.y, 0);
            }
        }

        if (step == 43)
        {
            if (Main_Scene.Language == 1)
            {
                if (Text_moving == 0)
                    Text.GetComponent<Text>().text = "이 게임은 앞서 설명한 모든 모드들을 응용한 9개의 챌린지 모드가 존재합니다.";

                if (Text_moving == 1)
                    Text.GetComponent<Text>().text = "챌린지는 기존에 있었던 모드들을 변형시켜 난이도를 높인 모드입니다.";

                if (Text_moving == 2)
                    Text.GetComponent<Text>().text = "따라서 어느정도 익숙하신 분들은 챌린지모드를 도전해보시기 바랍니다!";
            }

            else if (Main_Scene.Language == 2)
            {
                if (Text_moving == 0)
                    Text.GetComponent<Text>().text = "This game has a 'CHALLANGE MODE' which is modified to those special modes.";

                if (Text_moving == 1)
                    Text.GetComponent<Text>().text = "It will be difficult to success those level for beginners,";

                if (Text_moving == 2)
                    Text.GetComponent<Text>().text = "So I suggest that you should try it when you think that your ability is better than now!";
            }

            else if (Main_Scene.Language == 3)
            {
                if (Text_moving == 0)
                    Text.GetComponent<Text>().text = "このゲームはこの特別なモードをさらに応用した全9個のチャレンジモードがあります.";

                if (Text_moving == 1)
                    Text.GetComponent<Text>().text = "チャレンジモードは難易度が凄く高いので";

                if (Text_moving == 2)
                    Text.GetComponent<Text>().text = "少しゲームに慣れた人達のはぜひ挑戦してください!";

            }

            if (Text_moving == 3)
            {
                Text_moving = 0;
                step = 44;
            }
        }

        if (step == 44)
        {
            if (Card[1].GetComponent<RectTransform>().localPosition.x == 700)
            {
                if (Main_Scene.Language == 1)
                {
                    Title.GetComponent<Image>().sprite = Main[0];
                    Title.GetComponent<RectTransform>().localScale = new Vector3(1f, 1f);
                    Title.GetComponent<RectTransform>().sizeDelta = new Vector3(393, 135);
                }

                else if (Main_Scene.Language == 2)
                {
                    Title.GetComponent<Image>().sprite = Main[84];
                    Title.GetComponent<RectTransform>().sizeDelta = new Vector3(321, 161);
                    Title.GetComponent<RectTransform>().localScale = new Vector3(1.2f, 1.2f);
                }

                else if (Main_Scene.Language == 3)
                {
                    Title.GetComponent<Image>().sprite = Main[103];
                    Title.GetComponent<RectTransform>().localScale = new Vector3(1f, 1f);
                    Title.GetComponent<RectTransform>().sizeDelta = new Vector3(390, 138);
                }

                Title.GetComponent<RectTransform>().localPosition = new Vector3(0, 40, 0);
                Title.GetComponent<Image>().color = new Color(Title.GetComponent<Image>().color.r, Title.GetComponent<Image>().color.g, Title.GetComponent<Image>().color.b, 0);
                Title.GetComponent<RectTransform>().localScale = new Vector3(1f, 1f);
                step = 45;
            }

            else
            {
                if (!Stopthis)
                    Card[1].GetComponent<RectTransform>().localPosition = new Vector3(Card[1].GetComponent<RectTransform>().localPosition.x + 20, Card[1].GetComponent<RectTransform>().localPosition.y, 0);

                else
                    Card[1].GetComponent<RectTransform>().localPosition = new Vector3(Card[1].GetComponent<RectTransform>().localPosition.x, Card[1].GetComponent<RectTransform>().localPosition.y, 0);
            }
        }

        if (step == 45)
        {
            if (Title.GetComponent<Image>().color.a > 1)
                step = 46;

            else
            {
                if (!Stopthis)
                {
                    Title.GetComponent<Image>().color = new Color(Title.GetComponent<Image>().color.r, Title.GetComponent<Image>().color.g, Title.GetComponent<Image>().color.b, Title.GetComponent<Image>().color.a + 0.01f);
                    Title.GetComponent<RectTransform>().localScale = new Vector3(Title.GetComponent<RectTransform>().localScale.x - 0.01f / 3, Title.GetComponent<RectTransform>().localScale.y - 0.01f / 3, 0);
                }

                else
                {
                    Title.GetComponent<Image>().color = new Color(Title.GetComponent<Image>().color.r, Title.GetComponent<Image>().color.g, Title.GetComponent<Image>().color.b, Title.GetComponent<Image>().color.a);
                    Title.GetComponent<RectTransform>().localScale = new Vector3(Title.GetComponent<RectTransform>().localScale.x, Title.GetComponent<RectTransform>().localScale.y, 0);
                }
            }
        }

        if (step == 46)
        {
            if (Main_Scene.Language == 1)
            {
                if (Text_moving == 0)
                    Text.GetComponent<Text>().text = "지금까지 '결! 합!'에 대한 '게임 설명'이었습니다!";

                if (Text_moving == 1)
                    Text.GetComponent<Text>().text = "이 게임은 총 51개의 업적과 각 모드들에 대한 랭킹보드가 있습니다.";

                if (Text_moving == 2)
                    Text.GetComponent<Text>().text = "게임을 진행하다보면 다양한 모드들로부터 업적을 획득할 수 있고,";

                if (Text_moving == 3)
                    Text.GetComponent<Text>().text = "각각의 모드들에 따른 랭킹보드로 자신의 위치를 확인할 수 있을 것입니다.";

                if (Text_moving == 4)
                    Text.GetComponent<Text>().text = "너무 어려워서 도전하기 망설이시는 분들을 위해서";

                if (Text_moving == 5)
                    Text.GetComponent<Text>().text = "연속으로 틀리거나, 오랫동안 '합'을 외치지 못하면 '힌트'칸이 활성화되도록 설계되어 있으니";

                if (Text_moving == 6)
                    Text.GetComponent<Text>().text = "차근히 클리어해나가면서 '결! 합!'을 플레이하는 머리아픈 재미를 느껴주세요!";

                if (Text_moving == 7)
                {
                    Achive.AC[48]++;
                    Achive.Start_Achieve = true;
                    Text.GetComponent<Text>().text = "설명을 끝까지 봐주셔서 감사합니다.";
                }

                if (Text_moving == 8)
                    Text.GetComponent<Text>().text = "앗! 그러고보니, 업적 하나가 뜨지 않으셨나요?";

                if (Text_moving == 9)
                    Text.GetComponent<Text>().text = "이건 제가 여러분에게 주는 선물아닌 선물입니다♪";

                if (Text_moving == 10)
                    Text.GetComponent<Text>().text = "만약 설명이 이해가 안 가신 게 있다면, 다시 한 번 봐주세요!";

                if (Text_moving == 11)
                    Text.GetComponent<Text>().text = "게임을 다운받아주셔서 정말로 감사합니다!";

                if (Text_moving == 12)
                {
                    Adstart = true;
                    Text.GetComponent<Text>().text = "다음 버튼을 누르면 타이틀 화면으로 이동합니다.";
                }
            }

            else if (Main_Scene.Language == 2)
            {
                if (Text_moving == 0)
                    Text.GetComponent<Text>().text = "The tutorial of 'Find or Set' is ended!";

                if (Text_moving == 1)
                    Text.GetComponent<Text>().text = "This game has 51 Achievements and 14 Ranking Boards.";

                if (Text_moving == 2)
                    Text.GetComponent<Text>().text = "While you play this game, you can get many achievements in each mode.";

                if (Text_moving == 3)
                    Text.GetComponent<Text>().text = "And also, Ranking Boards of each mode will show your now ability.";

                if (Text_moving == 4)
                    Text.GetComponent<Text>().text = "I believe there are some people that hesitate to play this game.";

                if (Text_moving == 5)
                    Text.GetComponent<Text>().text = "If you can't find the other 'Find,' or fail to find it in succession, The hint will reveal and help you.";

                if (Text_moving == 6)
                    Text.GetComponent<Text>().text = "So please play this tricky puzzle game.";

                if (Text_moving == 7)
                {
                    Achive.AC[48]++;
                    Achive.Start_Achieve = true;
                    Text.GetComponent<Text>().text = "Thank you for reading it!";
                }

                if (Text_moving == 8)
                    Text.GetComponent<Text>().text = "Oh my, Wait. Is that an achievement?";

                if (Text_moving == 9)
                    Text.GetComponent<Text>().text = "That is my gift for you! :)";

                if (Text_moving == 10)
                    Text.GetComponent<Text>().text = "If you don't understand about this game right now, Please read it one more time.";

                if (Text_moving == 11)
                    Text.GetComponent<Text>().text = "And thank you for download this game! I hope you enjoy it.";

                if (Text_moving == 12)
                {
                    Adstart = true;
                    Text.GetComponent<Text>().text = "Next button will bring you to the Main Title.";
                }
            }

            else if (Main_Scene.Language == 3)
            {
                if (Text_moving == 0)
                    Text.GetComponent<Text>().text = "今までが「決! 発!」のゲーム説明書でした!";

                if (Text_moving == 1)
                    Text.GetComponent<Text>().text = "このゲームは51個の業績と14個のリーダーボードがあります.";

                if (Text_moving == 2)
                    Text.GetComponent<Text>().text = "色んなモードから業績をもらうことができ，";

                if (Text_moving == 3)
                    Text.GetComponent<Text>().text = "それぞれのモードに対するランキングボードで自分の立場を確認することができます.";

                if (Text_moving == 4)
                    Text.GetComponent<Text>().text = "難しい過ぎて挑戦に惑わるあなたのために";

                if (Text_moving == 5)
                    Text.GetComponent<Text>().text = "困ったらヒントを見ることができるようにしたので";

                if (Text_moving == 6)
                    Text.GetComponent<Text>().text = "一度やってくれたら嬉しいです.";

                if (Text_moving == 7)
                {
                    Achive.AC[48]++;
                    Achive.Start_Achieve = true;
                    Text.GetComponent<Text>().text = "最後まで見てくださって本当にありがとうございました.";
                }

                if (Text_moving == 8)
                    Text.GetComponent<Text>().text = "はっ! あれは何なのでしょうか?";

                if (Text_moving == 9)
                    Text.GetComponent<Text>().text = "これは私がくれる贈り物です♪";

                if (Text_moving == 10)
                    Text.GetComponent<Text>().text = "理解できなかったものがあったらもう一度説明書を見てください!";

                if (Text_moving == 11)
                    Text.GetComponent<Text>().text = "本当にありがとうございます!";

                if (Text_moving == 12)
                {
                    Adstart = true;
                    Text.GetComponent<Text>().text = "次のボタン押すとタイトル画面に戻ります…";
                }

            }

            if (Text_moving == 13)
            {
                Text_moving = 0;
                step = 47;
                FadeOut = true;
            }
        }


        if (FadeOut)
        {
            if (step4 == 0)
            {
                Fade2.GetComponent<RectTransform>().localPosition = new Vector3(0, 0, 0);
                Fade2.GetComponent<Image>().color = new Color(0, 0, 0, 0);
                step4 = 1;
            }

            if (step4 == 1)
            {
                if (Fade2.GetComponent<Image>().color.a > 1)
                    step4 = 2;

                else
                {
                    Fade2.GetComponent<Image>().color = new Color(Fade2.GetComponent<Image>().color.r, Fade2.GetComponent<Image>().color.g, Fade2.GetComponent<Image>().color.b, Fade2.GetComponent<Image>().color.a + 0.01f);
                    MusicSource.volume -= 0.01f;
                }
            }

            if (step4 == 2)
            {
                step = 0;
                step2 = 0;
                step3 = 0;
                step4 = 3;
                Text_moving = 0;
                h = 0;
                Lightning = 0;
                Lightmode = false;
                LightStart = false;
                speed = 3;
                FadeOut = false;
                FadeIn = false;

                Fade.GetComponent<RectTransform>().localPosition = new Vector3(0, 0, 0);
                Light.GetComponent<Image>().color = new Color(Light.GetComponent<Image>().color.r, Light.GetComponent<Image>().color.g, Light.GetComponent<Image>().color.b, 0f);
                Scroll.GetComponent<RectTransform>().localPosition = new Vector3(0, -217, 0);

                Fade.GetComponent<Image>().color = new Color(0, 0, 0, 1);
                Scroll.GetComponent<Image>().color = new Color(Scroll.GetComponent<Image>().color.r, Scroll.GetComponent<Image>().color.g, Scroll.GetComponent<Image>().color.b, 0f);
                Next.GetComponent<Image>().color = new Color(Next.GetComponent<Image>().color.r, Next.GetComponent<Image>().color.g, Next.GetComponent<Image>().color.b, 0f);
                Title.GetComponent<Image>().color = new Color(Title.GetComponent<Image>().color.r, Title.GetComponent<Image>().color.g, Title.GetComponent<Image>().color.b, 0);

                for (int i = 0; i < 9; i++)
                    Card[i].GetComponent<Image>().color = new Color(Card[i].GetComponent<Image>().color.r, Card[i].GetComponent<Image>().color.g, Card[i].GetComponent<Image>().color.b, 0);
            }

            if(step4 == 3)
            {
                Stopthis = false;

                step4 = 0;

                Adstart = false;
                SceneManager.LoadScene("Main Scene");
            }
        }
    }
}
