using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour
{
    public GameObject StartMenuCanvas;
    public GameObject EndText;
    public GameObject OptionsCanvas;
    public GameObject CreditsCanvas;
    public GameObject SelectCharacterCanvas;
    public GameObject ButtonContinue;
    public GameObject GameEndCanvas;
    public Button SelectRogue;
    public Button SelectWizard;
    public Button SelectArcher;
    public Button SelectKnight;
    public Button continueButton;
    public Text gameVersion;
    public Text volumeText;
    public Slider volumeSlider;
    public AudioSource ClickSound;
    public AudioClip nextClick;
    public AudioClip backClick;
    public static float volumeValue;
    public static bool isContinue;
    public AudioSource anaMenu;

    public void Start()
    {
        LoadValues();
        ThisGameEndControl();
        gameVersion.text = Application.version;
        Application.targetFrameRate = 60;
    }

    public void PlayNextClick()
    {
        ClickSound.PlayOneShot(nextClick);
    }

    public void PlayBackClick()
    {
        ClickSound.PlayOneShot(backClick);
    }
    public void NewGameButton()
    {
        SelectCharacterCanvas.SetActive(true);
        StartMenuCanvas.SetActive(false);
        PlayNextClick();
        isContinue = false;
        anaMenu.Stop();
    }

    public void RogueButton()
    {
        Status.playerClass = "Rogue";
        Status.currentMap = "Forest";
        SelectWizard.interactable = false;
        SelectArcher.interactable = false;
        SelectKnight.interactable = false;
        PlayerPrefs.SetInt("GameDeath", 0);
        PlayerPrefs.Save();
        PlayNextClick();
        SceneManager.LoadScene("SampleScene");
    }

    public void WizardButton()
    {
        Status.playerClass = "Wizard";
        Status.currentMap = "Forest";
        SelectRogue.interactable = false;
        SelectArcher.interactable = false;
        SelectKnight.interactable = false;
        PlayerPrefs.SetInt("GameDeath", 0);
        PlayerPrefs.Save();
        PlayNextClick();
        SceneManager.LoadScene("SampleScene");
    }

    public void ArcherButton()
    {
        Status.playerClass = "Archer";
        Status.currentMap = "Forest";
        SelectRogue.interactable = false;
        SelectWizard.interactable = false;
        SelectKnight.interactable = false;
        PlayerPrefs.SetInt("GameDeath", 0);
        PlayerPrefs.Save();
        PlayNextClick();
        SceneManager.LoadScene("SampleScene");
    }

    public void KnightButton()
    {
        Status.playerClass = "Knight";
        Status.currentMap = "Forest";
        SelectRogue.interactable = false;
        SelectWizard.interactable = false;
        SelectArcher.interactable = false;
        PlayerPrefs.SetInt("GameDeath", 0);
        PlayerPrefs.Save();
        PlayNextClick();
        SceneManager.LoadScene("SampleScene");
    }

    public void ContinueButton()
    {
        isContinue = true;
        PlayNextClick();
        SceneManager.LoadScene("SampleScene");
    }

    public void CreditsButton()
    {
        StartMenuCanvas.SetActive(false);
        CreditsCanvas.SetActive(true);
        EndText.transform.position = new Vector3(0, -10f, 0);
        PlayNextClick();
    }
    public void OptionsButton()
    {
        StartMenuCanvas.SetActive(false);
        OptionsCanvas.SetActive(true);
        PlayNextClick();
    }

    public void SaveButton()
    {
        volumeValue = volumeSlider.value;
        PlayerPrefs.SetFloat("VolumeValue", volumeValue);
        PlayerPrefs.Save();
        LoadValues();
        OptionsCanvas.SetActive(false);
        StartMenuCanvas.SetActive(true);
        PlayNextClick();
    }

    public void BackButton()
    {
        StartMenuCanvas.SetActive(true);
        OptionsCanvas.SetActive(false);
        CreditsCanvas.SetActive(false);
        SelectCharacterCanvas.SetActive(false);
        GameEndCanvas.SetActive(false);
        PlayBackClick();
        anaMenu.Play();
    }

    public void QuitButton()
    {
        PlayNextClick();
        Application.Quit();
    }

    public void ContinueControl()
    {
        if (LoadData.loadedMap == "")
        {
            continueButton.interactable = false;
        }
        else
        {
            continueButton.interactable = true;
        }
    }

    public void VolumeSlider(float volume)
    {
        volumeText.text = (volume * 100).ToString("F0");
    }

    public void VolumeControl()
    {
        volumeValue = PlayerPrefs.GetFloat("VolumeValue");
        volumeSlider.value = volumeValue;
        AudioListener.volume = volumeValue;
    }

    public void GameEndControl()
    {
        if(PlayerPrefs.GetInt("GameEnd")==1)
        {
            SelectKnight.interactable = true;
        }
        else
        {
            SelectKnight.interactable = false;
        }
        
    }

    public void ThisGameEndControl()
    {
        if(PlayerPrefs.GetInt("ThisGameEnd")==1)
        {
            GameEndCanvas.SetActive(true);
            PlayerPrefs.SetInt("ThisGameEnd", 0);
            StartMenuCanvas.SetActive(false);
        }
    }
    public void LoadValues()
    {
        LoadData.loadData();

        VolumeControl();

        ContinueControl();

        GameEndControl();
    }


    void Update()
    {
        EndText.transform.position += new Vector3(0, 0.5f, 0) * Time.deltaTime;
    }
}
