using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class Sound
{
    //Name of the song
    public string name;
    //The mp3 file of the song
    public AudioClip clip;

    [Range(0f,1f)]
    public float volume = 1f;

    [Range(.1f, 3f)]
    public float pitch = 1f;

    public bool loop;

    [HideInInspector]
    public AudioSource source;
}
