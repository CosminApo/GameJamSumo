using System;
using UnityEngine.Audio;
using UnityEngine;
using System.Collections;


public class AudioManager : MonoBehaviour
{
    public Sound[] sounds; //store all the sounds the game needs to play here
    Sound s1;
    Sound s2;
    Sound s3;
    void Awake()
    {
        foreach (Sound s in sounds) //add an audio source component to each sound object at the start
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.loop = s.loop;
            s.source.volume = s.volume;
            s.source.outputAudioMixerGroup = s.mixer;
        }
        s1 = Array.Find(sounds, sound => sound.name == "Music1");
        s2 = Array.Find(sounds, sound => sound.name == "Music2");
        s3 = Array.Find(sounds, sound => sound.name == "Music3");
    }

    void Update()
    {
        if (!s1.source.isPlaying && !s2.source.isPlaying && !s3.source.isPlaying)
        StartCoroutine(PlayMusic());
    }

    IEnumerator PlayMusic()
    {
        s1.source.Play();
        yield return new WaitForSeconds(s1.source.clip.length);
    
        s2.source.Play();
        yield return new WaitForSeconds(s2.source.clip.length);

        s3.source.Play();
        yield return new WaitForSeconds(s3.source.clip.length);

    }
    public void Play (string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (!s.source.isPlaying)
        s.source.Play();
    }
}
