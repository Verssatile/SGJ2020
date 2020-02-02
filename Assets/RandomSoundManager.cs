using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RandomSoundManager : MonoBehaviour
{
    AudioSource audio;
    public AudioClip[] clips;
    void Start()
    {
        audio = GetComponent<AudioSource>();
        clips = Resources.LoadAll("AudioLoops").Cast<AudioClip>().ToArray();
        
    }

    public void PlayRandomSound()
    {
        int randomIndex = Random.Range(0, clips.Length);
        Debug.Log(randomIndex+" : "+clips.Length);
        audio.clip = clips[randomIndex];
        audio.Play();
    }
}
