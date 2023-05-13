using UnityEngine.Audio;
using System;
using UnityEngine.SceneManagement;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public bool AllSoundIsActive = true;
    public bool MusicIsActive = true;
    public bool ActivateSFX;
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

        AllSoundIsActive = true;
        
    }

 

    public void NewScene()
    {
        Scene scene = SceneManager.GetActiveScene();

        if (MusicIsActive == true && AllSoundIsActive == true)
        {
            AudioListener.volume = 1f;
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
        else if (MusicIsActive == false && AllSoundIsActive == false)
        {
            AudioListener.volume = 0f;
            
            StopSound("Music");
            StopSound("MenuSound");
          
        }
        //Only SFX
        else if (MusicIsActive == false && AllSoundIsActive == true)
        {
            StopSound("MenuSound");
            StopSound("Music");
            AudioListener.volume = 1f;
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
