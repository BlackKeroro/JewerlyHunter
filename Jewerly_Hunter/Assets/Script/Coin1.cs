using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin1 : MonoBehaviour
{
    PlayerController pc;
    // Start is called before the first frame update
    float TRange = 4.0f; //target 범위
    float PRange = 4.0f; //플레이어 범위 
    public GameObject Csound;

    GameManager GM;
    void Start()
    {
        pc = GameObject.Find("Player").GetComponent<PlayerController>();
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();

    }

    void Update()
    {
        if (pc.ismagnet == true) //Magnet 아이템이 활성화 될 시
        {
            //플레이어와 오브젝트의 포지션 값을 Vector2로 받음
            Vector2 Coin = transform.position;
            Vector2 Player = this.pc.transform.position;
            //오브젝트에 플레이어를 뺸 값의 길이(magnitude)를 구하기
            Vector2 Run = Coin - Player;
            float Range = Run.magnitude;

            if (Range < TRange + PRange) //길이를 구한 값이 지정한 값(8f)보다 작을 경우
            {
                //오브젝트의 포지션을 플레이어의 위치로 이동하며 이동시 0.4(임의 값)의 속도로 이동
                transform.position = Vector3.MoveTowards(transform.position, pc.transform.position, 0.4f);
            }
        }
    }
    public void OnTriggerEnter2D(Collider2D Collision)
    {
        if (Collision.gameObject.CompareTag("Player"))
        {
            GM.score += 1;
            Instantiate(Csound, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
