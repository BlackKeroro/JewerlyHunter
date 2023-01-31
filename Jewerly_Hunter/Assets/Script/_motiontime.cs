using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _motiontime : MonoBehaviour
{
    public GameObject []Trail;
   Animator[] anim;

    PlayerController PC;
    

    // Start is called before the first frame update
    void Start()
    {
        PC = GameObject.Find("Player").GetComponent<PlayerController>();
        Trail = new GameObject[transform.childCount];

        anim = new Animator[transform.childCount];

        for(int i = 0; i<Trail.Length; i++)
        {
            Trail[i] = transform.GetChild(i).gameObject;

            anim[i] = Trail[i].GetComponent<Animator>();
          
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (PC.JumpCount > 0)
        {
            if (Input.GetKeyDown(KeyCode.Space) && PC.JumpCount == 2)
            {
                StartCoroutine("Jump");
            }
            if (Input.GetKeyDown(KeyCode.Space) && PC.JumpCount == 1)
            {
                StartCoroutine("Jump2");
            }
        }
    }
    IEnumerator Jump()
    {
        for(int i = 0; i<Trail.Length; i++)
        {
            yield return new WaitForSeconds(0.1f);
            anim[i].SetTrigger("JumpTrigger");
        }
    }
    IEnumerator Jump2()
    {
        for (int i = 0; i < Trail.Length; i++)
        {
            yield return new WaitForSeconds(0.1f);
            anim[i].SetTrigger("Jump2Trigger");
        }
        
    }
}
