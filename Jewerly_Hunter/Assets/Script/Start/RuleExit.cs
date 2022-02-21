using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuleExit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnClick()
    {
        GameObject.Find("RuleBotton").transform.GetChild(1).gameObject.SetActive(false);

    }
    public void OffKey()
    {
        GameObject.Find("Key").transform.GetChild(1).gameObject.SetActive(false);
        GameObject.Find("Canvas").transform.GetChild(1).gameObject.SetActive(true);
        GameObject.Find("Canvas").transform.GetChild(3).gameObject.SetActive(true);
    }
}
