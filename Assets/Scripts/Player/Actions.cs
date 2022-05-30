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
    public GameObject skillRogue;
    public GameObject skillWizard;
    public GameObject skillArcher;
    public GameObject skillKnight;
    public static float jump;
    public static int rotate;
    public float shootTimer;
    public float delay = 0.5f;
    public static float bulletForce=20f;
    Rigidbody2D rigidbody;
    public static float speed = 6f;
    public static float speedKey = 6f;
    public static float yatay;
    Vector3 velocity;

    public AudioClip magicSound;
    public AudioClip archerSound;
    public AudioClip rogueSound;

    public AudioClip knightSound;
    public AudioClip magicSkillSound;
    public AudioClip archerSkillSound;
    public AudioClip rogueSkillSound;
    public AudioClip knightSkillSound;

    public AudioClip jumpSound;

    public AudioClip walkSound;
    AudioSource sourceAudio;

    
    void Start()
    {
        Application.targetFrameRate = StartMenu.maxFPS;
        rigidbody = GetComponent<Rigidbody2D>();
        sourceAudio = gameObject.GetComponent<AudioSource>();
    }

    void ButtonControl()
    {
        transform.position += new Vector3(speed*yatay, jump, 0) * Time.deltaTime;
    }
    void KeyboardControl()
    {
        if (Input.GetKeyDown("w"))
        {
            if (Mathf.Approximately(rigidbody.velocity.y, 0))
            {
                jump = 9.5f;
                rigidbody.AddForce(transform.up * jump, ForceMode2D.Impulse);
                jump = 0;
            }
        }

        velocity = new Vector3(Input.GetAxis("Horizontal"), 0f);
        transform.position += velocity * speedKey * Time.deltaTime;

        if (Input.GetKey("h"))
        {
            Hit();
        }
        if (Input.GetKey("j"))
        {
            UsePot();
        }
        if(Input.GetKey("k"))
        {
            UseSkill();
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
            sword.transform.rotation= Quaternion.Euler(0, rotate, 0);
            shooter.transform.rotation = Quaternion.Euler(rotate, 0, rotate);
        }
        else if (Status.playerClass == "Wizard")
        {
            Wizard.transform.rotation = Quaternion.Euler(0, rotate, 0);
            shooter.transform.rotation = Quaternion.Euler(rotate, 0, rotate);
        }
        else if (Status.playerClass == "Archer")
        {
            Archer.transform.rotation = Quaternion.Euler(0, rotate, 0);
            shooter.transform.rotation = Quaternion.Euler(rotate, 0, rotate);
        }
        else if (Status.playerClass == "Knight")
        {
            Knight.transform.rotation = Quaternion.Euler(0, rotate, 0);
            sword.transform.rotation = Quaternion.Euler(0, rotate, 0);
            shooter.transform.rotation = Quaternion.Euler(rotate, 0, rotate);
        }
    }
    public void RightMovement()
    {
        sourceAudio.Play();
        animator.SetFloat("left", 0f);
        animator.SetFloat("right", 10f);
        animator.SetFloat("attack", 0f);
        animator.SetFloat("state", 0f);
        animator.SetFloat("skill",0f);
        rotate = 0;
        RotatePlayer();
        yatay = 1;
        if (Status.playerClass == "Rogue")
        {
            sword.transform.position = Rogue.transform.position + new Vector3(0.85f, -0.85f, 0);
            shooter.transform.position = Rogue.transform.position + new Vector3(0.95f, -0.75f, 0);
        }
        if (Status.playerClass == "Knight")
        {
            sword.transform.position = Knight.transform.position + new Vector3(0.85f, -0.85f, 0);
            shooter.transform.position = Rogue.transform.position + new Vector3(0.95f, -0.75f, 0);
        }
        if (Status.playerClass == "Wizard")
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
        sourceAudio.Play();
        animator.SetFloat("right", 10f);
        animator.SetFloat("attack", 0f);
        animator.SetFloat("state", 0f);
        animator.SetFloat("skill",0f);
        rotate = 180;
        RotatePlayer();
        yatay = -1;
        if (Status.playerClass == "Rogue")
        {
            sword.transform.position = Rogue.transform.position + new Vector3(-0.95f, -0.85f, 0);
            shooter.transform.position = Rogue.transform.position + new Vector3(-0.95f, -0.75f, 0);
        }
        if (Status.playerClass == "Knight")
        {
            sword.transform.position = Knight.transform.position + new Vector3(-0.95f, -0.85f, 0);
            shooter.transform.position = Rogue.transform.position + new Vector3(-0.95f, -0.75f, 0);
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
        sourceAudio.Stop();
        yatay = 0;
        animator.SetFloat("state", 10f);
        animator.SetFloat("left", 0f);
        animator.SetFloat("right", 0f);
        animator.SetFloat("skill",0f);
    }

    public void Jump()
    {
        if (Mathf.Approximately(rigidbody.velocity.y, 0) || Status.jumpable==true)
        {
            sourceAudio.PlayOneShot(jumpSound);
            jump = 31f;
            rigidbody.AddForce(transform.up * jump, ForceMode2D.Impulse);
            jump = 0f;
        }
    }
    public void Hit()
    {
        if (Status.playerClass == "Rogue" || Status.playerClass == "Knight")
        {
            if (shootTimer <= 0 && sword.activeInHierarchy==false)
            {
                if(Status.playerClass == "Rogue")
                {
                    sourceAudio.PlayOneShot(rogueSound);
                }
                if(Status.playerClass == "Knight")
                {
                    sourceAudio.PlayOneShot(knightSound);
                }
                animator.SetFloat("state", 0f);
                animator.SetFloat("attack", 10f);
                animator.SetFloat("skill", 0f);
                sword.SetActive(true);
                delay = 0.5f;
            }
        }
        if (Status.playerClass == "Archer")
        {
            if (shootTimer <= 0)
            {
                sourceAudio.PlayOneShot(archerSound);
                animator.SetFloat("state", 0f);
                animator.SetFloat("attack", 10f);
                animator.SetFloat("skill",0f);
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
                sourceAudio.PlayOneShot(magicSound);
                animator.SetFloat("state", 0f);
                animator.SetFloat("attack", 10f);
                animator.SetFloat("skill",0f);
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
        if (Status.potCount > 0 && Status.health!=Status.maxHealth)
        {
            Status.potCount--;
            Status.health = Status.maxHealth;
        }
    }

    public void UseSkill()
    {
        if (Status.skillTimer<=0)
        {
            delay = 0.5f;
            animator.SetFloat("skill",10f);  
           
            if(Status.playerClass=="Rogue")
            {
                sourceAudio.PlayOneShot(rogueSkillSound);
                GameObject bulletr = Instantiate(skillRogue, shooter.transform.position, shooter.transform.rotation);
                Rigidbody2D rgbr = bulletr.GetComponent<Rigidbody2D>();
                rgbr.AddForce(shooter.transform.right * bulletForce, ForceMode2D.Impulse);
                Destroy(bulletr, 2f);
            }
            else if(Status.playerClass=="Wizard")
            {
                sourceAudio.PlayOneShot(magicSkillSound);
                GameObject bulletr = Instantiate(skillWizard, shooter.transform.position, shooter.transform.rotation);
                Rigidbody2D rgbr = bulletr.GetComponent<Rigidbody2D>();
                rgbr.AddForce(shooter.transform.right * bulletForce*500, ForceMode2D.Impulse);
                Destroy(bulletr, 2f);
            }
            else if(Status.playerClass=="Archer")
            {
                sourceAudio.PlayOneShot(archerSkillSound);
                GameObject bulletr = Instantiate(skillArcher, shooter.transform.position, shooter.transform.rotation);
                Rigidbody2D rgbr = bulletr.GetComponent<Rigidbody2D>();
                rgbr.AddForce(shooter.transform.right * bulletForce*500, ForceMode2D.Impulse);
                Destroy(bulletr, 2f);
            }
            else if(Status.playerClass=="Knight")
            {
                sourceAudio.PlayOneShot(knightSkillSound);
                GameObject bulletr = Instantiate(skillKnight, shooter.transform.position, shooter.transform.rotation);
                Rigidbody2D rgbr = bulletr.GetComponent<Rigidbody2D>();
                rgbr.AddForce(shooter.transform.right * bulletForce * 500, ForceMode2D.Impulse);
                Destroy(bulletr, 2f);
            }
            Status.skillTimer = Status.skillCD;
            Status.skillUsed = true;
        }
    }


    void Update()
    {
        GetAnimator();
        //KeyboardControl();
        ButtonControl();

        shootTimer -= Time.deltaTime;
        if (Status.playerClass == "Rogue" || Status.playerClass == "Knight")
        {
            if (sword.activeInHierarchy == true)
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
        if (Status.playerClass == "Wizard" || Status.playerClass == "Archer")
        {
            shootTimer -= Time.deltaTime;
            delay -= Time.deltaTime;
            if (delay <= 0)
            {
                animator.SetFloat("state", 10f);
                animator.SetFloat("attack", 0f);
                animator.SetFloat("skill", 0f);
            }
        }
    }
}