using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadData : MonoBehaviour
{
    public static int loadedHealth;
    public static int loadedPot;
    public static string loadedMap;
    public static string loadedClass;
    public static int loadedDeath;
    public static int loadedTotalDeath;

    static void healthCheck()
    {
        if(PlayerPrefs.GetInt("Health")!= 0 )
        {
            loadedHealth = PlayerPrefs.GetInt("Health");
        }
        else
        {
            loadedHealth = 0;
        }
    }

    static void potCheck()
    {
        if(PlayerPrefs.GetInt("Pot")!=0)
        {
            loadedPot = PlayerPrefs.GetInt("Pot");
        }
        else
        {
            loadedPot= 0;
        }
    }

    static void mapCheck()
    {
        if(PlayerPrefs.GetString("Map") != "Forest")
        {
            loadedMap = PlayerPrefs.GetString("Map");
        }
        else
        {
            loadedMap = "Forest";
        }
    }

    static void classCheck()
    {
        if (PlayerPrefs.GetString("Class") != "")
        {
            loadedClass = PlayerPrefs.GetString("Class");
        }
        else
        {
            loadedClass = "Rogue";
        }
    }

    static void deathCheck()
    {
        if(PlayerPrefs.GetInt("GameDeath")!=0)
        {
            loadedDeath = PlayerPrefs.GetInt("GameDeath");
        }
        else
        {
            loadedDeath= 0;
        }
    }

    static void totalDeathCheck()
    {
        if (PlayerPrefs.GetInt("TotalDeath") != 0)
        {
            loadedTotalDeath = PlayerPrefs.GetInt("TotalDeath");
        }
        else
        {
            loadedTotalDeath = 0;
        }
    }


    public static void loadData()
    {
        healthCheck();
        potCheck();
        mapCheck();
        classCheck();
        deathCheck();
        totalDeathCheck();
    }

    public void Start()
    {
        loadData();
    }
}
