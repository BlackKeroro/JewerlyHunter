using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftTrap : MonoBehaviour
{

    GameObject Player;
    float TRange = 8.0f;
    float PRange = 7.0f;

    float Speed = 8f;
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
            transform.position += Vector3.left * Speed * Time.deltaTime;
            StartCoroutine("DT");
        }


    }
    IEnumerator DT()
    {
        yield return new WaitForSeconds(4.0f);
        Destroy(gameObject);
    }
}
