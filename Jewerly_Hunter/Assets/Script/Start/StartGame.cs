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

    // Start is called before the first frame update
    void Start()
    {
        Image = Panel.GetComponent<Image>();
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
        SceneManager.LoadScene("Start");
        Time.timeScale = 1;
    }
    public void OffXPause()
    {
        GameObject.Find("Canvas").transform.GetChild(3).gameObject.SetActive(false);
        Time.timeScale = 1;
    }
}
