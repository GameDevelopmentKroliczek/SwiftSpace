using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneAudio : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Scene scene = SceneManager.GetActiveScene();

        if (FindObjectOfType<AudioManager>().AllSoundIsActive == true && FindObjectOfType<AudioManager>().MusicIsActive == true)
        {
            if (scene.name == "PlayScene")
            {
                FindObjectOfType<AudioManager>().PlaySound("Music");
                FindObjectOfType<AudioManager>().StopSound("MenuSound");
            }

            if (scene.name == "StartScene")
            {
                FindObjectOfType<AudioManager>().PlaySound("MenuSound");
                FindObjectOfType<AudioManager>().StopSound("Music");
            }
        }
        else if (FindObjectOfType<AudioManager>().AllSoundIsActive == true && FindObjectOfType<AudioManager>().MusicIsActive == false)
        {
            FindObjectOfType<AudioManager>().StopSound("MenuSound");
            FindObjectOfType<AudioManager>().StopSound("Music");
        }
        else if (FindObjectOfType<AudioManager>().AllSoundIsActive == false)
        {
            FindObjectOfType<AudioManager>().StopSound("MenuSound");
            FindObjectOfType<AudioManager>().StopSound("Music");
            AudioListener.volume = 0f;
        }
    }


}
