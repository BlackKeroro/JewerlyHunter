using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdDownUP : MonoBehaviour
{
    GameObject Player;
    float TRange = 15.0f;
    float PRange = 13.0f;
    float RoteTime = 0.0f;

    float Speed = 8f;
    bool isTurn = false;

    // Start is called before the first frame update
    void Start()
    {
        this.Player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //오브젝트의 포지션 값에 플레이어의 포지션을 뺀 값의 크기(magnitude) 대입
        Vector2 Trap = transform.position;
        Vector2 Player = this.Player.transform.position;
        Vector2 Run = Trap - Player;
        float Range = Run.magnitude;

        //크기 값이 지정 값(10)보다 작고 오브젝트의 위치가 -3.3f 이하일 때
        if (Range < TRange + PRange)
        {
            //오브젝트의 y 값이 -0.4보다 크고 isTurn이 false일 때
            if (transform.position.y > -0.4 && isTurn == false)
            {
                //오브젝트의 위치를 대각선으로 이동
                transform.position += Vector3.down * Speed * Time.deltaTime;
                transform.position += Vector3.left * Speed * Time.deltaTime;
            }
            RoteTime += Time.deltaTime;
            Destroy(gameObject, 4f); // 4초 뒤 파괴
        }
        //오브젝트의 y 값이 -0.4보다 작거나 isTurn이 true일 때
        if(transform.position.y < -0.4f || isTurn == true)
        {
            //오브젝트의 방향을 -45로 전환하며 위치를 위쪽 대각선으로 이동
            transform.rotation = Quaternion.Euler(0, 0, -45f);
            isTurn = true;
            transform.position += Vector3.up * Speed * Time.deltaTime;
            transform.position += Vector3.left * Speed * Time.deltaTime;
        }
        
    }
}
