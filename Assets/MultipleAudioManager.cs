using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultipleAudioManager : MonoBehaviour
{
    AudioSource[] sources;
    // Start is called before the first frame update
    void Awake()
    {
        sources = GetComponentsInChildren<AudioSource>();
    }

    AudioSource FindUnoccupiedSource(){
        foreach (AudioSource source in sources){
            if (!source.isPlaying){
                return source;
            }
        }
        return sources[sources.Length - 1];
    }

    public void Play(AudioClip clip){
        AudioSource bestSource = FindUnoccupiedSource();
        bestSource.clip = clip;
        bestSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
