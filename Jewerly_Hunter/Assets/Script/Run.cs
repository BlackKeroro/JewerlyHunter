using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Run : MonoBehaviour
{
    PlayerController pc; //PlayerController가져오기
    public Animator anim;

    GameManager GM;

    AudioSource DAU; //피격 오디오 소스

    public GameObject DTeffect; //파괴 오브젝트 리팹
    // Start is called before the first frame update
    void Start()
    {
        pc = GameObject.Find("Player").GetComponent<PlayerController>();
        DAU = GetComponent<AudioSource>();
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && pc.JumpCount == 1)//스페이스 키를 눌렀을 때 PlayerController script의 JumpCount가 1이면 실행
        {
            anim.SetTrigger("JumpTrigger"); //Jump 애니메이션 실행
            print("점프1");
        }
        if (Input.GetKeyDown(KeyCode.Space) && pc.JumpCount == 0) //스페이스 키를 눌렀을 때 PlayerController script의 JumpCount가 0이면 실행
        {
            anim.SetTrigger("Jump2Trigger"); //Jump2 애니메이션 실행
            print("점프2");

        }

    }


    


    public void OnTriggerEnter2D(Collider2D collision) // Collider의 Trigger 충돌시 실행
    {

        if (collision.gameObject.CompareTag("Enemy") && pc.isOndamage == false) //만약 충돌 한 오브젝트의 Tag가 Enemy이고 Ondamage가 비활성화 일 때
        {
            if(pc.isGiant == false) //만약 Giant가 비활성화 일 때
            {
                DAU.Play(); //피격 오디오 실행
                pc.hit = true; //PlayerController의 hit(피격판정) 활성화
                GM.hp -= 5f; //GameManager의 hp를 5감소
                if (GM.hp > 1) // 만약 GameManager의 hp가 1보다 클 경우
                {
                    pc.isOndamage = true; //Ondamage 활성화
                    pc.StartCoroutine("Ondamage"); //PlayerController의 Ondamage 코루틴 실행
                }
            }
            else if(pc.isGiant == true) // 만약 isGiant가 활성화 상태일 때
            {
                Instantiate(DTeffect, collision.transform.position, collision.transform.rotation); //해당 오브젝트 위치에 파괴이펙트 생성 및 
                Destroy(collision.gameObject); // 해당 오브젝트 제거
            }


        }
        if (collision.gameObject.CompareTag("Health")) // 만약 충돌한 오브젝트의 tag가 Health일 때
        {
            if (GM.hp <= 85f) // GamaManager의 hp이 85 이하일 때
            {
                GM.hp += 15f;// hp에 15회복
                Destroy(collision.gameObject);

            }
            else if (GM.hp > 85.0f) // 만약 hp가 85 이상일 때
            {
                GM.hp = 100.0f; //hp를 최대치로 회복
                Destroy(collision.gameObject);

            }
        }
        if (collision.gameObject.CompareTag("Giant")) // 만약 충돌한 오브젝트의 tag가 Giant일 때
        {
            pc.StartCoroutine("Ongiant"); //Ongiant 코루틴 실행
            Destroy(collision.gameObject);
            
        }
        if (collision.gameObject.CompareTag("Magnet")) // 만약 충돌한 오브젝트의 tag가 magnet일 때
        {
            pc.StartCoroutine("Onmagnet"); //OnMagnet 
            Destroy(collision.gameObject);
        }
    }


}
