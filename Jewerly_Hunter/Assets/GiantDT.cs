using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiantDT : MonoBehaviour
{
    public float currenTime = 0f;
    public float Dtime = 1f;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currenTime += Time.deltaTime;
        if(currenTime > Dtime)
        {
            Destroy(gameObject);
        }
    }
}
