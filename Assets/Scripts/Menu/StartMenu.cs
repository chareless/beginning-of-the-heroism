using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour
{
    public GameObject StartMenuCanvas;
    public GameObject OptionsCanvas;
    public GameObject CreditsCanvas;
    public GameObject SelectCharacterCanvas;
    public GameObject ButtonContinue;
    public Button button30fps;
    public Button button60fps;
    public Button button75fps;
    public Button SelectRogue;
    public Button SelectWizard;
    public Button SelectArcher;
    public Button SelectKnight;
    public Text gameVersion;
    public Text volumeText;
    public Text fpsText;
    public Slider volumeSlider;
    public AudioSource ClickSound;
    public AudioClip nextClick;
    public AudioClip backClick;
    public static int maxFPS = 60;
    public static float volumeValue;
    public static bool isContinue;
    public void Start()
    {
        LoadValues();
        gameVersion.text = Application.version;
        fpsText.text = Application.targetFrameRate.ToString();
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
    }

    public void RogueButton()
    {
        Status.playerClass = "Rogue";
        SelectWizard.interactable = false;
        SelectArcher.interactable = false;
        SelectKnight.interactable = false;
        PlayNextClick();
        SceneManager.LoadScene("SampleScene");
    }

    public void WizardButton()
    {
        Status.playerClass = "Wizard";
        SelectRogue.interactable = false;
        SelectArcher.interactable = false;
        SelectKnight.interactable = false;
        PlayNextClick();
        SceneManager.LoadScene("SampleScene");
    }

    public void ArcherButton()
    {
        Status.playerClass = "Archer";
        SelectRogue.interactable = false;
        SelectWizard.interactable = false;
        SelectKnight.interactable = false;
        PlayNextClick();
        SceneManager.LoadScene("SampleScene");
    }

    public void KnightButton()
    {
        Status.playerClass = "Knight";
        SelectRogue.interactable = false;
        SelectWizard.interactable = false;
        SelectArcher.interactable = false;
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
        PlayerPrefs.SetInt("MaxFPS", maxFPS);
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
        PlayBackClick();
    }

    public void QuitButton()
    {
        PlayNextClick();
        Application.Quit();
    }

    public void ContinueControl()
    {

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

    public void Button30()
    {
        maxFPS = 30;
        button30fps.interactable = false;
        button60fps.interactable = true;
        button75fps.interactable = true;
        PlayNextClick();
    }
    public void Button60()
    {
        maxFPS = 60;
        button30fps.interactable = true;
        button60fps.interactable = false;
        button75fps.interactable = true;
        PlayNextClick();
    }

    public void Button75()
    {
        maxFPS = 75;
        button30fps.interactable = true;
        button60fps.interactable = true;
        button75fps.interactable = false;
        PlayNextClick();
    }

    public void FPSControl()
    {
        if (PlayerPrefs.GetInt("MaxFPS") != 0)
        {
            maxFPS = PlayerPrefs.GetInt("MaxFPS");
        }

        Application.targetFrameRate = maxFPS;
        fpsText.text = Application.targetFrameRate.ToString();

        if(Application.targetFrameRate == 30)
        {
            button30fps.interactable = false;
            button60fps.interactable = true;
            button75fps.interactable = true;
        }
        if (Application.targetFrameRate == 60)
        {
            button30fps.interactable = true;
            button60fps.interactable = false;
            button75fps.interactable = true;
        }
        if (Application.targetFrameRate == 75)
        {
            button30fps.interactable = true;
            button60fps.interactable = true;
            button75fps.interactable = false;
        }
    }

    public void GameEndControl()
    {
        SelectKnight.interactable = false;
    }
    public void LoadValues()
    {
        //LoadData.loadData();

        VolumeControl();

        FPSControl();

        ContinueControl();

        GameEndControl();
    }


    void Update()
    {
        
    }
}
