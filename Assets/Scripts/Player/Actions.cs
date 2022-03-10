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
        animator = GetComponent<Animator>();
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
            animator.SetFloat("jumpSpeed",10);
            animator.SetFloat("attackTime",0);
            animator.SetFloat("Vertical",0);
            animator.SetFloat("Horizontal",0);
            jump = 6f;
            pos.y += jump * Time.deltaTime;
        }
        if(Input.GetKey("d"))
        {
            animator.SetFloat("jumpSpeed",0);
            animator.SetFloat("walkSpeed",10);
            animator.SetFloat("attackTime",0);
            animator.SetFloat("Vertical",0);
            animator.SetFloat("Horizontal",10);
            speed = 5f;
            pos.x += speed * Time.deltaTime;
        }
        if(Input.GetKey("a"))
        {
            animator.SetFloat("jumpSpeed",0);
            animator.SetFloat("walkSpeed",10);
            animator.SetFloat("attackTime",0);
            animator.SetFloat("Vertical",10);
            animator.SetFloat("Horizontal",0);
            speed = 5f;
            pos.x -= speed * Time.deltaTime;
        }
        if(Input.GetKey("h"))
        {
            animator.SetFloat("jumpSpeed",0);
            animator.SetFloat("walkSpeed",0);
            animator.SetFloat("attackTime",10);
            animator.SetFloat("Vertical",0);
            animator.SetFloat("Horizontal",0);
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
    void Update()
    {
        KeyboardControl();
        //ButtonControl();
    }
}
