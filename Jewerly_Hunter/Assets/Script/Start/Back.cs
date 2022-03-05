using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Back : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnClick()
    {
        SceneManager.LoadScene("Start");
    }
    public void OffPause()
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
