using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actions : MonoBehaviour
{
    public Animator animator;
    
    public static float speed;
    public GameObject Rogue;
    public GameObject Archer;
    public GameObject Wizard;
    public GameObject Knight;
    public static float jump;
    public static int rotate;
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

        if (Input.GetKeyDown("w"))
        {
            animator.SetFloat("jump",10f);
            animator.SetFloat("left",0f);
            animator.SetFloat("right",0f);
            animator.SetFloat("attack",0f);
            jump = 6f;
            Rigidbody2D rgbr = GetComponent<Rigidbody2D>();
            rgbr.AddForce(transform.up * jump, ForceMode2D.Impulse);
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

    void GetAnimator()
    {
        animator = GetComponentInChildren<Animator>();
    }
    void RotatePlayer()
    {
        if (Status.playerClass == "Rogue")
        {
            Rogue.transform.rotation = Quaternion.Euler(0, rotate, 0);
        }
        else if(Status.playerClass == "Wizard")
        {
            Wizard.transform.rotation = Quaternion.Euler(0, rotate, 0);
        }
        else if(Status.playerClass == "Archer")
        {
            Archer.transform.rotation = Quaternion.Euler(0, rotate, 0);
        }
        else if(Status.playerClass == "Knight")
        {
            Knight.transform.rotation = Quaternion.Euler(0, rotate, 0);
        }
    }
    public void RightMovement()
    {
        animator.SetFloat("jump",0f);
        animator.SetFloat("left",0f);
        animator.SetFloat("right",10f);
        animator.SetFloat("attack",0f);
        animator.SetFloat("state",0f);
        rotate = 0;
        RotatePlayer();
        speed = 5f;
    }

    public void LeftMovement()
    {
        animator.SetFloat("jump",0f);
        animator.SetFloat("right",10f);
        animator.SetFloat("attack",0f);
        animator.SetFloat("state",0f);
        rotate = 180;
        RotatePlayer();
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
        jump = 3f;
        Rigidbody2D rgbr = GetComponent<Rigidbody2D>();
        rgbr.AddForce(transform.up * jump, ForceMode2D.Impulse);
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
        animator.SetFloat("attack",10f);
        animator.SetFloat("state",0f);
        animator.Play("Rogue-Attack");
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
        GetAnimator();
        KeyboardControl();
        //ButtonControl();
    }
}