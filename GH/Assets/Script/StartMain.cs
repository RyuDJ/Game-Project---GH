using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartMain : MonoBehaviour {

    public GameObject Logo, Text, Fade;
    public AudioClip LogoSound;
    AudioSource LG;
    public int step = 0;
    public static float time = 1;

    void Awake()
    {
        Screen.SetResolution(Screen.width, Screen.width * 16 / 9, false);
    }

    // Use this for initialization
    void Start () {

        string Language = Application.systemLanguage.ToString();

        LG = gameObject.AddComponent<AudioSource>();

        Logo = GameObject.Find("Image");
        Text = GameObject.Find("Text");
        Fade = GameObject.Find("Fade");

        Logo.GetComponent<Image>().color = new Color(Logo.GetComponent<Image>().color.r, Logo.GetComponent<Image>().color.g, Logo.GetComponent<Image>().color.b, 0);
        Fade.GetComponent<Image>().color = new Color(0, 0, 0, 0);
        Text.GetComponent<RectTransform>().localPosition = new Vector3(500, Text.GetComponent<RectTransform>().localPosition.y);

        if (Language.Equals("Korean"))
            Main_Scene.Language = 1;

        else if (Language.Equals("Japanese"))
            Main_Scene.Language = 3;

        else
            Main_Scene.Language = 2;
    }
	
	// Update is called once per frame
	void Update () {

		if(step == 0)
        {
            Logo.GetComponent<Image>().color = new Color(Logo.GetComponent<Image>().color.r, Logo.GetComponent<Image>().color.g, Logo.GetComponent<Image>().color.b, Logo.GetComponent<Image>().color.a + 0.05f);

            if (Text.GetComponent<RectTransform>().localPosition.x == 0)
            {
                Text.GetComponent<RectTransform>().localPosition = new Vector3(0, Text.GetComponent<RectTransform>().localPosition.y);
                step = 1;
            }

            else
                Text.GetComponent<RectTransform>().localPosition = new Vector3(Text.GetComponent<RectTransform>().localPosition.x - 50, Text.GetComponent<RectTransform>().localPosition.y);
        }

        if(step == 1)
        {
            LG.clip = LogoSound;
            LG.Play();
            step = 2;
        }

        if(step == 2)
        {
            Logo.GetComponent<Image>().color = new Color(Logo.GetComponent<Image>().color.r, Logo.GetComponent<Image>().color.g, Logo.GetComponent<Image>().color.b, Logo.GetComponent<Image>().color.a + 0.05f);

            if (Logo.GetComponent<Image>().color.a > 1)
                step = 3;
        }

        if(step == 3)
        {
            time -= Time.deltaTime;

            if(time < 0)
            {
                time = 1;
                step = 4;
            }
        }

        if (step == 4)
        {
            Fade.GetComponent<RectTransform>().localPosition = new Vector3(0, 0, 0);
            Logo.GetComponent<Image>().color = new Color(Logo.GetComponent<Image>().color.r, Logo.GetComponent<Image>().color.g, Logo.GetComponent<Image>().color.b, Logo.GetComponent<Image>().color.a - 0.05f);
            Text.GetComponent<RectTransform>().localPosition = new Vector3(Text.GetComponent<RectTransform>().localPosition.x - 50, Text.GetComponent<RectTransform>().localPosition.y);
            Fade.GetComponent<Image>().color = new Color(0, 0, 0, Fade.GetComponent<Image>().color.a + 0.05f);

            if (Logo.GetComponent<Image>().color.a < 0)
                step = 5;
        }

        if(step == 5)
        {
            SceneManager.LoadScene("Main Scene");
            step = 0;
        }
    }
}
