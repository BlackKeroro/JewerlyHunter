using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb; 
    public bool hit = false; //피격시 이동  판정 
    public float currentTime = 0.0f; //피격 시 캐릭터 움직임 둔화 시작
    float hitMaxTime = 1.0f; //피격 시 캐릭터 움직임 둔화 최대시간
    
    public GameObject Blood;
    Image BloodImg; //피격 시 받는 피 이미지
    
    public float MoveSpeed = 8f; //시작 시 캐릭터 속도
    public int UpSpeed = 0; //스테이지에 따른 속도 변화
    float JumpSpeed = 18.0f; //점프 속도
    public int JumpCount = 2; //점프 횟수(최대 2번)
    

    
    GameObject Cpos; //카메라 위치
    
    public bool isOndamage = false; //피격 판정
    public bool isGiant = false; //자이언트 비약 아이템 판정
    public GameObject GiantOff; //자이언트 사운드
    public bool ismagnet = false; //자석 아이템 판정

    public SpriteRenderer sr; //Run 캐릭터 오브젝트의 Sprite Renderer

    GameManager GM; //Game Manager 오브젝트

    public GameObject Run; //Run 오브젝트

    public void Awake()
    {

    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Cpos = GameObject.Find("CameraPos");
        sr.GetComponent<SpriteRenderer>(); 
        BloodImg = Blood.GetComponent<Image>();
        
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
        Run = GameObject.Find("Run");
    }

    // Update is called once per frame
    void Update()
    {
        Move(); 
        Jump();
        Sliding();


    }


    void Move()
    {
        if (GM.hp > 0) //GameManager의 체력이 0보다 크면 실행
        {
            Vector3 vec = new Vector3(MoveSpeed * Time.deltaTime, 0, 0); //Vector3 위치 값으로 캐릭터 이동 속도 설정
            transform.Translate(vec); //Vector3의 값 vec만큼 이동     
        }

        if (hit == true) //피격 판정이 true 일 때
        {
            MoveSpeed = 4f; //이동 속도 둔화(기본 8)
            currentTime += Time.deltaTime; //currentTime에 시간적용
            if (currentTime >= hitMaxTime) //흐른 시간이 최대 시간보다 클 경우
            {
                hit = false; //피격 판정 false
                currentTime = 0.0f; //currentTime 초기화
                if(UpSpeed == 0)//스테이지에 따른 속도 변화(1스테이지 = 0, 2스테이지 = 1)
                {
                  MoveSpeed = 8f;
                }
                else if(UpSpeed == 1)
                {
                    MoveSpeed = 11f;
                }
                else
                {
                    MoveSpeed = 14f;
                }
            }

        }

    }

    void Jump()
    {

        if (JumpCount > 0 && GM.hp > 0) //점프 횟수가 0보다 크고 GameManager의 체력이 0보다 클때
        {
            if (Input.GetKeyDown(KeyCode.Space))//스페이스 키를 누를 때 실행
            {
                rb.velocity = new Vector3(0, JumpSpeed, 0);//물체의 움직임을 y값에 줘서 위로 이동
                JumpCount--; //점프 횟수 감소
            }
        }
    }

    void Sliding()
    {
        if (isGiant == false) //Giant 아이템을 먹지 않았을 경우
        {
            if (Input.GetKeyDown(KeyCode.DownArrow)) //아래 화살표를 누를 시 Run 오브젝트의 크기를 현재 크기의 1/2로 감소
            {
                Run.transform.localScale = new Vector3(Run.transform.localScale.x / 2, Run.transform.localScale.y / 2, Run.transform.localScale.z);

            }
            if (Input.GetKeyUp(KeyCode.DownArrow)) //아래 화살표를 땔 시 Run 오브젝트의 크기를 원래 크기로 변경
            {
                Run.transform.localScale = new Vector3(1, 1, Run.transform.localScale.z);

            }
        }
    }

    public IEnumerator Ondamage() //피격 판정을 입었을 경우 Coroutine 실행
    {
        int countTime = 0; //캐릭터 투명도
        while (countTime < 10) //countTime이 10 보다 작을 시 반복 실행
        {
            if (countTime % 2 == 0) //countTIme에 2를 게속 나눌 때 나머지 값이 0일 경우
            {
                sr.color = new Color(255f / 255f, 255f / 255f, 255f / 255f, 90 / 255f); //캐릭터 투명도 값 적용
            }
            else
                sr.color = new Color(255f/255f, 255f/255f, 255f/255f, 180/255f); // 캐리거 투명도 값 적용
            yield return new WaitForSeconds(0.2f); //대기시간(투명도 변환 시간) 0.2초 = 0.2초마다 투명도 변함

            countTime++;//countTime 값 증가
        }
        //countTime이 끝날 경우
        sr.color = new Color(255f / 255f, 255f / 255f, 255f / 255f, 255 / 255f);
        countTime = 0; //countTime 초기화
        isOndamage = false; //Ondamage 비활성화
        yield return null;
    }

    public IEnumerator HitBlood()
    {

        Blood.SetActive(true); //피 이미지 활성화
        float BloodTime = 100f; //피 이미지 a(투명도)값 초기화
        while (BloodTime > 0) //BloodTime이 0 이상일 시 반복 실행
        {
            //피 이미지의 a값에 BloodTime 값을 적용
            BloodImg.color = new Color(BloodImg.color.r, BloodImg.color.g, BloodImg.color.b, BloodTime / 255f);
            yield return new WaitForSeconds(0.01f); //대기시간 0.01초
            BloodTime--;//BloodTime에 -1

        }
        Blood.SetActive(false); //피 이미지 비활성화
    }


    public IEnumerator Ongiant() //자이언트 아이템 사용 시 Coroutine 실행
    {
            isGiant = true; //Giant 활성화
        float Updown = 1.0f; //현재 캐릭터 크기
        while(Updown < 2.3f)// 만약 캐릭터 크기가 2.3보다 작으면 반복 실행
        {
            Run.transform.localScale = new Vector3(Updown, Updown, 1); //Run 오브젝트 크기에 Updown을 대입
            Updown += 0.4f; //Updown 크기 증가
            yield return new WaitForSeconds(0.01f); //대기 시간 0.01
        }
        //반복 실행이 끝났을 때
        yield return new WaitForSeconds(0.2f);//대기 시간 0.2 후에 다음 실행 
        while (Updown < 3.6f) // 만약 캐릭터 크기가 3.6보다 작으면 반복 실행
        {
            Run.transform.localScale = new Vector3(Updown, Updown, 1);
            Updown += 0.4f;
            yield return new WaitForSeconds(0.1f);
        }
        yield return new WaitForSeconds(0.2f);
        while (Updown < 5.0f)// 만약 캐릭터 크기가 5보다 작으면 반복 실행
        {
            Run.transform.localScale = new Vector3(Updown, Updown, 1);
            Updown += 0.4f;
            yield return new WaitForSeconds(0.1f);
        }
        //대기 시간 5초 뒤 다음 실행
        yield return new WaitForSeconds(5.0f);


        Instantiate(GiantOff, transform.position, transform.rotation); //자이언트 해제 사운드 오브젝트 생성
        while (Updown > 3.6f)// 만약 캐릭터 크기가 2.3보다 작으면 반복 실행
        {
            Run.transform.localScale = new Vector3(Updown, Updown, 1);
            Updown -= 0.4f;// 캐릭터 크기 감소
            yield return new WaitForSeconds(0.01f);
        }
        yield return new WaitForSeconds(0.2f);
        while (Updown > 2.3f)
        {
            Run.transform.localScale = new Vector3(Updown, Updown, 1);
            Updown -= 0.4f;
            yield return new WaitForSeconds(0.1f);
        }
        yield return new WaitForSeconds(0.2f);
        while (Updown > 1.0f)
        {
            Run.transform.localScale = new Vector3(Updown, Updown, 1);
            Updown -= 0.4f;

            yield return new WaitForSeconds(0.1f);
        }
        Updown = 1.0f; // 캐릭터 크기 초기화
        Run.transform.localScale = new Vector3(Updown, Updown, 1);//Updown 초기화 적용
        isGiant = false; //Giant 비활성화
        yield return null;
    }
    public IEnumerator Onmagnet()//자석 아이템 사용시 Coroutine 실행
    {
        ismagnet = true; //자석 활성화
        
        yield return new WaitForSeconds(5.0f); // 대기 시간
        ismagnet = false; //자석 비활성화
                yield return null;

    }


    public void OnTriggerEnter2D(Collider2D collision) //Trigger 충돌
        {
            if (collision.gameObject.CompareTag("Ground"))//충돌한 Tag가 Ground일 때 
            {
                JumpCount = 2;//점프 카운트 초기화
            }
        }

}

