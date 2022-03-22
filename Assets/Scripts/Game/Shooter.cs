using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public GameObject ice;
    public Transform shootPoint;
    public static float bulletForce = 10000f;
    public float sayac = 2;

    void Update()
    {
        sayac -= Time.deltaTime;
        if(sayac<=0)
        {
            GameObject bullet = Instantiate(ice, shootPoint.transform);
            Rigidbody2D rgbr = bullet.GetComponentInChildren<Rigidbody2D>();
            rgbr.AddForce(shootPoint.right * bulletForce, ForceMode2D.Impulse);
            Destroy(bullet, 2f);
            sayac = 2;
        }
        
    }
}
