using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaShooter : MonoBehaviour
{
    public GameObject fireball;
    public Transform[] downShootPoint;
    public Transform[] upShootPoint;
    public static float bulletForce = 17f;
    public float sayac = 3;
    public int fireType;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        sayac -= Time.deltaTime;
        if (sayac <= 0)
        {
            if(fireType==1)
            {
                for (int i = 0; i < downShootPoint.Length; i++)
                {
                    GameObject lava = Instantiate(fireball, downShootPoint[i].transform);
                    Rigidbody2D rgbr = lava.GetComponent<Rigidbody2D>();
                    rgbr.AddForce(downShootPoint[i].up * bulletForce, ForceMode2D.Impulse);
                    Destroy(lava, 4f);
                    sayac = 7;
                }
            }
            else if(fireType==2)
            {
                for (int i = 0; i < upShootPoint.Length; i++)
                {
                    GameObject lava = Instantiate(fireball, upShootPoint[i].transform);
                    Rigidbody2D rgbr = lava.GetComponent<Rigidbody2D>();
                    rgbr.AddForce(upShootPoint[i].up * bulletForce, ForceMode2D.Impulse);
                    Destroy(lava, 4f);
                    sayac = 7;
                }
            }
        }
    }
}
