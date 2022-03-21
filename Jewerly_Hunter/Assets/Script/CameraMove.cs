using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public GameObject target;
    bool Go = false;



    // Start is called before the first frame update
    void Start()
    {
        //카메라 이동 1.5초 후 시작
        Invoke("Wait", 1.5f);
    }
    void Wait()
    {
        Go = true;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
     void Move()
    {  if(Go == true)
        {
            //target(카메라 이동할 위치)로 이동
            Vector3 FixedPos = new Vector3(target.transform.position.x, 0.25f, -10);
            //Lerp를 사용하여 현재 위치에서 FixedPos 위치로 서서히 이동
            transform.position = Vector3.Lerp(transform.position, FixedPos, 10.0f * Time.deltaTime);
        }

    }

}
