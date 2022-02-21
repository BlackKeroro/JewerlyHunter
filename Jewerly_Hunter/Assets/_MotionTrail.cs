using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _MotionTrail : MonoBehaviour
{
    public GameObject trailTarget;
    public GameObject RunScale;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Trail();
    }

    void Trail()
    {
        transform.position = Vector3.Lerp(transform.position, trailTarget.transform.position, 6f * Time.deltaTime);
        transform.localScale = Vector3.Lerp(transform.localScale, RunScale.transform.localScale, 3f * Time.deltaTime);
    }
}
