using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScore : MonoBehaviour
{
    GameManager GM;
    Text Scoretxt;

    // Start is called before the first frame update
    void Start()
    {
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
        Scoretxt = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        Scoretxt.text = GM.score.ToString();
    }
}
