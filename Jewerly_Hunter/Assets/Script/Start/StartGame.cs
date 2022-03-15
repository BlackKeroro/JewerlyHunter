using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public GameObject Panel;
    Image Image;


    public GameObject GameOver;
    public GameObject Pause;

    GameManager GM;

    // Start is called before the first frame update
    void Start()
    {
        Image = Panel.GetComponent<Image>();
        GM = GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnReStart()
    {

        StartCoroutine("Restart");

    }

    public IEnumerator Restart()
    {
        if (GameOver.activeSelf == true)
        {
            GameOver.SetActive(false);
        }
        else if (Pause.activeSelf == true)
        {
            Pause.SetActive(false);
        }

        Time.timeScale = 1;
        Panel.SetActive(true);
        float fadecount = 0.0f;
        while (fadecount < 1.0f)
        {
            fadecount += 0.01f;
            yield return new WaitForSeconds(0.01f);
            Image.color = new Color(0, 0, 0, fadecount);
        }
        SceneManager.LoadScene("Game");

    }

    public void OpningStart()
    {
        Panel.SetActive(true);
        StartCoroutine("OpenStart");
    }
    IEnumerator OpenStart()
    {
        float fadecount = 0.0f;
        while (fadecount < 1.0f)
        {
            fadecount += 0.01f;
            yield return new WaitForSeconds(0.01f);
            Image.color = new Color(0, 0, 0, fadecount);
        }
        SceneManager.LoadScene("Game");
    }

    public void OnHome()
    {
        Panel.SetActive(true);
        StartCoroutine("HomeStart");
    }

    IEnumerator HomeStart()
    {
        Time.timeScale = 1;
        float fadecount = 0.0f;
        while (fadecount < 1.0f)
        {
            fadecount += 0.01f;
            yield return new WaitForSeconds(0.01f);
            Image.color = new Color(0, 0, 0, fadecount);
        }
        SceneManager.LoadScene("Start");
    }
    public void OffXPause()
    {
        GM.isPause = false;
        GameObject.Find("Canvas").transform.GetChild(4).gameObject.SetActive(false);
        Time.timeScale = 1;
    }
}
