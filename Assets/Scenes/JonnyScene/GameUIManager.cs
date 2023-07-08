using UnityEngine;
using UnityEngine.UIElements;

public class GameUIManager : VisualElement {
    VisualElement btnQuit;
    VisualElement btnStart;

    bool clickedQuit = false;
    bool clickedStart = false;

    GameObject AudioHauntedHouse;
    AudioSource AudioSourceAudioHauntedHouse;
    AudioClip AudioClipHauntedHouse;

    public new class UxmlFactory : UxmlFactory<GameUIManager, UxmlTraits> { }
    public GameUIManager() {
        RegisterCallback<GeometryChangedEvent>(OnGeometryChange);
    }
    void OnGeometryChange(GeometryChangedEvent evt) {
        btnQuit = this.Q("btnQuit");
        btnQuit?.RegisterCallback<ClickEvent>(ev => ClickedQuit());

        btnStart = this.Q("btnStart");
        btnStart?.RegisterCallback<ClickEvent>(ev => ClickedStart());
    }
    void Start() {
    }
    void Update() {
    }
    void ClickedQuit() {
        Debug.Log("Clicked quit game");
        clickedQuit = true;
    }
    void ClickedStart() {
        AudioHauntedHouse = GameObject.Find("AudioHauntedHouse");
        AudioSourceAudioHauntedHouse = AudioHauntedHouse.GetComponent<AudioSource>();
        AudioClipHauntedHouse = AudioSourceAudioHauntedHouse.clip;

        Debug.Log("game start");
        clickedStart = true;

        PlayHauntedHouse();
        clickedStart = false;
    }
    void PlayHauntedHouse() {
        AudioSourceAudioHauntedHouse.Play();
    }
}