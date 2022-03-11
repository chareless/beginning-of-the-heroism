using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actions : MonoBehaviour
{
    public Animator animator;
    public static float speed;
    public static float jump;
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }
    void ButtonControl()
    {
        transform.position += new Vector3(speed, jump, 0) * Time.deltaTime;
    }
    void KeyboardControl()
    {
        Vector3 pos = transform.position;

        if (Input.GetKey("w"))
        {
            animator.SetFloat("jump",10f);
            animator.SetFloat("left",0f);
            animator.SetFloat("right",0f);
            animator.SetFloat("attack",0f);
            jump = 6f;
            pos.y += jump * Time.deltaTime;
        }
        if (Input.GetKey("d"))
        {
            animator.SetFloat("jump",0f);
            animator.SetFloat("left",0f);
            animator.SetFloat("right",10f);
            animator.SetFloat("attack",0f);
            speed = 5f;
            pos.x += speed * Time.deltaTime;
        }
        if (Input.GetKey("a"))
        {
            animator.SetFloat("jump",0f);
            animator.SetFloat("left",10f);
            animator.SetFloat("right",0f);
            animator.SetFloat("attack",0f);
            speed = 5f;
            pos.x -= speed * Time.deltaTime;
        }
        if (Input.GetKey("h"))
        {
            animator.SetFloat("jump",0f);
            animator.SetFloat("left",0f);
            animator.SetFloat("right",0f);
            animator.SetFloat("attack",10f);
            Hit();
        }
        if (Input.GetKey("j"))
        {
            UsePot();
        }
        transform.position = pos;
    }
    public void RightMovement()
    {
            animator.SetFloat("jump",0f);
            animator.SetFloat("left",0f);
            animator.SetFloat("right",10f);
            animator.SetFloat("attack",0f);
            animator.SetFloat("state",0f);
            speed = 5f;
    }

    public void LeftMovement()
    {
            animator.SetFloat("jump",0f);
            animator.SetFloat("left",10f);
            animator.SetFloat("right",0f);
            animator.SetFloat("attack",0f);
            animator.SetFloat("state",0f);
            speed = -5f;
    }

    public void StopMovement()
    {
        
        speed = 0;
        animator.SetFloat("state",10f);
        animator.SetFloat("jump",0f);
        animator.SetFloat("left",0f);
        animator.SetFloat("right",0f);
    }

    public void Jump()
    {
            animator.SetFloat("jump",10f);
            animator.SetFloat("left",0f);
            animator.SetFloat("right",0f);
            animator.SetFloat("attack",0f);
            animator.SetFloat("state",0f);
            jump = 6f;
    }

    public void StopJump()
    {
        jump = 0f;
        animator.SetFloat("state",10f);
        animator.SetFloat("jump",0f);
        animator.SetFloat("left",0f);
        animator.SetFloat("right",0f);
    }

    public void Hit()
    {
            animator.SetFloat("jump",0f);
            animator.SetFloat("left",0f);
            animator.SetFloat("right",0f);
            animator.SetFloat("attack",10f);
            animator.SetFloat("state",0f);
    }

    public void UsePot()
    {
        if (Status.potCount > 0)
        {
            Status.potCount--;
            Status.health = Status.maxHealth;
        }
    }
    void Update()
    {
        //KeyboardControl();
        ButtonControl();
    }
}