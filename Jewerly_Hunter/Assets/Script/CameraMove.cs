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
            Vector3 FixedPos = new Vector3(target.transform.position.x, 0.25f, -10);

            transform.position = Vector3.Lerp(transform.position, FixedPos, 10.0f * Time.deltaTime);
        }

    }

}
