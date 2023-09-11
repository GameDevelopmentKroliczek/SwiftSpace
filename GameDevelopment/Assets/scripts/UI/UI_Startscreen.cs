using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI_Startscreen : MonoBehaviour
{
    public string loadLevel;
    public GameObject Playermodels;
    public GameObject Startmenu;
    public GameObject CharacterList;
    public GameObject Credits;
    public GameObject MusicButton;
    public GameObject SoundButton;
    public Sprite MusicPauseButton;
    public Sprite MusicPlayButton;
    public Sprite SoundPauseButton;
    public Sprite SoundPlayButton;
    public bool MusicSpriteIsActive = true;
    public bool SoundIsActive = true;
    private Animator anim;

    public void Start()
    {
        Time.timeScale = 1;
        FindObjectOfType<AudioManager>().NewScene();
        
    }
   

    public void Update()
    {

        SoundIsActive = (PlayerPrefs.GetInt("SoundIsActive") != 0);

        if (SoundIsActive)
        {
            SoundButton.GetComponent<Image>().sprite = SoundPlayButton;
        }
        else
        {
            SoundButton.GetComponent<Image>().sprite = SoundPauseButton;
        }

        MusicSpriteIsActive = (PlayerPrefs.GetInt("MusicSpriteIsActive") != 0);

        if (MusicSpriteIsActive)
        {
            MusicButton.GetComponent<Image>().sprite = MusicPlayButton;
        }
        else
        {
            MusicButton.GetComponent<Image>().sprite = MusicPauseButton;
        }
    }


    public void StartGame()
    {
        Startmenu.gameObject.SetActive(false);
        LoadingScene.FindObjectOfType<LoadingScene>().LoadScene();
        Time.timeScale = 1f;

    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void changePlayerModels()
    {
        Playermodels.gameObject.SetActive(true);
        Startmenu.gameObject.SetActive(false);
        CharacterList.SetActive(true);
    }

    public void OpenCredits()
    {
        Credits.gameObject.SetActive(true);
        Startmenu.gameObject.SetActive(false);
        CharacterList.gameObject.SetActive(false);
    }

    public void deactivateMusic()
    {
      
        if (FindObjectOfType<AudioManager>().MusicIsActive == true)
        {
            //MusicButton.GetComponent<Image>().sprite = MusicPauseButton;
            FindObjectOfType<AudioManager>().MusicIsActive = false;
            FindObjectOfType<AudioManager>().NewScene();
            PlayerPrefs.SetInt("MusicSpriteIsActive", (FindObjectOfType<AudioManager>().MusicIsActive ? 0 : 0));
            
        }
        else if (FindObjectOfType<AudioManager>().AllSoundIsActive == true && FindObjectOfType<AudioManager>().MusicIsActive == false)
        {
            //MusicButton.GetComponent<Image>().sprite = MusicPlayButton;
            FindObjectOfType<AudioManager>().MusicIsActive = true;
            FindObjectOfType<AudioManager>().NewScene();
            PlayerPrefs.SetInt("MusicSpriteIsActive", (FindObjectOfType<AudioManager>().MusicIsActive ? 1 : 0));
            

        }

      
    }

    public void deactivateSound()
    {
       
        if (FindObjectOfType<AudioManager>().AllSoundIsActive == true)
        {
            //MusicButton.GetComponent<Image>().sprite = MusicPauseButton;
            //SoundButton.GetComponent<Image>().sprite = SoundPauseButton;
            FindObjectOfType<AudioManager>().AllSoundIsActive = false;
            FindObjectOfType<AudioManager>().MusicIsActive = false;
            FindObjectOfType<AudioManager>().NewScene();
            PlayerPrefs.SetInt("SoundIsActive", (FindObjectOfType<AudioManager>().AllSoundIsActive ? 0 : 0));
            PlayerPrefs.SetInt("MusicSpriteIsActive", (FindObjectOfType<AudioManager>().MusicIsActive ? 0 : 0));
        }
        else 
        {
            ///MusicButton.GetComponent<Image>().sprite = MusicPlayButton;
            //SoundButton.GetComponent<Image>().sprite = SoundPlayButton;
            FindObjectOfType<AudioManager>().AllSoundIsActive = true;
            FindObjectOfType<AudioManager>().MusicIsActive = true;
            FindObjectOfType<AudioManager>().NewScene();
            PlayerPrefs.SetInt("SoundIsActive", (FindObjectOfType<AudioManager>().AllSoundIsActive ? 1 : 0));
            PlayerPrefs.SetInt("MusicSpriteIsActive", (FindObjectOfType<AudioManager>().MusicIsActive ? 1 : 0));
        }

      
    }


}
