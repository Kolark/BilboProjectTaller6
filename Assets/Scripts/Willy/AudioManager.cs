using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;

public class AudioManager : MonoBehaviour
{
    public Sound[] soundsX;

    public Dictionary<string,Sound> sounds = new Dictionary<string,Sound>();

    public static AudioManager instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
        AddSounds(soundsX);
        //foreach (KeyValuePair<string,Sound> s in sounds)
        //{
        //    s.Value.source = gameObject.AddComponent<AudioSource>();
        //    s.Value.source.clip = s.Value.clip;

        //    s.Value.source.volume = s.Value.volume;
        //    s.Value.source.pitch = s.Value.pitch;
        //    s.Value.source.loop = s.Value.loop;
        //    s.Value.source.outputAudioMixerGroup = s.Value.group;
        //}
    }

    public void Play(string name)
    {
        //Sound s = Array.Find(sounds, sound => sound.name == name);
        Sound s = sounds[name];
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " nor found!");
            return;
        }
        if (s.source == null)
        {
            Debug.LogWarning("No Audio Source");
            return;
        }
        s.source.Play();

    }

    public bool isPlaying(string name)
    {
        //Sound s = Array.Find(sounds, sound => sound.name == name);
        Sound s = sounds[name];

        return s.source.isPlaying;

    }

    public void StopPlaying(string name)
    {
        //Sound s = Array.Find(sounds, item => item.name == sound);
        Debug.Log("nm : " + name);
        Sound s = sounds[name];
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }

        s.source.Stop();
    }

    public void AddSounds(Sound[] s)
    {
        for (int i = 0; i < s.Length; i++)
        {
            sounds.Add(s[i].name, s[i]);
            s[i].source = gameObject.AddComponent<AudioSource>();
            s[i].source.clip = s[i].clip;

            s[i].source.volume = s[i].volume;
            s[i].source.pitch = s[i].pitch;
            s[i].source.loop = s[i].loop;
            s[i].source.outputAudioMixerGroup = s[i].group;
        }
    }

    public void RemoveSound(Sound[] s)
    {
            for (int i = 0; i < s.Length; i++)
        {
            Debug.Log("Removing Sound" + s[i].name);
            sounds.Remove(s[i].name);
            Debug.Log("Done Removing");
        }
    }
}
