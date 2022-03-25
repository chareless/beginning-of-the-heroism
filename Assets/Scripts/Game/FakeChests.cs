using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeChests : MonoBehaviour
{
    public GameObject[] chests;
    public GameObject[] pots;
    public float rand;
    void Start()
    {
        rand = Random.Range(0, 3);
        for (int i = 0; i < chests.Length; i++)
        {
            if (i != rand)
            {
                Destroy(chests[i]);
                Destroy(pots[i]);
            }
        }
    }
}
