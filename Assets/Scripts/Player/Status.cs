using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Status : MonoBehaviour
{
    public GameObject Rogue;
    public GameObject Knight;
    public GameObject Archer;
    public GameObject Wizard;
    public static string playerClass;
    public static int maxHealth;
    public static int health;
    public static int damage;
    public static int potCount;
    void Start()
    {
        SpawnPlayer();
        CheckLoadGame();
        
    }

    void SpawnPlayer()
    {
        if (playerClass == "Rogue")
        {
            Destroy(Knight);
            Destroy(Archer);
            Destroy(Wizard);
        }
        else if (playerClass == "Knight")
        {
            Destroy(Rogue);
            Destroy(Archer);
            Destroy(Wizard);
        }
        else if (playerClass == "Wizard")
        {
            Destroy(Knight);
            Destroy(Archer);
            Destroy(Rogue);
        }
        else if (playerClass == "Archer")
        {
            Destroy(Knight);
            Destroy(Rogue);
            Destroy(Wizard);
        }
        else
        {
            playerClass = "Rogue";
            Destroy(Knight);
            Destroy(Archer);
            Destroy(Wizard);
        }
    }

    void CheckLoadGame()
    {
        if (StartMenu.isContinue == true)
        {

        }
        else
        {
            maxHealth = 5;
            health = maxHealth;
            damage = 5;
            potCount = 0;
        }
    }

    
    void Update()
    {
        
    }
}
