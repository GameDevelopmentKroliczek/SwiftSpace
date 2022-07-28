using UnityEngine.Audio;
using System;
using UnityEngine.SceneManagement;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public bool ActivateMusic;
    public Sound[] sounds;
    public static AudioManager instance;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach (Sound s in sounds)
        {
           s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.Clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.Loop;
        }

        ActivateMusic = true;
        
    }

    public void NewScene()
    {
        Scene scene = SceneManager.GetActiveScene();

        if (ActivateMusic == true)
        {
            if (scene.name == "PlayScene")
            {
                PlaySound("Music");
                StopSound("MenuSound");
            }

            if (scene.name == "StartMenu")
            {
                PlaySound("MenuSound");
                StopSound("Music");
            }
        }
        else
        {
            StopSound("MenuSound");
            StopSound("Music");
        }
    }

    public void PlaySound(string name)
    {
       
       Sound s =  Array.Find(sounds, sound => sound.name == name);
         if(s == null)
        {
            return;
            Debug.LogWarning("Sound:" + name + "not found");
        }

        s.source.Play();
    }
    public void PlayOneShotSound(string name)
    {

        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            return;
            Debug.LogWarning("Sound:" + name + "not found");
        }

     
        s.source.PlayOneShot(s.Clip);
    }



    public void StopSound(string name)
    {

        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            return;
            Debug.LogWarning("Sound:" + name + "not found");
        }

        s.source.Stop();
    }
}
