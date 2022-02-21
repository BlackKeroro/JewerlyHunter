using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Run : MonoBehaviour
{
    PlayerController pc;
    public Animator anim;

    GameManager GM;

    AudioSource DAU;

    public GameObject DTeffect;
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
        if (Input.GetKeyDown(KeyCode.Space) && pc.JumpCount == 1)
        {
            anim.SetTrigger("JumpTrigger");
            print("점프1");
        }
        if (Input.GetKeyDown(KeyCode.Space) && pc.JumpCount == 0)
        {
            anim.SetTrigger("Jump2Trigger");
            print("점프2");

        }

    }


    


    public void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Enemy") && pc.isOndamage == false)
        {
            if(pc.isGiant == false)
            {
                DAU.Play();
                pc.hit = true;
                GM.hp -= 5f;
                if (GM.hp > 1)
                {
                    pc.isOndamage = true;
                    pc.StartCoroutine("Ondamage");
                }
            }
            else if(pc.isGiant == true)
            {
                Instantiate(DTeffect, collision.transform.position, collision.transform.rotation);
                Destroy(collision.gameObject);
            }


        }
        if (collision.gameObject.CompareTag("Health"))
        {
            if (GM.hp <= 85f)
            {
                GM.hp += 15f;
                Destroy(collision.gameObject);

            }
            else if (GM.hp > 85.0f)
            {
                GM.hp += (100.0f - GM.hp);
                Destroy(collision.gameObject);

            }
        }
        if (collision.gameObject.CompareTag("Giant"))
        {
            pc.StartCoroutine("Ongiant");
            Destroy(collision.gameObject);
            
        }
        if (collision.gameObject.CompareTag("Magnet"))
        {
            pc.StartCoroutine("Onmagnet");
            Destroy(collision.gameObject);
        }
    }


}
