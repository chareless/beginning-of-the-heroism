using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actions : MonoBehaviour
{
    public static float speed;
    public static float jump;
    void Start()
    {
        
    }
    void ButtonControl()
    {
        transform.position += new Vector3(speed, jump, 0) * Time.deltaTime;
    }
    void KeyboardControl()
    {
        Vector3 pos = transform.position;

        if(Input.GetKey("w"))
        {
            jump = 6f;
            pos.y += jump * Time.deltaTime;
        }
        if(Input.GetKey("d"))
        {
            speed = 5f;
            pos.x += speed * Time.deltaTime;
        }
        if(Input.GetKey("a"))
        {
            speed = 5f;
            pos.x -= speed * Time.deltaTime;
        }
        if(Input.GetKey("h"))
        {
            Hit();
        }
        if(Input.GetKey("j"))
        {
            UsePot();
        }
        transform.position = pos;
    }

    public void RightMovement()
    {
        speed = 5f;
    }

    public void LeftMovement()
    {
        speed = -5f;
    }

    public void StopMovement()
    {
        speed = 0;
    }

    public void Jump()
    {
        jump = 6f;
    }

    public void StopJump()
    {
        jump = 0f;
    }

    public void Hit()
    {

    }

    public void UsePot()
    {
        if(Status.potCount > 0)
        {
            Status.potCount--;
            Status.health = Status.maxHealth;
        }
    }
    void Update()
    {
        KeyboardControl();
        //ButtonControl();
    }
}
