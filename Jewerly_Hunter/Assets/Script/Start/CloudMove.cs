using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMove : MonoBehaviour
{
    public float Speed;

    // Start is called before the first frame update
    void Start()
    {
        Speed = Random.Range(2f, 4f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.right * Speed * Time.deltaTime;
        if(transform.position.x > 20.0f)
        {
            Destroy(gameObject);
        }
    }
}
