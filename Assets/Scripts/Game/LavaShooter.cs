using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaShooter : MonoBehaviour
{
    public GameObject fireball;
    public Transform[] downShootPoint;
    public Transform[] upShootPoint;
    public static float bulletForce = 17f;
    public int fireType;
    public float timer;
    public float mainTimer;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            if(fireType==1)
            {
                for (int i = 0; i < downShootPoint.Length; i++)
                {
                    GameObject lava = Instantiate(fireball, downShootPoint[i].transform);
                    Rigidbody2D rgbr = lava.GetComponent<Rigidbody2D>();
                    rgbr.AddForce(downShootPoint[i].up * bulletForce, ForceMode2D.Impulse);
                    Destroy(lava, 4f);
                    timer = mainTimer;
                }
            }
            else if(fireType==2)
            {
                int random= Random.Range(0, upShootPoint.Length);
                GameObject lava = Instantiate(fireball, upShootPoint[random].transform);
                Rigidbody2D rgbr = lava.GetComponent<Rigidbody2D>();
                rgbr.AddForce(upShootPoint[random].up * bulletForce, ForceMode2D.Impulse);
                Destroy(lava, 1.25f);
                timer = mainTimer;
            }
        }
    }
}
