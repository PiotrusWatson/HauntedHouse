using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitForAudio : MonoBehaviour {
    GameObject AudioHauntedHouse;
    AudioSource AudioSourceAudioHauntedHouse;
    AudioClip AudioClipHauntedHouse;

    TitleUIManager TitleUIManager;

    void Start() {
        AudioHauntedHouse = GameObject.Find("AudioHauntedHouse");
        AudioSourceAudioHauntedHouse = AudioHauntedHouse.GetComponent<AudioSource>();
        AudioClipHauntedHouse = AudioSourceAudioHauntedHouse.clip;
    }

    void Update() {
      //  if (GetComponent<TitleUIManager>("clickedStart")) {
        //    StartCoroutine("WaitForAudioEnd", AudioClipHauntedHouse.length);
        //}
    }

    void WaitForAudioEnd() {
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }
}
