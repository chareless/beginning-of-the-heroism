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
    public GameObject CDCanvas;
    public Button skillButton;
    public Text potText;
    public Text potTextGame;
    public Text damageText;
    public Text healthText;
    public Text attackSpeedText;
    public Text classText;
    public Text mapText;
    public Text cdText;
    public GameObject[] healthBars;
    public static string playerClass;
    public static string currentMap;
    public static int maxHealth;
    public static int maxPots;
    public static int health;
    public static int damage;
    public static int skillDamage;
    public static float skillCD;
    public static float skillTimer;
    public static int potCount;
    public static float attackSpeed;
    public static bool jumpable;
    public static bool skillUsed;

    public AudioClip knifeHit;
    public AudioClip spearHit;

    public AudioClip byteHit;

    public AudioClip rockHit;
    public AudioClip iceHit;
    public AudioClip thornHit;
    public AudioClip gate;

    public AudioClip poison;
    public AudioClip pot;

    public AudioClip lava;
    public AudioClip fireBall;
    public AudioClip saw;
    public AudioClip laserSound;
    public AudioClip enemyFire;
    public AudioClip soulShot;
    public AudioClip boss1Lazer;
    public AudioClip boss2Trap;



    public Animator animator;

    AudioSource sourceAudio;
    void Start()
    {
        CheckLoadGame();
        SpawnPlayer();
        playerStats();
        CheckMap();
        SaveData.saveData();
        sourceAudio = gameObject.GetComponent<AudioSource>();
        Application.targetFrameRate = 60;
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
     void GetAnimator()
    {
        animator = GetComponentInChildren<Animator>();
    }

    void CheckLoadGame()
    {
        maxHealth = 5;
        maxPots = 3;
        if (StartMenu.isContinue == true)
        {
            health = LoadData.loadedHealth;
            potCount = LoadData.loadedPot;
            currentMap = LoadData.loadedMap;
            playerClass = LoadData.loadedClass;

            if(currentMap=="Forest")
            {
                gameObject.transform.position = new Vector3(-8, -2, 0);
            }
            else if(currentMap=="IceCave")
            {
                gameObject.transform.position= new Vector3(205,-1,0); 
            }
            else if(currentMap=="Infernum")
            {
                gameObject.transform.position = new Vector3(470, -30, 0);
            }
        }
        else
        {
            potCount = 0;
            health = maxHealth;

            currentMap = "Forest";
            gameObject.transform.position = new Vector3(-8, -2, 0);

            //currentMap = "IceCave";
            //gameObject.transform.position = new Vector3(205, -1, 0);

            //currentMap = "Infernum";
            //gameObject.transform.position = new Vector3(470, -30, 0);
        }

    }

    void playerStats()
    {
        if(playerClass=="Rogue")
        {
            damage = 5;
            skillDamage = 5;
            skillCD = 3;
        }
        else if(playerClass=="Knight")
        {
            damage = 10;
            skillDamage = 40;
            skillCD = 5;
        }
        else if (playerClass == "Archer" || playerClass == "Wizard")
        {
            damage = 5;
            skillDamage = 40;
            skillCD = 25;
        }
        attackSpeed = 1.5f;
        skillTimer = 0;
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
        sourceAudio.PlayOneShot(pot);
    }

    void HealthControl()
    {
        if(health<=0)
        {
            animator.SetFloat("die",10.0f);
            health = 0;
            GameOverCanvas.SetActive(true);
        }
        else if(health>=maxHealth)
        {
            health=maxHealth;
        }

        for(int i=0;i<maxHealth;i++)
        {
            if(i<health)
            {
                healthBars[i].SetActive(true);
            }
            else
            {
                healthBars[i].SetActive(false);
            }
        }
    }

    public void SkillCDCount()
    {
        if (skillUsed == true)
        {
            skillTimer -= Time.deltaTime;
            if (skillTimer <= 0)
            {
                cdText.text = "";
                skillButton.interactable = true;
                skillUsed = false;
                CDCanvas.SetActive(false);
            }
            else
            {
                CDCanvas.SetActive(true);
                cdText.text = skillTimer.ToString("N0", CultureInfo.CreateSpecificCulture("en-US")); ;
                skillButton.interactable = false;
            }
        }
    }

    void Update()
    {
        GetAnimator();
        LabelUpdate();
        PotCountControl();
        HealthControl();
        CheckMap();
        SkillCDCount();
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="Platform")
        {
            jumpable= false;
            transform.parent= null;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="Platform")
        {
            jumpable = true;
            transform.parent = collision.transform;
        }
        if (collision.gameObject.tag=="Poison")
        {
            sourceAudio.PlayOneShot(poison);
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
            sourceAudio.PlayOneShot(iceHit);
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "IceGround")
        {
            health = 0;
            sourceAudio.PlayOneShot(iceHit);
        }
        if(collision.gameObject.tag=="IceSlime")
        {
            sourceAudio.PlayOneShot(iceHit);
            health -= 1;
        }
        if (collision.gameObject.tag=="EnemyKnife")
        {
            sourceAudio.PlayOneShot(knifeHit);
            health -= 1;
            Destroy(collision.gameObject);

        }
        if (collision.gameObject.tag == "EnemySpear")
        {
            sourceAudio.PlayOneShot(spearHit);
            health -= 1;
        }
        if (collision.gameObject.tag == "EnemyBite")
        {
            sourceAudio.PlayOneShot(byteHit);
            health -= 2;
        }
        if (collision.gameObject.tag == "EnemyRock")
        {
            sourceAudio.PlayOneShot(rockHit);
            health -= 2;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "EnemyThorn")
        {
            sourceAudio.PlayOneShot(thornHit);
            health -= 1;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "EnemyIce")
        {
            sourceAudio.PlayOneShot(iceHit);
            health -= 1;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "Gate1")
        {
            sourceAudio.PlayOneShot(gate);
            currentMap = "IceCave";
            SaveData.saveData();
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "Gate2")
        {
            sourceAudio.PlayOneShot(gate);
            currentMap = "Infernum";
            SaveData.saveData();
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "Gate3")
        {
            sourceAudio.PlayOneShot(gate);
            PlayerPrefs.SetInt("GameEnd", 1);
            PlayerPrefs.SetInt("ThisGameEnd", 1);
            PlayerPrefs.Save();
            GameOverCanvas.SetActive(true);
        }
        if(collision.gameObject.tag=="Lava")
        {
            sourceAudio.PlayOneShot(lava);
            health = 0;
        }
        if(collision.gameObject.tag=="Fireball")
        {
            sourceAudio.PlayOneShot(fireBall);
            health -= 2;
            Destroy(collision.gameObject);
        }
        if(collision.gameObject.tag=="Saw")
        {
            sourceAudio.PlayOneShot(saw);
            health = 0;
        }
        if(collision.gameObject.tag=="Laser")
        {
            sourceAudio.PlayOneShot(laserSound);
            health -= 1;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "EnemyFire")
        {
            sourceAudio.PlayOneShot(enemyFire);
            health -= 1;
            Destroy(collision.gameObject);
        }
        if(collision.gameObject.tag=="FireSlime")
        {
            sourceAudio.PlayOneShot(enemyFire);
            health -= 1;
        }
        if (collision.gameObject.tag == "SoulShot")
        {
            sourceAudio.PlayOneShot(soulShot);
            health -= 1;
            Destroy(collision.gameObject);
        }
        if(collision.gameObject.tag=="Boss1Laser")
        {
            sourceAudio.PlayOneShot(boss1Lazer);
            health -= 1;
            Destroy(collision.gameObject);
        }
        if(collision.gameObject.tag=="Boss2Trap")
        {
            sourceAudio.PlayOneShot(iceHit);
            health -= 2;
        }
    }
}