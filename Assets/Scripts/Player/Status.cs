using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class Status : MonoBehaviour
{
    public GameObject Rogue;
    public GameObject Knight;
    public GameObject Archer;
    public GameObject Wizard;
    public GameObject map1;
    public GameObject map2;
    public GameObject map3;
    public Text potText;
    public Text potTextGame;
    public Text damageText;
    public Text healthText;
    public Text attackSpeedText;
    public Text classText;
    public Text mapText;
    public static string playerClass;
    public static string currentMap;
    public static int maxHealth;
    public static int maxPots;
    public static int health;
    public static int damage;
    public static int potCount;
    public static float attackSpeed;
    void Start()
    {
        SpawnPlayer();
        CheckLoadGame();
        CheckMap();
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
            maxHealth = 10;
            maxPots = 3;
            health = maxHealth;
            damage = 5;
            attackSpeed = 1.5f;
            potCount = 0;
            currentMap = "Forest";
        }
    }

    void CheckMap()
    {
        if(currentMap == "Forest")
        {
            map1.SetActive(true);
        }
        else if(currentMap == "Frozen")
        {
            map2.SetActive(true);
        }
        else if(currentMap =="Dungeon")
        {
            map3.SetActive(true);
        }
    }

    void LabelUpdate()
    {
        potText.text = potCount.ToString() + " / 3";
        potTextGame.text = potCount.ToString();
        healthText.text = health.ToString();
        damageText.text = damage.ToString();
        attackSpeedText.text = attackSpeed.ToString("N2", CultureInfo.CreateSpecificCulture("en-US"));
        classText.text = playerClass.ToString().ToUpper();
        mapText.text = currentMap.ToString().ToUpper();
    }

    public static void PotCountControl()
    {
        if(potCount>maxPots)
        {
            potCount = maxPots;
        }
        else if(potCount<0)
        {
            potCount = 0;
        }
    }

    void TakePot()
    {
        potCount++;
    }

    
    void Update()
    {
        LabelUpdate();
        PotCountControl();
    }
}
