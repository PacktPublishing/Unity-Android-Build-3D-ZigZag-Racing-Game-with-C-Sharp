using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    float Zdistance;
    public float smoothValue;
    Vector3 distance;

    // Start is called before the first frame update
    void Start()
    {
        //Zdistance = target.position.z - transform.position.z ;
        distance = target.position - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(target.position.y >= 0)
        {
            Follow();
        }

        //transform.position = currentPos;
    }

    private void FixedUpdate()
    {


        //transform.LookAt(target);

    }

    void Follow()
    {
        Vector3 currentPos = transform.position;
        Vector3 targetPos = target.position - distance;
        //targetPos.z = target.position.z + Zdistance;

        transform.position = Vector3.Lerp(currentPos, targetPos, smoothValue * Time.deltaTime);
    }
}
