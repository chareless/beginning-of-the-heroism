using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saw : MonoBehaviour
{
    public float rotateAngle = 0;
    public float speed = 20;
    void Start()
    {
        
    }

    void Rotate()
    {
        rotateAngle += 1;
        if(rotateAngle==360)
        {
            rotateAngle = 0;
        }
        gameObject.transform.rotation = Quaternion.Euler(0,0,rotateAngle*10);
    }

    void Move()
    {
        gameObject.transform.position -= new Vector3(speed*Time.deltaTime,0,0);
        if(transform.position.x <= 580)
        {
            gameObject.transform.position = new Vector3(637, -68.5f, 0);
        }
    }
    // Update is called once per frame
    void Update()
    {
        Rotate();
        Move();
    }
}
