using UnityEngine;
using UnityEngine.UIElements;

public class TitleUIManager : VisualElement {
    VisualElement btnQuit;
    VisualElement btnStart;

    GameObject AudioHauntedHouse;
    AudioSource AudioSourceAudioHauntedHouse;
    AudioClip AudioClipHauntedHouse;

    public new class UxmlFactory : UxmlFactory<TitleUIManager, UxmlTraits> { }
    public TitleUIManager() {
        RegisterCallback<GeometryChangedEvent>(OnGeometryChange);
    }
    void OnGeometryChange(GeometryChangedEvent evt) {
        btnQuit = this.Q("btnQuit");
        btnQuit?.RegisterCallback<ClickEvent>(ev => ClickedQuit());

        btnStart = this.Q("btnStart");
        btnStart?.RegisterCallback<ClickEvent>(ev => ClickedStart());
    }
    void ClickedQuit() {
        Debug.Log("Clicked quit game");
        Application.Quit();
    }
    void ClickedStart() {
        AudioHauntedHouse = GameObject.Find("AudioHauntedHouse");
        AudioSourceAudioHauntedHouse = AudioHauntedHouse.GetComponent<AudioSource>();
        AudioClipHauntedHouse = AudioSourceAudioHauntedHouse.clip;

        Debug.Log("game start");
        PlayHauntedHouse();
    }
    void PlayHauntedHouse() {
        AudioSourceAudioHauntedHouse.Play();
    }

    void GoToScene() {
        int counter = 0;
        while (counter < 12000) {
            counter++;
        }
    }
}