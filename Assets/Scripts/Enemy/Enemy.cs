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
    void Start()
    {
        CreateEnemy();
        enemyRb = GetComponentInParent<Rigidbody2D>();
    }

    void CreateEnemy()
    {
        if(gameObject.tag=="Goblin")
        {
            enemyType = "Goblin";
            health = 10;
        }
        else if(gameObject.tag=="PossesedGoblin")
        {
            enemyType = "PossesedGoblin";
            health = 10;
        }
        else if(gameObject.tag=="Spider")
        {
            enemyType = "Spider";
            health = 15;
        }
        else if(gameObject.tag=="SpiderRider")
        {
            enemyType = "SpiderRider";
            health = 15;
        }
        else if(gameObject.tag=="Log")
        {
            enemyType = "Log";
            health = 30;
        }
    }

    void GetDamage(int damage)
    {
        health -= damage;
    }

    void HealthControl()
    {
        if(health<=0)
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
        }
    }
}