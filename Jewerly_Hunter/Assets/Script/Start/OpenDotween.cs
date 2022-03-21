using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class OpenDotween : MonoBehaviour
{
    [Header("����")]
    public GameObject MainText;
    Text Maintxt;

    [Header("Key��ư")]
    public GameObject KeyButton;
    Image KeyB;
    public GameObject KeyText;
    Text Keytxt;

    [Header("Start��ư")]
    public GameObject StartButton;
    Image StartB;
    public GameObject StartText;
    Text Starttxt;

    [Header("Rule��ư")]
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
        yield return new WaitForSeconds(1.5f);//1.5�� �� ����
        Maintxt.DOFade(1, 2);//�ؽ�Ʈ �� �̹����� ������ 2�ʿ� ���� 1(�ִ밪)���� ����
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
