using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdDownUP : MonoBehaviour
{
    GameObject Player;
    float TRange = 15.0f;
    float PRange = 13.0f;
    float RoteTime = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        this.Player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 Trap = transform.position;
        Vector2 Player = this.Player.transform.position;
        Vector2 Run = Trap - Player;
        float Range = Run.magnitude;


        if (Range < TRange + PRange)
        {
            transform.Translate(-0.06f, 0.0f, 0);
            RoteTime += Time.deltaTime;
            StartCoroutine("DT");
        }
        if(RoteTime > 0.3f)
        {
            StartCoroutine("Rote");
        }
        
    }

    IEnumerator Rote()
    {
        yield return new WaitForSeconds(1.0f);
        transform.rotation = Quaternion.Euler(0, 0, -45f);
    }

    IEnumerator DT()
    {
        yield return new WaitForSeconds(4.0f);
        Destroy(gameObject);
    }
}
