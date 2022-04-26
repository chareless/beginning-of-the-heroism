using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaMove : MonoBehaviour
{
    public int speed=3;
    public float timer=15f;
    void Start()
    {
        
    }

    void Update()
    {
        timer -= Time.deltaTime;
        gameObject.transform.position += new Vector3(0, speed * Time.deltaTime, 0);
        if (timer<=10 && timer>7.5f)
        {
            speed = 0;
        }
        else if(timer<=7.5f && timer>2.5f)
        {
            speed = -3;
        }
        else if(timer <=2.5f && timer>0)
        {
            speed = 0;
        }
        else if(timer <=0)
        {
            speed = 3;
            timer = 15f;
        }
        
    }
}
