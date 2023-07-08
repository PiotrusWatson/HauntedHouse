using UnityEngine;
using UnityEngine.UIElements;

public class GameUIManager : VisualElement
{
    VisualElement btnQuit;
    VisualElement btnStart;
    public new class UxmlFactory : UxmlFactory<GameUIManager, UxmlTraits> { }
    public GameUIManager()
    {
        RegisterCallback<GeometryChangedEvent>(OnGeometryChange);
    }
    void OnGeometryChange(GeometryChangedEvent evt)
    {
        btnQuit = this.Q("btnQuit");
        btnQuit?.RegisterCallback<ClickEvent>(ev => ClickedQuit());

        btnStart = this.Q("btnStart");
        btnStart?.RegisterCallback<ClickEvent>(ev => ClickedStart());
    }
    void ClickedQuit()
    {
        Debug.Log("Clicked quit game");
    }
    void ClickedStart()
    {
        Debug.Log("Clicked start game");
    }
}