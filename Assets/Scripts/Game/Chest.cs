using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    public int health;
    public GameObject pot;
    void Start()
    {
        health = 1;
    }

    void ChestControl()
    {
        if (health <= 0)
        {
            pot.SetActive(true);
            Rigidbody2D rgbr = pot.GetComponent<Rigidbody2D>();
            rgbr.AddForce(transform.up * 3f, ForceMode2D.Impulse);
            Destroy(gameObject);
        }
    }

    public void HitChest()
    {
        health -= 1;
    }
    void Update()
    {
        ChestControl();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="Player")
        {
            HitChest();
        }
        
    }
}
