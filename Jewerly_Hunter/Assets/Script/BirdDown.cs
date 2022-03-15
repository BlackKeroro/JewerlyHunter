using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdDown : MonoBehaviour
{
    GameObject Player;
    float TRange = 9.0f;
    float PRange = 7.0f;

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

        if (Range < TRange + PRange && transform.position.y > 2.8f)
        {
            transform.Translate(-0.24f, 0.0f, 0);
            StartCoroutine("DT");

        }
    }
    IEnumerator DT()
    {
        yield return new WaitForSeconds(4.0f);
        Destroy(gameObject);
    }
}
