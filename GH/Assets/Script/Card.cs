using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Card : MonoBehaviour
{
    public static Sprite[] allcard; //모든 카드들
    public static Sprite[] spr; //선택된 기호들에 의한 카드들
    public static Sprite[] but, GameImage;
    public static GameObject[] Position;
    public static GameObject[] Image;
    public static GameObject Light, Fade;
    public static GameObject[] ChooseImage;
    public static GameObject Hap_Text, AnswerBack, Hint, SeeHint, Keepit; //Hint의 게임 오브젝트를 추가한다.

    public static int Lightcount = 0;
    public static int[] Num = new int[16];
    public static int Hap = 0;
    public static int[,] Style = new int[16, 3]; //다른 곳에서 참조할 때 값이 임의로 변경되는 것을 방지하기 위함이다.
    public static int[,] AlChoose; // 이미 선택한 합의 중복을 방지하기 위함
    public static int chnum = 0; // 합을 몇 개 선택했는지 확인하기 위함
    public static float[,] Choose_return = new float[3, 2];
    public static float[,] move = new float[3, 2];
    public static float[,] Speed_move = new float[3, 2];

    public static bool Choosefinished = false;
    public static bool find = false;
    public static bool Gyeoul = false;
    public static bool Haap = false;
    public static bool Finish = false;

    public static bool Invisible = false; //가림막 모드 활성화 여부
    public static bool Lightmode = false; //전등 모드 활성화 여부
    public static bool fouroffour = false; //4*4모드 활성화 여부
    public static bool Randommode = false; //랜덤 모드 활성화 여부
    public static bool FadeIn = false; //나타나기
    public static bool FadeOut = false; //사라지기
    public static int LastWinner = 0;
    public static int Allnumber = 0; //선택된 합의 개수
    public static int FailAnswer = 0; //틀린 합의 개수 또는 건너뛴 합의 개수

    public static int moving = 0;
    static int out_if = 0;
    static int starting_number = 0;

    static int x = -1;
    static int y = -1;
    static int z = -1;

    public static int step = 0;
    public static float Lightning = 0;
    static float speed;
    public static bool ShowHint = false;
    public static int HintFade = 0;

    void Awake()
    {
        Screen.SetResolution(Screen.width, Screen.width * 16 / 9, true);
    }

    // Use this for initialization
    void Start()
    {
        allcard = new Sprite[171];
        but = new Sprite[6];
        Position = new GameObject[16];
        ChooseImage = new GameObject[3];
        Image = new GameObject[16];
        spr = new Sprite[36];
        GameImage = new Sprite[38];
        Hint = GameObject.Find("Hint");
        SeeHint = GameObject.Find("See Hint");
        Keepit = GameObject.Find("Keep it");
        Hint.GetComponent<Image>().color = new Color(Hint.GetComponent<Image>().color.r, Hint.GetComponent<Image>().color.g, Hint.GetComponent<Image>().color.b, 0);

        allcard = Resources.LoadAll<Sprite>("Texture/Cards"); //이미지를 부름
        GameImage = Resources.LoadAll<Sprite>("Texture/Button");

        if (Main_Scene.Language == 1)
        {
            Card.Hint.GetComponent<Image>().sprite = GameImage[28];
            Card.SeeHint.GetComponent<Image>().sprite = GameImage[29];
            Card.Keepit.GetComponent<Image>().sprite = GameImage[27];
        }

        else if (Main_Scene.Language == 2)
        {
            Card.Hint.GetComponent<Image>().sprite = GameImage[38];
            Card.SeeHint.GetComponent<Image>().sprite = GameImage[38];
            Card.Keepit.GetComponent<Image>().sprite = GameImage[41];
        }

        else if (Main_Scene.Language == 3)
        {
            Card.Hint.GetComponent<Image>().sprite = GameImage[50];
            Card.SeeHint.GetComponent<Image>().sprite = GameImage[50];
            Card.Keepit.GetComponent<Image>().sprite = GameImage[49];
        }

        for (int i = 0; i < 3; i++)
        {
            ChooseImage[i] = GameObject.Find("ChooseImage_" + (i+1));
            ChooseImage[i].GetComponent<Image>().color = new Color(ChooseImage[i].GetComponent<Image>().color.r, ChooseImage[i].GetComponent<Image>().color.g, ChooseImage[i].GetComponent<Image>().color.b, 0);
            ChooseImage[i].GetComponent<RectTransform>().localPosition = new Vector3(400, 0);
        }

        for(int i = 0; i < 16; i++)
        {
            Position[i] = GameObject.Find("Position_Button_" + i);
            /* 게임 오브젝트인 Position 배열에 각각 밖에 설정해둔 Position_0에서 Position_8까지 넣는다.
               이렇게 해 둔 이유는 Position이 고정되어 있고 그 위에 Sprite 이미지를 붙일 것이기 때문이다.*/

            Image[i] = GameObject.Find("Image_Button_" + i);
            /* 선택된 Sprite 이미지를 각 Position 게임 오브젝트의 Sprite Renderer에 이입한다.
               이렇게 하면 Position에 고정되어 있던 투명한 틀이 위와 같은 이미지 툴로 변경된다.*/

            Position[i].GetComponent<Image>().color = new Color(Position[i].GetComponent<Image>().color.r, Position[i].GetComponent<Image>().color.g, Position[i].GetComponent<Image>().color.b, 0);
            Image[i].GetComponent<Image>().color = new Color(Image[i].GetComponent<Image>().color.r, Image[i].GetComponent<Image>().color.g, Image[i].GetComponent<Image>().color.b, 0);

            Position[i].GetComponent<RectTransform>().localPosition = new Vector3(400, 0);
            Image[i].GetComponent<RectTransform>().localPosition = new Vector3(400, 0);

            Position[i].GetComponent<RectTransform>().localScale = new Vector3(0.65f, 0.65f);
            Image[i].GetComponent<RectTransform>().localScale = new Vector3(0.65f, 0.65f);
        }
        
        Light = GameObject.Find("Light");
        Hap_Text = GameObject.Find("Answer");
        AnswerBack = GameObject.Find("AnsweringBack");
        Light.GetComponent<RectTransform>().localPosition = new Vector3(15300, 0);
        Light.GetComponent<Image>().color = new Color(Light.GetComponent<Image>().color.r, Light.GetComponent<Image>().color.g, Light.GetComponent<Image>().color.b, 0);
        AnswerBack.GetComponent<Image>().color = new Color(AnswerBack.GetComponent<Image>().color.r, AnswerBack.GetComponent<Image>().color.g, AnswerBack.GetComponent<Image>().color.b, 0);

        if (Challenge.Challengemode[4] == 0)
            speed = 2;

        else
            speed = 6;

        Fade = GameObject.Find("FadeOut");

        //4*4모드가 아닐 때
        if (Main_Scene.Selected_stage[2] == 0)
        {
            Hap_Text.GetComponent<RectTransform>().localPosition = new Vector3(3, -93.29f);
            Hap_Text.GetComponent<Text>().fontSize = 14;
            AnswerBack.GetComponent<RectTransform>().localPosition = new Vector3(0.4f, -93.29f);

            //메인에서 정한 카드를 선택하기
            for (int i = 0; i < 3; i++) //3개의 문양을 선택하므로 이와같이 따른다.
            {
                int card_mode = Main_Scene.Selected_card[i];
                int card_color;

                for (int j = 0; j < 3; j++)
                {
                    card_color = Main_Scene.Selected_card_color[j];

                    for (int k = 0; k < 3; k++)
                    {
                        spr[(3 * j) + k + (9 * i)] = allcard[(21 * card_mode) + card_color + (k * 7)];
                    }
                }
            }

            //중복되는 숫자 없이 27개의 숫자 중 9개를 추출하기

            bool isSame; // 숫자가 중복되는지 확인하는 명제

            for (int i = 0; i < 9; i++) // 총 9개를 추출할 것이다.
            {
                while (true) // 중복되는 지 확인이 될 때까지 하므로 while을 써서 반복한다.
                {
                    Num[i] = Random.Range(0, 27); // 0에서 26 중에서 1개를 골라 해당 배열에 넣는다.
                    isSame = false; // 기본은 false값으로 주어진다.

                    for (int j = 0; j < i; ++j) // 중복을 확인합니다.
                    {
                        if(Challenge.Challengemode[1] == 0)
                        {
                            if (Num[j] == Num[i])
                            {
                                isSame = true; // 중복일 경우 해당 명제는 참으로 계산된다.
                                break; // 중복일 경우엔 다시 for(j)문을 확인할 필요가 없기 때문에 탈출한다.
                            }
                        }

                        else
                        {
                            if (Num[j]%9 == Num[i]%9)
                            {
                                isSame = true; // 중복일 경우 해당 명제는 참으로 계산된다.
                                break; // 중복일 경우엔 다시 for(j)문을 확인할 필요가 없기 때문에 탈출한다.
                            }
                        }

                        //만약 true 값이 나오지 않았다면 이대로 유지될 것이다.
                    }

                    if (!isSame)
                    {
                        break; // 만약에 isSame = 1이 아니라면(false) 중복이 없단 의미이므로 탈출한다.
                    }
                }
            }

            for(int i = 0; i < 9; i++)
                Image[i].GetComponent<Image>().sprite = spr[Num[i]];

            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                {
                    Position[(i * 3) + j].GetComponent<RectTransform>().localPosition = new Vector3(-70 + (70 * j), 140 - (70 * i));
                    Image[(i * 3) + j].GetComponent<RectTransform>().localPosition = new Vector3(-70 + (70 * j), 140 - (70 * i));
                }

            /*지금부터 결! 합! 이 되는 것들을 정리한다. 위는 표현을 해둔 9개의 그림을 나눈 것이다.
             첫 번째 배열은 모양(원, 네모, 세모), 두 번째는 모양색(빨강, 파랑, 노랑), 세 번째는 바탕색(회색,검정색,흰색)이다.*/

            for (int i = 0; i < 9; i++) //총 9개의 결! 합의 그림들을 각각 비교한다.
            {
                int num = 0;
                string name = spr[Num[i]].name;

                for (int j = 0; j < 170; j++)
                {
                    if (name.Equals(allcard[j].name)) //이름이 같다면
                    {
                        num = j;
                        break;
                    }
                }

                Style[i, 0] = num / 21;       // 모양은 한 모양당 21개이다. 예를 들어, 22/21 = 1번인 네모가 되고, 44번/21번 = 2번인 세모가 된다.

                Style[i, 1] = num % 7;       // 모양색은 하나의 바탕 당 7개이다. 예를 들어, 22%7 = 1번인 주황색(0번부터 센다)이 되고, 44%7 = 2번인 노랑색이 된다.

                // 바탕색은 7개씩 나뉘어져 있다.
                int number = num - 21*Style[i,0];

                if (number > 6)
                {
                    if(number > 13)
                    {
                        Style[i, 2] = 2; // 13부터는 하얀색으로 간주한다.
                    }

                    else
                    {
                        Style[i, 2] = 1; //7에서 13까지 검은색
                    }
                }

                else
                {
                    Style[i, 2] = 0; // 0에서 6까지 회색
                }
            }

            /*결의 개수를 해당 게임 프로그램이 먼저 알아야하기 때문에 프로그램 상 합의 경우를 나타내는 개수를 구한다.*/
            //int numb = 1; // 84개를 정확히 셋는가 확인하기 위함
            for (int x = 0; x < 7; x++)
            {
                for (int y = x + 1; y < 8; y++)
                {
                    for (int z = y + 1; z < 9; z++)
                    {
                        int H = 0;
                        //3개를 골라 확인한다.
                        for (int n = 0; n < 3; n++)
                        {
                            //모양이 같거나 아예 다른 지 확인한다.
                            bool Con1 = Style[x, n] == Style[y, n];
                            bool Con2 = Style[y, n] == Style[z, n];
                            bool Con3 = Style[z, n] == Style[x, n];

                            if (Con1 == Con2 & Con2 == Con3 & Con1 == Con3)
                            {
                                H++; // 해당 리스트에선 합이다.
                            }

                            else // 해당 리스트에서 합이 아니면 합이 아니므로 빠져나간다.
                            {
                                break;
                            }
                        }

                        if (H == 3)
                        {
                            Hap++;
                        }
                    }
                }
            }

            AlChoose = new int[Hap, 3];
        }

        //4*4모드일 때
        else if (Main_Scene.Selected_stage[2] == 1)
        {
            Hap_Text.GetComponent<RectTransform>().localPosition = new Vector3(3, -103.29f);
            AnswerBack.GetComponent<RectTransform>().localPosition = new Vector3(0.4f, -103.29f);
            AnswerBack.GetComponent<RectTransform>().sizeDelta = new Vector3(310.73f, 105.77f);
            Hap_Text.GetComponent<Text>().fontSize = 14;

            //메인에서 정한 카드를 선택하기
            for (int i = 0; i < 4; i++) //4개의 문양을 선택하므로 이와같이 따른다.
            {
                int card_mode = Main_Scene.Selected_card[i];
                int card_color;

                for (int j = 0; j < 3; j++)
                {
                    card_color = Main_Scene.Selected_card_color[j];

                    for (int k = 0; k < 3; k++)
                    {
                        spr[(3 * j) + k + (9 * i)] = allcard[(21 * card_mode) + card_color + (k * 7)];
                    }
                }
            }

            //중복되는 숫자 없이 27개의 숫자 중 9개를 추출하기

            bool isSame; // 숫자가 중복되는지 확인하는 명제

            for (int i = 0; i < 16; i++) // 총 16개를 추출할 것이다.
            {
                while (true) // 중복되는 지 확인이 될 때까지 하므로 while을 써서 반복한다.
                {
                    Num[i] = Random.Range(0, 36); // 0에서 36 중에서 1개를 골라 해당 배열에 넣는다.
                    isSame = false; // 기본은 false값으로 주어진다.

                    for (int j = 0; j < i; ++j) // 중복을 확인합니다.
                    {
                        if (Num[j] == Num[i])
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

            for (int i = 0; i < 16; i++)
                Image[i].GetComponent<Image>().sprite = spr[Num[i]];

            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                {
                    Position[(i * 4) + j].GetComponent<RectTransform>().localPosition = new Vector3(-82.5f + (55 * j), 147f - (55 * i));
                    Image[(i * 4) + j].GetComponent<RectTransform>().localPosition = new Vector3(-82.5f + (55 * j), 147f - (55 * i));
                    Position[(i * 4) + j].GetComponent<RectTransform>().localScale = new Vector3(0.55f, 0.55f);
                    Image[(i * 4) + j].GetComponent<RectTransform>().localScale = new Vector3(0.55f, 0.55f);
                }

            /*지금부터 결! 합! 이 되는 것들을 정리한다. 위는 표현을 해둔 9개의 그림을 나눈 것이다.
             첫 번째 배열은 모양(원, 네모, 세모), 두 번째는 모양색(빨강, 파랑, 노랑), 세 번째는 바탕색(회색,검정색,흰색)이다.*/

            for (int i = 0; i < 16; i++) //총 9개의 결! 합의 그림들을 각각 비교한다.
            {
                int num = 0;
                string name = spr[Num[i]].name;

                for (int j = 0; j < 170; j++)
                {
                    if (name.Equals(allcard[j].name)) //이름이 같다면
                    {
                        num = j;
                        break;
                    }
                }

                Style[i, 0] = num / 21;       // 모양은 한 모양당 21개이다. 예를 들어, 22/21 = 1번인 네모가 되고, 44번/21번 = 2번인 세모가 된다.

                Style[i, 1] = num % 7;       // 모양색은 하나의 바탕 당 7개이다. 예를 들어, 22%7 = 1번인 주황색(0번부터 센다)이 되고, 44%7 = 2번인 노랑색이 된다.

                // 바탕색은 7개씩 나뉘어져 있다.
                int number = num - 21 * Style[i, 0];

                if (number > 6)
                {
                    if (number > 13)
                    {
                        Style[i, 2] = 2; // 13부터는 하얀색으로 간주한다.
                    }

                    else
                    {
                        Style[i, 2] = 1; //7에서 13까지 검은색
                    }
                }

                else
                {
                    Style[i, 2] = 0; // 0에서 6까지 회색
                }
            }

            /*결의 개수를 해당 게임 프로그램이 먼저 알아야하기 때문에 프로그램 상 합의 경우를 나타내는 개수를 구한다.*/
            //int numb = 1; // 84개를 정확히 셋는가 확인하기 위함
            for (int x = 0; x < 14; x++)
            {
                for (int y = x + 1; y < 15; y++)
                {
                    for (int z = y + 1; z < 16; z++)
                    {
                        int H = 0;
                        //3개를 골라 확인한다.
                        for (int n = 0; n < 3; n++)
                        {
                            //모양이 같거나 아예 다른 지 확인한다.
                            bool Con1 = Style[x, n] == Style[y, n];
                            bool Con2 = Style[y, n] == Style[z, n];
                            bool Con3 = Style[z, n] == Style[x, n];
                            
                            if (Con1 == Con2 & Con2 == Con3 & Con1 == Con3)
                            {
                                H++; // 해당 리스트에선 합이다.
                            }

                            else // 해당 리스트에서 합이 아니면 합이 아니므로 빠져나간다.
                            {
                                break;
                            }
                        }

                        if (H == 3) // 합이라면 H의 값이 3이 나와야한다.
                        {
                            Hap++; //합일 경우 Hap을 계산하는 값이 더해진다.
                        }
                    }
                }
            }

            AlChoose = new int[Hap, 3]; //합의 개수만큼 선택한 배열이 등장한다.
        }
        
        FadeIn = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(ShowHint)
        {
            if(HintFade == 0)
            {
                Hint.GetComponent<RectTransform>().localPosition = new Vector3(0, -148);
                HintFade = 1;
            }

            if(HintFade == 1)
            {
                if(Hint.GetComponent<Image>().color.a <= 0.1f)
                {
                    HintFade = 2;
                }

                else
                {
                    if(!Button_Script.StopGame)
                        Hint.GetComponent<Image>().color = new Color(Hint.GetComponent<Image>().color.r, Hint.GetComponent<Image>().color.g, Hint.GetComponent<Image>().color.b, Hint.GetComponent<Image>().color.a - 0.03f);

                    else
                        Hint.GetComponent<Image>().color = new Color(Hint.GetComponent<Image>().color.r, Hint.GetComponent<Image>().color.g, Hint.GetComponent<Image>().color.b, Hint.GetComponent<Image>().color.a);
                }
            }

            if(HintFade == 2)
            {
                if(Hint.GetComponent<Image>().color.a >= 1f)
                {
                    HintFade = 1;
                }

                else
                {
                    if (!Button_Script.StopGame)
                        Hint.GetComponent<Image>().color = new Color(Hint.GetComponent<Image>().color.r, Hint.GetComponent<Image>().color.g, Hint.GetComponent<Image>().color.b, Hint.GetComponent<Image>().color.a + 0.03f);

                    else
                        Hint.GetComponent<Image>().color = new Color(Hint.GetComponent<Image>().color.r, Hint.GetComponent<Image>().color.g, Hint.GetComponent<Image>().color.b, Hint.GetComponent<Image>().color.a);
                }
            }
        }

        if(FailAnswer > 5 || Button_Script.lethinttime > 30)
        {
            ShowHint = true;
        }

        else
        {
            HintFade = 0;
            Hint.GetComponent<RectTransform>().localPosition = new Vector3(518, -144);
            Hint.GetComponent<Image>().color = new Color(Hint.GetComponent<Image>().color.r, Hint.GetComponent<Image>().color.g, Hint.GetComponent<Image>().color.b, 0);
            ShowHint = false;
        }

        if (Button_Script.StopGame)
            Time.timeScale = 0;

        else
            Time.timeScale = 0.75f;

        if (FadeIn)
        {
            if(step == 0)
            {
                Fade.GetComponent<RectTransform>().localPosition = new Vector3(0, 0);
                Fade.GetComponent<Image>().color = new Color(0, 0, 0, 1);
                step = 1;
            }

            if(step == 1)
            {
                Fade.GetComponent<Image>().color = new Color(0, 0, 0, Fade.GetComponent<Image>().color.a - 0.02f);
                
                if (Fade.GetComponent<Image>().color.a < 0)
                {
                    step = 2;
                }
            }

            if(step == 2)
            {
                Fade.GetComponent<RectTransform>().localPosition = new Vector3(15300, 0);
                Main_Scene.Start_Game_Button = true;
                Main_Scene.Start_Game_Card = true;
                FadeIn = false;
                step = 0;
            }
        }

        if (Main_Scene.Start_Game_Card) //등장하는 장면
        {
            Image[starting_number].GetComponent<Image>().color = new Color(Image[starting_number].GetComponent<Image>().color.r, Image[starting_number].GetComponent<Image>().color.g, Image[starting_number].GetComponent<Image>().color.b, Image[starting_number].GetComponent<Image>().color.a + 0.3f);

            if (Image[starting_number].GetComponent<Image>().color.a >= 1)
            {
                starting_number++;

                //4*4모드가 아닐 때
                if (Main_Scene.Selected_stage[2] == 0)
                {
                    if (starting_number == 9)
                    {
                        Main_Scene.Start_Game_Card = false;
                    }
                }

                //4*4모드일 때
                else if (Main_Scene.Selected_stage[2] == 1)
                {
                    if (starting_number == 16)
                    {
                        Main_Scene.Start_Game_Card = false;
                    }
                }
            }
        }
        
        if (Lightmode)
        {
            if (Button_Script.LightStart)
            {
                Light.GetComponent<RectTransform>().localPosition = new Vector3(0, 330);

                if (Challenge.Challengemode[5] == 1)
                    Light.GetComponent<RectTransform>().transform.rotation = Quaternion.Euler(0, 0, 180);

                if (Challenge.Challengemode[6] == 1)
                {
                    Light.GetComponent<Image>().sprite = allcard[171];
                    Light.GetComponent<RectTransform>().localPosition = new Vector3(0, 0);
                    Light.GetComponent<RectTransform>().sizeDelta = new Vector3(1920, 1920);
                    Light.GetComponent<RectTransform>().localScale = new Vector3(0.5f, 0.5f);
                }

                if (step == 0)
                {
                    Light.GetComponent<Image>().color = new Color(Light.GetComponent<Image>().color.r, Light.GetComponent<Image>().color.g, Light.GetComponent<Image>().color.b, Light.GetComponent<Image>().color.a + 0.1f);

                    if (Light.GetComponent<Image>().color.a > 1)
                        step = 1;
                }

                if (step == 1)
                {
                    Light.GetComponent<Image>().color = new Color(Light.GetComponent<Image>().color.r, Light.GetComponent<Image>().color.g, Light.GetComponent<Image>().color.b, Light.GetComponent<Image>().color.a - 0.1f);

                    if (Light.GetComponent<Image>().color.a < 0)
                        step = 0;
                }

                Lightning = 2;
            }

            else
            {
                if (Challenge.Challengemode[5] == 0)
                {
                    if(Challenge.Challengemode[6] == 1)
                    {
                        if(step == 0 || step == 1)
                        {
                            Light.GetComponent<Image>().color = new Color(Light.GetComponent<Image>().color.r, Light.GetComponent<Image>().color.g, Light.GetComponent<Image>().color.b, 0.98f);
                            step = 2;
                        }

                        if(step == 2)
                        {
                            if (Light.GetComponent<RectTransform>().localPosition.x <= -90)
                                step = 3;

                            else
                                Light.GetComponent<RectTransform>().localPosition = new Vector3(Light.GetComponent<RectTransform>().localPosition.x - 3f, Light.GetComponent<RectTransform>().localPosition.y + 3f);
                        }

                        if (step == 3)
                        {
                            if (Light.GetComponent<RectTransform>().localPosition.x >= 90)
                                step = 4;

                            else
                                Light.GetComponent<RectTransform>().localPosition = new Vector3(Light.GetComponent<RectTransform>().localPosition.x + 3f, Light.GetComponent<RectTransform>().localPosition.y + 0.5f);
                        }

                        if (step == 4)
                        {
                            if (Light.GetComponent<RectTransform>().localPosition.x <= 70)
                                step = 5;

                            else
                                Light.GetComponent<RectTransform>().localPosition = new Vector3(Light.GetComponent<RectTransform>().localPosition.x - 1f, Light.GetComponent<RectTransform>().localPosition.y - 9f);
                        }

                        if (step == 5)
                        {
                            if (Light.GetComponent<RectTransform>().localPosition.x <= -80)
                                step = 6;

                            else
                                Light.GetComponent<RectTransform>().localPosition = new Vector3(Light.GetComponent<RectTransform>().localPosition.x - 3f, Light.GetComponent<RectTransform>().localPosition.y + 0.5f);
                        }

                        if (step == 6)
                        {
                            if (Light.GetComponent<RectTransform>().localPosition.x >= 70)
                                step = 7;

                            else
                                Light.GetComponent<RectTransform>().localPosition = new Vector3(Light.GetComponent<RectTransform>().localPosition.x +5f, Light.GetComponent<RectTransform>().localPosition.y + 7f);
                        }

                        if (step == 7)
                        {
                            if (Light.GetComponent<RectTransform>().localPosition.x <= -80)
                                step = 8;

                            else
                                Light.GetComponent<RectTransform>().localPosition = new Vector3(Light.GetComponent<RectTransform>().localPosition.x - 3f, Light.GetComponent<RectTransform>().localPosition.y - 0.5f);
                        }

                        if (step == 8)
                        {
                            if (Light.GetComponent<RectTransform>().localPosition.x >= 80)
                                step = 9;

                            else
                                Light.GetComponent<RectTransform>().localPosition = new Vector3(Light.GetComponent<RectTransform>().localPosition.x + 5f, Light.GetComponent<RectTransform>().localPosition.y - 2f);
                        }

                        if (step == 9)
                        {
                            if (Light.GetComponent<RectTransform>().localPosition.x <= 0)
                                step = 2;

                            else
                                Light.GetComponent<RectTransform>().localPosition = new Vector3(Light.GetComponent<RectTransform>().localPosition.x - 4f, Light.GetComponent<RectTransform>().localPosition.y - 4.3f);
                        }

                    }

                    else
                    {
                        Light.GetComponent<Image>().color = new Color(Light.GetComponent<Image>().color.r, Light.GetComponent<Image>().color.g, Light.GetComponent<Image>().color.b, 0.95f);

                        if (step == 0) //왼으로 움직임
                        {
                            if (Light.GetComponent<RectTransform>().transform.eulerAngles.z < 110 && Light.GetComponent<RectTransform>().transform.eulerAngles.z > 0)
                            {
                                if (!Button_Script.StopGame)
                                    Light.GetComponent<RectTransform>().transform.rotation = Quaternion.Euler(0, 0, Light.GetComponent<RectTransform>().transform.eulerAngles.z + speed);

                                else
                                    Light.GetComponent<RectTransform>().transform.rotation = Quaternion.Euler(0, 0, Light.GetComponent<RectTransform>().transform.eulerAngles.z);

                                if (Light.GetComponent<RectTransform>().transform.eulerAngles.z >= 17)
                                {
                                    if (!Button_Script.StopGame)
                                    {
                                        if (Challenge.Challengemode[4] == 0)
                                            speed *= 0.94f;

                                        else
                                            speed *= 0.73f;
                                    }
                                }

                                if (speed < 0.03)
                                {
                                    step = 2;

                                    if (Challenge.Challengemode[4] == 0)
                                        speed = 3;

                                    else
                                        speed = 11;
                                }
                            }

                            else
                            {
                                if (!Button_Script.StopGame)
                                    Light.GetComponent<RectTransform>().transform.rotation = Quaternion.Euler(0, 0, Light.GetComponent<RectTransform>().transform.eulerAngles.z + speed);

                                else
                                    Light.GetComponent<RectTransform>().transform.rotation = Quaternion.Euler(0, 0, Light.GetComponent<RectTransform>().transform.eulerAngles.z);
                            }
                        }

                        if (step == 1) //오른쪽으로 움직임
                        {
                            if (Light.GetComponent<RectTransform>().transform.eulerAngles.z < 360 && Light.GetComponent<RectTransform>().transform.eulerAngles.z >= 250)
                            {
                                if (!Button_Script.StopGame)
                                    Light.GetComponent<RectTransform>().transform.rotation = Quaternion.Euler(0, 0, Light.GetComponent<RectTransform>().transform.eulerAngles.z - speed);

                                else
                                    Light.GetComponent<RectTransform>().transform.rotation = Quaternion.Euler(0, 0, Light.GetComponent<RectTransform>().transform.eulerAngles.z);

                                if (Light.GetComponent<RectTransform>().transform.eulerAngles.z <= 340)
                                {
                                    if (!Button_Script.StopGame)
                                    {
                                        if (Challenge.Challengemode[4] == 0)
                                            speed *= 0.94f;

                                        else
                                            speed *= 0.73f;
                                    }
                                }

                                if (speed < 0.03)
                                {
                                    step = 3;

                                    if (Challenge.Challengemode[4] == 0)
                                        speed = 3;

                                    else
                                        speed = 11;
                                }
                            }

                            else
                            {
                                if (!Button_Script.StopGame)
                                    Light.GetComponent<RectTransform>().transform.rotation = Quaternion.Euler(0, 0, Light.GetComponent<RectTransform>().transform.eulerAngles.z - speed);

                                else
                                    Light.GetComponent<RectTransform>().transform.rotation = Quaternion.Euler(0, 0, Light.GetComponent<RectTransform>().transform.eulerAngles.z);
                            }
                        }

                        if (step == 2)
                        {
                            if (360 > Light.GetComponent<RectTransform>().transform.eulerAngles.z && 220 < Light.GetComponent<RectTransform>().transform.eulerAngles.z)
                            {
                                if (Challenge.Challengemode[4] == 0)
                                    speed = 2;

                                else
                                    speed = 11;

                                step = 1;
                            }

                            else
                            {
                                if (!Button_Script.StopGame)
                                    Light.GetComponent<RectTransform>().transform.rotation = Quaternion.Euler(0, 0, Light.GetComponent<RectTransform>().transform.eulerAngles.z - speed);

                                else
                                    Light.GetComponent<RectTransform>().transform.rotation = Quaternion.Euler(0, 0, Light.GetComponent<RectTransform>().transform.eulerAngles.z);
                            }
                        }

                        if (step == 3)
                        {
                            if (80 > Light.GetComponent<RectTransform>().transform.eulerAngles.z && 0 < Light.GetComponent<RectTransform>().transform.eulerAngles.z)
                            {
                                if (Challenge.Challengemode[4] == 0)
                                    speed = 2;

                                else
                                    speed = 11;

                                step = 0;
                            }

                            else
                            {
                                if (!Button_Script.StopGame)
                                    Light.GetComponent<RectTransform>().transform.rotation = Quaternion.Euler(0, 0, Light.GetComponent<RectTransform>().transform.eulerAngles.z + speed);

                                else
                                    Light.GetComponent<RectTransform>().transform.rotation = Quaternion.Euler(0, 0, Light.GetComponent<RectTransform>().transform.eulerAngles.z);
                            }
                        }
                    }
                }

                //암전모드일 때
                else
                {
                    if (step == 1 || step == 0)
                    {
                        Lightcount = 0;
                        Light.GetComponent<Image>().color = new Color(Light.GetComponent<Image>().color.r, Light.GetComponent<Image>().color.g, Light.GetComponent<Image>().color.b, 0);
                        step = 2;
                    }

                    if (step == 2)
                    {
                        if (Lightning < 0)
                        {
                            step = 3;
                            Lightning = 4;
                        }

                        else
                            Lightning -= Time.deltaTime;
                    }

                    if (step == 3)
                    {
                        Light.GetComponent<Image>().color = new Color(Light.GetComponent<Image>().color.r, Light.GetComponent<Image>().color.g, Light.GetComponent<Image>().color.b, Light.GetComponent<Image>().color.a - 0.2f);

                        if (Light.GetComponent<Image>().color.a < 0)
                        {
                            step = 4;
                            Lightcount++;

                            if (Lightcount > 4)
                                step = 5;
                        }
                    }

                    if (step == 4)
                    {
                        Light.GetComponent<Image>().color = new Color(Light.GetComponent<Image>().color.r, Light.GetComponent<Image>().color.g, Light.GetComponent<Image>().color.b, Light.GetComponent<Image>().color.a + 0.2f);

                        if (Light.GetComponent<Image>().color.a > 1)
                        {
                            step = 3;
                            Lightcount++;

                            if (Lightcount > 4)
                                step = 1;
                        }
                    }

                    if (step == 5)
                    {
                        Lightcount = 0;
                        Light.GetComponent<Image>().color = new Color(Light.GetComponent<Image>().color.r, Light.GetComponent<Image>().color.g, Light.GetComponent<Image>().color.b, 0.93f);
                        step = 6;
                    }

                    if (step == 6)
                    {
                        if (Lightning < 0)
                        {
                            step = 4;
                            Lightning = 2;
                        }

                        else
                            Lightning -= Time.deltaTime;
                    }
                }
            }
        }

        if (Button_Script.Invisible)
        {
            if(Button_Script.Timeattack - 5 > 0)
            {
                Image[starting_number - 1].GetComponent<Image>().color = new Color(Image[starting_number - 1].GetComponent<Image>().color.r, Image[starting_number - 1].GetComponent<Image>().color.g, Image[starting_number - 1].GetComponent<Image>().color.b, Image[starting_number - 1].GetComponent<Image>().color.a - 0.3f);

                if (Image[starting_number - 1].GetComponent<Image>().color.a < 0)
                {
                    Image[starting_number - 1].GetComponent<Image>().color = new Color(Image[starting_number - 1].GetComponent<Image>().color.r, Image[starting_number - 1].GetComponent<Image>().color.g, Image[starting_number - 1].GetComponent<Image>().color.b, 1);

                    int In;

                    if (Challenge.Challengemode[2] == 0)
                    {
                        if(Challenge.Challengemode[3] == 1)
                        {
                            In = Random.Range(0, 2);

                            if (In != 0)
                                Image[starting_number - 1].GetComponent<Image>().sprite = Card.allcard[168];

                            else
                                Image[starting_number - 1].GetComponent<Image>().sprite = spr[Num[starting_number - 1]];
                        }

                        else
                        {
                            In = Random.Range(0, 3);

                            if (In == 0)
                                Image[starting_number - 1].GetComponent<Image>().sprite = Card.allcard[168];

                            else
                                Image[starting_number - 1].GetComponent<Image>().sprite = spr[Num[starting_number - 1]];
                        }
                    }

                    else
                    {
                        In = Random.Range(0, 3);

                        if (In != 0)
                            Image[starting_number - 1].GetComponent<Image>().sprite = Card.allcard[168];

                        else
                            Image[starting_number - 1].GetComponent<Image>().sprite = spr[Num[starting_number - 1]];
                    }

                    starting_number--;

                    //4*4모드가 아닐 때
                    if (Main_Scene.Selected_stage[2] == 0)
                    {
                        if (starting_number == 0)
                        {
                            starting_number = 9;
                            Button_Script.Invisible = false;
                        }
                    }

                    //4*4모드일 때
                    else if (Main_Scene.Selected_stage[2] == 1)
                    {
                        if (starting_number == 0)
                        {
                            starting_number = 16;
                            Button_Script.Invisible = false;
                        }
                    }

                    if (Challenge.Challengemode[3] == 1)
                        Button_Script.InvisibleTime = 0.07f;

                    else
                        Button_Script.InvisibleTime = 5;
                }
            }
        }

        if (Choosefinished) // 선택된 버튼이 3개일 때
        {
            //선택한 3개의 수를 작은수부터 x, y, z로 다시 넣는다.
            if (moving == 0)
            {
                for (int i = 0; i < 4; i++)
                    for (int j = 0; j < 4; j++)
                        Position[(i * 4) + j].GetComponent<RectTransform>().localPosition = new Vector3(400, 0);

                for (int i = 0; i < 3; i++)
                {
                    ChooseImage[i].GetComponent<Image>().color = new Color(ChooseImage[i].GetComponent<Image>().color.r, ChooseImage[i].GetComponent<Image>().color.g, ChooseImage[i].GetComponent<Image>().color.b, 1);
                    ChooseImage[i].GetComponent<RectTransform>().localPosition = new Vector3(400, -210);
                }

                x = Button_Script.Choose[0];
                y = Button_Script.Choose[1];
                z = Button_Script.Choose[2];

                int change = 0;

                if (x > y)
                {
                    if (y > z) // z, y, x 순
                    {
                        change = x;
                        x = z;
                        z = change;
                    }

                    else
                    {
                        if (z > x) //y, x, z순
                        {
                            change = y;
                            y = x;
                            x = change;
                        }

                        else // y, z, x순
                        {
                            change = x;
                            x = y;
                            y = z;
                            z = change;
                        }

                    }
                }

                else // y > x순
                {
                    if (y > z) // y가 가장 큼
                    {
                        if (x > z) //z, x, y순
                        {
                            change = y;
                            y = x;
                            x = z;
                            z = change;
                        }

                        else // x, z, y순
                        {
                            change = y;
                            y = z;
                            z = change;
                        }
                    }
                }

                ChooseImage[0].GetComponent<Image>().sprite = spr[Num[x]];
                ChooseImage[1].GetComponent<Image>().sprite = spr[Num[y]];
                ChooseImage[2].GetComponent<Image>().sprite = spr[Num[z]];

                moving = 1;
            }

            //나머지 버튼의 색을 어둡게 한다.

            else if (moving == 1)
            {
                for (int i = 0; i < 16; i++)
                {
                    if(i != x && i != y && i != z)
                    {
                        if (out_if == 0)
                        {
                            if (!Button_Script.StopGame)
                                Image[i].GetComponent<Image>().color = new Color(Image[i].GetComponent<Image>().color.r, Image[i].GetComponent<Image>().color.g, Image[i].GetComponent<Image>().color.b, Image[i].GetComponent<Image>().color.a - 0.06f);

                            else
                                Image[i].GetComponent<Image>().color = new Color(Image[i].GetComponent<Image>().color.r, Image[i].GetComponent<Image>().color.g, Image[i].GetComponent<Image>().color.b, Image[i].GetComponent<Image>().color.a);
                        }
                    

                        for (int j = 0; j < 15; j++)
                        {
                            if (j != x && j != y && j != z)
                            {
                                out_if = 1;

                                if (Image[j].GetComponent<Image>().color.a > 0.3f)
                                {
                                    out_if = 0;
                                    break;
                                }
                            }
                        }
                    }

                    if ((i == 8 || i == 16) && out_if == 1)
                    {
                        for (int j = 0; j < 16; j++)
                            if (j != x && j != y && j != z)
                                Image[j].GetComponent<Image>().color = new Color(Image[j].GetComponent<Image>().color.r, Image[j].GetComponent<Image>().color.g, Image[j].GetComponent<Image>().color.b, 0.1f);

                        out_if = 2;
                        break;
                    }
                }

                if (out_if == 2)
                {
                    if (!Button_Script.StopGame)
                    {
                        if (ChooseImage[0].GetComponent<RectTransform>().localPosition.x == -100)
                            ChooseImage[0].GetComponent<RectTransform>().localPosition = new Vector3(ChooseImage[0].GetComponent<RectTransform>().localPosition.x, ChooseImage[0].GetComponent<RectTransform>().localPosition.y, ChooseImage[0].transform.position.z);
                        else
                            ChooseImage[0].GetComponent<RectTransform>().localPosition = new Vector3(ChooseImage[0].GetComponent<RectTransform>().localPosition.x - 25f, ChooseImage[0].GetComponent<RectTransform>().localPosition.y, ChooseImage[0].transform.position.z);

                        if (ChooseImage[0].GetComponent<RectTransform>().localPosition.x <= 250)
                        {
                            if (ChooseImage[1].GetComponent<RectTransform>().localPosition.x == 0)
                                ChooseImage[1].GetComponent<RectTransform>().localPosition = new Vector3(ChooseImage[1].GetComponent<RectTransform>().localPosition.x, ChooseImage[1].GetComponent<RectTransform>().localPosition.y, ChooseImage[1].transform.position.z);

                            else
                                ChooseImage[1].GetComponent<RectTransform>().localPosition = new Vector3(ChooseImage[1].GetComponent<RectTransform>().localPosition.x - 25f, ChooseImage[1].GetComponent<RectTransform>().localPosition.y, ChooseImage[1].transform.position.z);
                        }

                        if (ChooseImage[1].GetComponent<RectTransform>().localPosition.x <= 250)
                        {
                            if (ChooseImage[2].GetComponent<RectTransform>().localPosition.x == 100)
                            {
                                ChooseImage[2].GetComponent<RectTransform>().localPosition = new Vector3(ChooseImage[2].GetComponent<RectTransform>().localPosition.x, ChooseImage[2].GetComponent<RectTransform>().localPosition.y, ChooseImage[2].transform.position.z);
                                moving = 2;
                            }

                            else
                                ChooseImage[2].GetComponent<RectTransform>().localPosition = new Vector3(ChooseImage[2].GetComponent<RectTransform>().localPosition.x - 25f, ChooseImage[2].GetComponent<RectTransform>().localPosition.y, ChooseImage[2].transform.position.z);
                        }
                    }

                    else
                    {
                        ChooseImage[0].GetComponent<RectTransform>().localPosition = new Vector3(ChooseImage[0].GetComponent<RectTransform>().localPosition.x, ChooseImage[0].GetComponent<RectTransform>().localPosition.y, ChooseImage[0].transform.position.z);
                        ChooseImage[1].GetComponent<RectTransform>().localPosition = new Vector3(ChooseImage[1].GetComponent<RectTransform>().localPosition.x, ChooseImage[1].GetComponent<RectTransform>().localPosition.y, ChooseImage[1].transform.position.z);
                        ChooseImage[2].GetComponent<RectTransform>().localPosition = new Vector3(ChooseImage[2].GetComponent<RectTransform>().localPosition.x, ChooseImage[2].GetComponent<RectTransform>().localPosition.y, ChooseImage[2].transform.position.z);
                    }

                }
            }

            else if (moving == 2)
            {
                //합인지 아닌지 확인한다
                if (Hap_Func(x, y, z))
                {
                    if (Button_Script.Player == 1)
                        Main_Scene.Player_1_Score++;

                    else
                        Main_Scene.Player_2_Score++;

                    int num1 = x + 1;
                    int num2 = y + 1;
                    int num3 = z + 1;

                    Allnumber++;

                    Hap_Text.GetComponent<Text>().text = Hap_Text.GetComponent<Text>().text + num1.ToString("F0") + "," + num2.ToString("F0") + "," + num3.ToString("F0") + " ";

                    Haap = true;
                }

                else
                {
                    if (Button_Script.Player == 1)
                    {
                        Main_Scene.Player_1_Score--;
                        if (Main_Scene.Player_1_Score < 0)
                            Main_Scene.Player_1_Score = 0;
                    }

                    else
                    {
                        Main_Scene.Player_2_Score--;
                        if (Main_Scene.Player_2_Score < 0)
                            Main_Scene.Player_2_Score = 0;
                    }

                    Haap = false;
                }

                moving = -1;
                find = true;
            }

            else if (moving == 3)
            {
                if (!Button_Script.StopGame)
                {
                    if (ChooseImage[0].GetComponent<RectTransform>().localPosition.x == -400)
                        ChooseImage[0].GetComponent<RectTransform>().localPosition = new Vector3(ChooseImage[0].GetComponent<RectTransform>().localPosition.x, ChooseImage[0].GetComponent<RectTransform>().localPosition.y, ChooseImage[0].transform.position.z);
                    else
                        ChooseImage[0].GetComponent<RectTransform>().localPosition = new Vector3(ChooseImage[0].GetComponent<RectTransform>().localPosition.x - 25f, ChooseImage[0].GetComponent<RectTransform>().localPosition.y, ChooseImage[0].transform.position.z);

                    if (ChooseImage[0].GetComponent<RectTransform>().localPosition.x <= -200)
                    {
                        if (ChooseImage[1].GetComponent<RectTransform>().localPosition.x == -400)
                            ChooseImage[1].GetComponent<RectTransform>().localPosition = new Vector3(ChooseImage[1].GetComponent<RectTransform>().localPosition.x, ChooseImage[1].GetComponent<RectTransform>().localPosition.y, ChooseImage[1].transform.position.z);

                        else
                            ChooseImage[1].GetComponent<RectTransform>().localPosition = new Vector3(ChooseImage[1].GetComponent<RectTransform>().localPosition.x - 25f, ChooseImage[1].GetComponent<RectTransform>().localPosition.y, ChooseImage[1].transform.position.z);
                    }

                    if (ChooseImage[1].GetComponent<RectTransform>().localPosition.x <= -100)
                    {
                        if (ChooseImage[2].GetComponent<RectTransform>().localPosition.x == -400)
                        {
                            ChooseImage[2].GetComponent<RectTransform>().localPosition = new Vector3(ChooseImage[2].GetComponent<RectTransform>().localPosition.x, ChooseImage[2].GetComponent<RectTransform>().localPosition.y, ChooseImage[2].transform.position.z);
                            moving = 4;
                        }

                        else
                            ChooseImage[2].GetComponent<RectTransform>().localPosition = new Vector3(ChooseImage[2].GetComponent<RectTransform>().localPosition.x - 25f, ChooseImage[2].GetComponent<RectTransform>().localPosition.y, ChooseImage[2].transform.position.z);
                    }
                }

                else
                {
                    ChooseImage[0].GetComponent<RectTransform>().localPosition = new Vector3(ChooseImage[0].GetComponent<RectTransform>().localPosition.x, ChooseImage[0].GetComponent<RectTransform>().localPosition.y, ChooseImage[0].transform.position.z);
                    ChooseImage[1].GetComponent<RectTransform>().localPosition = new Vector3(ChooseImage[1].GetComponent<RectTransform>().localPosition.x, ChooseImage[1].GetComponent<RectTransform>().localPosition.y, ChooseImage[1].transform.position.z);
                    ChooseImage[2].GetComponent<RectTransform>().localPosition = new Vector3(ChooseImage[2].GetComponent<RectTransform>().localPosition.x, ChooseImage[2].GetComponent<RectTransform>().localPosition.y, ChooseImage[2].transform.position.z);
                }

                out_if = 0;
            }

            else if (moving == 4)
            {
                if (Main_Scene.Selected_stage[2] == 0)
                {
                    for (int i = 0; i < 3; i++)
                        for (int j = 0; j < 3; j++)
                        {
                            Position[(i * 3) + j].GetComponent<RectTransform>().localPosition = new Vector3(-70 + (70 * j), 140 - (70 * i));
                            Image[(i * 3) + j].GetComponent<RectTransform>().localPosition = new Vector3(-70 + (70 * j), 140 - (70 * i));
                        }
                }

                else if (Main_Scene.Selected_stage[2] == 1)
                {
                    for (int i = 0; i < 4; i++)
                        for (int j = 0; j < 4; j++)
                        {
                            Position[(i * 4) + j].GetComponent<RectTransform>().localPosition = new Vector3(-82.5f + (55 * j), 147f - (55 * i));
                            Image[(i * 4) + j].GetComponent<RectTransform>().localPosition = new Vector3(-82.5f + (55 * j), 147f - (55 * i));
                            Position[(i * 4) + j].GetComponent<RectTransform>().localScale = new Vector3(0.55f, 0.55f);
                            Image[(i * 4) + j].GetComponent<RectTransform>().localScale = new Vector3(0.55f, 0.55f);
                        }
                }

                moving = 5;
            }

            else if(moving == 5)
            {
                for (int i = 0; i < 16; i++)
                {
                    if (out_if == 0)
                    {
                        if (!Button_Script.StopGame)
                            Image[i].GetComponent<Image>().color = new Color(Image[i].GetComponent<Image>().color.r, Image[i].GetComponent<Image>().color.g, Image[i].GetComponent<Image>().color.b, Image[i].GetComponent<Image>().color.a + 0.1f);

                        else
                            Image[i].GetComponent<Image>().color = new Color(Image[i].GetComponent<Image>().color.r, Image[i].GetComponent<Image>().color.g, Image[i].GetComponent<Image>().color.b, Image[i].GetComponent<Image>().color.a);

                        for (int j = 0; j < 15; j++)
                        {
                            out_if = 1;

                            if (Image[j].GetComponent<Image>().color.a < 1f)
                            {
                                out_if = 0;
                                break;
                            }
                        }
                    }

                    if ((i == 8 || i == 16) && out_if == 1)
                    {
                        for (int j = 0; j < 16; j++)
                            Image[j].GetComponent<Image>().color = new Color(Image[j].GetComponent<Image>().color.r, Image[j].GetComponent<Image>().color.g, Image[j].GetComponent<Image>().color.b, 1);

                        moving = 0;
                        out_if = 0;
                        x = -1;
                        y = -1;
                        z = -1;
                        Choosefinished = false;
                    }
                }
            }
        }

        if (Gyeoul)
        {
            if (Hap == 0)
            {
                if (Main_Scene.Score)
                {
                    if (Button_Script.Player == 1)
                        Main_Scene.Player_1_Score += 3;

                    else
                        Main_Scene.Player_2_Score += 3;
                    

                    if (Main_Scene.Player_1_Score > Main_Scene.Player_2_Score)
                    {
                        Main_Scene.Player_1_WinCount++;
                        LastWinner = 1;
                    }

                    else
                    {
                        Main_Scene.Player_2_WinCount++;
                        LastWinner = 2;
                    }

                    Main_Scene.Score = false;
                    find = true;
                    Button_Script.step = 3;
                    //동점은 예외처리
                }
            }

            else
            {
                if (Main_Scene.Score)
                {
                    if (Button_Script.Player == 1)
                    {
                        Main_Scene.Player_1_Score--;
                        if (Main_Scene.Player_1_Score < 0)
                            Main_Scene.Player_1_Score = 0;
                    }

                    else
                    {
                        Main_Scene.Player_2_Score--;
                        if (Main_Scene.Player_2_Score < 0)
                            Main_Scene.Player_2_Score = 0;
                    }

                    Main_Scene.Score = false;
                    find = false;
                    Button_Script.step = 3;
                }
            }
        }

        if(Finish)
        {
            chnum = 0;
            find = false;
            Gyeoul = false;
            Haap = false;
            Choosefinished = false;
            Finish = false;
            Hap = 0;

            moving = 0;
            out_if = 0;

            x = -1;
            y = -1;
            z = -1;
            speed = 2;
            step = 0;
            
            Button_Script.NowButtonclick = 0;
            Button_Script.Player = 1;

            Button_Script.timeCount = 0;
            Button_Script.Move = 0;

            Button_Script.Choose = new int[3];
            Button_Script.choose_card = 0;

            Button_Script.Timer_Check = false;
            Button_Script.Start_Timer = false;
            Button_Script.Stop_Timer = false;
            Button_Script.Check_timer = 0;
            Button_Script.Game_Start = false;
            Button_Script.Hap_next = false;
            Button_Script.timer_stop = false;
            Button_Script.AnswerG = false;
            Button_Script.InvisibleTime = 5;
            Allnumber = 0;
            find = false;
            Button_Script.step = 0;
            Main_Scene.step = 0;
            Main_Scene.Finish_Game_Card = true;
            Button_Script.Invisible = false;
            Main_Scene.hintcount = 0;

            if (Main_Scene.Last_Stage == 1)
            {
                for (int i = 0; i < 9; i++)
                    Challenge.Challengemode[i] = 0;

                for (int i = 0; i < 5; i++)
                    Main_Scene.Selected_stage[i] = 0;

                Main_Scene.Firsttime = 0;
                Button_Script.NowTime = 0;
                Achive.Start_Achieve = true;
            }

            if ((!Main_Scene.Player1Mode) && (Main_Scene.Player_1_WinCount + Main_Scene.Player_2_WinCount + Main_Scene.Last_Stage - 1 >= 3) && (Main_Scene.Player_1_WinCount > ((Main_Scene.Player_1_WinCount + Main_Scene.Player_2_WinCount + Main_Scene.Last_Stage - 1) / 2) || Main_Scene.Player_2_WinCount > ((Main_Scene.Player_1_WinCount + Main_Scene.Player_2_WinCount + Main_Scene.Last_Stage - 1) / 2)))
                Achive.Start_Achieve = true;

            //AdMobHint.num = 0;
            //AdMobManager.num = 0;

            FailAnswer = 0;
            HintFade = 0;
            ShowHint = false;

            Light.GetComponent<RectTransform>().transform.rotation = Quaternion.Euler(0, 0, Light.GetComponent<RectTransform>().transform.rotation.z);
            Lightmode = false;
            Lightning = 0;
            Lightcount = 0;
        }

        if (Main_Scene.Finish_Game_Card) //끝나는 장면
        {
            Light.GetComponent<Image>().color = new Color(Light.GetComponent<Image>().color.r, Light.GetComponent<Image>().color.g, Light.GetComponent<Image>().color.b, Light.GetComponent<Image>().color.a - 0.1f);
            Position[starting_number-1].GetComponent<Image>().color = new Color(Position[starting_number-1].GetComponent<Image>().color.r, Position[starting_number-1].GetComponent<Image>().color.g, Position[starting_number-1].GetComponent<Image>().color.b, Position[starting_number-1].GetComponent<Image>().color.a - 0.3f);
            Image[starting_number - 1].GetComponent<Image>().color = new Color(Image[starting_number - 1].GetComponent<Image>().color.r, Image[starting_number - 1].GetComponent<Image>().color.g, Image[starting_number - 1].GetComponent<Image>().color.b, Image[starting_number - 1].GetComponent<Image>().color.a - 0.3f);

            if (Image[starting_number-1].GetComponent<Image>().color.a <= 0)
            {
                starting_number--;

                if(Main_Scene.Last_Stage == 1)
                    MusicSource.volume -= 0.2f;

                if (Main_Scene.Selected_stage[0] == 1 && (!Challenge.Ch))
                    MusicSource.volume -= 0.2f;

                MusicSource.ClockingOff = true;

                if (starting_number == 0)
                {
                    if (Button_Script.Timeattack < 0 || Button_Script.QuitGame)
                        Main_Scene.Last_Stage = 0;

                    else
                        Main_Scene.Last_Stage--;

                    Main_Scene.Finish_Game_Card = false;
                    FadeOut = true;
                }
            }
        }

        if (FadeOut)
        {
            if(!Main_Scene.Player1Mode)
            {
                if (step == 0)
                {
                    Button_Script.Winner = true;

                    if (Main_Scene.Last_Stage > 0)
                    {
                        if (Main_Scene.Player_1_WinCount > ((Main_Scene.Player_1_WinCount + Main_Scene.Player_2_WinCount + Main_Scene.Last_Stage) / 2) || Main_Scene.Player_2_WinCount > ((Main_Scene.Player_1_WinCount + Main_Scene.Player_2_WinCount + Main_Scene.Last_Stage) / 2))
                        { }

                        else
                            Button_Script.QuitGame = true;
                    }
                }

                if (step == 1)
                {
                    Fade.GetComponent<RectTransform>().localPosition = new Vector3(0, 0);
                    Fade.GetComponent<Image>().color = new Color(0, 0, 0, 0);
                    step = 2;
                }

                if (step == 2)
                {
                    MusicSource.SE_volume -= 0.2f;
                    Fade.GetComponent<Image>().color = new Color(0, 0, 0, Fade.GetComponent<Image>().color.a + 0.02f);

                    if (Fade.GetComponent<Image>().color.a > 1)
                    {
                        step = 3;
                    }
                }

                if (step == 3)
                {
                    Fade.GetComponent<RectTransform>().localPosition = new Vector3(0, 0);
                    FadeOut = false;
                    Main_Scene.FadeIn = true;
                    step = 0;
                    Light.GetComponent<RectTransform>().transform.rotation = Quaternion.Euler(0, 0, 0);
                    Card.AnswerBack.GetComponent<Image>().color = new Color(Card.AnswerBack.GetComponent<Image>().color.r, Card.AnswerBack.GetComponent<Image>().color.g, Card.AnswerBack.GetComponent<Image>().color.b, 0f);
                    Hap_Text.GetComponent<Text>().text = "";

                    if (Main_Scene.Last_Stage == 0)
                    {
                        SceneManager.LoadScene("Main Scene");
                        Main_Scene.Player_1_WinCount = 0;
                        Main_Scene.Player_2_WinCount = 0;
                        LastWinner = 0;
                    }

                    else
                    {
                        if (Main_Scene.Player_1_WinCount > ((Main_Scene.Player_1_WinCount + Main_Scene.Player_2_WinCount + Main_Scene.Last_Stage) / 2) || Main_Scene.Player_2_WinCount > ((Main_Scene.Player_1_WinCount + Main_Scene.Player_2_WinCount + Main_Scene.Last_Stage) / 2))
                        {
                            SceneManager.LoadScene("Main Scene");
                            Main_Scene.Player_1_WinCount = 0;
                            Main_Scene.Player_2_WinCount = 0;
                            LastWinner = 0;
                        }

                        else
                        {
                            SceneManager.LoadScene("Game Scene");
                        }
                    }

                    Main_Scene.Player_1_Score = 0;
                    Main_Scene.Player_2_Score = 0;
                }
            }

            else
            {
                if (step == 0)
                {
                    if(Button_Script.Timeattack < 0)
                    {
                        Button_Script.Winner = true;
                    }

                    else
                    {
                        if (Main_Scene.Last_Stage == 0)
                        {
                            Button_Script.Winner = true;
                        }

                        else
                            step = 1;
                    }
                }

                if (step == 1)
                {
                    Fade.GetComponent<RectTransform>().localPosition = new Vector3(0, 0);
                    Fade.GetComponent<Image>().color = new Color(0, 0, 0, 0);
                    step = 2;
                }

                if (step == 2)
                {
                    Fade.GetComponent<Image>().color = new Color(0, 0, 0, Fade.GetComponent<Image>().color.a + 0.02f);

                    if (Fade.GetComponent<Image>().color.a > 1)
                    {
                        step = 3;
                    }
                }

                if (step == 3)
                {
                    Button_Script.lethinttime = 0;
                    Fade.GetComponent<RectTransform>().localPosition = new Vector3(0, 0);
                    FadeOut = false;
                    Main_Scene.FadeIn = true;
                    step = 0;
                    Light.GetComponent<RectTransform>().transform.rotation = Quaternion.Euler(0, 0, 0);
                    Card.AnswerBack.GetComponent<Image>().color = new Color(Card.AnswerBack.GetComponent<Image>().color.r, Card.AnswerBack.GetComponent<Image>().color.g, Card.AnswerBack.GetComponent<Image>().color.b, 0f);
                    Hap_Text.GetComponent<Text>().text = "";

                    if (Main_Scene.Last_Stage == 0)
                    {
                        Main_Scene.Player_1_WinCount = 0;
                        Main_Scene.Player_2_WinCount = 0;

                        if (Challenge.Ch == true)
                        {
                            SceneManager.LoadScene("Challenge");
                            Challenge.Startplayit = false;
                            Challenge.Ch = false;
                        }

                        else
                            SceneManager.LoadScene("Main Scene");

                        Main_Scene.Player1Mode = false;
                        Main_Scene.TimeAttack = false;
                        Main_Scene.time = 60;
                        LastWinner = 0;
                        Button_Script.StopGame = false;
                        Challenge.Now = 0;
                    }

                    else
                    {
                        if (Challenge.Challengemode[8] == 1)
                        {
                            Challenge.Now++;
                            ChallengeAllround(Challenge.Now);
                        }

                        SceneManager.LoadScene("Game Scene");
                        Main_Scene.time = Button_Script.Timeattack;
                        Button_Script.StopGame = false;
                        LastWinner = 0;
                    }

                    Main_Scene.Player_1_Score = 0;
                    Main_Scene.Player_2_Score = 0;
                }
            }

        }
    }

    public bool Hap_Func(int x, int y, int z)
    {
        int H = 0;

        //3개를 골라 확인한다.
        for (int n = 0; n < 3; n++)
        {
            //모양이 같거나 아예 다른 지 확인한다. x(0,1,2)와 y(0,1,2), z(0,1,2)를 각각 비교한다.
            bool Con1 = Style[x, n] == Style[y, n];
            bool Con2 = Style[y, n] == Style[z, n];
            bool Con3 = Style[z, n] == Style[x, n];

            if (Con1 == Con2 & Con2 == Con3 & Con1 == Con3)
            {
                H++; // 해당 리스트에선 합이다.
            }

            else // 해당 리스트에서 합이 아니면 합이 아니므로 빠져나간다.
            {
                break;
            }
        }

        if (H == 3) // 합이라면 H의 값이 3이 나와야한다.
        {
            bool Already = false;

            for(int i = 0; i < chnum; i++)
            {
                bool Con1 = AlChoose[i, 0] == x;
                bool Con2 = AlChoose[i, 1] == y;
                bool Con3 = AlChoose[i, 2] == z;
                
                if (Con1 & Con2 & Con3 & true)
                {
                    Already = true;
                    break;
                }
            }

            if(!Already) //만약, 중복되지 않았다면
            {
                AlChoose[chnum, 0] = x;
                AlChoose[chnum, 1] = y;
                AlChoose[chnum, 2] = z;
                Hap--;
                chnum++; //하나를 더 찾았으므로 더한다.
                return true;
            }

            else
            {
                return false;
            }
        }

        else
            return false;
    }

    void ChallengeAllround(int now)
    {
        for (int i = 0; i < 5; i++) //기본세팅
            Main_Scene.Selected_stage[i] = 0;

        if (now == 1)
        {
            Main_Scene.Selected_stage[0] = 1; //가림막모드 실행
        }

        if(now == 2)
        {
            Main_Scene.Selected_stage[1] = 1; //전등모드 실행
        }

        if (now == 3)
        {
            Main_Scene.Selected_stage[2] = 1; //4*4모드 실행
        }

        if (now == 4)
        {
            Main_Scene.Selected_stage[0] = 1; //복합실행
            Main_Scene.Selected_stage[1] = 1;
            Main_Scene.Selected_stage[3] = 1;
        }

        if (now == 5)
        {
            Main_Scene.Selected_stage[0] = 1; //복합실행
            Main_Scene.Selected_stage[2] = 1;
            Main_Scene.Selected_stage[3] = 1;
        }

        if (now == 6)
        {
            Main_Scene.Selected_stage[1] = 1; //복합실행
            Main_Scene.Selected_stage[2] = 1;
            Main_Scene.Selected_stage[3] = 1;
        }

        if (now == 7)
        {
            Main_Scene.Selected_stage[0] = 1;
            Main_Scene.Selected_stage[1] = 1; //복합실행
            Main_Scene.Selected_stage[2] = 1;
            Main_Scene.Selected_stage[3] = 1;
        }
    }
}