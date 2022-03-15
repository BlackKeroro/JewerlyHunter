using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpTrap : MonoBehaviour
{
    GameObject Player;
    float TRange = 5.0f;
    float PRange = 5.0f;

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

        if(Range < TRange + PRange && transform.position.y < -3.3f)
        {
            transform.Translate(0, 0.12f, 0);
            Debug.Log("실행");
            StartCoroutine("DT");

        }
    }
    IEnumerator DT()
    {
        yield return new WaitForSeconds(4.0f);
        Destroy(gameObject);
    }
}
