using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillColliders : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="Fireball" || collision.gameObject.tag=="Ice" || collision.gameObject.tag=="EnemyKnife" || collision.gameObject.tag=="Laser" ||
            collision.gameObject.tag=="EnemyThorn" || collision.gameObject.tag=="EnemyRock" || collision.gameObject.tag=="EnemyFire" || collision.gameObject.tag=="EnemyIce" ||
            collision.gameObject.tag=="SoulShot")
        {
            Destroy(collision.gameObject);
        }
    }
}
