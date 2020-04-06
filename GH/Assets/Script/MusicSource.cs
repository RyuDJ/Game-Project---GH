using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MusicSource : MonoBehaviour {

    public AudioClip BackGround;    //배경음악
    public AudioClip[] sfx;         //효과음
    public AudioClip[] sfx2;
    public AudioClip tictok;
    public static int step = -1;
    public static float Looptime = -1;
    public static float volume = -1;
    public static float SE_volume = -1, SE2_volume = -1;
    public static GameObject Music;
    AudioSource myBack, SE, SE2, Clock;

    public static bool[] SFX =
    {
        false, false, false, false, false, false, false, false, false
    };

    public static bool[] SFX2 =
    {
        false, false, false
    };

    public static bool SFXCHOOSE = false, SFXCHOOSE2 = false;
    public static bool Clocking = false, ClockingOff = false;

    void Awake()
    {
    }

    // Use this for initialization
    void Start() {
        myBack = gameObject.AddComponent<AudioSource>();
        SE = gameObject.AddComponent<AudioSource>();
        SE2 = gameObject.AddComponent<AudioSource>();
        Clock = gameObject.AddComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Main_Scene.isMusicOn)
        {
            if (step == 0)
            {
                myBack.clip = BackGround;
                myBack.Play();
                step = 1;
            }

            if (step == 1)
            {
                if (myBack.isPlaying)
                {
                    if (myBack.time > Looptime)
                        myBack.time = 0;

                    myBack.loop = true;
                    myBack.volume = volume;
                }
            }

            if (SFXCHOOSE)
            {
                for(int i = 0; i < 9; i++)
                {
                    if(SFX[i])
                    {
                        SE.clip = sfx[i];
                        SE.Play();
                        SE.loop = false;
                        SE.volume = SE_volume;
                    }

                    SFX[i] = false;
                }

                SFXCHOOSE = false;
            }

            if (SFXCHOOSE2)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (SFX2[j])
                    {
                        SE2.clip = sfx2[j];
                        SE2.Play();
                        SE2.loop = false;
                        SE2.volume = SE2_volume;
                    }

                    SFX2[j] = false;
                }

                SFXCHOOSE = false;
            }

            if (Clocking)
            {
                Clock.clip = tictok;
                Clock.Play();
                Clock.volume = 1.5f;
                Clock.loop = true;
                Clocking = false;
            }

            if(ClockingOff)
            {
                Clock.Pause();
                Clock.time = 0;
                ClockingOff = false;
            }

            if((Card.FadeOut) && (Main_Scene.Last_Stage > 0))
            {
                if (myBack.isPlaying)
                {
                    if((!Main_Scene.Player1Mode) && (Main_Scene.Player_1_WinCount > ((Main_Scene.Player_1_WinCount + Main_Scene.Player_2_WinCount + Main_Scene.Last_Stage) / 2) || Main_Scene.Player_2_WinCount > ((Main_Scene.Player_1_WinCount + Main_Scene.Player_2_WinCount + Main_Scene.Last_Stage) / 2)) && (Card.step >= 1))
                    {
                        Destroy(Button_Script.GameMusic);
                    }

                    else
                        DontDestroyOnLoad(Button_Script.GameMusic);
                }
            }

            if ((Card.FadeOut) && (Main_Scene.Last_Stage == 0) && (Card.step >= 1))
            {
                if (myBack.isPlaying)
                {
                    Destroy(Button_Script.GameMusic);
                }
            }
        }

        else
        {
            myBack.Pause();
            myBack.time = 0;
            step = 0;
        }
    }

    public void MusicOn()
    {
        Music = GameObject.Find("Music");

        if (Main_Scene.isMusicOn)
        {
            Music.GetComponent<Image>().sprite = Main_Scene.main_but[73];
            Main_Scene.isMusicOn = false;
        }

        else
        {
            Music.GetComponent<Image>().sprite = Main_Scene.main_but[76];
            Main_Scene.isMusicOn = true;
        }

    }
}
