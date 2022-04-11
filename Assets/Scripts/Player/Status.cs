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
    public GameObject GameOverCanvas;
    public Text potText;
    public Text potTextGame;
    public Text damageText;
    public Text healthText;
    public Text attackSpeedText;
    public Text classText;
    public Text mapText;
    public Image healthBar;
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
        CheckLoadGame();
        SpawnPlayer();
        playerStats();
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
            playerClass = "Archer";
            Destroy(Knight);
            Destroy(Wizard);
            Destroy(Rogue);
        }
    }

    void CheckLoadGame()
    {
        if (StartMenu.isContinue == true)
        {
            health = LoadData.loadedHealth;
            potCount = LoadData.loadedPot;
            currentMap = LoadData.loadedMap;
            playerClass = LoadData.loadedClass;
        }
        else
        {
            maxHealth = 5;
            maxPots = 3;
            health = maxHealth;
        }
    }

    void playerStats()
    {
        if (playerClass == "Rogue" || playerClass == "Knight")
        {
            damage = 4;
        }
        else if (playerClass == "Archer" || playerClass == "Wizard")
        {
            damage = 3;
        }

        attackSpeed = 1.5f;
        potCount = 0;
        currentMap = "Forest";
    }

    void CheckMap()
    {
        if (currentMap == "Forest")
        {
            map1.SetActive(true);
            map2.SetActive(false);
            map3.SetActive(false);
        }
        else if (currentMap == "IceCave")
        {
            map2.SetActive(true);
            map1.SetActive(false);
            map3.SetActive(false);
        }
        else if (currentMap == "Infernum")
        {
            map3.SetActive(true);
            map1.SetActive(false);
            map2.SetActive(false);
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
        if (potCount > maxPots)
        {
            potCount = maxPots;
        }
        else if (potCount < 0)
        {
            potCount = 0;
        }
    }

    void TakePot()
    {
        potCount++;
    }

    void HealthControl()
    {
        if(health<=0)
        {
            health = 0;
            GameOverCanvas.SetActive(true);
        }
        else if(health>=maxHealth)
        {
            health=maxHealth;
        }
        else
        {
            healthBar.fillAmount = (float)health / (float)maxHealth;
        }
    }


    void Update()
    {
        LabelUpdate();
        PotCountControl();
        HealthControl();
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="Poison")
        {
            health = 0;
        }
        if(collision.gameObject.tag=="Pot")
        {
            TakePot();
            Destroy(collision.gameObject);
        }
        if(collision.gameObject.tag=="Ice")
        {
            health -= 1;
        }
        if (collision.gameObject.tag == "IceGround")
        {
            health -= 5;
        }
    }

}