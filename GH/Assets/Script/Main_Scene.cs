using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Main_Scene : MonoBehaviour {

    public static int Player_1_Score = 0;
    public static int Player_2_Score = 0;
    public static int Player_1_WinCount = 0;
    public static int Player_2_WinCount = 0;
    public static int hintcount = 0;

    public static bool Score = false;
    public static bool Start_Game_Card = false;
    public static bool Start_Game_Button = false;
    public static bool Finish_Game_Card = false;
    public static bool Finish_Game_Button = false;

    public static Sprite[] main_but;
    public static Sprite[] main_number;

    public static GameObject Title, P1_Button, P2_Button, P3_Button, P4_Button, Exit, Select1, Select2, Select3, Select4, Select5, Select6,
        Plus, Minus, Plus2, Minus2, Next, BackNext, Next2, BackNext2, Number, Number2, Stage, Mode, Fade, Googleplay, Music, Achieve,
        Leader, Setting, VersionText, Staring, Lang;
    public static GameObject[] Card = new GameObject[22];

    public static int step = 0;
    public static float speed = 0.5f;

    public static int number = 1;
    public static int stage = 1;
    public static int mode = 1;
    public static int step_number = 0;
    public static int step_stage = 0;
    public static int step_mode = 0;

    public static int card_number = 0;
    public static int selected_card_number = 0;

    public static int card_color = 0;
    public static int selected_card_color = 0;

    public static int stage_number = 0;
    public static int selected_stage_number = 0;

    public static int[] Selected_stage = new int[5];
    public static int[] Selected_card = new int[4];
    public static int[] Selected_card_color = new int[4];

    public static int Last_Stage = 1;
    
    public static bool isSame = false; //두 개가 닮았는지 확인하는 방법
    public static bool FadeIn = false;

    public static bool Player1Mode = false; //1플레이어모드인가
    public static bool TimeAttack = false; //타임어택모드인가
    public static float time = 60; //시간
    public static float Firsttime = 0;

    public static bool SettingOn = false;
    public static bool NotSetting = true;
    public static bool isMusicOn = true;
    public static bool MessageOn = false;
    public static int MessageCount = 1;

    public static int Language;

    public void PlaceSetting()
    {
        if (!SettingOn && !FadeIn && (step < 14 || step > 19 || step < 214))
        {
            On();
        }

        else
            Out();
    }
    
    void On()
    {
        MusicSource.SFXCHOOSE = true;
        MusicSource.SFX[1] = true;
        MusicSource.SE_volume = 0.25f;

        Fade.GetComponent<RectTransform>().localPosition = new Vector3(0, 0, 0);
        Fade.GetComponent<Image>().color = new Color(1, 1, 1, 0.8f);

        if (GooglePlayServiceManager.isGoogle)
            Googleplay.GetComponent<Image>().sprite = main_but[71];

        else
            Googleplay.GetComponent<Image>().sprite = main_but[70];

        Achieve.GetComponent<Image>().sprite = main_but[72];
        Leader.GetComponent<Image>().sprite = main_but[77];

        if(Main_Scene.isMusicOn)
            Music.GetComponent<Image>().sprite = main_but[76];

        else
            Music.GetComponent<Image>().sprite = main_but[73];

        Setting.GetComponent<Image>().sprite = main_but[75];

        Set_Lang();

        Googleplay.GetComponent<RectTransform>().localPosition = new Vector3(0, 180, 0);
        Achieve.GetComponent<RectTransform>().localPosition = new Vector3(-100, 30, 0);
        Leader.GetComponent<RectTransform>().localPosition = new Vector3(100, 30, 0);
        Music.GetComponent<RectTransform>().localPosition = new Vector3(0, -120, 0);
        Staring.GetComponent<RectTransform>().localPosition = new Vector3(-110, -230, 0);
        Lang.GetComponent<RectTransform>().localPosition = new Vector3(0, -230, 0);
        Setting.GetComponent<RectTransform>().localPosition = new Vector3(110, -230, 0);

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
        MessageOn = false;
        MessageCount = 1;
    }

    void Out()
    {
        MusicSource.SFXCHOOSE = true;
        MusicSource.SFX[1] = true;
        MusicSource.SE_volume = 0.25f;

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
        if(Language == 1)
            Lang.GetComponent<Image>().sprite = main_but[122];

        else if(Language == 2)
            Lang.GetComponent<Image>().sprite = main_but[123];

        else if(Language == 3)
            Lang.GetComponent<Image>().sprite = main_but[124];
    }

    public void ChangeLang()
    {
        MusicSource.SFXCHOOSE = true;
        MusicSource.SFX[0] = true;
        MusicSource.SE_volume = 0.7f;

        Language++;

        if (Language > 3)
            Language = 1;

        Set_Lang();
    }

    public void GoStaring()
    {
        Application.OpenURL("https://play.google.com/store/apps/details?id=com.ehdwo365.GH&hl=ko&ah=2Pp1SfISDrQgvUPgCM7cZSbwSsQ");
    }

    public void Touch_Button1()
    {
        if (step == 1)
        {
            MusicSource.SFXCHOOSE = true;
            MusicSource.SFX[0] = true;
            MusicSource.SE_volume = 1f;
            step = 100;
        }
    }

    public void Touch_Button2()
    {
        if(step == 1)
        {
            MusicSource.SFXCHOOSE = true;
            MusicSource.SFX[0] = true;
            MusicSource.SE_volume = 1f;
            step = 200;
        }

        if(step == 12)
        {
            MusicSource.SFXCHOOSE = true;
            MusicSource.SFX[0] = true;
            MusicSource.SE_volume = 1f;
            step = 1120;
        }
    }

    public void Touch_Button3()
    {
        if (step == 12)
        {
            MusicSource.SFXCHOOSE = true;
            MusicSource.SFX[0] = true;
            MusicSource.SE_volume = 1f;
            step = 14;
        }
    }

    public void Touch_Button4()
    {
        if (step == 12)
        {
            MusicSource.SFXCHOOSE = true;
            MusicSource.SFX[0] = true;
            MusicSource.SE_volume = 1f;
            step = 17;
        }
    }

    public void Quit()
    {
        if (step == 1)
        {
            MusicSource.SFXCHOOSE = true;
            MusicSource.SFX[1] = true;
            MusicSource.SE_volume = 0.25f;
            Application.Quit();
        }
    }

    //스테이지 개수 선택
    public void Stage_Number_Plus()
    {
        if (step == 24 && number >= 1 && number <= 8)
        {
            MusicSource.SFXCHOOSE = true;
            MusicSource.SFX[0] = true;
            MusicSource.SE_volume = 0.6f;
            step_number = 0;
            step = 25;
        }
    }

    public void Stage_Number_Minus()
    {
        if (step == 24 && number > 1 && number <= 9)
        {
            MusicSource.SFXCHOOSE = true;
            MusicSource.SFX[0] = true;
            MusicSource.SE_volume = 1f;
            step_number = 0;
            step = 26;
        }
    }

    //스테이지 선택
    public void Stage_Next()
    {
        if (step == 24 && stage >= 1 && stage <= 6)
        {
            MusicSource.SFXCHOOSE = true;
            MusicSource.SFX[0] = true;
            MusicSource.SE_volume = 1f;

            stage++;
            step_stage = 0;
            step = 27;
        }
    }

    public void Stage_BackNext()
    {
        if (step == 24 && stage >= 1 && stage <= 6)
        {
            MusicSource.SFXCHOOSE = true;
            MusicSource.SFX[0] = true;
            MusicSource.SE_volume = 1f;

            stage--;
            step_stage = 0;
            step = 28;
        }
    }

    public void Select_Stage()
    {
        step_stage = 0;
        string name = EventSystem.current.currentSelectedGameObject.name;
        MusicSource.SFXCHOOSE = true;
        MusicSource.SFX[0] = true;
        MusicSource.SE_volume = 1f;

        if (step == 24 && stage >= 1 && stage <= 6) //스테이지 선택할 수 있을 때
        {
            for (int i = 0; i < 6; i++) //5개의 이름을 확인한다.
            {
                if (name.Equals(Card[i+16].name))
                { selected_stage_number = i; } // 5개의 버튼에 대해 0에서 4까지 이름을 정한다.
            }

            if (selected_stage_number < 3) //3번 이하일 때
            {
                if(step_stage == 0)
                {
                    //버튼의 모습을 변경
                    if (Card[selected_stage_number + 16].GetComponent<Image>().sprite == main_but[44 + selected_stage_number]) //선택되지 않음
                    {
                        Card[selected_stage_number + 16].GetComponent<Image>().sprite = main_but[50 + selected_stage_number];
                        Selected_stage[selected_stage_number] = 1;
                        stage_number++; //숫자를 늘린다
                    }

                    else if (Card[selected_stage_number + 16].GetComponent<Image>().sprite == main_but[50 + selected_stage_number]) //이미 선택되어서 취소함
                    {
                        Card[selected_stage_number + 16].GetComponent<Image>().sprite = main_but[44 + selected_stage_number];
                        Selected_stage[selected_stage_number] = 0;
                        stage_number--; //숫자를 줄인다.
                    }
                    
                    if (Card[20].GetComponent<Image>().sprite == main_but[55]) //랜덤모드가 선택되어 있는 상태에서 버튼을 눌렀다면
                    {
                        Card[20].GetComponent<Image>().sprite = main_but[49];
                        Selected_stage[4] = 0;
                        stage_number--;
                    }

                    //이후에
                    if (stage_number == 0) //선택된 것이 없다면
                    {
                        stage = 1; //일반모드
                        Card[19].GetComponent<Image>().sprite = main_but[47];
                    }

                    else if (stage_number == 1) //선택된 것이 하나가 있다면
                    {
                        if (Card[19].GetComponent<Image>().sprite == main_but[53])
                        {
                            stage = 1;
                            stage_number = 0;
                        }

                        else
                        {
                            for (int i = 0; i < 3; i++)
                            {
                                if (Card[i + 16].GetComponent<Image>().sprite == main_but[50 + i]) //선택되었다면
                                    stage = i + 2;
                            }
                        }

                        Card[19].GetComponent<Image>().sprite = main_but[47];
                    }

                    else //선택된 것이 2개 이상이라면
                    {
                        stage = 5; //합성모드
                        Card[19].GetComponent<Image>().sprite = main_but[53];
                    }

                    stage_number = 0;

                    for (int i = 0; i < 4; i++)
                    {
                        if (Card[i + 16].GetComponent<Image>().sprite == main_but[50 + i]) //선택되었다면
                            stage_number++;
                    }

                    if (Card[20].GetComponent<Image>().sprite == main_but[55])
                        stage_number++;

                    step_stage = 1;
                }

                if (step_stage == 1)
                {
                    if (stage == 1) // 일반모드
                    {
                        Stage.GetComponent<RectTransform>().localScale = new Vector3(0.4f, 0.4f);
                        Stage.GetComponent<RectTransform>().sizeDelta = new Vector3(135, 72);
                    }

                    else if (stage == 2) // 가림막모드
                    {
                        Stage.GetComponent<RectTransform>().sizeDelta = new Vector3(202, 72);
                        Stage.GetComponent<RectTransform>().localScale = new Vector3(0.35f, 0.35f);
                    }

                    else if (stage == 3) // 전등모드
                    {
                        Stage.GetComponent<RectTransform>().sizeDelta = new Vector3(137, 70);
                        Stage.GetComponent<RectTransform>().localScale = new Vector3(0.4f, 0.4f);
                    }

                    else if (stage == 4) // 4x4모드
                    {
                        Stage.GetComponent<RectTransform>().sizeDelta = new Vector3(135, 59);
                        Stage.GetComponent<RectTransform>().localScale = new Vector3(0.4f, 0.4f);
                    }

                    else if (stage == 5) // 합성모드
                    {
                        Stage.GetComponent<RectTransform>().sizeDelta = new Vector3(129, 70);
                        Stage.GetComponent<RectTransform>().localScale = new Vector3(0.4f, 0.4f);
                    }

                    else if (stage == 6) // 랜덤 모드
                    {
                        Stage.GetComponent<RectTransform>().sizeDelta = new Vector3(129, 69);
                        Stage.GetComponent<RectTransform>().localScale = new Vector3(0.4f, 0.4f);
                    }

                    Stage.GetComponent<Image>().sprite = main_but[stage + 60];
                }
            }

            else //다른 버튼을 눌렀을 때
            {
                if(selected_stage_number == 3) //합성모드일 때
                {
                    if(step_stage == 0)
                    {
                        //버튼의 모습을 변경
                        if (Card[19].GetComponent<Image>().sprite == main_but[47]) //선택되지 않음
                        {
                            Card[19].GetComponent<Image>().sprite = main_but[53];
                            Selected_stage[selected_stage_number] = 1;
                        }

                        else if (Card[19].GetComponent<Image>().sprite == main_but[53]) //이미 선택되어서 취소함
                        {
                            Card[19].GetComponent<Image>().sprite = main_but[47];
                            Selected_stage[selected_stage_number] = 0;
                        }

                        if(Card[19].GetComponent<Image>().sprite == main_but[47]) //취소 선택을 함
                        {
                            stage = 1; //일반모드
                        }

                        else if((Card[19].GetComponent<Image>().sprite == main_but[53])) //선택되었을 때
                        {
                            stage = 5; //합성모드
                        }
                        
                        for (int i = 0; i < 3; i++)
                            Card[i + 16].GetComponent<Image>().sprite = main_but[44 + i];
                        Card[20].GetComponent<Image>().sprite = main_but[49];
                        
                        stage_number = 0;

                        for (int i = 0; i < 4; i++)
                        {
                            if (Card[i + 16].GetComponent<Image>().sprite == main_but[50 + i]) //선택되었다면
                                stage_number++;
                        }

                        if (Card[20].GetComponent<Image>().sprite == main_but[55])
                            stage_number++;

                        step_stage = 1;
                    }

                    if(step_stage == 1)
                    {
                        if (stage == 1) // 일반모드
                        {
                            Stage.GetComponent<RectTransform>().localScale = new Vector3(0.4f, 0.4f);
                            Stage.GetComponent<RectTransform>().sizeDelta = new Vector3(135, 72);
                        }

                        else if (stage == 2) // 가림막모드
                        {
                            Stage.GetComponent<RectTransform>().sizeDelta = new Vector3(202, 72);
                            Stage.GetComponent<RectTransform>().localScale = new Vector3(0.35f, 0.35f);
                        }

                        else if (stage == 3) // 전등모드
                        {
                            Stage.GetComponent<RectTransform>().sizeDelta = new Vector3(137, 70);
                            Stage.GetComponent<RectTransform>().localScale = new Vector3(0.4f, 0.4f);
                        }

                        else if (stage == 4) // 4x4모드
                        {
                            Stage.GetComponent<RectTransform>().sizeDelta = new Vector3(135, 59);
                            Stage.GetComponent<RectTransform>().localScale = new Vector3(0.4f, 0.4f);
                        }

                        else if (stage == 5) // 합성모드
                        {
                            Stage.GetComponent<RectTransform>().sizeDelta = new Vector3(129, 70);
                            Stage.GetComponent<RectTransform>().localScale = new Vector3(0.4f, 0.4f);
                        }

                        else if (stage == 6) // 랜덤 모드
                        {
                            Stage.GetComponent<RectTransform>().sizeDelta = new Vector3(129, 69);
                            Stage.GetComponent<RectTransform>().localScale = new Vector3(0.4f, 0.4f);
                        }

                        Stage.GetComponent<Image>().sprite = main_but[stage + 60];
                    }
                }

                if (selected_stage_number == 4) //랜덤모드일 때
                {
                    if (step_stage == 0)
                    {
                        //버튼의 모습을 변경
                        if (Card[20].GetComponent<Image>().sprite == main_but[49]) //선택되지 않음
                        {
                            Card[20].GetComponent<Image>().sprite = main_but[55];
                            Selected_stage[selected_stage_number] = 1;

                            stage = 6; //일반모드 전환
                        }

                        else if (Card[20].GetComponent<Image>().sprite == main_but[55]) //이미 선택되어서 취소함
                        {
                            Card[20].GetComponent<Image>().sprite = main_but[49];
                            Selected_stage[selected_stage_number] = 0;

                            stage = 1; //랜덤모드 전환
                        }

                        for (int i = 0; i < 4; i++)
                            Card[i + 16].GetComponent<Image>().sprite = main_but[44 + i];
                        //나머지는 모두 버튼이 꺼진다.

                        stage_number = 0;

                        for (int i = 0; i < 4; i++)
                        {
                            if (Card[i + 16].GetComponent<Image>().sprite == main_but[50 + i]) //선택되었다면
                                stage_number++;
                        }

                        if (Card[20].GetComponent<Image>().sprite == main_but[55])
                            stage_number++;

                        step_stage = 1;
                    }

                    if (step_stage == 1)
                    {
                        if (stage == 1) // 일반모드
                        {
                            Stage.GetComponent<RectTransform>().localScale = new Vector3(0.4f, 0.4f);
                            Stage.GetComponent<RectTransform>().sizeDelta = new Vector3(135, 72);
                        }

                        else if (stage == 2) // 가림막모드
                        {
                            Stage.GetComponent<RectTransform>().sizeDelta = new Vector3(202, 72);
                            Stage.GetComponent<RectTransform>().localScale = new Vector3(0.35f, 0.35f);
                        }

                        else if (stage == 3) // 전등모드
                        {
                            Stage.GetComponent<RectTransform>().sizeDelta = new Vector3(137, 70);
                            Stage.GetComponent<RectTransform>().localScale = new Vector3(0.4f, 0.4f);
                        }

                        else if (stage == 4) // 4x4모드
                        {
                            Stage.GetComponent<RectTransform>().sizeDelta = new Vector3(135, 59);
                            Stage.GetComponent<RectTransform>().localScale = new Vector3(0.4f, 0.4f);
                        }

                        else if (stage == 5) // 합성모드
                        {
                            Stage.GetComponent<RectTransform>().sizeDelta = new Vector3(129, 70);
                            Stage.GetComponent<RectTransform>().localScale = new Vector3(0.4f, 0.4f);
                        }

                        else if (stage == 6) // 랜덤 모드
                        {
                            Stage.GetComponent<RectTransform>().sizeDelta = new Vector3(129, 69);
                            Stage.GetComponent<RectTransform>().localScale = new Vector3(0.4f, 0.4f);
                        }

                        Stage.GetComponent<Image>().sprite = main_but[stage + 60];
                        step_stage = 2;
                    }

                    if (step_stage == 2)
                    {
                        if (Card[20].GetComponent<Image>().sprite == main_but[55])
                        {
                            int count = 0;

                            for (int i = 0; i < 3; i++) // 총 3개를 추출할 것이다.
                            {
                                Selected_stage[i] = Random.Range(0, 2); // 0에서 1 중에서 1개를 골라 해당 배열에 넣는다.
                            }

                            for (int i = 0; i < 3; i++)
                            {
                                if (Selected_stage[i] == 1)
                                    count++;
                            }

                            if (count >= 2)
                                Selected_stage[3] = 1;

                            else
                                Selected_stage[3] = 0;
                        }

                        else
                        {
                            for(int i = 0; i < 4; i++)
                                Selected_stage[i] = 0;
                        }
                    }
                }

                if (selected_stage_number == 5)
                {
                    if (Card[21].GetComponent<Image>().sprite == main_but[48]) //선택되지 않음
                    {
                        Card[21].GetComponent<Image>().sprite = main_but[54];
                        TimeAttack = true;
                    }

                    else if (Card[21].GetComponent<Image>().sprite == main_but[54]) //이미 선택되어서 취소함
                    {
                        Card[21].GetComponent<Image>().sprite = main_but[48];
                        TimeAttack = false;
                    }

                    TimeAttackMode();
                }
            }

            if (stage != 4)
            {
                if (card_number > 3)
                {
                    card_number--;
                    Card[Selected_card[3]].GetComponent<Image>().sprite = main_but[14 + Selected_card[3]];
                }
            }
        }

        for (int i = 0; i < 4; i++)
        {
            if (Card[i + 16].GetComponent<Image>().sprite == main_but[50 + i])
                Selected_stage[i] = 1;

            else
                Selected_stage[i] = 0;
        }

        if (Card[20].GetComponent<Image>().sprite == main_but[55])
            Selected_stage[4] = 1;

        else
            Selected_stage[4] = 0;
    }

    public void TimeAttackMode()
    {
        MusicSource.SFXCHOOSE = true;
        MusicSource.SFX[0] = true;
        MusicSource.SE_volume = 1f;
        step = 241;
    }

    //시간 선택
    public void Time_Plus()
    {
        if (TimeAttack && time >= 60 && time < 540)
        {
            MusicSource.SFXCHOOSE = true;
            MusicSource.SFX[0] = true;
            MusicSource.SE_volume = 1f;
            step_number = 0;
            step = 251;
        }
    }

    public void Time_Minus()
    {
        if (TimeAttack && time > 60 && time <= 540)
        {
            MusicSource.SFXCHOOSE = true;
            MusicSource.SFX[0] = true;
            MusicSource.SE_volume = 1f;
            step_number = 0;
            step = 261;
        }
    }

    //스테이지의 기호 선택
    public void Select_Number()
    {
        string name = EventSystem.current.currentSelectedGameObject.name;
        MusicSource.SFXCHOOSE = true;
        MusicSource.SFX[0] = true;
        MusicSource.SE_volume = 1f;

        if (step == 24 && card_number >= 0 && card_number <= 4)
        {
            for (int i = 0; i < 8; i++)
            {
                if (name.Equals(Card[i].name))
                { selected_card_number = i; }
            }

            if(mode == 1) //랜덤 외에 선택됨
            {
                if (Card[selected_card_number].GetComponent<Image>().sprite == main_but[14 + selected_card_number]) //선택되지 않음
                {
                    if (Selected_stage[2] == 0) //4x4모드가 아니다
                    {
                        if (card_number < 3)
                        {
                            Card[selected_card_number].GetComponent<Image>().sprite = main_but[29 + selected_card_number];
                            Selected_card[card_number] = selected_card_number;
                            card_number++; //숫자를 늘린다
                        }
                    }

                    if (Selected_stage[2] == 1) //4x4모드
                    {
                        if (card_number < 4)
                        {
                            Card[selected_card_number].GetComponent<Image>().sprite = main_but[29 + selected_card_number];
                            Selected_card[card_number] = selected_card_number;
                            card_number++; //숫자를 늘린다
                        }
                    }
                }

                else if (Card[selected_card_number].GetComponent<Image>().sprite == main_but[29 + selected_card_number]) //이미 선택되어서 취소함
                {
                    if (card_number > 0)
                    {
                        card_number--;
                        Card[selected_card_number].GetComponent<Image>().sprite = main_but[14 + selected_card_number];
                        Selected_card[card_number] = -1;
                    }
                }
            }
        }
    }

    //스테이지의 색깔 선택
    public void Select_Color()
    {
        string name = EventSystem.current.currentSelectedGameObject.name;
        MusicSource.SFXCHOOSE = true;
        MusicSource.SFX[0] = true;
        MusicSource.SE_volume = 1f;

        if (step == 24 && card_color >= 0 && card_color <= 3)
        {
            for (int i = 8; i < 16; i++)
            {
                if (name.Equals(Card[i].name))
                { selected_card_number = i; }
            }

            if (mode == 1) //랜덤 외에 선택됨
            {
                if (Card[selected_card_number].GetComponent<Image>().sprite == main_but[14 + selected_card_number]) //선택되지 않음
                {
                    if (card_color < 3)
                    {
                        Card[selected_card_number].GetComponent<Image>().sprite = main_but[29 + selected_card_number];
                        Selected_card_color[card_color] = (selected_card_number - 8);
                        card_color++; //숫자를 늘린다
                    }
                }

                else if (Card[selected_card_number].GetComponent<Image>().sprite == main_but[29 + selected_card_number]) //이미 선택되어서 취소함
                {
                    if (card_color > 0)
                    {
                        card_color--;
                        Card[selected_card_number].GetComponent<Image>().sprite = main_but[14 + selected_card_number];
                        Selected_card_color[card_color] = -1;
                    }
                }
            }
        }
    }

    //돌아가기
    public void Go_Back()
    {
        if(step == 24) // 24번일 때 초기화하고 돌아감
        {
            MusicSource.SFXCHOOSE = true;
            MusicSource.SFX[1] = true;
            MusicSource.SE_volume = 0.25f;

            number = 1;
            stage = 1;
            step_number = 0;
            step_stage = 0;

            card_number = 0;
            selected_card_number = 0;

            card_color = 0;
            selected_card_color = 0;

            stage_number = 0;
            selected_stage_number = 0;

            step = 211;

            for (int i = 0; i < 5; i++)
                Selected_stage[i] = 0;
        }

        if(step == 12)
        {
            MusicSource.SFXCHOOSE = true;
            MusicSource.SFX[1] = true;
            MusicSource.SE_volume = 0.25f;
            step = 13;
        }
    }

    //게임 시작
    public void StartGame()
    {
        if (step == 24)
        {
            MusicSource.SFXCHOOSE = true;
            MusicSource.SFX[0] = true;
            MusicSource.SE_volume = 1f;
            step = 214;
        }
    }

    void Awake()
    {
        Screen.SetResolution(Screen.width, Screen.width*16/9, false);
    }

    // Use this for initialization
    void Start ()
    {
        main_but = new Sprite[128];
        main_number = new Sprite[15];

        for (int i = 0; i < 3; i++)
            Selected_card[i] = -1;

        main_but = Resources.LoadAll<Sprite>("Texture/Main"); //이미지를 부름
        main_number = Resources.LoadAll<Sprite>("Texture/Button"); //이미지를 부름

        Title = GameObject.Find("Title");
        P1_Button = GameObject.Find("1P_Button");
        P2_Button = GameObject.Find("2P_Button");
        P3_Button = GameObject.Find("3P_Button");
        P4_Button = GameObject.Find("4P_Button");
        Exit = GameObject.Find("Exit");
        Select1 = GameObject.Find("Select 1");
        Select2 = GameObject.Find("Select 2");
        Select3 = GameObject.Find("Select 3");
        Select4 = GameObject.Find("Select 4");
        Select5 = GameObject.Find("Select 5");
        Select6 = GameObject.Find("Select 6");
        Plus = GameObject.Find("Plus");
        Minus = GameObject.Find("Minus");
        Plus2 = GameObject.Find("Plus2");
        Minus2 = GameObject.Find("Minus2");
        Next = GameObject.Find("Next");
        BackNext = GameObject.Find("BackNext");
        Number = GameObject.Find("Number");
        Number2 = GameObject.Find("Number2");
        Stage = GameObject.Find("Stage");
        Fade = GameObject.Find("Fade");
        Googleplay = GameObject.Find("Google Play");
        Achieve = GameObject.Find("Achievement");
        Music = GameObject.Find("Music");
        Leader = GameObject.Find("LeaderBoard");
        Setting = GameObject.Find("Setting");
        VersionText = GameObject.Find("VersionText");
        Staring = GameObject.Find("Staring");
        Lang = GameObject.Find("Lang");

        //card1 ~ 8까지 문양, card9 ~ 16까지 색깔, card17~21부터 모드
        for (int i = 1; i < 23; i++)
            Card[i-1] = GameObject.Find("card" + i);

        Title.GetComponent<Image>().color = new Color(Title.GetComponent<Image>().color.r, Title.GetComponent<Image>().color.g, Title.GetComponent<Image>().color.b, 0);
        P1_Button.GetComponent<RectTransform>().localPosition = new Vector3(285, P1_Button.GetComponent<RectTransform>().localPosition.y, P1_Button.transform.position.z);
        P2_Button.GetComponent<RectTransform>().localPosition = new Vector3(285, P2_Button.GetComponent<RectTransform>().localPosition.y, P2_Button.transform.position.z);
        Exit.GetComponent<RectTransform>().localPosition = new Vector3(285, Exit.GetComponent<RectTransform>().localPosition.y, Exit.transform.position.z);

        FadeIn = true;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (FadeIn)
        {
            if (step == 0)
            {
                Fade.GetComponent<RectTransform>().localPosition = new Vector3(0, 0);
                Fade.GetComponent<Image>().color = new Color(0, 0, 0, 1);
                step = 1;
            }

            if (step == 1)
            {
                Fade.GetComponent<Image>().color = new Color(0, 0, 0, Fade.GetComponent<Image>().color.a - 0.001f);

                if (Fade.GetComponent<Image>().color.a < 0)
                {
                    step = 2;
                }
            }

            if (step == 2)
            {
                Fade.GetComponent<RectTransform>().localPosition = new Vector3(15300, 0);
                Title.GetComponent<Image>().color = new Color(Title.GetComponent<Image>().color.r, Title.GetComponent<Image>().color.g, Title.GetComponent<Image>().color.b, 0);
                P1_Button.GetComponent<RectTransform>().localPosition = new Vector3(285, P1_Button.GetComponent<RectTransform>().localPosition.y, P1_Button.transform.position.z);
                P2_Button.GetComponent<RectTransform>().localPosition = new Vector3(285, P2_Button.GetComponent<RectTransform>().localPosition.y, P2_Button.transform.position.z);
                Exit.GetComponent<RectTransform>().localPosition = new Vector3(285, Exit.GetComponent<RectTransform>().localPosition.y, Exit.transform.position.z);
                Setting.GetComponent<RectTransform>().localPosition = new Vector3(110, -230);
                Setting.GetComponent<RectTransform>().sizeDelta = new Vector3(512, 512);
                Setting.GetComponent<RectTransform>().localScale = new Vector3(0.15f, 0.15f);
                Setting.GetComponent<Image>().sprite = main_but[74];
                Setting.GetComponent<Image>().color = new Color(Setting.GetComponent<Image>().color.r, Setting.GetComponent<Image>().color.g, Setting.GetComponent<Image>().color.b, 0);
                MusicSource.step = 0;
                MusicSource.Looptime = 15.545f;
                MusicSource.volume = 1f;

                VersionText.GetComponent<RectTransform>().localPosition = new Vector3(355, -250, 0);

                FadeIn = false;
                step = 0;
            }
        }

        else
        {
            if (step == 0) // 타이틀 화면 시작 //버튼들 등장
            {
                if (Language == 1)
                {
                    Title.GetComponent<Image>().sprite = main_but[0];
                    Title.GetComponent<RectTransform>().sizeDelta = new Vector3(393, 135);
                    P1_Button.GetComponent<Image>().sprite = main_but[1];
                    P2_Button.GetComponent<Image>().sprite = main_but[2];
                    Exit.GetComponent<Image>().sprite = main_but[5];
                }

                else if (Language == 2)
                {
                    Title.GetComponent<Image>().sprite = main_but[84];
                    Title.GetComponent<RectTransform>().sizeDelta = new Vector3(321, 161);
                    P1_Button.GetComponent<Image>().sprite = main_but[85];
                    P2_Button.GetComponent<Image>().sprite = main_but[86];
                    Exit.GetComponent<Image>().sprite = main_but[89];
                }

                else if (Language == 3)
                {
                    Title.GetComponent<Image>().sprite = main_but[103];
                    Title.GetComponent<RectTransform>().sizeDelta = new Vector3(390, 138);
                    P1_Button.GetComponent<Image>().sprite = main_but[104];
                    P2_Button.GetComponent<Image>().sprite = main_but[105];
                    Exit.GetComponent<Image>().sprite = main_but[108];
                }

                if (Title.GetComponent<Image>().color.a >= 1)
                {
                    if (P1_Button.GetComponent<RectTransform>().localPosition.x <= 0)
                    {
                        step = 1; // 기다리기
                    }

                    else
                    {
                        Title.GetComponent<RectTransform>().localPosition = new Vector3(Title.GetComponent<RectTransform>().localPosition.x, Title.GetComponent<RectTransform>().localPosition.y + 0.3f, Title.transform.position.z);
                        P1_Button.GetComponent<RectTransform>().localPosition = new Vector3(P1_Button.GetComponent<RectTransform>().localPosition.x - 0.5f, P1_Button.GetComponent<RectTransform>().localPosition.y, P1_Button.transform.position.z);
                        P2_Button.GetComponent<RectTransform>().localPosition = new Vector3(P2_Button.GetComponent<RectTransform>().localPosition.x - 0.5f, P2_Button.GetComponent<RectTransform>().localPosition.y, P2_Button.transform.position.z);
                        Exit.GetComponent<RectTransform>().localPosition = new Vector3(Exit.GetComponent<RectTransform>().localPosition.x - 0.5f, Exit.GetComponent<RectTransform>().localPosition.y, Exit.transform.position.z);
                        Setting.GetComponent<Image>().color = new Color(Setting.GetComponent<Image>().color.r, Setting.GetComponent<Image>().color.g, Setting.GetComponent<Image>().color.b, Setting.GetComponent<Image>().color.a+0.05f);
                        VersionText.GetComponent<RectTransform>().localPosition = new Vector3(VersionText.GetComponent<RectTransform>().localPosition.x - 0.5f, VersionText.GetComponent<RectTransform>().localPosition.y, VersionText.transform.position.z);
                    }
                }

                else
                    Title.GetComponent<Image>().color = new Color(Title.GetComponent<Image>().color.r, Title.GetComponent<Image>().color.g, Title.GetComponent<Image>().color.b, Title.GetComponent<Image>().color.a + 0.001f);
            }

            //메인메뉴에서 기다리기
            if (step == 1)
            {
                P1_Button.GetComponent<RectTransform>().localScale = new Vector3(0.5f, 0.5f);
                P2_Button.GetComponent<RectTransform>().localScale = new Vector3(0.5f, 0.5f);
                Exit.GetComponent<RectTransform>().localScale = new Vector3(0.5f, 0.5f);
                P1_Button.GetComponent<RectTransform>().sizeDelta = new Vector3(510, 168);
                P2_Button.GetComponent<RectTransform>().sizeDelta = new Vector3(510, 168);
                Exit.GetComponent<RectTransform>().sizeDelta = new Vector3(510, 149);

                Title.GetComponent<RectTransform>().localPosition = new Vector3(0, 190, 0);
                P1_Button.GetComponent<RectTransform>().localPosition = new Vector3(0, 70, 0);
                P2_Button.GetComponent<RectTransform>().localPosition = new Vector3(0, -40, 0);
                Exit.GetComponent<RectTransform>().localPosition = new Vector3(0, -150, 0);
                VersionText.GetComponent<RectTransform>().localPosition = new Vector3(0, -250, 0);
                Setting.GetComponent<Image>().color = new Color(Setting.GetComponent<Image>().color.r, Setting.GetComponent<Image>().color.g, 1);
                
                if (Language == 1)
                {
                    Title.GetComponent<Image>().sprite = main_but[0];
                    Title.GetComponent<RectTransform>().sizeDelta = new Vector3(393, 135);
                    Title.GetComponent<RectTransform>().localScale = new Vector3(0.6f, 0.6f);
                    P1_Button.GetComponent<Image>().sprite = main_but[1];
                    P2_Button.GetComponent<Image>().sprite = main_but[2];
                    Exit.GetComponent<Image>().sprite = main_but[5];
                }

                else if (Language == 2)
                {
                    Title.GetComponent<Image>().sprite = main_but[84];
                    Title.GetComponent<RectTransform>().sizeDelta = new Vector3(321, 161);
                    Title.GetComponent<RectTransform>().localScale = new Vector3(0.7f, 0.7f);
                    P1_Button.GetComponent<Image>().sprite = main_but[85];
                    P2_Button.GetComponent<Image>().sprite = main_but[86];
                    Exit.GetComponent<Image>().sprite = main_but[89];
                }

                else if (Language == 3)
                {
                    Title.GetComponent<Image>().sprite = main_but[103];
                    Title.GetComponent<RectTransform>().sizeDelta = new Vector3(390, 138);
                    Title.GetComponent<RectTransform>().localScale = new Vector3(0.6f, 0.6f);
                    P1_Button.GetComponent<Image>().sprite = main_but[104];
                    P2_Button.GetComponent<Image>().sprite = main_but[105];
                    Exit.GetComponent<Image>().sprite = main_but[108];
                }

                number = 1;
                stage = 1;
                mode = 1;
                step_number = 0;
                step_stage = 0;
                step_mode = 0;

                card_number = 0;
                selected_card_number = 0;

                card_color = 0;
                selected_card_color = 0;

                stage_number = 0;
                selected_stage_number = 0;

                Selected_stage = new int[5];
                Selected_card = new int[4];
                Selected_card_color = new int[4];
                Last_Stage = 1;

            }

            //1P
            if (step == 10) // 1P를 눌렀을 때
            {
            }

            //1P이동 세팅
            if (step == 100)
            {
                P1_Button.GetComponent<RectTransform>().localScale = new Vector3(0.5f, 0.5f);
                P2_Button.GetComponent<RectTransform>().localScale = new Vector3(0.5f, 0.5f);
                P3_Button.GetComponent<RectTransform>().localScale = new Vector3(0.5f, 0.5f);
                Exit.GetComponent<RectTransform>().localScale = new Vector3(0.5f, 0.5f);
                step = 10;
            }

            if (step == 10) //버튼 자리이동 1
            {
                if (speed == 10)
                {
                    P1_Button.GetComponent<Image>().color = new Color(P1_Button.GetComponent<Image>().color.r, P1_Button.GetComponent<Image>().color.g, P1_Button.GetComponent<Image>().color.b, 1);
                    P2_Button.GetComponent<RectTransform>().localPosition = new Vector3(400, -10, P2_Button.transform.position.z);
                    P3_Button.GetComponent<RectTransform>().localPosition = new Vector3(400, 95, P3_Button.transform.position.z);
                    P4_Button.GetComponent<RectTransform>().localPosition = new Vector3(400, -125, P4_Button.transform.position.z);
                    Exit.GetComponent<RectTransform>().localPosition = new Vector3(400, -230, Exit.transform.position.z);
                    P3_Button.GetComponent<RectTransform>().sizeDelta = new Vector3(510, 150);
                    P2_Button.GetComponent<RectTransform>().sizeDelta = new Vector3(510, 164);
                    Exit.GetComponent<RectTransform>().sizeDelta = new Vector3(338, 112);
                    Exit.GetComponent<RectTransform>().localScale = new Vector3(0.4f, 0.4f);

                    if (Language == 1)
                    {
                        P3_Button.GetComponent<Image>().sprite = main_but[3];
                        P2_Button.GetComponent<Image>().sprite = main_but[6];
                        P4_Button.GetComponent<Image>().sprite = main_but[69];
                        Exit.GetComponent<Image>().sprite = main_but[12];
                    }

                    else if (Language == 2)
                    {
                        P3_Button.GetComponent<Image>().sprite = main_but[87];
                        P2_Button.GetComponent<Image>().sprite = main_but[90];
                        P4_Button.GetComponent<Image>().sprite = main_but[125];
                        Exit.GetComponent<Image>().sprite = main_but[95];
                    }

                    else if (Language == 3)
                    {
                        P3_Button.GetComponent<Image>().sprite = main_but[106];
                        P2_Button.GetComponent<Image>().sprite = main_but[109];
                        P4_Button.GetComponent<Image>().sprite = main_but[126];
                        Exit.GetComponent<Image>().sprite = main_but[114];
                    }

                    step = 11;
                }

                else
                {
                    Title.GetComponent<RectTransform>().localPosition = new Vector3(Title.GetComponent<RectTransform>().localPosition.x - (40 - 5 * speed), Title.GetComponent<RectTransform>().localPosition.y, Title.transform.position.z);
                    P1_Button.GetComponent<RectTransform>().localScale = new Vector3(P1_Button.GetComponent<RectTransform>().localScale.x + speed / 1000, P1_Button.GetComponent<RectTransform>().localScale.y + speed / 1000);
                    P1_Button.GetComponent<RectTransform>().localPosition = new Vector3(P1_Button.GetComponent<RectTransform>().localPosition.x, P1_Button.GetComponent<RectTransform>().localPosition.y + 1.5f * speed, P1_Button.transform.position.z);
                    P2_Button.GetComponent<RectTransform>().localPosition = new Vector3(P2_Button.GetComponent<RectTransform>().localPosition.x - (40 - 5 * speed), P2_Button.GetComponent<RectTransform>().localPosition.y, P2_Button.transform.position.z);
                    Exit.GetComponent<RectTransform>().localPosition = new Vector3(Exit.GetComponent<RectTransform>().localPosition.x - (40 - 5 * speed), Exit.GetComponent<RectTransform>().localPosition.y, Exit.transform.position.z);
                    VersionText.GetComponent<RectTransform>().localPosition = new Vector3(VersionText.GetComponent<RectTransform>().localPosition.x - (40 - 5 * speed), VersionText.GetComponent<RectTransform>().localPosition.y, VersionText.transform.position.z);

                    if (P1_Button.GetComponent<Image>().color.a <= 0)
                    {
                        P1_Button.GetComponent<Image>().color = new Color(P2_Button.GetComponent<Image>().color.r, P2_Button.GetComponent<Image>().color.g, P2_Button.GetComponent<Image>().color.b, P2_Button.GetComponent<Image>().color.a + 0.5f);
                    }

                    else
                        P1_Button.GetComponent<Image>().color = new Color(P2_Button.GetComponent<Image>().color.r, P2_Button.GetComponent<Image>().color.g, P2_Button.GetComponent<Image>().color.b, P2_Button.GetComponent<Image>().color.a - 0.5f);

                    speed += 0.5f;
                }
            }

            if (step == 11) //버튼 자리이동 2
            {
                if (P2_Button.GetComponent<RectTransform>().localPosition.x == 0)
                {
                    step = 12; //버튼이 선택되길 기다린다.
                }

                else
                {
                    P2_Button.GetComponent<RectTransform>().localPosition = new Vector3(P2_Button.GetComponent<RectTransform>().localPosition.x - 5f, P2_Button.GetComponent<RectTransform>().localPosition.y, P2_Button.transform.position.z);
                    P3_Button.GetComponent<RectTransform>().localPosition = new Vector3(P3_Button.GetComponent<RectTransform>().localPosition.x - 5f, P3_Button.GetComponent<RectTransform>().localPosition.y, P3_Button.transform.position.z);
                    P4_Button.GetComponent<RectTransform>().localPosition = new Vector3(P4_Button.GetComponent<RectTransform>().localPosition.x - 5f, P4_Button.GetComponent<RectTransform>().localPosition.y, P4_Button.transform.position.z);
                    Exit.GetComponent<RectTransform>().localPosition = new Vector3(Exit.GetComponent<RectTransform>().localPosition.x - 5f, Exit.GetComponent<RectTransform>().localPosition.y, Exit.transform.position.z);
                }
            }

            if(step == 12)
            {
                if (Input.GetKeyDown(KeyCode.Escape) && !SettingOn)
                    Go_Back();

                if (Language == 1)
                {
                    P1_Button.GetComponent<Image>().sprite = main_but[1];
                    P3_Button.GetComponent<Image>().sprite = main_but[3];
                    P2_Button.GetComponent<Image>().sprite = main_but[6];
                    P4_Button.GetComponent<Image>().sprite = main_but[69];
                    Exit.GetComponent<Image>().sprite = main_but[12];
                }

                else if (Language == 2)
                {
                    P1_Button.GetComponent<Image>().sprite = main_but[85];
                    P3_Button.GetComponent<Image>().sprite = main_but[87];
                    P2_Button.GetComponent<Image>().sprite = main_but[90];
                    P4_Button.GetComponent<Image>().sprite = main_but[125];
                    Exit.GetComponent<Image>().sprite = main_but[95];
                }

                else if (Language == 3)
                {
                    P1_Button.GetComponent<Image>().sprite = main_but[104];
                    P3_Button.GetComponent<Image>().sprite = main_but[106];
                    P2_Button.GetComponent<Image>().sprite = main_but[109];
                    P4_Button.GetComponent<Image>().sprite = main_but[126];
                    Exit.GetComponent<Image>().sprite = main_but[114];
                }
            }

            //선택하지 않고 돌아가기를 눌렀음
            if (step == 13) //버튼 자리이동 2
            {
                if (P2_Button.GetComponent<RectTransform>().localPosition.x == -400)
                {
                    P2_Button.GetComponent<Image>().sprite = main_but[2];
                    P2_Button.GetComponent<RectTransform>().sizeDelta = new Vector3(510, 164);
                    P1_Button.GetComponent<RectTransform>().localPosition = new Vector3(400, P1_Button.GetComponent<RectTransform>().localPosition.y, P1_Button.transform.position.z);
                    P2_Button.GetComponent<RectTransform>().localPosition = new Vector3(400, P2_Button.GetComponent<RectTransform>().localPosition.y, P2_Button.transform.position.z);
                    P3_Button.GetComponent<RectTransform>().localPosition = new Vector3(400, P3_Button.GetComponent<RectTransform>().localPosition.y, P3_Button.transform.position.z);
                    P4_Button.GetComponent<RectTransform>().localPosition = new Vector3(400, P4_Button.GetComponent<RectTransform>().localPosition.y, P4_Button.transform.position.z);
                    Exit.GetComponent<RectTransform>().localPosition = new Vector3(400, Exit.GetComponent<RectTransform>().localPosition.y, Exit.transform.position.z);
                    Exit.GetComponent<Image>().sprite = main_but[5];
                    step = 213; //버튼이 선택되길 기다린다.
                }

                else
                {
                    P1_Button.GetComponent<RectTransform>().localPosition = new Vector3(P1_Button.GetComponent<RectTransform>().localPosition.x - 5f, P1_Button.GetComponent<RectTransform>().localPosition.y, P1_Button.transform.position.z);
                    P2_Button.GetComponent<RectTransform>().localPosition = new Vector3(P2_Button.GetComponent<RectTransform>().localPosition.x - 5f, P2_Button.GetComponent<RectTransform>().localPosition.y, P2_Button.transform.position.z);
                    P3_Button.GetComponent<RectTransform>().localPosition = new Vector3(P3_Button.GetComponent<RectTransform>().localPosition.x - 5f, P3_Button.GetComponent<RectTransform>().localPosition.y, P3_Button.transform.position.z);
                    P4_Button.GetComponent<RectTransform>().localPosition = new Vector3(P4_Button.GetComponent<RectTransform>().localPosition.x - 5f, P4_Button.GetComponent<RectTransform>().localPosition.y, P4_Button.transform.position.z);
                    Exit.GetComponent<RectTransform>().localPosition = new Vector3(Exit.GetComponent<RectTransform>().localPosition.x - 5f, Exit.GetComponent<RectTransform>().localPosition.y, Exit.transform.position.z);
                }
            }

            if (step == 14)
            {
                step = 15;
                Fade.GetComponent<RectTransform>().localPosition = new Vector3(0, 0);
                Fade.GetComponent<Image>().color = new Color(0, 0, 0, 0);
            }

            if (step == 15)
            {
                Fade.GetComponent<Image>().color = new Color(0, 0, 0, Fade.GetComponent<Image>().color.a + 0.001f);
                Setting.GetComponent<Image>().color = new Color(0, 0, 0, Setting.GetComponent<Image>().color.a - 0.001f);
                MusicSource.volume -= 0.001f;

                if (Fade.GetComponent<Image>().color.a > 1)
                {
                    step = 16;
                }
            }

            if (step == 16)
            {
                Fade.GetComponent<RectTransform>().localPosition = new Vector3(0, 0);

                //출발!
                number = 1;
                stage = 1;
                step_number = 0;
                step_stage = 0;

                card_number = 0;
                selected_card_number = 0;

                card_color = 0;
                selected_card_color = 0;

                stage_number = 0;
                selected_stage_number = 0;
                step = 0;
                speed = 0.5f;

                Title.GetComponent<Image>().color = new Color(Title.GetComponent<Image>().color.r, Title.GetComponent<Image>().color.g, Title.GetComponent<Image>().color.b, 0);
                P1_Button.GetComponent<RectTransform>().localPosition = new Vector3(285, P1_Button.GetComponent<RectTransform>().localPosition.y, P1_Button.transform.position.z);
                P2_Button.GetComponent<RectTransform>().localPosition = new Vector3(285, P2_Button.GetComponent<RectTransform>().localPosition.y, P2_Button.transform.position.z);
                Exit.GetComponent<RectTransform>().localPosition = new Vector3(285, Exit.GetComponent<RectTransform>().localPosition.y, Exit.transform.position.z);

                SceneManager.LoadScene("Tutorial");
            }

            if (step == 17)
            {
                step = 18;
                Fade.GetComponent<RectTransform>().localPosition = new Vector3(0, 0);
                Fade.GetComponent<Image>().color = new Color(0, 0, 0, 0);
            }

            if (step == 18)
            {
                Fade.GetComponent<Image>().color = new Color(0, 0, 0, Fade.GetComponent<Image>().color.a + 0.001f);
                Setting.GetComponent<Image>().color = new Color(0, 0, 0, Setting.GetComponent<Image>().color.a - 0.001f);
                MusicSource.volume -= 0.001f;

                if (Fade.GetComponent<Image>().color.a > 1)
                {
                    step = 19;
                }
            }

            if (step == 19)
            {
                Fade.GetComponent<RectTransform>().localPosition = new Vector3(0, 0);

                //출발!
                number = 1;
                stage = 1;
                step_number = 0;
                step_stage = 0;

                card_number = 0;
                selected_card_number = 0;

                card_color = 0;
                selected_card_color = 0;

                stage_number = 0;
                selected_stage_number = 0;
                step = 0;
                speed = 0.5f;

                Title.GetComponent<Image>().color = new Color(Title.GetComponent<Image>().color.r, Title.GetComponent<Image>().color.g, Title.GetComponent<Image>().color.b, 0);
                P1_Button.GetComponent<RectTransform>().localPosition = new Vector3(285, P1_Button.GetComponent<RectTransform>().localPosition.y, P1_Button.transform.position.z);
                P2_Button.GetComponent<RectTransform>().localPosition = new Vector3(285, P2_Button.GetComponent<RectTransform>().localPosition.y, P2_Button.transform.position.z);
                Exit.GetComponent<RectTransform>().localPosition = new Vector3(285, Exit.GetComponent<RectTransform>().localPosition.y, Exit.transform.position.z);

                SceneManager.LoadScene("Challenge");
            }

            //1P 연습하기 모드
            if (step == 1120)
            {
                P1_Button.GetComponent<RectTransform>().localScale = new Vector3(0.4f, 0.4f);
                P2_Button.GetComponent<RectTransform>().localScale = new Vector3(0.4f, 0.4f);
                P3_Button.GetComponent<RectTransform>().localScale = new Vector3(0.4f, 0.4f);
                P4_Button.GetComponent<RectTransform>().localScale = new Vector3(0.4f, 0.4f);
                Exit.GetComponent<RectTransform>().localScale = new Vector3(0.4f, 0.4f);
                step = 1121;
                speed = 0.5f;
            }

            if (step == 1121)
            {
                if (speed == 10)
                {
                    P2_Button.GetComponent<Image>().color = new Color(P2_Button.GetComponent<Image>().color.r, P2_Button.GetComponent<Image>().color.g, P2_Button.GetComponent<Image>().color.b, 1);
                    speed = 0.5f;
                    Player1Mode = true;
                    step = 21;
                }

                else
                {
                    P3_Button.GetComponent<RectTransform>().localPosition = new Vector3(P3_Button.GetComponent<RectTransform>().localPosition.x - (40 - 5 * speed), P3_Button.GetComponent<RectTransform>().localPosition.y, P3_Button.transform.position.z);
                    P1_Button.GetComponent<RectTransform>().localPosition = new Vector3(P1_Button.GetComponent<RectTransform>().localPosition.x - (40 - 5 * speed), P1_Button.GetComponent<RectTransform>().localPosition.y, P1_Button.transform.position.z);
                    P2_Button.GetComponent<RectTransform>().localPosition = new Vector3(P2_Button.GetComponent<RectTransform>().localPosition.x, P2_Button.GetComponent<RectTransform>().localPosition.y + 2.35f * speed, P2_Button.transform.position.z);
                    P2_Button.GetComponent<RectTransform>().localScale = new Vector3(P2_Button.GetComponent<RectTransform>().localScale.x + speed / 700, P2_Button.GetComponent<RectTransform>().localScale.y + speed / 700);
                    Exit.GetComponent<RectTransform>().localPosition = new Vector3(Exit.GetComponent<RectTransform>().localPosition.x - (40 - 5 * speed), Exit.GetComponent<RectTransform>().localPosition.y, Exit.transform.position.z);
                    P4_Button.GetComponent<RectTransform>().localPosition = new Vector3(P4_Button.GetComponent<RectTransform>().localPosition.x - (40 - 5 * speed), P4_Button.GetComponent<RectTransform>().localPosition.y, P4_Button.transform.position.z);

                    if (P2_Button.GetComponent<Image>().color.a <= 0)
                    {
                        P2_Button.GetComponent<RectTransform>().sizeDelta = new Vector3(578, 169);
                        P2_Button.GetComponent<Image>().color = new Color(P2_Button.GetComponent<Image>().color.r, P2_Button.GetComponent<Image>().color.g, P2_Button.GetComponent<Image>().color.b, P2_Button.GetComponent<Image>().color.a + 0.5f);
                    }

                    else
                        P2_Button.GetComponent<Image>().color = new Color(P2_Button.GetComponent<Image>().color.r, P2_Button.GetComponent<Image>().color.g, P2_Button.GetComponent<Image>().color.b, P2_Button.GetComponent<Image>().color.a - 0.5f);

                    speed += 0.5f;
                }
            }

            //추가버튼 등장
            if (step == 1124)
            {
                if (Plus.GetComponent<Image>().color.a >= 1)
                {
                    //미리 랜덤으로 선택하기
                    for (int i = 0; i < 4; i++) // 총 3개를 추출할 것이다.
                    {
                        while (true) // 중복되는 지 확인이 될 때까지 하므로 while을 써서 반복한다.
                        {
                            Selected_card[i] = Random.Range(0, 8); // 0에서 6 중에서 1개를 골라 해당 배열에 넣는다.
                            isSame = false; // 기본은 false값으로 주어진다.

                            for (int j = 0; j < i; j++) // 중복을 확인합니다.
                            {
                                if (Selected_card[j] == Selected_card[i])
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

                        while (true) // 중복되는 지 확인이 될 때까지 하므로 while을 써서 반복한다.
                        {
                            Selected_card_color[i] = Random.Range(0, 7); // 0에서 6 중에서 1개를 골라 해당 배열에 넣는다.
                            isSame = false; // 기본은 false값으로 주어진다.

                            for (int j = 0; j < i; j++) // 중복을 확인합니다.
                            {
                                if (Selected_card_color[j] == Selected_card_color[i])
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

                    step = 24;
                }

                else
                {
                    Plus.GetComponent<Image>().color = new Color(Plus.GetComponent<Image>().color.r, Plus.GetComponent<Image>().color.g, Plus.GetComponent<Image>().color.b, Plus.GetComponent<Image>().color.a + 0.01f);
                    Minus.GetComponent<Image>().color = new Color(Minus.GetComponent<Image>().color.r, Minus.GetComponent<Image>().color.g, Minus.GetComponent<Image>().color.b, Minus.GetComponent<Image>().color.a + 0.01f);
                    Next.GetComponent<Image>().color = new Color(Next.GetComponent<Image>().color.r, Next.GetComponent<Image>().color.g, Next.GetComponent<Image>().color.b, Next.GetComponent<Image>().color.a + 0.01f);
                    BackNext.GetComponent<Image>().color = new Color(BackNext.GetComponent<Image>().color.r, BackNext.GetComponent<Image>().color.g, BackNext.GetComponent<Image>().color.b, BackNext.GetComponent<Image>().color.a + 0.01f);
                    Next2.GetComponent<Image>().color = new Color(Next2.GetComponent<Image>().color.r, Next2.GetComponent<Image>().color.g, Next2.GetComponent<Image>().color.b, Next2.GetComponent<Image>().color.a + 0.01f);
                    BackNext2.GetComponent<Image>().color = new Color(BackNext2.GetComponent<Image>().color.r, BackNext2.GetComponent<Image>().color.g, BackNext2.GetComponent<Image>().color.b, BackNext2.GetComponent<Image>().color.a + 0.01f);
                    Number.GetComponent<Image>().color = new Color(Number.GetComponent<Image>().color.r, Number.GetComponent<Image>().color.g, Number.GetComponent<Image>().color.b, Number.GetComponent<Image>().color.a + 0.01f);
                    Stage.GetComponent<Image>().color = new Color(Stage.GetComponent<Image>().color.r, Stage.GetComponent<Image>().color.g, Stage.GetComponent<Image>().color.b, Stage.GetComponent<Image>().color.a + 0.01f);
                    Mode.GetComponent<Image>().color = new Color(Mode.GetComponent<Image>().color.r, Mode.GetComponent<Image>().color.g, Mode.GetComponent<Image>().color.b, Mode.GetComponent<Image>().color.a + 0.01f);

                    for (int i = 0; i < 21; i++)
                        Card[i].GetComponent<Image>().color = new Color(Card[i].GetComponent<Image>().color.r, Card[i].GetComponent<Image>().color.g, Card[i].GetComponent<Image>().color.b, Card[i].GetComponent<Image>().color.a + 0.01f);
                }
            }

            //2P
            //2P이동 세팅
            if (step == 200)
            {
                P1_Button.GetComponent<RectTransform>().localScale = new Vector3(0.4f, 0.4f);
                P2_Button.GetComponent<RectTransform>().localScale = new Vector3(0.4f, 0.4f);
                Exit.GetComponent<RectTransform>().localScale = new Vector3(0.4f, 0.4f);
                step = 20;
            }

            if (step == 20) //버튼 자리이동 1
            {
                if (speed == 10)
                {
                    P2_Button.GetComponent<Image>().color = new Color(P2_Button.GetComponent<Image>().color.r, P2_Button.GetComponent<Image>().color.g, P2_Button.GetComponent<Image>().color.b, 1);
                    speed = 0.5f;
                    step = 21;
                }

                else
                {
                    Title.GetComponent<RectTransform>().localPosition = new Vector3(Title.GetComponent<RectTransform>().localPosition.x - (40 - 5 * speed), Title.GetComponent<RectTransform>().localPosition.y, Title.transform.position.z);
                    P1_Button.GetComponent<RectTransform>().localPosition = new Vector3(P1_Button.GetComponent<RectTransform>().localPosition.x - (40 - 5 * speed), P1_Button.GetComponent<RectTransform>().localPosition.y, P1_Button.transform.position.z);
                    P2_Button.GetComponent<RectTransform>().localPosition = new Vector3(P2_Button.GetComponent<RectTransform>().localPosition.x, P2_Button.GetComponent<RectTransform>().localPosition.y + 2.8f * speed, P2_Button.transform.position.z);
                    P2_Button.GetComponent<RectTransform>().localScale = new Vector3(P2_Button.GetComponent<RectTransform>().localScale.x + speed / 700, P2_Button.GetComponent<RectTransform>().localScale.y + speed / 700);
                    Exit.GetComponent<RectTransform>().localPosition = new Vector3(Exit.GetComponent<RectTransform>().localPosition.x - (40 - 5 * speed), Exit.GetComponent<RectTransform>().localPosition.y, Exit.transform.position.z);
                    VersionText.GetComponent<RectTransform>().localPosition = new Vector3(VersionText.GetComponent<RectTransform>().localPosition.x - (40 - 5 * speed), VersionText.GetComponent<RectTransform>().localPosition.y, VersionText.transform.position.z);


                    if (P2_Button.GetComponent<Image>().color.a <= 0)
                    {
                        P2_Button.GetComponent<RectTransform>().sizeDelta = new Vector3(578, 169);
                        P2_Button.GetComponent<Image>().color = new Color(P2_Button.GetComponent<Image>().color.r, P2_Button.GetComponent<Image>().color.g, P2_Button.GetComponent<Image>().color.b, P2_Button.GetComponent<Image>().color.a + 0.5f);
                    }

                    else
                        P2_Button.GetComponent<Image>().color = new Color(P2_Button.GetComponent<Image>().color.r, P2_Button.GetComponent<Image>().color.g, P2_Button.GetComponent<Image>().color.b, P2_Button.GetComponent<Image>().color.a - 0.5f);

                    speed += 0.5f;
                }
            }

            //다음에 나오는 이미지 등장하기
            if (step == 21)
            {
                //설정모드
                if (Language == 1)
                {
                    Select1.GetComponent<Image>().sprite = main_but[7]; //스테이지
                    Select2.GetComponent<Image>().sprite = main_but[11]; //모드 선택
                    Select3.GetComponent<Image>().sprite = main_but[127]; //문양 선택
                    Select4.GetComponent<Image>().sprite = main_but[12]; //돌아가기
                    Select5.GetComponent<Image>().sprite = main_but[13]; //시작
                    Select6.GetComponent<Image>().sprite = main_but[8]; //제한시간
                }

                else if (Language == 2)
                {
                    Select1.GetComponent<Image>().sprite = main_but[91]; //스테이지
                    Select2.GetComponent<Image>().sprite = main_but[94]; //모드 선택
                    Select3.GetComponent<Image>().sprite = main_but[93]; //문양 선택
                    Select4.GetComponent<Image>().sprite = main_but[95]; //돌아가기
                    Select5.GetComponent<Image>().sprite = main_but[96]; //시작
                    Select6.GetComponent<Image>().sprite = main_but[92]; //제한시간
                }

                else if (Language == 3)
                {
                    Select1.GetComponent<Image>().sprite = main_but[110]; //스테이지
                    Select2.GetComponent<Image>().sprite = main_but[113]; //모드 선택
                    Select3.GetComponent<Image>().sprite = main_but[112]; //문양 선택
                    Select4.GetComponent<Image>().sprite = main_but[114]; //돌아가기
                    Select5.GetComponent<Image>().sprite = main_but[115]; //시작
                    Select6.GetComponent<Image>().sprite = main_but[111]; //제한시간
                }

                Plus.GetComponent<Image>().sprite = main_but[56];
                Minus.GetComponent<Image>().sprite = main_but[57];
                Plus2.GetComponent<Image>().sprite = main_but[56];
                Minus2.GetComponent<Image>().sprite = main_but[57];
                Next.GetComponent<Image>().sprite = main_but[58];
                BackNext.GetComponent<Image>().sprite = main_but[58];
                Number.GetComponent<Image>().sprite = main_number[6];
                Number2.GetComponent<Image>().sprite = main_number[6];
                Stage.GetComponent<Image>().sprite = main_but[61];

                for (int i = 0; i < 8; i++) //모양
                    Card[i].GetComponent<Image>().sprite = main_but[14 + i];

                for (int i = 8; i < 15; i++) //색깔
                    Card[i].GetComponent<Image>().sprite = main_but[14 + i];

                for (int i = 16; i < 20; i++) //모드
                    Card[i].GetComponent<Image>().sprite = main_but[28 + i];
                Card[20].GetComponent<Image>().sprite = main_but[49];

                Select1.GetComponent<RectTransform>().localPosition = new Vector3(400, 120);
                Select2.GetComponent<RectTransform>().localPosition = new Vector3(400, 30);
                Select3.GetComponent<RectTransform>().localPosition = new Vector3(400, -90);
                Select4.GetComponent<RectTransform>().localPosition = new Vector3(310, -230);
                Select5.GetComponent<RectTransform>().localPosition = new Vector3(400, -230);
                Select6.GetComponent<RectTransform>().localPosition = new Vector3(400, 30);

                Plus.GetComponent<RectTransform>().localPosition = new Vector3(125, 120);
                Minus.GetComponent<RectTransform>().localPosition = new Vector3(15, 120);
                Plus2.GetComponent<RectTransform>().localPosition = new Vector3(400, 120);
                Minus2.GetComponent<RectTransform>().localPosition = new Vector3(400, 120);
                Number.GetComponent<RectTransform>().localPosition = new Vector3(70, 120);

                Next.GetComponent<RectTransform>().localPosition = new Vector3(130, 30);
                BackNext.GetComponent<RectTransform>().localPosition = new Vector3(20, 30);
                Stage.GetComponent<RectTransform>().localPosition = new Vector3(75, 30);

                for (int i = 0; i < 8; i++)
                    Card[i].GetComponent<RectTransform>().localPosition = new Vector3(-140 + 240 / 6 * i, -135);

                for (int i = 8; i < 15; i++)
                    Card[i].GetComponent<RectTransform>().localPosition = new Vector3(-123 + 250 / 6 * (i - 8), -170);

                for (int i = 16; i < 21; i++)
                    Card[i].GetComponent<RectTransform>().localPosition = new Vector3(-100 + 50 * (i - 16), -15);


                Plus.GetComponent<Image>().color = new Color(Plus.GetComponent<Image>().color.r, Plus.GetComponent<Image>().color.g, Plus.GetComponent<Image>().color.b, 0);
                Minus.GetComponent<Image>().color = new Color(Minus.GetComponent<Image>().color.r, Minus.GetComponent<Image>().color.g, Minus.GetComponent<Image>().color.b, 0);
                Plus2.GetComponent<Image>().color = new Color(Plus2.GetComponent<Image>().color.r, Plus2.GetComponent<Image>().color.g, Plus2.GetComponent<Image>().color.b, 0);
                Minus2.GetComponent<Image>().color = new Color(Minus2.GetComponent<Image>().color.r, Minus2.GetComponent<Image>().color.g, Minus2.GetComponent<Image>().color.b, 0);
                Next.GetComponent<Image>().color = new Color(Next.GetComponent<Image>().color.r, Next.GetComponent<Image>().color.g, Next.GetComponent<Image>().color.b, 0);
                BackNext.GetComponent<Image>().color = new Color(BackNext.GetComponent<Image>().color.r, BackNext.GetComponent<Image>().color.g, BackNext.GetComponent<Image>().color.b, 0);
                Number.GetComponent<Image>().color = new Color(Number.GetComponent<Image>().color.r, Number.GetComponent<Image>().color.g, Number.GetComponent<Image>().color.b, 0);
                Stage.GetComponent<Image>().color = new Color(Stage.GetComponent<Image>().color.r, Stage.GetComponent<Image>().color.g, Stage.GetComponent<Image>().color.b, 0);

                for (int i = 0; i < 21; i++)
                    Card[i].GetComponent<Image>().color = new Color(Card[i].GetComponent<Image>().color.r, Card[i].GetComponent<Image>().color.g, Card[i].GetComponent<Image>().color.b, 0);

                Select4.GetComponent<RectTransform>().sizeDelta = new Vector3(338, 112);
                Select5.GetComponent<RectTransform>().sizeDelta = new Vector3(194, 112);
                Select6.GetComponent<RectTransform>().sizeDelta = new Vector3(676, 97);
                Plus.GetComponent<RectTransform>().sizeDelta = new Vector3(82, 82);
                Plus.GetComponent<RectTransform>().sizeDelta = new Vector3(82, 82);
                Minus.GetComponent<RectTransform>().sizeDelta = new Vector3(81, 82);
                Plus2.GetComponent<RectTransform>().sizeDelta = new Vector3(82, 82);
                Minus2.GetComponent<RectTransform>().sizeDelta = new Vector3(81, 82);
                Next.GetComponent<RectTransform>().sizeDelta = new Vector3(82, 82);
                BackNext.GetComponent<RectTransform>().sizeDelta = new Vector3(82, 82);
                Number.GetComponent<RectTransform>().sizeDelta = new Vector3(47, 100);
                Stage.GetComponent<RectTransform>().sizeDelta = new Vector3(135, 72);

                for (int i = 0; i < 22; i++)
                    Card[i].GetComponent<RectTransform>().sizeDelta = new Vector3(80, 80);

                Next.GetComponent<RectTransform>().transform.rotation = Quaternion.Euler(0, 0, 180);

                //이렇게 세팅했는데 만약에 플레이어1모드였었다면
                if (Player1Mode)
                {
                    Select1.GetComponent<RectTransform>().localPosition = new Vector3(400, 130);
                    Plus.GetComponent<RectTransform>().localPosition = new Vector3(125, 130);
                    Minus.GetComponent<RectTransform>().localPosition = new Vector3(15, 130);
                    Number.GetComponent<RectTransform>().localPosition = new Vector3(70, 130);

                    Select2.GetComponent<RectTransform>().localPosition = new Vector3(400, 70);
                    Next.GetComponent<RectTransform>().localPosition = new Vector3(130, 70);
                    BackNext.GetComponent<RectTransform>().localPosition = new Vector3(20, 70);
                    Stage.GetComponent<RectTransform>().localPosition = new Vector3(75, 70);

                    for (int i = 16; i < 22; i++)
                        Card[i].GetComponent<RectTransform>().localPosition = new Vector3(-120 + 48 * (i - 16), 25);

                    Card[21].GetComponent<Image>().sprite = main_but[48];

                    Select6.GetComponent<RectTransform>().localPosition = new Vector3(400, -30);
                    Select6.GetComponent<RectTransform>().localScale = new Vector3(0.45f, 0.45f);
                    Plus2.GetComponent<RectTransform>().localPosition = new Vector3(50, -30);
                    Minus2.GetComponent<RectTransform>().localPosition = new Vector3(15, -30);
                    Number2.GetComponent<RectTransform>().localPosition = new Vector3(90, -30);
                    Number2.GetComponent<RectTransform>().sizeDelta = new Vector3(47, 100);

                    Select6.GetComponent<Image>().color = new Color(Select6.GetComponent<Image>().color.r, Select6.GetComponent<Image>().color.g, Select6.GetComponent<Image>().color.b, 0.3f);
                    Number2.GetComponent<Image>().color = new Color(Number2.GetComponent<Image>().color.r, Number2.GetComponent<Image>().color.g, Number2.GetComponent<Image>().color.b, 0f);
                }

                step = 22;
            }

            //버튼 자리이동 2
            if (step == 22)
            {
                if (Select1.GetComponent<RectTransform>().localPosition.x == 0)
                {
                    Select1.GetComponent<RectTransform>().localPosition = new Vector3(Select1.GetComponent<RectTransform>().localPosition.x, Select1.GetComponent<RectTransform>().localPosition.y, Select1.transform.position.z);
                }

                else
                    Select1.GetComponent<RectTransform>().localPosition = new Vector3(Select1.GetComponent<RectTransform>().localPosition.x - 10, Select1.GetComponent<RectTransform>().localPosition.y, Select1.transform.position.z);

                if (Select1.GetComponent<RectTransform>().localPosition.x <= 250)
                {
                    if (Select2.GetComponent<RectTransform>().localPosition.x == 0)
                        Select2.GetComponent<RectTransform>().localPosition = new Vector3(Select2.GetComponent<RectTransform>().localPosition.x, Select2.GetComponent<RectTransform>().localPosition.y, Select2.transform.position.z);

                    else
                        Select2.GetComponent<RectTransform>().localPosition = new Vector3(Select2.GetComponent<RectTransform>().localPosition.x - 10, Select2.GetComponent<RectTransform>().localPosition.y, Select2.transform.position.z);
                }

                if (Select2.GetComponent<RectTransform>().localPosition.x <= 250)
                {
                    //2P모드
                    if (!Player1Mode)
                    {
                        if (Select3.GetComponent<RectTransform>().localPosition.x == 0)
                            Select3.GetComponent<RectTransform>().localPosition = new Vector3(Select3.GetComponent<RectTransform>().localPosition.x, Select3.GetComponent<RectTransform>().localPosition.y, Select3.transform.position.z);

                        else
                            Select3.GetComponent<RectTransform>().localPosition = new Vector3(Select3.GetComponent<RectTransform>().localPosition.x - 10, Select3.GetComponent<RectTransform>().localPosition.y, Select3.transform.position.z);
                    }

                    else
                    {
                        if (Select6.GetComponent<RectTransform>().localPosition.x == 0)
                            Select6.GetComponent<RectTransform>().localPosition = new Vector3(Select6.GetComponent<RectTransform>().localPosition.x, Select6.GetComponent<RectTransform>().localPosition.y, Select6.transform.position.z);

                        else
                            Select6.GetComponent<RectTransform>().localPosition = new Vector3(Select6.GetComponent<RectTransform>().localPosition.x - 10, Select6.GetComponent<RectTransform>().localPosition.y, Select6.transform.position.z);
                    }
                }

                if (Player1Mode)
                {
                    if (Select6.GetComponent<RectTransform>().localPosition.x <= 250)
                    {
                        if (Select3.GetComponent<RectTransform>().localPosition.x == 0)
                            Select3.GetComponent<RectTransform>().localPosition = new Vector3(Select3.GetComponent<RectTransform>().localPosition.x, Select3.GetComponent<RectTransform>().localPosition.y, Select3.transform.position.z);

                        else
                            Select3.GetComponent<RectTransform>().localPosition = new Vector3(Select3.GetComponent<RectTransform>().localPosition.x - 10, Select3.GetComponent<RectTransform>().localPosition.y, Select3.transform.position.z);
                    }
                }

                if (Select3.GetComponent<RectTransform>().localPosition.x <= 250)
                {
                    if (Select4.GetComponent<RectTransform>().localPosition.x == -90)
                        Select4.GetComponent<RectTransform>().localPosition = new Vector3(Select4.GetComponent<RectTransform>().localPosition.x, Select4.GetComponent<RectTransform>().localPosition.y, Select4.transform.position.z);

                    else
                        Select4.GetComponent<RectTransform>().localPosition = new Vector3(Select4.GetComponent<RectTransform>().localPosition.x - 10, Select4.GetComponent<RectTransform>().localPosition.y, Select4.transform.position.z);
                }

                if (Select4.GetComponent<RectTransform>().localPosition.x <= 250)
                {
                    if (Select5.GetComponent<RectTransform>().localPosition.x == 30)
                    {
                        Select5.GetComponent<RectTransform>().localPosition = new Vector3(Select5.GetComponent<RectTransform>().localPosition.x, Select5.GetComponent<RectTransform>().localPosition.y, Select5.transform.position.z);
                        step = 23;
                    }

                    else
                        Select5.GetComponent<RectTransform>().localPosition = new Vector3(Select5.GetComponent<RectTransform>().localPosition.x - 10, Select5.GetComponent<RectTransform>().localPosition.y, Select5.transform.position.z);
                }
            }

            //추가버튼 등장
            if (step == 23)
            {
                if (Plus.GetComponent<Image>().color.a >= 1)
                {
                    //미리 랜덤으로 선택하기
                    for (int i = 0; i < 4; i++) // 총 3개를 추출할 것이다.
                    {
                        while (true) // 중복되는 지 확인이 될 때까지 하므로 while을 써서 반복한다.
                        {
                            Selected_card[i] = Random.Range(0, 8); // 0에서 6 중에서 1개를 골라 해당 배열에 넣는다.
                            isSame = false; // 기본은 false값으로 주어진다.

                            for (int j = 0; j < i; j++) // 중복을 확인합니다.
                            {
                                if (Selected_card[j] == Selected_card[i])
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

                        while (true) // 중복되는 지 확인이 될 때까지 하므로 while을 써서 반복한다.
                        {
                            Selected_card_color[i] = Random.Range(0, 7); // 0에서 6 중에서 1개를 골라 해당 배열에 넣는다.
                            isSame = false; // 기본은 false값으로 주어진다.

                            for (int j = 0; j < i; j++) // 중복을 확인합니다.
                            {
                                if (Selected_card_color[j] == Selected_card_color[i])
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

                    step = 24;
                }

                else
                {
                    Plus.GetComponent<Image>().color = new Color(Plus.GetComponent<Image>().color.r, Plus.GetComponent<Image>().color.g, Plus.GetComponent<Image>().color.b, Plus.GetComponent<Image>().color.a + 0.01f);
                    Minus.GetComponent<Image>().color = new Color(Minus.GetComponent<Image>().color.r, Minus.GetComponent<Image>().color.g, Minus.GetComponent<Image>().color.b, Minus.GetComponent<Image>().color.a + 0.01f);
                    Next.GetComponent<Image>().color = new Color(Next.GetComponent<Image>().color.r, Next.GetComponent<Image>().color.g, Next.GetComponent<Image>().color.b, Next.GetComponent<Image>().color.a + 0.01f);
                    BackNext.GetComponent<Image>().color = new Color(BackNext.GetComponent<Image>().color.r, BackNext.GetComponent<Image>().color.g, BackNext.GetComponent<Image>().color.b, BackNext.GetComponent<Image>().color.a + 0.01f);
                    Number.GetComponent<Image>().color = new Color(Number.GetComponent<Image>().color.r, Number.GetComponent<Image>().color.g, Number.GetComponent<Image>().color.b, Number.GetComponent<Image>().color.a + 0.01f);
                    Stage.GetComponent<Image>().color = new Color(Stage.GetComponent<Image>().color.r, Stage.GetComponent<Image>().color.g, Stage.GetComponent<Image>().color.b, Stage.GetComponent<Image>().color.a + 0.01f);

                    for (int i = 0; i < 22; i++)
                        Card[i].GetComponent<Image>().color = new Color(Card[i].GetComponent<Image>().color.r, Card[i].GetComponent<Image>().color.g, Card[i].GetComponent<Image>().color.b, Card[i].GetComponent<Image>().color.a + 0.01f);
                }
            }

            //버튼 누르기
            if (step == 24)
            {
                if (Input.GetKeyDown(KeyCode.Escape) && !SettingOn)
                    Go_Back();

                CardModeName();

                //설정모드
                if (Language == 1)
                {
                    P2_Button.GetComponent<Image>().sprite = main_but[4];
                    Select1.GetComponent<Image>().sprite = main_but[7]; //스테이지
                    Select2.GetComponent<Image>().sprite = main_but[11]; //모드 선택
                    Select3.GetComponent<Image>().sprite = main_but[127]; //문양 선택
                    Select4.GetComponent<Image>().sprite = main_but[12]; //돌아가기
                    Select5.GetComponent<Image>().sprite = main_but[13]; //시작
                    Select6.GetComponent<Image>().sprite = main_but[8]; //제한시간

                    if(Player1Mode)
                    {
                        Plus2.GetComponent<RectTransform>().localPosition = new Vector3(50, Plus2.GetComponent<RectTransform>().localPosition.y);
                        Minus2.GetComponent<RectTransform>().localPosition = new Vector3(15, Minus2.GetComponent<RectTransform>().localPosition.y);
                        Number2.GetComponent<RectTransform>().localPosition = new Vector3(90, Number2.GetComponent<RectTransform>().localPosition.y);
                    }
                }

                else if (Language == 2)
                {
                    P2_Button.GetComponent<Image>().sprite = main_but[88];
                    Select1.GetComponent<Image>().sprite = main_but[91]; //스테이지
                    Select2.GetComponent<Image>().sprite = main_but[94]; //모드 선택
                    Select3.GetComponent<Image>().sprite = main_but[93]; //문양 선택
                    Select4.GetComponent<Image>().sprite = main_but[95]; //돌아가기
                    Select5.GetComponent<Image>().sprite = main_but[96]; //시작
                    Select6.GetComponent<Image>().sprite = main_but[92]; //제한시간

                    if (Player1Mode)
                    {
                        Plus2.GetComponent<RectTransform>().localPosition = new Vector3(20, Plus2.GetComponent<RectTransform>().localPosition.y);
                        Minus2.GetComponent<RectTransform>().localPosition = new Vector3(-15, Minus2.GetComponent<RectTransform>().localPosition.y);
                        Number2.GetComponent<RectTransform>().localPosition = new Vector3(60, Number2.GetComponent<RectTransform>().localPosition.y);
                    }
                }

                else if (Language == 3)
                {
                    P2_Button.GetComponent<Image>().sprite = main_but[107];
                    Select1.GetComponent<Image>().sprite = main_but[110]; //스테이지
                    Select2.GetComponent<Image>().sprite = main_but[113]; //모드 선택
                    Select3.GetComponent<Image>().sprite = main_but[112]; //문양 선택
                    Select4.GetComponent<Image>().sprite = main_but[114]; //돌아가기
                    Select5.GetComponent<Image>().sprite = main_but[115]; //시작
                    Select6.GetComponent<Image>().sprite = main_but[111]; //제한시간

                    if (Player1Mode)
                    {
                        Plus2.GetComponent<RectTransform>().localPosition = new Vector3(20, Plus2.GetComponent<RectTransform>().localPosition.y);
                        Minus2.GetComponent<RectTransform>().localPosition = new Vector3(-15, Minus2.GetComponent<RectTransform>().localPosition.y);
                        Number2.GetComponent<RectTransform>().localPosition = new Vector3(75, Number2.GetComponent<RectTransform>().localPosition.y);
                    }
                }
            }

            //버튼 누르기
            if (step == 241)
            {
                if (TimeAttack)
                {
                    Select6.GetComponent<Image>().color = new Color(Select6.GetComponent<Image>().color.r, Select6.GetComponent<Image>().color.g, Select6.GetComponent<Image>().color.b, 1f);
                    Number2.GetComponent<Image>().color = new Color(Number2.GetComponent<Image>().color.r, Number2.GetComponent<Image>().color.g, Number2.GetComponent<Image>().color.b, 1f);
                    Plus2.GetComponent<Image>().color = new Color(Plus2.GetComponent<Image>().color.r, Plus2.GetComponent<Image>().color.g, Plus2.GetComponent<Image>().color.b, 1f);
                    Minus2.GetComponent<Image>().color = new Color(Minus2.GetComponent<Image>().color.r, Minus2.GetComponent<Image>().color.g, Minus2.GetComponent<Image>().color.b, 1f);
                }

                else
                {
                    Select6.GetComponent<Image>().color = new Color(Select6.GetComponent<Image>().color.r, Select6.GetComponent<Image>().color.g, Select6.GetComponent<Image>().color.b, 0.3f);
                    Number2.GetComponent<Image>().color = new Color(Number2.GetComponent<Image>().color.r, Number2.GetComponent<Image>().color.g, Number2.GetComponent<Image>().color.b, 0f);
                    Plus2.GetComponent<Image>().color = new Color(Plus2.GetComponent<Image>().color.r, Plus2.GetComponent<Image>().color.g, Plus2.GetComponent<Image>().color.b, 0f);
                    Minus2.GetComponent<Image>().color = new Color(Minus2.GetComponent<Image>().color.r, Minus2.GetComponent<Image>().color.g, Minus2.GetComponent<Image>().color.b, 0f);
                    time = 60;
                    Number2.GetComponent<RectTransform>().sizeDelta = new Vector3(47, 100);
                    Number2.GetComponent<Image>().sprite = main_number[6];
                }

                step = 24;
            }

            //1P와 2P에 대한 각 모드들에 대해서

            //스테이지 수 추가
            if (step == 25)
            {
                //1. 추가 넘버를 쓴다.
                if (step_number == 0)
                {
                    //1플레이어모드가 아닐 때는 2씩 올라간다(홀수)
                    if (!Player1Mode)
                        number += 2;

                    else
                    {
                        number++;
                    }

                    if (number == 1)
                        Number.GetComponent<RectTransform>().sizeDelta = new Vector3(47, 100);

                    else if (number == 2)
                        Number.GetComponent<RectTransform>().sizeDelta = new Vector3(69, 101);

                    else if (number == 3)
                        Number.GetComponent<RectTransform>().sizeDelta = new Vector3(71, 101);

                    else if (number == 4)
                        Number.GetComponent<RectTransform>().sizeDelta = new Vector3(73, 100);

                    else if (number == 5)
                        Number.GetComponent<RectTransform>().sizeDelta = new Vector3(70, 101);

                    else if (number == 6)
                        Number.GetComponent<RectTransform>().sizeDelta = new Vector3(71, 102);

                    else if (number == 7)
                        Number.GetComponent<RectTransform>().sizeDelta = new Vector3(67, 100);

                    else if (number == 8)
                        Number.GetComponent<RectTransform>().sizeDelta = new Vector3(73, 102);

                    else if (number == 9)
                        Number.GetComponent<RectTransform>().sizeDelta = new Vector3(71, 102);

                    step_number = 1;
                }

                //2. 숫자를 바꾼다.
                if (step_number == 1)
                {
                    Number.GetComponent<Image>().sprite = main_number[number + 5];
                    Last_Stage = number;
                    step = 24;
                }
            }

            //시간 수 추가
            if (step == 251)
            {
                //1. 추가 넘버를 쓴다.
                if (step_number == 0)
                {
                    //1플레이어모드가 아닐 때는 2씩 올라간다(홀수)
                    time = (time + 60) / 60;

                    if (time == 1)
                        Number2.GetComponent<RectTransform>().sizeDelta = new Vector3(47, 100);

                    else if (time == 2)
                        Number2.GetComponent<RectTransform>().sizeDelta = new Vector3(69, 101);

                    else if (time == 3)
                        Number2.GetComponent<RectTransform>().sizeDelta = new Vector3(71, 101);

                    else if (time == 4)
                        Number2.GetComponent<RectTransform>().sizeDelta = new Vector3(73, 100);

                    else if (time == 5)
                        Number2.GetComponent<RectTransform>().sizeDelta = new Vector3(70, 101);

                    else if (time == 6)
                        Number2.GetComponent<RectTransform>().sizeDelta = new Vector3(71, 102);

                    else if (time == 7)
                        Number2.GetComponent<RectTransform>().sizeDelta = new Vector3(67, 100);

                    else if (time == 8)
                        Number2.GetComponent<RectTransform>().sizeDelta = new Vector3(73, 102);

                    else if (time == 9)
                        Number2.GetComponent<RectTransform>().sizeDelta = new Vector3(71, 102);

                    step_number = 1;
                }

                //2. 숫자를 바꾼다.
                if (step_number == 1)
                {
                    Number2.GetComponent<Image>().sprite = main_number[(int)time + 5];
                    step = 24;

                    time *= 60;
                }
            }

            //스테이지 수 감소
            if (step == 26)
            {
                //1. 추가 넘버를 쓴다.
                if (step_number == 0)
                {
                    if (!Player1Mode)
                        number -= 2;

                    else
                    {
                        number--;
                    }

                    if (number == 1)
                        Number.GetComponent<RectTransform>().sizeDelta = new Vector3(47, 100);

                    else if (number == 2)
                        Number.GetComponent<RectTransform>().sizeDelta = new Vector3(69, 101);

                    else if (number == 3)
                        Number.GetComponent<RectTransform>().sizeDelta = new Vector3(71, 101);

                    else if (number == 4)
                        Number.GetComponent<RectTransform>().sizeDelta = new Vector3(73, 100);

                    else if (number == 5)
                        Number.GetComponent<RectTransform>().sizeDelta = new Vector3(70, 101);

                    else if (number == 6)
                        Number.GetComponent<RectTransform>().sizeDelta = new Vector3(71, 102);

                    else if (number == 7)
                        Number.GetComponent<RectTransform>().sizeDelta = new Vector3(67, 100);

                    else if (number == 8)
                        Number.GetComponent<RectTransform>().sizeDelta = new Vector3(73, 102);

                    else if (number == 9)
                        Number.GetComponent<RectTransform>().sizeDelta = new Vector3(71, 102);

                    step_number = 1;
                }

                //2. 숫자를 바꾼다.
                if (step_number == 1)
                {
                    Last_Stage = number;
                    Number.GetComponent<Image>().sprite = main_number[number + 5];
                    step = 24;
                }
            }

            //시간 수 추가
            if (step == 261)
            {
                //1. 추가 넘버를 쓴다.
                if (step_number == 0)
                {
                    time = (time - 60) / 60;

                    if (time == 1)
                        Number2.GetComponent<RectTransform>().sizeDelta = new Vector3(47, 100);

                    else if (time == 2)
                        Number2.GetComponent<RectTransform>().sizeDelta = new Vector3(69, 101);

                    else if (time == 3)
                        Number2.GetComponent<RectTransform>().sizeDelta = new Vector3(71, 101);

                    else if (time == 4)
                        Number2.GetComponent<RectTransform>().sizeDelta = new Vector3(73, 100);

                    else if (time == 5)
                        Number2.GetComponent<RectTransform>().sizeDelta = new Vector3(70, 101);

                    else if (time == 6)
                        Number2.GetComponent<RectTransform>().sizeDelta = new Vector3(71, 102);

                    else if (time == 7)
                        Number2.GetComponent<RectTransform>().sizeDelta = new Vector3(67, 100);

                    else if (time == 8)
                        Number2.GetComponent<RectTransform>().sizeDelta = new Vector3(73, 102);

                    else if (time == 9)
                        Number2.GetComponent<RectTransform>().sizeDelta = new Vector3(71, 102);

                    step_number = 1;
                }

                //2. 숫자를 바꾼다.
                if (step_number == 1)
                {
                    Number2.GetComponent<Image>().sprite = main_number[(int)time + 5];
                    step = 24;

                    time *= 60;
                }
            }

            //스테이지 다음 선택
            if (step == 27)
            {
                //1. 추가 넘버를 쓴다.
                if (step_stage == 0)
                {
                    if (stage > 6) //3을 넘어가면 다시 1부터 간다.
                        stage = 1;

                    step_stage = 1;
                }

                if (step_stage == 1)
                {
                    if (step_stage == 1)
                    {
                        if (stage == 1) // 일반모드
                        {
                            for (int i = 16; i < 20; i++)
                                Card[i].GetComponent<Image>().sprite = main_but[28 + i];
                            Card[20].GetComponent<Image>().sprite = main_but[49];
                        }

                        else if (stage == 2) // 가림막모드
                        {
                            for (int i = 16; i < 20; i++)
                                Card[i].GetComponent<Image>().sprite = main_but[28 + i];

                            Card[16].GetComponent<Image>().sprite = main_but[50];
                            Card[20].GetComponent<Image>().sprite = main_but[49];
                        }

                        else if (stage == 3) // 전등모드
                        {
                            for (int i = 16; i < 20; i++)
                                Card[i].GetComponent<Image>().sprite = main_but[28 + i];

                            Card[17].GetComponent<Image>().sprite = main_but[51];
                            Card[20].GetComponent<Image>().sprite = main_but[49];
                        }

                        else if (stage == 4) // 4x4모드
                        {
                            for (int i = 16; i < 20; i++)
                                Card[i].GetComponent<Image>().sprite = main_but[28 + i];

                            Card[18].GetComponent<Image>().sprite = main_but[52];
                            Card[20].GetComponent<Image>().sprite = main_but[49];
                        }

                        else if (stage == 5) // 합성모드
                        {
                            for (int i = 16; i < 20; i++)
                                Card[i].GetComponent<Image>().sprite = main_but[28 + i];

                            Card[19].GetComponent<Image>().sprite = main_but[53];
                            Card[20].GetComponent<Image>().sprite = main_but[49];
                        }

                        else if (stage == 6) // 랜덤 모드
                        {
                            for (int i = 16; i < 20; i++)
                                Card[i].GetComponent<Image>().sprite = main_but[28 + i];

                            Card[20].GetComponent<Image>().sprite = main_but[55];
                        }
                    }

                    step_stage = 2;
                }

                //2.4x4모드일 경우
                if (step_stage == 2)
                {
                    if (stage != 4)
                    {
                        if (card_number > 3)
                        {
                            card_number--;
                            Card[Selected_card[3]].GetComponent<Image>().sprite = main_but[14 + Selected_card[3]];
                        }
                    }

                    step_stage = 3;
                }

                if (step_stage == 3)
                {
                    if (stage == 1)
                    {
                        for (int i = 0; i < 5; i++)
                            Selected_stage[i] = 0;
                    }

                    else
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            if (stage == i + 2)
                                Selected_stage[i] = 1;

                            else
                                Selected_stage[i] = 0;
                        }
                    }

                    step_stage = 4;
                }

                //3. 숫자를 바꾼다.
                if (step_stage == 4)
                {
                    if (stage != 1)
                        stage_number = 1;

                    else
                        stage_number = 0;

                    CardModeName();

                    step = 24;
                }
            }

            //스테이지 이전 선택
            if (step == 28)
            {
                //1. 추가 넘버를 쓴다.
                if (step_stage == 0)
                {
                    if (stage < 1) //3을 넘어가면 다시 1부터 간다.
                        stage = 6;

                    step_stage = 1;
                }

                if (step_stage == 1)
                {
                    if (stage == 1) // 일반모드
                    {
                        for (int i = 16; i < 20; i++)
                            Card[i].GetComponent<Image>().sprite = main_but[28 + i];
                        Card[20].GetComponent<Image>().sprite = main_but[49];
                    }

                    else if (stage == 2) // 가림막모드
                    {
                        for (int i = 16; i < 20; i++)
                            Card[i].GetComponent<Image>().sprite = main_but[28 + i];

                        Card[16].GetComponent<Image>().sprite = main_but[50];
                        Card[20].GetComponent<Image>().sprite = main_but[49];
                    }

                    else if (stage == 3) // 전등모드
                    {
                        for (int i = 16; i < 20; i++)
                            Card[i].GetComponent<Image>().sprite = main_but[28 + i];

                        Card[17].GetComponent<Image>().sprite = main_but[51];
                        Card[20].GetComponent<Image>().sprite = main_but[49];
                    }

                    else if (stage == 4) // 4x4모드
                    {
                        for (int i = 16; i < 20; i++)
                            Card[i].GetComponent<Image>().sprite = main_but[28 + i];

                        Card[18].GetComponent<Image>().sprite = main_but[52];
                        Card[20].GetComponent<Image>().sprite = main_but[49];
                    }

                    else if (stage == 5) // 합성모드
                    {
                        for (int i = 16; i < 20; i++)
                            Card[i].GetComponent<Image>().sprite = main_but[28 + i];

                        Card[19].GetComponent<Image>().sprite = main_but[53];
                        Card[20].GetComponent<Image>().sprite = main_but[49];
                    }

                    else if (stage == 6) // 랜덤 모드
                    {
                        for (int i = 16; i < 20; i++)
                            Card[i].GetComponent<Image>().sprite = main_but[28 + i];

                        Card[20].GetComponent<Image>().sprite = main_but[55];
                    }

                    step_stage = 2;
                }

                //2.4x4모드일 경우
                if (step_stage == 2)
                {
                    if (stage != 4)
                    {
                        if (card_number > 3)
                        {
                            card_number--;
                            Card[Selected_card[3]].GetComponent<Image>().sprite = main_but[14 + Selected_card[3]];
                        }
                    }

                    step_stage = 3;
                }

                if (step_stage == 3)
                {
                    if (stage == 1)
                    {
                        for (int i = 0; i < 5; i++)
                            Selected_stage[i] = 0;
                    }

                    else
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            if (stage == i + 2)
                                Selected_stage[i] = 1;

                            else
                                Selected_stage[i] = 0;
                        }
                    }

                    step_stage = 4;
                }

                //3. 숫자를 바꾼다.
                if (step_stage == 4)
                {
                    CardModeName();
                    step = 24;
                }
            }

            //돌아가기 선택
            if (step == 211)
            {
                if (Plus.GetComponent<Image>().color.a < 0)
                    step = 212;

                else
                {
                    Plus.GetComponent<Image>().color = new Color(Plus.GetComponent<Image>().color.r, Plus.GetComponent<Image>().color.g, Plus.GetComponent<Image>().color.b, Plus.GetComponent<Image>().color.a - 0.01f);
                    Minus.GetComponent<Image>().color = new Color(Minus.GetComponent<Image>().color.r, Minus.GetComponent<Image>().color.g, Minus.GetComponent<Image>().color.b, Minus.GetComponent<Image>().color.a - 0.01f);
                    Plus2.GetComponent<Image>().color = new Color(Plus.GetComponent<Image>().color.r, Plus.GetComponent<Image>().color.g, Plus2.GetComponent<Image>().color.b, Plus2.GetComponent<Image>().color.a - 0.01f);
                    Minus2.GetComponent<Image>().color = new Color(Minus.GetComponent<Image>().color.r, Minus.GetComponent<Image>().color.g, Minus2.GetComponent<Image>().color.b, Minus2.GetComponent<Image>().color.a - 0.01f);
                    Next.GetComponent<Image>().color = new Color(Next.GetComponent<Image>().color.r, Next.GetComponent<Image>().color.g, Next.GetComponent<Image>().color.b, Next.GetComponent<Image>().color.a - 0.01f);
                    BackNext.GetComponent<Image>().color = new Color(BackNext.GetComponent<Image>().color.r, BackNext.GetComponent<Image>().color.g, BackNext.GetComponent<Image>().color.b, BackNext.GetComponent<Image>().color.a - 0.01f);
                    Number.GetComponent<Image>().color = new Color(Number.GetComponent<Image>().color.r, Number.GetComponent<Image>().color.g, Number.GetComponent<Image>().color.b, Number.GetComponent<Image>().color.a - 0.01f);
                    Number2.GetComponent<Image>().color = new Color(Number2.GetComponent<Image>().color.r, Number2.GetComponent<Image>().color.g, Number2.GetComponent<Image>().color.b, Number2.GetComponent<Image>().color.a - 0.01f);
                    Stage.GetComponent<Image>().color = new Color(Stage.GetComponent<Image>().color.r, Stage.GetComponent<Image>().color.g, Stage.GetComponent<Image>().color.b, Stage.GetComponent<Image>().color.a - 0.01f);

                    for (int i = 0; i < 22; i++)
                        Card[i].GetComponent<Image>().color = new Color(Card[i].GetComponent<Image>().color.r, Card[i].GetComponent<Image>().color.g, Card[i].GetComponent<Image>().color.b, Card[i].GetComponent<Image>().color.a - 0.01f);
                }
            }

            //돌아갈 때 버튼 사라지기
            if (step == 212)
            {
                if (Select1.GetComponent<RectTransform>().localPosition.x == 400)
                {
                    Select1.GetComponent<RectTransform>().localPosition = new Vector3(400, 70);
                    Select2.GetComponent<RectTransform>().localPosition = new Vector3(400, -10);
                    Select3.GetComponent<RectTransform>().localPosition = new Vector3(400, -100);
                    Select4.GetComponent<RectTransform>().localPosition = new Vector3(310, -230);
                    Select5.GetComponent<RectTransform>().localPosition = new Vector3(510, -230);
                    Select6.GetComponent<RectTransform>().localPosition = new Vector3(400, -150);
                    Plus.GetComponent<RectTransform>().localPosition = new Vector3(400, 70);
                    Minus.GetComponent<RectTransform>().localPosition = new Vector3(400, 70);
                    Plus2.GetComponent<RectTransform>().localPosition = new Vector3(400, 70);
                    Minus2.GetComponent<RectTransform>().localPosition = new Vector3(400, 70);
                    Number.GetComponent<RectTransform>().localPosition = new Vector3(400, 70);
                    Number2.GetComponent<RectTransform>().localPosition = new Vector3(400, 70);

                    Next.GetComponent<RectTransform>().localPosition = new Vector3(400, -10);
                    BackNext.GetComponent<RectTransform>().localPosition = new Vector3(400, -10);
                    Stage.GetComponent<RectTransform>().localPosition = new Vector3(400, -10);

                    for (int i = 0; i < 22; i++)
                        Card[i].GetComponent<RectTransform>().localPosition = new Vector3(400, -145);

                    if (Player1Mode)
                    {
                        step = 2131;
                    }

                    else
                        step = 213;
                }

                else
                {
                    Select1.GetComponent<RectTransform>().localPosition = new Vector3(Select1.GetComponent<RectTransform>().localPosition.x + 10, Select1.GetComponent<RectTransform>().localPosition.y, Select1.transform.position.z);
                    Select2.GetComponent<RectTransform>().localPosition = new Vector3(Select2.GetComponent<RectTransform>().localPosition.x + 10, Select2.GetComponent<RectTransform>().localPosition.y, Select2.transform.position.z);
                    Select3.GetComponent<RectTransform>().localPosition = new Vector3(Select3.GetComponent<RectTransform>().localPosition.x + 10, Select3.GetComponent<RectTransform>().localPosition.y, Select3.transform.position.z);
                    Select4.GetComponent<RectTransform>().localPosition = new Vector3(Select4.GetComponent<RectTransform>().localPosition.x + 30, Select4.GetComponent<RectTransform>().localPosition.y, Select4.transform.position.z);
                    Select5.GetComponent<RectTransform>().localPosition = new Vector3(Select5.GetComponent<RectTransform>().localPosition.x + 30, Select5.GetComponent<RectTransform>().localPosition.y, Select5.transform.position.z);

                    if (Player1Mode)
                    {
                        P1_Button.GetComponent<RectTransform>().localPosition = new Vector3(P1_Button.GetComponent<RectTransform>().localPosition.x + 10, P1_Button.GetComponent<RectTransform>().localPosition.y, P1_Button.transform.position.z);
                        Select6.GetComponent<RectTransform>().localPosition = new Vector3(Select3.GetComponent<RectTransform>().localPosition.x + 10, Select3.GetComponent<RectTransform>().localPosition.y, Select3.transform.position.z);
                    }
                }
            }

            //메인메뉴 돌아가기
            if (step == 213)
            {
                if (speed == 10)
                {
                    P2_Button.GetComponent<Image>().color = new Color(P2_Button.GetComponent<Image>().color.r, P2_Button.GetComponent<Image>().color.g, P2_Button.GetComponent<Image>().color.b, 1);
                    speed = 0.5f;
                    step = 1;
                }

                else
                {
                    Title.GetComponent<RectTransform>().localPosition = new Vector3(Title.GetComponent<RectTransform>().localPosition.x + (40 - 5 * speed), Title.GetComponent<RectTransform>().localPosition.y, Title.transform.position.z);
                    P1_Button.GetComponent<RectTransform>().localPosition = new Vector3(P1_Button.GetComponent<RectTransform>().localPosition.x + (40 - 5 * speed), P1_Button.GetComponent<RectTransform>().localPosition.y, P1_Button.transform.position.z);
                    P2_Button.GetComponent<RectTransform>().localPosition = new Vector3(P2_Button.GetComponent<RectTransform>().localPosition.x, P2_Button.GetComponent<RectTransform>().localPosition.y - 2.2f * speed, P2_Button.transform.position.z);
                    P2_Button.GetComponent<RectTransform>().localScale = new Vector3(P2_Button.GetComponent<RectTransform>().localScale.x - speed / 700, P2_Button.GetComponent<RectTransform>().localScale.y - speed / 700);
                    Exit.GetComponent<RectTransform>().localPosition = new Vector3(Exit.GetComponent<RectTransform>().localPosition.x + (40 - 5 * speed), Exit.GetComponent<RectTransform>().localPosition.y, Exit.transform.position.z);
                    VersionText.GetComponent<RectTransform>().localPosition = new Vector3(VersionText.GetComponent<RectTransform>().localPosition.x + (40 - 5 * speed), VersionText.GetComponent<RectTransform>().localPosition.y, VersionText.transform.position.z);


                    if (P2_Button.GetComponent<Image>().color.a <= 0)
                    {
                        P2_Button.GetComponent<RectTransform>().sizeDelta = new Vector3(578, 169);
                        P2_Button.GetComponent<Image>().sprite = main_but[2];
                        P2_Button.GetComponent<Image>().color = new Color(P2_Button.GetComponent<Image>().color.r, P2_Button.GetComponent<Image>().color.g, P2_Button.GetComponent<Image>().color.b, P2_Button.GetComponent<Image>().color.a + 0.5f);
                    }

                    else
                        P2_Button.GetComponent<Image>().color = new Color(P2_Button.GetComponent<Image>().color.r, P2_Button.GetComponent<Image>().color.g, P2_Button.GetComponent<Image>().color.b, P2_Button.GetComponent<Image>().color.a - 0.5f);

                    speed += 0.5f;
                }
            }

            //1P일 때 이전 메뉴로 돌아가기
            if (step == 2131)
            {
                Player1Mode = false;
                P1_Button.GetComponent<RectTransform>().localScale = new Vector3(0.595f, 0.595f);
                P2_Button.GetComponent<RectTransform>().localScale = new Vector3(0.5f, 0.5f);
                P3_Button.GetComponent<RectTransform>().localScale = new Vector3(0.5f, 0.5f);
                P4_Button.GetComponent<RectTransform>().localScale = new Vector3(0.5f, 0.5f);
                Exit.GetComponent<RectTransform>().localScale = new Vector3(0.4f, 0.4f);
                P1_Button.GetComponent<Image>().color = new Color(P1_Button.GetComponent<Image>().color.r, P1_Button.GetComponent<Image>().color.g, P1_Button.GetComponent<Image>().color.b, 1);
                P1_Button.GetComponent<RectTransform>().localPosition = new Vector3(400, 212.5f, P2_Button.transform.position.z);
                P2_Button.GetComponent<RectTransform>().localPosition = new Vector3(400, -10, P2_Button.transform.position.z);
                P3_Button.GetComponent<RectTransform>().localPosition = new Vector3(400, 95, P3_Button.transform.position.z);
                P4_Button.GetComponent<RectTransform>().localPosition = new Vector3(400, -125, P4_Button.transform.position.z);
                Exit.GetComponent<RectTransform>().localPosition = new Vector3(400, -230, Exit.transform.position.z);
                P3_Button.GetComponent<RectTransform>().sizeDelta = new Vector3(510, 150);
                P2_Button.GetComponent<RectTransform>().sizeDelta = new Vector3(510, 164);
                Exit.GetComponent<RectTransform>().sizeDelta = new Vector3(338, 112);
                step = 2132;
            }

            if (step == 2132) //버튼 자리이동 2
            {
                if (P2_Button.GetComponent<RectTransform>().localPosition.x == 0)
                {
                    step = 12; //버튼이 선택되길 기다린다.
                }

                else
                {
                    P1_Button.GetComponent<RectTransform>().localPosition = new Vector3(P1_Button.GetComponent<RectTransform>().localPosition.x - 5f, P1_Button.GetComponent<RectTransform>().localPosition.y, P1_Button.transform.position.z);
                    P2_Button.GetComponent<RectTransform>().localPosition = new Vector3(P2_Button.GetComponent<RectTransform>().localPosition.x - 5f, P2_Button.GetComponent<RectTransform>().localPosition.y, P2_Button.transform.position.z);
                    P3_Button.GetComponent<RectTransform>().localPosition = new Vector3(P3_Button.GetComponent<RectTransform>().localPosition.x - 5f, P3_Button.GetComponent<RectTransform>().localPosition.y, P3_Button.transform.position.z);
                    P4_Button.GetComponent<RectTransform>().localPosition = new Vector3(P4_Button.GetComponent<RectTransform>().localPosition.x - 5f, P4_Button.GetComponent<RectTransform>().localPosition.y, P4_Button.transform.position.z);
                    Exit.GetComponent<RectTransform>().localPosition = new Vector3(Exit.GetComponent<RectTransform>().localPosition.x - 5f, Exit.GetComponent<RectTransform>().localPosition.y, Exit.transform.position.z);
                }
            }

            //게임 시작하기(디버깅)
            if (step == 214)
            {
                //선택되지 않은 나머지에서 중복이 되지 않게 선택한다.
                for (int i = card_number; i < 4; i++)
                {
                    while (true) // 중복되는 지 확인이 될 때까지 하므로 while을 써서 반복한다.
                    {
                        Selected_card[i] = Random.Range(0, 8); // 0에서 7 중에서 1개를 골라 해당 배열에 넣는다.
                        isSame = false; // 기본은 false값으로 주어진다.

                        for (int j = 0; j < i; j++) // 중복을 확인합니다.
                        {
                            if (Selected_card[j] == Selected_card[i])
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
                for (int i = card_color; i < 3; i++)
                {
                    while (true) // 중복되는 지 확인이 될 때까지 하므로 while을 써서 반복한다.
                    {
                        Selected_card_color[i] = Random.Range(0, 7); // 0에서 6 중에서 1개를 골라 해당 배열에 넣는다.
                        isSame = false; // 기본은 false값으로 주어진다.

                        for (int j = 0; j < i; j++) // 중복을 확인합니다.
                        {
                            if (Selected_card_color[j] == Selected_card_color[i])
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

                step = 215;
            }

            if (step == 215)
            {
                step = 216;
                Fade.GetComponent<RectTransform>().localPosition = new Vector3(0, 0);
                Fade.GetComponent<Image>().color = new Color(0, 0, 0, 0);
            }

            if (step == 216)
            {
                Fade.GetComponent<Image>().color = new Color(0, 0, 0, Fade.GetComponent<Image>().color.a + 0.001f);
                Setting.GetComponent<Image>().color = new Color(0, 0, 0, Setting.GetComponent<Image>().color.a - 0.001f);
                MusicSource.volume -= 0.001f;

                if (Fade.GetComponent<Image>().color.a > 1)
                {
                    step = 217;
                }
            }

            if (step == 217)
            {
                Fade.GetComponent<RectTransform>().localPosition = new Vector3(0, 0);

                //출발!
                number = 1;
                stage = 1;
                step_number = 0;
                step_stage = 0;

                card_number = 0;
                selected_card_number = 0;

                card_color = 0;
                selected_card_color = 0;

                stage_number = 0;
                selected_stage_number = 0;
                step = 0;
                speed = 0.5f;

                Title.GetComponent<Image>().color = new Color(Title.GetComponent<Image>().color.r, Title.GetComponent<Image>().color.g, Title.GetComponent<Image>().color.b, 0);
                P1_Button.GetComponent<RectTransform>().localPosition = new Vector3(285, P1_Button.GetComponent<RectTransform>().localPosition.y, P1_Button.transform.position.z);
                P2_Button.GetComponent<RectTransform>().localPosition = new Vector3(285, P2_Button.GetComponent<RectTransform>().localPosition.y, P2_Button.transform.position.z);
                Exit.GetComponent<RectTransform>().localPosition = new Vector3(285, Exit.GetComponent<RectTransform>().localPosition.y, Exit.transform.position.z);

                Firsttime = time;

                SceneManager.LoadScene("Game Scene");
            }
        }
    }

    void CardModeName()
    {
        if(Language == 1)
        {
            Next.GetComponent<RectTransform>().localPosition = new Vector3(130, Next.GetComponent<RectTransform>().localPosition.y);
            BackNext.GetComponent<RectTransform>().localPosition = new Vector3(20, Next.GetComponent<RectTransform>().localPosition.y);
            Stage.GetComponent<RectTransform>().localPosition = new Vector3(75, Next.GetComponent<RectTransform>().localPosition.y);

            if (stage == 1) // 일반모드
            {
                Stage.GetComponent<RectTransform>().sizeDelta = new Vector3(135, 70);
                Stage.GetComponent<RectTransform>().localScale = new Vector3(0.4f, 0.4f);
                Stage.GetComponent<Image>().sprite = main_but[61];
            }

            else if (stage == 2) // 가림막모드
            {
                Stage.GetComponent<RectTransform>().sizeDelta = new Vector3(202, 72);
                Stage.GetComponent<RectTransform>().localScale = new Vector3(0.35f, 0.35f);
                Stage.GetComponent<Image>().sprite = main_but[62];
            }

            else if (stage == 3) // 전등모드
            {
                Stage.GetComponent<RectTransform>().sizeDelta = new Vector3(137, 70);
                Stage.GetComponent<RectTransform>().localScale = new Vector3(0.4f, 0.4f);
                Stage.GetComponent<Image>().sprite = main_but[63];
            }

            else if (stage == 4) // 4x4모드
            {
                Stage.GetComponent<RectTransform>().sizeDelta = new Vector3(135, 59);
                Stage.GetComponent<RectTransform>().localScale = new Vector3(0.4f, 0.4f);
                Stage.GetComponent<Image>().sprite = main_but[64];
            }

            else if (stage == 5) // 합성모드
            {
                Stage.GetComponent<RectTransform>().sizeDelta = new Vector3(129, 70);
                Stage.GetComponent<RectTransform>().localScale = new Vector3(0.4f, 0.4f);
                Stage.GetComponent<Image>().sprite = main_but[65];
            }

            else if (stage == 6) // 랜덤 모드
            {
                Stage.GetComponent<RectTransform>().sizeDelta = new Vector3(129, 69);
                Stage.GetComponent<RectTransform>().localScale = new Vector3(0.4f, 0.4f);
                Stage.GetComponent<Image>().sprite = main_but[66];
            }
        }

        else if (Language == 2)
        {
            Next.GetComponent<RectTransform>().localPosition = new Vector3(130, Next.GetComponent<RectTransform>().localPosition.y);
            BackNext.GetComponent<RectTransform>().localPosition = new Vector3(-20, Next.GetComponent<RectTransform>().localPosition.y);
            Stage.GetComponent<RectTransform>().localPosition = new Vector3(55, Next.GetComponent<RectTransform>().localPosition.y);

            if (stage == 1) // 일반모드
            {
                Stage.GetComponent<RectTransform>().sizeDelta = new Vector3(255, 67);
                Stage.GetComponent<RectTransform>().localScale = new Vector3(0.4f, 0.4f);
                Stage.GetComponent<Image>().sprite = main_but[98];
            }

            else if (stage == 2) // 가림막모드
            {
                Stage.GetComponent<RectTransform>().sizeDelta = new Vector3(166, 64);
                Stage.GetComponent<RectTransform>().localScale = new Vector3(0.4f, 0.4f);
                Stage.GetComponent<Image>().sprite = main_but[99];
            }

            else if (stage == 3) // 전등모드
            {
                Stage.GetComponent<RectTransform>().sizeDelta = new Vector3(187, 67);
                Stage.GetComponent<RectTransform>().localScale = new Vector3(0.4f, 0.4f);
                Stage.GetComponent<Image>().sprite = main_but[100];
            }

            else if (stage == 4) // 4x4모드
            {
                Stage.GetComponent<RectTransform>().sizeDelta = new Vector3(135, 59);
                Stage.GetComponent<RectTransform>().localScale = new Vector3(0.4f, 0.4f);
                Stage.GetComponent<Image>().sprite = main_but[64];
            }

            else if (stage == 5) // 합성모드
            {
                Stage.GetComponent<RectTransform>().sizeDelta = new Vector3(133, 64);
                Stage.GetComponent<RectTransform>().localScale = new Vector3(0.4f, 0.4f);
                Stage.GetComponent<Image>().sprite = main_but[101];
            }

            else if (stage == 6) // 랜덤 모드
            {
                Stage.GetComponent<RectTransform>().sizeDelta = new Vector3(290, 63);
                Stage.GetComponent<RectTransform>().localScale = new Vector3(0.35f, 0.35f);
                Stage.GetComponent<Image>().sprite = main_but[102];
            }
        }

        else if (Language == 3)
        {
            Next.GetComponent<RectTransform>().localPosition = new Vector3(130, Next.GetComponent<RectTransform>().localPosition.y);
            BackNext.GetComponent<RectTransform>().localPosition = new Vector3(-20, Next.GetComponent<RectTransform>().localPosition.y);
            Stage.GetComponent<RectTransform>().localPosition = new Vector3(55, Next.GetComponent<RectTransform>().localPosition.y);

            if (stage == 1) // 일반모드
            {
                Stage.GetComponent<RectTransform>().sizeDelta = new Vector3(142, 72);
                Stage.GetComponent<RectTransform>().localScale = new Vector3(0.4f, 0.4f);
                Stage.GetComponent<Image>().sprite = main_but[117];
            }

            else if (stage == 2) // 가림막모드
            {
                Stage.GetComponent<RectTransform>().sizeDelta = new Vector3(132, 72);
                Stage.GetComponent<RectTransform>().localScale = new Vector3(0.35f, 0.35f);
                Stage.GetComponent<Image>().sprite = main_but[118];
            }

            else if (stage == 3) // 전등모드
            {
                Stage.GetComponent<RectTransform>().sizeDelta = new Vector3(184, 63);
                Stage.GetComponent<RectTransform>().localScale = new Vector3(0.4f, 0.4f);
                Stage.GetComponent<Image>().sprite = main_but[119];
            }

            else if (stage == 4) // 4x4모드
            {
                Stage.GetComponent<RectTransform>().sizeDelta = new Vector3(135, 59);
                Stage.GetComponent<RectTransform>().localScale = new Vector3(0.4f, 0.4f);
                Stage.GetComponent<Image>().sprite = main_but[64];
            }

            else if (stage == 5) // 합성모드
            {
                Stage.GetComponent<RectTransform>().sizeDelta = new Vector3(136, 69);
                Stage.GetComponent<RectTransform>().localScale = new Vector3(0.4f, 0.4f);
                Stage.GetComponent<Image>().sprite = main_but[120];
            }

            else if (stage == 6) // 랜덤 모드
            {
                Stage.GetComponent<RectTransform>().sizeDelta = new Vector3(255, 69);
                Stage.GetComponent<RectTransform>().localScale = new Vector3(0.4f, 0.4f);
                Stage.GetComponent<Image>().sprite = main_but[121];
            }
        }
    }
}
