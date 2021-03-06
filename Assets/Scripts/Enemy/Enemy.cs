using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Animator animator;

    Rigidbody2D enemyRb;
    public float speed;
    public float hold;
    public float sayac = 2f;
    public int health;
    public string enemyType;
    public GameObject pot;
    public GameObject throwable;
    public GameObject attackObj;
    public GameObject trapObj;
    public GameObject Door1;
    public GameObject Door2;
    public GameObject Door3;
    public float moveSayac;
    public float attackSayac;
    public float beklemeSayac;
    public float rotate;
    Vector3 velocity;
    public float bulletForce;
    public Transform attackR;
    public Transform attackL;
    public int attackType;
    public bool shooted;
    public float shootDelay = 0.5f;
    public bool bossTypeControl;
    public float bossAttackDelay;
    void Start()
    {
        CreateEnemy();
        enemyRb = GetComponentInParent<Rigidbody2D>();
    }

    void CreateEnemy()
    {
        if(gameObject.tag=="Goblin")
        {
            health = 10;
            attackSayac = 2f;
            beklemeSayac = 1f;
            attackType =Random.Range(0,2);
            if(Status.playerClass=="Wizard"|| Status.playerClass=="Archer")
            {
                attackType = 1;
            }
        }
        else if(gameObject.tag=="PossesedGoblin")
        {
            health = 10;
            attackSayac = 2f;
            beklemeSayac =1f;
            attackType = Random.Range(0, 2);
            if (Status.playerClass == "Wizard" || Status.playerClass == "Archer")
            {
                attackType = 1;
            }
        }
        else if(gameObject.tag=="Spider")
        {
            health = 20;
            attackSayac = 3f;
            beklemeSayac = 1f;
            attackType = 0;
        }
        else if(gameObject.tag=="SpiderRider")
        {
            health = 20;
            attackSayac = 3f;
            beklemeSayac = 1f;
            attackType = 0;
        }
        else if(gameObject.tag=="Log")
        {
            health = 30;
            speed = -1;
            hold = 1;
            moveSayac = 12f;
            attackSayac = 3f;
            beklemeSayac = 1f;
}
        else if(gameObject.tag=="ForestBoss")
        {
            health = 150;
            attackSayac = 3f;
            beklemeSayac = 1f;
        }
        else if(gameObject.tag=="Kobold")
        {
            health = 10;
            attackSayac = 2f;
            beklemeSayac = 1f;
            attackType = Random.Range(0, 2);
            if (Status.playerClass == "Wizard" || Status.playerClass == "Archer")
            {
                attackType = 1;
            }
        }
        else if(gameObject.tag=="Warg")
        {
            health = 20;
            attackSayac = 3f;
            beklemeSayac = 1f;
            attackType = 0;
        }
        else if(gameObject.tag=="WargRider")
        {
            health = 20;
            attackSayac = 3f;
            beklemeSayac = 1f;
            attackType = 0;
        }
        else if(gameObject.tag=="IceGolem")
        {
            health = 40;
            attackSayac = 4f;
            beklemeSayac = 1f;
            attackType = Random.Range(0, 2);
            if (Status.playerClass == "Wizard" || Status.playerClass == "Archer")
            {
                attackType = 1;
            }
        }
        else if(gameObject.tag=="IceSlime")
        {
            health = 25;
            attackSayac = 2f;
        }
        else if(gameObject.tag=="Soul")
        {
            health = 3;
            attackSayac = 2f;
        }
        else if(gameObject.tag=="FireSlime")
        {
            health = 25;
            attackSayac = 2f;
        }
        else if(gameObject.tag=="Eye")
        {
            health = 100;
            attackSayac = 2f;
        }
        else if(gameObject.tag=="Imp")
        {
            health = 20;
            attackSayac = 2f;
            beklemeSayac = 1f;
            attackType = Random.Range(0, 2);
            if (Status.playerClass == "Wizard" || Status.playerClass == "Archer")
            {
                attackType = 1;
            }
        }
        else if(gameObject.tag=="IceBoss")
        {
            health = 150;
            attackSayac = 3f;
            beklemeSayac = 1f;
        }
        else if(gameObject.tag=="FireBoss")
        {
            health = 150;
            attackSayac = 3f;
            beklemeSayac=1f;
        }


        enemyType = gameObject.tag;
    }


    void GetDamage(int damage)
    {
        health -= damage;
    }

    void HealthControl()
    {
        if (gameObject.tag == "ForestBoss" && health <= 0)
        {
            pot.SetActive(true);
            Rigidbody2D rgbr = pot.GetComponent<Rigidbody2D>();
            rgbr.AddForce(transform.up * 3f, ForceMode2D.Impulse);
            Destroy(gameObject);
            Door1.SetActive(true);
        }
        else if (gameObject.tag == "IceBoss" && health <= 0)
        {
            pot.SetActive(true);
            Rigidbody2D rgbr = pot.GetComponent<Rigidbody2D>();
            rgbr.AddForce(transform.up * 3f, ForceMode2D.Impulse);
            Destroy(gameObject);
            Door2.SetActive(true);
        }
        else if (gameObject.tag == "FireBoss" && health <= 0)
        {
            Destroy(gameObject);
            Door3.SetActive(true);
        }
        else if (health<=0)
        {
            Destroy(gameObject);
        }
    }
    
    void Attack()
    {
        if(gameObject.tag=="Log")
        {
            moveSayac -= Time.deltaTime;
            if(moveSayac<=0)
            {
                rotate += 180;
                if(rotate==360)
                {
                    rotate = 0;
                }
                speed *= -1;
                moveSayac = 12f;
                transform.rotation = Quaternion.Euler(0, rotate, 0);
            }
            attackSayac -= Time.deltaTime;
            if(attackSayac<=0)
            {
                hold = 0;
                beklemeSayac -= Time.deltaTime;
                if(beklemeSayac<=0)
                {
                    GameObject bulletr = Instantiate(throwable, attackR.transform.position, throwable.transform.rotation);
                    GameObject bulletl = Instantiate(throwable, attackL.transform.position, throwable.transform.rotation);
                    Rigidbody2D rgbr = bulletr.GetComponentInChildren<Rigidbody2D>();
                    Rigidbody2D rgbl = bulletl.GetComponentInChildren<Rigidbody2D>();
                    rgbr.AddForce(attackR.transform.right * bulletForce, ForceMode2D.Impulse);
                    rgbl.AddForce(attackL.transform.right * -bulletForce, ForceMode2D.Impulse);
                    Destroy(bulletr, 0.2f);
                    Destroy(bulletl, 0.2f);
                    hold = 1;
                    attackSayac = 3f;
                    beklemeSayac = 1f;
                }
            }
        }
        else if(gameObject.tag=="Eye" || gameObject.tag=="Soul")
        {
            attackSayac -= Time.deltaTime;
            if (attackSayac <= 0)
            {
                GameObject bulletr = Instantiate(throwable, attackR.transform.position, throwable.transform.rotation);
                Rigidbody2D rgbr = bulletr.GetComponentInChildren<Rigidbody2D>();
                rgbr.AddForce(attackR.transform.right * -bulletForce, ForceMode2D.Impulse);
                if(gameObject.tag=="Eye")
                {
                    Destroy(bulletr, 0.2f);
                    attackSayac = 2f;
                }
                else if(gameObject.tag=="Soul")
                {
                    Destroy(bulletr, 0.5f);
                    attackSayac = 2f;
                }
            }
        }
        else if(gameObject.tag=="IceSlime" || gameObject.tag=="FireSlime")
        {
            attackSayac -= Time.deltaTime;
            if (attackSayac <= 0)
            {
                animator.SetFloat("attackDeger", 10.0f);
                animator.SetFloat("state",0.0f);
                GameObject bulletr = Instantiate(throwable, attackR.transform.position, throwable.transform.rotation);
                GameObject bulletl = Instantiate(throwable, attackL.transform.position, throwable.transform.rotation);
                Rigidbody2D rgbr = bulletr.GetComponentInChildren<Rigidbody2D>();
                Rigidbody2D rgbl = bulletl.GetComponentInChildren<Rigidbody2D>();
                rgbr.AddForce(attackR.transform.right * bulletForce, ForceMode2D.Impulse);
                rgbl.AddForce(attackL.transform.right * -bulletForce, ForceMode2D.Impulse);
                Destroy(bulletr, 0.4f);
                Destroy(bulletl, 0.4f);
                attackSayac = 2f;
            }
            beklemeSayac -= Time.deltaTime;
                        if (beklemeSayac <= 0)
                        {
                animator.SetFloat("attackDeger", 0.0f);
                animator.SetFloat("state",10.0f);
                beklemeSayac = 1f;
                        }
        }
        else if(gameObject.tag == "Goblin" || gameObject.tag == "PossesedGoblin" || gameObject.tag== "Kobold" || gameObject.tag == "IceGolem" ||
                gameObject.tag == "Spider" || gameObject.tag == "SpiderRider" || gameObject.tag == "Warg" || gameObject.tag == "WargRider" || gameObject.tag=="Imp")
        {
            attackSayac -= Time.deltaTime;
            if(attackSayac<=0)
            {
                if (attackType == 0)
                {
                    animator.SetFloat("attackDeger", 10.0f);
                    animator.SetFloat("state",0.0f);
                    attackObj.SetActive(true);
                   
                    if (attackObj.activeInHierarchy == true)
                    {
                        beklemeSayac -= Time.deltaTime;
                        if (beklemeSayac <= 0)
                        {
                            attackObj.SetActive(false);
                            animator.SetFloat("attackDeger", 0.0f);
                            animator.SetFloat("state", 10.0f);
                            beklemeSayac = 1f;
                            if (gameObject.tag == "Spider" || gameObject.tag == "SpiderRider" || gameObject.tag == "Warg" || gameObject.tag == "WargRider")
                            {
                                attackSayac = 3f;
                            }
                            else if (gameObject.tag == "Goblin" || gameObject.tag == "PossesedGoblin" || gameObject.tag == "Kobold" || gameObject.tag=="Imp")
                            {
                                attackSayac = 2f;
                            }
                            else if(gameObject.tag=="IceGolem")
                            {
                                attackSayac = 4f;
                            }
                        }
                    }
                }
                else if (attackType == 1)
                {
                    shooted = true;
                    animator.SetFloat("attackDegerUzak", 10.0f);
                    animator.SetFloat("state",0.0f);
                    shootDelay-=Time.deltaTime;
                    if(shootDelay<=0)
                    {
                        GameObject bullet = Instantiate(throwable, attackR.transform.position, throwable.transform.rotation);
                        Rigidbody2D rgb = bullet.GetComponentInChildren<Rigidbody2D>();
                        rgb.AddForce(attackR.transform.right * bulletForce, ForceMode2D.Impulse);
                        shootDelay = 0.5f;
                        if (gameObject.tag == "IceGolem")
                        {
                            Destroy(bullet, 1f);
                            attackSayac = 4f;
                        }
                        else
                        {
                            Destroy(bullet, 0.25f);
                            attackSayac = 2f;
                        }
                    }
                }
            }
        }
        else if(gameObject.tag=="ForestBoss")
        {
            attackSayac-=Time.deltaTime;
            if(attackSayac<=0)
            {
                if(bossTypeControl==false)
                {
                    attackType = Random.Range(0, 2);
                    bossTypeControl = true;
                    if (attackType == 0)
                    {
                        animator.SetFloat("attackDeger", 10.0f);
                        animator.SetFloat("state", 0.0f);
                    }
                    else if (attackType == 1)
                    {
                        animator.SetFloat("attackDegerUzak", 10.0f);
                        animator.SetFloat("state", 0.0f);
                    }
                }

                beklemeSayac -= Time.deltaTime;

                if(beklemeSayac<=0)
                {
                    if(attackType==0)
                    {
                        attackObj.SetActive(true);

                        if (attackObj.activeInHierarchy == true)
                        {
                            bossAttackDelay -= Time.deltaTime;
                            if (bossAttackDelay <= 0)
                            {
                                attackObj.SetActive(false);
                                bossAttackDelay = 0.3f;
                                animator.SetFloat("attackDeger", 0.0f);
                                animator.SetFloat("state", 10.0f);
                                attackSayac = 3f;
                                beklemeSayac = 1f;
                                bossTypeControl = false;
                            }
                        }
                    }
                    else if(attackType==1)
                    {
                        GameObject bullet = Instantiate(throwable, attackR.transform.position, throwable.transform.rotation);
                        Rigidbody2D rgb = bullet.GetComponentInChildren<Rigidbody2D>();
                        rgb.AddForce(attackR.transform.right * bulletForce, ForceMode2D.Impulse);
                        Destroy(bullet, 0.5f);
                        animator.SetFloat("attackDegerUzak", 0.0f);
                        animator.SetFloat("state", 10.0f);
                        attackSayac = 3f;
                        beklemeSayac = 1f;
                        bossTypeControl = false;
                    }


                    
                }
            }
        }
        else if(gameObject.tag=="IceBoss")
        {
            attackSayac -= Time.deltaTime;
            if (attackSayac <= 0)
            {
                if (bossTypeControl == false)
                {
                    attackType = Random.Range(0, 2);
                    bossTypeControl = true;
                    if (attackType == 0)
                    {
                        animator.SetFloat("attackDeger", 10.0f);
                        animator.SetFloat("state", 0.0f);
                    }
                    else if (attackType == 1)
                    {
                        animator.SetFloat("attackDegerUzak", 10.0f);
                        animator.SetFloat("state", 0.0f);
                    }
                }

                beklemeSayac -= Time.deltaTime;

                if (beklemeSayac <= 0)
                {
                    if (attackType == 0)
                    {
                        attackObj.SetActive(true);

                        if (attackObj.activeInHierarchy == true)
                        {
                            bossAttackDelay -= Time.deltaTime;
                            if (bossAttackDelay <= 0)
                            {
                                attackObj.SetActive(false);
                                bossAttackDelay = 0.5f;
                                animator.SetFloat("attackDeger", 0.0f);
                                animator.SetFloat("state", 10.0f);
                                attackSayac = 3f;
                                beklemeSayac = 1f;
                                bossTypeControl = false;
                            }
                        }
                    }
                    else if (attackType == 1)
                    {
                        trapObj.SetActive(true);

                        if (trapObj.activeInHierarchy == true)
                        {
                            bossAttackDelay -= Time.deltaTime;
                            if (bossAttackDelay <= 0)
                            {
                                trapObj.SetActive(false);
                                bossAttackDelay = 0.5f;
                                animator.SetFloat("attackDegerUzak", 0.0f);
                                animator.SetFloat("state", 10.0f);
                                attackSayac = 3f;
                                beklemeSayac = 1f;
                                bossTypeControl = false;
                            }
                        }
                    }
                }
            }
        }
        else if(gameObject.tag=="FireBoss")
        {
            attackSayac -= Time.deltaTime;
            if (attackSayac <= 0)
            {
                    animator.SetFloat("attackDeger", 10.0f);
                    animator.SetFloat("state", 0.0f);

                beklemeSayac -= Time.deltaTime;

                if (beklemeSayac <= 0)
                {
                    GameObject bullet = Instantiate(throwable, attackR.transform.position, throwable.transform.rotation);
                    Rigidbody2D rgb = bullet.GetComponentInChildren<Rigidbody2D>();
                    rgb.AddForce(attackR.transform.right * bulletForce, ForceMode2D.Impulse);
                    Destroy(bullet, 1f);
                    animator.SetFloat("attackDeger", 0.0f);
                    animator.SetFloat("state", 10.0f);
                    attackSayac = 3f;
                    beklemeSayac = 1f;
                }
            }
        }
    }

    void RangeAnimDelayControl()
    {
        if (shooted == true)
        {
            beklemeSayac -= Time.deltaTime;
            if (beklemeSayac <= 0)
            {
                animator.SetFloat("attackDegerUzak", 0.0f);
                animator.SetFloat("state", 10.0f);
                beklemeSayac = 1f;
                shooted = false;
            }
        }
    }
    void Move()
    {
        transform.position += new Vector3(speed, 0)*Time.deltaTime*hold;
    }
    void Update()
    {
        HealthControl();
        Move();
        Attack();
        RangeAnimDelayControl();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="Sword")
        {
            GetDamage(Status.damage);
        }

        if(collision.gameObject.tag=="Bullet")
        {
            GetDamage(Status.damage);
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "RogueSkill")
        {
            GetDamage(Status.skillDamage);
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "WizardSkill")
        {
            GetDamage(Status.skillDamage);
        }

        if (collision.gameObject.tag == "ArcherSkill")
        {
            GetDamage(Status.skillDamage);
        }

        if (collision.gameObject.tag == "KnightSkill")
        {
            GetDamage(Status.skillDamage);
        }

    }
}