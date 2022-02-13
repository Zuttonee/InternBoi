using System;
using UnityEngine;

//Code to play music in the audio manager :)
//FindObjectType<AudioManager>().Play("add _sound_name");

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    //make AudioMange be accessable from other scripts
    public static AudioManager instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return; 
        }

        //Keep the game object so that music will not be cut off when changing scene
        DontDestroyOnLoad(gameObject);

        //Add AudioSource to enable the gameobject to play music
        foreach(Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    public void Start()
    {
        Play("Theme"); //Play Theme when the game is started
    }

    public void Play(string name)
    {
        //Songs will be search by their name
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }

        s.source.Play(); 
    }
}
