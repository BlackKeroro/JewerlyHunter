using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterIntro : MonoBehaviour
{
    Animator anim;
    float LoadTime;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        LoadTime += Time.deltaTime;

        if(LoadTime > 2)
        {
            anim.SetTrigger("IdleTrigger");
        }
    }
}
