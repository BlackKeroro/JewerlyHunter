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
    bool isGameOver = false;

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
        //���������� ü�� ����
        hp -= Time.deltaTime * 3f;
        
        //ü���� 0 ���ϰ� �ǰų� �÷��̾� ��ġ�� Y ���� -8.0 ������ ���
        if (hp <= 0 || Player.transform.position.y < -8.0f)
        {
            if(isGameOver == false)
            {
                hp = 0f; // ü�� 0���� �����
                GameOver.SetActive(true); //GameOver UI Ȱ��ȭ
                run.anim.SetTrigger("DieTrigger"); //Die �ִϸ��̼� ����
                isGameOver = true;
            }
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
