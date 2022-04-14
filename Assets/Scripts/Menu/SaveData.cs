using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveData : MonoBehaviour
{
    public static int currentHealth;
    public static int currentPot;
    public static string currentMap;
    public static string currentClass;

    static void saveHealth()
    {
        currentHealth = Status.health;
        PlayerPrefs.SetInt("Health", currentHealth);
        PlayerPrefs.Save();
    }

    static void savePot()
    {
        currentPot = Status.potCount;
        PlayerPrefs.SetInt("Pot", currentPot);
        PlayerPrefs.Save();
    }

    static void saveMap()
    {
        currentMap = Status.currentMap;
        PlayerPrefs.SetString("Map", currentMap);
        PlayerPrefs.Save();
    }

    static void saveClass()
    {
        currentClass = Status.playerClass;
        PlayerPrefs.SetString("Class", currentClass);
        PlayerPrefs.Save();
    }
    public static void saveData()
    {
        saveHealth();
        savePot();
        saveMap();
        saveClass();
        PlayerPrefs.Save();
    }
}
