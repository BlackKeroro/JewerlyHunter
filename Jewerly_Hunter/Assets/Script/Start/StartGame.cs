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

    // Start is called before the first frame update
    void Start()
    {
        Image = Panel.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnStart()
    {
       
        StartCoroutine(StartIn());

    }
    IEnumerator StartIn()
    {
    GameOver.SetActive(false);
        Time.timeScale = 1;
        Panel.SetActive(true);
        float fadecount = 0.0f;
        while(fadecount < 1.0f)
        {
            fadecount += 0.01f;
            yield return new WaitForSeconds(0.01f);
            Image.color = new Color(0, 0, 0, fadecount);
        }
        SceneManager.LoadScene("Game");

    }

    public void OffPause()
    {
        SceneManager.LoadScene("Game");
        Time.timeScale = 1;
    }
}
