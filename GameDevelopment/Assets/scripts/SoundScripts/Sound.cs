using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class Sound
{
    public string name;

    public AudioClip Clip;

    [Range(0f,1f)]
    public float volume;
    [Range(0.1f, 3f)]
    public float pitch;

    public bool Loop;

    [HideInInspector]
    public AudioSource source;
}
