using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slide : MonoBehaviour
{
    GameManager GM;
    PlayerController PC;

    // Start is called before the first frame update
    void Start()
    {
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
        PC = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {

    }



    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") &&PC.isOndamage == false)
        {
            PC.hit = true;
            GM.hp -= 5f;
            if (GM.hp > 1)
            {
                PC.isOndamage = true;
                PC.StartCoroutine("Ondamage");
            }

        }
        if (collision.gameObject.CompareTag("Health"))
        {
            if (GM.hp <= 90f)
            {
                GM.hp += 5f;
                Destroy(collision.gameObject);

            }
            else if (GM.hp > 90.0f)
            {
                GM.hp += (100.0f - GM.hp);
                Destroy(collision.gameObject);

            }
        }
    }

}
