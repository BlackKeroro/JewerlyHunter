using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin10 : MonoBehaviour
{
    PlayerController pc;
    // Start is called before the first frame update
    float TRange = 4.0f;
    float PRange = 5.0f;
    GameManager GM;

    public GameObject Csound;
    void Start()
    {
        pc = GameObject.Find("Player").GetComponent<PlayerController>();
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();


    }
    void Update()
    {
        if (pc.ismagnet == true)
        {
            Vector2 Coin = transform.position;
            Vector2 Player = this.pc.transform.position;
            Vector2 Run = Coin - Player;
            float Range = Run.magnitude;

            if (Range < TRange + PRange)
            {
                transform.position = Vector3.MoveTowards(transform.position, pc.transform.position, 0.4f);

            }
        }

    }
    // Start is called before the first frame update
    public void OnTriggerEnter2D(Collider2D Collision)
    {
        if (Collision.gameObject.CompareTag("Player"))
        {
            GM.score += 10;
            Instantiate(Csound, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
