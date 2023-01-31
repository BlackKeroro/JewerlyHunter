using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSound : MonoBehaviour
{
    float currentime = 0.0f;
    float Dtime = 2.0f;

    AudioSource AU;
    // Start is called before the first frame update
    void Start()
    {
        AU = GetComponent<AudioSource>();
        AU.Play();
    }

    // Update is called once per frame
    void Update()
    {
        currentime += Time.deltaTime;
        if(currentime > Dtime)
        {
            Destroy(gameObject);
        }
    }
}
