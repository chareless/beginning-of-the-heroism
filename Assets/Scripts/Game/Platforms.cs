using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platforms : MonoBehaviour
{
    public int speed;
    public float timer;
    public float mainTimer;
    public int moveType;
    void Start()
    {
        timer = mainTimer;
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if(moveType==1)
        {
            gameObject.transform.position -= new Vector3(0, speed*Time.deltaTime, 0);
            if (timer <= 0)
            {
                speed *= -1;
                timer = mainTimer;
            }
        }
        else if(moveType==2)
        {
            gameObject.transform.position += new Vector3( speed * Time.deltaTime, 0,0);
            if (timer <= 0)
            {
                speed *= -1;
                timer = mainTimer;
            }
        }
       

    }
}
