using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudPrefab : MonoBehaviour
{
    public GameObject Cloudprefab;
    public float createCloud;

    float currentTime = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime > createCloud)
        {
            //일정시간에 한번씩만 들어온다.
            // Enemy를 생성
            GameObject enemy = Instantiate(Cloudprefab);
            enemy.transform.position = transform.position;
            currentTime = 0.0f;

        }
    }
}
