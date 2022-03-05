using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    public bool hit = false;
    public GameObject Blood;
    Image BloodImg;
    public float currentTime = 0.0f;
    public float MoveSpeed = 8f;
    public int UpSpeed = 0;

    float JumpSpeed = 18.0f;

    float hitMaxTime = 1.0f;

    public int JumpCount = 2;
    GameObject Cpos;
    public bool isOndamage = false;
    public bool isGiant = false;
    public GameObject GiantOff;
    public bool ismagnet = false;

    public SpriteRenderer sr;
    public SpriteRenderer sr2;

    GameManager GM;

    public GameObject Run;

    public void Awake()
    {

    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Cpos = GameObject.Find("CameraPos");
        sr.GetComponent<SpriteRenderer>();
        sr2.GetComponent<SpriteRenderer>();
        BloodImg = Blood.GetComponent<Image>();
        JumpCount = 0;

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
        //rb.velocity = new Vector2(MoveSpeed, 0);
        if (GM.hp > 0)
        {
            //transform.position += transform.right * MoveSpeed * Time.deltaTime;
            Vector3 vec = new Vector3(MoveSpeed * Time.deltaTime, 0, 0);
            transform.Translate(vec);
            
        }

        if (hit == true)
        {
            MoveSpeed = 4f;
            currentTime += Time.deltaTime;
            if (currentTime >= hitMaxTime)
            {
                hit = false;
                currentTime = 0.0f;
                if(UpSpeed == 0)
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

        if (JumpCount > 0 && GM.hp > 0)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb.velocity = new Vector3(0, JumpSpeed, 0);
                JumpCount--;
            }
        }
    }

    void Sliding()
    {
        if (isGiant == false)
        {
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                Run.transform.localScale = new Vector3(Run.transform.localScale.x / 2, Run.transform.localScale.y / 2, Run.transform.localScale.z);

            }
            if (Input.GetKeyUp(KeyCode.DownArrow))
            {
                Run.transform.localScale = new Vector3(1, 1, Run.transform.localScale.z);

            }
        }
    }


    public IEnumerator Ondamage()
    {
        int countTime = 0;
        Blood.SetActive(true);
        float BloodTime = 100f; 
        while(BloodTime > 0)
        {
            BloodImg.color = new Color(BloodImg.color.r, BloodImg.color.g, BloodImg.color.b, BloodTime / 255f);
            yield return new WaitForSeconds(0.01f);
            BloodTime--;
        }
        while (countTime < 10)
        {
            if (countTime % 2 == 0)
            {
                sr.color = new Color(255f / 255f, 255f / 255f, 255f / 255f, 90 / 255f);
                sr2.color = new Color(255f / 255f, 255f / 255f, 255f / 255f, 90 / 255f);
            }
            else
                sr.color = new Color(255f/255f, 255f/255f, 255f/255f, 180/255f);
                sr2.color = new Color(255f/255f, 255f/255f, 255f/255f, 180/255f);
            yield return new WaitForSeconds(0.2f);

            countTime++;
        }
        sr.color = new Color(255f / 255f, 255f / 255f, 255f / 255f, 255 / 255f);
        sr2.color = new Color(255f / 255f, 255f / 255f, 255f / 255f, 255 / 255f);
        countTime = 0;
        isOndamage = false;
        Blood.SetActive(false);
        BloodTime = 100f;
        yield return null;
    }


    public IEnumerator Ongiant()
    {
            isGiant = true;
        float Updown = 1.0f;
        while(Updown < 2.3f)
        {
            Run.transform.localScale = new Vector3(Updown, Updown, 1);
            Updown += 0.4f;
            yield return new WaitForSeconds(0.01f);
        }
        yield return new WaitForSeconds(0.2f);
        while (Updown < 3.6f)
        {
            Run.transform.localScale = new Vector3(Updown, Updown, 1);
            Updown += 0.4f;
            yield return new WaitForSeconds(0.1f);
        }
        yield return new WaitForSeconds(0.2f);
        while (Updown < 5.0f)
        {
            Run.transform.localScale = new Vector3(Updown, Updown, 1);
            Updown += 0.4f;
            yield return new WaitForSeconds(0.1f);
        }
        yield return new WaitForSeconds(5.0f);


        Instantiate(GiantOff, transform.position, transform.rotation); //자이언트 해제 사운드
        while (Updown > 3.6f)
        {
            Run.transform.localScale = new Vector3(Updown, Updown, 1);
            Updown -= 0.4f;
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
        Updown = 1.0f;
        Run.transform.localScale = new Vector3(Updown, Updown, 1);
        isGiant = false;
        yield return null;
    }
    public IEnumerator Onmagnet()
    {
        ismagnet = true;
        
        yield return new WaitForSeconds(5.0f);
        ismagnet = false;
                yield return null;

    }


    public void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Ground"))
            {
                JumpCount = 2;

            }


        }

}

