using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapRot : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 rot = new Vector3(0, 0, -8f);
        transform.Rotate(rot);
    }
}
