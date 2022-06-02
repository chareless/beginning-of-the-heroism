using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platforms : MonoBehaviour
{
    public int speed;
    public float timer;
    public float mainTimer;
    public int moveType;
    public bool first;
    void Start()
    {
        timer = mainTimer;
    }

    void Update()
    {
        if(first)
        {
            timer -= Time.deltaTime;
            if (moveType == 1)
            {
                gameObject.transform.position -= new Vector3(0, speed * Time.deltaTime, 0);
                if (timer <= 0)
                {
                    speed *= -1;
                    timer = mainTimer;
                }
            }
            else if (moveType == 2)
            {
                gameObject.transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
                if (timer <= 0)
                {
                    speed *= -1;
                    timer = mainTimer;
                }
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="Player")
        {
            first = true;
        }
    }
}
