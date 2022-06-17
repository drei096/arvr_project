using UnityEngine;
using UnityEngine.Audio;
using System;

public class AudioManager : MonoBehaviour
{

    public Sound[] sounds;

    void Awake()
    {
        foreach (Sound sound in sounds)
        {
            sound.source = gameObject.AddComponent<AudioSource>();
            sound.source.clip = sound.clip;
            sound.source.volume = sound.volume;
            sound.source.pitch = sound.pitch;
            sound.source.loop = sound.loop;
        }
    }

    void Start()
    {
        Play(SoundCode.CRY_BULBASAUR);
    }

    public void Play(SoundCode code)
    {
        Sound s = Array.Find(sounds, sound => sound.code == code);
        if (s == null) return;
        s.source.Play();
    }

}
