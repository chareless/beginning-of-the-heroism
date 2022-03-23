using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actions : MonoBehaviour
{
    public Animator animator;
    
    public GameObject Rogue;
    public GameObject Archer;
    public GameObject Wizard;
    public GameObject Knight;
    public GameObject sword;
    public GameObject shooter;
    public GameObject arrow;
    public GameObject magic;
    public static float jump=7f;
    public static int rotate;
    public float shootTimer;
    public float delay = 0.5f;
    public static float bulletForce;
    Rigidbody2D rigidbody;
    public static float speed = 800f;
    public static float speedKey = 5f;
    public static float yatay;
    Vector3 velocity;
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    void ButtonControl()
    {
        rigidbody.velocity = new Vector2(yatay * speed * Time.deltaTime, rigidbody.velocity.y);
    }
    void KeyboardControl()
    {
        if (Input.GetKeyDown("w"))
        {
            animator.SetFloat("jump",10f);
            animator.SetFloat("left",0f);
            animator.SetFloat("right",0f);
            animator.SetFloat("attack",0f);
            animator.SetFloat("state",0f);
            if(Mathf.Approximately(rigidbody.velocity.y,0))
            {
                rigidbody.AddForce(transform.up * jump, ForceMode2D.Impulse);
            }
            
        }

        velocity = new Vector3(Input.GetAxis("Horizontal"), 0f);
        transform.position += velocity * speed * Time.deltaTime;

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
        yatay = 1;
        
        bulletForce = 20f;
        if(Status.playerClass=="Rogue")
        {
            sword.transform.position = Rogue.transform.position + new Vector3(0.85f, -0.85f, 0);
        }
        if (Status.playerClass == "Knight")
        {
            sword.transform.position = Knight.transform.position + new Vector3(0.85f, -0.85f, 0);
        }
        if (Status.playerClass=="Wizard")
        {
            shooter.transform.position = Wizard.transform.position + new Vector3(0.85f, -0.75f, 0);
        }
        if (Status.playerClass == "Archer")
        {
            shooter.transform.position = Archer.transform.position + new Vector3(0.85f, -0.75f, 0);
        }
    }

    public void LeftMovement()
    {
        animator.SetFloat("jump",0f);
        animator.SetFloat("right",10f);
        animator.SetFloat("attack",0f);
        animator.SetFloat("state",0f);
        rotate = 180;
        RotatePlayer();
        yatay = -1;
        bulletForce = -20f;
        if(Status.playerClass=="Rogue")
        {
            sword.transform.position = Rogue.transform.position + new Vector3(-0.95f, -0.85f, 0);
        }
        if (Status.playerClass == "Knight")
        {
            sword.transform.position = Knight.transform.position + new Vector3(-0.95f, -0.85f, 0);
        }
        if (Status.playerClass == "Wizard")
        {
            shooter.transform.position = Wizard.transform.position + new Vector3(-0.95f, -0.75f, 0);
        }
        if (Status.playerClass == "Archer")
        {
            shooter.transform.position = Archer.transform.position + new Vector3(-0.95f, -0.75f, 0);
        }
    }

    public void StopMovement()
    {
        yatay = 0;
        animator.SetFloat("state",10f);
        animator.SetFloat("jump",0f);
        animator.SetFloat("left",0f);
        animator.SetFloat("right",0f);
    }

    public void Jump()
    {
        if(Mathf.Approximately(rigidbody.velocity.y,0))
        {
            rigidbody.AddForce(transform.up * jump, ForceMode2D.Impulse);
        }
        
    }
    public void Hit()
    {
        if(Status.playerClass=="Rogue" || Status.playerClass=="Knight")
        {
            if(shootTimer<=0)
            {
                animator.SetFloat("state", 0f);
                animator.SetFloat("attack", 10f);
                sword.SetActive(true);
                delay = 0.5f;
            }
            
        }
        if(Status.playerClass=="Archer")
        {
            if (shootTimer <= 0)
            {
                animator.SetFloat("state", 0f);
                animator.SetFloat("attack", 10f);
                GameObject bulletr = Instantiate(arrow, shooter.transform.position, shooter.transform.rotation);
                Rigidbody2D rgbr = bulletr.GetComponent<Rigidbody2D>();
                rgbr.AddForce(shooter.transform.right * bulletForce, ForceMode2D.Impulse);
                Destroy(bulletr, 0.2f);
                shootTimer = Status.attackSpeed;
                delay = 0.5f;
               
            }
        }
        if (Status.playerClass == "Wizard")
        {
            if (shootTimer <= 0)
            {
                animator.SetFloat("state", 0f);
                animator.SetFloat("attack", 10f);
                GameObject bulletr = Instantiate(magic, shooter.transform.position, shooter.transform.rotation);
                Rigidbody2D rgbr = bulletr.GetComponent<Rigidbody2D>();
                rgbr.AddForce(shooter.transform.right * bulletForce, ForceMode2D.Impulse);
                Destroy(bulletr, 0.2f);
                delay = 0.5f;
                shootTimer = Status.attackSpeed;
            }
        }
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
        //KeyboardControl();
        ButtonControl();
        
        shootTimer -= Time.deltaTime;
        if (Status.playerClass=="Rogue" || Status.playerClass=="Knight")
        {
            if(sword.activeInHierarchy==true)
            {
                delay -= Time.deltaTime;
                if (delay <= 0)
                {
                    sword.SetActive(false);
                    shootTimer = Status.attackSpeed;
                    animator.SetFloat("state", 10f);
                    animator.SetFloat("attack", 0f);
                }
            }
            
        }
        if(Status.playerClass=="Wizard"||Status.playerClass=="Archer")
        {
            shootTimer-=Time.deltaTime;
            delay -= Time.deltaTime;
            if (delay <= 0)
            {
                animator.SetFloat("state", 10f);
                animator.SetFloat("attack", 0f);
            }
        }
    }
}