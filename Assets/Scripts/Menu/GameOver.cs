using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public float counter = 2;
    public GameObject menuButton;
    public GameObject quitButton;
    public Text gameEndText;

    void Start()
    {
        if(Status.health<=0)
        {
            gameEndText.text = "GAME OVER";
            gameEndText.color = Color.red;
        }
        else
        {
            gameEndText.text = "CONGRATULATIONS";
            gameEndText.color= Color.yellow;
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
