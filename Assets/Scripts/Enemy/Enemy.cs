using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Rigidbody2D enemyRb;
    public static float speed;
    public float sayac = 2f;
    public int health;
    public string enemyType;
    public GameObject pot;
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
        }
        else if(gameObject.tag=="PossesedGoblin")
        {
            health = 10;
        }
        else if(gameObject.tag=="Spider")
        {
            health = 15;
        }
        else if(gameObject.tag=="SpiderRider")
        {
            health = 15;
        }
        else if(gameObject.tag=="Log")
        {
            health = 30;
        }
        else if(gameObject.tag=="ForestBoss")
        {
            health = 100;
        }
        else if(gameObject.tag=="Kobold")
        {
            health = 10;
        }
        else if(gameObject.tag=="Warg")
        {
            health = 15;
        }
        else if(gameObject.tag=="WargRider")
        {
            health = 15;
        }
        else if(gameObject.tag=="IceGolem")
        {
            health = 40;
        }
        else if(gameObject.tag=="IceSlime")
        {
            health = 30;
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
        }
        else if (health<=0)
        {
            Destroy(gameObject);
        }
    }
    void Update()
    {
        HealthControl();
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
    }
}
