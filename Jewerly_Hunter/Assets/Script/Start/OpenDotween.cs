using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class OpenDotween : MonoBehaviour
{
    [Header("제목")]
    public GameObject MainText;
    Text Maintxt;

    [Header("Key버튼")]
    public GameObject KeyButton;
    Image KeyB;
    public GameObject KeyText;
    Text Keytxt;

    [Header("Start버튼")]
    public GameObject StartButton;
    Image StartB;
    public GameObject StartText;
    Text Starttxt;

    [Header("Rule버튼")]
    public GameObject RuleButton;
    Image RuleB;
    public GameObject RuleText;
    Text Ruletxt;

    // Start is called before the first frame update
    void Start()
    {
        Maintxt = MainText.GetComponent<Text>();
        KeyB = KeyButton.GetComponent<Image>();
        Keytxt = KeyText.GetComponent<Text>();
        StartB = StartButton.GetComponent<Image>();
        Starttxt = StartText.GetComponent<Text>();
        RuleB = RuleButton.GetComponent<Image>();
        Ruletxt = RuleText.GetComponent<Text>();

        StartCoroutine("Dottween");
    }

    IEnumerator Dottween()
    {
        yield return new WaitForSeconds(1.5f);//1.5초 뒤 실행
        Maintxt.DOFade(1, 2);//텍스트 및 이미지의 투명도를 2초에 걸쳐 1(최대값)으로 변경
        yield return new WaitForSeconds(1f);
        KeyB.DOFade(1, 2);
        Keytxt.DOFade(1, 2);
        yield return new WaitForSeconds(1f);
        StartB.DOFade(1, 2);
        Starttxt.DOFade(1, 2);
        yield return new WaitForSeconds(1f);
        RuleB.DOFade(1, 2);
        Ruletxt.DOFade(1, 2);


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
