using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public float hp;
    public Image HPbar_Image;

    public GameObject ScoreObj;
    public int score;
    Text Scoretxt;

    GameObject Player;
    Run run;
    public bool isPause;
    public GameObject PauseOn;
    public GameObject GameOver;

    public void Awake()
    {
        hp = 100.0f;
        score = 0;
        isPause = false;

    }

    // Start is called before the first frame update
    void Start()
    {
        Scoretxt = ScoreObj.GetComponent<Text>();
        Player = GameObject.Find("Player");
        run = GameObject.Find("Run").GetComponent<Run>();
     }

    // Update is called once per frame
    void Update()
    {
        PlayerHPbar();
        PlayerHPTime();
        ScoreUI();
        Pause();
        
    }

    void PlayerHPTime()
    {
        hp -= Time.deltaTime * 3f;
        
        if (hp <= 0 || Player.transform.position.y < -8.0f)
        {
            hp = 0f;
            GameOver.SetActive(true);
            run.anim.SetTrigger("DieTrigger");
        }
    }

    public void PlayerHPbar()
    {
       
        HPbar_Image.fillAmount = hp / 100f;
    }
    public void ScoreUI()
    {
        Scoretxt.text = score.ToString();
    }

    public void Pause()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && hp > 0)
        {
            if (isPause == false)
            {
                Time.timeScale = 0;
                PauseOn.SetActive(true);
                isPause = true;


            }
            else if (isPause == true)
            {
                Time.timeScale = 1;
                PauseOn.gameObject.SetActive(false);
                isPause = false;


            }
        }
    }
}
