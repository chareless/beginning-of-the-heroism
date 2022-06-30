using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public float counter = 2;
    public GameObject menuButton;
    public GameObject quitButton;
    public string deathText;
    public TextMeshProUGUI gameEndText;

    void Start()
    {
        if(Status.health<=0)
        {
            RandomMessage();
            gameEndText.text = deathText;
            gameEndText.color = Color.red;
        }
        else
        {
            gameEndText.text = "CONGRATULATIONS!";
            gameEndText.color= Color.yellow;
        }
    }

    void RandomMessage()
    {
        int random = Random.Range(0,6);
        if(random==0)
        {
            deathText = "GAME OVER";
        }
        else if(random==1)
        {
            deathText = "TRY AGAIN!";
        }
        else if(random==2)
        {
            deathText = "MAYBE ANOTHER TIME!";
        }
        else if(random==3)
        {
            deathText = "DO OR DO NOT!";
        }
        else if(random==4)
        {
            deathText = "TATAKAE!";
        }
        else if(random==5)
        {
            deathText = "DEATH IS NOT AN ESCAPE...";
        }
    }
    public void MenuButton()
    {
        SceneManager.LoadScene("StartMenu");
    }

    public void QuitButton()
    {
        Application.Quit();
    }

    void Update()
    {
        counter -= Time.deltaTime;
        if(counter<=0)
        {
            menuButton.SetActive(true);
            quitButton.SetActive(true);
        }
    }
}
