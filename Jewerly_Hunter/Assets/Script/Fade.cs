using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    Image Image;

    public void Awake()
    {

    }
    // Start is called before the first frame update
    public void Start()
    {
        Image = GetComponent<Image>();
        StartCoroutine("FadeOut");

    }

    IEnumerator FadeOut()
    {
        float fadecnt = 1.0f;
        while (fadecnt > 0.0f)
        {
            fadecnt -= 0.01f;
            yield return new WaitForSeconds(0.01f);
            Image.color = new Color(0, 0, 0, fadecnt);
            if (fadecnt <= 0.0f)
            {
                GetComponent<Fade>().enabled = false;
                gameObject.SetActive(false);   
            }
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}
