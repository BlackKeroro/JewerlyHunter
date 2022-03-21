using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpTrap : MonoBehaviour
{
    GameObject Player;
    float TRange = 5.0f;
    float PRange = 5.0f;

    float Speed = 2;
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
        if(Range < TRange + PRange && transform.position.y < -3.3f)
        {
            //오브젝트를 위 방향 + 스피드 + time.deltatime으로 이동
            transform.position += Vector3.up * Speed * Time.deltaTime;
            Debug.Log("실행");
            StartCoroutine("DT");

        }
    }
    IEnumerator DT() //실행 되었을 때 4초 뒤에 오브젝트 제거
    {
        yield return new WaitForSeconds(4.0f);
        Destroy(gameObject);
    }
}
